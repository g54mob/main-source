using System;
using Rewired;
using UnityEngine;

internal interface CjjRDclXuvjouyeLLeBBHCfpqqbM : IDisposable, iflCBykpCtyCmFAlnduVbpFYFGW
{
	YlWFkSrNjhWjdvjHemdfYAMOisT NativeJoystick { get; }

	int JoystickId { get; }

	int ButtonCount { get; }

	int AxisCount { get; }

	int HatCount { get; }

	int BallCount { get; }

	bool HasElements { get; }

	InputSource InputSource { get; }

	bool HasEverReceivedInput { get; }

	float GetAxisValue(int P_0);

	int GetAxisRawValue(int P_0);

	bool GetButtonValue(int P_0);

	int GetHatValue(int P_0);

	Vector2 GetBallValue(int P_0);
}
