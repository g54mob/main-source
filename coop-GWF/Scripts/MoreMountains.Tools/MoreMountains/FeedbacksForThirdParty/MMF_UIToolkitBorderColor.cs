using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the border color of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Border Color")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitBorderColor : MMF_UIToolkitColorBase
	{
		[MMFInspectorGroup("Borders", true, 55, true, false)]
		[Tooltip("whether or not the feedback should modify the color of the left border")]
		public bool BorderLeft = true;

		[Tooltip("whether or not the feedback should modify the color of the right border")]
		public bool BorderRight = true;

		[Tooltip("whether or not the feedback should modify the color of the bottom border")]
		public bool BorderBottom = true;

		[Tooltip("whether or not the feedback should modify the color of the top border")]
		public bool BorderTop = true;

		protected override void ApplyColor(Color newColor)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				if (BorderLeft)
				{
					visualElement.style.borderLeftColor = newColor;
				}
				if (BorderRight)
				{
					visualElement.style.borderRightColor = newColor;
				}
				if (BorderBottom)
				{
					visualElement.style.borderBottomColor = newColor;
				}
				if (BorderTop)
				{
					visualElement.style.borderTopColor = newColor;
				}
				HandleMarkDirty(visualElement);
			}
		}

		protected override Color GetInitialColor()
		{
			if (BorderLeft)
			{
				return _visualElements[0].resolvedStyle.borderLeftColor;
			}
			if (BorderRight)
			{
				return _visualElements[0].resolvedStyle.borderRightColor;
			}
			if (BorderBottom)
			{
				return _visualElements[0].resolvedStyle.borderBottomColor;
			}
			if (BorderTop)
			{
				return _visualElements[0].resolvedStyle.borderTopColor;
			}
			return Color.black;
		}
	}
}
