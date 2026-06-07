using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the font size of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Font Size")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitFontSize : MMF_UIToolkitFloatBase
	{
		protected override void SetValue(float newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				int num = Mathf.FloorToInt(newValue);
				visualElement.style.fontSize = num;
				HandleMarkDirty(visualElement);
			}
		}

		protected override float GetInitialValue()
		{
			return _visualElements[0].resolvedStyle.fontSize;
		}
	}
}
