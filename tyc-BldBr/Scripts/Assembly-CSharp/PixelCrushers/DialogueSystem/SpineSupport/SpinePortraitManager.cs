using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SpineSupport
{
	public class SpinePortraitManager : MonoBehaviour
	{
		private static SpinePortraitManager m_instance;

		private Dictionary<SpineDialogueActor, int> actors = new Dictionary<SpineDialogueActor, int>();

		private SpineDialogueActor focusedActor;

		public static SpinePortraitManager instance
		{
			get
			{
				if (m_instance == null)
				{
					m_instance = Object.FindObjectOfType<SpinePortraitManager>() ?? DialogueManager.instance.gameObject.AddComponent<SpinePortraitManager>();
				}
				return m_instance;
			}
		}

		private void OnEnable()
		{
			DialogueManager.instance.conversationEnded += OnConversationEnded;
		}

		private void OnDisable()
		{
			DialogueManager.instance.conversationEnded -= OnConversationEnded;
		}

		public void ShowSpineActor(SpineDialogueActor spineDialogueActor, int panelIndex)
		{
			if (spineDialogueActor == null)
			{
				return;
			}
			if (actors.ContainsKey(spineDialogueActor))
			{
				if (actors[spineDialogueActor] != panelIndex)
				{
					MoveSpineActorToPanel(spineDialogueActor, panelIndex);
				}
			}
			else
			{
				actors.Add(spineDialogueActor, panelIndex);
				MoveSpineActorToPanel(spineDialogueActor, panelIndex);
				SetTrigger(spineDialogueActor, spineDialogueActor.showTrigger);
			}
		}

		public void HideSpineActor(SpineDialogueActor spineDialogueActor)
		{
			if (!(spineDialogueActor == null))
			{
				if (spineDialogueActor == focusedActor)
				{
					focusedActor = null;
				}
				SetTrigger(spineDialogueActor, spineDialogueActor.hideTrigger, canvasState: false);
			}
		}

		private void OnConversationLine(Subtitle subtitle)
		{
			if (!string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				StartCoroutine(CheckActorAtEndOfFrame(subtitle));
			}
		}

		private IEnumerator CheckActorAtEndOfFrame(Subtitle subtitle)
		{
			yield return new WaitForEndOfFrame();
			SpineDialogueActor component = subtitle.speakerInfo.transform.GetComponent<SpineDialogueActor>();
			if (focusedActor == null || focusedActor != component)
			{
				if (focusedActor != null)
				{
					SetTrigger(focusedActor, focusedActor.unfocusTrigger);
				}
				focusedActor = component;
				if (component != null)
				{
					SetTrigger(component, component.focusTrigger);
				}
			}
		}

		private void OnConversationEnded(Transform conversationActor)
		{
			foreach (SpineDialogueActor key in actors.Keys)
			{
				SetTrigger(key, key.hideTrigger, canvasState: false);
			}
			actors.Clear();
			focusedActor = null;
		}

		private void MoveSpineActorToPanel(SpineDialogueActor spineDialogueActor, int panelIndex)
		{
			if (spineDialogueActor == null || spineDialogueActor.spineGameObject == null)
			{
				return;
			}
			RectTransform component = spineDialogueActor.spineGameObject.GetComponent<RectTransform>();
			if (component == null)
			{
				return;
			}
			StandardUISubtitlePanel panel = GetPanel(panelIndex);
			if (!(panel == null))
			{
				if (panel.panelState == UIPanel.PanelState.Closed)
				{
					panel.Open();
				}
				RectTransform component2 = panel.GetComponent<RectTransform>();
				component.pivot = component2.pivot;
				component.anchoredPosition = component2.anchoredPosition;
				component.anchorMax = component2.anchorMax;
				component.anchorMin = component2.anchorMin;
				component.sizeDelta = component2.sizeDelta;
				actors[spineDialogueActor] = panelIndex;
			}
		}

		private StandardUISubtitlePanel GetPanel(int panelIndex)
		{
			StandardDialogueUI standardDialogueUI = DialogueManager.dialogueUI as StandardDialogueUI;
			if (standardDialogueUI == null)
			{
				return null;
			}
			int num = standardDialogueUI.conversationUIElements.subtitlePanels.Length;
			if (0 > panelIndex || panelIndex >= num)
			{
				return null;
			}
			return standardDialogueUI.conversationUIElements.subtitlePanels[panelIndex];
		}

		private void SetTrigger(SpineDialogueActor spineDialogueActor, string triggerName, bool canvasState = true)
		{
			if (spineDialogueActor == null || spineDialogueActor.spineGameObject == null)
			{
				return;
			}
			Canvas componentInParent = spineDialogueActor.spineGameObject.GetComponentInParent<Canvas>();
			if (!(componentInParent == null))
			{
				componentInParent.enabled = canvasState;
				Animator component = componentInParent.GetComponent<Animator>();
				if (!(component == null))
				{
					component.SetTrigger(triggerName);
				}
			}
		}
	}
}
