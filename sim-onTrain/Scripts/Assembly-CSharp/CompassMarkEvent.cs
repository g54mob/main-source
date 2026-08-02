using System;
using UnityEngine;

public class CompassMarkEvent
{
	public static Action<CompassMark> CompassMarkAction;

	public static Action<Transform> ChangeCompassCameraAction;

	public static Action<Transform> ActionDestroyMark;

	public static Action<Transform, bool> ActionShowMark;

	public static void SetCompassMark(CompassMark mark)
	{
		if (CompassMarkAction != null)
		{
			CompassMarkAction(mark);
		}
	}

	public static void SetCompassCamera(Transform Camera)
	{
		if (ChangeCompassCameraAction != null)
		{
			ChangeCompassCameraAction(Camera);
		}
	}

	public static void DestroyMark(Transform mark)
	{
		if (ActionDestroyMark != null)
		{
			ActionDestroyMark(mark);
		}
	}

	public static void ShowMark(Transform mark, bool show)
	{
		if (ActionShowMark != null)
		{
			ActionShowMark(mark, show);
		}
	}
}
