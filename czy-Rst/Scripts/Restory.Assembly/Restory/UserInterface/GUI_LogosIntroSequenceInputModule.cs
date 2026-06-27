using System;
using System.Collections.Generic;
using Restory.UserInterface.Input;
using Rewired;
using UnityEngine;

namespace Restory.UserInterface
{
	public sealed class GUI_LogosIntroSequenceInputModule : GUI_BaseElementInputModule
	{
		[Serializable]
		private struct InputEntry
		{
			[RewiredActionsDropdown]
			public int Action;
		}

		[SerializeField]
		private GUI_LogosIntroSequence introSequence;

		[SerializeField]
		private List<InputEntry> currentLogoSkipActions = new List<InputEntry>();

		[SerializeField]
		private List<InputEntry> wholeSequenceSkipActions = new List<InputEntry>();

		protected override bool CanSubscribeInput()
		{
			return true;
		}

		protected override void OnSubscribeInput()
		{
			foreach (InputEntry currentLogoSkipAction in currentLogoSkipActions)
			{
				base.PlayerInput.AddInputEventDelegate(ResolveSkipCurrentLogoActionTriggered, InputActionEventType.ButtonJustPressed, currentLogoSkipAction.Action);
			}
			foreach (InputEntry wholeSequenceSkipAction in wholeSequenceSkipActions)
			{
				base.PlayerInput.AddInputEventDelegate(ResolveSkipWholeSequenceActionTriggered, InputActionEventType.ButtonJustPressed, wholeSequenceSkipAction.Action);
			}
		}

		protected override void OnUnsubscribeInput()
		{
			foreach (InputEntry currentLogoSkipAction in currentLogoSkipActions)
			{
				base.PlayerInput.RemoveInputEventDelegate(ResolveSkipCurrentLogoActionTriggered, InputActionEventType.ButtonJustPressed, currentLogoSkipAction.Action);
			}
			foreach (InputEntry wholeSequenceSkipAction in wholeSequenceSkipActions)
			{
				base.PlayerInput.RemoveInputEventDelegate(ResolveSkipWholeSequenceActionTriggered, InputActionEventType.ButtonJustPressed, wholeSequenceSkipAction.Action);
			}
		}

		private void ResolveSkipWholeSequenceActionTriggered(InputActionEventData _)
		{
			introSequence.SkipWholeSequence();
		}

		private void ResolveSkipCurrentLogoActionTriggered(InputActionEventData _)
		{
			introSequence.SkipCurrentLogo();
		}
	}
}
