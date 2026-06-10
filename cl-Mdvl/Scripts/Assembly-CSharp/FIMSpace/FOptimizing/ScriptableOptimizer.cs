using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FIMSpace.FOptimizing
{
	[AddComponentMenu("FImpossible Creations/Optimizers 2/Scriptable Optimizer", 1)]
	public class ScriptableOptimizer : Optimizer_Base, IDropHandler, IEventSystemHandler, IFHierarchyIcon
	{
		[Tooltip("If scriptable files 'LOD sets' should be saved inside prefab file as sub-assets.\nThis is more comfortable but Unity have big trouble in good serving them this way so it's recommended to save scriptable files inside project directory to avoid any issues.\n\nWith this option disabled you will see 'Shared LOD Set' parameter when you unfold some component LOD settings and you can save LOD Set file with 'New' button.")]
		public bool SaveSetFilesInPrefab = true;

		public List<ScriptableLODsController> ToOptimize;

		public string EditorIconPath
		{
			get
			{
				if (PlayerPrefs.GetInt("OptH", 1) == 0)
				{
					return "";
				}
				return "FIMSpace/Optimizers 2/OptIconSmall";
			}
		}

		public void OnDrop(PointerEventData data)
		{
		}

		public override bool OptimizationListExists()
		{
			return ToOptimize != null;
		}

		protected override LODsControllerBase AddToOptimize(LODsControllerBase lod)
		{
			return null;
		}

		public override Component GetOptimizedComponent(int i)
		{
			if (i >= ToOptimize.Count)
			{
				return null;
			}
			return ToOptimize[i].Component;
		}

		internal override ILODInstance GetLODInstance(int i, int targetLODLevel)
		{
			if (i >= ToOptimize.Count)
			{
				return null;
			}
			if (targetLODLevel >= ToOptimize[i].LODSet.LevelOfDetailSets.Count)
			{
				return null;
			}
			return ToOptimize[i].LODSet.LevelOfDetailSets[targetLODLevel].GetLODInstance();
		}

		internal override void RemoveToOptimize(LODsControllerBase lODsControllerBase)
		{
			for (int num = ToOptimize.Count - 1; num >= 0; num--)
			{
				LODsControllerBase lODsControllerBase2 = ToOptimize[num];
				if (lODsControllerBase2 == null)
				{
					ToOptimize.RemoveAt(num);
				}
				else if (lODsControllerBase2 == lODsControllerBase)
				{
					ToOptimize.RemoveAt(num);
					break;
				}
			}
		}

		public ScrLOD_Base LoadLODReference(string resourcesPath)
		{
			ScrLOD_Base scrLOD_Base = Resources.Load<ScrLOD_Base>(resourcesPath);
			if (scrLOD_Base == null)
			{
				Debug.LogError("[OPTIMIZERS CRITICAL ERROR] There are no references for base LOD Types, you removed them from resources folder???");
			}
			return scrLOD_Base;
		}

		protected override void OptimizerReset()
		{
		}

		public override void SyncWithReferences()
		{
			if (ToOptimize.Count > 0 && ToOptimize[0].LODSet != null && ToOptimize[0].LODSet.LevelOfDetailSets != null && ToOptimize[0].LODSet.LevelOfDetailSets.Count > 0 && ToOptimize[0].LODSet.LevelOfDetailSets.Count - 2 != LODLevels)
			{
				LODLevels = ToOptimize[0].LODSet.LevelOfDetailSets.Count - 2;
				preLODLevels = LODLevels;
			}
		}

		protected override void OnValidateRefreshComponents()
		{
			if (ToOptimize != null)
			{
				RefreshToOptimizeList();
			}
			else
			{
				AssignComponentsToOptimizeFrom(base.gameObject.transform);
			}
		}

		protected override void OnValidateUpdateToOptimize(bool hard = false)
		{
			if (preLODLevels != LODLevels || hard)
			{
				ResetLODs(hard);
			}
			preLODLevels = LODLevels;
		}

		public override void CheckForNullsToOptimize()
		{
			if (ToOptimize == null)
			{
				return;
			}
			for (int num = ToOptimize.Count - 1; num >= 0; num--)
			{
				if (ToOptimize[num] == null)
				{
					ToOptimize.RemoveAt(num);
				}
				else if (ToOptimize[num].Component == null)
				{
					ToOptimize.RemoveAt(num);
				}
			}
		}

		public override void CleanAsset()
		{
		}

		protected override void ResetLODs(bool hard = false)
		{
		}

		public override void RemoveAllComponentsFromToOptimize()
		{
		}

		public override void RemoveFromToOptimizeAt(int i)
		{
		}

		protected override void RefreshInitialSettingsForOptimized()
		{
			RefreshDistances();
			for (int num = ToOptimize.Count - 1; num >= 0; num--)
			{
				if (ToOptimize == null)
				{
					ToOptimize.RemoveAt(num);
				}
				else
				{
					ToOptimize[num].OnStart();
				}
			}
			if (UseMultiShape)
			{
				AddToContainer = false;
				Debug.Log("Multi shape detection no container!");
			}
		}

		public override void AssignComponentsToOptimizeFrom(Component target, bool includeAdvanced = false)
		{
		}

		protected void TryAddLODControllerFor(ScrLOD_Base lod, Component target, List<Optimizer_Base> childOptims)
		{
		}

		public override void AssignCustomComponentToOptimize(MonoBehaviour target)
		{
		}

		public override bool ContainsComponent(Component component)
		{
			for (int num = ToOptimize.Count - 1; num >= 0; num--)
			{
				if (ToOptimize == null)
				{
					ToOptimize.RemoveAt(num);
				}
				else if (ToOptimize[num].Component == component)
				{
					return true;
				}
			}
			return false;
		}

		public override void RefreshToOptimizeList()
		{
			for (int num = ToOptimize.Count - 1; num >= 0; num--)
			{
				if (ToOptimize[num] == null)
				{
					ToOptimize.RemoveAt(num);
				}
			}
		}

		public override int GetToOptimizeCount()
		{
			if (ToOptimize == null)
			{
				return 0;
			}
			return ToOptimize.Count;
		}

		protected override void Start()
		{
			bool flag = false;
			for (int num = ToOptimize.Count - 1; num >= 0; num--)
			{
				if (ToOptimize[num].Component == null)
				{
					ToOptimize.RemoveAt(num);
					flag = true;
				}
			}
			if (flag)
			{
				Debug.LogWarning("[OPTIMIZERS] Optimizer had saved objects to optimize which are not existing anymore!");
			}
			base.Start();
		}

		public override void EditorUpdate()
		{
			base.EditorUpdate();
			if (ToOptimize == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < ToOptimize.Count; i++)
			{
				if (ToOptimize[i].LODSet == null)
				{
					ToOptimize[i].GenerateLODParameters();
					flag = true;
				}
			}
			if (flag)
			{
				Debug.LogWarning("[OPTIMIZERS EDITOR] LOD Settings generated from scratch for " + base.name + ". Did you copy and paste objects through scenes? Unity is not able to remember LOD settings for not prefabed objects and to objects without shared settings between scenes like that :/ \n(without prefabing or saving shared settings this settings are scene assets, no object assets)");
			}
		}

		protected override void AllLODComponents_ApplyCulledState()
		{
			for (int i = 0; i < ToOptimize.Count; i++)
			{
				ToOptimize[i].ApplyLODLevelSettings(ToOptimize[i].GetCullingLOD());
			}
		}

		protected override void AllLODComponents_ApplyCurrentState()
		{
			if (ToOptimize.Count != 0 && ToOptimize[0].CurrentLODLevel >= 0)
			{
				for (int i = 0; i < ToOptimize.Count; i++)
				{
					ToOptimize[i].ApplyLODLevelSettings(ToOptimize[i].GetCurrentLOD());
				}
			}
		}

		protected override void AllLODComponents_RefreshChoosedLODState(int lodLevel)
		{
			for (int i = 0; i < ToOptimize.Count; i++)
			{
				ToOptimize[i].SetCurrentLODLevel(lodLevel);
			}
		}

		protected override void AllLODComponents_ChangeChoosedLODState(int lodLevel)
		{
			for (int i = 0; i < ToOptimize.Count; i++)
			{
				ToOptimize[i].SetCurrentLODLevel(base.CurrentLODLevel);
				ToOptimize[i].ApplyLODLevelSettings(ToOptimize[i].GetCurrentLOD());
			}
		}

		internal override Optimizers_LODTransition GetLodTransitionFor(int i, int targetLODLevel)
		{
			return new Optimizers_LODTransition(ToOptimize[i].Component, ToOptimize[i].GetLODSetting(base.CurrentBackLODLevel), ToOptimize[i].GetLODSetting(targetLODLevel), ToOptimize[i].InitialSettings);
		}

		public override void RefreshLODSettings()
		{
			OnValidateUpdateToOptimize(hard: true);
		}
	}
}
