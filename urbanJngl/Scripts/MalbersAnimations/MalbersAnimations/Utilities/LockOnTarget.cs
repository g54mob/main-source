using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/utilities/lock-on-target")]
	public class LockOnTarget : MonoBehaviour
	{
		[Tooltip("The Lock On Target will activate automatically if any target is stored on the list")]
		public BoolReference Auto = new BoolReference(value: false);

		[Tooltip("The Lock On Target requires an Aim Component")]
		[RequiredField]
		public Aim aim;

		[Tooltip("Set of the focused 'potential' Targets")]
		[RequiredField]
		public RuntimeGameObjects Targets;

		[Tooltip("Time needed to change to the next or previous target")]
		public FloatReference NextTargetTime = new FloatReference(0f);

		private float CurrentNextTime;

		private int CurrentTargetIndex = -1;

		public bool debug;

		[Header("Events")]
		public TransformEvent OnTargetChanged = new TransformEvent();

		public TransformEvent OnTargetAimAssist = new TransformEvent();

		public BoolEvent OnLockingTarget = new BoolEvent();

		private Transform locketTarget;

		public Transform LockedTarget
		{
			get
			{
				return locketTarget;
			}
			private set
			{
				locketTarget = value;
				aim.SetTarget(value);
				OnTargetChanged.Invoke(value);
				IsAimTarget = ((value != null) ? value.FindComponent<AimTarget>() : null);
				OnTargetAimAssist.Invoke((IsAimTarget != null) ? IsAimTarget.AimPoint : value);
			}
		}

		public bool LockingOn { get; private set; }

		public AimTarget IsAimTarget { get; private set; }

		public GameObject Owner => base.transform.root.gameObject;

		private void Awake()
		{
			Targets.Clear();
			if (aim != null)
			{
				aim.FindComponent<Aim>();
			}
		}

		private void OnEnable()
		{
			if (Targets != null)
			{
				Targets.OnItemAdded.AddListener(OnItemAdded);
				Targets.OnItemRemoved.AddListener(OnItemRemoved);
			}
			ResetLockOn();
		}

		private void OnDisable()
		{
			if (Targets != null)
			{
				Targets.OnItemAdded.RemoveListener(OnItemAdded);
				Targets.OnItemRemoved.RemoveListener(OnItemRemoved);
			}
			ResetLockOn();
		}

		private void OnItemAdded(GameObject arg0)
		{
			if (Auto.Value && !LockingOn)
			{
				LockTarget(value: true);
			}
		}

		public void LockTargetToggle()
		{
			LockingOn = !LockingOn;
			LookingTarget();
		}

		public void LockTarget(bool value)
		{
			LockingOn = value;
			LookingTarget();
		}

		private void LookingTarget()
		{
			if (LockingOn)
			{
				if (Targets != null && Targets.Count > 0)
				{
					FindNearestTarget();
					OnLockingTarget.Invoke(arg0: true);
				}
			}
			else
			{
				ResetLockOn();
			}
		}

		private void ResetLockOn()
		{
			if (LockedTarget != null)
			{
				CurrentTargetIndex = -1;
				LockedTarget = null;
				BoolEvent onLockingTarget = OnLockingTarget;
				bool arg = (LockingOn = false);
				onLockingTarget.Invoke(arg);
				Debugging("Reset Locked Target: [Empty]");
			}
		}

		private void FindNearestTarget()
		{
			GameObject gameObject = Targets.Item_GetClosest(base.gameObject);
			if ((bool)gameObject)
			{
				LockedTarget = gameObject.transform;
				CurrentTargetIndex = Targets.items.IndexOf(gameObject);
				Debugging("Locked Target: " + LockedTarget.name);
			}
			else
			{
				ResetLockOn();
			}
		}

		public void Target_Scroll(Vector2 value)
		{
			if (value.y > 0f || value.x > 0f)
			{
				Target_Next();
			}
			else if (value.y < 0f || value.x < 0f)
			{
				Target_Previous();
			}
		}

		public void Target_Scroll(float value)
		{
			if (value > 0f)
			{
				Target_Next();
			}
			else if (value < 0f)
			{
				Target_Previous();
			}
		}

		public void Target_Next()
		{
			if ((!(CurrentNextTime > 0f) || MTools.ElapsedTime(CurrentNextTime, NextTargetTime)) && Targets != null && LockedTarget != null && CurrentTargetIndex != -1)
			{
				CurrentTargetIndex++;
				CurrentTargetIndex %= Targets.Count;
				LockedTarget = Targets.Item_Get(CurrentTargetIndex).transform;
				Debugging("Locked Next Target: " + LockedTarget.name);
				CurrentNextTime = Time.time;
			}
		}

		public void Target_Previous()
		{
			if ((!(CurrentNextTime > 0f) || MTools.ElapsedTime(CurrentNextTime, NextTargetTime)) && Targets != null && LockedTarget != null && CurrentTargetIndex != -1)
			{
				CurrentTargetIndex--;
				if (CurrentTargetIndex == -1)
				{
					CurrentTargetIndex = Targets.Count - 1;
				}
				LockedTarget = Targets.Item_Get(CurrentTargetIndex).transform;
				Debugging("Locked Previous Target: " + LockedTarget.name);
				CurrentNextTime = Time.time;
			}
		}

		private void OnItemRemoved(GameObject _)
		{
			if (LockingOn)
			{
				this.Delay_Action(delegate
				{
					FindNearestTarget();
				});
			}
		}

		public void Debugging(string value)
		{
		}
	}
}
