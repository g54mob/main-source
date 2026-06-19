using System;
using UnityEngine;

public class AnimationAuthoring : MonoBehaviour
{
	[Flags]
	public enum OrientationSupport
	{
		None = 0,
		Horizontal = 1,
		Vertical = 2,
		EightDirections = 4
	}

	[Header("Indicates if the object's animation needs support for orientation data.")]
	public OrientationSupport orientationSupport;

	public bool largeAnimationHistorySupport;
}
