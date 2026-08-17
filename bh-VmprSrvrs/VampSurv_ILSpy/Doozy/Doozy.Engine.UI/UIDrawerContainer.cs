using System;
using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.UI;

[Serializable]
public class UIDrawerContainer : UIContainer
{
	private const UIDrawerContainerSize DEFAULT_CONTAINER_SIZE = UIDrawerContainerSize.PercentageOfScreen;

	private const bool DEFAULT_FADE_OUT = true;

	private const float DEFAULT_FIXED_SIZE = 128f;

	private const float DEFAULT_MINIMUM_SIZE = 128f;

	private const float DEFAULT_PERCENTAGE_OF_SCREEN_SIZE = 0.5f;

	public Vector2 CalculatedSize;

	public Vector3 ClosedPosition;

	public Vector3 CurrentPosition;

	public bool FadeOut;

	public float FixedSize;

	public float MinimumSize;

	public Vector3 OpenedPosition;

	public float PercentageOfScreen;

	public Vector3 PreviousPosition;

	public UIDrawerContainerSize Size;

	public Vector2 Velocity
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public UIDrawerContainer()
	{
		Reset();
	}

	public override void Reset()
	{
		DisableCanvas = true;
		Size = UIDrawerContainerSize.PercentageOfScreen;
		PercentageOfScreen = 0.5f;
		MinimumSize = 128f;
		FixedSize = 128f;
		FadeOut = true;
	}
}
