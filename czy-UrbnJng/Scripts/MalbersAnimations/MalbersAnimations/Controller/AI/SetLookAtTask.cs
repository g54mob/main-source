using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Look At-Aim", fileName = "new Aim Task")]
	public class SetLookAtTask : MTask
	{
		public enum LookAtOption1
		{
			CurrentTarget = 0,
			TransformVar = 1,
			ClearTarget = 2
		}

		public enum LookAtOption2
		{
			This = 0,
			TransformVar = 1,
			ClearTarget = 2
		}

		[Tooltip("Check the Look At Component on the Target or on Self")]
		[FormerlySerializedAs("SetLookAtOn")]
		public Affected SetAimOn;

		[Hide("SetAimOn", new int[] { 0 })]
		public LookAtOption1 LookAtTargetS;

		[Hide("SetAimOn", new int[] { 1 })]
		public LookAtOption2 LookAtTargetT;

		[Hide("showTransformVar")]
		public TransformVar TargetVar;

		[Tooltip("If true .. it will Look for a gameObject on the Target with the Tag[tag].... else it will look for the gameObject name")]
		public bool UseTag;

		[Hide("UseTag", true)]
		[Tooltip("Search for the Target Child gameObject name")]
		public string BoneName = "Head";

		[Hide("UseTag")]
		[Tooltip("Look for a child gameObject on the Target with the Tag[tag]")]
		public Tag tag;

		[Tooltip("When the Task ends it will Remove the Target on the Aim Component")]
		public bool DisableOnExit = true;

		[HideInInspector]
		public bool showTransformVar;

		public override string DisplayName => "General/Set Look At-Aim";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			IAim aim = ((SetAimOn == Affected.Self) ? brain.Animal.FindInterface<IAim>() : ((brain.Target != null) ? brain.Target.FindInterface<IAim>() : null));
			if (aim == null)
			{
				brain.TaskDone(index);
				return;
			}
			if (SetAimOn == Affected.Self && LookAtTargetS == LookAtOption1.ClearTarget)
			{
				aim.ClearTarget();
			}
			else if (SetAimOn == Affected.Target && LookAtTargetT == LookAtOption2.ClearTarget)
			{
				aim.ClearTarget();
			}
			else if (SetAimOn == Affected.Self)
			{
				Transform transform = ((LookAtTargetS == LookAtOption1.CurrentTarget) ? brain.Target : TargetVar.Value);
				Transform target = (UseTag ? transform.FindWithMalbersTag(tag) : GetChildByName(transform));
				aim.SetTarget(target);
			}
			else
			{
				Transform transform2 = ((LookAtTargetT == LookAtOption2.This) ? brain.Animal.transform : TargetVar.Value);
				Transform target = (UseTag ? transform2.FindWithMalbersTag(tag) : GetChildByName(transform2));
				aim.SetTarget(target);
			}
			brain.TaskDone(index);
		}

		private Transform GetChildByName(Transform Target)
		{
			if ((bool)Target && !string.IsNullOrEmpty(BoneName))
			{
				Transform transform = Target.FindGrandChild(BoneName);
				if (transform != null)
				{
					return transform;
				}
			}
			return Target;
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			if (DisableOnExit)
			{
				brain.Animal.FindInterface<IAim>()?.ClearTarget();
				if ((bool)brain.Target)
				{
					brain.Target.FindInterface<IAim>()?.ClearTarget();
				}
			}
		}

		private void OnValidate()
		{
			showTransformVar = (LookAtTargetS == LookAtOption1.TransformVar && SetAimOn == Affected.Self) || (LookAtTargetT == LookAtOption2.TransformVar && SetAimOn == Affected.Target);
		}

		private void Reset()
		{
			Description = "Find a child gameObject with the name given on the Target and set it as the Target for Aim Component";
		}
	}
}
