using System;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public sealed class LODI_Light : ILODInstance
	{
		public enum EOptLightMode
		{
			Auto = 0,
			Important = 1,
			NotImportant = 2
		}

		internal int index = -1;

		internal string LODName = "";

		[HideInInspector]
		public bool SetDisabled;

		[HideInInspector]
		[SerializeField]
		private bool _Locked;

		[SerializeField]
		[HideInInspector]
		private Light cmp;

		[Space(4f)]
		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		[Tooltip("Percentage value of light intensity for LOD level (percentage of initial light intensity)")]
		public float IntensityMul = 1f;

		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		[Tooltip("Percentage value of light range for LOD level (percentage of initial light range)")]
		public float RangeMul = 1f;

		[Space(3f)]
		public LightShadows ShadowsMode = LightShadows.Soft;

		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		[Tooltip("Percentage value of shadows intensity for LOD level (percentage of initial shadow value)")]
		public float ShadowsStrength = 1f;

		public EOptLightMode RenderMode;

		[HideInInspector]
		[Tooltip("If component should change intensity and range of light component (disable if you using flickering or something)")]
		public bool ChangeIntensity = true;

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

		public bool SupportingTransitions => true;

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

		public string HeaderText => "Light LOD Settings";

		public float ToCullDelay => 0f;

		public bool SupportVersions => false;

		public int DrawingVersion
		{
			get
			{
				return 1;
			}
			set
			{
				new NotImplementedException();
			}
		}

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

		public Texture Icon => null;

		public Component TargetComponent => cmp;

		public void SetSameValuesAsComponent(Component component)
		{
			Light light = component as Light;
			if (!(light == null))
			{
				cmp = light;
				IntensityMul = light.intensity;
				RangeMul = light.range;
				ShadowsMode = light.shadows;
				ShadowsStrength = light.shadowStrength;
				RenderMode = (EOptLightMode)light.renderMode;
			}
		}

		public void InterpolateBetween(ILODInstance aa, ILODInstance bb, float transitionToB)
		{
			FLOD.DoBaseInterpolation(this, aa, bb, transitionToB);
			LODI_Light lODI_Light = aa as LODI_Light;
			LODI_Light lODI_Light2 = bb as LODI_Light;
			ChangeIntensity = lODI_Light.ChangeIntensity;
			if (ChangeIntensity)
			{
				IntensityMul = Mathf.Lerp(lODI_Light.IntensityMul, lODI_Light2.IntensityMul, transitionToB);
				RangeMul = Mathf.Lerp(lODI_Light.RangeMul, lODI_Light2.RangeMul, transitionToB);
			}
			if (lODI_Light2.ShadowsMode == LightShadows.None)
			{
				lODI_Light2.ShadowsStrength = 0f;
			}
			ShadowsStrength = Mathf.Lerp(lODI_Light.ShadowsStrength, lODI_Light2.ShadowsStrength, transitionToB);
			if (lODI_Light2.ShadowsStrength > 0f)
			{
				if (lODI_Light.ShadowsMode == LightShadows.None && transitionToB >= 1f)
				{
					RenderMode = lODI_Light2.RenderMode;
				}
				ShadowsMode = lODI_Light2.ShadowsMode;
			}
			if (RenderMode == EOptLightMode.Important)
			{
				if (transitionToB >= 1f)
				{
					RenderMode = lODI_Light2.RenderMode;
				}
			}
			else if (lODI_Light2.RenderMode == EOptLightMode.Important || lODI_Light2.RenderMode == EOptLightMode.Auto)
			{
				RenderMode = lODI_Light2.RenderMode;
			}
			if (transitionToB >= 1f)
			{
				ShadowsMode = lODI_Light2.ShadowsMode;
				RenderMode = lODI_Light2.RenderMode;
			}
			else if (transitionToB <= 0f)
			{
				ShadowsMode = lODI_Light.ShadowsMode;
				RenderMode = lODI_Light.RenderMode;
			}
		}

		public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettings)
		{
			LODI_Light lODI_Light = initialSettings as LODI_Light;
			Light light = component as Light;
			if (lODI_Light == null || light == null)
			{
				Debug.Log("[OPTIMIZERS] Target LOD is not LightLOD or is null");
				return;
			}
			if (ChangeIntensity)
			{
				light.intensity = IntensityMul * lODI_Light.IntensityMul;
				light.range = RangeMul * lODI_Light.RangeMul;
			}
			light.shadowStrength = ShadowsStrength * lODI_Light.ShadowsStrength;
			light.shadows = ShadowsMode;
			light.renderMode = (LightRenderMode)RenderMode;
			if (Disable)
			{
				light.enabled = false;
			}
			else
			{
				light.enabled = true;
			}
		}

		public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component component)
		{
			Light light = component as Light;
			if (light == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component for reference values is null or is not Light Component!");
			}
			float valueForLODLevel = FLOD.GetValueForLODLevel(1f, 0f, lodIndex - 2, lodCount);
			if (lodIndex > 2 && lodCount > 2)
			{
				RangeMul = valueForLODLevel;
				ShadowsStrength = valueForLODLevel;
			}
			ShadowsMode = light.shadows;
			RenderMode = (EOptLightMode)light.renderMode;
			if (lodCount == 2 && light.shadows == LightShadows.Soft)
			{
				ShadowsMode = LightShadows.Hard;
			}
			if (lodCount > 2 && light.shadows == LightShadows.Soft)
			{
				ShadowsMode = LightShadows.Hard;
			}
			if (light.renderMode == LightRenderMode.ForcePixel)
			{
				RenderMode = EOptLightMode.Auto;
			}
			if (lodIndex > 0 && light.renderMode == LightRenderMode.ForcePixel)
			{
				RenderMode = EOptLightMode.Auto;
			}
			if (lodIndex >= lodCount - 2 && lodCount > 2)
			{
				ShadowsMode = LightShadows.None;
				ShadowsStrength = 0f;
			}
			if (lodIndex >= 1 && lodCount == 3)
			{
				RenderMode = EOptLightMode.NotImportant;
			}
			if (lodIndex >= 2)
			{
				RenderMode = EOptLightMode.NotImportant;
			}
			if (RenderMode == EOptLightMode.NotImportant)
			{
				IntensityMul = 0.4f;
				RangeMul = 0.5f;
			}
		}

		public void AssignSettingsAsForCulled(Component component)
		{
			FLOD.AssignDefaultCulledParams(this);
			IntensityMul = 0f;
			RangeMul = 0f;
			ShadowsStrength = 0f;
			ShadowsMode = LightShadows.None;
			RenderMode = EOptLightMode.NotImportant;
		}

		public void AssignSettingsAsForNearest(Component component)
		{
			FLOD.AssignDefaultNearestParams(this);
			Light light = component as Light;
			ShadowsMode = light.shadows;
			RenderMode = (EOptLightMode)light.renderMode;
		}

		public void AssignSettingsAsForHidden(Component componentnent)
		{
			FLOD.AssignDefaultHiddenParams(this);
		}

		public ILODInstance GetCopy()
		{
			return MemberwiseClone() as ILODInstance;
		}
	}
}
