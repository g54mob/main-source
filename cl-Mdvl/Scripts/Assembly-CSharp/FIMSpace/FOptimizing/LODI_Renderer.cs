using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public sealed class LODI_Renderer : ILODInstance
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
		private Renderer cmp;

		[Space(4f)]
		[Tooltip("If model should cast and receive shadows (receive will be always false if renderer have it marked as false by default)")]
		public bool UseShadows = true;

		internal ShadowCastingMode ShadowsCast = ShadowCastingMode.On;

		internal bool ShadowsReceive;

		public MotionVectorGenerationMode MotionVectors = MotionVectorGenerationMode.Object;

		[Tooltip("If it is skinned mesh renderer we can switch bones weights spread quality")]
		public SkinQuality SkinnedQuality;

		public string shaderParam = "_Transparency";

		public bool ColorParameter;

		public float targetParamValue = 1f;

		private Material[] allocatedMaterials;

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

		public string HeaderText => "Renderer LOD Settings";

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
			if (component == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component is null instead of Renderer!");
			}
			Renderer renderer = component as Renderer;
			if (renderer != null)
			{
				cmp = renderer;
				UseShadows = true;
				if (renderer.shadowCastingMode == ShadowCastingMode.Off)
				{
					UseShadows = false;
				}
				ShadowsCast = renderer.shadowCastingMode;
				ShadowsReceive = renderer.receiveShadows;
				MotionVectors = renderer.motionVectorGenerationMode;
				SkinnedMeshRenderer skinnedMeshRenderer = component as SkinnedMeshRenderer;
				if ((bool)skinnedMeshRenderer)
				{
					SkinnedQuality = skinnedMeshRenderer.quality;
				}
			}
		}

		public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettingsRef)
		{
			LODI_Renderer lODI_Renderer = initialSettingsRef as LODI_Renderer;
			if (component == null)
			{
				Debug.Log("[OPTIMIZERS] Target component is null");
				return;
			}
			if (lODI_Renderer == null)
			{
				Debug.Log("[OPTIMIZERS] Target LOD is not Renderer LOD or is null");
				return;
			}
			Renderer renderer = component as Renderer;
			if (UseShadows)
			{
				renderer.shadowCastingMode = lODI_Renderer.ShadowsCast;
				renderer.receiveShadows = lODI_Renderer.ShadowsReceive;
			}
			else
			{
				renderer.shadowCastingMode = ShadowCastingMode.Off;
				renderer.receiveShadows = false;
			}
			renderer.motionVectorGenerationMode = MotionVectors;
			if (DrawingVersion == 2 && !string.IsNullOrEmpty(shaderParam))
			{
				if (allocatedMaterials == null)
				{
					allocatedMaterials = renderer.materials;
				}
				if (allocatedMaterials.Length != 0)
				{
					Material[] array = allocatedMaterials;
					foreach (Material material in array)
					{
						if (material.HasProperty(shaderParam))
						{
							if (ColorParameter)
							{
								Color color = material.GetColor(shaderParam);
								color.a = targetParamValue;
								material.SetColor(shaderParam, color);
							}
							else
							{
								material.SetFloat(shaderParam, targetParamValue);
							}
						}
					}
				}
			}
			if (QualitySettings.skinWeights != SkinWeights.OneBone && renderer is SkinnedMeshRenderer)
			{
				if (QualitySettings.skinWeights == SkinWeights.TwoBones && SkinnedQuality == SkinQuality.Bone4)
				{
					SkinnedQuality = SkinQuality.Bone2;
				}
				(renderer as SkinnedMeshRenderer).quality = SkinnedQuality;
			}
			if (Disable)
			{
				renderer.enabled = false;
			}
			else if (!renderer.enabled)
			{
				renderer.enabled = true;
			}
		}

		public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component component)
		{
			Renderer renderer = component as Renderer;
			if (renderer == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component for reference values is null or is not Renderer Component!");
			}
			float valueForLODLevel = FLOD.GetValueForLODLevel(1f, 0f, lodIndex, lodCount);
			UseShadows = renderer.shadowCastingMode != ShadowCastingMode.Off;
			if (lodIndex >= 0 && renderer.motionVectorGenerationMode != MotionVectorGenerationMode.ForceNoMotion)
			{
				MotionVectors = MotionVectorGenerationMode.Camera;
			}
			if (lodCount == 2 && renderer.motionVectorGenerationMode == MotionVectorGenerationMode.Object)
			{
				MotionVectors = MotionVectorGenerationMode.Camera;
			}
			SkinnedMeshRenderer skinnedMeshRenderer = renderer as SkinnedMeshRenderer;
			SkinQuality skinQuality = SkinQuality.Auto;
			if ((bool)skinnedMeshRenderer)
			{
				skinQuality = skinnedMeshRenderer.quality;
			}
			if (valueForLODLevel < 0.6f)
			{
				SkinnedQuality = ((skinQuality == SkinQuality.Bone4) ? SkinQuality.Bone2 : SkinQuality.Auto);
			}
			if (valueForLODLevel < 0.4f)
			{
				SkinnedQuality = SkinQuality.Bone1;
			}
			if (valueForLODLevel < 0.55f)
			{
				UseShadows = false;
			}
			if (lodIndex == lodCount - 2)
			{
				UseShadows = false;
				if (lodCount != 2)
				{
					MotionVectors = MotionVectorGenerationMode.ForceNoMotion;
				}
				SkinnedQuality = SkinQuality.Bone1;
			}
		}

		public void AssignSettingsAsForCulled(Component component)
		{
			FLOD.AssignDefaultCulledParams(this);
			UseShadows = false;
			MotionVectors = MotionVectorGenerationMode.ForceNoMotion;
			SkinnedQuality = SkinQuality.Bone1;
			targetParamValue = 0f;
		}

		public void AssignSettingsAsForNearest(Component component)
		{
			FLOD.AssignDefaultNearestParams(this);
		}

		public void AssignSettingsAsForHidden(Component component)
		{
			FLOD.AssignDefaultHiddenParams(this);
			UseShadows = false;
			MotionVectors = MotionVectorGenerationMode.ForceNoMotion;
			SkinnedQuality = SkinQuality.Bone1;
			targetParamValue = 0f;
		}

		public ILODInstance GetCopy()
		{
			LODI_Renderer obj = MemberwiseClone() as LODI_Renderer;
			obj.targetParamValue = targetParamValue;
			obj.ColorParameter = ColorParameter;
			obj.shaderParam = shaderParam;
			obj.DrawingVersion = DrawingVersion;
			return obj;
		}

		public void InterpolateBetween(ILODInstance a, ILODInstance b, float transitionToB)
		{
			FLOD.DoBaseInterpolation(this, a, b, transitionToB);
			LODI_Renderer lODI_Renderer = a as LODI_Renderer;
			LODI_Renderer lODI_Renderer2 = b as LODI_Renderer;
			DrawingVersion = b.DrawingVersion;
			targetParamValue = Mathf.Lerp(lODI_Renderer.targetParamValue, lODI_Renderer2.targetParamValue, transitionToB);
		}
	}
}
