using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class MarkEffect : MonoBehaviour
	{
		private const string MARK_IMAGE_NAME = "[image select]";

		private const float MARK_ANIM_DURATION = 0.1f;

		private IMarkable markable;

		private Image markImage;

		private void Awake()
		{
			markable = GetComponent<IMarkable>();
			markImage = Util.FindInChildren<Image>(base.gameObject, "[image select]");
			markImage.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
			SetupListeners(on: true);
		}

		private void OnEnable()
		{
			markImage.canvasRenderer.SetAlpha(markable.IsMarked ? 1 : 0);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				markable.MarkChanged += OnMarkChanged;
			}
			else
			{
				markable.MarkChanged -= OnMarkChanged;
			}
		}

		private void OnMarkChanged(IHoverable _ = null)
		{
			if (markable.IsMarked)
			{
				markImage.gameObject.SetActive(value: true);
			}
			else
			{
				DisableAfterAnimationFinishes();
			}
			markImage.CrossFadeAlpha(markable.IsMarked ? 1 : 0, 0.1f, ignoreTimeScale: true);
		}

		private void DisableAfterAnimationFinishes()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				markImage.gameObject.SetActive(value: false);
			}
			else
			{
				StartCoroutine(DisableAfterAnimationFinishesCoro());
			}
		}

		private IEnumerator DisableAfterAnimationFinishesCoro()
		{
			yield return WaitFor.SecondsRealtime(0.1f);
			markImage.gameObject.SetActive(value: false);
		}
	}
}
