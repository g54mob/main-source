using System;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public sealed class LODI_AudioSource : ILODInstance
	{
		internal int index = -1;

		internal string LODName = "";

		[HideInInspector]
		public bool SetDisabled;

		[HideInInspector]
		[SerializeField]
		private bool _Locked;

		[SerializeField]
		[HideInInspector]
		private AudioSource cmp;

		[Range(0f, 1f)]
		[Tooltip("Setted to zero will result with priority = 256 so marked as NOT important audio source, marked as 100% will result with priority level like audio source had when initialized")]
		public float PriorityFactor = 1f;

		[HideInInspector]
		public float Volume = 1f;

		private bool unPause;

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

		public string HeaderText => "AudioSource LOD Settings";

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

		public float ToCullDelay => 0f;

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
			if (!(component == null))
			{
				AudioSource audioSource = (cmp = component as AudioSource);
				PriorityFactor = audioSource.priority;
				Volume = audioSource.volume;
			}
		}

		public void InterpolateBetween(ILODInstance a, ILODInstance b, float transitionToB)
		{
			FLOD.DoBaseInterpolation(this, a, b, transitionToB);
			LODI_AudioSource lODI_AudioSource = a as LODI_AudioSource;
			LODI_AudioSource lODI_AudioSource2 = b as LODI_AudioSource;
			PriorityFactor = lODI_AudioSource2.PriorityFactor;
			Volume = Mathf.Lerp(lODI_AudioSource.Volume, lODI_AudioSource2.Volume, transitionToB);
		}

		public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettings)
		{
			AudioSource audioSource = component as AudioSource;
			LODI_AudioSource lODI_AudioSource = initialSettings as LODI_AudioSource;
			audioSource.priority = (int)Mathf.Lerp(255f, lODI_AudioSource.PriorityFactor, PriorityFactor);
			audioSource.volume = lODI_AudioSource.Volume * Volume;
			if (Disable)
			{
				if (audioSource.isPlaying && audioSource.loop)
				{
					audioSource.Pause();
					unPause = true;
				}
				audioSource.enabled = false;
			}
			else
			{
				if (unPause)
				{
					unPause = false;
					audioSource.UnPause();
				}
				audioSource.enabled = true;
			}
		}

		public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component source)
		{
			if (source as AudioSource == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component for reference values is null or is not AudioSource Component!");
			}
			float valueForLODLevel = FLOD.GetValueForLODLevel(1f, 0f, lodIndex - 1, lodCount);
			if (lodIndex > 0)
			{
				PriorityFactor = valueForLODLevel;
			}
			Volume = 1f;
		}

		public void AssignSettingsAsForCulled(Component component)
		{
			FLOD.AssignDefaultCulledParams(this);
			PriorityFactor = 0f;
			Volume = 0f;
		}

		public void AssignSettingsAsForNearest(Component component)
		{
			FLOD.AssignDefaultNearestParams(this);
			PriorityFactor = 1f;
			Volume = 1f;
		}

		public ILODInstance GetCopy()
		{
			return MemberwiseClone() as ILODInstance;
		}

		public void AssignSettingsAsForHidden(Component component)
		{
			FLOD.AssignDefaultHiddenParams(this);
		}
	}
}
