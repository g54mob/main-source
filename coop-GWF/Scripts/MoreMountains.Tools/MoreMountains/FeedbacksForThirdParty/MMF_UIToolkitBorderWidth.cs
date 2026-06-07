using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the border width of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Border Width")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitBorderWidth : MMF_UIToolkitFloatBase
	{
		[Tooltip("whether to modify the left border width or not")]
		public bool Left = true;

		[Tooltip("whether to modify the right border width or not")]
		public bool Right = true;

		[Tooltip("whether to modify the top border width or not")]
		public bool Top = true;

		[Tooltip("whether to modify the bottom border width or not")]
		public bool Bottom = true;

		protected override void SetValue(float newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				if (Left)
				{
					visualElement.style.borderLeftWidth = newValue;
				}
				if (Right)
				{
					visualElement.style.borderRightWidth = newValue;
				}
				if (Bottom)
				{
					visualElement.style.borderBottomWidth = newValue;
				}
				if (Top)
				{
					visualElement.style.borderTopWidth = newValue;
				}
				HandleMarkDirty(visualElement);
			}
		}

		protected override float GetInitialValue()
		{
			if (Left)
			{
				return _visualElements[0].resolvedStyle.borderLeftWidth;
			}
			if (Right)
			{
				return _visualElements[0].resolvedStyle.borderRightWidth;
			}
			if (Bottom)
			{
				return _visualElements[0].resolvedStyle.borderBottomWidth;
			}
			if (Top)
			{
				return _visualElements[0].resolvedStyle.borderTopWidth;
			}
			return _visualElements[0].resolvedStyle.borderLeftWidth;
		}
	}
}
