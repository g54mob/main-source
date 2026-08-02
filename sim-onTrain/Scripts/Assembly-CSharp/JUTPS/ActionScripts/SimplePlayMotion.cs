using JUTPS.InputEvents;
using JUTPSActions;
using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.ActionScripts
{
	[AddComponentMenu("JU TPS/Third Person System/Actions/Simple Play Motion")]
	public class SimplePlayMotion : JUTPSAnimatedAction
	{
		[JUHeader("Animation Parameter")]
		public ActionPart TargetLayer = ActionPart.FullBody;

		public string AnimatorStateName = "";

		[Range(0f, 1f)]
		public float StartMotionAt;

		public InputEvent InputToCallAction;

		[JUHeader("Options")]
		public bool ForceFireMode;

		public bool ForceNoFireMode;

		public bool BlockCharacterLocomotion;

		public bool StartActionEvenStateIsPlaying;

		private void Start()
		{
			SwitchAnimationLayer(TargetLayer);
			InputToCallAction.SetupListeners();
			InputToCallAction.OnInputPerformed.AddListener(TryStartAction);
		}

		public void TryStartAction()
		{
			if (!IsActionPlaying || StartActionEvenStateIsPlaying)
			{
				StartAction();
				PlayAnimation(AnimatorStateName, GetCurrentAnimationLayer(), StartMotionAt);
			}
		}

		public override void OnActionStarted()
		{
			if (BlockCharacterLocomotion)
			{
				TPSCharacter.disableMove();
			}
		}

		public override void OnActionEnded()
		{
			if (BlockCharacterLocomotion)
			{
				TPSCharacter.enableMove();
			}
		}

		private void LateUpdate()
		{
			if (IsActionPlaying)
			{
				if (ForceFireMode)
				{
					TPSCharacter.FiringMode = true;
				}
				if (ForceNoFireMode)
				{
					TPSCharacter.FiringMode = false;
				}
			}
		}
	}
}
