using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_DialogueChoiceOption : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		[SerializeField]
		private TMP_Text optionText;

		[SerializeField]
		private GameObject pointerImage;

		[SerializeField]
		private CanvasGroup canvasGroup;

		public event Action PointerEnter;

		public void UpdateContent(string option)
		{
			optionText.text = option;
		}

		public void Select()
		{
			pointerImage.SetActive(value: true);
			canvasGroup.alpha = 1f;
		}

		public void Deselect()
		{
			pointerImage.SetActive(value: false);
			canvasGroup.alpha = 0.5f;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.PointerEnter?.Invoke();
		}
	}
}
