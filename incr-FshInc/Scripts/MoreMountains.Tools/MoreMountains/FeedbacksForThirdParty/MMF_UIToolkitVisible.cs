using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you set the visibility of an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Visible")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit", null)]
	public class MMF_UIToolkitVisible : MMF_UIToolkitBoolBase
	{
		public enum Modes
		{
			Set = 0,
			Toggle = 1
		}

		[Header("Visible")]
		[Tooltip("the selected mode (set : sets the object visible or not, toggle : toggles the object's visibility)")]
		public Modes Mode;

		[Tooltip("whether to set the object visible (true) or not")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public bool Visible;

		protected override void SetValue()
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				switch (Mode)
				{
				case Modes.Set:
					visualElement.visible = Visible;
					break;
				case Modes.Toggle:
					visualElement.visible = !visualElement.visible;
					break;
				}
				HandleMarkDirty(visualElement);
			}
		}

		protected override void SetValue(bool newValue)
		{
			foreach (VisualElement visualElement in _visualElements)
			{
				visualElement.visible = newValue;
				HandleMarkDirty(visualElement);
			}
		}

		protected override bool GetInitialValue()
		{
			return _visualElements[0].visible;
		}
	}
}
