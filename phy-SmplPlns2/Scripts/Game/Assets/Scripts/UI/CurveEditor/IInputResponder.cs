namespace Assets.Scripts.UI.CurveEditor
{
	public interface IInputResponder
	{
		InputResponderDelegates.IsRespondingDelegate IsResponding { get; set; }

		string Name { get; }

		int Priority { get; }

		InputResponderDelegates.InputResponderDelegate OnBeginDrag { get; set; }

		InputResponderDelegates.InputPinchResponderDelegate OnBeginPinch { get; set; }

		InputResponderDelegates.InputSelectionResponderDelegate OnDeselect { get; set; }

		InputResponderDelegates.InputResponderDelegate OnDrag { get; set; }

		InputResponderDelegates.InputResponderDelegate OnDrop { get; set; }

		InputResponderDelegates.InputResponderDelegate OnEndDrag { get; set; }

		InputResponderDelegates.InputPinchResponderDelegate OnEndPinch { get; set; }

		InputResponderDelegates.InputResponderDelegate OnInitializePotentialDrag { get; set; }

		InputResponderDelegates.InputPinchResponderDelegate OnPinch { get; set; }

		InputResponderDelegates.InputResponderDelegate OnPointerClick { get; set; }

		InputResponderDelegates.InputResponderDelegate OnPointerDown { get; set; }

		InputResponderDelegates.InputResponderDelegate OnPointerUp { get; set; }

		InputResponderDelegates.InputResponderDelegate OnScroll { get; set; }

		InputResponderDelegates.InputSelectionResponderDelegate OnSelect { get; set; }
	}
}
