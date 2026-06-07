using System;
using Assets.Scripts.Flight.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class FadingMessageScriptXr : MonoBehaviour, IFadingMessage
	{
		private Image _background;

		private CanvasGroup _canvasGroup;

		private TextMeshProUGUI _label;

		private MessageManager.Message _message;

		[SerializeField]
		private Vector2 _padding = new Vector2(0.05f, 0.05f);

		public bool CanFloat => _message.CanFloat;

		public bool IsDead { get; private set; }

		public string MessageText => _message.Text;

		public void Destroy(bool immediate)
		{
			_canvasGroup.alpha = 0f;
			IsDead = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void ShowMessage(MessageManager.Message message)
		{
			_message = message;
			_label.text = message.Text;
			_label.ForceMeshUpdate(ignoreActiveState: true);
			Vector2 sizeDelta = (Vector2)_label.textBounds.size + new Vector2(_padding.x, _padding.y);
			_background.rectTransform.sizeDelta = sizeDelta;
			_label.rectTransform.sizeDelta = sizeDelta;
			_canvasGroup.alpha = 1f;
		}

		void IFadingMessage.Update(float deltaTime)
		{
			throw new NotImplementedException();
		}

		protected virtual void Awake()
		{
			_label = base.transform.Find("MessageLabel").GetComponent<TextMeshProUGUI>();
			_background = base.transform.Find("MessageBackground").GetComponent<Image>();
			_canvasGroup = GetComponent<CanvasGroup>();
			_canvasGroup.alpha = 0f;
		}

		protected virtual void Update()
		{
			if (_message != null && _message.Time > 0f)
			{
				_message.Time -= Time.deltaTime;
			}
			else if (_canvasGroup.alpha > 0f)
			{
				ReduceAlpha(Time.unscaledDeltaTime * 1f);
			}
			else
			{
				IsDead = true;
			}
		}

		private void ReduceAlpha(float amount)
		{
			float alpha = _canvasGroup.alpha;
			alpha -= amount;
			if (alpha < 0f)
			{
				alpha = 0f;
			}
			_canvasGroup.alpha = alpha;
		}
	}
}
