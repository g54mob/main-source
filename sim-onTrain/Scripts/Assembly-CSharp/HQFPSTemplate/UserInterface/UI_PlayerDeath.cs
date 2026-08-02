using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	[RequireComponent(typeof(CanvasGroup))]
	public class UI_PlayerDeath : UserInterfaceBehaviour
	{
		[SerializeField]
		private CanvasGroup m_CanvasGroup;

		[SerializeField]
		private float m_FadeSpeed = 1f;

		private Coroutine m_CanvasFader;

		private void Start()
		{
			DOVirtual.DelayedCall(1f, delegate
			{
				base.Player.Death.AddListener(OnPlayerDeath);
				base.Player.Respawn.AddListener(OnPlayerRespawn);
			});
		}

		private void OnPlayerDeath()
		{
			if (m_CanvasFader != null)
			{
				StopCoroutine(m_CanvasFader);
			}
			m_CanvasFader = StartCoroutine(FadeCanvasAlpha(0f));
		}

		private void OnPlayerRespawn()
		{
			if (m_CanvasFader != null)
			{
				StopCoroutine(m_CanvasFader);
			}
			m_CanvasFader = StartCoroutine(FadeCanvasAlpha(1f));
		}

		private IEnumerator FadeCanvasAlpha(float targetAlpha)
		{
			float currentAlpha = m_CanvasGroup.alpha;
			while (Mathf.Abs(currentAlpha - targetAlpha) > 0.001f)
			{
				currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, m_FadeSpeed * Time.deltaTime);
				m_CanvasGroup.alpha = currentAlpha;
				yield return null;
			}
		}
	}
}
