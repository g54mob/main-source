using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using DV;
using DV.TerrainSystem;
using DV.ThingTypes;
using DV.Utils;
using DV.VFX;
using DV.WeatherSystem;
using DV.WorldTools;
using UnityEngine;

public class HazmatTileManager : SingletonBehaviour<HazmatTileManager>
{
	private class TerrainChunkData
	{
		public Vector2Int coord;

		public TerrainData terrainData;

		public bool shouldUpdateSplatsOnReload;

		public bool flaggedForSplatUpdate;

		public bool hasModifiedData;

		private int tilesPerTerrain;

		private float[,,] _sourceSplatData;

		private float[,,] _overlaySplatData;

		private float[,,] _blendedSplatData;

		public bool IsLoaded => sourceSplatData != null;

		public float[,,] sourceSplatData
		{
			get
			{
				if (_sourceSplatData == null)
				{
					if (terrainData == null)
					{
						return null;
					}
					_sourceSplatData = terrainData.GetAlphamaps(0, 0, tilesPerTerrain, tilesPerTerrain);
				}
				return _sourceSplatData;
			}
		}

		public float[,,] overlaySplatData
		{
			get
			{
				if (_overlaySplatData == null)
				{
					_overlaySplatData = new float[tilesPerTerrain, tilesPerTerrain, 16];
				}
				return _overlaySplatData;
			}
		}

		public float[,,] blendedSplatData
		{
			get
			{
				if (_blendedSplatData == null)
				{
					float[,,] array = sourceSplatData;
					if (array == null)
					{
						return null;
					}
					_blendedSplatData = new float[array.GetLength(0), array.GetLength(1), array.GetLength(2)];
					Array.Copy(array, _blendedSplatData, array.Length);
					if (overlaySplatData != null && hasModifiedData)
					{
						NormalizeSplatDataWithConstantMember(array, overlaySplatData, _blendedSplatData);
					}
				}
				return _blendedSplatData;
			}
		}

		public TerrainChunkData(TerrainData terrainData, int tilesPerTerrain, Vector2Int coord)
		{
			this.terrainData = terrainData;
			shouldUpdateSplatsOnReload = false;
			flaggedForSplatUpdate = false;
			this.tilesPerTerrain = tilesPerTerrain;
			this.coord = coord;
		}

		public void ResetSplatBools()
		{
			shouldUpdateSplatsOnReload = false;
			flaggedForSplatUpdate = false;
		}

		public void ReleaseData()
		{
			terrainData = null;
			_sourceSplatData = null;
			_blendedSplatData = null;
			if (!hasModifiedData)
			{
				_overlaySplatData = null;
			}
		}
	}

	private enum CellularAutomataState
	{
		EvolveFlow = 0,
		ProcessFlow = 1,
		EvolveIgnition = 2,
		ProcessIgnition = 3,
		EvolveReaction = 4,
		ProcessReaction = 5,
		PrepareTerrainSplatData = 6,
		ApplyTerrainSplatData = 7,
		CleanUp = 8
	}

	private const byte HAZMAT_DATA_VERSION = 3;

	private const int SPLAT_COEFFICIENTS = 16;

	public bool showState;

	public Vector3 worldPosition;

	public float maxWeight = 3000f;

	public float textureWeightToAdd = 2000f;

	public HazmatTerrainEffectsController[] fireEffectsControllerPrefabs;

	public HazmatTerrainEffectsController corrosiveEffectsControllerPrefab;

	public HazmatTerrainEffectsController biohazardEffectsControllerPrefab;

	public HazmatRadioactiveEffect hazmatRadioactiveEffect;

	[NonSerialized]
	public HazmatAudioGrid hazmatAudioGrid;

	public Dictionary<int, float> tileLiquidAmountToBeAddedDictionary = new Dictionary<int, float>();

	public Dictionary<int, CargoType> tileLiquidTypeToBeAddedDictionary = new Dictionary<int, CargoType>();

	public const int TILE_SIZE = 8;

	private const int LIQUID_TEXTURE_INDEX = 14;

	private const int WASTELAND_TEXTURE_INDEX = 15;

	private float heightMapResolution;

	private float heightToSplatRatio;

	private int terrainSpan;

	private int terrainSize;

	private int tilesPerTerrain;

	private int maxTileIndex;

	private const float FLOW_HEIGHT_THRESHOLD = -0.2f;

	private const float DIRECTIONAL_FLOW_DELTA_HEIGHT_THRESHOLD = 0.2f;

	private const float DEFAULT_FIRE_EMISSION_OVER_TIME = 10f;

	private const float DEFAULT_EMISSION_RADIUS = 4f;

	private const string TERRAIN_FIRE_EFFECTS_NAME = "TerrainFireParticle_{0}_{1}";

	private const string TERRAIN_CORROSIVE_EFFECTS_NAME = "TerrainCorosiveParticle_{0}_{1}";

	private const string TERRAIN_BIOHAZARD_EFFECTS_NAME = "TerrainBiohazardParticle_{0}_{1}";

	private const string TERRAIN_RADIOACTIVE_EFFECTS_NAME = "TerrainRadioactiveParticle_{0}_{1}";

	private const float positionReferenceOffsetX = 0f;

	private const float positionReferenceOffsetY = 0f;

	private static readonly byte[] PLAIN_MAGIC = new byte[2] { 213, 0 };

	private TerrainChunkData[,] terrainChunkDataCollection;

	private List<KeyValuePair<int, HazmatGridTile>> tileList = new List<KeyValuePair<int, HazmatGridTile>>();

	private int ignitionRobin;

	private Queue<TerrainChunkData> terrainsPendingPainting = new Queue<TerrainChunkData>();

	private List<ICargoLeak> gasLeakSources = new List<ICargoLeak>();

	private List<Transform> explosionEpicenters = new List<Transform>();

	private byte[] dataToLoad;

	private CellularAutomataState state;

	private Color orange = new Color(0.99215686f, 0.64705884f, 1f / 17f);

	private const int HALF_TILE_SIZE = 4;

	private Vector3 tileSizeOffset = new Vector3(4f, 0f, 4f);

	private const float MAX_SPECIAL_TEXTURE_WEIGHT = 0.4f;

	private const float MAX_BURN_TIME = 15f;

	private float[] blendBuffer = new float[16];

	private const string PROFILER_EVOLVE_LIQUID = "HZMT Evolve Liquid";

	private const string PROFILER_PROCESS_LIQUID = "HZMT Process Liquid";

	private const string PROFILER_EVOLVE_IGNITION = "HZMT Evolve Ignition";

	private const string PROFILER_PROCESS_IGNITION = "HZMT Process Ignition";

	private const string PROFILER_PREPARE_SPLAT = "HZMT Prepare Splat";

	private const string PROFILER_APPLY_SPLAT = "HZMT Apply Splat";

	private const string PROFILER_PREPARE_REACTION = "HZMT Prepare Reaction";

	private const string PROFILER_PROCESS_REACTION = "HZMT Process Reaction";

	private const string PROFILER_CLEANUP = "HZMT Clean Up";

	private const string PROFILER_FLOW = "HZMT Flow Liquid";

	private const string PROFILER_NEIGHBOUR_FETCH = "HZMT Neighbour Fetching";

	private float reactionTimer;

	private int[] liquidTileKeys;

	private HazmatGridTile[] liquidNeighbours = new HazmatGridTile[4];

	private HazmatGridTile[] existingNeighbours = new HazmatGridTile[4];

	[InspectorButton("RemoveTilesDebug", true, true)]
	public bool removeTilesDebug;

	[InspectorButton("GetGridPositionFromWorldPositionDebug", true, true)]
	public bool getGridPositionFromWorldPosition;

	[InspectorButton("AddLiquidToTile", true, true)]
	public bool addLiquidToTile;

