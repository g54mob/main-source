using System;
using AppsTools;
using Mandragora.Utils;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.FinalStates
{
	[Serializable]
	public class GradientColorFinalState
	{
		[SerializeField]
		private GradientColor gradientColor;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setTopAndBottomColors;

		[SerializeField]
		private Color finalTopColor = Color.white;

		[SerializeField]
		private Color finalBottomColor = Color.white;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setLeftAndRightColors;

		[SerializeField]
		private Color finalLeftColor = Color.white;

		[SerializeField]
		private Color finalRightColor = Color.white;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setVerticalOffset;

		[SerializeField]
		[Range(-1f, 1f)]
		private float finalVerticalOffset;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setHorizontalOffset;

		[SerializeField]
		[Range(-1f, 1f)]
		private float finalHorizontalOffset;

		public void ApplySettings()
		{
			if (setTopAndBottomColors)
			{
				gradientColor.colorTop = finalTopColor;
				gradientColor.colorBottom = finalBottomColor;
			}
			if (setLeftAndRightColors)
			{
				gradientColor.colorLeft = finalLeftColor;
				gradientColor.colorRight = finalRightColor;
			}
			if (setVerticalOffset)
			{
				gradientColor.gradientOffsetVertical = finalVerticalOffset;
			}
			if (setHorizontalOffset)
			{
				gradientColor.gradientOffsetHorizontal = finalHorizontalOffset;
			}
		}
	}
}
