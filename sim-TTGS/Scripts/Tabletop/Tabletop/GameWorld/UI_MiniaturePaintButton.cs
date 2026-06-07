using System;
using Dhs5.Utility.Updates;
using Simulator;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_MiniaturePaintButton : NavButton, IActivable
	{
		[SerializeField]
		private CanvasGroup m_group;

		[SerializeField]
		private Image m_pressIndicatorImage;

		[SerializeField]
		private TextMeshProUGUI m_paintCountText;

		[SerializeField]
		private UI_CollectionMiniatureHoldButton m_holdButton;

		private UpdateTimelineInstanceHandle m_handle;

		public event Action Pressed;

		public void Paint()
		{
			this.Pressed?.Invoke();
		}

		private void UpdatePressState(float normalizedTime)
		{
			m_pressIndicatorImage.fillAmount = normalizedTime;
		}

		public void SetContent(int paintCount)
		{
			m_paintCountText.text = paintCount.ToString();
			m_paintCountText.enabled = paintCount > 0;
			base.Button.onClick.AddListener(Paint);
		}

		public void SetActive(bool active)
		{
			base.Button.onClick.RemoveListener(Paint);
			base.gameObject.SetActive(active);
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			base.OnSubmit(eventData);
			Paint();
		}
	}
}
