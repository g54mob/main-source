using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public class ScriptableLODsController : LODsControllerBase
	{
		public ScrOptimizer_LODSettings LODSet;

		[SerializeField]
		private ScrOptimizer_LODSettings sharedLODSet;

		[SerializeField]
		private ScrOptimizer_LODSettings uniqueLODSet;

		[SerializeField]
		private ScriptableOptimizer sOptimizer;

		[HideInInspector]
		public ScrLOD_Base RootReference;

		[SerializeField]
		[HideInInspector]
		private ILODInstance initialSettings;

		[HideInInspector]
		public bool UsingShared;

		private List<ILODInstance> _iflod;

		public int nullTry;

		public static string pathTo = "";

		public ScriptableOptimizer GetOptimizer => sOptimizer;

		public override ILODInstance InitialSettings
		{
			get
			{
				return initialSettings;
			}
			protected set
			{
				initialSettings = value;
			}
		}

		public ScrOptimizer_LODSettings GetSharedSet()
		{
			return sharedLODSet;
		}

		public ScrOptimizer_LODSettings GetUniqueSet()
		{
			return uniqueLODSet;
		}

		public ScriptableLODsController(Optimizer_Base sourceOptimizer, Component toOptimize, int index, string header = "", ScrLOD_Base rootReference = null)
			: base(sourceOptimizer, toOptimize, index, header)
		{
			sOptimizer = sourceOptimizer as ScriptableOptimizer;
			RootReference = rootReference;
		}

		public override ILODInstance GetLODSetting(int i)
		{
			if (LODSet == null)
			{
				GenerateLODParameters();
			}
			else if (LODSet.LevelOfDetailSets == null)
			{
				GenerateLODParameters();
			}
			return LODSet.LevelOfDetailSets[i].GetLODInstance();
		}

		public override int GetLODSettingsCount()
		{
			return LODSet.LevelOfDetailSets.Count;
		}

		public override void OnStart()
		{
			if ((bool)RootReference)
			{
				if (InitialSettings == null)
				{
					InitialSettings = RootReference.GetScrLODInstance().GetLODInstance();
				}
				InitialSettings.SetSameValuesAsComponent(Component);
			}
		}

		internal override void ApplyLODLevelSettings(ILODInstance currentLOD)
		{
			if (currentLOD == null)
			{
				if (RootReference == null)
				{
					Debug.LogError("[OPTIMIZERS] CRITICAL ERROR: There is no root reference in Optimizer's LOD Controller! (" + optimizer?.ToString() + ") Try adding Optimizers Manager again to the scene or import newest version from the Asset Store!");
				}
				Debug.LogError("[OPTIMIZERS] Target LOD is NULL! (" + optimizer.name + " - " + RootReference.name + ")");
			}
			else
			{
				base.CurrentLODLevel = currentLOD.Index;
				if (IsTransitioningOrOther())
				{
					base.CurrentLODLevel = -1;
				}
				currentLOD.ApplySettingsToTheComponent(Component, InitialSettings);
			}
		}

		protected override void RefreshToOptimizeIndex()
		{
			for (int i = 0; i < sOptimizer.ToOptimize.Count; i++)
			{
				if (sOptimizer.ToOptimize[i] == this)
				{
					ToOptimizeIndex = i;
					break;
				}
			}
		}

		internal override ILODInstance GetCurrentLOD()
		{
			return LODSet.LevelOfDetailSets[base.CurrentLODLevel].GetLODInstance();
		}

		internal override ILODInstance GetCullingLOD()
		{
			return LODSet.LevelOfDetailSets[LODSet.LevelOfDetailSets.Count - 2].GetLODInstance();
		}

		internal override ILODInstance GetHiddenLOD()
		{
			return LODSet.LevelOfDetailSets[LODSet.LevelOfDetailSets.Count - 1].GetLODInstance();
		}

		protected override List<ILODInstance> GetIFLODList()
		{
			if (_iflod == null || _iflod.Count != GetLODSettingsCount())
			{
				_iflod = new List<ILODInstance>();
				for (int i = 0; i < LODSet.LevelOfDetailSets.Count; i++)
				{
					_iflod.Add(LODSet.LevelOfDetailSets[i].GetLODInstance());
				}
			}
			return _iflod;
		}

		protected override void Editor_MonoSimplyfy()
		{
		}

		protected override bool CheckCoreRequirements(bool hard = false)
		{
			if (!RootReference)
			{
				if (!hard)
				{
					Debug.LogError("[OPTIMIZERS] No Root Reference! Try adding Optimizers Manager again!");
					return false;
				}
				if (GUILayout.Button(new GUIContent("Retry"), GUILayout.Width(50f), GUILayout.Height(15f)))
				{
					optimizer.RemoveAllComponentsFromToOptimize();
					optimizer.AssignComponentsToBeOptimizedFromAllChildren(optimizer.gameObject);
					if (sOptimizer.ToOptimize.Count == 0)
					{
						optimizer.AssignComponentsToBeOptimizedFromAllChildren(optimizer.gameObject, searchForCustom: true);
					}
				}
			}
			return true;
		}

		protected override void GenerateNewLODSettings()
		{
			ScrOptimizer_LODSettings scrOptimizer_LODSettings = LODSet;
			if (!(LODSet != null))
			{
				scrOptimizer_LODSettings = ScriptableObject.CreateInstance<ScrOptimizer_LODSettings>();
			}
			if (UsingShared)
			{
				SetSharedLODSettings(scrOptimizer_LODSettings);
			}
			else
			{
				SetUniqueLODSettings(scrOptimizer_LODSettings);
			}
		}

		protected override bool NeedToReGenerate(int targetCount)
		{
			bool result = false;
			if (LODSet == null)
			{
				if (uniqueLODSet == null && sharedLODSet == null)
				{
					result = true;
					GenerateNewLODSettings();
				}
				else if (uniqueLODSet != null)
				{
					LODSet = uniqueLODSet;
				}
				else
				{
					LODSet = sharedLODSet;
				}
			}
			else if (LODSet.LevelOfDetailSets == null)
			{
				result = true;
				LODSet.LevelOfDetailSets = new List<ScrLOD_Base>();
			}
			else if (LODSet.LevelOfDetailSets.Count == 0)
			{
				result = true;
			}
			else
			{
				if (!(LODSet.LevelOfDetailSets[0] != null))
				{
					result = true;
				}
				if (targetCount != LODSet.LevelOfDetailSets.Count + 2)
				{
					result = true;
				}
				else if (targetCount != 0)
				{
					bool flag = false;
					for (int i = 0; i < LODSet.LevelOfDetailSets.Count; i++)
					{
						if ((bool)LODSet.LevelOfDetailSets[i])
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						result = true;
					}
				}
			}
			return result;
		}

		public void SetSharedLODSettings(ScrOptimizer_LODSettings lodSettings)
		{
		}

		public static bool CheckLODSetCorrectness(ScrOptimizer_LODSettings lodSet, ILODInstance referenceLOD)
		{
			if (lodSet.LevelOfDetailSets.Count == 0)
			{
				Debug.LogError("[OPTIMIZERS] LOD Set is empty");
				return false;
			}
			if (lodSet.LevelOfDetailSets[0] == null)
			{
				Debug.LogError("[OPTIMIZERS] LOD Set element is null");
				return false;
			}
			Type type = lodSet.LevelOfDetailSets[0].GetLODInstance().GetType();
			if (type == referenceLOD.GetType())
			{
				return true;
			}
			Debug.LogError("[OPTIMIZERS] Type of LODSet is uncorrect! (<color=red><b>" + type.ToString() + "</b></color>) You need <color=blue><b>" + referenceLOD.GetType().ToString() + "</b></color> type");
			return false;
		}

		public void SetUniqueLODSettings(ScrOptimizer_LODSettings lodSettings)
		{
			if (Application.isPlaying)
			{
				Debug.LogWarning("[OPTIMIZERS] No allowed in playmode!");
				return;
			}
			if (lodSettings == null)
			{
				Debug.LogError("[OPTIMIZERS] Target lod settings cannot be null!");
				return;
			}
			sharedLODSet = null;
			uniqueLODSet = lodSettings;
			LODSet = lodSettings;
			LODSet.name = "LOD Set-" + optimizer.name;
			UsingShared = false;
		}

		protected override void CheckAndGenerateLODParameters()
		{
		}

		public bool LostRequiredReferences()
		{
			if (RootReference == null)
			{
				return true;
			}
			if (uniqueLODSet == null && sharedLODSet == null)
			{
				return true;
			}
			return false;
		}

		protected override void Editor_ValuesChanged()
		{
		}

		public ScrOptimizer_LODSettings SaveLODSet()
		{
			string text = "";
			string text2 = "";
			if (RootReference != null)
			{
				if (Component == null)
				{
					text2 = optimizer.name;
					text = RootReference.GetType().ToString();
					text = text.Replace("FIMSpace.FOptimizing.", "");
					text = text.Replace("LOD_", "");
					text = text.Replace("FLOD_", "");
					int num = text.LastIndexOf('.') + 1;
					text = text.Substring(num, text.Length - num);
				}
				else
				{
					text2 = Component.name;
					text = Component.GetType().ToString();
					int num2 = text.LastIndexOf('.') + 1;
					text = text.Substring(num2, text.Length - num2);
				}
				text2 = text2.Replace("PR_", "");
				text2 = text2.Replace("PR.", "");
				text2 = text2.Substring(0, Mathf.Min(11, text2.Length));
			}
			return null;
		}

		public void CheckAssetStructureCorrectness()
		{
			if (!RootReference)
			{
				Debug.LogError("[OPTIMIZERS] CRITICAL ERROR: There is no root reference in Optimizer's LOD Controller! Try adding Optimizers Manager again to the scene or import newest version from the Asset Store!");
			}
		}
	}
}
