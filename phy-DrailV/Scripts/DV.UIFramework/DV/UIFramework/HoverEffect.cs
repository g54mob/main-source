using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class HoverEffect : MonoBehaviour
	{
		private const string HOVER_IMAGE_NAME = "[image hover]";

		private const float HOVER_ANIM_DURATION = 0.1f;

		private IHoverable hoverable;

		private Image hoverImage;

		private Coroutine disableCoro;

		private void Awake()
		{
			hoverable = GetComponent<IHoverable>();
			hoverImage = Util.FindInChildren<Image>(base.gameObject, "[image hover]");
			hoverImage.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
			SetupListeners(on: true);
		}

		private void OnEnable()
		{
			hoverImage.canvasRenderer.SetAlpha(hoverable.IsHovered ? 1 : 0);
		}

		private void OnDisable()
		{
			disableCoro = null;
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				hoverable.HoverChanged += OnHoverChanged;
			}
			else
			{
				hoverable.HoverChanged -= OnHoverChanged;
			}
		}

		private void OnHoverChanged(IHoverable _ = null)
		{
			if (disableCoro != null)
			{
				StopCoroutine(disableCoro);
				disableCoro = null;
			}
			if (hoverable.IsHovered)
			{
				hoverImage.gameObject.SetActive(value: true);
			}
			else
			{
				DisableAfterAnimationFinishes();
			}
			hoverImage.CrossFadeAlpha(hoverable.IsHovered ? 1 : 0, 0.1f, ignoreTimeScale: true);
		}

		private void DisableAfterAnimationFinishes()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				hoverImage.gameObject.SetActive(value: false);
			}
			else
			{
				disableCoro = StartCoroutine(DisableAfterAnimationFinishesCoro());
			}
		}

		private IEnumerator DisableAfterAnimationFinishesCoro()
		{
			yield return WaitFor.SecondsRealtime(0.1f);
			hoverImage.gameObject.SetActive(value: false);
			disableCoro = null;
		}
	}
}
