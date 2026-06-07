using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you rotate an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Rotate")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitRotate : MMF_UIToolkitFloatBase
	{
		protected StyleRotate _styleRotate;

		protected override void SetValue(float newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				_styleRotate = new Rotate(newValue);
				visualElement.style.rotate = _styleRotate;
				HandleMarkDirty(visualElement);
			}
		}

		protected override float GetInitialValue()
		{
			return _visualElements[0].resolvedStyle.rotate.angle.value;
		}
	}
}
