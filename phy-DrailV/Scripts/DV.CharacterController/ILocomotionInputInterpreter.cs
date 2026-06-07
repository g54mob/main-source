using System;
using UnityEngine;

public interface ILocomotionInputInterpreter : IDisposable
{
	Vector2 LocomotionAxis { get; }

	bool SwimRequested { get; }

	bool JumpRequested { get; }

	bool CrouchRequested { get; }

	bool SittingRequested { get; }

	bool RunRequested { get; }

	bool ClimbLadderRequested { get; }

	Transform LadderClimbDirectionTransform { get; }

	LocomotionInputWrapper.LeanDirection LeanValue { get; }

	bool IsLeanPressed { get; }

	void ResetAxis(bool primary);

	bool ResetLean();

	void UpdateFrame();

	void SetLeanToggle(bool on);

	void SetCrouchToggle(bool on);

	void SetRunToggle(bool on);
}
