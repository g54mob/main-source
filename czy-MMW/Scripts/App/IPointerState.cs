using Factory;
using UnityEngine;

public interface IPointerState
{
	Vector2 Position { get; }

	Vector2 PositionDelta { get; }

	void Initialize(IScope scope);

	ButtonState GetButtonState(int buttonIndex);

	void SetButtonState(float appTime, int buttonIndex, InputEventButtonState newState);

	void MoveTo(float appTime, Vector2 position, PointerMoveToDeltaBehaviour deltaBehaviour = PointerMoveToDeltaBehaviour.CalculateDelta);

	void Tick(float appTime);

	Touch ToUnityTouch();
}
