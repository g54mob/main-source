using System;
using DV.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class SliderDV : Slider, IHoverable
	{
		private const string TEXT_VALUE_NAME = "[texts]/[text value] [noloc]";

		public bool useStepping;

		public float stepIncrement = 0.1f;

		public string localizeValueKey;

		private HoverableEvents events;

		protected TextMeshProUGUI valueTMPro;

		public new bool IsInteractable => IsInteractable();

		public bool IsHovered { get; set; }

		public bool IsMouseOvered { get; protected set; }

		public event HoverChangedDelegate HoverChanged;

		public event HoverChangedDelegate MouseOverChanged;

		public event InteractabilityChangedDelegate InteractabilityChanged;

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		public void ToggleInteractable(bool newInteractable)
		{
			base.interactable = newInteractable;
			if (!base.interactable)
			{
				IsHovered = false;
			}
			events?.FireEventsIfNeeded();
		}

		public void Hover()
		{
			IsHovered = IsInteractable;
			IsMouseOvered = true;
			events?.FireEventsIfNeeded();
		}

		public void Unhover()
		{
			IsHovered = false;
			IsMouseOvered = false;
			events?.FireEventsIfNeeded();
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			Hover();
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			Unhover();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Unhover();
		}

		protected override void Awake()
		{
			base.Awake();
			events = new HoverableEvents(this, delegate
			{
				this.HoverChanged?.Invoke(this);
			}, delegate
			{
				this.MouseOverChanged?.Invoke(this);
			}, delegate
			{
				this.InteractabilityChanged?.Invoke(this);
			});
			valueTMPro = base.transform.Find("[texts]/[text value] [noloc]")?.GetComponent<TextMeshProUGUI>();
			UpdateValueText();
			base.onValueChanged.AddListener(UpdateValueText);
		}

		protected virtual void UpdateValueText(float _ = 0f)
		{
			if (!(valueTMPro == null))
			{
				string text = Math.Round(value, 3).ToString();
				if (!string.IsNullOrWhiteSpace(localizeValueKey))
				{
					text = LocalizationAPI.L(localizeValueKey, text);
				}
				valueTMPro.text = text;
			}
		}

		public override void SetValueWithoutNotify(float input)
		{
			base.SetValueWithoutNotify(input);
			UpdateValueText(input);
		}

		public void SetValueNoStepping(float input)
		{
			base.Set(input);
		}

		private static float RoundToIncrement(float value, float start, float end, float increment)
		{
			if (value < start)
			{
				return start;
			}
			if (value > end)
			{
				return end;
			}
			if (increment < 0.0001f)
			{
				return value;
			}
			float num = Mathf.Round((value - start) / increment) * increment;
			float num2 = start + num;
			if (num2 > end)
			{
				return end;
			}
			if (end - num2 < increment)
			{
				if (!(Mathf.InverseLerp(num2, end, value) > 0.5f))
				{
					return num2;
				}
				return end;
			}
			return num2;
		}

		protected override void Set(float input, bool sendCallback = true)
		{
			if (useStepping)
			{
				input = RoundToIncrement(input, base.minValue, base.maxValue, stepIncrement);
			}
			base.Set(input, sendCallback);
		}
	}
}
