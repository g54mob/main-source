using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/States/Ladder Climbing")]
	public class LadderClimbing : CharacterState
	{
		public enum LadderClimbState
		{
			Entering = 0,
			Exiting = 1,
			Idling = 2,
			Climbing = 3
		}

		[Header("Offset")]
		[SerializeField]
		protected bool useIKOffsetValues;

		[Condition("useIKOffsetValues", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		protected Vector3 rightFootOffset = Vector3.zero;

		[Condition("useIKOffsetValues", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		protected Vector3 leftFootOffset = Vector3.zero;

		[Condition("useIKOffsetValues", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		protected Vector3 rightHandOffset = Vector3.zero;

		[Condition("useIKOffsetValues", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		protected Vector3 leftHandOffset = Vector3.zero;

		[Header("Activation")]
		[SerializeField]
		protected bool useInteractAction = true;

		[SerializeField]
		protected bool filterByAngle = true;

		[SerializeField]
		protected float maxAngle = 70f;

		[Header("Animation")]
		[SerializeField]
		protected string bottomDownParameter = "BottomDown";

		[SerializeField]
		protected string bottomUpParameter = "BottomUp";

		[SerializeField]
		protected string topDownParameter = "TopDown";

		[SerializeField]
		protected string topUpParameter = "TopUp";

		[SerializeField]
		protected string upParameter = "Up";

		[SerializeField]
		protected string downParameter = "Down";

		[Space(10f)]
		[SerializeField]
		protected string entryStateName = "Entry";

		[SerializeField]
		protected string exitStateName = "Exit";

		[SerializeField]
		protected string idleStateName = "Idle";

		protected Dictionary<Transform, Ladder> ladders = new Dictionary<Transform, Ladder>();

		protected LadderClimbState state;

		protected Ladder currentLadder;

		protected Vector3 targetPosition = Vector3.zero;

		protected int currentClimbingAnimation;

		protected bool forceExit;

		protected AnimatorStateInfo animatorStateInfo;

		protected bool isBottom;

		public override void CheckExitTransition()
		{
			if (forceExit)
			{
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
		}

		public override bool CheckEnterTransition(CharacterState fromState)
		{
			if (!base.CharacterActor.IsGrounded)
			{
				return false;
			}
			if (useInteractAction && !base.CharacterActions.interact.Started)
			{
				return false;
			}
			for (int i = 0; i < base.CharacterActor.Triggers.Count; i++)
			{
				Trigger trigger = base.CharacterActor.Triggers[i];
				Ladder orRegisterValue = ladders.GetOrRegisterValue(trigger.transform);
				if (!(orRegisterValue != null))
				{
					continue;
				}
				if (!useInteractAction && base.CharacterActor.WasGrounded && !trigger.firstContact)
				{
					return false;
				}
				currentLadder = orRegisterValue;
				float num = Vector3.Distance(base.CharacterActor.Position, currentLadder.TopReference.position);
				float num2 = Vector3.Distance(base.CharacterActor.Position, currentLadder.BottomReference.position);
				isBottom = num2 < num;
				if (filterByAngle)
				{
					Vector3 vector = base.CharacterActor.Position - currentLadder.transform.position;
					vector = Vector3.ProjectOnPlane(vector, currentLadder.transform.up);
					float num3 = Vector3.Angle(currentLadder.FacingDirectionVector, vector);
					if (isBottom)
					{
						if (num3 >= maxAngle)
						{
							return true;
						}
					}
					else if (num3 <= maxAngle)
					{
						return true;
					}
					continue;
				}
				return true;
			}
			return false;
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.CharacterActor.Velocity = Vector3.zero;
			base.CharacterActor.IsKinematic = true;
			base.CharacterActor.alwaysNotGrounded = true;
			currentClimbingAnimation = ((!isBottom) ? currentLadder.ClimbingAnimations : 0);
			targetPosition = (isBottom ? currentLadder.BottomReference.position : currentLadder.TopReference.position);
			base.CharacterActor.SetYaw(currentLadder.FacingDirectionVector);
			base.CharacterActor.Position = targetPosition;
			base.CharacterActor.SetUpRootMotion(updateRootPosition: true, PhysicsActor.RootMotionVelocityType.SetVelocity, updateRootRotation: false);
			base.CharacterActor.Animator.SetTrigger(isBottom ? bottomUpParameter : topDownParameter);
			state = LadderClimbState.Entering;
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			forceExit = false;
			base.CharacterActor.IsKinematic = false;
			base.CharacterActor.alwaysNotGrounded = false;
			currentLadder = null;
			base.CharacterStateController.ResetIKWeights();
			base.CharacterActor.Velocity = Vector3.zero;
			base.CharacterActor.ForceGrounded();
		}

		protected override void Awake()
		{
			base.Awake();
			Ladder[] array = Object.FindObjectsByType<Ladder>(FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				ladders.Add(array[i].transform, array[i]);
			}
		}

		protected override void Start()
		{
			base.Start();
			if (base.CharacterActor.Animator == null)
			{
				Debug.Log("The LadderClimbing state needs the character to have a reference to an Animator component. Destroying this state...");
				Object.Destroy(this);
			}
		}

		public override void UpdateBehaviour(float dt)
		{
			animatorStateInfo = base.CharacterActor.Animator.GetCurrentAnimatorStateInfo(0);
			switch (state)
			{
			case LadderClimbState.Entering:
				if (animatorStateInfo.IsName(idleStateName))
				{
					state = LadderClimbState.Idling;
				}
				break;
			case LadderClimbState.Idling:
				if (base.CharacterActions.interact.Started)
				{
					if (useInteractAction)
					{
						forceExit = true;
					}
				}
				else if (base.CharacterActions.movement.Up)
				{
					if (currentClimbingAnimation == currentLadder.ClimbingAnimations)
					{
						base.CharacterActor.Animator.SetTrigger(topUpParameter);
						state = LadderClimbState.Exiting;
					}
					else
					{
						base.CharacterActor.Animator.SetTrigger(upParameter);
						currentClimbingAnimation++;
						state = LadderClimbState.Climbing;
					}
				}
				else if (base.CharacterActions.movement.Down)
				{
					if (currentClimbingAnimation == 0)
					{
						base.CharacterActor.Animator.SetTrigger(bottomDownParameter);
						state = LadderClimbState.Exiting;
					}
					else
					{
						base.CharacterActor.Animator.SetTrigger(downParameter);
						currentClimbingAnimation--;
						state = LadderClimbState.Climbing;
					}
				}
				break;
			case LadderClimbState.Climbing:
				if (animatorStateInfo.IsName(idleStateName))
				{
					state = LadderClimbState.Idling;
				}
				break;
			case LadderClimbState.Exiting:
				if (animatorStateInfo.IsName(exitStateName))
				{
					forceExit = true;
					base.CharacterActor.ForceGrounded();
				}
				break;
			}
		}

		public override void UpdateIK(int layerIndex)
		{
			if (useIKOffsetValues)
			{
				UpdateIKElement(AvatarIKGoal.LeftFoot, leftFootOffset);
				UpdateIKElement(AvatarIKGoal.RightFoot, rightFootOffset);
				UpdateIKElement(AvatarIKGoal.LeftHand, leftHandOffset);
				UpdateIKElement(AvatarIKGoal.RightHand, rightHandOffset);
			}
		}

		private void UpdateIKElement(AvatarIKGoal avatarIKGoal, Vector3 offset)
		{
			base.CharacterActor.Animator.SetIKPositionWeight(avatarIKGoal, 0f);
			Vector3 iKPosition = base.CharacterActor.Animator.GetIKPosition(avatarIKGoal);
			base.CharacterActor.Animator.SetIKPositionWeight(avatarIKGoal, 1f);
			base.CharacterActor.Animator.SetIKPosition(avatarIKGoal, iKPosition + offset);
		}
	}
}
