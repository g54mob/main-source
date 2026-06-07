using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public abstract class AMonitorStep : ALocoTutorialStep
	{
		private bool conditionMet;

		private bool manualDismiss;

		private bool dismissPressed;

		private bool released;

		private bool strictDismiss;

		public AMonitorStep(TrainCar loco, AQuickTutorialMessage message, Transform attentionPoint, bool manualDismiss, Vector3 attentionOffset = default(Vector3), bool strictDismiss = false)
			: base(loco, message, QTSemantic.Monitor, attentionPoint, attentionOffset)
		{
			this.manualDismiss = manualDismiss;
			ShouldRecheck = false;
			this.strictDismiss = strictDismiss;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			conditionMet = false;
			dismissPressed = false;
			released = false;
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			if (conditionMet && manualDismiss && !VRManager.IsVREnabled())
			{
				InputManager.SetInteractConflictersEnabled(on: true);
			}
		}

		public override void ShowVisual()
		{
			if (Message != null)
			{
				string text = Message.GetMessage(GetVerb());
				TutorialHelper.SoundType soundType = TutorialHelper.SoundType.Regular;
				if (conditionMet && manualDismiss)
				{
					text += GetContinuePromptSuffix();
					soundType = TutorialHelper.SoundType.Acknowledge;
				}
				SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(text, AttentionPoint, AttentionOffset, localize: false, targetIsUI: false, soundType);
				shownFloatie = true;
			}
		}

		protected abstract bool CheckCondition();

		protected override bool InternalCheck()
		{
			if (!conditionMet || strictDismiss)
			{
				bool flag = conditionMet;
				conditionMet = CheckCondition();
				if (strictDismiss)
				{
					if (flag != conditionMet)
					{
						ShowVisual();
						if (!VRManager.IsVREnabled())
						{
							if (conditionMet)
							{
								InputManager.SetInteractConflictersEnabled(on: false);
							}
							else
							{
								InputManager.SetInteractConflictersEnabled(on: true);
							}
						}
					}
				}
				else if (conditionMet && manualDismiss)
				{
					ShowVisual();
					if (!VRManager.IsVREnabled())
					{
						InputManager.SetInteractConflictersEnabled(on: false);
					}
				}
			}
			if (manualDismiss && conditionMet)
			{
				if (!dismissPressed)
				{
					if (!released)
					{
						if (!InputManager.NewPlayer.GetButton(InputManager.Actions.Interact) && !SingletonBehaviour<TutorialHelper>.Instance.IsAnyVRContinueButtonPressed)
						{
							released = true;
						}
					}
					else if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Interact) || SingletonBehaviour<TutorialHelper>.Instance.IsAnyVRContinueButtonPressed)
					{
						SingletonBehaviour<TutorialHelper>.Instance.PlayClick();
						dismissPressed = true;
					}
				}
				return dismissPressed;
			}
			return conditionMet;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Monitor;
		}
	}
}
