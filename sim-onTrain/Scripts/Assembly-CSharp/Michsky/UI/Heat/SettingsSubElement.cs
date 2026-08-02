using System.Collections;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(CanvasGroup))]
	public class SettingsSubElement : MonoBehaviour
	{
		public enum DefaultState
		{
			None = 0,
			Active = 1,
			Disabled = 2
		}

		[Header("Settings")]
		[SerializeField]
		[Range(0f, 1f)]
		private float disabledOpacity = 0.5f;

		[SerializeField]
		[Range(1f, 10f)]
		private float animSpeed = 4f;

		public DefaultState defaultState = DefaultState.Active;

		[Header("Resources")]
		[SerializeField]
		private CanvasGroup targetCG;

		private void Awake()
		{
			if (targetCG == null)
			{
				targetCG = GetComponent<CanvasGroup>();
			}
		}

		private void OnEnable()
		{
			if (defaultState == DefaultState.Active)
			{
				SetState(value: true);
			}
			else if (defaultState == DefaultState.Disabled)
			{
				SetState(value: false);
			}
		}

		public void SetState(bool value)
		{
			if (value)
			{
				StartCoroutine("GroupIn");
				defaultState = DefaultState.Active;
			}
			else
			{
				StartCoroutine("GroupOut");
				defaultState = DefaultState.Disabled;
			}
		}

		private IEnumerator GroupIn()
		{
			StopCoroutine("GroupOut");
			targetCG.interactable = true;
			targetCG.blocksRaycasts = true;
			while ((double)targetCG.alpha < 0.99)
			{
				targetCG.alpha += Time.unscaledDeltaTime * animSpeed;
				yield return null;
			}
			targetCG.alpha = 1f;
		}

		private IEnumerator GroupOut()
		{
			StopCoroutine("GroupIn");
			targetCG.interactable = false;
			targetCG.blocksRaycasts = false;
			while (targetCG.alpha > disabledOpacity)
			{
				targetCG.alpha -= Time.unscaledDeltaTime * animSpeed;
				yield return null;
			}
			targetCG.alpha = disabledOpacity;
		}
	}
}
