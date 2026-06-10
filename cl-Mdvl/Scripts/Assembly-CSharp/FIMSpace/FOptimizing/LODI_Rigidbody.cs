using System;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public sealed class LODI_Rigidbody : ILODInstance
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
		private Rigidbody cmp;

		[Space(4f)]
		[Tooltip("Switching collision detection for rigidbody")]
		public bool DetectCollisions;

		[Tooltip("Switching kinemtic to make object freezed")]
		public bool IsKinematic;

		[Space(6f)]
		public RigidbodyInterpolation Interpolation;

		[Tooltip("Continous and ContinousDynamic have big impact on rigidbodies performance, try to not use them when object is far from camera.\nSpeculative have a bit bigger impact on performance than Discrete.\nDiscrete collision is fastest.")]
		public CollisionDetectionMode CollisionMode;

		[Space(4f)]
		[Tooltip("Try forcing rigidbody to Sleep state")]
		public bool TryTriggerSleep;

		[Tooltip("Try forcing rigidbody to go out of Sleep state")]
		public bool TriggerWakeup;

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

		public bool DrawDisableOption => false;

		public bool SupportingTransitions => false;

		public bool DrawLowererSlider => false;

		public float QualityLowerer
		{
			get
			{
				return 1f;
			}
			set
			{
			}
		}

		public string HeaderText => "Rigidbody LOD Settings";

		public bool SupportVersions => false;

		public int DrawingVersion
		{
			get
			{
				return 1;
			}
			set
			{
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
			Rigidbody rigidbody = component as Rigidbody;
			if (!(rigidbody == null))
			{
				cmp = rigidbody;
				IsKinematic = rigidbody.isKinematic;
				DetectCollisions = rigidbody.detectCollisions;
				Interpolation = rigidbody.interpolation;
				CollisionMode = rigidbody.collisionDetectionMode;
			}
		}

		public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettings)
		{
			Rigidbody rigidbody = component as Rigidbody;
			rigidbody.isKinematic = IsKinematic;
			rigidbody.detectCollisions = DetectCollisions;
			rigidbody.interpolation = Interpolation;
			rigidbody.collisionDetectionMode = CollisionMode;
			if (TriggerWakeup)
			{
				if (rigidbody.IsSleeping())
				{
					rigidbody.WakeUp();
				}
			}
			else if (TryTriggerSleep && !rigidbody.IsSleeping())
			{
				rigidbody.Sleep();
			}
		}

		public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component source)
		{
			Rigidbody rigidbody = source as Rigidbody;
			if (rigidbody == null)
			{
				Debug.LogError("[OPTIMIZERS] Given component for reference values is null or is not AudioSource Component!");
			}
			DetectCollisions = rigidbody.detectCollisions;
			Interpolation = rigidbody.interpolation;
			CollisionMode = rigidbody.collisionDetectionMode;
			if (lodIndex > 0)
			{
				TryTriggerSleep = true;
				CollisionMode = CollisionDetectionMode.Discrete;
			}
			if (lodIndex == lodCount - 2)
			{
				TryTriggerSleep = true;
				CollisionMode = CollisionDetectionMode.Discrete;
			}
		}

		public void AssignSettingsAsForCulled(Component component)
		{
			FLOD.AssignDefaultCulledParams(this);
			DetectCollisions = false;
			IsKinematic = true;
			CollisionMode = CollisionDetectionMode.Discrete;
			TryTriggerSleep = true;
		}

		public void AssignSettingsAsForNearest(Component component)
		{
			FLOD.AssignDefaultNearestParams(this);
			SetSameValuesAsComponent(component);
			TriggerWakeup = true;
		}

		public ILODInstance GetCopy()
		{
			return MemberwiseClone() as ILODInstance;
		}

		public void AssignSettingsAsForHidden(Component component)
		{
			Name = "Hidden";
			TryTriggerSleep = true;
		}

		public void InterpolateBetween(ILODInstance lodA, ILODInstance lodB, float transitionToB)
		{
		}
	}
}
