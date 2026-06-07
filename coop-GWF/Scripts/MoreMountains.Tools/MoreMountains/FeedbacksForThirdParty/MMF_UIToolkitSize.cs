using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the size an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Size")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitSize : MMF_UIToolkitVector2Base
	{
		protected override void SetValue(Vector2 newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				visualElement.style.width = newValue.x;
				visualElement.style.height = newValue.y;
				HandleMarkDirty(visualElement);
			}
		}

		protected override Vector2 GetInitialValue()
		{
			return new Vector2(_visualElements[0].resolvedStyle.width, _visualElements[0].resolvedStyle.height);
		}
	}
}
