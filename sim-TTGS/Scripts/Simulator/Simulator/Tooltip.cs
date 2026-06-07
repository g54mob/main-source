using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class Tooltip : MonoBehaviour, IActivable
	{
		[SerializeField]
		private RectTransform m_root;

		[SerializeField]
		private RectTransform m_layout;

		[SerializeField]
		private CanvasGroup m_group;

		[SerializeField]
		private SimulatorText m_text;

		private Tween m_activationTween;

		public bool IsActive { get; private set; }

		public virtual void SetTerm(string term)
		{
			m_text.SetTerm(term);
			if (base.gameObject.activeInHierarchy)
			{
				RefreshLayout();
			}
		}

		protected virtual void RefreshLayout()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_layout);
		}

		public void SetActive(bool active)
		{
			m_activationTween.Kill();
			IsActive = active;
			m_activationTween = m_group.DOFade(active ? 1 : 0, 0.1f).OnComplete(delegate
			{
				OnEndFade(active);
			});
			if (active)
			{
				OnSetActive();
			}
		}

		private void OnEndFade(bool active)
		{
			base.gameObject.SetActive(active);
		}

		protected virtual void OnSetActive()
		{
			RefreshLayout();
		}
	}
}
