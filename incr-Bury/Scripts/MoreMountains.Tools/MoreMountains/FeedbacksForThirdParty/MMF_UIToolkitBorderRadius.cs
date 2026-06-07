using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the border radius of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Border Radius")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitBorderRadius : MMF_UIToolkitFloatBase
	{
		[Tooltip("whether to modify the bottom left border radius or not")]
		public bool BottomLeft = true;

		[Tooltip("whether to modify the bottom right border radius or not")]
		public bool BottomRight = true;

		[Tooltip("whether to modify the top left border radius or not")]
		public bool TopLeft = true;

		[Tooltip("whether to modify the top right border radius or not")]
		public bool TopRight = true;

		protected override void SetValue(float newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				if (BottomLeft)
				{
					visualElement.style.borderBottomLeftRadius = newValue;
				}
				if (BottomRight)
				{
					visualElement.style.borderBottomRightRadius = newValue;
				}
				if (TopLeft)
				{
					visualElement.style.borderTopLeftRadius = newValue;
				}
				if (TopRight)
				{
					visualElement.style.borderTopRightRadius = newValue;
				}
				HandleMarkDirty(visualElement);
			}
		}

		protected override float GetInitialValue()
		{
			if (BottomLeft)
			{
				return _visualElements[0].resolvedStyle.borderBottomLeftRadius;
			}
			if (BottomRight)
			{
				return _visualElements[0].resolvedStyle.borderBottomRightRadius;
			}
			if (TopLeft)
			{
				return _visualElements[0].resolvedStyle.borderTopLeftRadius;
			}
			if (TopRight)
			{
				return _visualElements[0].resolvedStyle.borderTopRightRadius;
			}
			return _visualElements[0].resolvedStyle.borderBottomLeftRadius;
		}
	}
}
