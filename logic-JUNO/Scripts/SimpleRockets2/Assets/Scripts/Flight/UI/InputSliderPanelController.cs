using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Ui;
using ModApi.Craft;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class InputSliderPanelController : FlightPanelController
	{
		private XmlElement _addSliderButtonTemplate;

		private XmlElement _addSliderPanel;

		private XmlElement _addSliderParent;

		private bool _expanded = true;

		private XmlElement _panel;

		private XmlElement _removeSliderButton;

		private XmlElement _sliderParent;

		private List<InputSlider> _sliders = new List<InputSlider>();

		private XmlElement _sliderTemplate;

		public CraftControls Controls { get; private set; }

		public bool IsAddSliderPanelVisible => _addSliderPanel.Visible;

		public override void CraftNodeChanged(CraftNode craftNode)
		{
			Controls = craftNode?.Controls;
		}

		public override void Initialize(FlightSceneUiController flightSceneUiController)
		{
			base.Initialize(flightSceneUiController);
		}

		public bool IsSliderVisible(string sliderName)
		{
			return _sliders.Where((InputSlider x) => x.Name == sliderName && x.IsUiCreated).Any();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			if (Application.isPlaying)
			{
				_panel = base.xmlLayout.GetElementById("input-panel");
				_addSliderPanel = base.xmlLayout.GetElementById("add-slider-panel");
				_sliderParent = base.xmlLayout.GetElementById("slider-parent");
				_sliderTemplate = base.xmlLayout.GetElementById("slider-template");
				_addSliderButtonTemplate = base.xmlLayout.GetElementById("add-slider-template");
				_addSliderParent = base.xmlLayout.GetElementById("add-slider-parent");
				_removeSliderButton = base.xmlLayout.GetElementById("remove-slider-button");
				AddInputSlider("ROLL", () => Controls.Roll, delegate(float x)
				{
					CraftControls controls = Controls;
					float roll = (Controls.OffsetRoll = x);
					controls.Roll = roll;
				});
				AddInputSlider("PITCH", () => Controls.Pitch, delegate(float x)
				{
					CraftControls controls = Controls;
					float pitch = (Controls.OffsetPitch = x);
					controls.Pitch = pitch;
				});
				AddInputSlider("YAW", () => Controls.Yaw, delegate(float x)
				{
					CraftControls controls = Controls;
					float yaw = (Controls.OffsetYaw = x);
					controls.Yaw = yaw;
				});
				AddInputSlider("THROTTLE", () => Controls.Throttle, delegate(float x)
				{
					CraftControls controls = Controls;
					float throttle = (Controls.Throttle = x);
					controls.Throttle = throttle;
				}).AllowNegative = false;
				AddInputSlider("BRAKE", () => Controls.Brake, delegate(float x)
				{
					CraftControls controls = Controls;
					float brake = (Controls.OffsetBrake = x);
					controls.Brake = brake;
				}).AllowNegative = false;
				AddInputSlider("SLIDER 1", () => Controls.Slider1, delegate(float x)
				{
					CraftControls controls = Controls;
					float slider = (Controls.OffsetSlider1 = x);
					controls.Slider1 = slider;
				});
				AddInputSlider("SLIDER 2", () => Controls.Slider2, delegate(float x)
				{
					CraftControls controls = Controls;
					float slider = (Controls.OffsetSlider2 = x);
					controls.Slider2 = slider;
				});
				AddInputSlider("SLIDER 3", () => Controls.Slider3, delegate(float x)
				{
					CraftControls controls = Controls;
					float slider = (Controls.OffsetSlider3 = x);
					controls.Slider3 = slider;
				});
				AddInputSlider("SLIDER 4", () => Controls.Slider4, delegate(float x)
				{
					CraftControls controls = Controls;
					float slider = (Controls.OffsetSlider4 = x);
					controls.Slider4 = slider;
				});
				AddInputSlider("FORWARD", () => Controls.TranslateForward, delegate(float x)
				{
					CraftControls controls = Controls;
					float translateForward = (Controls.OffsetTranslateForward = x);
					controls.TranslateForward = translateForward;
				});
				AddInputSlider("RIGHT", () => Controls.TranslateRight, delegate(float x)
				{
					CraftControls controls = Controls;
					float translateRight = (Controls.OffsetTranslateRight = x);
					controls.TranslateRight = translateRight;
				});
				AddInputSlider("UP", () => Controls.TranslateUp, delegate(float x)
				{
					CraftControls controls = Controls;
					float translateUp = (Controls.OffsetTranslateUp = x);
					controls.TranslateUp = translateUp;
				});
				UpdateLayout();
			}
		}

		public override void UpdatePanel(CraftNode craftNode)
		{
		}

		protected virtual void Start()
		{
			string text = Game.Instance.Settings.Game.Flight.VisibleFlightInputSliders;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			string[] array = text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				return;
			}
			string[] array2 = array;
			foreach (string sliderName in array2)
			{
				InputSlider inputSlider = _sliders.Where((InputSlider x) => x.Name == sliderName).FirstOrDefault();
				if (inputSlider != null)
				{
					OnAddSliderPanelClicked(inputSlider);
				}
			}
			_addSliderPanel.SetActive(active: false);
		}

		private InputSlider AddInputSlider(string sliderName, Func<float> getAction, Action<float> setAction)
		{
			InputSlider slider = new InputSlider(getAction, setAction);
			slider.Name = sliderName;
			XmlElement xmlElement = UiUtilities.CloneTemplate(_addSliderButtonTemplate, _addSliderParent);
			xmlElement.name = "InputSliderPanel.Add" + sliderName;
			xmlElement.AddOnClickEvent(delegate
			{
				OnAddSliderPanelClicked(slider);
			});
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("label").text = sliderName;
			_sliders.Add(slider);
			return slider;
		}

		private void ExpandPanel(bool expand)
		{
			if (_expanded != expand)
			{
				_expanded = expand;
				_removeSliderButton.SetActive(expand);
				_sliderParent.SetActive(expand);
				_addSliderPanel.SetActive(expand);
				if (expand)
				{
					_panel.RemoveClass("collapsed");
					UpdateLayout();
				}
				else
				{
					_panel.AddClass("collapsed");
				}
			}
		}

		private void OnAddSliderPanelClicked(InputSlider slider)
		{
			if (!slider.IsUiCreated)
			{
				slider.CreateUi(UiUtilities.CloneTemplate(_sliderTemplate, _sliderParent));
			}
			slider.Element.transform.SetAsLastSibling();
			_sliders.Remove(slider);
			_sliders.Add(slider);
			UpdateLayout(saveOpenSlidersState: true);
			_addSliderPanel.Hide();
		}

		private void OnRemoveSliderClicked()
		{
			for (int num = _sliders.Count - 1; num >= 0; num--)
			{
				if (_sliders[num].IsUiCreated)
				{
					_sliders[num].DestroyUi();
					break;
				}
			}
			_addSliderPanel.Hide();
			UpdateLayout(saveOpenSlidersState: true);
		}

		private void OnShowAddSliderPanelClicked()
		{
			if (_addSliderPanel.Visible)
			{
				_addSliderPanel.Hide();
			}
			else
			{
				_addSliderPanel.Show();
			}
		}

		private void UpdateLayout(bool saveOpenSlidersState = false)
		{
			string text = string.Empty;
			int num = 0;
			foreach (InputSlider slider in _sliders)
			{
				if (slider.Element != null)
				{
					text = text + slider.Name + ",";
					num++;
				}
			}
			if (saveOpenSlidersState)
			{
				Game.Instance.Settings.Game.Flight.VisibleFlightInputSliders.UpdateAndCommit(text);
			}
			_panel.SetAndApplyAttribute("width", $"{num * 80 + 25}");
			ExpandPanel(num > 0);
		}
	}
}
