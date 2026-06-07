using System;

[Flags]
public enum TransitionCameraControl
{
	Position = 1,
	Rotation = 2,
	Scale = 4,
	Transform = 7
}
