using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class HoverEffect : MonoBehaviour
	{
		public Image targetImage;

		public Canvas targetCanvas;

		[HideInInspector]
		public float speed;

		[HideInInspector]
		public float transitionAlpha;

		[HideInInspector]
		public bool fadeIn;

		[HideInInspector]
		public bool fadeOut;

		private void Start()
		{
			if (targetCanvas == null)
			{
				targetCanvas = GetComponentInParent<Canvas>();
			}
		}

		private void Update()
		{
			if (targetCanvas != null && (targetCanvas.renderMode == RenderMode.ScreenSpaceCamera || targetCanvas.renderMode == RenderMode.WorldSpace))
			{
				ProcessPosition(targetCanvas.worldCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
			}
			else
			{
				ProcessPosition(Mouse.current.position.ReadValue());
			}
		}

		private void ProcessPosition(Vector2 pos)
		{
			targetImage.transform.position = pos;
		}

		public void StartFadeIn()
		{
			base.gameObject.SetActive(value: true);
			StopCoroutine("DoFadeOut");
			StopCoroutine("DoFadeIn");
			StartCoroutine("DoFadeIn");
		}

		public void StartFadeOut()
		{
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DoFadeOut");
				StopCoroutine("DoFadeIn");
				StartCoroutine("DoFadeOut");
			}
		}

		private IEnumerator DoFadeIn()
		{
			while (targetImage.color.a < transitionAlpha)
			{
				targetImage.color = Color.Lerp(targetImage.color, new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, transitionAlpha), Time.deltaTime * speed);
				yield return null;
			}
			targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, transitionAlpha);
		}

		private IEnumerator DoFadeOut()
		{
			while (targetImage.color.a > 0.01f)
			{
				targetImage.color = Color.Lerp(targetImage.color, new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0f), Time.deltaTime * speed);
				yield return null;
			}
			targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0f);
			base.gameObject.SetActive(value: false);
		}
	}
}
