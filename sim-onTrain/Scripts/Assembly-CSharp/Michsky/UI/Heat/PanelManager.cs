using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Michsky.UI.Heat
{
	public class PanelManager : MonoBehaviour
	{
		[Serializable]
		public class PanelChangeCallback : UnityEvent<int>
		{
		}

		public enum PanelMode
		{
			MainPanel = 0,
			SubPanel = 1,
			Custom = 2
		}

		public enum UpdateMode
		{
			DeltaTime = 0,
			UnscaledTime = 1
		}

		[Serializable]
		public class PanelItem
		{
			[Tooltip("[Required] This is the variable that you use to call specific panels.")]
			public string panelName = "My Panel";

			[Tooltip("[Required] Main panel object.")]
			public Animator panelObject;

			[Tooltip("[Optional] If you want the panel manager to have tabbing capability, you can assign a panel button here.")]
			public PanelButton panelButton;

			[Tooltip("[Optional] Alternate panel button variable that supports standard buttons instead of panel buttons.")]
			public ButtonManager altPanelButton;

			[Tooltip("[Optional] Alternate panel button variable that supports box buttons instead of panel buttons.")]
			public BoxButtonManager altBoxButton;

			[Tooltip("[Optional] This is the object that will be selected as the current UI object on panel activation. Useful for gamepad navigation.")]
			public GameObject firstSelected;

			[Tooltip("[Optional] Enables or disables child hotkeys depending on the panel state to avoid conflict between hotkeys.")]
			public Transform hotkeyParent;

			[Tooltip("Enable or disable panel navigation when using the 'Previous' or 'Next' methods.")]
			public bool disableNavigation;

			[HideInInspector]
			public GameObject latestSelected;

			[HideInInspector]
			public HotkeyEvent[] hotkeys;
		}

		public List<PanelItem> panels = new List<PanelItem>();

		public int currentPanelIndex;

		private int currentButtonIndex;

		private int newPanelIndex;

		public bool cullPanels = true;

		[SerializeField]
		private bool initializeButtons = true;

		[SerializeField]
		private bool useCooldownForHotkeys;

		[SerializeField]
		private bool bypassAnimationOnEnable;

		[SerializeField]
		private UpdateMode updateMode = UpdateMode.UnscaledTime;

		[SerializeField]
		private PanelMode panelMode = PanelMode.Custom;

		[Range(0.75f, 2f)]
		public float animationSpeed = 1f;

		public PanelChangeCallback onPanelChanged = new PanelChangeCallback();

		private Animator currentPanel;

		private Animator nextPanel;

		private PanelButton currentButton;

		private PanelButton nextButton;

		private string panelFadeIn = "Panel In";

		private string panelFadeOut = "Panel Out";

		private string animSpeedKey = "AnimSpeed";

		private bool isInitialized;

		public float cachedStateLength = 1f;

		[HideInInspector]
		public int managerIndex;

		private void Awake()
		{
			if (panels.Count != 0)
			{
				if (panelMode == PanelMode.MainPanel)
				{
					cachedStateLength = HeatUIInternalTools.GetAnimatorClipLength(panels[currentPanelIndex].panelObject, "MainPanel_In");
				}
				else if (panelMode == PanelMode.SubPanel)
				{
					cachedStateLength = HeatUIInternalTools.GetAnimatorClipLength(panels[currentPanelIndex].panelObject, "SubPanel_In");
				}
				else if (panelMode == PanelMode.Custom)
				{
					cachedStateLength = 1f;
				}
				if (ControllerManager.instance != null)
				{
					managerIndex = ControllerManager.instance.panels.Count;
					ControllerManager.instance.panels.Add(this);
				}
			}
		}

		private void OnEnable()
		{
			if (!isInitialized)
			{
				InitializePanels();
			}
			if (ControllerManager.instance != null)
			{
				ControllerManager.instance.currentManagerIndex = managerIndex;
			}
			if (bypassAnimationOnEnable)
			{
				for (int i = 0; i < panels.Count; i++)
				{
					if (!(panels[i].panelObject == null))
					{
						if (currentPanelIndex == i)
						{
							panels[i].panelObject.gameObject.SetActive(value: true);
							panels[i].panelObject.enabled = true;
							panels[i].panelObject.Play("Panel Instant In");
						}
						else
						{
							panels[i].panelObject.gameObject.SetActive(value: false);
						}
					}
				}
			}
			else if (isInitialized && !bypassAnimationOnEnable && nextPanel == null)
			{
				currentPanel.enabled = true;
				currentPanel.SetFloat(animSpeedKey, animationSpeed);
				currentPanel.Play(panelFadeIn);
				if (currentButton != null)
				{
					currentButton.SetSelected(value: true);
				}
			}
			else if (isInitialized && !bypassAnimationOnEnable && nextPanel != null)
			{
				nextPanel.enabled = true;
				nextPanel.SetFloat(animSpeedKey, animationSpeed);
				nextPanel.Play(panelFadeIn);
				if (nextButton != null)
				{
					nextButton.SetSelected(value: true);
				}
			}
			StopCoroutine("DisablePreviousPanel");
			StopCoroutine("DisableAnimators");
			StartCoroutine("DisableAnimators");
		}

		public void InitializePanels()
		{
			if (panels[currentPanelIndex].panelButton != null)
			{
				currentButton = panels[currentPanelIndex].panelButton;
				currentButton.SetSelected(value: true);
			}
			currentPanel = panels[currentPanelIndex].panelObject;
			currentPanel.enabled = true;
			currentPanel.gameObject.SetActive(value: true);
			currentPanel.SetFloat(animSpeedKey, animationSpeed);
			currentPanel.Play(panelFadeIn);
			onPanelChanged.Invoke(currentPanelIndex);
			for (int i = 0; i < panels.Count; i++)
			{
				if (panels[i].panelObject == null)
				{
					continue;
				}
				if (i != currentPanelIndex && cullPanels)
				{
					panels[i].panelObject.gameObject.SetActive(value: false);
				}
				if (initializeButtons)
				{
					string tempName = panels[i].panelName;
					if (panels[i].panelButton != null)
					{
						panels[i].panelButton.onClick.AddListener(delegate
						{
							OpenPanel(tempName);
						});
					}
					if (panels[i].altPanelButton != null)
					{
						panels[i].altPanelButton.onClick.AddListener(delegate
						{
							OpenPanel(tempName);
						});
					}
					if (panels[i].altBoxButton != null)
					{
						panels[i].altBoxButton.onClick.AddListener(delegate
						{
							OpenPanel(tempName);
						});
					}
				}
				if (!(panels[i].hotkeyParent != null))
				{
					continue;
				}
				panels[i].hotkeys = panels[i].hotkeyParent.GetComponentsInChildren<HotkeyEvent>();
				if (useCooldownForHotkeys)
				{
					HotkeyEvent[] hotkeys = panels[i].hotkeys;
					for (int num = 0; num < hotkeys.Length; num++)
					{
						hotkeys[num].useCooldown = true;
					}
				}
			}
			StopCoroutine("DisableAnimators");
			StartCoroutine("DisableAnimators");
			isInitialized = true;
		}

		public void OpenFirstPanel()
		{
			OpenPanelByIndex(0);
		}

		public void OpenPanel(string newPanel)
		{
			bool flag = false;
			for (int i = 0; i < panels.Count; i++)
			{
				if (panels[i].panelName == newPanel)
				{
					newPanelIndex = i;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Debug.LogWarning("There is no panel named '" + newPanel + "' in the panel list.", this);
			}
			else
			{
				if (newPanelIndex == currentPanelIndex)
				{
					return;
				}
				if (cullPanels)
				{
					StopCoroutine("DisablePreviousPanel");
				}
				if (ControllerManager.instance != null)
				{
					ControllerManager.instance.currentManagerIndex = managerIndex;
				}
				currentPanel = panels[currentPanelIndex].panelObject;
				if (panels[currentPanelIndex].hotkeyParent != null)
				{
					HotkeyEvent[] hotkeys = panels[currentPanelIndex].hotkeys;
					for (int j = 0; j < hotkeys.Length; j++)
					{
						hotkeys[j].enabled = false;
					}
				}
				if (panels[currentPanelIndex].panelButton != null)
				{
					currentButton = panels[currentPanelIndex].panelButton;
				}
				if (ControllerManager.instance != null && EventSystem.current.currentSelectedGameObject != null)
				{
					panels[currentPanelIndex].latestSelected = EventSystem.current.currentSelectedGameObject;
				}
				currentPanelIndex = newPanelIndex;
				nextPanel = panels[currentPanelIndex].panelObject;
				nextPanel.gameObject.SetActive(value: true);
				currentPanel.enabled = true;
				nextPanel.enabled = true;
				currentPanel.SetFloat(animSpeedKey, animationSpeed);
				nextPanel.SetFloat(animSpeedKey, animationSpeed);
				currentPanel.Play(panelFadeOut);
				nextPanel.Play(panelFadeIn);
				if (cullPanels)
				{
					StartCoroutine("DisablePreviousPanel");
				}
				if (panels[currentPanelIndex].hotkeyParent != null)
				{
					HotkeyEvent[] hotkeys = panels[currentPanelIndex].hotkeys;
					for (int j = 0; j < hotkeys.Length; j++)
					{
						hotkeys[j].enabled = true;
					}
				}
				currentButtonIndex = newPanelIndex;
				if (ControllerManager.instance != null && panels[currentPanelIndex].latestSelected != null)
				{
					ControllerManager.instance.SelectUIObject(panels[currentPanelIndex].latestSelected);
				}
				else if (ControllerManager.instance != null && panels[currentPanelIndex].latestSelected == null)
				{
					ControllerManager.instance.SelectUIObject(panels[currentPanelIndex].firstSelected);
				}
				if (currentButton != null)
				{
					currentButton.SetSelected(value: false);
				}
				if (panels[currentButtonIndex].panelButton != null)
				{
					nextButton = panels[currentButtonIndex].panelButton;
					nextButton.SetSelected(value: true);
				}
				onPanelChanged.Invoke(currentPanelIndex);
				StopCoroutine("DisableAnimators");
				StartCoroutine("DisableAnimators");
			}
		}

		public void OpenPanelByIndex(int panelIndex)
		{
			if (panelIndex > panels.Count || panelIndex < 0)
			{
				Debug.LogWarning("Index '" + panelIndex + "' doesn't exist.", this);
				return;
			}
			for (int i = 0; i < panels.Count; i++)
			{
				if (panels[i].panelName == panels[panelIndex].panelName)
				{
					OpenPanel(panels[panelIndex].panelName);
					break;
				}
			}
		}

		public void NextPanel()
		{
			if (currentPanelIndex <= panels.Count - 2 && !panels[currentPanelIndex + 1].disableNavigation)
			{
				OpenPanelByIndex(currentPanelIndex + 1);
			}
		}

		public void PreviousPanel()
		{
			if (currentPanelIndex >= 1 && !panels[currentPanelIndex - 1].disableNavigation)
			{
				OpenPanelByIndex(currentPanelIndex - 1);
			}
		}

		public void ShowCurrentPanel()
		{
			if (nextPanel == null)
			{
				StopCoroutine("DisableAnimators");
				StartCoroutine("DisableAnimators");
				currentPanel.enabled = true;
				currentPanel.SetFloat(animSpeedKey, animationSpeed);
				currentPanel.Play(panelFadeIn);
			}
			else
			{
				StopCoroutine("DisableAnimators");
				StartCoroutine("DisableAnimators");
				nextPanel.enabled = true;
				nextPanel.SetFloat(animSpeedKey, animationSpeed);
				nextPanel.Play(panelFadeIn);
			}
		}

		public void HideCurrentPanel()
		{
			if (nextPanel == null)
			{
				StopCoroutine("DisableAnimators");
				StartCoroutine("DisableAnimators");
				currentPanel.enabled = true;
				currentPanel.SetFloat(animSpeedKey, animationSpeed);
				currentPanel.Play(panelFadeOut);
			}
			else
			{
				StopCoroutine("DisableAnimators");
				StartCoroutine("DisableAnimators");
				nextPanel.enabled = true;
				nextPanel.SetFloat(animSpeedKey, animationSpeed);
				nextPanel.Play(panelFadeOut);
			}
		}

		public void ShowCurrentButton()
		{
			if (nextButton == null)
			{
				currentButton.SetSelected(value: true);
			}
			else
			{
				nextButton.SetSelected(value: true);
			}
		}

		public void HideCurrentButton()
		{
			if (nextButton == null)
			{
				currentButton.SetSelected(value: false);
			}
			else
			{
				nextButton.SetSelected(value: false);
			}
		}

		public void AddNewItem()
		{
			PanelItem panelItem = new PanelItem();
			if (panels.Count != 0 && panels[panels.Count - 1].panelObject != null)
			{
				int index = panels.Count - 1;
				GameObject gameObject = UnityEngine.Object.Instantiate(panels[index].panelObject.transform.parent.GetChild(index).gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(panels[index].panelObject.transform.parent, worldPositionStays: false);
				gameObject.gameObject.name = "New Panel " + index;
				panelItem.panelName = "New Panel " + index;
				panelItem.panelObject = gameObject.GetComponent<Animator>();
				if (panels[index].panelButton != null)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(panels[index].panelButton.transform.parent.GetChild(index).gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject2.transform.SetParent(panels[index].panelButton.transform.parent, worldPositionStays: false);
					gameObject2.gameObject.name = "New Panel " + index;
					panelItem.panelButton = gameObject2.GetComponent<PanelButton>();
				}
				else if (panels[index].altPanelButton != null)
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate(panels[index].altPanelButton.transform.parent.GetChild(index).gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject3.transform.SetParent(panels[index].panelButton.transform.parent, worldPositionStays: false);
					gameObject3.gameObject.name = "New Panel " + index;
					panelItem.altPanelButton = gameObject3.GetComponent<ButtonManager>();
				}
				else if (panels[index].altBoxButton != null)
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate(panels[index].altBoxButton.transform.parent.GetChild(index).gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject4.transform.SetParent(panels[index].panelButton.transform.parent, worldPositionStays: false);
					gameObject4.gameObject.name = "New Panel " + index;
					panelItem.altBoxButton = gameObject4.GetComponent<BoxButtonManager>();
				}
			}
			panels.Add(panelItem);
		}

		private IEnumerator DisablePreviousPanel()
		{
			if (updateMode == UpdateMode.UnscaledTime)
			{
				yield return new WaitForSecondsRealtime(cachedStateLength * animationSpeed);
			}
			else
			{
				yield return new WaitForSeconds(cachedStateLength * animationSpeed);
			}
			for (int i = 0; i < panels.Count; i++)
			{
				if (i != currentPanelIndex)
				{
					panels[i].panelObject.gameObject.SetActive(value: false);
				}
			}
		}

		private IEnumerator DisableAnimators()
		{
			if (updateMode == UpdateMode.UnscaledTime)
			{
				yield return new WaitForSecondsRealtime(cachedStateLength * animationSpeed);
			}
			else
			{
				yield return new WaitForSeconds(cachedStateLength * animationSpeed);
			}
			if (currentPanel != null)
			{
				currentPanel.enabled = false;
			}
			if (nextPanel != null)
			{
				nextPanel.enabled = false;
			}
		}
	}
}
