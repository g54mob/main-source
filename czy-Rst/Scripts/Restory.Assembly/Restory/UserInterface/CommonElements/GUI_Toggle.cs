using System;
using System.Collections;
using Helpers.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_Toggle : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler
	{
		[Serializable]
		private struct ToggleItemPreset
		{
			public Graphic Graphic;

			[Space]
			public Color IsOnColor;

			public Color IsOffColor;

			public void ApplyColor(bool isOn)
			{
				Graphic.color = (isOn ? IsOnColor : IsOffColor);
			}
		}

		private struct GraphicLerpHelper
		{
			private Graphic graphic;

			public Color Start { get; private set; }

			public Color Final { get; private set; }

			public GraphicLerpHelper(Graphic graphic, Color start, Color final)
			{
				this.graphic = graphic;
				Start = start;
				Final = final;
			}

			public GraphicLerpHelper(ToggleItemPreset preset)
			{
				graphic = preset.Graphic;
				Start = preset.IsOffColor;
				Final = preset.IsOnColor;
			}

			public void Reverse()
			{
				Color start = Start;
				Start = Final;
				Final = start;
			}

			public void Lerp(float step)
			{
				if (!(graphic.color == Final))
				{
					graphic.color = Color.Lerp(Start, Final, step);
				}
			}
		}

		public readonly UnityEvent<bool> OnValueChanged = new UnityEventBool();

		[Header("General settings")]
		[SerializeField]
		private bool isOn;

		[SerializeField]
		private RectTransform containerTransform;

		[SerializeField]
		private RectTransform handlerTransform;

		[Header("View settings")]
		[SerializeField]
		private bool smoothAnimation = true;

		[SerializeField]
		private float animationDuration = 0.75f;

		[SerializeField]
		private Text title;

		[SerializeField]
		private Text value;

		[Header("Toggle controller presets")]
		[SerializeField]
		private ToggleItemPreset border;

		[SerializeField]
		private ToggleItemPreset background;

		[SerializeField]
		private ToggleItemPreset handler;

		[Header("Localizations")]
		[SerializeField]
		private GUI_LocalisedText valueLocalizationText;

		[SerializeField]
		private string isOnKey = "GUI_TECH_ON";

		[SerializeField]
		private string isOffKey = "GUI_TECH_OFF";

		[Header("Others")]
		[SerializeField]
		private Graphic[] targetGraphics = new Graphic[0];

		private Coroutine mainRoutine;

		public bool IsOn
		{
			get
			{
				return isOn;
			}
			set
			{
				SetIsOnWithoutNotify(value);
				OnValueChanged.Invoke(isOn);
			}
		}

		public void Init()
		{
			UpdateView();
			MoveImmidiately();
		}

		public void SetIsOnWithoutNotify(bool value)
		{
			isOn = value;
			if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && smoothAnimation)
			{
				StartMovingRoutine();
			}
			else
			{
				MoveImmidiately();
			}
			UpdateView();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Init();
		}

		public override void Select()
		{
			base.Select();
			Graphic[] array = targetGraphics;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = base.colors.selectedColor;
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			IsOn = !IsOn;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			IsOn = !IsOn;
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			Graphic[] array = targetGraphics;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = base.colors.normalColor;
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			OnSelect(eventData);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			OnDeselect(eventData);
		}

		private void UpdateView()
		{
			if ((bool)valueLocalizationText)
			{
				valueLocalizationText.LocalizationID = (IsOn ? isOnKey : isOffKey);
				valueLocalizationText.Refresh();
			}
			else if ((bool)value)
			{
				value.text = (IsOn ? "On" : "Off");
			}
		}

		private void StartMovingRoutine()
		{
			if (mainRoutine != null)
			{
				StopCoroutine(mainRoutine);
			}
			mainRoutine = StartCoroutine(MoveRoutine(animationDuration));
		}

		private void MoveImmidiately()
		{
			Vector2 anchoredPosition = Vector2.right * containerTransform.rect.size.x / 2f;
			if (!isOn)
			{
				anchoredPosition *= -1f;
			}
			handlerTransform.anchoredPosition = anchoredPosition;
			background.ApplyColor(IsOn);
			border.ApplyColor(IsOn);
			handler.ApplyColor(IsOn);
		}

		private IEnumerator MoveRoutine(float duration)
		{
			Vector2 finalPosition = Vector2.right * containerTransform.rect.size.x / 2f;
			GraphicLerpHelper backgroundHelper = new GraphicLerpHelper(background);
			GraphicLerpHelper borderHelper = new GraphicLerpHelper(border);
			GraphicLerpHelper handlerHelper = new GraphicLerpHelper(handler);
			if (!isOn)
			{
				finalPosition *= -1f;
				backgroundHelper.Reverse();
				borderHelper.Reverse();
				handlerHelper.Reverse();
			}
			for (float timer = 0f; timer < duration; timer += 0.005f)
			{
				float num = timer / duration;
				handlerTransform.anchoredPosition = Vector3.Lerp(handlerTransform.anchoredPosition, finalPosition, num);
				backgroundHelper.Lerp(num);
				borderHelper.Lerp(num);
				handlerHelper.Lerp(num);
				yield return new WaitForSecondsRealtime(0.005f);
			}
			MoveImmidiately();
		}
	}
}
