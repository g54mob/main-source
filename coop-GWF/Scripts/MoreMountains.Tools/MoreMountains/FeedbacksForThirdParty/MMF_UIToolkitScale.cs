using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you scale an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Scale")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitScale : MMF_UIToolkitVector2Base
	{
		protected override void SetValue(Vector2 newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				visualElement.style.scale = new StyleScale(new Scale(newValue));
				HandleMarkDirty(visualElement);
			}
		}

		protected override Vector2 GetInitialValue()
		{
			return _visualElements[0].resolvedStyle.scale.value;
		}
	}
}
