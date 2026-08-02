using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.Heat
{
	public class HUDManager : MonoBehaviour
	{
		public enum DefaultBehaviour
		{
			Visible = 0,
			Invisible = 1
		}

		public GameObject HUDPanel;

		private CanvasGroup cg;

		[Range(1f, 20f)]
		public float fadeSpeed = 8f;

		public DefaultBehaviour defaultBehaviour;

		public UnityEvent onSetVisible;

		public UnityEvent onSetInvisible;

		private bool isOn;

		private void Awake()
		{
			if (!(HUDPanel == null))
			{
				cg = HUDPanel.AddComponent<CanvasGroup>();
				if (defaultBehaviour == DefaultBehaviour.Visible)
				{
					cg.alpha = 1f;
					isOn = true;
					onSetVisible.Invoke();
				}
				else if (defaultBehaviour == DefaultBehaviour.Invisible)
				{
					cg.alpha = 0f;
					isOn = false;
					onSetInvisible.Invoke();
				}
			}
		}

		public void SetVisible()
		{
			if (isOn)
			{
				SetVisible(value: false);
			}
			else
			{
				SetVisible(value: true);
			}
		}

		public void SetVisible(bool value)
		{
			if (!(HUDPanel == null))
			{
				if (value)
				{
					isOn = true;
					onSetVisible.Invoke();
					StopCoroutine("DoFadeIn");
					StopCoroutine("DoFadeOut");
					StartCoroutine("DoFadeIn");
				}
				else
				{
					isOn = false;
					onSetInvisible.Invoke();
					StopCoroutine("DoFadeIn");
					StopCoroutine("DoFadeOut");
					StartCoroutine("DoFadeOut");
				}
			}
		}

		private IEnumerator DoFadeIn()
		{
			while (cg.alpha < 0.99f)
			{
				cg.alpha += Time.unscaledDeltaTime * fadeSpeed;
				yield return null;
			}
			cg.alpha = 1f;
		}

		private IEnumerator DoFadeOut()
		{
			while (cg.alpha > 0.01f)
			{
				cg.alpha -= Time.unscaledDeltaTime * fadeSpeed;
				yield return null;
			}
			cg.alpha = 0f;
		}
	}
}