	public CargoType liquidTypeToAdd = CargoType.Gasoline;

	[InspectorButton("GetAllWeights", true, true)]
	public bool getAllWeights;

	[InspectorButton("IgniteTileDebug", true, true)]
	public bool igniteTileDebug;

	[InspectorButton("CenterOnPlayer", true, true)]
	public bool centerOnPlayer;

	[InspectorButton("GetTerrain", true, true)]
	public bool getTerrain;

	[InspectorButton("GetHeight", true, true)]
	public bool getHeight;

	public HashSet<int> IgnitedTileCoords { get; private set; } = new HashSet<int>();

	public Dictionary<int, HazmatGridTile> TileDictionary { get; private set; } = new Dictionary<int, HazmatGridTile>();

	protected override void Awake()
	{
		base.Awake();
		hazmatAudioGrid = GetComponent<HazmatAudioGrid>();
		if ((bool)SingletonBehaviour<TerrainGrid>.Instance && SingletonBehaviour<TerrainGrid>.Instance.IsInitialized)
		{
			OnTerrainGridInitialized();
			return;
		}
		TerrainGrid.Initialized += OnTerrainGridInitialized;
		base.enabled = false;
	}

	private void OnTerrainGridInitialized()
	{
		TerrainGrid.Initialized -= OnTerrainGridInitialized;
		if (!SingletonBehaviour<LevelInfo>.Instance)
		{
			UnityEngine.Debug.LogError("LevelInfo is not present. Hazmat terrain features are disabled.");
			return;
		}
		int splatsCount = SingletonBehaviour<LevelInfo>.Instance.splatsCount;
		int num = SingletonBehaviour<LevelInfo>.Instance.terrainSpan;
		float num2 = SingletonBehaviour<LevelInfo>.Instance.heightMapResolution;
		float splatResolution = SingletonBehaviour<LevelInfo>.Instance.splatResolution;
		int num3 = (int)SingletonBehaviour<LevelInfo>.Instance.terrainSize;
		if (num <= 0 || num2 <= 0f || splatResolution <= 0f || num3 <= 0)
		{
			UnityEngine.Debug.LogError("Terrains data was not deserialized properly. Hazmat terrain features are disabled.");
			return;
		}
		terrainSpan = num;
		heightMapResolution = num2;
		terrainSize = num3;
		heightToSplatRatio = num2 / splatResolution;
		tilesPerTerrain = num3 / 8;
		maxTileIndex = tilesPerTerrain * num - 1;
		terrainChunkDataCollection = new TerrainChunkData[num, num];
		int num4 = -1;
		for (int i = 0; i < splatsCount; i++)
		{
			int num5 = i % terrainSpan;
			if (num5 == 0)
			{
				num4++;
			}
			terrainChunkDataCollection[num5, num4] = new TerrainChunkData(null, tilesPerTerrain, new Vector2Int(num5, num4));
		}
		TerrainGrid.TerrainDataLoaded += OnTerrainDataLoaded;
		TerrainGrid.TerrainDataAboutToBeUnloaded += OnTerrainDataAboutToBeUnloaded;
		foreach (GameObject generatedTerrain in SingletonBehaviour<TerrainGrid>.Instance.generatedTerrains)
		{
			generatedTerrain.AddComponent<HazmatParticleDetector>();
		}
		base.enabled = true;
		if (dataToLoad != null)
		{
			Deserialize(dataToLoad);
			dataToLoad = null;
		}
	}

