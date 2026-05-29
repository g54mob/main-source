using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class InputFieldTransition : MonoBehaviour
	{
		[SerializeField]
		private InputField inputField;

		[SerializeField]
		private Animator animator;

		private EventTrigger eventTrigger;

		private bool bDelayed;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void AddTriggersListener(GameObject obj, EventTriggerType eventID, UnityAction<BaseEventData> action)
		{
		}

		public void InputFieldIn(BaseEventData data)
		{
		}

		public void InputFieldOut(string value)
		{
		}

		public void UpdateGUI(bool bIn)
		{
		}

		private void PlayAnimation(Animator animator, string animStr)
		{
		}

		private void ResetAnimation(Animator animator)
		{
		}
	}
}
