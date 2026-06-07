using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Set Strafe")]
	public class SetStrafeTask : MTask
	{
		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		public BoolReference strafe = new BoolReference(value: true);

		[Hide("showSelf")]
		[Tooltip("The Strafe Target of this AI Character, will be this Current AI Target")]
		public bool TargetIsStrafeTarget;

		[Hide("showTarget")]
		[Tooltip("The Strafe Target of the current AI Target, will be this AI Character")]
		public bool SelfIsStrafeTarget = true;

		[Tooltip("Add a completely new Strafe Target to the Animal")]
		[Hide("showTransform")]
		public TransformVar NewStrafeTarget;

		[HideInInspector]
		[SerializeField]
		private bool showTransform;

		[HideInInspector]
		[SerializeField]
		private bool showSelf;

		[HideInInspector]
		[SerializeField]
		private bool showTarget;

		public override string DisplayName => "Animal/Set Strafe";

		private void Reset()
		{
			Description = "Enable/Disable Strafing on the Animal Controller";
		}

		public override void StartTask(MAnimalBrain brain, int index)
		{
			Transform transform = ((NewStrafeTarget != null) ? NewStrafeTarget.Value : null);
			if (affect == Affected.Self)
			{
				brain.Animal.Strafe = strafe.Value;
				if (transform == null)
				{
					transform = brain.AIControl.Target;
				}
				if (TargetIsStrafeTarget)
				{
					brain.Animal.Aimer.SetTarget(transform);
				}
			}
			else if ((bool)brain.TargetAnimal)
			{
				brain.TargetAnimal.Strafe = strafe.Value;
				if (transform == null)
				{
					transform = brain.Animal.transform;
				}
				if (SelfIsStrafeTarget)
				{
					brain.TargetAnimal.Aimer.SetTarget(transform);
				}
			}
			brain.TaskDone(index);
		}

		private void OnValidate()
		{
			if (NewStrafeTarget != null)
			{
				TargetIsStrafeTarget = false;
				SelfIsStrafeTarget = false;
			}
			showTransform = (affect == Affected.Self && !TargetIsStrafeTarget) || (affect == Affected.Target && !SelfIsStrafeTarget);
			showSelf = affect == Affected.Self && NewStrafeTarget == null;
			showTarget = affect == Affected.Target && NewStrafeTarget == null;
		}
	}
}
