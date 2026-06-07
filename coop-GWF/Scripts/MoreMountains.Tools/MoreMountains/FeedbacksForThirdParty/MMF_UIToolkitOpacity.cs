using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the opacity of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Opacity")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitOpacity : MMF_UIToolkitFloatBase
	{
		protected override void SetValue(float newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				visualElement.style.opacity = newValue;
				HandleMarkDirty(visualElement);
			}
		}

		protected override float GetInitialValue()
		{
			return _visualElements[0].resolvedStyle.opacity;
		}
	}
}
