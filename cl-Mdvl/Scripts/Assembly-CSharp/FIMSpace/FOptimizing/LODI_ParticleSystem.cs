using System;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public sealed class LODI_ParticleSystem : ILODInstance
	{
		internal int index = -1;

		internal string LODName = "";

		[HideInInspector]
		public bool SetDisabled;

		[SerializeField]
		[HideInInspector]
		private float QLowerer = 1f;

		internal float CullingDelay;

		[HideInInspector]
		[SerializeField]
		private bool _Locked;

		[SerializeField]
		[HideInInspector]
		private ParticleSystem cmp;

		[Space(4f)]
		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		[Tooltip("Percentage value of emmision rate for LOD level (percentage of initial emmission rate)")]
		public float EmmissionAmount = 1f;

		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		[Tooltip("Percentage value of burst rates for LOD level (percentage of initial burst rates)")]
		public float BurstsAmount = 1f;

		[FPD_Suffix(0f, 5f, FPD_SuffixAttribute.SuffixMode.PercentageUnclamped, "%", true, 0)]
		[Tooltip("Multiplier for particles size, if you make emmission smaller, particle size should become bigger to mask lower quality in distance")]
		public float ParticleSizeMul = 1f;

		[SerializeField]
		[HideInInspector]
		private ParticleSystem.Burst[] Bursts;

		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		[Tooltip("Percentage value of 'Max Particles' count for LOD level (percentage of initial 'Max Particles' count)")]
		public float MaxParticlAmount = 1f;

		[Tooltip("Percentage value of emmision rate over distance for LOD level (percentage of initial emmission rate)")]
		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		public float OverDistanceMul = 1f;

		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		[Tooltip("Percentage Alpha values of 'ColorOverLifetimeAlpha' for LOD level (percentage of initial 'ColorOverLifetimeAlpha' alpha keys on gradient)")]
		public float LifetimeAlpha = 1f;

		[HideInInspector]
		[Tooltip("Changing particle emission bursts can produce unwanted Garbage Collector allocation")]
		public bool ChangeBursts = true;

		[HideInInspector]
		[Tooltip("Changing color gradients can produce unwanted Garbage Collector allocation")]
		public bool ChangeGradients = true;

		[SerializeField]
		[HideInInspector]
		private ParticleSystem.MinMaxGradient ColorOverLifetime;

		private ParticleSystemRenderer allocatedRenderer;

		private GradientColorKey[] allocatedColorKeys;

		private ParticleSystem.Burst[] allocatedBursts;

		private GradientAlphaKey[] allocatedGradientKeys;

		private GradientAlphaKey[] allocatedGradientMinKeys;

		private GradientAlphaKey[] allocatedGradientMaxKeys;

		private bool usingGradients;

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

		public bool CustomEditor => false;

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

		public bool DrawLowererSlider => true;

		public float QualityLowerer
		{
			get
			{
				return QLowerer;
			}
			set
			{
				QLowerer = value;
			}
		}

		public string HeaderText => "Particle System LOD Settings";

		public float ToCullDelay => CullingDelay;

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
			if (component == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component is null instead of ParticleSystem!");
			}
			ParticleSystem particleSystem = component as ParticleSystem;
			if (!(particleSystem != null))
			{
				return;
			}
			cmp = particleSystem;
			EmmissionAmount = particleSystem.emission.rateOverTimeMultiplier;
			OverDistanceMul = particleSystem.emission.rateOverDistanceMultiplier;
			allocatedRenderer = particleSystem.GetComponent<ParticleSystemRenderer>();
			BurstsAmount = 1f;
			ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[particleSystem.emission.burstCount];
			particleSystem.emission.GetBursts(bursts);
			Bursts = bursts;
			MaxParticlAmount = particleSystem.main.maxParticles;
			LifetimeAlpha = 1f;
			ColorOverLifetime = particleSystem.colorOverLifetime.color;
			ColorOverLifetime = particleSystem.colorOverLifetime.color;
			usingGradients = false;
			if (ColorOverLifetime.gradient != null)
			{
				allocatedGradientKeys = ColorOverLifetime.gradient.alphaKeys;
				if (!usingGradients)
				{
					usingGradients = allocatedGradientKeys.Length != 0;
				}
			}
			if (ColorOverLifetime.gradientMin != null)
			{
				allocatedGradientMinKeys = ColorOverLifetime.gradientMin.alphaKeys;
				if (!usingGradients)
				{
					usingGradients = allocatedGradientMinKeys.Length != 0;
				}
			}
			if (ColorOverLifetime.gradientMax != null)
			{
				allocatedGradientMaxKeys = ColorOverLifetime.gradientMax.alphaKeys;
				if (!usingGradients)
				{
					usingGradients = allocatedGradientMaxKeys.Length != 0;
				}
			}
			allocatedColorKeys = ColorOverLifetime.gradient.colorKeys;
			ParticleSizeMul = particleSystem.main.startSizeMultiplier;
		}

		public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettingsRef)
		{
			LODI_ParticleSystem lODI_ParticleSystem = initialSettingsRef as LODI_ParticleSystem;
			ParticleSystem particleSystem = component as ParticleSystem;
			if (lODI_ParticleSystem == null || particleSystem == null)
			{
				Debug.Log("[OPTIMIZERS] Target LOD is not ParticleSystem LOD or is null");
				return;
			}
			ParticleSystemRenderer particleSystemRenderer = lODI_ParticleSystem.allocatedRenderer;
			if (particleSystemRenderer == null)
			{
				particleSystemRenderer = (lODI_ParticleSystem.allocatedRenderer = particleSystem.GetComponent<ParticleSystemRenderer>());
			}
			if (Disable)
			{
				if (particleSystemRenderer.enabled)
				{
					particleSystemRenderer.enabled = false;
					particleSystem.Pause(withChildren: false);
				}
			}
			else if (!particleSystemRenderer.enabled)
			{
				particleSystemRenderer.enabled = true;
				particleSystem.Play(withChildren: false);
			}
			ParticleSystem.EmissionModule emission = particleSystem.emission;
			ParticleSystem.MainModule main = particleSystem.main;
			emission.rateOverTimeMultiplier = lODI_ParticleSystem.EmmissionAmount * EmmissionAmount;
			emission.rateOverDistanceMultiplier = lODI_ParticleSystem.OverDistanceMul * OverDistanceMul;
			if (ChangeBursts && lODI_ParticleSystem.Bursts != null)
			{
				if (allocatedBursts == null)
				{
					allocatedBursts = new ParticleSystem.Burst[lODI_ParticleSystem.Bursts.Length];
				}
				ParticleSystem.Burst[] array = allocatedBursts;
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = lODI_ParticleSystem.Bursts[i];
					array[i].minCount = (short)((float)lODI_ParticleSystem.Bursts[i].minCount * BurstsAmount);
					array[i].maxCount = (short)((float)lODI_ParticleSystem.Bursts[i].maxCount * BurstsAmount);
				}
				emission.SetBursts(array);
			}
			main.maxParticles = (int)(lODI_ParticleSystem.MaxParticlAmount * MaxParticlAmount);
			if (lODI_ParticleSystem.usingGradients && ChangeGradients)
			{
				ParticleSystem.MinMaxGradient color = particleSystem.colorOverLifetime.color;
				if (lODI_ParticleSystem.ColorOverLifetime.mode == ParticleSystemGradientMode.Gradient)
				{
					if (lODI_ParticleSystem.ColorOverLifetime.gradient != null)
					{
						if (allocatedGradientKeys == null)
						{
							allocatedGradientKeys = new GradientAlphaKey[lODI_ParticleSystem.allocatedGradientKeys.Length];
						}
						GradientAlphaKey[] array2 = allocatedGradientKeys;
						for (int j = 0; j < array2.Length; j++)
						{
							array2[j].alpha = lODI_ParticleSystem.allocatedGradientKeys[j].alpha * LifetimeAlpha;
							array2[j].time = lODI_ParticleSystem.allocatedGradientKeys[j].time;
						}
						color.gradient.SetKeys(lODI_ParticleSystem.allocatedColorKeys, array2);
					}
				}
				else if (lODI_ParticleSystem.ColorOverLifetime.gradientMin != null)
				{
					if (allocatedGradientKeys == null)
					{
						allocatedGradientKeys = new GradientAlphaKey[lODI_ParticleSystem.allocatedGradientMinKeys.Length];
					}
					GradientAlphaKey[] array3 = allocatedGradientKeys;
					for (int k = 0; k < array3.Length; k++)
					{
						color.gradientMin.alphaKeys[k].alpha = lODI_ParticleSystem.allocatedGradientMinKeys[k].alpha * LifetimeAlpha;
						color.gradientMin.alphaKeys[k].time = lODI_ParticleSystem.allocatedGradientMinKeys[k].time;
					}
					color.gradientMin.SetKeys(lODI_ParticleSystem.allocatedColorKeys, array3);
					array3 = new GradientAlphaKey[lODI_ParticleSystem.ColorOverLifetime.gradientMax.alphaKeys.Length];
					for (int l = 0; l < array3.Length; l++)
					{
						color.gradientMax.alphaKeys[l].alpha = lODI_ParticleSystem.allocatedGradientMaxKeys[l].alpha * LifetimeAlpha;
						color.gradientMax.alphaKeys[l].time = lODI_ParticleSystem.allocatedGradientMaxKeys[l].time;
					}
					color.gradientMax.SetKeys(lODI_ParticleSystem.allocatedColorKeys, array3);
				}
				ParticleSystem.ColorOverLifetimeModule colorOverLifetime = particleSystem.colorOverLifetime;
				colorOverLifetime.color = color;
			}
			main.startSizeMultiplier = lODI_ParticleSystem.ParticleSizeMul * ParticleSizeMul;
			CullingDelay = particleSystem.main.startLifetime.constantMax;
		}

		public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component component)
		{
			ParticleSystem particleSystem = component as ParticleSystem;
			if (particleSystem == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component for reference values is null or is not ParticleSystem Component!");
			}
			cmp = particleSystem;
			float valueForLODLevel = FLOD.GetValueForLODLevel(1f, 0f, lodIndex, lodCount);
			float num = (BurstsAmount = (OverDistanceMul = (EmmissionAmount = valueForLODLevel * QualityLowerer)));
			MaxParticlAmount = Mathf.Min(1f, valueForLODLevel * 1.5f);
			ParticleSizeMul = 1.75f - num * 0.75f;
			Name = "LOD" + (lodIndex + 2);
		}

		public void AssignSettingsAsForCulled(Component component)
		{
			FLOD.AssignDefaultCulledParams(this);
			EmmissionAmount = 0f;
			OverDistanceMul = 0f;
			BurstsAmount = 0f;
			MaxParticlAmount = 0f;
			ParticleSizeMul = 1.5f;
			LifetimeAlpha = 0f;
		}

		public void AssignSettingsAsForNearest(Component component)
		{
			FLOD.AssignDefaultNearestParams(this);
		}

		public void AssignSettingsAsForHidden(Component component)
		{
			FLOD.AssignDefaultHiddenParams(this);
			MaxParticlAmount = 0.1f;
		}

		public ILODInstance GetCopy()
		{
			return MemberwiseClone() as ILODInstance;
		}

		public void InterpolateBetween(ILODInstance lodA, ILODInstance lodB, float transitionToB)
		{
			FLOD.DoBaseInterpolation(this, lodA, lodB, transitionToB);
			LODI_ParticleSystem lODI_ParticleSystem = lodA as LODI_ParticleSystem;
			LODI_ParticleSystem lODI_ParticleSystem2 = lodB as LODI_ParticleSystem;
			EmmissionAmount = Mathf.Lerp(lODI_ParticleSystem.EmmissionAmount, lODI_ParticleSystem2.EmmissionAmount, transitionToB);
			OverDistanceMul = Mathf.Lerp(lODI_ParticleSystem.OverDistanceMul, lODI_ParticleSystem2.OverDistanceMul, transitionToB);
			BurstsAmount = Mathf.Lerp(lODI_ParticleSystem.BurstsAmount, lODI_ParticleSystem2.BurstsAmount, transitionToB);
			MaxParticlAmount = Mathf.Lerp(lODI_ParticleSystem.MaxParticlAmount, lODI_ParticleSystem2.MaxParticlAmount, transitionToB);
			LifetimeAlpha = Mathf.Lerp(lODI_ParticleSystem.LifetimeAlpha, lODI_ParticleSystem2.LifetimeAlpha, transitionToB);
			ParticleSizeMul = Mathf.Lerp(lODI_ParticleSystem.ParticleSizeMul, lODI_ParticleSystem2.ParticleSizeMul, transitionToB);
		}
	}
}
