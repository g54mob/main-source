using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public class Optimizer2020LODsController : LODsControllerBase
	{
		[SerializeReference]
		public List<Component> ToOptimizes = new List<Component>();

		[SerializeReference]
		public Component ToOptimize;

		[SerializeReference]
		public ILODInstance LODInitial;

		[SerializeReference]
		public List<ILODInstance> LODInstances = new List<ILODInstance>();

		[SerializeField]
		private Optimizer2 eOptimizer;

		public override ILODInstance InitialSettings
		{
			get
			{
				return LODInitial;
			}
			protected set
			{
				LODInitial = value;
			}
		}

		protected override List<ILODInstance> GetIFLODList()
		{
			return LODInstances;
		}

		public Optimizer2020LODsController(Optimizer_Base sourceOptimizer, Component toOptimize, int index, string header = "")
			: base(sourceOptimizer, toOptimize, index, header)
		{
			eOptimizer = sourceOptimizer as Optimizer2;
			ToOptimize = toOptimize;
		}

		public override void OnStart()
		{
			if (InitialSettings == null)
			{
				GenerateInitialSettings();
			}
			InitialSettings.SetSameValuesAsComponent(Component);
		}

		protected override void RefreshToOptimizeIndex()
		{
			for (int i = 0; i < eOptimizer.ToOptimize.Count; i++)
			{
				if (eOptimizer.ToOptimize[i] == this)
				{
					ToOptimizeIndex = i;
					break;
				}
			}
		}

		internal override ILODInstance GetCurrentLOD()
		{
			return GetIFLODList()[base.CurrentLODLevel];
		}

		internal override ILODInstance GetCullingLOD()
		{
			return GetIFLODList()[GetIFLODList().Count - 2];
		}

		internal override ILODInstance GetHiddenLOD()
		{
			return GetIFLODList()[GetIFLODList().Count - 1];
		}

		protected override void GenerateNewLODSettings()
		{
			if (ToOptimize == null)
			{
				Debug.Log("[Optimizers] Unknown to optimize component!");
			}
			else
			{
				LODInstances = new List<ILODInstance>();
			}
		}

		private void GenerateInitialSettings()
		{
			LODInitial = GenerateInstance();
		}

		private ILODInstance GenerateInstance()
		{
			return LODInstanceGenerator.GenerateInstanceOutOf(eOptimizer, ToOptimize);
		}

		protected override void CheckAndGenerateLODParameters()
		{
			if (GetLODSettingsCount() != optimizer.LODLevels + 2)
			{
				for (int i = 0; i < optimizer.LODLevels + 2; i++)
				{
					LODInstances.Add(GenerateInstance());
				}
			}
			RefreshOptimizerLODCount();
		}

		internal override void ApplyLODLevelSettings(ILODInstance currentLOD)
		{
			if (currentLOD != null)
			{
				base.CurrentLODLevel = currentLOD.Index;
				if (IsTransitioningOrOther())
				{
					base.CurrentLODLevel = -1;
				}
				currentLOD.ApplySettingsToTheComponent(Component, InitialSettings);
			}
		}

		public void OnValidate()
		{
		}

		public void SetFromEssential(EssentialLODsController ess)
		{
			List<ILODInstance> iFLODsForOptimizer = ess.GetIFLODsForOptimizer2();
			if (iFLODsForOptimizer.Count == LODInstances.Count && iFLODsForOptimizer.Count > 0 && !(iFLODsForOptimizer[0].GetType() != LODInstances[0].GetType()))
			{
				for (int i = 0; i < LODInstances.Count; i++)
				{
					LODInstances[i] = iFLODsForOptimizer[i].GetCopy();
				}
			}
		}

		public override ILODInstance GetLODSetting(int lod)
		{
			return LODInstances[lod];
		}

		public override int GetLODSettingsCount()
		{
			return LODInstances.Count;
		}
	}
}
