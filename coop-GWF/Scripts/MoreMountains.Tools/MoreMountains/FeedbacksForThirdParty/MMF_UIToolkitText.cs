using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the text an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Text")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitText : MMF_UIToolkit
	{
		[Header("Text")]
		[Tooltip("the new text to set on the target object(s)")]
		public string NewText = "";

		protected string _initialText;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			SetValue(NewText);
		}

		protected virtual void SetValue(string newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				(visualElement as TextElement).text = newValue;
				HandleMarkDirty(visualElement);
			}
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (_visualElements != null && _visualElements.Count != 0)
			{
				_initialText = GetInitialValue();
			}
		}

		protected virtual string GetInitialValue()
		{
			return (_visualElements[0] as TextElement).text;
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				SetValue(_initialText);
			}
		}
	}
}
