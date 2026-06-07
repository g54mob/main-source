using System.Collections;
using LeanTween.Framework;
using UnityEngine;

namespace UIScripts
{
	public abstract class TemporarySettingsPreviewer : SettingPreviewer
	{
		[SerializeField]
		protected CanvasGroup previewPanel;

		[SerializeField]
		private float transitionTime = 0.25f;

		[SerializeField]
		private float closeDelay = 5f;

		private bool isOn;

		private Coroutine closePreview;

		public bool blocked;

		private LTDescr closeLT;

		public override void InitializePreview()
		{
			if (!initialized)
			{
				previewPanel.alpha = 0f;
				previewPanel.gameObject.SetActive(value: false);
				base.InitializePreview();
			}
		}

		protected sealed override void UpdatePreview()
		{
			if (blocked)
			{
				return;
			}
			previewPanel.gameObject.SetActive(value: true);
			if (initialized)
			{
				if (!isOn)
				{
					LeanTween.Framework.LeanTween.alphaCanvas(previewPanel, 1f, transitionTime).setOnComplete(DoneOpening);
				}
				isOn = true;
				UpdatePreviewVisual();
				if (closePreview != null)
				{
					StopCoroutine(closePreview);
				}
				closePreview = StartCoroutine(ClosePreview(closeDelay));
			}
		}

		public abstract void UpdatePreviewVisual();

		public virtual void DoneOpening()
		{
		}

		private IEnumerator ClosePreview(float delay)
		{
			yield return new WaitForSeconds(delay);
			closeLT = previewPanel.LeanAlpha(0f, transitionTime).setOnComplete(OnClosePreviewComplete);
		}

		public void SetBlocked(bool val)
		{
			blocked = val;
			if (blocked)
			{
				if (closePreview != null)
				{
					StopCoroutine(closePreview);
				}
				if (closeLT != null)
				{
					closeLT.updateNow();
				}
				OnClosePreviewComplete();
			}
		}

		private void OnClosePreviewComplete()
		{
			previewPanel.gameObject.SetActive(value: false);
		}

		private void OnMouseOver()
		{
			if (closePreview != null)
			{
				StopCoroutine(closePreview);
			}
		}
	}
}