	public byte[] Serialize()
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(PLAIN_MAGIC, 0, PLAIN_MAGIC.Length);
		SerializeToStream(memoryStream);
		return memoryStream.ToArray();
	}

	public void Deserialize(byte[] rawBytes)
	{
		if (base.enabled)
		{
			if (rawBytes != null && rawBytes.Length != 0)
			{
				if (rawBytes.Length < 2)
				{
					throw new InvalidDataException("Hazmat binary doesn't even have a full magic header, something is wrong");
				}
				MemoryStream memoryStream = new MemoryStream(rawBytes);
				if (rawBytes[0] != PLAIN_MAGIC[0] || rawBytes[1] != PLAIN_MAGIC[1])
				{
					throw new InvalidDataException("Unrecognized hazmat data header: " + rawBytes[0].ToString("X2") + " " + rawBytes[1].ToString("X2"));
				}
				memoryStream.Seek(2L, SeekOrigin.Current);
				DeserializeFromStream(memoryStream);
			}
		}
		else
		{
			dataToLoad = rawBytes;
		}
	}

	private void SerializeToStream(Stream output)
	{
		using (BinaryWriter binaryWriter = new BinaryWriter(output, Encoding.UTF8, leaveOpen: true))
		{
			binaryWriter.Write((byte)3);
			binaryWriter.Write(TileDictionary.Count);
			binaryWriter.Write(HazmatGridTile.CARGO_TYPES.Length);
			foreach (KeyValuePair<int, HazmatGridTile> tile in tileList)
			{
				binaryWriter.Write(tile.Key);
				tile.Value.SerializeData(binaryWriter);
			}
		}
	}

	private void DeserializeFromStream(Stream input)
	{
		using (BinaryReader binaryReader = new BinaryReader(input))
		{
			byte b = binaryReader.ReadByte();
			if (b != 3)
			{
				UnityEngine.Debug.LogError($"Hazmat data of unknown version: {b} (expected {(byte)3}). Skipping hazmat data loading!");
				return;
			}
			int num = binaryReader.ReadInt32();
			int num2 = binaryReader.ReadInt32();
			if (num2 > HazmatGridTile.CARGO_TYPES.Length)
			{
				throw new InvalidOperationException($"Higher number of cargo types: {num2} in file vs {HazmatGridTile.CARGO_TYPES.Length} in game");
			}
			for (int i = 0; i < num; i++)
			{
				int gridCoords = binaryReader.ReadInt32();
				HazmatGridTile tileFromCoords = GetTileFromCoords(gridCoords);
				tileFromCoords.DeserializeData(binaryReader, b);
				if (tileFromCoords.IsIgnited)
				{
					BurnTerrainTile(tileFromCoords);
				}
				if (tileFromCoords.IsCorroded)
				{
					CorrodeTerrainTile(tileFromCoords);
				}
				if (tileFromCoords.IsDefiled)
				{
					DefileTile(tileFromCoords);
				}
				PrepareTerrainPaintData(14, tileFromCoords.currentWeight, gridCoords);
			}
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		TerrainGrid.TerrainDataLoaded -= OnTerrainDataLoaded;
		TerrainGrid.TerrainDataAboutToBeUnloaded -= OnTerrainDataAboutToBeUnloaded;
		TerrainGrid.Initialized -= OnTerrainGridInitialized;
	}

	private void OnTerrainDataLoaded(TerrainData terrainData, Vector2Int terrainGridCoords)
	{
		TerrainChunkData terrainChunkData = terrainChunkDataCollection[terrainGridCoords.x, terrainGridCoords.y];
		terrainChunkData.terrainData = terrainData;
		if (terrainChunkData.shouldUpdateSplatsOnReload || terrainChunkData.hasModifiedData)
		{
			terrainChunkData.shouldUpdateSplatsOnReload = false;
			terrainChunkData.flaggedForSplatUpdate = true;
			terrainsPendingPainting.Enqueue(terrainChunkData);
		}
	}

	private void OnTerrainDataAboutToBeUnloaded(TerrainData terrainData, Vector2Int terrainGridCoords)
	{
		TerrainChunkData terrainChunkData = terrainChunkDataCollection[terrainGridCoords.x, terrainGridCoords.y];
		if (terrainChunkData == null)
		{
			UnityEngine.Debug.LogError($"Trying to set chunk to unloaded but it is null at {terrainGridCoords.x}, {terrainGridCoords.y}", this);
			return;
		}
		terrainChunkData.ReleaseData();
		terrainChunkData.flaggedForSplatUpdate = false;
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		foreach (KeyValuePair<int, HazmatGridTile> tile in tileList)
		{
			Gizmos.color = (tile.Value.IsIgnited ? orange : Color.cyan);
			Vector3 worldPositionFromGridTile = GetWorldPositionFromGridTile(tile.Value, usingWorldShift: true);
			worldPositionFromGridTile.y = tile.Value.flowHeight;
			Gizmos.DrawWireCube(worldPositionFromGridTile, new Vector3(7f, Mathf.Clamp(3f * tile.Value.currentWeight / maxWeight, 0f, 5f), 7f));
		}
		Gizmos.color = Color.red;
		Vector3 worldPositionFromGridTileGizmo = GetWorldPositionFromGridTileGizmo();
		worldPositionFromGridTileGizmo.y = HeightMapProvider.GetPointSample(worldPositionFromGridTileGizmo);
		Gizmos.DrawWireCube(worldPositionFromGridTileGizmo, new Vector3(7.5f, 7.7f, 7.5f));
	}

	public void AddGasSource(ICargoLeak gasLeak)
	{
		if (!gasLeakSources.Contains(gasLeak))
		{
			gasLeakSources.Add(gasLeak);
		}
	}

	public void RemoveGasSource(ICargoLeak gasLeak)
	{
		if (gasLeakSources.Contains(gasLeak))
		{
			gasLeakSources.Remove(gasLeak);
		}
	}

	public void AddExplosionSource(Transform explosionEpicenter)
	{
		if (explosionEpicenters.Contains(explosionEpicenter))
		{
			explosionEpicenters.Add(explosionEpicenter);
		}
	}

	private void ApplyGasReactionModifier(Vector3 center, float radius, CargoType gas)
	{
		int gridPositionFromWorldPosition = GetGridPositionFromWorldPosition(center);
		int tileCoordX = GetTileCoordX(gridPositionFromWorldPosition);
		int tileCoordY = GetTileCoordY(gridPositionFromWorldPosition);
		int num = ((int)radius + 4) / 8;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = (num + 1) / 3;
		HazmatGridTile value = null;
		float reactivityModifierToOthers = TrainCarAndCargoDamageProperties.CargoReactionProperties[gas].reactivityModifierToOthers;
		for (int i = -3 * num2 - 1; i <= 3 * num2 + 1; i++)
		{
			for (int j = -3 * num2 - 1; j <= 3 * num2 + 1; j++)
			{
				if (Mathf.Abs(i) + Mathf.Abs(j) <= num)
				{
					gridPositionFromWorldPosition = PackGridCoordsToInt(tileCoordX + i, tileCoordY + j);
					TileDictionary.TryGetValue(gridPositionFromWorldPosition, out value);
					if (value != null)
					{
						value.reactionModifier += reactivityModifierToOthers;
					}
				}
			}
		}
	}

	private void ApplyExplosionModifier(Vector3 center)
	{
		int gridPositionFromWorldPosition = GetGridPositionFromWorldPosition(center);
		int tileCoordX = GetTileCoordX(gridPositionFromWorldPosition);
		int tileCoordY = GetTileCoordY(gridPositionFromWorldPosition);
		int num = 3;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = (num + 1) / 3;
		HazmatGridTile value = null;
		for (int i = -3 * num2 - 1; i <= 3 * num2 + 1; i++)
		{
			for (int j = -3 * num2 - 1; j <= 3 * num2 + 1; j++)
			{
				if (Mathf.Abs(i) + Mathf.Abs(j) <= num)
				{
					gridPositionFromWorldPosition = PackGridCoordsToInt(tileCoordX + i, tileCoordY + j);
					TileDictionary.TryGetValue(gridPositionFromWorldPosition, out value);
					if (value != null)
					{
						value.reactionModifier += 200f;
					}
				}
			}
		}
	}

	public List<HazmatGridTile> GetTilesInDiamondAreaAroundWorldPosition(Vector3 worldPos, float radius, bool existingOnly = false, List<HazmatGridTile> tileArea = null)
	{
		if (tileArea == null)
		{
			tileArea = new List<HazmatGridTile>();
		}
		int gridPositionFromWorldPosition = GetGridPositionFromWorldPosition(worldPos);
		int tileCoordX = GetTileCoordX(gridPositionFromWorldPosition);
		int tileCoordY = GetTileCoordY(gridPositionFromWorldPosition);
		int num = (int)(radius + 4f) / 8;
		if (num < 0)
		{
			num = 0;
		}
		HazmatGridTile value = null;
		int num2 = (num + 1) / 3;
		for (int i = -3 * num2 - 1; i <= 3 * num2 + 1; i++)
		{
			for (int j = -3 * num2 - 1; j <= 3 * num2 + 1; j++)
			{
				if (Mathf.Abs(i) + Mathf.Abs(j) <= num)
				{
					gridPositionFromWorldPosition = PackGridCoordsToInt(tileCoordX + i, tileCoordY + j);
					if (existingOnly)
					{
						TileDictionary.TryGetValue(gridPositionFromWorldPosition, out value);
					}
					else
					{
						value = GetTileFromCoords(tileCoordX + i, tileCoordY + j);
					}
					if (value != null)
					{
						tileArea.Add(value);
					}
				}
			}
		}
		return tileArea;
	}

	public List<HazmatGridTile> GetTilesInLine(Vector3 start, Vector3 end, bool existingOnly = false, List<HazmatGridTile> tileLine = null)
	{
		if (tileLine == null)
		{
			tileLine = new List<HazmatGridTile>();
		}
		int gridPositionFromWorldPosition = GetGridPositionFromWorldPosition(start);
		int gridPositionFromWorldPosition2 = GetGridPositionFromWorldPosition(end);
		if (gridPositionFromWorldPosition == gridPositionFromWorldPosition2)
		{
			if (TileDictionary.TryGetValue(gridPositionFromWorldPosition, out var value))
			{
				tileLine.Add(value);
			}
		}
		else
		{
			int tileCoordX = GetTileCoordX(gridPositionFromWorldPosition);
			int tileCoordY = GetTileCoordY(gridPositionFromWorldPosition);
			int tileCoordX2 = GetTileCoordX(gridPositionFromWorldPosition2);
			int tileCoordY2 = GetTileCoordY(gridPositionFromWorldPosition2);
			float num = tileCoordX2 - tileCoordX;
			float num2 = tileCoordY2 - tileCoordY;
			int a = Mathf.RoundToInt(Mathf.Abs(num));
			int b = Mathf.RoundToInt(Mathf.Abs(num2));
			int num3 = Mathf.Max(a, b);
			num /= (float)num3;
			num2 /= (float)num3;
			HazmatGridTile value2 = null;
			for (int i = 0; i <= num3; i++)
			{
				int x = tileCoordX + Mathf.RoundToInt((float)i * num);
				int y = tileCoordY + Mathf.RoundToInt((float)i * num2);
				int num4 = PackGridCoordsToInt(x, y);
				if (existingOnly)
				{
					TileDictionary.TryGetValue(num4, out value2);
				}
				else
				{
					value2 = GetTileFromCoords(num4);
				}
				if (value2 != null)
				{
					tileLine.Add(value2);
				}
			}
		}
		return tileLine;
	}

	private TerrainData GetTerrainDataFromTileCoords(int gridPosition)
	{
		int tileCoordX = GetTileCoordX(gridPosition);
		int tileCoordY = GetTileCoordY(gridPosition);
		return GetTerrainDataFromTileCoords(tileCoordX, tileCoordY);
	}

	private TerrainData GetTerrainDataFromTileCoords(int x, int y)
	{
		Vector3 worldPositionFromGridCoords = GetWorldPositionFromGridCoords(x, y);
		return SingletonBehaviour<TerrainGrid>.Instance.GetLoadedTerrainAt(worldPositionFromGridCoords)?.terrainData;
	}

	private (float flowHeight, float terrainHeight, Vector3 terrainNormal) GetTerrainDataForTile(Vector2Int terrainCoords, int tileX, int tileY)
	{
		(float terrainHeight, float flowHeight) terrainHeightDataAtPoint = GetTerrainHeightDataAtPoint(tileX, tileY, terrainChunkDataCollection[terrainCoords.x, terrainCoords.y]?.terrainData);
		float item = terrainHeightDataAtPoint.terrainHeight;
		float item2 = terrainHeightDataAtPoint.flowHeight;
		float num = heightToSplatRatio / heightMapResolution;
		Vector3 normalPointSampled = HeightMapProvider.GetNormalPointSampled(new Vector3(((float)tileX + 0.5f) * num, 0f, ((float)tileY + 0.5f) * num), usingWorldShift: false);
		return (flowHeight: item2, terrainHeight: item, terrainNormal: normalPointSampled);
	}

	public HazmatGridTile GetTileFromPosition(Vector3 position)
	{
		return GetTileFromCoords(GetGridPositionFromWorldPosition(position));
	}

	public HazmatGridTile GetTileFromCoords(int x, int y, bool autoCreate = true)
	{
		if (x < 0 || y < 0)
		{
			return null;
		}
		int gridCoords = PackGridCoordsToInt(x, y);
		return GetTileFromCoords(gridCoords, autoCreate);
	}

	private HazmatGridTile GetTileFromCoords(int gridCoords, bool autoCreate = true)
	{
		if (TileDictionary.TryGetValue(gridCoords, out var value))
		{
			return value;
		}
		if (autoCreate)
		{
			int tileCoordX = GetTileCoordX(gridCoords);
			int tileCoordY = GetTileCoordY(gridCoords);
			Vector3 worldPositionFromGridCoords = GetWorldPositionFromGridCoords(tileCoordX, tileCoordY);
			Vector2Int vector2Int = new Vector2Int(Mathf.FloorToInt(worldPositionFromGridCoords.x / SingletonBehaviour<TerrainGrid>.Instance.TerrainSizeInWorld), Mathf.FloorToInt(worldPositionFromGridCoords.z / SingletonBehaviour<TerrainGrid>.Instance.TerrainSizeInWorld));
			(float flowHeight, float terrainHeight, Vector3 terrainNormal) terrainDataForTile = GetTerrainDataForTile(vector2Int, tileCoordX, tileCoordY);
			float item = terrainDataForTile.flowHeight;
			float item2 = terrainDataForTile.terrainHeight;
			Vector3 item3 = terrainDataForTile.terrainNormal;
			value = new HazmatGridTile(gridCoords, item, item2, item3, vector2Int);
			TileDictionary.Add(gridCoords, value);
			tileList.Add(new KeyValuePair<int, HazmatGridTile>(gridCoords, value));
			return value;
		}
		return null;
	}

	public Vector3 GetWorldPositionFromGridTileGizmo()
	{
		int gridPositionFromWorldPositionDebug = GetGridPositionFromWorldPositionDebug();
		return ((SingletonBehaviour<WorldMover>.Instance != null) ? WorldMover.currentMove : Vector3.zero) + new Vector3(4f, 200f, 4f) - new Vector3(0f - (float)GetTileCoordX(gridPositionFromWorldPositionDebug), 0f, 0f - (float)GetTileCoordY(gridPositionFromWorldPositionDebug)) * 8f;
	}

	public Vector3 GetWorldPositionFromGridTile(HazmatGridTile tile, bool usingWorldShift)
	{
		int tileCoordX = GetTileCoordX(tile.gridPosition);
		int tileCoordY = GetTileCoordY(tile.gridPosition);
		return GetWorldPositionFromGridCoords(tileCoordX, tileCoordY, usingWorldShift);
	}

	public Vector3 GetWorldPositionFromGridCoords(int x, int y, bool usingWorldShift = false)
	{
		return ((SingletonBehaviour<WorldMover>.Instance != null && usingWorldShift) ? WorldMover.currentMove : Vector3.zero) + tileSizeOffset - new Vector3(0f - (float)x, 0f, 0f - (float)y) * 8f;
	}

	public Vector3 GetWorldPositionFromGridTileWithHeight(HazmatGridTile tile, bool usingWorldShift = true)
	{
		Vector3 worldPositionFromGridTile = GetWorldPositionFromGridTile(tile, usingWorldShift);
		worldPositionFromGridTile.y = GetTerrainHeightDataAtPoint(tile.gridPosition).terrainHeight;
		return worldPositionFromGridTile;
	}

	public Vector3 GetWorldPositionFromGridTileWithHeight(int x, int y)
	{
		Vector3 worldPositionFromGridCoords = GetWorldPositionFromGridCoords(x, y);
		worldPositionFromGridCoords.y = GetTerrainHeightDataAtPoint(x, y).terrainHeight;
		return worldPositionFromGridCoords;
	}

	public void NormalizeSplatDataWithConstantMember(int x, int y, float liquidWeight, float wasteWeight, float[,,] splatPixelData, int constantTextureIndex, float[,,] overlayOutput, float[] outputBuffer)
	{
		float num = liquidWeight + wasteWeight;
		if (num > 0.4f)
		{
			float num2 = 0.4f / num;
			liquidWeight *= num2;
			wasteWeight *= num2;
			num = 0.4f;
		}
		if (splatPixelData != null)
		{
			float num3 = (1f - num) / (1f - splatPixelData[y, x, constantTextureIndex] - splatPixelData[y, x, 15]);
			for (int i = 0; i < splatPixelData.GetLength(2); i++)
			{
				if (i != constantTextureIndex && i != 15)
				{
					outputBuffer[i] = splatPixelData[y, x, i] * num3;
					overlayOutput[y, x, i] = 0f;
				}
				else if (i == 15)
				{
					overlayOutput[y, x, i] = (outputBuffer[i] = wasteWeight);
				}
				else
				{
					overlayOutput[y, x, i] = (outputBuffer[i] = liquidWeight);
				}
			}
			return;
		}
		for (int j = 0; j < overlayOutput.GetLength(2); j++)
		{
			if (j != constantTextureIndex && j != 15)
			{
				overlayOutput[y, x, j] = 0f;
			}
			else if (j == 15)
			{
				overlayOutput[y, x, j] = wasteWeight;
			}
			else
			{
				overlayOutput[y, x, j] = liquidWeight;
			}
		}
	}

	public void NormalizeSplatDataWithConstantMember(float[] splatPixelData, int constantTextureIndex, float[] overlayOutput, float[] outputBuffer)
	{
		float num = 0f;
		for (int i = 0; i < overlayOutput.Length; i++)
		{
			num += overlayOutput[i];
		}
		if (num > 0.4f)
		{
			float num2 = 0.4f / num;
			for (int j = 0; j < overlayOutput.Length; j++)
			{
				overlayOutput[j] *= num2;
			}
			num = 0.4f;
		}
		float num3 = (1f - num) / (1f - splatPixelData[constantTextureIndex] - splatPixelData[15]);
		for (int k = 0; k < splatPixelData.Length; k++)
		{
			if (k != constantTextureIndex && k != 15)
			{
				outputBuffer[k] = splatPixelData[k] * num3;
			}
			else
			{
				outputBuffer[k] = overlayOutput[k];
			}
		}
	}

	public static void NormalizeSplatDataWithConstantMember(float[,,] splatPixelData, float[,,] overlayInput, float[,,] blendedOutput)
	{
		int length = splatPixelData.GetLength(1);
		int length2 = splatPixelData.GetLength(0);
		int length3 = splatPixelData.GetLength(2);
		float[] array = new float[length3];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				float num = 0f;
				for (int k = 0; k < length3; k++)
				{
					array[k] = splatPixelData[j, i, k] + overlayInput[j, i, k];
					num += array[k];
				}
				if (num > 0.4f)
				{
					float num2 = 0.4f / num;
					for (int l = 0; l < length3; l++)
					{
						array[l] *= num2;
					}
					num = 0.4f;
				}
				float num3 = (1f - num) / (1f - array[14] - array[15]);
				for (int m = 0; m < length3; m++)
				{
					if (m != 14 && m != 15)
					{
						blendedOutput[j, i, m] = array[m] * num3;
					}
					else
					{
						blendedOutput[j, i, m] = array[m];
					}
				}
			}
		}
	}

	public int GetGridPositionFromWorldPosition(Vector3 pos, bool usingWorldShift = true, int offsetX = 0, int offsetY = 0)
	{
		Vector3 shiftedPosition = (pos - (((bool)SingletonBehaviour<WorldMover>.Instance && usingWorldShift) ? WorldMover.currentMove : Vector3.zero)) / 8f;
		return CalculateAndPackGridCoordsToInt(shiftedPosition, offsetX, offsetY);
	}

	private int CalculateAndPackGridCoordsToInt(Vector3 shiftedPosition, int offsetX = 0, int offsetY = 0)
	{
		int x = Mathf.FloorToInt(shiftedPosition.x) + offsetX;
		int y = Mathf.FloorToInt(shiftedPosition.z) + offsetY;
		return PackGridCoordsToInt(x, y);
	}

	public int PackGridCoordsToInt(int x, int y)
	{
		return (x << 16) | (ushort)y;
	}

	public int GetTileCoordX(int gridCoords)
	{
		return gridCoords >> 16;
	}

	public int GetTileCoordY(int gridCoords)
	{
		return gridCoords & 0xFFFF;
	}

	private void PrepareTerrainPaintData(int textureIndex, float weightToAdd, int gridCoords)
	{
		HazmatGridTile tileFromCoords = GetTileFromCoords(gridCoords);
		if (!tileFromCoords.fullyInitialized)
		{
			return;
		}
		int num = GetTileCoordX(gridCoords) % tilesPerTerrain;
		int num2 = GetTileCoordY(gridCoords) % tilesPerTerrain;
		TerrainChunkData terrainChunkData = terrainChunkDataCollection[tileFromCoords.terrainGridPosition.x, tileFromCoords.terrainGridPosition.y];
		float liquidWeight = Mathf.Clamp(weightToAdd / maxWeight * 0.4f, 0f, 0.4f);
		float wasteWeight = Mathf.Clamp(tileFromCoords.burnTime / 15f * 0.4f, 0f, 0.4f);
		NormalizeSplatDataWithConstantMember(num, num2, liquidWeight, wasteWeight, terrainChunkData.sourceSplatData, textureIndex, terrainChunkData.overlaySplatData, blendBuffer);
		terrainChunkData.hasModifiedData = true;
		if (terrainChunkData.sourceSplatData != null)
		{
			for (int i = 0; i < blendBuffer.Length; i++)
			{
				terrainChunkData.blendedSplatData[num2, num, i] = blendBuffer[i];
			}
			if (!terrainChunkData.flaggedForSplatUpdate)
			{
				terrainChunkData.flaggedForSplatUpdate = true;
				terrainsPendingPainting.Enqueue(terrainChunkData);
			}
		}
	}

	private void ApplyTerrainSplats()
	{
		while (terrainsPendingPainting.Count > 0)
		{
			TerrainChunkData terrainChunkData = terrainsPendingPainting.Dequeue();
			if (!terrainChunkData.IsLoaded)
			{
				terrainChunkData.shouldUpdateSplatsOnReload = true;
			}
			else
			{
				terrainChunkData.terrainData.SetAlphamaps(0, 0, terrainChunkData.blendedSplatData);
			}
			terrainChunkData.flaggedForSplatUpdate = false;
		}
	}

	private void Update()
	{
		UpdateTileLiquidContentExternal();
		if (TileDictionary.Count > 0 && TimeUtil.IsFlowing)
		{
			if (showState)
			{
				UnityEngine.Debug.Log($"Current tile manager state is: {state}");
			}
			reactionTimer += Time.deltaTime;
			switch (state)
			{
			case CellularAutomataState.EvolveFlow:
				EvolveLiquidCellularAutomaton();
				state = CellularAutomataState.PrepareTerrainSplatData;
				break;
			case CellularAutomataState.PrepareTerrainSplatData:
				PrepareAllTerrainSplats();
				state = CellularAutomataState.ApplyTerrainSplatData;
				break;
			case CellularAutomataState.ApplyTerrainSplatData:
				ApplyTerrainSplats();
				state = CellularAutomataState.EvolveReaction;
				break;
			case CellularAutomataState.EvolveReaction:
				PrepareReaction();
				state = CellularAutomataState.ProcessReaction;
				break;
			case CellularAutomataState.ProcessReaction:
				ProcessReaction();
				state = CellularAutomataState.CleanUp;
				break;
			case CellularAutomataState.CleanUp:
				CleanUp();
				state = CellularAutomataState.EvolveFlow;
				break;
			case CellularAutomataState.ProcessFlow:
			case CellularAutomataState.EvolveIgnition:
			case CellularAutomataState.ProcessIgnition:
				break;
			}
		}
	}

	private void PrepareReaction()
	{
		for (int num = gasLeakSources.Count - 1; num >= 0; num--)
		{
			if (gasLeakSources[num] == null)
			{
				gasLeakSources.RemoveAt(num);
			}
			else
			{
				ApplyGasReactionModifier(gasLeakSources[num].Position(), gasLeakSources[num].VaporRadius(), gasLeakSources[num].GetCargoType());
			}
		}
		for (int num2 = explosionEpicenters.Count - 1; num2 >= 0; num2--)
		{
			if (explosionEpicenters[num2] != null)
			{
				ApplyExplosionModifier(explosionEpicenters[num2].position);
			}
			explosionEpicenters.RemoveAt(num2);
		}
		foreach (KeyValuePair<int, HazmatGridTile> tile in tileList)
		{
			HazmatGridTile value = tile.Value;
			if (value.IsIgnited && value.reactionModifier > 0f)
			{
				continue;
			}
			HazmatGridTile[] array = GetExistingNeighbours(tile.Value);
			foreach (HazmatGridTile hazmatGridTile in array)
			{
				if (hazmatGridTile != null && hazmatGridTile.IsIgnited)
				{
					value.reactionModifier += 0.1f;
				}
			}
			value.ReCalculateReactionValues();
		}
	}

	private void ProcessReaction()
	{
		bool flag = false;
		foreach (KeyValuePair<int, HazmatGridTile> tile in tileList)
		{
			HazmatGridTile value = tile.Value;
			bool isIgnited = value.IsIgnited;
			bool isCorroded = value.IsCorroded;
			bool isDefiled = value.IsDefiled;
			_ = value.IsRadiated;
			value.ProcessReaction(reactionTimer, (SingletonBehaviour<WeatherDriver>.Instance != null) ? ((float)SingletonBehaviour<WeatherDriver>.Instance.WetnessValue) : 0f);
			value.ProcessRadiation(reactionTimer);
			bool isIgnited2 = value.IsIgnited;
			bool flag2 = value.ContainsCorosive();
			bool flag3 = value.ContainsBioHazard();
			bool flag4 = value.ContainsRadiation();
			flag = flag || flag4;
			if (!isIgnited && isIgnited2)
			{
				BurnTerrainTile(value);
			}
			else if (isIgnited && !isIgnited2)
			{
				if (value.terrainFireEffects != null)
				{
					value.terrainFireEffects.RemoveEffects();
				}
				if (IgnitedTileCoords.Contains(value.gridPosition))
				{
					IgnitedTileCoords.Remove(value.gridPosition);
				}
				else
				{
					UnityEngine.Debug.LogError(string.Format("Tile {0} was burning but wasn't in {1} set. This should not happen.", value.gridPosition, "IgnitedTileCoords"));
				}
			}
			if (!isCorroded && flag2)
			{
				CorrodeTerrainTile(value);
			}
			else if (isCorroded && !flag2 && value.terrainCorrosiveEffects != null)
			{
				value.terrainCorrosiveEffects.RemoveEffects();
			}
			if (!isDefiled && flag3)
			{
				DefileTile(value);
			}
			else if (isDefiled && !flag3 && value.terrainBiohazardEffects != null)
			{
				value.terrainBiohazardEffects.RemoveEffects();
			}
		}
		if (flag)
		{
			hazmatRadioactiveEffect.UpdateRadiationEffect();
		}
		else
		{
			hazmatRadioactiveEffect.DisableRadiationEffect();
		}
		reactionTimer = 0f;
		if (tileList.Count > 0)
		{
			if (ignitionRobin >= tileList.Count)
			{
				ignitionRobin = 0;
			}
			tileList[ignitionRobin].Value.ProcessIgnition();
			ignitionRobin = (ignitionRobin + 1) % tileList.Count;
		}
	}

	public void UpdateTileLiquidToBeAddedDictionary(Vector3 pos, float amount, CargoType liquid)
	{
		int gridPositionFromWorldPosition = GetGridPositionFromWorldPosition(pos);
		if (tileLiquidAmountToBeAddedDictionary.ContainsKey(gridPositionFromWorldPosition))
		{
			tileLiquidAmountToBeAddedDictionary[gridPositionFromWorldPosition] += amount;
		}
		else
		{
			tileLiquidAmountToBeAddedDictionary[gridPositionFromWorldPosition] = amount;
		}
		tileLiquidTypeToBeAddedDictionary[gridPositionFromWorldPosition] = liquid;
	}

	public bool IsTileIgnited(Vector3 worldPos)
	{
		TileDictionary.TryGetValue(GetGridPositionFromWorldPosition(worldPos), out var value);
		return value?.IsIgnited ?? false;
	}

	private void UpdateTileLiquidContentExternal()
	{
		foreach (KeyValuePair<int, float> item in tileLiquidAmountToBeAddedDictionary)
		{
			HazmatGridTile tileFromCoords = GetTileFromCoords(item.Key);
			CargoType cargoType = tileLiquidTypeToBeAddedDictionary[item.Key];
			tileFromCoords.AddLiquidAmount(cargoType, item.Value);
			tileFromCoords.UpdateCurrentWeight();
		}
		if (tileLiquidAmountToBeAddedDictionary.Count > 0)
		{
			tileLiquidAmountToBeAddedDictionary.Clear();
			tileLiquidTypeToBeAddedDictionary.Clear();
		}
	}

	private void EvolveLiquidCellularAutomaton()
	{
		for (int i = 0; i < tileList.Count; i++)
		{
			HazmatGridTile value = tileList[i].Value;
			float currentWeight = value.currentWeight;
			if (currentWeight > maxWeight)
			{
				HazmatGridTile[] orCreateNeighbours = GetOrCreateNeighbours(value);
				FlowLiquidToNeighbours(value, currentWeight - maxWeight, orCreateNeighbours);
			}
		}
	}

	private void FlowLiquidToNeighbours(HazmatGridTile currentTile, float overflow, HazmatGridTile[] neighbours)
	{
		float num = float.PositiveInfinity;
		HazmatGridTile hazmatGridTile = null;
		int num2 = 4;
		HazmatGridTile[] array = neighbours;
		foreach (HazmatGridTile hazmatGridTile2 in array)
		{
			if (hazmatGridTile2 == null || currentTile.neighbouringLiquidSources.Contains(hazmatGridTile2) || currentTile.flowHeight - hazmatGridTile2.flowHeight < -0.2f)
			{
				num2--;
			}
			else if (num > hazmatGridTile2.flowHeight)
			{
				num = hazmatGridTile2.flowHeight;
				hazmatGridTile = hazmatGridTile2;
			}
		}
		CargoType[] array2 = new CargoType[currentTile.liquidContent.Keys.Count];
		currentTile.liquidContent.Keys.CopyTo(array2, 0);
		if (hazmatGridTile != null && currentTile.flowHeight - num > 0.2f)
		{
			CargoType[] array3 = array2;
			foreach (CargoType cargoType in array3)
			{
				float num3 = currentTile.liquidContent[cargoType];
				float num4 = overflow * num3 / currentTile.currentWeight;
				hazmatGridTile.AddLiquidAmount(cargoType, num4);
				currentTile.liquidContent[cargoType] -= num4;
			}
			currentTile.UpdateCurrentWeight();
			hazmatGridTile.UpdateCurrentWeight();
		}
		else
		{
			if (num2 <= 0)
			{
				return;
			}
			float num5 = 1f / (float)num2;
			float num6 = overflow * num5;
			array = neighbours;
			foreach (HazmatGridTile hazmatGridTile3 in array)
			{
				if (hazmatGridTile3 == null || currentTile.neighbouringLiquidSources.Contains(hazmatGridTile3) || currentTile.flowHeight - hazmatGridTile3.flowHeight < -0.2f)
				{
					continue;
				}
				if (currentTile.liquidContent.Count > 0)
				{
					CargoType[] array3 = array2;
					foreach (CargoType cargoType2 in array3)
					{
						float num7 = currentTile.liquidContent[cargoType2];
						float num8 = num6 * num7 / currentTile.currentWeight;
						hazmatGridTile3.AddLiquidAmount(cargoType2, num8);
						currentTile.liquidContent[cargoType2] -= num8;
					}
				}
				hazmatGridTile3.UpdateCurrentWeight();
			}
			currentTile.UpdateCurrentWeight();
		}
	}

	private void PrepareAllTerrainSplats()
	{
		foreach (KeyValuePair<int, HazmatGridTile> tile in tileList)
		{
			if (Mathf.Abs(tile.Value.currentWeight - tile.Value.previousWeight) > float.Epsilon)
			{
				PrepareTerrainPaintData(14, tile.Value.currentWeight, tile.Value.gridPosition);
				tile.Value.previousWeight = tile.Value.currentWeight;
			}
		}
	}

	private HazmatGridTile[] GetOrCreateNeighbours(HazmatGridTile tile)
	{
		int tileCoordX = GetTileCoordX(tile.gridPosition);
		int tileCoordY = GetTileCoordY(tile.gridPosition);
		int num = 0;
		int num2 = 2;
		for (int i = -1; i < 2; i += 2)
		{
			int num3 = tileCoordX + i;
			if (num3 < 0 || num3 > maxTileIndex)
			{
				liquidNeighbours[num] = null;
				num++;
			}
			else
			{
				liquidNeighbours[(i >= 0) ? 1 : 0] = GetTileFromCoords(num3, tileCoordY);
			}
			int num4 = tileCoordY + i;
			if (num4 < 0 || num4 > maxTileIndex)
			{
				liquidNeighbours[num2] = null;
				num2++;
			}
			else
			{
				liquidNeighbours[(i < 0) ? 2 : 3] = GetTileFromCoords(tileCoordX, num4);
			}
		}
		return liquidNeighbours;
	}

	private HazmatGridTile[] GetExistingNeighbours(HazmatGridTile tile)
	{
		int tileCoordX = GetTileCoordX(tile.gridPosition);
		int tileCoordY = GetTileCoordY(tile.gridPosition);
		for (int i = -1; i < 2; i += 2)
		{
			HazmatGridTile value = null;
			int num = tileCoordX + i;
			if (num < 0)
			{
				existingNeighbours[existingNeighbours.Length - 1] = null;
			}
			else
			{
				int key = PackGridCoordsToInt(num, tileCoordY);
				TileDictionary.TryGetValue(key, out value);
				if (value != null)
				{
					existingNeighbours[(i >= 0) ? 1 : 0] = value;
				}
			}
			int num2 = tileCoordY + i;
			if (num2 < 0)
			{
				existingNeighbours[existingNeighbours.Length - 2] = null;
				continue;
			}
			int key2 = PackGridCoordsToInt(tileCoordX, num2);
			TileDictionary.TryGetValue(key2, out value);
			if (value != null)
			{
				existingNeighbours[(i < 0) ? 2 : 3] = value;
			}
		}
		return existingNeighbours;
	}

	private bool IgniteTerrainTile(HazmatGridTile tile, float ignitionStrength)
	{
		if (tile == null || tile.IsIgnited || tile.currentWeight <= float.Epsilon)
		{
			return false;
		}
		return tile.Ignite(ignitionStrength);
	}

	private void BurnTerrainTile(HazmatGridTile tile)
	{
		if (tile.terrainFireEffects == null || !tile.terrainFireEffects.RestartEffects())
		{
			HazmatTerrainEffectsController prefab = fireEffectsControllerPrefabs[UnityEngine.Random.Range(0, fireEffectsControllerPrefabs.Length)];
			tile.terrainFireEffects = InstaniateTerrainEffects(tile, prefab, "TerrainFireParticle_{0}_{1}");
		}
		IgnitedTileCoords.Add(tile.gridPosition);
	}

	private void CorrodeTerrainTile(HazmatGridTile tile)
	{
		if (tile != null && tile.ContainsCorosive() && (tile.terrainCorrosiveEffects == null || !tile.terrainCorrosiveEffects.RestartEffects()))
		{
			tile.terrainCorrosiveEffects = InstaniateTerrainEffects(tile, corrosiveEffectsControllerPrefab, "TerrainCorosiveParticle_{0}_{1}");
		}
	}

	private void DefileTile(HazmatGridTile tile)
	{
		if (tile != null && tile.ContainsBioHazard() && (tile.terrainBiohazardEffects == null || !tile.terrainBiohazardEffects.RestartEffects()))
		{
			tile.terrainBiohazardEffects = InstaniateTerrainEffects(tile, biohazardEffectsControllerPrefab, "TerrainBiohazardParticle_{0}_{1}");
		}
	}

	private HazmatTerrainEffectsController InstaniateTerrainEffects(HazmatGridTile tile, HazmatTerrainEffectsController prefab, string namePrefix)
	{
		if (prefab == null)
		{
			return null;
		}
		if (tile == null)
		{
			UnityEngine.Debug.LogError("Cannot instantiate terrain effect without a valid HazmatGridTile reference.", this);
			return null;
		}
		var (position, rotation) = GetTerrainEffectTransformValues(tile);
		UnityEngine.Random.Range(0f, 360f);
		HazmatTerrainEffectsController hazmatTerrainEffectsController = UnityEngine.Object.Instantiate(prefab, position, rotation);
		hazmatTerrainEffectsController.transform.SetParent(WorldMover.OriginShiftParent);
		hazmatTerrainEffectsController.name = string.Format(namePrefix, GetTileCoordX(tile.gridPosition), GetTileCoordY(tile.gridPosition));
		return hazmatTerrainEffectsController;
	}

	private (Vector3 effectPostion, Quaternion effectRotation) GetTerrainEffectTransformValues(HazmatGridTile tile)
	{
		Vector3 worldPositionFromGridTile = GetWorldPositionFromGridTile(tile, usingWorldShift: true);
		worldPositionFromGridTile.y = HeightMapProvider.GetInterpolated(worldPositionFromGridTile);
		Vector3 normalInterpolated = HeightMapProvider.GetNormalInterpolated(worldPositionFromGridTile);
		return new ValueTuple<Vector3, Quaternion>(item2: (!(Math.Abs(Vector3.Dot(Vector3.up, normalInterpolated)) > 0.99f)) ? Quaternion.LookRotation(Vector3.Cross(Vector3.Cross(normalInterpolated, Vector3.up), normalInterpolated), normalInterpolated) : Quaternion.identity, item1: worldPositionFromGridTile);
	}

	private (float terrainHeight, float flowHeight) GetTerrainHeightDataAtPoint(int tileX, int tileY, TerrainData terrainData)
	{
		float num = 2f;
		var (sx, sy) = InterpolateToHeightCoords(tileX, tileY, 0.5f, 0.5f);
		SampleHeight(sx, sy);
		float interpolated = HeightMapProvider.GetInterpolated(GetWorldPosition(tileX, tileY), usingWorldShift: false);
		float num2 = 0f;
		for (int i = 0; (float)i < num; i++)
		{
			for (int j = 0; (float)j < num; j++)
			{
				(float xf, float yf) tuple2 = InterpolateToHeightCoords(tileX, tileY, (float)i / num, (float)j / num);
				sx = tuple2.xf;
				sy = tuple2.yf;
				num2 += SampleHeight(sx, sy);
			}
		}
		num2 += SampleHeight(sx, sy);
		float num3 = num * num;
		num2 /= num3 + 1f;
		return (terrainHeight: interpolated, flowHeight: num2);
		(float xf, float yf) InterpolateToHeightCoords(int tilePosX, int tilePosY, float offsetX, float offsetY)
		{
			return (xf: (float)tilePosX + offsetX, yf: (float)tilePosY + offsetY);
		}
		float SampleHeight(float num4, float num5)
		{
			return HeightMapProvider.GetInterpolated(new Vector3(num4 * 8f, 0f, num5 * 8f), usingWorldShift: false);
		}
	}

	public (float terrainHeight, float flowHeight) GetTerrainHeightDataAtPoint(int gridCoords)
	{
		int tileCoordX = GetTileCoordX(gridCoords);
		int tileCoordY = GetTileCoordY(gridCoords);
		return GetTerrainHeightDataAtPoint(tileCoordX, tileCoordY);
	}

	public (float terrainHeight, float flowHeight) GetTerrainHeightDataAtPoint(int x, int y)
	{
		float waterLevel;
		if (x < 0 || x > maxTileIndex || y < 0 || y > maxTileIndex)
		{
			return (terrainHeight: waterLevel = SingletonBehaviour<LevelInfo>.Instance.waterLevel, flowHeight: waterLevel);
		}
		Vector3 worldPositionFromGridCoords = GetWorldPositionFromGridCoords(x, y);
		worldPositionFromGridCoords.x += 4f;
		worldPositionFromGridCoords.z += 4f;
		float pointSample = HeightMapProvider.GetPointSample(worldPositionFromGridCoords, usingWorldShift: false);
		return (terrainHeight: pointSample, flowHeight: pointSample);
	}

	private Vector3 GetWorldPosition(int tileX, int tileY, bool usingWorldShift = false, float offsetX = 0f, float offsetY = 0f)
	{
		Vector3 vector = new Vector3(((float)tileX + offsetX) * 8f, 0f, ((float)tileY + offsetY) * 8f);
		if (usingWorldShift)
		{
			return vector - WorldMover.currentMove;
		}
		return vector;
	}

	private void CleanUp()
	{
		for (int num = tileList.Count - 1; num >= 0; num--)
		{
			HazmatGridTile value = tileList[num].Value;
			if (value.liquidContent.Count > 0)
			{
				return;
			}
			HazmatGridTile[] array = GetExistingNeighbours(value);
			if (array != null && array.Any((HazmatGridTile t) => t != null && t.liquidContent.Count > 0))
			{
				return;
			}
			bool flag = false;
			HazmatGridTile[] array2 = array;
			foreach (HazmatGridTile hazmatGridTile in array2)
			{
				if (hazmatGridTile != null && value.neighbouringLiquidSources.Contains(value))
				{
					hazmatGridTile.neighbouringLiquidSources.Remove(value);
				}
				if (value.terrainFireEffects != null)
				{
					value.terrainFireEffects.RemoveEffects();
				}
				else if (value.terrainCorrosiveEffects != null)
				{
					value.terrainCorrosiveEffects.RemoveEffects();
				}
				else if (value.terrainBiohazardEffects != null)
				{
					value.terrainBiohazardEffects.RemoveEffects();
				}
				else if (!value.ContainsRadiation())
				{
					flag = true;
				}
			}
			if (flag)
			{
				TileDictionary.Remove(tileList[num].Key);
				tileList.RemoveAt(num);
			}
		}
		gasLeakSources.Clear();
	}

	private void RemoveTilesDebug()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		IgnitedTileCoords.Clear();
		foreach (KeyValuePair<int, HazmatGridTile> tile in tileList)
		{
			HazmatGridTile value = tile.Value;
			int tileCoordX = GetTileCoordX(value.gridPosition);
			int tileCoordY = GetTileCoordY(value.gridPosition);
			GetTerrainDataFromTileCoords(tileCoordX, tileCoordY);
			NeutralizeCorrosion(value);
		}
		foreach (KeyValuePair<int, HazmatGridTile> tile2 in tileList)
		{
			if (tile2.Value.terrainFireEffects != null)
			{
				UnityEngine.Object.Destroy(tile2.Value.terrainFireEffects.gameObject);
			}
			if (tile2.Value.terrainCorrosiveEffects != null)
			{
				UnityEngine.Object.Destroy(tile2.Value.terrainCorrosiveEffects.gameObject);
			}
			if (tile2.Value.terrainBiohazardEffects != null)
			{
				UnityEngine.Object.Destroy(tile2.Value.terrainBiohazardEffects.gameObject);
			}
		}
		TileDictionary.Clear();
		tileList.Clear();
		terrainsPendingPainting.Clear();
	}

	public int GetGridPositionFromWorldPositionDebug()
	{
		Vector3 shiftedPosition = (worldPosition - ((SingletonBehaviour<WorldMover>.Instance != null) ? WorldMover.currentMove : Vector3.zero)) / 8f;
		return CalculateAndPackGridCoordsToInt(shiftedPosition);
	}

	private void AddLiquidToTile()
	{
		if (!Application.isPlaying)
		{
			UnityEngine.Debug.LogError("Can only add liquid in play mode.");
			return;
		}
		int gridPositionFromWorldPositionDebug = GetGridPositionFromWorldPositionDebug();
		HazmatGridTile tileFromCoords = GetTileFromCoords(gridPositionFromWorldPositionDebug);
		tileFromCoords.AddLiquidAmount(liquidTypeToAdd, textureWeightToAdd);
		tileFromCoords.UpdateCurrentWeight();
		UnityEngine.Debug.Log($"Total weight on tile {gridPositionFromWorldPositionDebug}; {GetTileCoordX(gridPositionFromWorldPositionDebug)}, {GetTileCoordY(gridPositionFromWorldPositionDebug)} is: {tileFromCoords.currentWeight}");
	}

	public void GetAllWeights()
	{
		float num = 0f;
		foreach (KeyValuePair<int, HazmatGridTile> tile in tileList)
		{
			num += tile.Value.currentWeight;
		}
		UnityEngine.Debug.Log($"Total weight is: {num}");
	}

	private void IgniteTileDebug()
	{
		int gridPositionFromWorldPositionDebug = GetGridPositionFromWorldPositionDebug();
		TileDictionary.TryGetValue(gridPositionFromWorldPositionDebug, out var value);
		IgniteTerrainTile(value, 100000f);
	}

	private void CenterOnPlayer()
	{
		if (Application.isPlaying)
		{
			worldPosition = Camera.main.transform.position;
		}
	}

	public bool IgniteTile(int gridCoords, float ignitionStrength)
	{
		if (TileDictionary.TryGetValue(gridCoords, out var value))
		{
			return IgniteTerrainTile(value, ignitionStrength);
		}
		return false;
	}

	public bool IgniteTile(HazmatGridTile tile, float ignitionStrength)
	{
		return IgniteTerrainTile(tile, ignitionStrength);
	}

	private void NeutralizeCorrosion(HazmatGridTile tile)
	{
		if (tile.ContainsCorosive() && tile.terrainCorrosiveEffects != null)
		{
			tile.terrainCorrosiveEffects.RemoveEffects();
		}
	}

	private void GetTerrain()
	{
		int gridPositionFromWorldPositionDebug = GetGridPositionFromWorldPositionDebug();
		TerrainData terrainDataFromTileCoords = GetTerrainDataFromTileCoords(gridPositionFromWorldPositionDebug);
		Vector2Int vector2Int = SingletonBehaviour<TerrainGrid>.Instance.ToGridCoords(worldPosition);
		if (terrainDataFromTileCoords == null)
		{
			UnityEngine.Debug.LogError($"No terrain data found from given position '{worldPosition}'; terrain grid position: '{vector2Int}'.");
		}
		else
		{
			UnityEngine.Debug.LogError($"Terrain loaded at world position '{worldPosition}' with grid position '{vector2Int}'.");
		}
	}

	private void GetHeight()
	{
		int gridPositionFromWorldPositionDebug = GetGridPositionFromWorldPositionDebug();
		int tileCoordX = GetTileCoordX(gridPositionFromWorldPositionDebug);
		int tileCoordY = GetTileCoordY(gridPositionFromWorldPositionDebug);
		tileCoordX %= tilesPerTerrain;
		tileCoordY %= tilesPerTerrain;
		Vector2Int vector2Int = SingletonBehaviour<TerrainGrid>.Instance.ToGridCoords(worldPosition);
		TerrainData terrainData = terrainChunkDataCollection[vector2Int.x, vector2Int.y].terrainData;
		float num = 2f;
		float heightRes = heightToSplatRatio / heightMapResolution;
		float num2 = 0f;
		int num3 = 0;
		float item;
		float item2;
		for (int i = 0; (float)i < num; i++)
		{
			for (int j = 0; (float)j < num; j++)
			{
				(float xf, float yf) tuple = InterpolateToHeightCoords(tileCoordX, tileCoordY, (float)i / num, (float)j / num);
				item = tuple.xf;
				item2 = tuple.yf;
				num2 += terrainData.GetInterpolatedHeight(item, item2);
				num3++;
			}
		}
		(float xf, float yf) tuple2 = InterpolateToHeightCoords(tileCoordX, tileCoordY, 0.5f, 0.5f);
		item = tuple2.xf;
		item2 = tuple2.yf;
		float interpolatedHeight = terrainData.GetInterpolatedHeight(item, item2);
		num2 += terrainData.GetInterpolatedHeight(item, item2);
		float num4 = num * num;
		num2 /= num4 + 1f;
		num3++;
		UnityEngine.Debug.LogError($"Expected height should be around {Camera.main.transform.position.y}");
		UnityEngine.Debug.LogError($"Height for ({tileCoordX}, {tileCoordY}) after {num4 + 1f}, check {num3}, samples is {num2}, center is {interpolatedHeight}");
		float interpolated = HeightMapProvider.GetInterpolated(worldPosition, usingWorldShift: false);
		UnityEngine.Debug.LogError($"Sampled height = {interpolated}");
		(float xf, float yf) InterpolateToHeightCoords(int xx, int yy, float offsetX, float offsetY)
		{
			return (xf: ((float)xx + offsetX) * heightRes, yf: ((float)yy + offsetY) * heightRes);
		}
	}

	[Conditional("HAZMAT_DEBUG")]
	internal static void DebugLog(string msg)
	{
		UnityEngine.Debug.Log(msg);
	}
}
