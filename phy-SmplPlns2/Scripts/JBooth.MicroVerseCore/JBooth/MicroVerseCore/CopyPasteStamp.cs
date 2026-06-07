using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace JBooth.MicroVerseCore
{
	public class CopyPasteStamp : Stamp, IHeightModifier, IModifier, ITextureModifier, IHoleModifier, ITreeModifier, ISpawner, IDetailModifier
	{
		public CopyStamp stamp;

		public bool copyHeights = true;

		public bool copyTexturing = true;

		public bool copyTrees = true;

		public bool copyDetails = true;

		public bool copyHoles = true;

		public bool applyHeights = true;

		public bool applyTexturing = true;

		public bool applyTrees;

		public bool applyDetails;

		public bool applyHoles;

		[Tooltip("When true, the stamp scale is aligned to pixel sizes, providing a precise copy instead of interpolating the data between pixels. You may want to turn this off if you are scaling/rotating a copy paste stamp")]
		public bool pixelQuantization = true;

		private Material splatPaste;

		private RenderBuffer[] _mrt;

		private float[] channels = new float[32];

		[SerializeField]
		private int version;

		private static Shader pasteStampShader = null;

		private static int _ClearLayer = Shader.PropertyToID("_ClearLayer");

		private static int _ClearMask = Shader.PropertyToID("_ClearMask");

		private static Shader treePasteShader = null;

		private static Shader detailPasteShader = null;

		public HeightStamp heightStamp { get; private set; }

		private static float FindClosestDivisible(float inputValue, float increment)
		{
			float num = Mathf.Floor(inputValue / increment) * increment;
			float num2 = Mathf.Ceil(inputValue / increment) * increment;
			float num3 = Mathf.Abs(inputValue - num);
			float num4 = Mathf.Abs(inputValue - num2);
			if (num3 < num4)
			{
				return num;
			}
			return num2;
		}

		public static void SetTerrainScale(Transform stamp, Terrain t, int textureSize)
		{
			Vector3 localScale = stamp.transform.localScale;
			localScale.x = FindClosestDivisible(localScale.x, t.terrainData.size.x / (float)textureSize);
			localScale.z = FindClosestDivisible(localScale.z, t.terrainData.size.z / (float)textureSize);
			if (stamp.transform.localScale != localScale)
			{
				stamp.transform.localScale = localScale;
			}
		}

		public override void OnEnable()
		{
			if (heightStamp == null)
			{
				heightStamp = GetComponent<HeightStamp>();
			}
			if (heightStamp == null)
			{
				heightStamp = base.gameObject.AddComponent<HeightStamp>();
				heightStamp.falloff.filterType = FalloffFilter.FilterType.Box;
				heightStamp.mode = HeightStamp.CombineMode.Max;
				heightStamp.enabled = false;
			}
			heightStamp.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
			if (stamp != null)
			{
				if (version == 0 && heightStamp.mode == HeightStamp.CombineMode.Max)
				{
					Vector3 position = base.transform.position;
					position.y = 0f;
					base.transform.position = position;
				}
				else if (version == 1 && heightStamp.mode != HeightStamp.CombineMode.Override && heightStamp.mode != HeightStamp.CombineMode.Max)
				{
					Vector3 position2 = base.transform.position;
					position2.y = 0f;
					base.transform.position = position2;
				}
			}
			version = 2;
			base.OnEnable();
		}

		public override void OnDisable()
		{
			if (stamp != null)
			{
				base.OnDisable();
			}
		}

		public bool NeedTreeClear()
		{
			return false;
		}

		public void ApplyTreeClear(TreeData td)
		{
		}

		public bool NeedDetailClear()
		{
			return false;
		}

		public void ApplyDetailClear(DetailData td)
		{
		}

		public bool UsesOtherTreeSDF()
		{
			return false;
		}

		public bool UsesOtherObjectSDF()
		{
			return false;
		}

		public void Initialize()
		{
			if (stamp != null)
			{
				if (pasteStampShader == null)
				{
					pasteStampShader = Shader.Find("Hidden/MicroVerse/PasteSplat");
				}
				stamp.Unpack();
				if (heightStamp != null)
				{
					heightStamp.stamp = stamp.heightMap;
				}
				splatPaste = new Material(pasteStampShader);
				_mrt = new RenderBuffer[2];
			}
			if (heightStamp != null)
			{
				heightStamp.Initialize();
			}
		}

		public bool ApplyHeightStamp(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od)
		{
			if (stamp != null && applyHeights)
			{
				Vector3 localScale = base.transform.localScale;
				if (pixelQuantization)
				{
					SetTerrainScale(base.transform, heightmapData.terrain, dest.width);
				}
				stamp.heightMap.filterMode = ((!pixelQuantization) ? FilterMode.Bilinear : FilterMode.Point);
				stamp.heightMap.wrapMode = TextureWrapMode.Clamp;
				bool result = heightStamp.ApplyHeightStampAbsolute(source, dest, heightmapData, od, stamp.heightRenorm);
				if (localScale != base.transform.localScale)
				{
					base.transform.localScale = localScale;
				}
				return result;
			}
			return false;
		}

		public bool IsValidHoleStamp()
		{
			if (stamp != null && applyHoles && stamp.holeData != null)
			{
				return stamp.holeMap != null;
			}
			return false;
		}

		public void ApplyHoleStamp(RenderTexture src, RenderTexture dest, HoleData holeData, OcclusionData od)
		{
			if (IsValidHoleStamp())
			{
				Vector3 localScale = base.transform.localScale;
				if (pixelQuantization)
				{
					SetTerrainScale(base.transform, holeData.terrain, dest.width);
				}
				Material material = new Material(Shader.Find("Hidden/MicroVerse/HoleStamp"));
				keywordBuilder.Clear();
				keywordBuilder.Add("_COPYPASTE");
				heightStamp.falloff.PrepareMaterial(splatPaste, base.transform, keywordBuilder.keywords);
				keywordBuilder.Assign(material);
				material.SetMatrix("_Transform", TerrainUtil.ComputeStampMatrix(holeData.terrain, base.transform));
				material.SetTexture("_PasteTex", stamp.holeMap);
				Graphics.Blit(src, dest, material);
				Object.DestroyImmediate(material);
				base.transform.localScale = localScale;
			}
			else
			{
				RenderTexture.active = dest;
				GL.Clear(clearDepth: false, clearColor: true, Color.white);
				RenderTexture.active = null;
			}
		}

		public bool ApplyTextureStamp(RenderTexture indexSrc, RenderTexture indexDest, RenderTexture weightSrc, RenderTexture weightDest, TextureData splatmapData, OcclusionData od)
		{
			if (applyTexturing && stamp != null && stamp.layers != null && stamp.layers.Length != 0 && stamp.indexMap != null && stamp.weightMap != null)
			{
				Vector3 localScale = base.transform.localScale;
				if (pixelQuantization)
				{
					SetTerrainScale(base.transform, splatmapData.terrain, indexSrc.width);
				}
				Terrain terrain = splatmapData.terrain;
				int num = stamp.layers.Length;
				if (num > 32)
				{
					Debug.LogError("Greater than 32 textures on the terrain! Will not be able to preserve area");
					num = 32;
				}
				for (int i = 0; i < num; i++)
				{
					channels[i] = TerrainUtil.FindTextureChannelIndex(terrain, stamp.layers[i]);
				}
				splatPaste.SetFloatArray("_Channels", channels);
				splatPaste.SetTexture("_OrigWeightMap", weightSrc);
				splatPaste.SetTexture("_OrigIndexMap", indexSrc);
				splatPaste.SetTexture("_WeightMap", stamp.weightMap);
				splatPaste.SetTexture("_IndexMap", stamp.indexMap);
				splatPaste.SetTexture("_PlacementMask", od.terrainMask);
				keywordBuilder.Clear();
				heightStamp.falloff.PrepareMaterial(splatPaste, base.transform, keywordBuilder.keywords);
				keywordBuilder.Assign(splatPaste);
				splatPaste.SetMatrix("_Transform", TerrainUtil.ComputeStampMatrix(terrain, base.transform));
				_mrt[0] = indexDest.colorBuffer;
				_mrt[1] = weightDest.colorBuffer;
				Graphics.SetRenderTarget(_mrt, indexDest.depthBuffer);
				Graphics.Blit(null, splatPaste, 0);
				base.transform.localScale = localScale;
				return true;
			}
			return false;
		}

		public bool NeedSDF()
		{
			return false;
		}

		public bool NeedParentSDF()
		{
			return false;
		}

		public bool NeedToGenerateSDFForChilden()
		{
			return false;
		}

		public void SetSDF(Terrain t, RenderTexture rt)
		{
		}

		public RenderTexture GetSDF(Terrain t)
		{
			return null;
		}

		public void ApplyTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
			if (applyTrees && stamp != null && stamp.treeData != null && stamp.treeData.prototypes != null && stamp.treeData.prototypes.Length != 0 && stamp.treeData.randomsTex != null && stamp.treeData.positonsTex != null)
			{
				float[] array = new float[stamp.treeData.prototypes.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = TerrainUtil.FindTreeIndex(vd.terrain, stamp.treeData.prototypes[i].prefab);
				}
				keywordBuilder.Clear();
				if (treePasteShader == null)
				{
					treePasteShader = Shader.Find("Hidden/MicroVerse/TreePasteStamp");
				}
				Material material = new Material(treePasteShader);
				material.SetTexture("_TreePos", stamp.treeData.positonsTex);
				material.SetTexture("_TreeRand", stamp.treeData.randomsTex);
				material.SetFloatArray("_Indexes", array);
				material.SetTexture("_Heightmap", vd.heightMap);
				material.SetTexture("_PlacementMask", od.terrainMask);
				heightStamp.falloff.PrepareMaterial(material, base.transform, keywordBuilder.keywords);
				TerrainData terrainData = vd.terrain.terrainData;
				material.SetMatrix("_Transform", TerrainUtil.ComputeStampMatrix(vd.terrain, base.transform));
				material.SetVector("_RealSize", TerrainUtil.ComputeTerrainSize(vd.terrain));
				material.SetFloat(_ClearLayer, vd.layerIndex);
				material.SetTexture(_ClearMask, vd.treeClearMap);
				material.SetMatrix("_StampTransform", base.transform.localToWorldMatrix);
				material.SetMatrix("_TerrainTransform", vd.terrain.transform.worldToLocalMatrix);
				float value = 1f;
				if (terrainData.size.y > terrainData.size.x)
				{
					value = terrainData.size.y / terrainData.size.x;
				}
				material.SetFloat("_ScaleR", value);
				keywordBuilder.Assign(material);
				RenderTexture renderTexture = new RenderTexture(stamp.treeData.dataSize.x, stamp.treeData.dataSize.y, 0, RenderTextureFormat.ARGBHalf);
				RenderTexture renderTexture2 = new RenderTexture(stamp.treeData.dataSize.x, stamp.treeData.dataSize.y, 0, RenderTextureFormat.ARGBHalf);
				_mrt[0] = renderTexture.colorBuffer;
				_mrt[1] = renderTexture2.colorBuffer;
				Graphics.SetRenderTarget(_mrt, renderTexture.depthBuffer);
				Graphics.Blit(null, material, 0);
				TreeUtil.ApplyOcclusion(renderTexture, od, others: true, selfSDF: false);
				TreeJobHolder treeJobHolder = new TreeJobHolder();
				NativeArray<int> treeIndexes = new NativeArray<int>(array.Length, Allocator.Persistent);
				for (int j = 0; j < array.Length; j++)
				{
					treeIndexes[j] = (int)array[j];
				}
				treeJobHolder.AddJob(renderTexture, renderTexture2, treeIndexes);
				if (jobs.ContainsKey(vd.terrain))
				{
					jobs[vd.terrain].Add(treeJobHolder);
					return;
				}
				jobs.Add(vd.terrain, new List<TreeJobHolder> { treeJobHolder });
			}
		}

		public void ProcessTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od)
		{
		}

		public void ApplyDetailStamp(DetailData dd, Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers, OcclusionData od)
		{
			if (!applyDetails || !(stamp != null) || stamp.detailData == null || stamp.detailData.layers == null)
			{
				return;
			}
			foreach (CopyStamp.DetailCopyData.Layer layer in stamp.detailData.layers)
			{
				if (layer.prototype.IsValid())
				{
					int key = VegetationUtilities.FindDetailIndex(od.terrain, layer.prototype);
					keywordBuilder.Clear();
					if (detailPasteShader == null)
					{
						detailPasteShader = Shader.Find("Hidden/MicroVerse/DetailPasteStamp");
					}
					Material material = new Material(detailPasteShader);
					material.SetFloat("_Weight", 1f);
					material.SetTexture(_ClearMask, dd.clearMap);
					material.SetFloat(_ClearLayer, dd.layerIndex);
					material.SetTexture("_PlacementMask", od.terrainMask);
					heightStamp.falloff.PrepareMaterial(material, base.transform, keywordBuilder.keywords);
					_ = dd.terrain.terrainData;
					material.SetMatrix("_Transform", TerrainUtil.ComputeStampMatrix(dd.terrain, base.transform));
					RenderTexture temporary = RenderTexture.GetTemporary(dd.terrain.terrainData.detailWidth, dd.terrain.terrainData.detailHeight, 0, GraphicsFormat.R8_UNorm);
					temporary.name = "DetailStamp::rt";
					keywordBuilder.Assign(material);
					Graphics.Blit(layer.texture, temporary, material);
					if (!resultBuffers.ContainsKey(dd.terrain))
					{
						resultBuffers.Add(dd.terrain, new Dictionary<int, List<RenderTexture>>());
					}
					Dictionary<int, List<RenderTexture>> dictionary = resultBuffers[dd.terrain];
					if (dictionary.ContainsKey(key))
					{
						dictionary[key].Add(temporary);
						continue;
					}
					dictionary.Add(key, new List<RenderTexture>(1) { temporary });
				}
			}
		}

		public void InqDetailPrototypes(List<DetailPrototypeSerializable> prototypes)
		{
			if (!applyDetails || !(stamp != null) || stamp.detailData == null || stamp.detailData.layers == null)
			{
				return;
			}
			foreach (CopyStamp.DetailCopyData.Layer layer in stamp.detailData.layers)
			{
				if (layer.prototype != null && (layer.prototype.prototype != null || layer.prototype.prototypeTexture != null) && !prototypes.Contains(layer.prototype))
				{
					prototypes.Add(layer.prototype);
				}
			}
		}

		public void InqTreePrototypes(List<TreePrototypeSerializable> prototypes)
		{
			if (applyTrees && stamp != null && stamp.treeData != null && stamp.treeData.prototypes != null && stamp.treeData.prototypes.Length != 0)
			{
				prototypes.AddRange(stamp.treeData.prototypes);
			}
		}

		public bool OccludesOthers()
		{
			return true;
		}

		public void InqTerrainLayers(Terrain terrain, List<TerrainLayer> prototypes)
		{
			if (!applyTexturing || !(stamp != null) || stamp.layers == null || !(stamp.indexMap != null) || !(stamp.weightMap != null) || !TerrainUtil.ComputeTerrainBounds(terrain).Intersects(GetBounds()))
			{
				return;
			}
			TerrainLayer[] layers = stamp.layers;
			for (int i = 0; i < layers.Length; i++)
			{
				if (layers[i] != null)
				{
					prototypes.AddRange(stamp.layers);
				}
			}
		}

		public bool NeedCurvatureMap()
		{
			return false;
		}

		public bool NeedFlowMap()
		{
			return false;
		}

		public void Dispose()
		{
			if (heightStamp != null)
			{
				heightStamp.Dispose();
			}
			Object.DestroyImmediate(splatPaste);
			_mrt = null;
		}

		public override Bounds GetBounds()
		{
			if (heightStamp != null && heightStamp.falloff.filterType == FalloffFilter.FilterType.SplineArea && heightStamp.falloff.splineArea != null)
			{
				return heightStamp.falloff.splineArea.GetBounds();
			}
			if (heightStamp != null && heightStamp.falloff.paintArea != null && heightStamp.falloff.paintArea.clampOutsideOfBounds)
			{
				return heightStamp.falloff.paintArea.GetBounds();
			}
			return TerrainUtil.GetBounds(base.transform);
		}

		private void OnDrawGizmosSelected()
		{
			if (MicroVerse.instance != null && heightStamp.falloff.filterType != FalloffFilter.FilterType.Global && heightStamp.falloff.filterType != FalloffFilter.FilterType.SplineArea)
			{
				Gizmos.color = MicroVerse.instance.options.colors.copyStampColor;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				Gizmos.DrawWireCube(new Vector3(0f, 0.5f, 0f), Vector3.one);
			}
		}
	}
}
