using UnityEngine;

namespace JUTPSActions
{
	public class JUTPSAnimatedAction : JUTPSAction
	{
		public enum ActionPart
		{
			RightArm = 0,
			BothArms = 1,
			FullBody = 2,
			Legs = 3,
			Torso = 4
		}

		protected enum StateOfAction
		{
			None = 0,
			Started = 1,
			Playing = 2,
			Ended = 3
		}

		private int ActionCurrentLayerIndex = 5;

		protected float LayerWeight;

		public float ActionDuration;

		private float ActionCurrentTime;

		public float EnterTransitionSpeed;

		public float ExitTransitionSpeed;

		[SerializeField]
		protected StateOfAction ActionState;

		protected bool NoneAction = true;

		protected bool ActionStarted;

		protected bool IsActionPlaying;

		protected bool ActionEnded;

		protected int LasUsedItemID;

		public void StartAction()
		{
			ActionStarted = true;
			ActionCurrentTime = 0f;
		}

		protected void Action()
		{
			anim.SetLayerWeight(ActionCurrentLayerIndex, LayerWeight);
			if (!ActionStarted)
			{
				ActionState = StateOfAction.None;
				LayerWeight = Mathf.MoveTowards(LayerWeight, 0f, ExitTransitionSpeed * Time.deltaTime);
				return;
			}
			if (ActionCurrentTime < ActionDuration)
			{
				ActionCurrentTime += Time.deltaTime;
			}
			switch (ActionState)
			{
			case StateOfAction.Started:
				LayerWeight = Mathf.MoveTowards(LayerWeight, 0f, ExitTransitionSpeed * Time.deltaTime);
				break;
			case StateOfAction.Playing:
				LayerWeight = Mathf.MoveTowards(LayerWeight, 1f, EnterTransitionSpeed * Time.deltaTime);
				break;
			case StateOfAction.Ended:
				LayerWeight = Mathf.MoveTowards(LayerWeight, 0f, ExitTransitionSpeed * Time.deltaTime);
				break;
			}
			if (ActionCurrentTime > 0f && !IsActionPlaying)
			{
				ActionState = StateOfAction.Started;
				IsActionPlaying = true;
				OnActionStarted();
			}
			if (ActionCurrentTime > 0.001f && ActionCurrentTime < ActionDuration)
			{
				ActionState = StateOfAction.Playing;
				IsActionPlaying = true;
				NoneAction = false;
				OnActionIsPlaying();
			}
			if (ActionCurrentTime > ActionDuration && !ActionEnded)
			{
				ActionState = StateOfAction.Ended;
				ActionEnded = true;
				ActionCurrentTime = 0f;
				OnActionEnded();
			}
			if (ActionCurrentTime == 0f && ActionEnded)
			{
				ActionState = StateOfAction.None;
				ActionStarted = false;
				IsActionPlaying = false;
				ActionEnded = false;
				NoneAction = true;
				ActionCurrentTime = 0f;
				OnNoAction();
			}
		}

		public virtual void ActionCondition()
		{
		}

		public virtual void OnActionStarted()
		{
		}

		public virtual void OnActionIsPlaying()
		{
		}

		public virtual void OnActionEnded()
		{
		}

		public virtual void OnNoAction()
		{
		}

		public virtual void Update()
		{
			ActionCondition();
			Action();
		}

		protected void PlayAnimation(string AnimationStateName, int LayerID = -1, float normalizedTime = 0f)
		{
			if (LayerID > -1)
			{
				anim.Play(AnimationStateName, LayerID, normalizedTime);
			}
			else
			{
				anim.Play(AnimationStateName, ActionCurrentLayerIndex, normalizedTime);
			}
		}

		protected void SwitchAnimationLayer(ActionPart BodyPartLayer)
		{
			ActionCurrentLayerIndex = (int)(BodyPartLayer + 7);
		}

		protected int GetCurrentAnimationLayer()
		{
			return ActionCurrentLayerIndex;
		}

		protected void DisableCharacterMovement(float duration = 0f)
		{
			if (!(TPSCharacter == null))
			{
				TPSCharacter.DisableLocomotion(duration);
			}
		}

		protected void SetCurrentItemIndexToLastUsedItem()
		{
			if (TPSCharacter.HoldableItemInUseRightHand != null)
			{
				LasUsedItemID = TPSCharacter.HoldableItemInUseRightHand.ItemSwitchID;
			}
			else
			{
				LasUsedItemID = -1;
			}
		}

		protected void DisableItemOnHand()
		{
			TPSCharacter.SwitchToItem();
		}

		protected void EnableLastUsedItem()
		{
			TPSCharacter.SwitchToItem(LasUsedItemID);
		}
	}
}
