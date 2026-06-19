using System;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchMessageBox : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _messageText;

		[SerializeField]
		private DynamicButton _button1;

		[SerializeField]
		private TMP_Text _button1Text;

		[SerializeField]
		private DynamicButton _button2;

		[SerializeField]
		private TMP_Text _button2Text;

		private Action OnButton1Action;

		private Action OnButton2Action;

		private void OnEnable()
		{
			_button1.onPrimaryDown.AddListener(OnButton1Pressed);
			_button2.onPrimaryDown.AddListener(OnButton2Pressed);
		}

		private void OnDisable()
		{
			_button1.onPrimaryDown.RemoveListener(OnButton1Pressed);
			_button2.onPrimaryDown.RemoveListener(OnButton2Pressed);
			OnButton1Action = null;
			OnButton2Action = null;
		}

		public void SetupWith1Button(string message, string buttonText, Action onButtonPressed)
		{
			GameObjectUtils.SetActive(_button2.gameObject, isActive: false);
			OnButton1Action = onButtonPressed;
			OnButton2Action = null;
			_messageText.text = message;
			_button1Text.text = buttonText;
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
		}

		public void SetupWith2Buttons(string message, string button1Text, Action onButton1Pressed, string button2Text, Action onButton2Pressed)
		{
			GameObjectUtils.SetActive(_button2.gameObject, isActive: true);
			OnButton1Action = onButton1Pressed;
			OnButton2Action = onButton2Pressed;
			_messageText.text = message;
			_button1Text.text = button1Text;
			_button2Text.text = button2Text;
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
		}

		public void Kill()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}

		private void OnButton1Pressed()
		{
			if (OnButton1Action != null)
			{
				OnButton1Action.InvokeSafe();
			}
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}

		private void OnButton2Pressed()
		{
			if (OnButton2Action != null)
			{
				OnButton2Action.InvokeSafe();
			}
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}
	}
}
