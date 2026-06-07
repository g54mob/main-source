using Assets.Scripts.Tutorials;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class TutorialMessageScriptXr : MonoBehaviour, ITutorialMessage
	{
		[SerializeField]
		private Image _background;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private Button _continueButton;

		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private Vector2 _padding = new Vector2(0.05f, 0.05f);

		public GameObject GameObject => base.gameObject;

		public bool ShowContinueButton { get; private set; }

		public void OnContinueButtonClicked()
		{
			TutorialScript.Current?.FocusedRequirement?.OnContinueButtonClicked();
		}

		public void SetFade(float fade)
		{
			_canvasGroup.alpha = fade;
		}

		public void SetText(string text, bool showContinueButton)
		{
			_label.text = text;
			_label.ForceMeshUpdate(ignoreActiveState: true);
			Vector2 sizeDelta = (Vector2)_label.textBounds.size + new Vector2(_padding.x, _padding.y);
			((RectTransform)_background.rectTransform.parent).sizeDelta = sizeDelta;
			ShowContinueButton = showContinueButton;
			_canvasGroup.blocksRaycasts = showContinueButton;
			_continueButton.gameObject.SetActive(showContinueButton);
		}

		protected virtual void Start()
		{
			SetText(_label.text, ShowContinueButton);
		}
	}
}
