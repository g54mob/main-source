using System;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public sealed class LODI_UnityLOD : ILODInstance
	{
		internal int index = -1;

		internal string LODName = "";

		[HideInInspector]
		public bool SetDisabled;

		[HideInInspector]
		[SerializeField]
		private int _version = 1;

		[HideInInspector]
		[SerializeField]
		private bool _Locked;

		[SerializeField]
		[HideInInspector]
		private LODGroup cmp;

		[Tooltip("Which LOD level from LOD Group should be applied on this Optimizer LOD Level")]
		public int UnityLODLevel;

		public string shaderParam = "_Transparency";

		public bool ColorParameter;

		public float shaderVisibleValue = 1f;

		public float shaderInvisibleValue;

		public float crossfadeHelper;

		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
			}
		}

		public string Name
		{
			get
			{
				return LODName;
			}
			set
			{
				LODName = value;
			}
		}

		public bool CustomEditor => true;

		public bool Disable
		{
			get
			{
				return SetDisabled;
			}
			set
			{
				SetDisabled = value;
			}
		}

		public bool DrawDisableOption => true;

		public bool SupportingTransitions => DrawingVersion == 2;

		public bool DrawLowererSlider => false;

		public float QualityLowerer
		{
			get
			{
				return 1f;
			}
			set
			{
				new NotImplementedException();
			}
		}

		public string HeaderText => "Unity LODGroup Settings";

		public float ToCullDelay => 0f;

		public bool SupportVersions => true;

		public int DrawingVersion
		{
			get
			{
				return _version;
			}
			set
			{
				_version = value;
			}
		}

		public Texture Icon => null;

		public Component TargetComponent => cmp;

		public bool LockSettings
		{
			get
			{
				return _Locked;
			}
			set
			{
				_Locked = value;
			}
		}

		public void SetSameValuesAsComponent(Component component)
		{
			if (component == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component is null instead of Unity LODGroup!");
			}
			else
			{
				cmp = component as LODGroup;
			}
			UnityLODLevel = 0;
		}

		public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettingsRef)
		{
			LODI_UnityLOD lODI_UnityLOD = initialSettingsRef as LODI_UnityLOD;
			if (component == null)
			{
				Debug.Log("[OPTIMIZERS] Target component is null");
				return;
			}
			if (lODI_UnityLOD == null)
			{
				Debug.Log("[OPTIMIZERS] Target LOD is not UnityLODGroup or is null");
				return;
			}
			LODGroup obj = component as LODGroup;
			LOD[] lODs = obj.GetLODs();
			obj.enabled = false;
			if (Disable)
			{
				for (int i = 0; i < lODs.Length; i++)
				{
					for (int j = 0; j < lODs[i].renderers.Length; j++)
					{
						if (lODs[i].renderers[j] != null)
						{
							lODs[i].renderers[j].enabled = false;
						}
					}
				}
			}
			else
			{
				if (!(crossfadeHelper <= 0f) && !(crossfadeHelper >= 1f))
				{
					return;
				}
				if (crossfadeHelper <= 0f)
				{
					for (int k = 0; k < lODs.Length; k++)
					{
						if (k == UnityLODLevel)
						{
							continue;
						}
						for (int l = 0; l < lODs[k].renderers.Length; l++)
						{
							if (lODs[k].renderers[l] != null)
							{
								lODs[k].renderers[l].enabled = false;
							}
						}
					}
				}
				if (UnityLODLevel >= lODs.Length)
				{
					return;
				}
				for (int m = 0; m < lODs[UnityLODLevel].renderers.Length; m++)
				{
					if (lODs[UnityLODLevel].renderers[m] != null)
					{
						lODs[UnityLODLevel].renderers[m].enabled = true;
					}
				}
			}
		}

		public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component component)
		{
			LODGroup lODGroup = component as LODGroup;
			if (lODGroup == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component for reference values is null or is not LODGroup Component!");
			}
			UnityLODLevel = lodIndex + 1;
			if (UnityLODLevel > lODGroup.lodCount - 1)
			{
				UnityLODLevel = lODGroup.lodCount - 1;
			}
			cmp = lODGroup;
		}

		public void AssignSettingsAsForCulled(Component component)
		{
			FLOD.AssignDefaultCulledParams(this);
			LODGroup lODGroup = component as LODGroup;
			if (lODGroup != null)
			{
				cmp = lODGroup;
				UnityLODLevel = lODGroup.lodCount;
			}
		}

		public void AssignSettingsAsForNearest(Component component)
		{
			FLOD.AssignDefaultNearestParams(this);
			UnityLODLevel = 0;
			if (component != null)
			{
				cmp = component as LODGroup;
			}
		}

		public void AssignSettingsAsForHidden(Component component)
		{
			FLOD.AssignDefaultHiddenParams(this);
			LODGroup lODGroup = component as LODGroup;
			if (lODGroup != null)
			{
				UnityLODLevel = lODGroup.lodCount;
				cmp = lODGroup;
			}
		}

		public ILODInstance GetCopy()
		{
			LODI_UnityLOD obj = MemberwiseClone() as LODI_UnityLOD;
			obj.cmp = cmp;
			obj.UnityLODLevel = UnityLODLevel;
			obj.shaderVisibleValue = shaderVisibleValue;
			obj.shaderInvisibleValue = shaderInvisibleValue;
			obj.ColorParameter = ColorParameter;
			obj.shaderParam = shaderParam;
			obj.DrawingVersion = DrawingVersion;
			return obj;
		}

		public void InterpolateBetween(ILODInstance a, ILODInstance b, float transitionToB)
		{
			FLOD.DoBaseInterpolation(this, a, b, transitionToB);
			LODI_UnityLOD obj = a as LODI_UnityLOD;
			LODI_UnityLOD lODI_UnityLOD = b as LODI_UnityLOD;
			DrawingVersion = b.DrawingVersion;
			crossfadeHelper = transitionToB;
			obj.crossfadeHelper = 1f - transitionToB;
			lODI_UnityLOD.crossfadeHelper = 1f - transitionToB;
			ApplyCrossfade(obj, lODI_UnityLOD, transitionToB);
		}

		private static void ApplyCrossfade(LODI_UnityLOD pre, LODI_UnityLOD next, float toNew)
		{
			if (pre.UnityLODLevel != next.UnityLODLevel && pre.cmp != null && pre.UnityLODLevel < pre.cmp.lodCount)
			{
				Renderer[] renderers = pre.cmp.GetLODs()[pre.UnityLODLevel].renderers;
				foreach (Renderer renderer in renderers)
				{
					if (toNew < 1f)
					{
						renderer.enabled = true;
					}
					if (renderer.materials.Length == 0)
					{
						continue;
					}
					Material[] materials = renderer.materials;
					foreach (Material material in materials)
					{
						if (material.HasProperty(pre.shaderParam))
						{
							if (pre.ColorParameter)
							{
								Color color = material.GetColor(pre.shaderParam);
								color.a = pre.GetFadeMaterialValueToVisible(1f - toNew);
								material.SetColor(pre.shaderParam, color);
							}
							else
							{
								material.SetFloat(pre.shaderParam, pre.GetFadeMaterialValueToVisible(1f - toNew));
							}
						}
					}
				}
			}
			if (!(next.cmp != null) || next.UnityLODLevel >= next.cmp.lodCount)
			{
				return;
			}
			Renderer[] renderers2 = next.cmp.GetLODs()[next.UnityLODLevel].renderers;
			foreach (Renderer renderer2 in renderers2)
			{
				renderer2.enabled = true;
				if (renderer2.materials.Length == 0)
				{
					continue;
				}
				Material[] materials = renderer2.materials;
				foreach (Material material2 in materials)
				{
					if (material2.HasProperty(next.shaderParam))
					{
						if (next.ColorParameter)
						{
							Color color2 = material2.GetColor(next.shaderParam);
							color2.a = next.GetFadeMaterialValueToVisible(toNew);
							material2.SetColor(next.shaderParam, color2);
						}
						else
						{
							material2.SetFloat(next.shaderParam, next.GetFadeMaterialValueToVisible(toNew));
						}
					}
				}
			}
		}

		private float GetFadeMaterialValueToVisible(float progress)
		{
			return Mathf.LerpUnclamped(shaderInvisibleValue, shaderVisibleValue, progress);
		}
	}
}
