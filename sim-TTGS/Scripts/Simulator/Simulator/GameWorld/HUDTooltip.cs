using DG.Tweening;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class HUDTooltip : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private CanvasGroup m_canvasGroup;

		[SerializeField]
		private SimulatorText m_simulatorText;

		[Header("Delays")]
		[SerializeField]
		private float m_canvasFadeDuration = 0.25f;

		[SerializeField]
		private float m_delayShowTooltip = 0.5f;

		private Tween m_canvasTween;

		private DelayedCallHandle m_handle;

		private bool m_isShown;

		public void ShowTooltip(string key = null)
		{
			m_handle.Kill();
			base.gameObject.SetActive(value: true);
			m_canvasGroup.alpha = 0f;
			Updater.CallInXSeconds(m_delayShowTooltip, delegate
			{
				ShowValue(show: true, key);
			}, out m_handle);
			m_isShown = true;
		}

		public void HideTooltip()
		{
			m_handle.Kill();
			ShowValue(show: false, null);
			m_isShown = false;
		}

		private void ShowValue(bool show, string key)
		{
			m_canvasTween?.Kill();
			m_canvasTween = m_canvasGroup.DOFade(show ? 1 : 0, m_canvasFadeDuration).OnComplete(SetActive);
			if (show)
			{
				m_simulatorText.SetTerm(key);
			}
		}

		private void SetActive()
		{
			base.gameObject.SetActive(m_isShown);
		}
	}
}
