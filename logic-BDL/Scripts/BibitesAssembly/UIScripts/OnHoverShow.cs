using System;
using System.Collections;
using LeanTween.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UIScripts
{
	public class OnHoverShow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public GameObject target;

		public float openDelay;

		public float closeDelay;

		public float fadeInDuration;

		public float fadeOutDuration;

		public UnityEvent onShow = new UnityEvent();

		public UnityEvent onHide = new UnityEvent();

		private bool hover;

		private float time;

		private CanvasGroup CG;

		private LTDescr tween;

		private void Awake()
		{
			if (!(target == null))
			{
				target.SetActive(value: false);
				CG = target.GetComponent<CanvasGroup>();
				if ((bool)CG)
				{
					CG.alpha = 0f;
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!(target == null))
			{
				if (Mathf.Approximately(openDelay, 0f))
				{
					hover = true;
					ShowElement();
				}
				else
				{
					StartCoroutine(WaitForHoverOpenDuration());
				}
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!(target == null))
			{
				if (Mathf.Approximately(closeDelay, 0f))
				{
					hover = false;
					HideElement();
				}
				else
				{
					StartCoroutine(WaitForHoverCloseDuration());
				}
			}
		}

		private IEnumerator WaitForHoverOpenDuration()
		{
			hover = true;
			time = 0f;
			while (hover && time < openDelay)
			{
				time += Time.unscaledDeltaTime;
				yield return null;
			}
			if (hover)
			{
				ShowElement();
			}
		}

		private IEnumerator WaitForHoverCloseDuration()
		{
			hover = false;
			time = 0f;
			while (!hover && time < closeDelay)
			{
				time += Time.unscaledDeltaTime;
				yield return null;
			}
			if (!hover)
			{
				HideElement();
			}
		}

		public void ShowElement()
		{
			target.SetActive(value: true);
			onShow.Invoke();
			if (CG == null)
			{
				return;
			}
			if (tween != null)
			{
				LeanTween.Framework.LeanTween.cancel(tween.id);
			}
			if (fadeInDuration > 0f)
			{
				tween = LeanTween.Framework.LeanTween.alphaCanvas(CG, 1f, fadeInDuration).setEaseOutSine().setOnComplete((Action)delegate
				{
					tween = null;
				})
					.setIgnoreTimeScale(useUnScaledTime: true);
			}
			else
			{
				CG.alpha = 1f;
			}
		}

		public void HideElement()
		{
			if (CG != null)
			{
				if (tween != null)
				{
					LeanTween.Framework.LeanTween.cancel(tween.id);
				}
				if (fadeOutDuration > 0f)
				{
					tween = LeanTween.Framework.LeanTween.alphaCanvas(CG, 0f, fadeOutDuration).setEaseInSine().setOnComplete(HideElementAfterFade)
						.setIgnoreTimeScale(useUnScaledTime: true);
					return;
				}
				target.SetActive(value: false);
				CG.alpha = 0f;
			}
			else
			{
				target.SetActive(value: false);
				onHide.Invoke();
			}
		}

		private void HideElementAfterFade()
		{
			if (!(target == null))
			{
				tween = null;
				target.SetActive(value: false);
				onHide.Invoke();
			}
		}
	}
}
