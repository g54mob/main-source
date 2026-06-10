using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public abstract class LODsControllerBase
	{
		[SerializeField]
		private bool constructed;

		public int ToOptimizeIndex = -1;

		[SerializeField]
		protected Optimizer_Base optimizer;

		public Component Component;

		public int Version;

		[SerializeField]
		[HideInInspector]
		protected bool lockFirstLOD = true;

		[SerializeField]
		[HideInInspector]
		private string editorHeader = "";

		[SerializeField]
		[HideInInspector]
		private bool drawProperties = true;

		private ILODInstance[] lockSupportCopy;

		public bool Constructed => constructed;

		public Optimizer_Base Optimizer => optimizer;

		public int LODLevelsCount => optimizer.LODLevels;

		public int CurrentLODLevel { get; protected set; }

		public ILODInstance ReferenceLOD
		{
			get
			{
				if (GetLODSettingsCount() > 0)
				{
					return GetLODSetting(0);
				}
				return null;
			}
		}

		public virtual ILODInstance InitialSettings { get; protected set; }

		public LODsControllerBase(Optimizer_Base sourceOptimizer, Component toOptimize, int index, string header = "")
		{
			ToOptimizeIndex = index;
			optimizer = sourceOptimizer;
			Component = toOptimize;
			constructed = true;
		}

		public abstract ILODInstance GetLODSetting(int lod);

		public abstract int GetLODSettingsCount();

		public virtual void OnStart()
		{
		}

		internal void SetCurrentLODLevel(int currentLODLevel)
		{
			CurrentLODLevel = currentLODLevel;
			if (currentLODLevel >= GetLODSettingsCount())
			{
				CurrentLODLevel = GetLODSettingsCount() - 1;
			}
		}

		internal abstract void ApplyLODLevelSettings(ILODInstance currentLOD);

		internal abstract ILODInstance GetCurrentLOD();

		internal abstract ILODInstance GetCullingLOD();

		internal abstract ILODInstance GetHiddenLOD();

		public bool IsTransitioningOrOther()
		{
			if (CurrentLODLevel >= 0 && CurrentLODLevel <= GetLODSettingsCount())
			{
				return false;
			}
			return true;
		}

		public void Editor_DrawValues(int selectedLOD = 0, int index = 0)
		{
		}

		protected virtual void Editor_MonoSimplyfy()
		{
		}

		protected virtual void Editor_ValuesChanged()
		{
		}

		public void GUI_HideProperties(bool hideThem)
		{
		}

		protected abstract void RefreshToOptimizeIndex();

		public void CheckComponentsCorrectness()
		{
			if (Component == null)
			{
				optimizer.RemoveToOptimize(this);
			}
		}

		protected virtual void GUI_LODSettingHeader(ILODInstance iflod, int selectedLOD)
		{
		}

		public void GenerateLODParameters(bool hard = false)
		{
			lockSupportCopy = null;
			if (NeedToReGenerate(optimizer.LODLevels) || hard)
			{
				GenerateNewLODSettings();
			}
			CheckAndGenerateLODParameters();
			CheckCoreRequirements();
			RefreshLODAutoParametersSettings();
		}

		public void StoreLODLockedSettings()
		{
			lockSupportCopy = new ILODInstance[GetIFLODList().Count];
			GetIFLODList().CopyTo(lockSupportCopy);
			for (int i = 0; i < lockSupportCopy.Length; i++)
			{
				if (lockSupportCopy[i].LockSettings)
				{
					Debug.Log("Store");
				}
			}
		}

		public void RestoreLODLockedSettings()
		{
			if (lockSupportCopy == null)
			{
				return;
			}
			for (int i = 0; i < GetIFLODList().Count && i < lockSupportCopy.Length; i++)
			{
				if (lockSupportCopy[i] != null && lockSupportCopy[i].LockSettings)
				{
					GetIFLODList()[i] = lockSupportCopy[i];
					GetIFLODList()[i].Disable = true;
					Debug.Log("reapplied " + i + " sett = " + lockSupportCopy[i].Disable);
				}
			}
		}

		protected abstract void CheckAndGenerateLODParameters();

		protected virtual bool NeedToReGenerate(int targetCount)
		{
			if (GetLODSettingsCount() != 0)
			{
				return GetLODSettingsCount() - 2 != targetCount;
			}
			return true;
		}

		protected void RefreshOptimizerLODCount()
		{
			if (GetLODSettingsCount() != 0)
			{
				optimizer.LODLevels = GetLODSettingsCount() - 2;
			}
		}

		protected abstract void GenerateNewLODSettings();

		protected virtual bool CheckCoreRequirements(bool hard = false)
		{
			return true;
		}

		protected virtual List<ILODInstance> GetIFLODList()
		{
			return null;
		}

		public void RefreshLODAutoParametersSettings(float lowerer = 1f)
		{
			string name = optimizer.name;
			name = name.Replace("PR_", "");
			name = name.Replace("PR.", "");
			name = name.Substring(0, Mathf.Min(5, name.Length)) + "[";
			string text = Component.GetType().ToString();
			text = text.Replace("FIMSpace.FOptimizing.", "");
			text = text.Replace("LOD_", "");
			text = text.Replace("FLOD_", "");
			text = text.Substring(0, Mathf.Min(6, text.Length)) + "]";
			string text2 = name + text;
			ILODInstance iLODInstance = GetIFLODList()[0];
			iLODInstance.DrawingVersion = Version;
			if (!iLODInstance.LockSettings)
			{
				iLODInstance.AssignSettingsAsForNearest(Component);
			}
			iLODInstance.QualityLowerer = lowerer;
			iLODInstance.Name = text2 + "Nearest";
			for (int i = 0; i < optimizer.LODLevels - 1; i++)
			{
				ILODInstance iLODInstance2 = GetIFLODList()[i + 1];
				iLODInstance2.DrawingVersion = Version;
				iLODInstance2.QualityLowerer = lowerer;
				if (!iLODInstance.LockSettings)
				{
					iLODInstance2.AssignAutoSettingsAsForLODLevel(i, optimizer.LODLevels, Component);
				}
				iLODInstance2.Name = text2 + "LOD" + (i + 1);
			}
			ILODInstance iLODInstance3 = GetIFLODList()[GetIFLODList().Count - 2];
			iLODInstance3.DrawingVersion = Version;
			iLODInstance3.QualityLowerer = lowerer;
			if (!iLODInstance.LockSettings)
			{
				iLODInstance3.AssignSettingsAsForCulled(Component);
			}
			iLODInstance3.Name = text2 + "Culled";
			ILODInstance iLODInstance4 = GetIFLODList()[GetIFLODList().Count - 1];
			iLODInstance4.DrawingVersion = Version;
			iLODInstance4.QualityLowerer = lowerer;
			if (!iLODInstance.LockSettings)
			{
				iLODInstance4.AssignAutoSettingsAsForLODLevel(optimizer.LODLevels - 2, optimizer.LODLevels, Component);
				iLODInstance4.AssignSettingsAsForHidden(Component);
			}
			iLODInstance4.Name = text2 + "Hidden";
		}

		public void AutoQualityLowerer(float lowerer = 1f)
		{
			GetIFLODList()[0].QualityLowerer = lowerer;
			if (!CheckCoreRequirements())
			{
				return;
			}
			ILODInstance iLODInstance;
			for (int i = 1; i < optimizer.LODLevels; i++)
			{
				iLODInstance = GetIFLODList()[i];
				iLODInstance.QualityLowerer = lowerer;
				if (!iLODInstance.LockSettings)
				{
					iLODInstance.AssignAutoSettingsAsForLODLevel(i - 1, optimizer.LODLevels, Component);
				}
			}
			iLODInstance = GetIFLODList()[GetIFLODList().Count - 1];
			iLODInstance.QualityLowerer = lowerer;
			if (!iLODInstance.LockSettings)
			{
				iLODInstance.AssignSettingsAsForHidden(Component);
				iLODInstance.AssignAutoSettingsAsForLODLevel(optimizer.LODLevels - 1, optimizer.LODLevels + 1, Component);
			}
		}
	}
}
