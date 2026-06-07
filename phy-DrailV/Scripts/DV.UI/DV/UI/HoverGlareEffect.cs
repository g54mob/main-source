using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class HoverGlareEffect : MonoBehaviour
	{
		private const float ALPHA_HOVERED = 0.5f;

		private const float ALPHA_UNHOVERED = 0.1f;

		private const float ANIM_DURATION = 0.1f;

		private readonly Vector3 SCALE_UNHOVERED = Vector3.one;

		private readonly Vector3 SCALE_HOVERED = Vector3.one * 1.3f;

		[SerializeField]
		protected List<Image> glareImages = new List<Image>();

		private Camera cam;

		private Canvas canvas;

		private bool hovered;

		private RectTransform rectTransform;

		protected Dictionary<Image, Coroutine> scaleCoros = new Dictionary<Image, Coroutine>();

		private void Awake()
		{
			canvas = GetComponentInParent<Canvas>();
			cam = GetComponentInParent<Camera>() ?? canvas?.worldCamera ?? Camera.main;
			rectTransform = GetComponent<RectTransform>();
		}

		private void OnEnable()
		{
			hovered = false;
			UpdateImages();
		}

		private void UpdateImages()
		{
			foreach (Image glareImage in glareImages)
			{
				glareImage.CrossFadeAlpha(hovered ? 0.5f : 0.1f, 0.1f, ignoreTimeScale: true);
				AnimateImageScale(glareImage, hovered ? SCALE_HOVERED : SCALE_UNHOVERED, 0.1f);
			}
		}

		private void Update()
		{
			bool flag = MouseInside();
			if (hovered && !flag)
			{
				Unhover();
			}
			else if (!hovered && flag)
			{
				Hover();
			}
		}

		private void Hover()
		{
			hovered = true;
			UpdateImages();
		}

		private void Unhover()
		{
			hovered = false;
			UpdateImages();
		}

		private bool MouseInside()
		{
			Camera camera = ((canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : cam);
			return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, camera);
		}

		protected void AnimateImageScale(Image image, Vector3 to, float animationTime)
		{
			if (scaleCoros.TryGetValue(image, out var value))
			{
				StopCoroutine(value);
				scaleCoros.Remove(image);
			}
			if (base.gameObject.activeInHierarchy)
			{
				scaleCoros[image] = StartCoroutine(AnimateImageScaleCoro(image, image.rectTransform.localScale, to, animationTime));
			}
			else
			{
				image.rectTransform.localScale = to;
			}
		}

		protected IEnumerator AnimateImageScaleCoro(Image image, Vector3 scaleFrom, Vector3 scaleTo, float animationTime)
		{
			image.gameObject.SetActive(value: true);
			float elapsedTime = 0f;
			yield return new WaitForEndOfFrame();
			while (elapsedTime < animationTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float t = Mathf.Clamp01(elapsedTime / animationTime);
				Vector3 localScale = Vector3.Lerp(scaleFrom, scaleTo, t);
				image.rectTransform.localScale = localScale;
				yield return null;
			}
			yield return null;
			scaleCoros.Remove(image);
		}
	}
}
