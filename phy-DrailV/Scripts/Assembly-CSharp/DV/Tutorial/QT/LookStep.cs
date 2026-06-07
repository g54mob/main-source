using System;
using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LookStep : AQuickTutorialStep
	{
		private enum State
		{
			Initial = 0,
			LookedAt = 1,
			Acknowledged = 2
		}

		private State state;

		private float angleDelta = 30f;

		private string acknowledgePrompt = string.Empty;

		private bool shownVisual;

		private bool released;

		public LookStep(ControlIconQuickTutorialMessage message, Transform attentionPoint, Vector3 attentionOffset = default(Vector3), float angleDelta = 30f)
			: base(message, attentionPoint, attentionOffset)
		{
			this.angleDelta = angleDelta;
			ShouldRecheck = false;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			shownVisual = false;
			released = false;
			if (CheckLook())
			{
				state = State.LookedAt;
				if (!VRManager.IsVREnabled())
				{
					InputManager.SetInteractConflictersEnabled(on: false);
				}
			}
			else
			{
				state = State.Initial;
			}
		}

		public override void ShowVisual()
		{
			if (state == State.Initial)
			{
				if (shownVisual)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
				}
				shownVisual = true;
				SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(Message.GetMessage(GetVerb()), AttentionPoint, AttentionOffset, localize: false);
			}
			else if (state == State.LookedAt)
			{
				if (shownVisual)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
				}
				shownVisual = true;
				SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(Message.GetMessage(GetVerb()) + GetContinuePromptSuffix(), AttentionPoint, AttentionOffset, localize: false, targetIsUI: false, TutorialHelper.SoundType.Acknowledge);
			}
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			if (shownVisual)
			{
				SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			}
			if (!VRManager.IsVREnabled() && state != State.Initial)
			{
				InputManager.SetInteractConflictersEnabled(on: true);
			}
		}

		private bool CheckLook()
		{
			if (PlayerManager.PlayerCamera == null)
			{
				return false;
			}
			Vector3 forward = Camera.main.transform.forward;
			Vector3 normalized = (AttentionPoint.position - Camera.main.transform.position).normalized;
			return Mathf.Acos(Vector3.Dot(forward, normalized)) < angleDelta * ((float)Math.PI / 180f);
		}

		protected override void HideVisual()
		{
			if (shownVisual)
			{
				if ((bool)SingletonBehaviour<TutorialHelper>.Instance)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie(state == State.Acknowledged);
				}
				shownVisual = false;
			}
		}

		protected override bool InternalCheck()
		{
			if (state == State.Initial && CheckLook())
			{
				state = State.LookedAt;
				if (shownVisual)
				{
					ShowVisual();
				}
				if (!VRManager.IsVREnabled())
				{
					InputManager.SetInteractConflictersEnabled(on: false);
				}
			}
			if (state == State.LookedAt)
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
					state = State.Acknowledged;
					HideVisual();
				}
			}
			return state == State.Acknowledged;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Look;
		}
	}
}
