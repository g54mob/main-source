using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class SliderTransition : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[SerializeField]
		private Slider slider;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text;

		private bool bDelayedUpdate;

		public bool HasText
		{
			get
			{
				return hasText;
			}
			set
			{
				hasText = value;
				UpdateText();
			}
		}

		private void UpdateText()
		{
			if (text != null && text.gameObject.activeSelf != hasText)
			{
				text.gameObject.SetActive(hasText);
			}
			if (hasText && text != null)
			{
				float num = (float)Math.Round(slider.value, 1);
				text.text = num.ToString() ?? "";
			}
		}

		private void Start()
		{
			if (slider == null)
			{
				slider = GetComponent<Slider>();
			}
			slider.onValueChanged.AddListener(SliderValueChange);
			SliderValueChange(slider.value);
		}

		private void Update()
		{
			if (bDelayedUpdate)
			{
				bDelayedUpdate = false;
				if (text != null)
				{
					text.gameObject.SetActive(hasText);
				}
				if (slider == null)
				{
					slider = GetComponent<Slider>();
				}
				SliderValueChange(slider.value);
			}
		}

		public void SliderValueChange(float value)
		{
			if (hasText && text != null)
			{
				float num = (float)Math.Round(slider.value, 1);
				text.text = num.ToString() ?? "";
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (animator != null)
			{
				animator.Play("Transition", 0, 0f);
			}
		}
	}
}
