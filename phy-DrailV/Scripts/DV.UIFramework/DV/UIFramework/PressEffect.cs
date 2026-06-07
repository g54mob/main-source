using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class PressEffect : MonoBehaviour
	{
		private const string PRESS_IMAGE_NAME = "[image press]";

		private const float PRESS_ANIM_DURATION = 0.1f;

		private IClickable clickable;

		private Image pressImage;

		private void Awake()
		{
			clickable = GetComponent<IClickable>();
			pressImage = Util.FindInChildren<Image>(base.gameObject, "[image press]");
			pressImage.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
			SetupListeners(on: true);
		}

		private void OnEnable()
		{
			pressImage.gameObject.SetActive(clickable.IsPressed);
			pressImage.canvasRenderer.SetAlpha(clickable.IsPressed ? 1 : 0);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				clickable.PressChanged += OnPressChanged;
			}
			else
			{
				clickable.PressChanged -= OnPressChanged;
			}
		}

		private void OnPressChanged(IHoverable _ = null)
		{
			if (clickable.IsPressed)
			{
				pressImage.gameObject.SetActive(value: true);
			}
			else
			{
				DisableAfterAnimationFinishes();
			}
			pressImage.CrossFadeAlpha(clickable.IsPressed ? 1 : 0, 0.1f, ignoreTimeScale: true);
		}

		private void DisableAfterAnimationFinishes()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				pressImage.gameObject.SetActive(value: false);
			}
			else
			{
				StartCoroutine(DisableAfterAnimationFinishesCoro());
			}
		}

		private IEnumerator DisableAfterAnimationFinishesCoro()
		{
			yield return WaitFor.SecondsRealtime(0.1f);
			pressImage.gameObject.SetActive(value: false);
		}
	}
}
