using System;
using System.Collections.Generic;
using System.ComponentModel;
using DV.UIFramework;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class Selector : MonoBehaviour, ISelector, IClickable, IHoverable
	{
		protected const string TEXT_LABEL_NAME = "[texts]/[text label]";

		protected const string TEXT_VALUE_NAME = "[texts]/[text value] [noloc]";

		private const string BUTTON_NEXT_NAME = "[arrow right]";

		private const string BUTTON_PREVIOUS_NAME = "[arrow left]";

		private const string ICON_NAME = "[icon]";

		private const float ALPHA_ACTIVE = 1f;

		private const float ALPHA_INACTIVE = 0.3f;

		private const float ANIM_DURATION = 0.1f;

		protected bool initialized;

		protected TextMeshProUGUI labelTMPro;

		protected TextMeshProUGUI valueTMPro;

		private IClickable buttonPrevious;

		private IClickable buttonNext;

		private Image icon;

		private string currentLabel = "";

		private string selectedValueText = "";

		protected readonly List<string> values = new List<string>();

		private bool _localizedLabel;

		private bool _localizedValues;

		public bool IsInteractable { get; private set; } = true;

		public bool IsHovered { get; private set; }

		public bool IsMouseOvered { get; private set; }

		public bool IsPressed { get; private set; }

		public Image Icon => icon;

		public int SelectedIndex { get; private set; }

		public bool LocalizedLabel
		{
			get
			{
				return _localizedLabel;
			}
			set
			{
				_localizedLabel = value;
				Initialize();
				UpdateLocalization(labelTMPro, currentLabel, value);
			}
		}

		public bool LocalizedValues
		{
			get
			{
				return _localizedValues;
			}
			set
			{
				_localizedValues = value;
				Initialize();
				UpdateLocalization(valueTMPro, selectedValueText, value);
			}
		}

		public event ClickDelegate Clicked;

		public event SelectorClickDelegate PreviousOrNextClicked;

		public event InteractabilityChangedDelegate InteractabilityChanged;

		public event PressChangedDelegate PressChanged;

		public event HoverChangedDelegate HoverChanged;

		public event HoverChangedDelegate MouseOverChanged;

		public event AboutToChangeSelectionChangeEvent AboutToChangeSelection;

		public event SelectionChangeEvent SelectionChanged;

		private void Awake()
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
			if (!initialized)
			{
				buttonNext = base.transform.Find("[arrow right]")?.GetComponent<IClickable>();
				buttonPrevious = base.transform.Find("[arrow left]")?.GetComponent<IClickable>();
				labelTMPro = base.transform.Find("[texts]/[text label]")?.GetComponent<TextMeshProUGUI>();
				valueTMPro = base.transform.Find("[texts]/[text value] [noloc]")?.GetComponent<TextMeshProUGUI>();
				if (buttonNext == null || buttonPrevious == null)
				{
					Debug.LogError("Selector couldn't find one or both of the previous/next buttons", this);
				}
				icon = base.transform.Find("[icon]")?.GetComponent<Image>();
				SetupListeners(on: true);
				initialized = true;
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (buttonNext != null)
				{
					buttonNext.Clicked += TrySelectNext;
					buttonNext.Clicked += OnNextClicked;
					buttonNext.Clicked += OnAnyClicked;
					buttonNext.HoverChanged += OnAnyHovered;
					buttonNext.PressChanged += OnAnyPressed;
					buttonNext.MouseOverChanged += OnAnyMouseOvered;
				}
				if (buttonPrevious != null)
				{
					buttonPrevious.Clicked += TrySelectPrevious;
					buttonPrevious.Clicked += OnPreviousClicked;
					buttonPrevious.Clicked += OnAnyClicked;
					buttonPrevious.HoverChanged += OnAnyHovered;
					buttonPrevious.PressChanged += OnAnyPressed;
					buttonPrevious.MouseOverChanged += OnAnyMouseOvered;
				}
			}
			else
			{
				if (buttonNext != null)
				{
					buttonNext.Clicked -= TrySelectNext;
					buttonNext.Clicked -= OnNextClicked;
					buttonNext.Clicked -= OnAnyClicked;
					buttonNext.HoverChanged -= OnAnyHovered;
					buttonNext.PressChanged -= OnAnyPressed;
					buttonNext.MouseOverChanged -= OnAnyMouseOvered;
				}
				if (buttonPrevious != null)
				{
					buttonPrevious.Clicked -= TrySelectPrevious;
					buttonPrevious.Clicked -= OnPreviousClicked;
					buttonPrevious.Clicked -= OnAnyClicked;
					buttonPrevious.HoverChanged -= OnAnyHovered;
					buttonPrevious.PressChanged -= OnAnyPressed;
					buttonPrevious.MouseOverChanged -= OnAnyMouseOvered;
				}
			}
		}

		private void OnAnyPressed(IClickable clickable)
		{
			this.PressChanged?.Invoke(this);
		}

		private void OnAnyClicked(IClickable clickable)
		{
			this.Clicked?.Invoke(this);
		}

		private void OnAnyHovered(IHoverable hoverable)
		{
			bool flag = buttonNext.IsHovered || buttonPrevious.IsHovered;
			bool isHovered = IsHovered;
			IsHovered = flag;
			if (isHovered != flag)
			{
				this.HoverChanged?.Invoke(this);
			}
		}

		private void OnAnyMouseOvered(IHoverable hoverable)
		{
			bool flag = buttonNext.IsMouseOvered || buttonPrevious.IsMouseOvered;
			bool isMouseOvered = IsMouseOvered;
			IsMouseOvered = flag;
			if (isMouseOvered != flag)
			{
				this.MouseOverChanged?.Invoke(this);
			}
		}

		private void OnPreviousClicked(IClickable selectable)
		{
			this.PreviousOrNextClicked?.Invoke(this, nextClicked: false);
		}

		private void OnNextClicked(IClickable selectable)
		{
			this.PreviousOrNextClicked?.Invoke(this, nextClicked: true);
		}

		public void Hover()
		{
			this.HoverChanged?.Invoke(this);
		}

		public void Unhover()
		{
			this.HoverChanged?.Invoke(this);
		}

		public void Click()
		{
			throw new NotImplementedException("Selector doesn't implement Click");
		}

		public void Press()
		{
			throw new NotImplementedException("Selector doesn't implement Press");
		}

		public void Release()
		{
			throw new NotImplementedException("Selector doesn't implement Release");
		}

		private void ToggleInteractable(bool forwardInteractable, bool backwardInteractable)
		{
			Initialize();
			bool flag = forwardInteractable || backwardInteractable;
			if (buttonNext != null)
			{
				buttonNext.ToggleInteractable(forwardInteractable);
			}
			if (buttonPrevious != null)
			{
				buttonPrevious.ToggleInteractable(backwardInteractable);
			}
			if (IsInteractable != flag)
			{
				IsInteractable = flag;
				this.InteractabilityChanged?.Invoke(this);
				if ((bool)icon)
				{
					icon.CrossFadeAlpha(IsInteractable ? 1f : 0.3f, 0.1f, ignoreTimeScale: true);
				}
			}
		}

		public void ToggleInteractable(bool newInteractable)
		{
			ToggleInteractable(newInteractable, newInteractable);
		}

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		private void TrySelectPrevious(IClickable _)
		{
			TryChangeSelection(next: false);
		}

		private void TrySelectNext(IClickable _)
		{
			TryChangeSelection(next: true);
		}

		private void TryChangeSelection(bool next)
		{
			if (IsInteractable && values.Count >= 2)
			{
				int num = SelectedIndex + (next ? 1 : (-1));
				if (num >= values.Count)
				{
					num = 0;
				}
				else if (num < 0)
				{
					num = values.Count - 1;
				}
				CancelEventArgs e = new CancelEventArgs();
				this.AboutToChangeSelection?.Invoke(this, num, e);
				if (!e.Cancel)
				{
					SetSelectedIndex(num);
				}
			}
		}

		public virtual void SetValues(List<string> newValues)
		{
			Initialize();
			values.Clear();
			if (newValues != null)
			{
				values.AddRange(newValues);
			}
			RefreshShownValue();
		}

		public IReadOnlyList<string> GetValues()
		{
			return values;
		}

		public void SetLabel(string label)
		{
			Initialize();
			currentLabel = label;
			UpdateLocalization(labelTMPro, currentLabel, LocalizedLabel);
		}

		public TextMeshProUGUI GetLabelTMPro()
		{
			Initialize();
			return labelTMPro;
		}

		public virtual void SetSelectedIndex(int index, bool fireEvent = true)
		{
			Initialize();
			index = Mathf.Clamp(index, 0, values.Count - 1);
			if (!Application.isPlaying || (index != SelectedIndex && values.Count != 0))
			{
				SelectedIndex = index;
				RefreshShownValue();
				if (fireEvent)
				{
					this.SelectionChanged?.Invoke(this, SelectedIndex);
				}
			}
		}

		private void RefreshShownValue()
		{
			if (values != null && values.Count > 0)
			{
				SelectedIndex = Mathf.Clamp(SelectedIndex, 0, values.Count - 1);
				selectedValueText = values[SelectedIndex];
			}
			else
			{
				selectedValueText = "";
				Debug.LogWarning("Selector couldn't find value (values list is null or empty)", this);
			}
			UpdateLocalization(valueTMPro, selectedValueText, LocalizedValues);
		}

		private void UpdateLocalization(TextMeshProUGUI target, string textOrLocalizationTerm, bool localize)
		{
			if (!initialized)
			{
				return;
			}
			Localize localize2 = target.GetComponent<Localize>();
			if (localize && !string.IsNullOrEmpty(textOrLocalizationTerm))
			{
				if (!localize2)
				{
					localize2 = target.gameObject.AddComponent<Localize>();
				}
				localize2.SetTerm(textOrLocalizationTerm);
			}
			else
			{
				if ((bool)localize2)
				{
					UnityEngine.Object.Destroy(localize2);
				}
				target.text = textOrLocalizationTerm;
			}
		}
	}
}
