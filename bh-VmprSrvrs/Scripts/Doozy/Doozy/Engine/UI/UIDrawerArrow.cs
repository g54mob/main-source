using System;
using Doozy.Engine.Touchy;
using UnityEngine;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIDrawerArrow
	{
		[Serializable]
		public class Holder
		{
			public RectTransform Closed;

			public RectTransform Opened;

			public RectTransform Root;

			public Vector3 ClosedLocalPosition => default(Vector3);

			public Vector3 OpenedLocalPosition => default(Vector3);

			public Holder(RectTransform parent)
			{
			}

			public void Reset(RectTransform parent)
			{
			}
		}

		private const bool DEFAULT_ENABLED = true;

		private const bool DEFAULT_OVERRIDE_COLOR = false;

		private const float DEFAULT_SCALE = 1f;

		private static readonly Color DefaultOpenedColor;

		private static readonly Color DefaultClosedColor;

		public UIDrawerArrowAnimator Animator;

		public Color ClosedColor;

		public RectTransform Container;

		public Holder Down;

		public bool Enabled;

		public Holder Left;

		public Color OpenedColor;

		public bool OverrideColor;

		public Holder Right;

		public float Scale;

		public Holder Up;

		public Holder GetHolder(SimpleSwipe closeDirection)
		{
			return null;
		}

		private void Reset()
		{
		}

		public void ResetArrowClosedPosition(SimpleSwipe closeDirection)
		{
		}

		public static void ResetArrowClosedPosition(RectTransform closed, SimpleSwipe closeDirection)
		{
		}

		public void ResetArrowOpenedPosition(SimpleSwipe closeDirection)
		{
		}

		public static void ResetArrowOpenedPosition(RectTransform opened, SimpleSwipe closeDirection)
		{
		}

		public void ResetArrowRootPosition(SimpleSwipe closeDirection)
		{
		}

		public static void ResetArrowRootPosition(RectTransform root, SimpleSwipe closeDirection)
		{
		}
	}
}
