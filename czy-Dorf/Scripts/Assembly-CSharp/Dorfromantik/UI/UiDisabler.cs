using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiDisabler : MonoBehaviour
	{
		[SerializeField]
		private bool isSlider;

		[SerializeField]
		private bool isToggle;

		[SerializeField]
		private GameObject gameObjectToDisable;

		[SerializeField]
		private float disabledAlpha = 0.5f;

		[SerializeField]
		private bool shouldDisableOnStart = true;

		[SerializeField]
		private bool shouldRemoveAllFunctionality = true;

		private void Awake()
		{
			if (gameObjectToDisable == null)
			{
				gameObjectToDisable = base.gameObject;
			}
		}

		private void Start()
		{
			if (shouldDisableOnStart)
			{
				SetDisabled();
			}
		}

		private void OnValidate()
		{
			if (gameObjectToDisable == null)
			{
				gameObjectToDisable = base.gameObject;
			}
		}

		internal void SetDisabled()
		{
			SetVisibilityToDisabled();
			if (shouldRemoveAllFunctionality)
			{
				SetFunctionalityToDisabled();
			}
		}

		private void SetVisibilityToDisabled()
		{
			CanvasGroup canvasGroup = gameObjectToDisable.GetComponent<CanvasGroup>();
			if (canvasGroup == null)
			{
				canvasGroup = gameObjectToDisable.AddComponent<CanvasGroup>();
			}
			if ((bool)canvasGroup)
			{
				canvasGroup.alpha = disabledAlpha;
			}
		}

		private void SetFunctionalityToDisabled()
		{
			if (isSlider)
			{
				Slider component = GetComponent<Slider>();
				component.onValueChanged.RemoveAllListeners();
				int persistentEventCount = component.onValueChanged.GetPersistentEventCount();
				for (int i = 0; i < persistentEventCount; i++)
				{
					component.onValueChanged.SetPersistentListenerState(i, UnityEventCallState.Off);
				}
			}
			if (isToggle)
			{
				Toggle component2 = GetComponent<Toggle>();
				component2.onValueChanged.RemoveAllListeners();
				int persistentEventCount2 = component2.onValueChanged.GetPersistentEventCount();
				for (int j = 0; j < persistentEventCount2; j++)
				{
					component2.onValueChanged.SetPersistentListenerState(j, UnityEventCallState.Off);
				}
			}
		}
	}
}
