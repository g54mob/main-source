using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace RainbowArt.CleanFlatUI
{
	public class InputFieldTransition : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private Animator animator;

		private EventTrigger eventTrigger;

		private bool bDelayed;

		private void Awake()
		{
			ResetAnimation(animator);
			AddTriggersListener(inputField.gameObject, EventTriggerType.Select, InputFieldIn);
			inputField.onEndEdit.AddListener(InputFieldOut);
		}

		private void OnEnable()
		{
			UpdateGUI(bIn: false);
		}

		private void Update()
		{
			if (bDelayed)
			{
				bDelayed = false;
				UpdateGUI(bIn: false);
			}
		}

		private void AddTriggersListener(GameObject obj, EventTriggerType eventID, UnityAction<BaseEventData> action)
		{
			EventTrigger eventTrigger = obj.GetComponent<EventTrigger>();
			if (eventTrigger == null)
			{
				eventTrigger = obj.AddComponent<EventTrigger>();
			}
			if (eventTrigger.triggers.Count == 0)
			{
				eventTrigger.triggers = new List<EventTrigger.Entry>();
			}
			UnityAction<BaseEventData> call = action.Invoke;
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = eventID;
			entry.callback.AddListener(call);
			eventTrigger.triggers.Add(entry);
		}

		public void InputFieldIn(BaseEventData data)
		{
			UpdateGUI(bIn: true);
		}

		public void InputFieldOut(string value)
		{
			bDelayed = true;
		}

		public void UpdateGUI(bool bIn)
		{
			if (inputField.text.Length == 0)
			{
				if (bIn)
				{
					PlayAnimation(animator, "In");
				}
				else
				{
					PlayAnimation(animator, "Out");
				}
			}
			else if (!bIn)
			{
				PlayAnimation(animator, "Out Value");
			}
			else
			{
				PlayAnimation(animator, "In");
			}
		}

		private void PlayAnimation(Animator animator, string animStr)
		{
			if (animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				animator.Play(animStr, 0, 0f);
			}
		}

		private void ResetAnimation(Animator animator)
		{
			if (animator != null)
			{
				animator.enabled = false;
			}
		}
	}
}
