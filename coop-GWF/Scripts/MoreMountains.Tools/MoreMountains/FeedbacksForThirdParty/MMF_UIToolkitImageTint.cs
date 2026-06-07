using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the image tint of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Image Tint")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitImageTint : MMF_UIToolkitColorBase
	{
		protected override void ApplyColor(Color newColor)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				visualElement.style.unityBackgroundImageTintColor = newColor;
				HandleMarkDirty(visualElement);
			}
		}

		protected override Color GetInitialColor()
		{
			return _visualElements[0].resolvedStyle.unityBackgroundImageTintColor;
		}
	}
}
