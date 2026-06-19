using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using PugTilemap.Quads;
using PugTilemap.Workshop;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PugMapLayer2 : MonoBehaviour, IDisposable
{
	public struct ParticleSystemTileScalableData
	{
		public struct BurstData
		{
			public float defaultProbability;
		}

		public bool isSubEmitter;

		public PugMapTileParticleExtraConfiguration extraConfig;

		public ParticleSystem.MinMaxCurve defeaultEmission;

		public FixedList32Bytes<BurstData> bursts;

		public ParticleSystemTileScalableData(ParticleSystem particleSystem, bool isSubEmitter)
		{
			this.isSubEmitter = isSubEmitter;
			extraConfig = particleSystem.GetComponent<PugMapTileParticleExtraConfiguration>();
			ParticleSystem.EmissionModule emission = particleSystem.emission;
			defeaultEmission = emission.rateOverTime;
			bursts = default(FixedList32Bytes<BurstData>);
			for (int i = 0; i < emission.burstCount; i++)
			{
				ParticleSystem.Burst burst = emission.GetBurst(i);
				bursts.Add(new BurstData
				{
					defaultProbability = burst.probability
				});
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	private struct VertexData
	{
		public float3 Position;

		public float3 Normal;

		public Color32 Color;

		public float2 Uv;
	}

	[BurstCompile]
	private struct ParticleMoveJob : IJob
	{
		public NativeArray<ParticleSystem.Particle> particles;

		public Vector3 offset;

		public void Execute()
		{
			for (int i = 0; i < particles.Length; i++)
			{
				ParticleSystem.Particle value = particles[i];
				value.position -= offset;
				particles[i] = value;
			}
		}
	}

	private struct LayerQuadData
	{
		public QuadGenerator.FillType meshFillType;

		public bool skewInTopVertices;

		public bool onlyAdaptToOwnTileset;

		public bool ignoreDiagonalQuads;

		public bool ignoreVerticalQuads;

		public bool ignoreHorizontalQuads;

		public bool isUsingFullAdaptiveTexture;

		public TileType overrideTileTypeForMeshAdjustments;

		public TileType targetTile;

		public TileType dontAdaptIfTilePresent;

		public bool hideUnderNonTransparentWall;

		[ReadOnly]
		public NativeArray<UnsafeList<Rect>> allSpriteUVs;

		[ReadOnly]
		public NativeArray<AdaptiveSpriteLookupTable> adaptiveSpriteLookupTable;

		[ReadOnly]
		public NativeArray<byte> adaptiveDirBitsAvailable;

		[ReadOnly]
		public NativeArray<AdaptiveSpriteLookupTable> generatedTextureAdaptiveSpriteLookupTable;

		[ReadOnly]
		public NativeArray<byte> generatedTextureAdaptiveDirBitsAvailable;
	}

	private struct AdaptiveSpriteLookupTable
	{
		public UnsafeList<Rect> allSpriteCoords;

		public UnsafeList<int> sublistStart;

		public UnsafeList<int> sublistLength;

		public Rect GetSpriteCoordsForDirCombination(byte dirFlags, byte random)
		{
			return sublistLength[dirFlags] switch
			{
				0 => Rect.zero, 
				1 => allSpriteCoords[sublistStart[dirFlags]], 
				_ => allSpriteCoords[sublistStart[dirFlags] + random % sublistLength[dirFlags]], 
			};
		}
	}

	[BurstCompile]
	private struct PreBuildJob : IJob
	{
		public NativeParallelMultiHashMap<int2, TileInfo> tileLookup;

		public NativeParallelHashMap<int2, int> layerDataUpdates;

		public TileType tileType;

		public Tileset tileset;

		public void Execute()
		{
			if (tileType == TileType.none)
			{
				return;
			}
			foreach (KeyValue<int2, int> layerDataUpdate in layerDataUpdates)
			{
				int2 key = layerDataUpdate.Key;
				int value = layerDataUpdate.Value;
				if (value == -2)
				{
					continue;
				}
				using NativeParallelMultiHashMap<int2, TileInfo>.Enumerator enumerator2 = tileLookup.GetValuesForKey(key);
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.tileType == tileType && (tileset == (Tileset)(-1) || tileset == (Tileset)enumerator2.Current.tileset))
					{
						tileLookup.Remove(key, enumerator2.Current);
						enumerator2.Reset();
					}
				}
				if (value != -1)
				{
					tileLookup.Add(key, new TileInfo((int)tileset, tileType, value));
				}
			}
			using NativeArray<int2> nativeArray = layerDataUpdates.GetKeyArray(Allocator.Temp);
			foreach (int2 item in nativeArray)
			{
				layerDataUpdates.TryAdd(item + new int2(0, 1), -2);
				layerDataUpdates.TryAdd(item + new int2(0, -1), -2);
				layerDataUpdates.TryAdd(item + new int2(1, 1), -2);
				layerDataUpdates.TryAdd(item + new int2(1, -1), -2);
				layerDataUpdates.TryAdd(item + new int2(1, 0), -2);
				layerDataUpdates.TryAdd(item + new int2(-1, 1), -2);
				layerDataUpdates.TryAdd(item + new int2(-1, -1), -2);
				layerDataUpdates.TryAdd(item + new int2(-1, 0), -2);
			}
		}
	}

	[BurstCompile]
	private struct BuildJob : IJob
	{
		[ReadOnly]
		public LayerQuadData quadData;

		[ReadOnly]
		public NativeArray<int> eightWay;

		[ReadOnly]
		public NativeArray<int> fourWay;

		[ReadOnly]
		public NativeParallelMultiHashMap<int2, TileInfo> tileLookup;

		[ReadOnly]
		public NativeParallelMultiHashMap<int2, TileInfo> hiddenTileLookup;

		[ReadOnly]
		public NativeParallelHashMap<int2, int> layerDataUpdates;

		public NativeParallelHashMap<int2, Quad> quads;

		public Tileset tileset;

		public void Execute()
		{
			foreach (KeyValue<int2, int> layerDataUpdate in layerDataUpdates)
			{
				int2 key = layerDataUpdate.Key;
				int value = layerDataUpdate.Value;
				switch (value)
				{
				case -1:
					if (quads.ContainsKey(key))
					{
						quads.Remove(key);
					}
					break;
				case -2:
				{
					if (quads.TryGetValue(key, out var item))
					{
						ResolveQuad(key, item.state, out item, tileLookup, hiddenTileLookup, in quadData, tileset, in eightWay, in fourWay);
						quads[key] = item;
					}
					break;
				}
				default:
				{
					ResolveQuad(key, value, out var q, tileLookup, hiddenTileLookup, in quadData, tileset, in eightWay, in fourWay);
					quads[key] = q;
					break;
				}
				}
			}
			while (quads.Count() > quads.Capacity / 2)
			{
				quads.Capacity *= 2;
			}
		}
	}

	[BurstCompile]
	private struct MeshCreator : IJob, IDisposable
	{
		[ReadOnly]
		public bool IsCreated;

		[ReadOnly]
		public NativeParallelHashMap<int2, Quad> quadsMap;

		public NativeArray<bool> isEmpty;

		[ReadOnly]
		public NativeArray<QuadGenerator.TileFace> tileFaces;

		public float padding;

		public float3 offset;

		public float heightStretch;

		public bool skewInTopVertices;

		public bool layerIgnoresVertexOffsets;

		public bool hideInteriorFaces;

		public int2 origo;

		public NativeArray<VertexData> vertexData;

		public NativeArray<ushort> indices;

		public void Dispose()
		{
			isEmpty.Dispose();
			tileFaces.Dispose();
			IsCreated = false;
		}

		public void Execute()
		{
			NativeArray<Quad> valueArray = quadsMap.GetValueArray(Allocator.Temp);
			isEmpty[0] = valueArray.Length == 0;
			int num = 0;
			foreach (Quad item in valueArray)
			{
				foreach (QuadGenerator.TileFace tileFace in tileFaces)
				{
					_BuildMeshSingle(item, tileFace, num++, padding, offset, heightStretch, skewInTopVertices, ref vertexData, ref indices, layerIgnoresVertexOffsets, origo);
				}
			}
			valueArray.Dispose();
		}
	}

	[BurstCompile]
	private struct BuildMeshJob : IJob, IDisposable
	{
		[ReadOnly]
		public bool IsCreated;

		[ReadOnly]
		public NativeParallelHashMap<int2, Quad> quadsMap;

		public NativeArray<bool> isEmpty;

		[ReadOnly]
		public NativeArray<QuadGenerator.TileFace> tileFaces;

		public float padding;

		public float3 offset;

		public float heightStretch;

		public bool skewInTopVertices;

		public bool layerIgnoresVertexOffsets;

		public bool hideInteriorFaces;

		public int2 origo;

		public Mesh.MeshData meshData;

		public void Dispose()
		{
			isEmpty.Dispose();
			tileFaces.Dispose();
			IsCreated = false;
		}

		public void Execute()
		{
			NativeArray<Quad> valueArray = quadsMap.GetValueArray(Allocator.Temp);
			isEmpty[0] = valueArray.Length == 0;
			int num = 0;
			foreach (Quad item in valueArray)
			{
				if (!IsQuadRelevant(item))
				{
					continue;
				}
				foreach (QuadGenerator.TileFace tileFace in tileFaces)
				{
					if (IsFaceRelevant(item, tileFace))
					{
						num++;
					}
				}
			}
			int indexCount = 6 * num;
			int vertexCount = 4 * num;
			NativeArray<VertexAttributeDescriptor> attributes = new NativeArray<VertexAttributeDescriptor>(4, Allocator.Temp);
			attributes[0] = new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0);
			attributes[1] = new VertexAttributeDescriptor(VertexAttribute.Normal);
			attributes[2] = new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4);
			attributes[3] = new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2);
			meshData.SetVertexBufferParams(vertexCount, attributes);
			meshData.SetIndexBufferParams(indexCount, IndexFormat.UInt16);
			attributes.Dispose();
			NativeArray<VertexData> vertexData = meshData.GetVertexData<VertexData>();
			NativeArray<ushort> indices = meshData.GetIndexData<ushort>();
			int num2 = 0;
			foreach (Quad item2 in valueArray)
			{
				if (!IsQuadRelevant(item2))
				{
					continue;
				}
				foreach (QuadGenerator.TileFace tileFace2 in tileFaces)
				{
					if (IsFaceRelevant(item2, tileFace2))
					{
						_BuildMeshSingle(item2, tileFace2, num2++, padding, offset, heightStretch, skewInTopVertices, ref vertexData, ref indices, layerIgnoresVertexOffsets, origo);
					}
				}
			}
			meshData.subMeshCount = 1;
			meshData.SetSubMesh(0, new SubMeshDescriptor(0, indexCount), MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontRecalculateBounds);
			valueArray.Dispose();
		}

		private bool IsQuadRelevant(Quad quad)
		{
			return !quad.hidden;
		}

		private bool IsFaceRelevant(Quad quad, QuadGenerator.TileFace face)
		{
			bool flag = (quad.adjacentTilesMask & 0x40) != 0;
			bool flag2 = (quad.adjacentTilesMask & 4) != 0;
			bool flag3 = (quad.adjacentTilesMask & 0x10) != 0;
			bool flag4 = (quad.adjacentTilesMask & 1) != 0;
			if (offset.y + ((face == QuadGenerator.TileFace.BOTTOM) ? (0f - padding) : 0f) > 0f && ((flag2 && face == QuadGenerator.TileFace.FRONT) || (flag && face == QuadGenerator.TileFace.BACK) || (flag4 && face == QuadGenerator.TileFace.RIGHT) || (flag3 && face == QuadGenerator.TileFace.LEFT)))
			{
				return false;
			}
			if (hideInteriorFaces)
			{
				int num = face switch
				{
					QuadGenerator.TileFace.TOP => 255, 
					QuadGenerator.TileFace.BOTTOM => 255, 
					QuadGenerator.TileFace.FRONT => 4, 
					QuadGenerator.TileFace.BACK => 64, 
					QuadGenerator.TileFace.LEFT => 16, 
					QuadGenerator.TileFace.RIGHT => 1, 
					_ => 255, 
				};
				if ((quad.adjacentTilesMask & num) == num)
				{
					return false;
				}
			}
			return true;
		}
	}

	public const int REMOVE_TILE_STATE = -1;

	public const int DIRTY_TILE_STATE = -2;

	private static readonly int EmissiveTex = Shader.PropertyToID("_EmissiveTex");

	private static readonly int EffectMaskTex = Shader.PropertyToID("_EffectMaskTex");

	private static readonly int BumpMap = Shader.PropertyToID("_BumpMap");

	private List<ParticleSystem> instantiatedParticleSystems;

	private List<ParticleSystemTileScalableData> particleSystemTileScalableData;

	private ParticleSystem.MinMaxCurve zeroParticlesCurve = new ParticleSystem.MinMaxCurve
	{
		constant = 0f
	};

	private NativeParallelHashMap<int2, Quad> quads;

	private LayerQuadData quadData;

	private BuildJob buildJob;

	private JobHandle buildJobHandle;

	private PreBuildJob preBuildJob;

	public static bool UseJobs = true;

	private Transform cachedTransform;

	private Mesh mesh;

	private JobHandle meshJobHandle;

	private JobHandle meshCreatorHandle;

	private MeshCreator meshCreator;

	private BuildMeshJob meshJob;

	private ParticleMoveJob[] particleMoveJobs;

	private JobHandle[] particleMoveJobHandles;

	private bool shouldScheduleMeshJob;

	private int2 lastOrigin;

	private bool meshJobRunning;

	private bool initialized;

	public int tilesetKey { get; private set; }

	public LayerName layerDefKey { get; private set; }

	public PugMapTileset tileset { get; private set; }

	public QuadGenerator quadGenerator { get; private set; }

	public Texture2D texture { get; private set; }

	public Texture2D emissiveTexture { get; private set; }

	public Texture2D effectMaskTexture { get; private set; }

	public Texture2D normalsTexture { get; private set; }

	public Material material { get; private set; }

	public MeshRenderer meshRenderer { get; private set; }

	public int layerDataLookupKey { get; set; }

	public List<PugMapLayer2> extraDependentLayers { get; private set; }

	public Quad GetQuad(int2 pos)
	{
		if (quads.IsCreated && quads.ContainsKey(pos))
		{
			return quads[pos];
		}
		return default(Quad);
	}

	public void Start()
	{
		cachedTransform = base.transform;
	}

	public void Init(int tilesetKey, LayerName layerDefKey)
	{
		initialized = false;
		meshJobRunning = (shouldScheduleMeshJob = false);
		this.tilesetKey = tilesetKey;
		this.layerDefKey = layerDefKey;
		extraDependentLayers = new List<PugMapLayer2>();
		tileset = TilesetTypeUtility.GetTileset(tilesetKey);
		quadGenerator = tileset.GetDef(layerDefKey);
		if (quadGenerator == null)
		{
			Debug.LogError(layerDefKey.ToString() + " in tileset " + tilesetKey + " does not exist, why have you made a layer with that?");
			return;
		}
		if (layerDefKey == LayerName.sunBeam)
		{
			base.transform.localPosition += Vector3.up * 0.001f;
		}
		base.gameObject.layer = quadGenerator.layer;
	}

	private void Init2(Dictionary<int2, Material> materialCache, bool reInitialize)
	{
		if (!quadGenerator.HasTileset(tilesetKey))
		{
			return;
		}
		if (quadGenerator.isUsingFullAdaptiveTexture)
		{
			texture = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.REGULAR);
			emissiveTexture = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.EMISSIVE);
			effectMaskTexture = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.EFFECT_MASK);
			normalsTexture = TilesetTypeUtility.GetAdaptiveTexture(tilesetKey, layerDefKey, TextureType.NORMALS);
		}
		else
		{
			texture = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.REGULAR);
			emissiveTexture = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.EMISSIVE);
			effectMaskTexture = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.EFFECT_MASK);
			normalsTexture = TilesetTypeUtility.GetTexture(tilesetKey, layerDefKey, TextureType.NORMALS);
		}
		if (!Application.isPlaying)
		{
			material = quadGenerator.overrideEditorMaterial;
			Material editorOverrideMaterial = TilesetTypeUtility.GetEditorOverrideMaterial(tilesetKey, layerDefKey);
			if (material != editorOverrideMaterial)
			{
				material = editorOverrideMaterial;
			}
		}
		if (material == null)
		{
			material = TilesetTypeUtility.GetOverrideMaterial(tilesetKey, layerDefKey);
		}
		if (material == null)
		{
			material = quadGenerator.overrideMaterial;
		}
		if (material == null)
		{
			material = tileset.tilesetMaterial;
		}
		if (quadGenerator.meshFillType == QuadGenerator.FillType.CustomFill)
		{
			texture = quadGenerator.customTexture;
			material = quadGenerator.customMaterial;
		}
		else
		{
			texture = ((texture == null) ? tileset.tilesetTexture : texture);
			material = ((material == null) ? tileset.tilesetMaterial : material);
		}
		tileset.InitLookupTables();
		MeshInit(materialCache, reInitialize);
		if (!quads.IsCreated)
		{
			quads = new NativeParallelHashMap<int2, Quad>(64, Allocator.Persistent);
		}
		if (!meshCreator.IsCreated)
		{
			InitCreator(ref meshCreator);
		}
		if (!meshJob.IsCreated)
		{
			InitJob(ref meshJob);
		}
		LayerQuadData layerQuadData = new LayerQuadData
		{
			meshFillType = quadGenerator.meshFillType,
			skewInTopVertices = quadGenerator.skewInTopVertices,
			onlyAdaptToOwnTileset = quadGenerator.onlyAdaptToOwnTileset,
			ignoreDiagonalQuads = (quadGenerator.ignoreVerticalAndDiagonalQuads || quadGenerator.ignoreDiagonalQuads),
			ignoreVerticalQuads = (quadGenerator.ignoreVerticalAndDiagonalQuads || quadGenerator.ignoreVerticalQuads),
			ignoreHorizontalQuads = quadGenerator.ignoreHorizontalQuads,
			isUsingFullAdaptiveTexture = quadGenerator.isUsingFullAdaptiveTexture,
			overrideTileTypeForMeshAdjustments = quadGenerator.overrideTileTypeForMeshAdjustments,
			targetTile = quadGenerator.targetTile,
			dontAdaptIfTilePresent = quadGenerator.dontAdaptIfTilePresent,
			hideUnderNonTransparentWall = quadGenerator.hideUnderNonTransparentWall,
			allSpriteUVs = new NativeArray<UnsafeList<Rect>>(quadGenerator.allSpriteUVs.Length, Allocator.Persistent),
			adaptiveDirBitsAvailable = new NativeArray<byte>(quadGenerator.adaptativeDirBitsAvailable.Length, Allocator.Persistent),
			adaptiveSpriteLookupTable = new NativeArray<AdaptiveSpriteLookupTable>(quadGenerator.adaptativeSpriteLookupTable.Length, Allocator.Persistent),
			generatedTextureAdaptiveDirBitsAvailable = new NativeArray<byte>(quadGenerator.generatedTextureAdaptativeDirBitsAvailable.Length, Allocator.Persistent),
			generatedTextureAdaptiveSpriteLookupTable = new NativeArray<AdaptiveSpriteLookupTable>(quadGenerator.generatedTextureAdaptativeSpriteLookupTable.Length, Allocator.Persistent)
		};
		for (int i = 0; i < layerQuadData.allSpriteUVs.Length; i++)
		{
			List<Rect> spriteUVS = quadGenerator.allSpriteUVs[i].spriteUVS;
			UnsafeList<Rect> value = new UnsafeList<Rect>(spriteUVS.Count, Allocator.Persistent);
			foreach (Rect item in spriteUVS)
			{
				value.Add(item);
			}
			layerQuadData.allSpriteUVs[i] = value;
		}
		for (int j = 0; j < layerQuadData.adaptiveSpriteLookupTable.Length; j++)
		{
			AdaptativeSpriteLookupTable adaptativeSpriteLookupTable = quadGenerator.adaptativeSpriteLookupTable[j];
			AdaptiveSpriteLookupTable value2 = new AdaptiveSpriteLookupTable
			{
				allSpriteCoords = new UnsafeList<Rect>(adaptativeSpriteLookupTable.allSpriteCoords.Length, Allocator.Persistent),
				sublistStart = new UnsafeList<int>(adaptativeSpriteLookupTable.sublistStart.Length, Allocator.Persistent),
				sublistLength = new UnsafeList<int>(adaptativeSpriteLookupTable.sublistLength.Length, Allocator.Persistent)
			};
			Rect[] allSpriteCoords = adaptativeSpriteLookupTable.allSpriteCoords;
			for (int k = 0; k < allSpriteCoords.Length; k++)
			{
				Rect value3 = allSpriteCoords[k];
				value2.allSpriteCoords.Add(in value3);
			}
			int[] sublistStart = adaptativeSpriteLookupTable.sublistStart;
			for (int k = 0; k < sublistStart.Length; k++)
			{
				int value4 = sublistStart[k];
				value2.sublistStart.Add(in value4);
			}
			sublistStart = adaptativeSpriteLookupTable.sublistLength;
			for (int k = 0; k < sublistStart.Length; k++)
			{
				int value5 = sublistStart[k];
				value2.sublistLength.Add(in value5);
			}
			layerQuadData.adaptiveSpriteLookupTable[j] = value2;
		}
		for (int l = 0; l < layerQuadData.adaptiveDirBitsAvailable.Length; l++)
		{
			layerQuadData.adaptiveDirBitsAvailable[l] = quadGenerator.adaptativeDirBitsAvailable[l];
		}
		for (int m = 0; m < layerQuadData.generatedTextureAdaptiveSpriteLookupTable.Length; m++)
		{
			AdaptativeSpriteLookupTable adaptativeSpriteLookupTable2 = quadGenerator.generatedTextureAdaptativeSpriteLookupTable[m];
			AdaptiveSpriteLookupTable value6 = new AdaptiveSpriteLookupTable
			{
				allSpriteCoords = new UnsafeList<Rect>(adaptativeSpriteLookupTable2.allSpriteCoords.Length, Allocator.Persistent),
				sublistStart = new UnsafeList<int>(adaptativeSpriteLookupTable2.sublistStart.Length, Allocator.Persistent),
				sublistLength = new UnsafeList<int>(adaptativeSpriteLookupTable2.sublistLength.Length, Allocator.Persistent)
			};
			Rect[] allSpriteCoords = adaptativeSpriteLookupTable2.allSpriteCoords;
			for (int k = 0; k < allSpriteCoords.Length; k++)
			{
				Rect value7 = allSpriteCoords[k];
				value6.allSpriteCoords.Add(in value7);
			}
			int[] sublistStart = adaptativeSpriteLookupTable2.sublistStart;
			for (int k = 0; k < sublistStart.Length; k++)
			{
				int value8 = sublistStart[k];
				value6.sublistStart.Add(in value8);
			}
			sublistStart = adaptativeSpriteLookupTable2.sublistLength;
			for (int k = 0; k < sublistStart.Length; k++)
			{
				int value9 = sublistStart[k];
				value6.sublistLength.Add(in value9);
			}
			layerQuadData.generatedTextureAdaptiveSpriteLookupTable[m] = value6;
		}
		for (int n = 0; n < layerQuadData.generatedTextureAdaptiveDirBitsAvailable.Length; n++)
		{
			layerQuadData.generatedTextureAdaptiveDirBitsAvailable[n] = quadGenerator.generatedTextureAdaptativeDirBitsAvailable[n];
		}
		preBuildJob = new PreBuildJob
		{
			tileset = (Tileset)tilesetKey,
			tileType = quadGenerator.dataTile
		};
		buildJob = new BuildJob
		{
			quads = quads,
			quadData = layerQuadData,
			tileset = (Tileset)tilesetKey,
			eightWay = new NativeArray<int>(8, Allocator.Persistent),
			fourWay = new NativeArray<int>(4, Allocator.Persistent)
		};
		for (int num = 0; num < AdjacentDir.GetWays(getFourWay: false, getHorizontalWay: false).Length; num++)
		{
			buildJob.eightWay[num] = AdjacentDir.GetWays(getFourWay: false, getHorizontalWay: false)[num];
		}
		for (int num2 = 0; num2 < AdjacentDir.GetWays(getFourWay: true, getHorizontalWay: false).Length; num2++)
		{
			buildJob.fourWay[num2] = AdjacentDir.GetWays(getFourWay: true, getHorizontalWay: false)[num2];
		}
		if (layerDefKey == LayerName.water)
		{
			base.gameObject.AddComponent<WaterSimSurface>().type = WaterSimSurface.Type.Surface;
		}
	}

	public void Reset()
	{
		if (quads.IsCreated)
		{
			quads.Clear();
		}
	}

	private void InitJob(ref BuildMeshJob job)
	{
		job.tileFaces = quadGenerator.tileFaces.ToNativeArray(Allocator.Persistent);
		job.padding = quadGenerator.padding;
		job.offset = quadGenerator.offset;
		job.heightStretch = quadGenerator.heightStretch;
		job.skewInTopVertices = quadGenerator.skewInTopVertices;
		job.layerIgnoresVertexOffsets = quadGenerator.layerIgnoresVertexOffsets;
		job.hideInteriorFaces = quadGenerator.hideInteriorFaces;
		job.isEmpty = new NativeArray<bool>(1, Allocator.Persistent);
		job.IsCreated = true;
	}

	private void InitCreator(ref MeshCreator job)
	{
		job.tileFaces = quadGenerator.tileFaces.ToNativeArray(Allocator.Persistent);
		job.padding = quadGenerator.padding;
		job.offset = quadGenerator.offset;
		job.heightStretch = quadGenerator.heightStretch;
		job.skewInTopVertices = quadGenerator.skewInTopVertices;
		job.layerIgnoresVertexOffsets = quadGenerator.layerIgnoresVertexOffsets;
		job.hideInteriorFaces = quadGenerator.hideInteriorFaces;
		job.isEmpty = new NativeArray<bool>(1, Allocator.Persistent);
		job.IsCreated = true;
	}

	public void Dispose()
	{
		if (meshJobRunning)
		{
			meshJobHandle.Complete();
			if (instantiatedParticleSystems != null)
			{
				for (int i = 0; i < instantiatedParticleSystems.Count; i++)
				{
					particleMoveJobHandles[i].Complete();
					particleMoveJobs[i].particles.Dispose();
				}
			}
			meshJobRunning = false;
		}
		if (meshCreator.IsCreated)
		{
			meshCreator.Dispose();
		}
		if (meshJob.IsCreated)
		{
			meshJob.Dispose();
		}
		if (quads.IsCreated)
		{
			quads.Dispose();
		}
		if (!buildJob.eightWay.IsCreated)
		{
			return;
		}
		LayerQuadData layerQuadData = buildJob.quadData;
		foreach (UnsafeList<Rect> allSpriteUV in layerQuadData.allSpriteUVs)
		{
			allSpriteUV.Dispose();
		}
		layerQuadData.allSpriteUVs.Dispose();
		foreach (AdaptiveSpriteLookupTable item in layerQuadData.adaptiveSpriteLookupTable)
		{
			UnsafeList<Rect> allSpriteCoords = item.allSpriteCoords;
			allSpriteCoords.Dispose();
			UnsafeList<int> sublistStart = item.sublistStart;
			sublistStart.Dispose();
			sublistStart = item.sublistLength;
			sublistStart.Dispose();
		}
		layerQuadData.adaptiveSpriteLookupTable.Dispose();
		layerQuadData.adaptiveDirBitsAvailable.Dispose();
		foreach (AdaptiveSpriteLookupTable item2 in layerQuadData.generatedTextureAdaptiveSpriteLookupTable)
		{
			UnsafeList<Rect> allSpriteCoords = item2.allSpriteCoords;
			allSpriteCoords.Dispose();
			UnsafeList<int> sublistStart = item2.sublistStart;
			sublistStart.Dispose();
			sublistStart = item2.sublistLength;
			sublistStart.Dispose();
		}
		layerQuadData.generatedTextureAdaptiveSpriteLookupTable.Dispose();
		layerQuadData.generatedTextureAdaptiveDirBitsAvailable.Dispose();
		buildJob.eightWay.Dispose();
		buildJob.fourWay.Dispose();
		buildJob = default(BuildJob);
	}

	public Mesh ScheduleMeshJob(Mesh.MeshData meshData)
	{
		if (!meshJobRunning && shouldScheduleMeshJob)
		{
			meshJob.quadsMap = quads;
			lastOrigin = meshJob.origo;
			meshJob.origo = (Application.isPlaying ? Manager.camera.RenderOrigo.ToInt2() : int2.zero);
			meshJob.meshData = meshData;
			shouldScheduleMeshJob = false;
			meshJobRunning = true;
			meshJobHandle = meshJob.Schedule(buildJobHandle);
			shouldScheduleMeshJob = false;
			meshJobRunning = true;
			if (instantiatedParticleSystems != null)
			{
				ScheduleParticleUpdateJob();
			}
			return mesh;
		}
		return null;
	}

	public Mesh CreateMesh()
	{
		if (!meshJobRunning && shouldScheduleMeshJob)
		{
			meshCreator.quadsMap = quads;
			lastOrigin = meshCreator.origo;
			meshCreator.origo = (Application.isPlaying ? Manager.camera.RenderOrigo.ToInt2() : int2.zero);
			int num = quads.Count() * quadGenerator.tileFaces.Count;
			int length = 6 * num;
			int length2 = 4 * num;
			meshCreator.vertexData = new NativeArray<VertexData>(length2, Allocator.TempJob);
			meshCreator.indices = new NativeArray<ushort>(length, Allocator.TempJob);
			meshCreatorHandle = meshCreator.Schedule();
			shouldScheduleMeshJob = false;
			meshJobRunning = true;
			Debug.Log("Return real mesh");
			return mesh;
		}
		Debug.Log("Return null");
		return null;
	}

	public void CompleteMeshJob()
	{
		if (meshJobRunning)
		{
			meshJobHandle.Complete();
			meshCreatorHandle.Complete();
			meshJobRunning = false;
			if (!UseJobs)
			{
				int length = meshCreator.vertexData.Length;
				mesh.Clear();
				MeshUpdateFlags flags = MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontRecalculateBounds;
				mesh.SetVertices(meshCreator.vertexData.Select((VertexData x) => new Vector3(x.Position[0], x.Position[1], x.Position[2])).ToArray(), 0, length, flags);
				mesh.SetNormals(meshCreator.vertexData.Select((VertexData x) => new Vector3(x.Normal[0], x.Normal[1], x.Normal[2])).ToArray(), 0, length, flags);
				mesh.SetColors(((IEnumerable<VertexData>)meshCreator.vertexData).Select((Func<VertexData, Color>)((VertexData x) => x.Color)).ToArray(), 0, length, flags);
				mesh.SetUVs(0, meshCreator.vertexData.Select((VertexData x) => new Vector2(x.Uv[0], x.Uv[1])).ToArray(), 0, length, flags);
				mesh.SetTriangles(((IEnumerable<ushort>)meshCreator.indices).Select((Func<ushort, int>)((ushort x) => x)).ToArray(), 0, meshCreator.indices.Length, 0, calculateBounds: false);
				meshCreator.vertexData.Dispose();
				meshCreator.indices.Dispose();
			}
			if (instantiatedParticleSystems != null)
			{
				CompleteParticleUpdateJob();
			}
		}
		StopParticles(meshJob.isEmpty[0]);
	}

	private void ScheduleParticleUpdateJob()
	{
		for (int i = 0; i < instantiatedParticleSystems.Count; i++)
		{
			ParticleSystem particleSystem = instantiatedParticleSystems[i];
			NativeArray<ParticleSystem.Particle> particles = new NativeArray<ParticleSystem.Particle>(particleSystem.particleCount, Allocator.TempJob);
			Vector3 offset = (UseJobs ? (meshJob.origo - lastOrigin).ToFloat3() : (meshCreator.origo - lastOrigin).ToFloat3());
			particleSystem.GetParticles(particles);
			particleMoveJobs[i] = new ParticleMoveJob
			{
				particles = particles,
				offset = offset
			};
			particleMoveJobHandles[i] = particleMoveJobs[i].Schedule();
		}
	}

	private void CompleteParticleUpdateJob()
	{
		for (int i = 0; i < instantiatedParticleSystems.Count; i++)
		{
			particleMoveJobHandles[i].Complete();
			instantiatedParticleSystems[i].SetParticles(particleMoveJobs[i].particles);
			particleMoveJobs[i].particles.Dispose();
		}
	}

	private void MeshInit(Dictionary<int2, Material> materialCache, bool reInitialize)
	{
		mesh = new Mesh();
		mesh.MarkDynamic();
		MeshFilter component = GetComponent<MeshFilter>();
		meshRenderer = GetComponent<MeshRenderer>();
		component.mesh = mesh;
		meshRenderer.sortingLayerID = quadGenerator.sortingLayer;
		ParticleSystem particleSystem = TilesetTypeUtility.GetOverrideParticles(tilesetKey, layerDefKey);
		if (particleSystem == null)
		{
			particleSystem = quadGenerator.meshParticlePrefab;
		}
		if (particleSystem != null)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.parent = base.transform;
			gameObject.SetActive(value: false);
			ParticleSystem particleSystem2 = UnityEngine.Object.Instantiate(particleSystem, gameObject.transform);
			instantiatedParticleSystems = new List<ParticleSystem>();
			particleSystemTileScalableData = new List<ParticleSystemTileScalableData>();
			instantiatedParticleSystems.Add(particleSystem2);
			particleSystemTileScalableData.Add(new ParticleSystemTileScalableData(particleSystem2, isSubEmitter: false));
			ParticleSystem.SubEmittersModule subEmitters = particleSystem2.subEmitters;
			ParticleSystem[] componentsInChildren = particleSystem2.GetComponentsInChildren<ParticleSystem>();
			foreach (ParticleSystem particleSystem3 in componentsInChildren)
			{
				instantiatedParticleSystems.Add(particleSystem3);
				bool isSubEmitter = false;
				for (int j = 0; j < subEmitters.subEmittersCount; j++)
				{
					if (subEmitters.GetSubEmitterSystem(j) == particleSystem3)
					{
						isSubEmitter = true;
						break;
					}
				}
				particleSystemTileScalableData.Add(new ParticleSystemTileScalableData(particleSystem3, isSubEmitter));
			}
			StopParticles(disableCompletely: true);
			gameObject.SetActive(value: true);
			particleMoveJobs = new ParticleMoveJob[instantiatedParticleSystems.Count];
			particleMoveJobHandles = new JobHandle[instantiatedParticleSystems.Count];
		}
		meshRenderer.lightProbeUsage = LightProbeUsage.Off;
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Simple;
		meshRenderer.shadowCastingMode = ShadowCastingMode.On;
		meshRenderer.motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
		meshRenderer.shadowCastingMode = quadGenerator.shadowCastingMode;
		meshRenderer.receiveShadows = quadGenerator.receiveShadows;
		if (Application.isPlaying)
		{
			int2 key = new int2(tilesetKey, (int)layerDefKey);
			if (!reInitialize && materialCache.TryGetValue(key, out var value))
			{
				meshRenderer.sharedMaterial = value;
			}
			else
			{
				meshRenderer.material = material;
				meshRenderer.material.mainTexture = texture;
				if (effectMaskTexture != null)
				{
					meshRenderer.material.SetTexture(EffectMaskTex, effectMaskTexture);
				}
				if (emissiveTexture != null)
				{
					meshRenderer.material.SetTexture(EmissiveTex, emissiveTexture);
				}
				if (normalsTexture != null)
				{
					meshRenderer.material.SetTexture(BumpMap, normalsTexture);
				}
				if (emissiveTexture == null && quadGenerator.emissiveTexture != null)
				{
					meshRenderer.material.SetTexture(EmissiveTex, quadGenerator.emissiveTexture);
				}
				materialCache.TryAdd(key, meshRenderer.material);
			}
		}
		else
		{
			Material sharedMaterial = new Material(material)
			{
				mainTexture = texture,
				color = Color.white
			};
			meshRenderer.sharedMaterial = sharedMaterial;
		}
		if (quadGenerator.actAsCeilingLight)
		{
			base.gameObject.AddComponent<CeilingLightRenderer>().SetRenderOrderPass(quadGenerator.ceilingLightRenderOrderPass);
		}
	}

	public JobHandle PreBuild(JobHandle dependency, Dictionary<int2, Material> materialCache, ref NativeParallelMultiHashMap<int2, TileInfo> tileLookup, ref NativeParallelHashMap<int2, int> layerDataUpdates, bool reInitialize)
	{
		if (!initialized || reInitialize)
		{
			initialized = true;
			Init2(materialCache, reInitialize);
		}
		if (!quadGenerator.HasTileset(tilesetKey))
		{
			return dependency;
		}
		preBuildJob.tileLookup = tileLookup;
		preBuildJob.layerDataUpdates = layerDataUpdates;
		return preBuildJob.Schedule(dependency);
	}

	public bool Build(JobHandle dependency, NativeParallelMultiHashMap<int2, TileInfo> tileLookup, NativeParallelMultiHashMap<int2, TileInfo> hiddenTileLookup, NativeParallelHashMap<int2, int> layerDataUpdates)
	{
		if (!quadGenerator.HasTileset(tilesetKey))
		{
			return false;
		}
		buildJob.tileLookup = tileLookup;
		buildJob.hiddenTileLookup = hiddenTileLookup;
		buildJob.layerDataUpdates = layerDataUpdates;
		if (UseJobs)
		{
			buildJobHandle = buildJob.Schedule(dependency);
		}
		else
		{
			buildJob.Run();
		}
		shouldScheduleMeshJob = true;
		return true;
	}

	private void StopParticles(bool disableCompletely)
	{
		if (!Application.isPlaying || instantiatedParticleSystems == null)
		{
			return;
		}
		foreach (ParticleSystem instantiatedParticleSystem in instantiatedParticleSystems)
		{
			ParticleSystem.ShapeModule shape = instantiatedParticleSystem.shape;
			shape.shapeType = ParticleSystemShapeType.Sphere;
			shape.meshRenderer = null;
			ParticleSystem.EmissionModule emission = instantiatedParticleSystem.emission;
			emission.rateOverTime = zeroParticlesCurve;
			if (disableCompletely)
			{
				instantiatedParticleSystem.gameObject.SetActive(value: false);
			}
		}
	}

	public void ResetParticles()
	{
		if (Application.isPlaying && instantiatedParticleSystems != null && instantiatedParticleSystems.Count > 0 && instantiatedParticleSystems[0].gameObject.activeSelf)
		{
			StopParticles(disableCompletely: false);
			PlayParticles();
		}
	}

	private void PlayParticles()
	{
		if (!Application.isPlaying || instantiatedParticleSystems == null || !(mesh != null))
		{
			return;
		}
		float num = (float)mesh.vertexCount / 32f;
		float num2 = ((Application.isPlaying && Manager.prefs.particleQuality == 0) ? 0.2f : 1f);
		num *= num2;
		for (int i = 0; i < instantiatedParticleSystems.Count; i++)
		{
			ParticleSystem particleSystem = instantiatedParticleSystems[i];
			ParticleSystem.ShapeModule shape = particleSystem.shape;
			shape.shapeType = ParticleSystemShapeType.MeshRenderer;
			shape.meshRenderer = meshRenderer;
			ParticleSystemTileScalableData particleSystemTileScalableData = this.particleSystemTileScalableData[i];
			if (!particleSystemTileScalableData.isSubEmitter)
			{
				ParticleSystem.EmissionModule emission = particleSystem.emission;
				ParticleSystem.MinMaxCurve defeaultEmission = particleSystemTileScalableData.defeaultEmission;
				defeaultEmission.constantMin *= num;
				defeaultEmission.constantMax *= num;
				emission.rateOverTime = defeaultEmission;
				ScaleParticleBursts(emission, in particleSystemTileScalableData, mesh.vertexCount, num2);
			}
			particleSystem.gameObject.SetActive(value: true);
			if (!particleSystem.isPlaying)
			{
				particleSystem.Play();
			}
		}
	}

	private void ScaleParticleBursts(ParticleSystem.EmissionModule emission, in ParticleSystemTileScalableData particleSystemTileScalableData, int vertexCount, float multiplier)
	{
		if (emission.burstCount == 0)
		{
			return;
		}
		if (particleSystemTileScalableData.extraConfig == null)
		{
			Debug.LogError("No ParticleSystemTileScalableData component found for particle system with burst emission!");
			return;
		}
		for (int i = 0; i < emission.burstCount; i++)
		{
			ParticleSystem.Burst burst = emission.GetBurst(i);
			PugMapTileParticleExtraConfiguration.ParticleBurst particleBurst = particleSystemTileScalableData.extraConfig.burstsPerTileCount[i];
			ParticleSystemTileScalableData.BurstData burstData = particleSystemTileScalableData.bursts[i];
			float num = multiplier * (float)vertexCount / (float)(4 * particleBurst.targetTileCount);
			Vector2 vector = particleBurst.minMaxEmitCount * num;
			if (vector.y < 1f)
			{
				burst.count = new ParticleSystem.MinMaxCurve(1f);
				burst.probability = burstData.defaultProbability * (vector.x + vector.y) / 2f;
			}
			else if (vector.x < 1f)
			{
				Vector2Int vector2Int = new Vector2Int(1, Mathf.CeilToInt(vector.y));
				burst.count = new ParticleSystem.MinMaxCurve(vector2Int.x, vector2Int.y);
				float num2 = (vector.x + vector.y) / 2f;
				float num3 = (float)(vector2Int.x + vector2Int.y) / 2f;
				burst.probability = burstData.defaultProbability * (num2 / num3);
			}
			else
			{
				Vector2Int vector2Int2 = new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
				burst.count = new ParticleSystem.MinMaxCurve(vector2Int2.x, vector2Int2.y);
				burst.probability = burstData.defaultProbability;
			}
			emission.SetBurst(i, burst);
		}
	}

	[GenerateTestsForBurstCompatibility]
	private static void ResolveQuad(int2 position, int state, out Quad q, NativeParallelMultiHashMap<int2, TileInfo> nearbyTilesCheck, NativeParallelMultiHashMap<int2, TileInfo> nearbyHiddenTilesCheck, in LayerQuadData quadData, Tileset tileset, in NativeArray<int> eightWay, in NativeArray<int> fourWay)
	{
		q = new Quad(new Vector3Int(position.x, 0, position.y));
		q.state = state;
		if (quadData.hideUnderNonTransparentWall && HasNonTransparentWallAtPosition(position, nearbyTilesCheck))
		{
			q.hidden = true;
			return;
		}
		int num = 0;
		if (quadData.meshFillType == QuadGenerator.FillType.AdaptativeFill || quadData.meshFillType == QuadGenerator.FillType.AdaptativeExtrude || quadData.skewInTopVertices)
		{
			q.adjacentTilesMask = 0;
			int num2 = 0;
			TileType tileType = ((quadData.overrideTileTypeForMeshAdjustments == TileType.__illegal__) ? quadData.targetTile : quadData.overrideTileTypeForMeshAdjustments);
			bool flag = tileType.ShouldUseFenceLikeAdaption();
			bool flag2 = quadData.dontAdaptIfTilePresent == TileType.none || HasTileAtPosition(position, quadData.dontAdaptIfTilePresent, nearbyTilesCheck);
			for (int i = 0; i < eightWay.Length; i++)
			{
				int num3 = eightWay[i];
				int2 int5 = position + AdjacentDir.GetInt2(num3);
				if (!flag2 && HasTileAtPosition(int5, quadData.dontAdaptIfTilePresent, nearbyTilesCheck))
				{
					continue;
				}
				bool flag3 = PlacementHandler.IsPaintedGlass((int)tileset);
				bool flag4 = tileType == TileType.wall && (tileset == Tileset.Glass || flag3);
				foreach (TileInfo item in nearbyTilesCheck.GetValuesForKey(int5))
				{
					bool flag5 = PlacementHandler.IsPaintedGlass(item.tileset);
					bool flag6 = item.tileType == TileType.wall && (item.tileset == 34 || flag5);
					if (item.tileType != tileType || !(!flag6 || flag4))
					{
						continue;
					}
					q.adjacentTilesMask |= num3;
					if (!quadData.onlyAdaptToOwnTileset || item.tileset == (int)tileset)
					{
						num |= num3;
						if (flag && i % 2 == 0)
						{
							num2++;
						}
					}
					break;
				}
				foreach (TileInfo item2 in nearbyHiddenTilesCheck.GetValuesForKey(int5))
				{
					if (item2.tileType != tileType)
					{
						continue;
					}
					q.adjacentTilesMask |= num3;
					if (!quadData.onlyAdaptToOwnTileset || item2.tileset == (int)tileset)
					{
						num |= num3;
						if (flag && i % 2 == 0)
						{
							num2++;
						}
					}
					break;
				}
			}
			if (tileType.ShouldUseFenceLikeAdaption() && num2 < 2)
			{
				int num4 = 0;
				int num5 = 0;
				bool flag7 = false;
				int dir = num & 0x55;
				foreach (int item3 in fourWay)
				{
					int2 key = position + AdjacentDir.GetInt2(item3);
					foreach (TileInfo item4 in nearbyTilesCheck.GetValuesForKey(key))
					{
						if (tileType.ShouldUseFenceLikeAdaptionTowardsTileType(item4.tileType))
						{
							num4++;
							num5 = item3;
							if (num2 != 1)
							{
								num |= item3;
								break;
							}
							if (AdjacentDir.IsOppositeDirections(item3, dir))
							{
								num |= item3;
								flag7 = true;
								break;
							}
						}
					}
				}
				if (num2 == 1 && num4 == 1 && !flag7)
				{
					num |= num5;
				}
			}
		}
		switch (quadData.meshFillType)
		{
		case QuadGenerator.FillType.CustomFill:
			q.spriteUV = new Rect(0f, 0f, 1f, 1f);
			break;
		case QuadGenerator.FillType.RandomFill:
		{
			Unity.Mathematics.Random random = new Unity.Mathematics.Random(math.hash(position));
			q.spriteUV = quadData.allSpriteUVs[state][random.NextInt(0, quadData.allSpriteUVs[state].Length)];
			break;
		}
		case QuadGenerator.FillType.AdaptativeFill:
		case QuadGenerator.FillType.AdaptativeExtrude:
		{
			int num6 = new Unity.Mathematics.Random(math.hash(position)).NextInt(0, 256);
			NativeArray<byte> generatedTextureAdaptiveDirBitsAvailable = quadData.generatedTextureAdaptiveDirBitsAvailable;
			NativeArray<AdaptiveSpriteLookupTable> generatedTextureAdaptiveSpriteLookupTable = quadData.generatedTextureAdaptiveSpriteLookupTable;
			NativeArray<byte> adaptiveDirBitsAvailable = quadData.adaptiveDirBitsAvailable;
			NativeArray<AdaptiveSpriteLookupTable> adaptiveSpriteLookupTable = quadData.adaptiveSpriteLookupTable;
			if (quadData.ignoreDiagonalQuads)
			{
				num &= -171;
			}
			if (quadData.ignoreVerticalQuads)
			{
				num &= -69;
			}
			if (quadData.ignoreHorizontalQuads)
			{
				num &= -18;
			}
			if (quadData.isUsingFullAdaptiveTexture)
			{
				num &= generatedTextureAdaptiveDirBitsAvailable[state];
				q.spriteUV = generatedTextureAdaptiveSpriteLookupTable[state].GetSpriteCoordsForDirCombination((byte)num, (byte)num6);
			}
			else
			{
				num &= adaptiveDirBitsAvailable[state];
				q.spriteUV = adaptiveSpriteLookupTable[state].GetSpriteCoordsForDirCombination((byte)num, (byte)num6);
			}
			break;
		}
		}
	}

	private static bool HasTileAtPosition(int2 position, TileType tileType, NativeParallelMultiHashMap<int2, TileInfo> tiles)
	{
		NativeParallelMultiHashMap<int2, TileInfo>.Enumerator valuesForKey = tiles.GetValuesForKey(position);
		while (valuesForKey.MoveNext())
		{
			if (valuesForKey.Current.tileType == tileType)
			{
				return true;
			}
		}
		return false;
	}

	private static bool HasNonTransparentWallAtPosition(int2 position, NativeParallelMultiHashMap<int2, TileInfo> tiles)
	{
		NativeParallelMultiHashMap<int2, TileInfo>.Enumerator valuesForKey = tiles.GetValuesForKey(position);
		while (valuesForKey.MoveNext())
		{
			TileInfo current = valuesForKey.Current;
			if (current.tileType == TileType.wall && !((Tileset)current.tileset).HasTransparentWalls())
			{
				return true;
			}
		}
		return false;
	}

	public void ApplyMesh()
	{
		if (Application.isPlaying)
		{
			cachedTransform.SetParent(Manager.camera.VolatileRenderAnchor, worldPositionStays: false);
			int2 x = (UseJobs ? meshJob.origo : meshCreator.origo) - Manager.camera.RenderOrigo.ToInt2();
			cachedTransform.position = x.ToFloat3();
			if (Manager.camera.moveOrigo)
			{
				mesh.bounds = new Bounds(Vector3.zero, 150f * Vector3.one);
			}
			else
			{
				mesh.RecalculateBounds();
			}
		}
		else
		{
			mesh.bounds = new Bounds(Vector3.zero, 1000000f * Vector3.one);
		}
		if (!meshJob.isEmpty[0])
		{
			PlayParticles();
		}
	}

	private static void _BuildMeshSingle(Quad quad, QuadGenerator.TileFace face, int relevantFaceIndex, float padding, float3 offset, float heightStretch, bool skewInTopVertices, ref NativeArray<VertexData> vertexData, ref NativeArray<ushort> indices, bool layerIgnoresVertexOffsets, int2 origin)
	{
		Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		int num = relevantFaceIndex * 4;
		int num2 = relevantFaceIndex * 6;
		bool flag = (quad.adjacentTilesMask & 0x40) != 0;
		bool flag2 = (quad.adjacentTilesMask & 4) != 0;
		bool flag3 = (quad.adjacentTilesMask & 0x10) != 0;
		bool flag4 = (quad.adjacentTilesMask & 1) != 0;
		bool flag5 = (quad.adjacentTilesMask & 0x20) != 0;
		bool flag6 = (quad.adjacentTilesMask & 0x80) != 0;
		bool flag7 = (quad.adjacentTilesMask & 8) != 0;
		bool flag8 = (quad.adjacentTilesMask & 2) != 0;
		VertexData value = vertexData[num];
		VertexData value2 = vertexData[num + 1];
		VertexData value3 = vertexData[num + 2];
		VertexData value4 = vertexData[num + 3];
		float num3 = offset.x + ((float)(quad.pos.x - origin.x) - 0.5f + ((face == QuadGenerator.TileFace.LEFT) ? (0f - padding) : 0f));
		float num4 = offset.z + ((float)(quad.pos.z - origin.y) - 0.5f + ((face == QuadGenerator.TileFace.FRONT) ? (0f - padding) : 0f));
		float x = num3 + 1f + ((face == QuadGenerator.TileFace.RIGHT) ? padding : 0f);
		float num5 = num4 + 1f + ((face == QuadGenerator.TileFace.BACK) ? padding : 0f);
		float num6 = offset.y + ((face == QuadGenerator.TileFace.BOTTOM) ? (0f - padding) : 0f);
		float num7 = offset.y + 1f + heightStretch + ((face == QuadGenerator.TileFace.TOP) ? padding : 0f);
		float z = (skewInTopVertices ? (num5 - math.clamp(0.4f * num6, 0f, 1f)) : 0f);
		float z2 = (skewInTopVertices ? (num5 - math.clamp(0.4f * num7, 0f, 1f)) : 0f);
		float z3 = (skewInTopVertices ? (num4 - math.clamp(0.4f * num6, 0f, 1f)) : 0f);
		float z4 = (skewInTopVertices ? (num4 - math.clamp(0.4f * num7, 0f, 1f)) : 0f);
		float3 xyz = math.up();
		indices[num2++] = (ushort)num;
		indices[num2++] = (ushort)(num + 1);
		indices[num2++] = (ushort)(num + 2);
		indices[num2++] = (ushort)num;
		indices[num2++] = (ushort)(num + 2);
		indices[num2++] = (ushort)(num + 3);
		if (face == QuadGenerator.TileFace.BACK)
		{
			value.Uv = new float2(quad.spriteUV.xMax, quad.spriteUV.yMin);
			value2.Uv = new float2(quad.spriteUV.xMax, quad.spriteUV.yMax);
			value3.Uv = new float2(quad.spriteUV.xMin, quad.spriteUV.yMax);
			value4.Uv = new float2(quad.spriteUV.xMin, quad.spriteUV.yMin);
		}
		else
		{
			value.Uv = new float2(quad.spriteUV.xMin, quad.spriteUV.yMin);
			value2.Uv = new float2(quad.spriteUV.xMin, quad.spriteUV.yMax);
			value3.Uv = new float2(quad.spriteUV.xMax, quad.spriteUV.yMax);
			value4.Uv = new float2(quad.spriteUV.xMax, quad.spriteUV.yMin);
		}
		value.Color = color;
		value2.Color = color;
		value3.Color = color;
		value4.Color = color;
		switch (face)
		{
		case QuadGenerator.TileFace.TOP:
			if (!layerIgnoresVertexOffsets)
			{
				if (!skewInTopVertices || flag)
				{
					value.Position = new float3(num3, num7, num4);
					value2.Position = new float3(num3, num7, num5);
					value3.Position = new float3(x, num7, num5);
					value4.Position = new float3(x, num7, num4);
				}
				else
				{
					value.Position = new float3(num3, num7, num4);
					value2.Position = (flag5 ? new float3(num3, num7, num5) : new float3(num3, num7, z2));
					value3.Position = (flag6 ? new float3(x, num7, num5) : new float3(x, num7, z2));
					value4.Position = new float3(x, num7, num4);
				}
				break;
			}
			if (!skewInTopVertices)
			{
				value.Position = new float3(num3, num7, num4);
				value2.Position = new float3(num3, num7, num5);
				value3.Position = new float3(x, num7, num5);
				value4.Position = new float3(x, num7, num4);
				break;
			}
			if (!flag3 && flag2 && flag7)
			{
				value.Position = new float3(num3, num7, z4);
			}
			else
			{
				value.Position = new float3(num3, num7, num4);
			}
			if (!flag || (flag && flag3 && !flag5))
			{
				value2.Position = new float3(num3, num7, z2);
			}
			else
			{
				value2.Position = new float3(num3, num7, num5);
			}
			if (!flag || (flag && flag4 && !flag6))
			{
				value3.Position = new float3(x, num7, z2);
			}
			else
			{
				value3.Position = new float3(x, num7, num5);
			}
			if (!flag4 && flag2 && flag8)
			{
				value4.Position = new float3(x, num7, z4);
			}
			else
			{
				value4.Position = new float3(x, num7, num4);
			}
			break;
		case QuadGenerator.TileFace.BOTTOM:
			value.Position = new float3(num3, num6, num4);
			value2.Position = new float3(num3, num6, num5);
			value3.Position = new float3(x, num6, num5);
			value4.Position = new float3(x, num6, num4);
			break;
		case QuadGenerator.TileFace.FRONT:
			if (!layerIgnoresVertexOffsets)
			{
				value.Position = new float3(num3, num6, num4);
				value2.Position = new float3(num3, num7, num4);
				value3.Position = new float3(x, num7, num4);
				value4.Position = new float3(x, num6, num4);
			}
			else
			{
				if (!flag3 && flag2 && flag7)
				{
					value.Position = new float3(num3, num6, z3);
					value2.Position = new float3(num3, num7, z4);
				}
				else
				{
					value.Position = new float3(num3, num6, num4);
					value2.Position = new float3(num3, num7, num4);
				}
				if (!flag4 && flag2 && flag8)
				{
					value3.Position = new float3(x, num7, z4);
					value4.Position = new float3(x, num6, z3);
				}
				else
				{
					value3.Position = new float3(x, num7, num4);
					value4.Position = new float3(x, num6, num4);
				}
			}
			xyz = math.back();
			break;
		case QuadGenerator.TileFace.BACK:
			if (!layerIgnoresVertexOffsets)
			{
				if (skewInTopVertices && !flag6)
				{
					value.Position = new float3(x, num6, z);
					value2.Position = new float3(x, num7, z2);
				}
				else
				{
					value.Position = new float3(x, num6, num5);
					value2.Position = new float3(x, num7, num5);
				}
				if (skewInTopVertices && !flag5)
				{
					value3.Position = new float3(num3, num7, z2);
					value4.Position = new float3(num3, num6, z);
				}
				else
				{
					value3.Position = new float3(num3, num7, num5);
					value4.Position = new float3(num3, num6, num5);
				}
			}
			else
			{
				if (!flag || (flag && flag3 && !flag5))
				{
					value3.Position = new float3(num3, num7, z2);
					value4.Position = new float3(num3, num6, z);
				}
				else
				{
					value3.Position = new float3(num3, num7, num5);
					value4.Position = new float3(num3, num6, num5);
				}
				if (!flag || (flag && flag4 && !flag6))
				{
					value.Position = new float3(x, num6, z);
					value2.Position = new float3(x, num7, z2);
				}
				else
				{
					value.Position = new float3(x, num6, num5);
					value2.Position = new float3(x, num7, num5);
				}
			}
			xyz = math.forward();
			break;
		case QuadGenerator.TileFace.LEFT:
			if (!layerIgnoresVertexOffsets)
			{
				if (!skewInTopVertices || flag || flag5)
				{
					value.Position = new float3(num3, num6, num5);
					value2.Position = new float3(num3, num7, num5);
				}
				else
				{
					value.Position = new float3(num3, num6, z);
					value2.Position = new float3(num3, num7, z2);
				}
				value3.Position = new float3(num3, num7, num4);
				value4.Position = new float3(num3, num6, num4);
			}
			else
			{
				if (!flag || (flag && flag3 && !flag5))
				{
					value.Position = new float3(num3, num6, z);
					value2.Position = new float3(num3, num7, z2);
				}
				else
				{
					value.Position = new float3(num3, num6, num5);
					value2.Position = new float3(num3, num7, num5);
				}
				if (!flag3 && flag2 && flag7)
				{
					value3.Position = new float3(num3, num7, z4);
					value4.Position = new float3(num3, num6, z3);
				}
				else
				{
					value3.Position = new float3(num3, num7, num4);
					value4.Position = new float3(num3, num6, num4);
				}
			}
			xyz = math.left();
			break;
		case QuadGenerator.TileFace.RIGHT:
			if (!layerIgnoresVertexOffsets)
			{
				value.Position = new float3(x, num6, num4);
				value2.Position = new float3(x, num7, num4);
				if (!skewInTopVertices || flag || flag6)
				{
					value3.Position = new float3(x, num7, num5);
					value4.Position = new float3(x, num6, num5);
				}
				else
				{
					value3.Position = new float3(x, num7, z2);
					value4.Position = new float3(x, num6, z);
				}
			}
			else
			{
				if (!flag || (flag && flag4 && !flag6))
				{
					value3.Position = new float3(x, num7, z2);
					value4.Position = new float3(x, num6, z);
				}
				else
				{
					value3.Position = new float3(x, num7, num5);
					value4.Position = new float3(x, num6, num5);
				}
				if (!flag4 && flag2 && flag8)
				{
					value.Position = new float3(x, num6, z3);
					value2.Position = new float3(x, num7, z4);
				}
				else
				{
					value.Position = new float3(x, num6, num4);
					value2.Position = new float3(x, num7, num4);
				}
			}
			xyz = math.right();
			break;
		}
		value.Normal = new float3(xyz);
		value2.Normal = new float3(xyz);
		value3.Normal = new float3(xyz);
		value4.Normal = new float3(xyz);
		vertexData[num] = value;
		vertexData[num + 1] = value2;
		vertexData[num + 2] = value3;
		vertexData[num + 3] = value4;
	}
}
