using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Play Mode")]
	public class PlayModeTask : MTask
	{
		[Tooltip("Mode you want to activate when the brain is using this task")]
		public ModeID modeID;

		[Tooltip("Ability ID for the Mode... if is set to -99 it will play a random Ability")]
		public IntReference AbilityID = new IntReference(-99);

		public FloatReference ModePower = new FloatReference(0f);

		[Tooltip("Play the mode only when the animal has arrived to the target")]
		public bool near;

		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		[Tooltip("Play Once: it will play only at the start of the Task. Play Forever: will play forever using the Cooldown property")]
		public PlayWhen Play = PlayWhen.PlayForever;

		[Tooltip("Time elapsed to Play the Mode again and Again")]
		public FloatReference CoolDown = new FloatReference(0f);

		[Tooltip("Play the Mode if the Animal is Looking at the Target. Avoid playing modes while the target is behind the animal when this value is set to 180")]
		[Range(0f, 360f)]
		public float ModeAngle = 360f;

		[Tooltip("Align with a Look At towards the Target when Playing a mode")]
		public bool lookAtAlign;

		[Tooltip("When the mode is said to Play Forever, it will ignore the first cooldown")]
		public bool IgnoreFirstCoolDown = true;

		[Tooltip("If the task was playing a mode when the AI State Exits, stop the playing Mode")]
		public bool StopModeOnExit = true;

		[Tooltip("Align time to rotate towards the Target")]
		public float alignTime = 0.3f;

		public override string DisplayName => "Animal/Set|Play Mode";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			if (!((float)CoolDown <= 0f))
			{
				return;
			}
			if (Play == PlayWhen.PlayOnce)
			{
				if ((!near || brain.AIControl.HasArrived) && !brain.AIControl.IsWaitingOnTarget && PlayMode(brain))
				{
					brain.TasksVars[index].boolValue = true;
				}
			}
			else
			{
				if (Play != PlayWhen.Interrupt)
				{
					return;
				}
				switch (affect)
				{
				case Affected.Self:
					brain.Animal.Mode_Interrupt();
					break;
				case Affected.Target:
					if (brain.TargetAnimal != null)
					{
						brain.TargetAnimal.Mode_Interrupt();
					}
					break;
				}
				brain.TaskDone(index);
			}
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			if ((near && !brain.AIControl.HasArrived) || brain.AIControl.IsWaitingOnTarget)
			{
				return;
			}
			switch (Play)
			{
			case PlayWhen.PlayOnce:
				if (!brain.TasksVars[index].boolValue)
				{
					if (MTools.ElapsedTime(brain.TasksStartTime[index], CoolDown) && PlayMode(brain))
					{
						brain.TasksVars[index].boolValue = true;
					}
					break;
				}
				switch (affect)
				{
				case Affected.Self:
					if (!brain.Animal.IsPlayingMode && !brain.Animal.IsPreparingMode)
					{
						brain.TaskDone(index);
					}
					break;
				case Affected.Target:
					if ((bool)brain.TargetAnimal && !brain.TargetAnimal.IsPlayingMode && !brain.TargetAnimal.IsPreparingMode)
					{
						brain.TaskDone(index);
					}
					break;
				}
				break;
			case PlayWhen.PlayForever:
				if (!brain.TasksVars[index].boolValue && IgnoreFirstCoolDown && PlayMode(brain))
				{
					brain.TasksStartTime[index] = Time.time;
					brain.TasksVars[index].boolValue = true;
				}
				if (MTools.ElapsedTime(brain.TasksStartTime[index], CoolDown) && PlayMode(brain))
				{
					brain.TasksStartTime[index] = Time.time;
				}
				break;
			}
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			base.ExitAIState(brain, index);
			MAnimal mAnimal = ((affect == Affected.Self) ? brain.Animal : brain.TargetAnimal);
			if (mAnimal != null && mAnimal.IsPlayingMode && StopModeOnExit)
			{
				mAnimal.Mode_Stop();
			}
		}

		private bool PlayMode(MAnimalBrain brain)
		{
			switch (affect)
			{
			case Affected.Self:
			{
				Vector3 vector = ((brain.Target != null) ? (brain.Target.position - brain.Eyes.position) : brain.Animal.Forward);
				Vector3 rhs = Vector3.ProjectOnPlane(brain.Eyes.forward, brain.Animal.UpVector);
				if ((ModeAngle == 360f || Vector3.Dot(vector.normalized, rhs) > Mathf.Cos(ModeAngle * 0.5f * (MathF.PI / 180f))) && ((Play == PlayWhen.PlayOnce && brain.Animal.Mode_TryActivate(modeID, AbilityID, AbilityStatus.PlayOneTime)) || brain.Animal.Mode_TryActivate(modeID, AbilityID)))
				{
					if (lookAtAlign && (bool)brain.Target)
					{
						brain.StartCoroutine(MTools.AlignLookAtTransform(brain.Animal.transform, brain.AIControl.GetTargetPosition(), alignTime));
					}
					brain.Animal.Mode_SetPower(ModePower);
					return true;
				}
				break;
			}
			case Affected.Target:
			{
				Vector3 vector = brain.Eyes.position - brain.Target.position;
				Vector3 rhs = Vector3.ProjectOnPlane(brain.Target.forward, brain.Animal.UpVector);
				if ((ModeAngle == 360f || Vector3.Dot(vector.normalized, rhs) > Mathf.Cos(ModeAngle * 0.5f * (MathF.PI / 180f))) && (bool)brain.TargetAnimal && brain.TargetAnimal.Mode_TryActivate(modeID, AbilityID))
				{
					if (lookAtAlign && (bool)brain.Target)
					{
						brain.StartCoroutine(MTools.AlignLookAtTransform(brain.TargetAnimal.transform, brain.transform, alignTime));
					}
					brain.TargetAnimal.Mode_SetPower(ModePower);
					return true;
				}
				break;
			}
			}
			return false;
		}

		private void Reset()
		{
			Description = "Plays a mode on the Animal(Self or the Target)";
		}
	}
}
