using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the background color of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Background Color")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitBackgroundColor : MMF_UIToolkitColorBase
	{
		protected override void ApplyColor(Color newColor)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				visualElement.style.backgroundColor = newColor;
				HandleMarkDirty(visualElement);
			}
		}

		protected override Color GetInitialColor()
		{
			return _visualElements[0].resolvedStyle.backgroundColor;
		}
	}
}
