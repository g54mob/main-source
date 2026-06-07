using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VRTK
{
	public class VRTK_SDKSetupSwitcher : MonoBehaviour
	{
		protected enum ViewingState
		{
			Status = 0,
			Selection = 1
		}

		[Header("Fallback Objects")]
		[SerializeField]
		protected Camera fallbackCamera;

		[SerializeField]
		public EventSystem eventSystem;

		[Header("Object References")]
		[SerializeField]
		protected Text currentText;

		[SerializeField]
		protected RectTransform statusPanel;

		[SerializeField]
		protected RectTransform selectionPanel;

		[SerializeField]
		protected Button switchButton;

		[SerializeField]
		protected Button cancelButton;

		[SerializeField]
		protected Button chooseButton;

		[SerializeField]
		protected bool playareaSync = true;

		protected readonly List<GameObject> chooseButtonGameObjects = new List<GameObject>();

		protected Transform currentPlayarea;

		protected virtual void Awake()
		{
			fallbackCamera.gameObject.SetActive(value: false);
			eventSystem.gameObject.SetActive(value: false);
			chooseButton.gameObject.SetActive(value: false);
		}

		protected virtual void OnEnable()
		{
			VRTK_SDKManager.SubscribeLoadedSetupChanged(OnLoadedSetupChanged);
			switchButton.onClick.AddListener(OnSwitchButtonClick);
			cancelButton.onClick.AddListener(OnCancelButtonClick);
			Show(ViewingState.Status);
		}

		protected virtual void OnDisable()
		{
			VRTK_SDKManager.UnsubscribeLoadedSetupChanged(OnLoadedSetupChanged);
			switchButton.onClick.RemoveListener(OnSwitchButtonClick);
			cancelButton.onClick.RemoveListener(OnCancelButtonClick);
			Show(ViewingState.Status);
		}

		protected virtual void OnLoadedSetupChanged(VRTK_SDKManager sender, VRTK_SDKManager.LoadedSetupChangeEventArgs e)
		{
			Show(ViewingState.Status);
			if (playareaSync && currentPlayarea != null)
			{
				Transform obj = VRTK_DeviceFinder.PlayAreaTransform();
				obj.transform.position = currentPlayarea.transform.position;
				obj.transform.rotation = currentPlayarea.transform.rotation;
				obj.SetGlobalScale(currentPlayarea.transform.lossyScale);
			}
			currentPlayarea = VRTK_DeviceFinder.PlayAreaTransform();
		}

		protected virtual void OnSwitchButtonClick()
		{
			Show(ViewingState.Selection);
		}

		protected virtual void OnCancelButtonClick()
		{
			Show(ViewingState.Status);
		}

		protected virtual void Show(ViewingState viewingState)
		{
			switch (viewingState)
			{
			case ViewingState.Status:
				RemoveCreatedChooseButtons();
				UpdateCurrentText();
				selectionPanel.gameObject.SetActive(value: false);
				statusPanel.gameObject.SetActive(value: true);
				break;
			case ViewingState.Selection:
				AddSelectionButtons();
				selectionPanel.gameObject.SetActive(value: true);
				statusPanel.gameObject.SetActive(value: false);
				break;
			default:
				VRTK_Logger.Fatal(new ArgumentOutOfRangeException("viewingState", viewingState, null));
				return;
			}
			bool flag = VRTK_SDKManager.GetAllSDKSetups().Any((VRTK_SDKSetup setup) => setup != null && setup.gameObject.activeSelf) || VRTK_DeviceFinder.HeadsetCamera() != null;
			fallbackCamera.gameObject.SetActive(!flag);
			eventSystem.gameObject.SetActive(EventSystem.current == null || EventSystem.current == eventSystem);
		}

		protected virtual void UpdateCurrentText()
		{
			VRTK_SDKSetup loadedSDKSetup = VRTK_SDKManager.GetLoadedSDKSetup();
			currentText.text = ((loadedSDKSetup == null) ? "None" : loadedSDKSetup.name);
		}

		protected virtual void AddSelectionButtons()
		{
			if (VRTK_SDKManager.GetLoadedSDKSetup() != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(chooseButton.gameObject, chooseButton.transform.parent);
				gameObject.GetComponentInChildren<Text>().text = "None";
				gameObject.name = "ChooseNoneButton";
				gameObject.SetActive(value: true);
				gameObject.GetComponent<Button>().onClick.AddListener(delegate
				{
					VRTK_SDKManager.AttemptUnloadSDKSetup(disableVR: true);
				});
				chooseButtonGameObjects.Add(gameObject);
			}
			VRTK_SDKSetup[] setups = VRTK_SDKManager.GetAllSDKSetups();
			for (int num = 0; num < setups.Length; num++)
			{
				VRTK_SDKSetup vRTK_SDKSetup = setups[num];
				if (!(vRTK_SDKSetup == null) && !(vRTK_SDKSetup == VRTK_SDKManager.GetLoadedSDKSetup()))
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(chooseButton.gameObject, chooseButton.transform.parent);
					gameObject2.GetComponentInChildren<Text>().text = vRTK_SDKSetup.name;
					gameObject2.name = $"Choose{vRTK_SDKSetup.name}Button";
					gameObject2.SetActive(value: true);
					int indexCopy = num;
					Button component = gameObject2.GetComponent<Button>();
					component.onClick.AddListener(delegate
					{
						VRTK_SDKManager.AttemptTryLoadSDKSetup(indexCopy, tryToReinitialize: true, setups);
					});
					ColorBlock colors = component.colors;
					colors.colorMultiplier = (vRTK_SDKSetup.isValid ? 1f : 0.8f);
					component.colors = colors;
					chooseButtonGameObjects.Add(gameObject2);
				}
			}
		}

		protected virtual void RemoveCreatedChooseButtons()
		{
			chooseButtonGameObjects.ForEach(UnityEngine.Object.Destroy);
			chooseButtonGameObjects.Clear();
		}
	}
}
