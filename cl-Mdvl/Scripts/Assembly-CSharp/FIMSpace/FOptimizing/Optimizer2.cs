using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FIMSpace.FOptimizing
{
	[AddComponentMenu("FImpossible Creations/Optimizer 2 (v2019.4+)", 0)]
	public class Optimizer2 : Optimizer_Base, IDropHandler, IEventSystemHandler, IFHierarchyIcon
	{
		[HideInInspector]
		public Optimizer2020Selector OptimizationTypes;

		public List<Optimizer2020LODsController> ToOptimize;

		public string EditorIconPath
		{
			get
			{
				if (PlayerPrefs.GetInt("OptH", 1) == 0)
				{
					return "";
				}
				return "FIMSpace/Optimizers 2/OptEsIconSmall";
			}
		}

		public void OnDrop(PointerEventData data)
		{
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
			if (targetLODLevel >= ToOptimize[i].GetLODSettingsCount())
			{
				return null;
			}
			return ToOptimize[i].GetLODSetting(targetLODLevel);
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

		public override bool OptimizationListExists()
		{
			return ToOptimize != null;
		}

		protected override void OptimizerReset()
		{
		}

		public override void SyncWithReferences()
		{
			if (ToOptimize.Count > 0 && ToOptimize[0].Component != null && ToOptimize[0].GetLODSettingsCount() - 2 != LODLevels)
			{
				LODLevels = ToOptimize[0].GetLODSettingsCount() - 2;
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
			}
		}

		protected override void ResetLODs(bool hard = false)
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
		}

		public override void AssignComponentsToOptimizeFrom(Component target, bool includeAdvanced = false)
		{
		}

		public override void AssignCustomComponentToOptimize(MonoBehaviour target)
		{
			if (ToOptimize == null)
			{
				ToOptimize = new List<Optimizer2020LODsController>();
			}
			List<Optimizer_Base> childOptimizers = Optimizer_Base.FindComponentsInAllChildren<Optimizer_Base>(base.transform);
			manager = OptimizersManager.Instance;
			manager = null;
			Component[] components = target.GetComponents<Component>();
			for (int i = 0; i < components.Length; i++)
			{
				if (LODInstanceGenerator.GenerateInstanceOutOf(this, components[i], deepSearch: true, LODInstanceGenerator.ESearchMode.JustCustomComponents) != null)
				{
					AddToOptimizeIfCan(components[i], childOptimizers);
				}
			}
		}

		public void AddToOptimizeIfCan(Component target, List<Optimizer_Base> childOptimizers)
		{
		}

		public override void RemoveFromToOptimizeAt(int i)
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
			for (int i = 0; i < ToOptimize.Count; i++)
			{
				if (ToOptimize[i].GetLODSettingsCount() == 0)
				{
					ToOptimize[i].GenerateLODParameters();
				}
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
			if (ToOptimize.Count == 0 || ToOptimize[0].CurrentLODLevel < 0)
			{
				return;
			}
			for (int i = 0; i < ToOptimize.Count; i++)
			{
				if (ToOptimize[i] != null)
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
				if (ToOptimize[i] != null)
				{
					ToOptimize[i].SetCurrentLODLevel(base.CurrentLODLevel);
					ToOptimize[i].ApplyLODLevelSettings(ToOptimize[i].GetCurrentLOD());
				}
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
