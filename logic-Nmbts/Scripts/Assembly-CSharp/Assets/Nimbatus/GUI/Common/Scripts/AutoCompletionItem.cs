using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class AutoCompletionItem : MonoBehaviour
	{
		public UILabel Label;

		public UIButtonColor Color;

		private SimpleInputLabel _originLabel;

		public void Init(SimpleInputLabel originLabel, string text)
		{
			_originLabel = originLabel;
			Label.text = text;
		}

		public void OnClick()
		{
			if (!string.IsNullOrEmpty(Label.text))
			{
				_originLabel.CurrentText = Label.text;
				_originLabel.ResetAutoCompletion();
			}
		}

		public void SetSelected(bool selected)
		{
			Color.SetState(selected ? UIButtonColor.State.Hover : UIButtonColor.State.Disabled, true);
		}
	}
}
