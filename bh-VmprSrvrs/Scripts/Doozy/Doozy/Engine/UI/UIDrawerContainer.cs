using System;
using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.UI
{
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

		public Vector2 Velocity => default(Vector2);

		public override void Reset()
		{
		}
	}
}
