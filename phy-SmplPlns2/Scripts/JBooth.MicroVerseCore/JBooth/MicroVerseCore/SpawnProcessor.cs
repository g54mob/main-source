using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class SpawnProcessor
	{
		private List<ISpawner> spawners;

		private List<TreePrototypeSerializable> treePrototypes = new List<TreePrototypeSerializable>();

		private List<DetailPrototypeSerializable> detailPrototypes = new List<DetailPrototypeSerializable>();

		private Dictionary<Terrain, List<TreeJobHolder>> treeJobHolders = new Dictionary<Terrain, List<TreeJobHolder>>();

		private Dictionary<Terrain, List<DetailJobHolder>> detailJobHolders = new Dictionary<Terrain, List<DetailJobHolder>>();

		private List<Terrain> finishedTrees = new List<Terrain>();

		private List<Terrain> finishedDetails = new List<Terrain>();

		public static bool IsModifyingTerrain { get; private set; }

		public void Cancel(MicroVerse.DataCache dataCache)
		{
			CancelVegetationJobs(dataCache);
		}

		public void InitSystem()
		{
			IsModifyingTerrain = true;
			spawners = new List<ISpawner>(MicroVerse.instance.GetComponentsInChildren<ISpawner>());
			spawners.RemoveAll((ISpawner p) => !p.IsEnabled());
		}

		public void InitTerrain(Terrain terrain, MicroVerse.InvalidateType invalidateType, ref bool needCurvatureMap, ref bool needFlowMap)
		{
			Bounds bounds = TerrainUtil.ComputeTerrainBounds(terrain);
			foreach (ISpawner spawner in spawners)
			{
				ITreeModifier treeModifier = spawner as ITreeModifier;
				IDetailModifier detailModifier = spawner as IDetailModifier;
				if (treeModifier != null && treeModifier.IsEnabled())
				{
					if (bounds.Intersects(treeModifier.GetBounds()))
					{
						needCurvatureMap |= treeModifier.NeedCurvatureMap();
						needFlowMap |= treeModifier.NeedFlowMap();
					}
					treeModifier.InqTreePrototypes(treePrototypes);
				}
				if (detailModifier != null && bounds.Intersects(detailModifier.GetBounds()))
				{
					needCurvatureMap |= detailModifier.NeedCurvatureMap();
					detailModifier.InqDetailPrototypes(detailPrototypes);
				}
			}
			treePrototypes = treePrototypes.Distinct().ToList();
			detailPrototypes = detailPrototypes.Distinct().ToList();
			InitTerrainVegetation(terrain, treePrototypes, detailPrototypes);
			treePrototypes.Clear();
			detailPrototypes.Clear();
		}

		public void GenerateSpawnables(Terrain[] terrains, MicroVerse.DataCache dataCache)
		{
			bool allSDF = false;
			RenderVegetationClearLayers(terrains, dataCache);
			Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers = new Dictionary<Terrain, Dictionary<int, List<RenderTexture>>>();
			bool flag = false;
			bool flag2 = false;
			foreach (ISpawner spawner in spawners)
			{
				flag |= spawner.UsesOtherTreeSDF();
				flag2 |= spawner.UsesOtherObjectSDF();
			}
			foreach (ISpawner spawner2 in spawners)
			{
				ITreeModifier treeModifier = spawner2 as ITreeModifier;
				IDetailModifier detailModifier = spawner2 as IDetailModifier;
				if (treeModifier != null)
				{
					RenderTreeStamp(terrains, treeModifier, dataCache, allSDF, flag);
				}
				if (detailModifier != null)
				{
					RenderDetailStamp(terrains, detailModifier, dataCache, resultBuffers);
				}
			}
			FinishedRendereringVegetation(dataCache, resultBuffers);
		}

		public void CheckDone()
		{
			bool flag = true;
			if (treeJobHolders.Count > 0 || detailJobHolders.Count > 0)
			{
				flag = false;
			}
			if (flag)
			{
				IsModifyingTerrain = false;
			}
		}

		private void FinishedRendereringVegetation(MicroVerse.DataCache dataCache, Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers)
		{
			RenderTexture.active = null;
			foreach (TreeData value in dataCache.treeDatas.Values)
			{
				if (value.treeClearMap != null)
				{
					RenderTexture.ReleaseTemporary(value.treeClearMap);
					value.treeClearMap = null;
				}
			}
			foreach (DetailData value2 in dataCache.detailDatas.Values)
			{
				if (value2.clearMap != null)
				{
					RenderTexture.ReleaseTemporary(value2.clearMap);
					value2.clearMap = null;
				}
			}
			Material material = new Material(Shader.Find("Hidden/MicroVerse/CombineDetailBuffers"));
			foreach (Terrain key in resultBuffers.Keys)
			{
				Dictionary<int, List<RenderTexture>> dictionary = resultBuffers[key];
				foreach (int key2 in dictionary.Keys)
				{
					List<RenderTexture> list = dictionary[key2];
					if (list.Count > 1)
					{
						RenderTexture renderTexture = RenderTexture.GetTemporary(list[0].descriptor);
						RenderTexture renderTexture2 = RenderTexture.GetTemporary(list[0].descriptor);
						renderTexture.name = "MicroVerse::GenerateDetails";
						renderTexture2.name = "MicroVerse::GenerateDetails";
						Graphics.Blit(list[0], renderTexture);
						RenderTexture.ReleaseTemporary(list[0]);
						for (int i = 1; i < list.Count; i++)
						{
							RenderTexture renderTexture3 = list[i];
							material.SetTexture("_Merge", renderTexture3);
							Graphics.Blit(renderTexture, renderTexture2, material);
							RenderTexture.active = null;
							RenderTexture.ReleaseTemporary(renderTexture3);
							RenderTexture renderTexture4 = renderTexture2;
							RenderTexture renderTexture5 = renderTexture;
							renderTexture = renderTexture4;
							renderTexture2 = renderTexture5;
						}
						list.Clear();
						list.Add(renderTexture);
						RenderTexture.active = null;
						RenderTexture.ReleaseTemporary(renderTexture2);
					}
				}
				foreach (int key3 in dictionary.Keys)
				{
					List<RenderTexture> list2 = dictionary[key3];
					if (list2.Count != 1)
					{
						Debug.LogError("Detail channels have not been merged, memory will be leaked");
					}
					DetailJobHolder detailJobHolder = new DetailJobHolder();
					detailJobHolder.terrain = key;
					detailJobHolder.AddJob(list2[0], key3);
					if (detailJobHolders.ContainsKey(key))
					{
						detailJobHolders[key].Add(detailJobHolder);
						continue;
					}
					detailJobHolders.Add(key, new List<DetailJobHolder> { detailJobHolder });
				}
			}
			Object.DestroyImmediate(material);
		}

		private void RenderVegetationClearLayers(Terrain[] terrains, MicroVerse.DataCache dataCache)
		{
			bool flag = false;
			bool flag2 = false;
			foreach (ISpawner spawner in spawners)
			{
				ITreeModifier treeModifier = spawner as ITreeModifier;
				IDetailModifier detailModifier = spawner as IDetailModifier;
				if (treeModifier != null)
				{
					flag |= treeModifier.NeedTreeClear();
				}
				if (detailModifier != null)
				{
					flag2 |= detailModifier.NeedDetailClear();
				}
			}
			Terrain[] array = terrains;
			foreach (Terrain terrain in array)
			{
				Bounds bounds = TerrainUtil.ComputeTerrainBounds(terrain);
				_ = dataCache.indexMaps[terrain];
				_ = dataCache.weightMaps[terrain];
				RenderTexture height = dataCache.heightMaps[terrain];
				RenderTexture normal = dataCache.normalMaps[terrain];
				RenderTexture curve = dataCache.curvatureMaps[terrain];
				RenderTexture flow = dataCache.flowMaps[terrain];
				RenderTexture clearMap = null;
				RenderTexture clearMap2 = null;
				if (flag)
				{
					int alphamapResolution = terrain.terrainData.alphamapResolution;
					clearMap = (RenderTexture.active = RenderTexture.GetTemporary(alphamapResolution, alphamapResolution, 0, RenderTextureFormat.RG16, RenderTextureReadWrite.Linear));
					GL.Clear(clearDepth: false, clearColor: true, Color.clear);
					RenderTexture.active = null;
				}
				if (flag2)
				{
					int detailResolution = terrain.terrainData.detailResolution;
					clearMap2 = (RenderTexture.active = RenderTexture.GetTemporary(detailResolution, detailResolution, 0, RenderTextureFormat.RG16, RenderTextureReadWrite.Linear));
					GL.Clear(clearDepth: false, clearColor: true, Color.clear);
					RenderTexture.active = null;
				}
				TreeData treeData = new TreeData(terrain, height, normal, curve, flow, clearMap, dataCache);
				dataCache.treeDatas[terrain] = treeData;
				DetailData detailData = new DetailData(terrain, height, normal, curve, flow, clearMap2, dataCache);
				dataCache.detailDatas[terrain] = detailData;
				foreach (ISpawner spawner2 in spawners)
				{
					ITreeModifier treeModifier2 = spawner2 as ITreeModifier;
					IDetailModifier detailModifier2 = spawner2 as IDetailModifier;
					if (treeModifier2 != null && bounds.Intersects(treeModifier2.GetBounds()))
					{
						treeModifier2.ApplyTreeClear(treeData);
					}
					if (detailModifier2 != null && bounds.Intersects(detailModifier2.GetBounds()))
					{
						detailModifier2.ApplyDetailClear(detailData);
					}
				}
			}
			array = terrains;
			foreach (Terrain key in array)
			{
				if (dataCache.treeDatas.ContainsKey(key))
				{
					dataCache.treeDatas[key].layerIndex = -1;
				}
				if (dataCache.detailDatas.ContainsKey(key))
				{
					dataCache.detailDatas[key].layerIndex = -1;
				}
			}
		}

		private void RenderDetailStamp(Terrain[] terrains, IDetailModifier detailModifier, MicroVerse.DataCache dataCache, Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers)
		{
			foreach (Terrain terrain in terrains)
			{
				if (TerrainUtil.ComputeTerrainBounds(terrain).Intersects(detailModifier.GetBounds()))
				{
					DetailData dd = dataCache.detailDatas[terrain];
					OcclusionData od = dataCache.occlusionDatas[terrain];
					detailModifier.ApplyDetailStamp(dd, resultBuffers, od);
				}
			}
		}

		private void RenderTreeStamp(Terrain[] terrains, ITreeModifier treeModifier, MicroVerse.DataCache dataCache, bool allSDF, bool enableTreeSDF)
		{
			Terrain[] array = terrains;
			foreach (Terrain terrain in array)
			{
				if (TerrainUtil.ComputeTerrainBounds(terrain).Intersects(treeModifier.GetBounds()))
				{
					OcclusionData od = dataCache.occlusionDatas[terrain];
					TreeData vd = dataCache.treeDatas[terrain];
					treeModifier.ApplyTreeStamp(vd, treeJobHolders, od);
				}
			}
			bool flag = treeModifier.NeedToGenerateSDFForChilden();
			if (allSDF || treeModifier.NeedSDF() || flag || (treeModifier.OccludesOthers() && enableTreeSDF))
			{
				bool flag2 = treeModifier.OccludesOthers() && enableTreeSDF;
				array = terrains;
				foreach (Terrain terrain2 in array)
				{
					if (TerrainUtil.ComputeTerrainBounds(terrain2).Intersects(treeModifier.GetBounds()))
					{
						OcclusionData occlusionData = dataCache.occlusionDatas[terrain2];
						occlusionData?.RenderTreeSDF(terrain2, dataCache.occlusionDatas, flag2 || allSDF);
						if (flag && occlusionData != null && occlusionData.currentTreeSDF != null)
						{
							RenderTexture temporary = RenderTexture.GetTemporary(occlusionData.currentTreeSDF.descriptor);
							Graphics.Blit(occlusionData.currentTreeSDF, temporary);
							treeModifier.SetSDF(terrain2, temporary);
						}
					}
				}
			}
			array = terrains;
			foreach (Terrain terrain3 in array)
			{
				Bounds bounds = TerrainUtil.ComputeTerrainBounds(terrain3);
				OcclusionData od2 = dataCache.occlusionDatas[terrain3];
				if (dataCache.treeDatas.ContainsKey(terrain3) && bounds.Intersects(treeModifier.GetBounds()))
				{
					TreeData vd2 = dataCache.treeDatas[terrain3];
					treeModifier.ProcessTreeStamp(vd2, treeJobHolders, od2);
				}
			}
		}

		private void InitTerrainVegetation(Terrain terrain, List<TreePrototypeSerializable> treePrototypes, List<DetailPrototypeSerializable> detailPrototypes)
		{
			TreePrototype[] array = new TreePrototype[treePrototypes.Count];
			DetailPrototype[] array2 = new DetailPrototype[detailPrototypes.Count];
			for (int i = 0; i < treePrototypes.Count; i++)
			{
				array[i] = treePrototypes[i].GetPrototype();
			}
			for (int j = 0; j < detailPrototypes.Count; j++)
			{
				array2[j] = detailPrototypes[j].GetPrototype();
			}
			TreePrototype[] array3 = terrain.terrainData.treePrototypes;
			DetailPrototype[] array4 = terrain.terrainData.detailPrototypes;
			bool flag = false;
			bool flag2 = false;
			if (array3.Length != array.Length)
			{
				flag = true;
			}
			if (array4.Length != array2.Length)
			{
				flag2 = true;
			}
			if (!flag)
			{
				for (int k = 0; k < array.Length; k++)
				{
					if (!array[k].Equals(array3[k]))
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				for (int l = 0; l < array2.Length; l++)
				{
					if (!array2[l].Equals(array4[l]))
					{
						flag2 = true;
						break;
					}
					if (array2[l].positionJitter != array4[l].positionJitter || array2[l].alignToGround != array4[l].alignToGround)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (flag)
			{
				terrain.terrainData.SetTreeInstances(new TreeInstance[0], snapToHeightmap: false);
				terrain.terrainData.treePrototypes = array;
			}
			if (flag2)
			{
				terrain.terrainData.detailPrototypes = array2;
			}
		}

		private void CancelVegetationJobs(MicroVerse.DataCache dataCache)
		{
			foreach (List<TreeJobHolder> value in treeJobHolders.Values)
			{
				foreach (TreeJobHolder item in value)
				{
					item.canceled = true;
				}
			}
			foreach (List<DetailJobHolder> value2 in detailJobHolders.Values)
			{
				foreach (DetailJobHolder item2 in value2)
				{
					item2.canceled = true;
				}
			}
			if (dataCache == null)
			{
				return;
			}
			foreach (TreeData value3 in dataCache.treeDatas.Values)
			{
				if (value3.treeClearMap != null)
				{
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(value3.treeClearMap);
					value3.treeClearMap = null;
				}
			}
			foreach (DetailData value4 in dataCache.detailDatas.Values)
			{
				if (value4.clearMap != null)
				{
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(value4.clearMap);
					value4.clearMap = null;
				}
			}
		}

		public void ApplyTrees()
		{
			finishedTrees.Clear();
			foreach (List<TreeJobHolder> value in treeJobHolders.Values)
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (value[i].canceled && value[i].IsDone())
					{
						value[i].Dispose();
						value.RemoveAt(i);
						i--;
					}
				}
			}
			foreach (Terrain key in treeJobHolders.Keys)
			{
				List<TreeJobHolder> list = treeJobHolders[key];
				bool flag = true;
				foreach (TreeJobHolder item in list)
				{
					if (!item.IsDone())
					{
						flag = false;
						break;
					}
				}
				if (list.Count == 0)
				{
					finishedTrees.Add(key);
				}
				if (!flag || list.Count <= 0)
				{
					continue;
				}
				int num = 0;
				foreach (TreeJobHolder item2 in list)
				{
					item2.handle.Complete();
					num += item2.job.count[0];
				}
				NativeArray<TreeInstance> dst = new NativeArray<TreeInstance>(num, Allocator.Temp);
				int num2 = 0;
				foreach (TreeJobHolder item3 in list)
				{
					if (item3.job.count[0] > 0)
					{
						NativeArray<TreeInstance>.Copy(item3.job.trees.GetSubArray(0, item3.job.count[0]), 0, dst, num2, item3.job.count[0]);
						num2 += item3.job.count[0];
					}
					item3.Dispose();
				}
				list.Clear();
				TreeInstance[] array = new TreeInstance[num];
				dst.CopyTo(array);
				key.terrainData.SetTreeInstances(array, snapToHeightmap: false);
				dst.Dispose();
				finishedTrees.Add(key);
			}
			foreach (Terrain finishedTree in finishedTrees)
			{
				treeJobHolders.Remove(finishedTree);
			}
			finishedTrees.Clear();
		}

		public void ApplyDetails()
		{
			foreach (List<DetailJobHolder> value in detailJobHolders.Values)
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (value[i].canceled && value[i].IsDone())
					{
						value[i].Dispose();
						value.RemoveAt(i);
						i--;
					}
				}
			}
			finishedDetails.Clear();
			foreach (Terrain key in detailJobHolders.Keys)
			{
				List<DetailJobHolder> list = detailJobHolders[key];
				bool flag = true;
				foreach (DetailJobHolder item in list)
				{
					if (!item.IsDone())
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					finishedDetails.Add(key);
				}
			}
			foreach (Terrain finishedDetail in finishedDetails)
			{
				detailJobHolders.Remove(finishedDetail);
			}
			finishedDetails.Clear();
		}
	}
}
