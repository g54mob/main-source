using System.IO;
using Pug.RP;
using Pug.UnityExtensions;
using PugTilemap;
using QFSW.QC;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class MapUpdateSystem : PugSimulationSystemBase
{
	private struct LightPixel
	{
		public half r;

		public half g;

		public half b;

		public half a;

		public static implicit operator Color(LightPixel p)
		{
			return new Color(p.r, p.g, p.b, p.a);
		}

		public static implicit operator LightPixel(Color c)
		{
			return new LightPixel
			{
				r = (half)c.r,
				b = (half)c.b,
				g = (half)c.g,
				a = (half)c.a
			};
		}

		public static implicit operator Color32(LightPixel p)
		{
			return new Color32((byte)math.round((float)p.r * 255f), (byte)math.round((float)p.g * 255f), (byte)math.round((float)p.b * 255f), (byte)math.round((float)p.a * 255f));
		}

		public static implicit operator LightPixel(Color32 c)
		{
			return new LightPixel
			{
				r = (half)((float)(int)c.r / 255f),
				b = (half)((float)(int)c.b / 255f),
				g = (half)((float)(int)c.g / 255f),
				a = (half)((float)(int)c.a / 255f)
			};
		}

		public static implicit operator PugColorARGB32(LightPixel p)
		{
			return new PugColorARGB32((byte)math.round((float)p.r * 255f), (byte)math.round((float)p.g * 255f), (byte)math.round((float)p.b * 255f), (byte)math.round((float)p.a * 255f));
		}

		public static implicit operator LightPixel(PugColorARGB32 c)
		{
			return new LightPixel
			{
				r = (half)((float)(int)c.r / 255f),
				b = (half)((float)(int)c.b / 255f),
				g = (half)((float)(int)c.g / 255f),
				a = (half)((float)(int)c.a / 255f)
			};
		}
	}

	private struct LightPixelHiP
	{
		public float r;

		public float g;

		public float b;

		public float a;

		public static implicit operator Color(LightPixelHiP p)
		{
			return new Color(p.r, p.g, p.b, p.a);
		}

		public static implicit operator LightPixelHiP(Color c)
		{
			return new LightPixelHiP
			{
				r = c.r,
				b = c.b,
				g = c.g,
				a = c.a
			};
		}

		public static implicit operator Color32(LightPixelHiP p)
		{
			return new Color32((byte)math.round(p.r * 255f), (byte)math.round(p.g * 255f), (byte)math.round(p.b * 255f), (byte)math.round(p.a * 255f));
		}

		public static implicit operator LightPixelHiP(Color32 c)
		{
			return new LightPixelHiP
			{
				r = (float)(int)c.r / 255f,
				b = (float)(int)c.b / 255f,
				g = (float)(int)c.g / 255f,
				a = (float)(int)c.a / 255f
			};
		}

		public static implicit operator PugColorARGB32(LightPixelHiP p)
		{
			return new PugColorARGB32((byte)math.round(p.r * 255f), (byte)math.round(p.g * 255f), (byte)math.round(p.b * 255f), (byte)math.round(p.a * 255f));
		}

		public static implicit operator LightPixelHiP(PugColorARGB32 c)
		{
			return new LightPixelHiP
			{
				r = (float)(int)c.r / 255f,
				b = (float)(int)c.b / 255f,
				g = (float)(int)c.g / 255f,
				a = (float)(int)c.a / 255f
			};
		}
	}

	private struct ColorOverride
	{
		public int2 Position;

		public Color Color;
	}

	[BurstCompile]
	private struct ExtractNearbyWallAndLightJob : IJob
	{
		public int UpdateSquareSize;

		public int2 SquareBottomLeftLocalPos;

		public float RevealDistanceWithPaddingSq;

		public float RevealThreshold;

		public int2 PlayerPos;

		public float2 LightBufferOrigin;

		public float2 LightBufferWindowSize;

		public int2 LightBufferResolution;

		public bool HighPrecisionLight;

		[ReadOnly]
		public NativeArray<LightPixel> LightTexPixels;

		[ReadOnly]
		public NativeArray<LightPixelHiP> LightTexPixelsHiP;

		[ReadOnly]
		public TileAccessor TileAccessor;

		public NativeArray<bool> HashWall;

		public NativeArray<bool> HasLight;

		public void Execute()
		{
			for (int i = 0; i < UpdateSquareSize; i++)
			{
				for (int j = 0; j < UpdateSquareSize; j++)
				{
					int2 int5 = new int2(j, i);
					int2 int6 = SquareBottomLeftLocalPos + int5;
					if (!(math.lengthsq(int6) > RevealDistanceWithPaddingSq))
					{
						int index = int5.y * UpdateSquareSize + int5.x;
						int2 int7 = PlayerPos + int6;
						HashWall[index] = TileAccessor.HasType(int7, TileType.wall);
						float2 float5 = LightBufferOrigin - LightBufferWindowSize / 2f;
						int2 int8 = (int2)math.floor((int7 - float5) / LightBufferWindowSize * LightBufferResolution);
						int8 -= 4;
						bool flag = math.all(int8 >= 0) && math.all(int8 < LightBufferResolution);
						HasLight[index] = flag && RGB2Luminance(int8.y * LightBufferResolution.x + int8.x) >= RevealThreshold;
					}
				}
			}
		}

		private float RGB2Luminance(int pixel)
		{
			if (HighPrecisionLight)
			{
				LightPixelHiP lightPixelHiP = LightTexPixelsHiP[pixel];
				return 0.2126f * lightPixelHiP.r + 0.7152f * lightPixelHiP.g + 0.0722f * lightPixelHiP.b;
			}
			LightPixel lightPixel = LightTexPixels[pixel];
			return 0.2126f * (float)lightPixel.r + 0.7152f * (float)lightPixel.g + 0.0722f * (float)lightPixel.b;
		}
	}

	[BurstCompile]
	private struct UpdateMapPartJob : IJob
	{
		public int UpdateSquareSize;

		public int2 SquareBottomLeftLocalPos;

		public float RevealDistanceSq;

		public int2 PlayerPos;

		public PugColorARGB32 TimestampColor;

		public bool OnlyRevealLitTiles;

		public int2 CurrentMapKeyPos;

		[ReadOnly]
		public NativeArray<bool> HasWall;

		[ReadOnly]
		public NativeArray<bool> HasLight;

		[ReadOnly]
		public NativeArray<int2> AdjDirs;

		[ReadOnly]
		public TileAccessor TileLookup;

		[ReadOnly]
		public NativeParallelHashSet<TileCD> DrawableTiles;

		[ReadOnly]
		public NativeList<ColorOverride> ColorOverridesThisUpdate;

		[ReadOnly]
		public TileTypeColorLookupSystem.LookupHelper TileTypeColorLookup;

		public NativeArray<PugColorARGB32> TextureData;

		public NativeArray<PugColorARGB32> TimestampData;

		public NativeParallelHashSet<int2> UpdatedMapKeys;

		private bool _somethingChanged;

		public void Execute()
		{
			_somethingChanged = false;
			for (int i = 0; i < UpdateSquareSize; i++)
			{
				for (int j = 0; j < UpdateSquareSize; j++)
				{
					int2 int5 = new int2(j, i);
					int2 int6 = SquareBottomLeftLocalPos + int5;
					int2 int7 = PlayerPos + int6;
					if (InThisMapPart(int7) && !(math.lengthsq(int6) > RevealDistanceSq) && (!OnlyRevealLitTiles || IsLit(int5)))
					{
						TileCD topFromSelection = TileLookup.GetTopFromSelection(int7, DrawableTiles);
						Color32 colorByTileType = TileTypeColorLookup.GetColorByTileType(topFromSelection.tileset, topFromSelection.tileType);
						SetColorAtPosInternal(int7, colorByTileType);
					}
				}
			}
			foreach (ColorOverride item in ColorOverridesThisUpdate)
			{
				if (InThisMapPart(item.Position) && !(math.distancesq(item.Position, PlayerPos) > RevealDistanceSq))
				{
					Color color = item.Color;
					SetColorAtPosInternal(item.Position, color);
				}
			}
			if (_somethingChanged)
			{
				UpdatedMapKeys.Add(CurrentMapKeyPos);
			}
		}

		private bool InThisMapPart(int2 worldPos)
		{
			return math.all(MapUI.WorldPositionToMapPartIndex(worldPos).ToInt2() == CurrentMapKeyPos);
		}

		private void SetColorAtPosInternal(int2 worldPos, Color c)
		{
			int2 int5 = MapUI.WorldPositionToMapPartPosition(worldPos);
			int index = int5.y * 256 + int5.x;
			int index2 = int5.y / 1 * 256 + int5.x / 1;
			if (c != TextureData[index])
			{
				TextureData[index] = c;
				TimestampData[index2] = TimestampColor;
				_somethingChanged = true;
			}
		}

		private bool IsLit(int2 localPos)
		{
			int index = localPos.y * UpdateSquareSize + localPos.x;
			if (!HasWall[index])
			{
				return HasLight[index];
			}
			foreach (int2 adjDir in AdjDirs)
			{
				int2 int5 = localPos + adjDir;
				if (!math.any(int5 < 0) && !math.any(int5 >= UpdateSquareSize))
				{
					int index2 = int5.y * UpdateSquareSize + int5.x;
					if (!HasWall[index2] && HasLight[index2])
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	private const float DISTANCE_TO_UPDATE_MAP = 7f;

	private const float LARGER_DISTANCE_TO_UPDATE_MAP = 12f;

	private const float REVEAL_THRESHOLD = 0.0015f;

	private bool _asyncGpuReadbackSupported;

	private AsyncGPUReadbackRequest _lightReadbackRequest;

	private GraphicsFormat _lightTextureFormat;

	private float2 _lightTextureWindowSize;

	private float2 _lightTextureOrigin;

	private int2 _lightBufferResolution;

	private bool _usingHighLightPrecision;

	private NativeArray<LightPixel> _lightDataLowPrecision;

	private NativeArray<LightPixelHiP> _lightDataHighPrecision;

	private NativeArray<int2> _adjDirs;

	private NativeParallelHashSet<TileCD> _drawableTiles;

	private NativeList<ColorOverride> _colorOverridesThisUpdate;

	private bool _refreshLightTextureData;

	private TileTypeColorLookupSystem _colorLookupSystem;

	private static bool _largeRevealDistance;

	public static bool shouldDumpMapLightData;

	public static bool showMapLightDebugTexture;

	public static Texture2D mapRevealDebugTexture;

	[Preserve]
	[Command("ui.toggleLargerMapReveal", "Toggle larger map reveal.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void ToggleMapReveal()
	{
		_largeRevealDistance = !_largeRevealDistance;
	}

	[Preserve]
	protected override void OnCreate()
	{
		_asyncGpuReadbackSupported = SystemInfo.supportsAsyncGPUReadback;
		if (!_asyncGpuReadbackSupported)
		{
			Debug.Log("Async GPU readback not supported. The map UI will not update.");
			base.Enabled = false;
		}
		_lightReadbackRequest = default(AsyncGPUReadbackRequest);
		_drawableTiles = new NativeParallelHashSet<TileCD>(300, Allocator.Persistent);
		foreach (TileTypeColorTable.TileSetColors tileSetColor in Resources.Load<TileTypeColorTable>("TileTypeColorTable").tileSetColors)
		{
			foreach (TileTypeColorTable.TileColor tileColor in tileSetColor.tileColors)
			{
				_drawableTiles.Add(new TileCD
				{
					tileset = (int)tileSetColor.pugMapTileset,
					tileType = tileColor.tileType
				});
			}
		}
		_colorOverridesThisUpdate = new NativeList<ColorOverride>(64, Allocator.Persistent);
		_adjDirs = new NativeArray<int2>(Direction.allEightClockwise.Length, Allocator.Persistent);
		for (int i = 0; i < Direction.allEightClockwise.Length; i++)
		{
			_adjDirs[i] = Direction.allEightClockwise[i].i2;
		}
		_colorLookupSystem = base.World.GetOrCreateSystemManaged<TileTypeColorLookupSystem>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		_drawableTiles.Dispose();
		_colorOverridesThisUpdate.Dispose();
		_lightReadbackRequest.WaitForCompletion();
		if (_lightDataLowPrecision.IsCreated)
		{
			_lightDataLowPrecision.Dispose();
			_lightDataHighPrecision.Dispose();
		}
		_adjDirs.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (!_asyncGpuReadbackSupported)
		{
			return;
		}
		float revealDistance = (_largeRevealDistance ? 12f : 7f);
		if (Manager.ui.mapUI.PauseMapUpdates)
		{
			_refreshLightTextureData = true;
			return;
		}
		if (_refreshLightTextureData)
		{
			RefreshLightBufferData(revealDistance);
			return;
		}
		if (_lightReadbackRequest.done)
		{
			_refreshLightTextureData = true;
			if (_lightReadbackRequest.width != 0)
			{
				if (_lightReadbackRequest.hasError)
				{
					Debug.LogError("Error reading light texture data from GPU.");
				}
				else
				{
					UpdateTiles(revealDistance);
				}
			}
		}
		base.OnUpdate();
	}

	private void RefreshLightBufferData(float revealDistance)
	{
		PugCamera pugCamera = Manager.camera.gameCamera.GetPugCamera();
		if (pugCamera == null || !PugRP.TryGetCameraData(Manager.camera.gameCamera, out var cameraData))
		{
			Debug.LogError("PugCamera or CameraData was null");
		}
		else
		{
			if (!cameraData.TryGetRenderFeature<IndirectLightRenderFeature>(out var renderFeature))
			{
				return;
			}
			RenderTexture irradiance = renderFeature.irradiance;
			if (irradiance == null)
			{
				return;
			}
			_lightTextureFormat = irradiance.graphicsFormat;
			if (!SystemInfo.IsFormatSupported(_lightTextureFormat, FormatUsage.Sample) || !SystemInfo.IsFormatSupported(_lightTextureFormat, FormatUsage.ReadPixels))
			{
				Debug.LogError("MapUI graphics format not supported");
				return;
			}
			int2 int5 = new int2(irradiance.width, irradiance.height);
			float2 float5 = pugCamera.indirectLightSize;
			float2 float6 = math.saturate(revealDistance * 2f / float5);
			float2 float7 = float5 / int5;
			int2 int6 = (int2)math.ceil(int5 * float6);
			_lightTextureWindowSize = float7 * int6;
			if (math.any(_lightBufferResolution != int6))
			{
				if (_lightDataLowPrecision.IsCreated)
				{
					_lightDataLowPrecision.Dispose();
					_lightDataHighPrecision.Dispose();
				}
				_lightDataLowPrecision = new NativeArray<LightPixel>(int6.x * int6.y, Allocator.Persistent);
				_lightDataHighPrecision = new NativeArray<LightPixelHiP>(int6.x * int6.y, Allocator.Persistent);
				_lightBufferResolution = int6;
			}
			if (math.all(_lightBufferResolution < int5))
			{
				Transform indirectLightAnchor = pugCamera.indirectLightAnchor;
				Vector3 p = PugRPUtils.SnapBufferPosition(indirectLightAnchor.position, indirectLightAnchor.rotation, pugCamera.indirectLightSize, pugCamera.GetIndirectLightSnapResolution());
				_lightTextureOrigin = p.ToWorld().XZ();
				int2 int7 = (int5 - _lightBufferResolution) / 2;
				_usingHighLightPrecision = irradiance.format == RenderTextureFormat.ARGBFloat;
				_lightReadbackRequest = AsyncGPUReadback.Request(irradiance, 0, int7.x, _lightBufferResolution.x, int7.y, _lightBufferResolution.y, 0, 1, _lightTextureFormat);
				_refreshLightTextureData = false;
			}
		}
	}

	private void UpdateRevealDebugTexture(NativeArray<bool> hasWall, NativeArray<bool> hasLight, int size)
	{
		if (mapRevealDebugTexture == null || mapRevealDebugTexture.width != size)
		{
			mapRevealDebugTexture = new Texture2D(size, size);
			mapRevealDebugTexture.filterMode = FilterMode.Point;
		}
		Color[] array = new Color[mapRevealDebugTexture.width * mapRevealDebugTexture.height];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new Color(hasWall[i] ? 1 : 0, hasLight[i] ? 1 : 0, 0f, 1f);
		}
		mapRevealDebugTexture.SetPixels(array);
		mapRevealDebugTexture.Apply();
	}

	private void DumpMapLight(NativeArray<bool> hasWall, NativeArray<bool> hasLight, int size)
	{
		NativeArray<LightPixel> data = _lightReadbackRequest.GetData<LightPixel>();
		Texture2D texture2D = new Texture2D(_lightBufferResolution.x, _lightBufferResolution.y);
		Color[] array = new Color[texture2D.width * texture2D.height];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = data[i];
		}
		texture2D.SetPixels(array);
		texture2D.Apply();
		string text = Application.dataPath + "/mapLight.png";
		File.WriteAllBytes(text, texture2D.EncodeToPNG());
		Debug.Log("Dumped map light data to: " + text);
		shouldDumpMapLightData = false;
	}

	private void UpdateTiles(float revealDistance)
	{
		if (Manager.ui == null || Manager.ui.mapUI == null)
		{
			Debug.LogError("Cannot update map due to missing map UI.");
		}
		else
		{
			if (Manager.main.player == null)
			{
				return;
			}
			float revealDistanceSq = revealDistance * revealDistance;
			float num = revealDistance + 1.5f;
			float revealDistanceWithPaddingSq = num * num;
			int num2 = (int)(2f * math.ceil(revealDistance) + 2f);
			int2 int5 = (int2)math.ceil((float2)((float)num2 * -0.5f));
			PugColorARGB32 currentMapTimestampColor = MapUI.CurrentMapTimestampColor;
			int2 int6 = Manager.main.player.WorldPosition.RoundToInt2();
			NativeArray<bool> nativeArray = CollectionHelper.CreateNativeArray<bool>(num2 * num2, base.World.UpdateAllocator.ToAllocator);
			NativeArray<bool> hasLight = CollectionHelper.CreateNativeArray<bool>(num2 * num2, base.World.UpdateAllocator.ToAllocator);
			TileTypeColorLookupSystem.LookupHelper tileTypeColorLookup = _colorLookupSystem.CreateLookupHelper();
			TileAccessor tileLookup = CreateTileAccessor();
			IJobExtensions.Run(new ExtractNearbyWallAndLightJob
			{
				UpdateSquareSize = num2,
				SquareBottomLeftLocalPos = int5,
				RevealDistanceWithPaddingSq = revealDistanceWithPaddingSq,
				RevealThreshold = 0.0015f,
				PlayerPos = int6,
				LightBufferOrigin = _lightTextureOrigin,
				LightBufferResolution = _lightBufferResolution,
				LightBufferWindowSize = _lightTextureWindowSize,
				HashWall = nativeArray,
				HasLight = hasLight,
				TileAccessor = tileLookup,
				LightTexPixels = _lightReadbackRequest.GetData<LightPixel>(),
				LightTexPixelsHiP = _lightReadbackRequest.GetData<LightPixelHiP>(),
				HighPrecisionLight = _usingHighLightPrecision
			});
			if (shouldDumpMapLightData)
			{
				DumpMapLight(nativeArray, hasLight, num2);
			}
			if (showMapLightDebugTexture)
			{
				UpdateRevealDebugTexture(nativeArray, hasLight, num2);
				Graphics.DrawTexture(new Rect(0f, 0f, mapRevealDebugTexture.width, mapRevealDebugTexture.height), mapRevealDebugTexture);
			}
			NativeParallelHashSet<int2> nativeParallelHashSet = new NativeParallelHashSet<int2>(4, Allocator.Temp);
			float2 worldPos = (int6 + int5 + new int2(0, 0)).ToFloat2();
			nativeParallelHashSet.Add(MapUI.WorldPositionToMapPartIndex(worldPos).ToInt2());
			worldPos = (int6 + int5 + new int2(0, num2 - 1)).ToFloat2();
			nativeParallelHashSet.Add(MapUI.WorldPositionToMapPartIndex(worldPos).ToInt2());
			worldPos = (int6 + int5 + new int2(num2 - 1, 0)).ToFloat2();
			nativeParallelHashSet.Add(MapUI.WorldPositionToMapPartIndex(worldPos).ToInt2());
			worldPos = (int6 + int5 + new int2(num2 - 1, num2 - 1)).ToFloat2();
			nativeParallelHashSet.Add(MapUI.WorldPositionToMapPartIndex(worldPos).ToInt2());
			foreach (int2 item in nativeParallelHashSet)
			{
				Manager.ui.mapUI.GetOrCreateMapTextures(item, out var textureData, out var timestampData);
				IJobExtensions.Run(new UpdateMapPartJob
				{
					UpdateSquareSize = num2,
					SquareBottomLeftLocalPos = int5,
					PlayerPos = int6,
					HasWall = nativeArray,
					HasLight = hasLight,
					TileLookup = tileLookup,
					AdjDirs = _adjDirs,
					DrawableTiles = _drawableTiles,
					TimestampColor = currentMapTimestampColor,
					RevealDistanceSq = revealDistanceSq,
					TextureData = textureData,
					TimestampData = timestampData,
					ColorOverridesThisUpdate = _colorOverridesThisUpdate,
					CurrentMapKeyPos = item,
					OnlyRevealLitTiles = !_largeRevealDistance,
					TileTypeColorLookup = tileTypeColorLookup,
					UpdatedMapKeys = Manager.ui.mapUI.MapsChangedThisUpdate
				});
			}
			nativeParallelHashSet.Dispose();
			_colorOverridesThisUpdate.Clear();
		}
	}

	public void SetColorOverridesThisUpdate(int2 worldPos, Color c)
	{
		ref NativeList<ColorOverride> colorOverridesThisUpdate = ref _colorOverridesThisUpdate;
		ColorOverride value = new ColorOverride
		{
			Position = worldPos,
			Color = c
		};
		colorOverridesThisUpdate.Add(in value);
	}

	[Preserve]
	public MapUpdateSystem()
	{
	}
}
