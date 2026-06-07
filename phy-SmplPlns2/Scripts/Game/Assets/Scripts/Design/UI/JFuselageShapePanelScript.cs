using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class JFuselageShapePanelScript : DesignerPanelScript
	{
		private enum CornerEditMode
		{
			All = 0,
			PerCorner = 1
		}

		private enum CornerMode
		{
			Rounded = 0,
			Stretched = 1
		}

		private enum CuttingEditMode
		{
			Single = 0,
			AllSides = 1
		}

		private enum EdgeEditMode
		{
			All = 0,
			PerEdge = 1
		}

		private enum SectionTab
		{
			Corners = 0,
			Edges = 1,
			Cutting = 2
		}

		private static class EnumDisplayName<T> where T : Enum
		{
			public static Dictionary<T, string> Names { get; private set; }

			static EnumDisplayName()
			{
				Names = new Dictionary<T, string>();
				T[] array = (T[])Enum.GetValues(typeof(T));
				for (int i = 0; i < array.Length; i++)
				{
					T key = array[i];
					Names.Add(key, key.ToString().PascalCaseToDisplay());
				}
			}

			public static string Format(T value)
			{
				if (Names.TryGetValue(value, out var value2))
				{
					return value2;
				}
				return value.ToString();
			}
		}

		private class CornerStyleControl : WidgetControl
		{
			private bool _isPercent;

			private float _maxRoundRadius;

			private float _maxStretchedRadius;

			private CornerMode _mode;

			private float _radius;

			private string _textFormat;

			private TextWidget _unitText;

			public float MaxRadius
			{
				get
				{
					if (_mode != CornerMode.Stretched)
					{
						return _maxRoundRadius;
					}
					return _maxStretchedRadius;
				}
			}

			public float MaxRoundRadius
			{
				get
				{
					return _maxRoundRadius;
				}
				set
				{
					_maxRoundRadius = value;
					if (_mode == CornerMode.Rounded)
					{
						RadiusSlider.MaxValue = _maxRoundRadius;
						UpdateTextFormat();
						UpdateSlider();
					}
				}
			}

			public float MaxStretchedRadius
			{
				get
				{
					return _maxStretchedRadius;
				}
				set
				{
					if (_maxStretchedRadius != value)
					{
						_maxStretchedRadius = value;
						if (_mode == CornerMode.Stretched)
						{
							RadiusSlider.MaxValue = _maxStretchedRadius;
							UpdateTextFormat();
							UpdateSlider();
						}
					}
				}
			}

			public CornerMode Mode
			{
				get
				{
					return _mode;
				}
				set
				{
					SetMode(value, raiseEvents: false, rescaleRadius: false);
				}
			}

			public SpinnerControl<CornerMode> ModeSpinner { get; private set; }

			public float Radius
			{
				get
				{
					return _radius;
				}
				set
				{
					SetRadius(value, raiseEvents: false);
				}
			}

			public InputWidget RadiusInput { get; private set; }

			public SliderWidget RadiusSlider { get; private set; }

			public event OnValueChanged<(CornerMode Mode, float Radius)> OnValueChanged;

			public CornerStyleControl(Widget widget)
				: base(widget)
			{
				ModeSpinner = CreateEnumSpinner<CornerMode>(widget.FindWidget("style-spinner"));
				RadiusSlider = widget.FindWidget<SliderWidget>("radius-slider");
				RadiusInput = widget.FindWidget<InputWidget>("radius-input");
				_unitText = widget.FindWidget<TextWidget>("unit-text");
				ModeSpinner.OnValueChanged = delegate(CornerMode _, CornerMode val)
				{
					SetMode(val, raiseEvents: true, rescaleRadius: true);
				};
				RadiusSlider.NumberOfSteps = 51;
				RadiusSlider.ValueChanged += delegate(float val)
				{
					SetRadius(val, raiseEvents: true);
					UpdateText();
				};
				RadiusInput.Input.onEndEdit.AddListener(delegate(string str)
				{
					if (float.TryParse(str, out var result))
					{
						if (_isPercent)
						{
							result /= 100f;
						}
						result = Mathf.Clamp(result, 0f, (_mode == CornerMode.Rounded) ? _maxRoundRadius : 1f);
						SetRadius(result, raiseEvents: true);
					}
					else
					{
						UpdateText();
					}
				});
				MaxRoundRadius = 2f;
				MaxStretchedRadius = 1f;
				Mode = CornerMode.Rounded;
				Radius = 0.5f;
			}

			public void SetMode(CornerMode mode, bool raiseEvents, bool rescaleRadius)
			{
				CornerMode mode2 = _mode;
				float radius = _radius;
				float num = Radius / MaxRadius;
				if (float.IsNaN(num))
				{
					num = 0f;
				}
				_mode = mode;
				_isPercent = mode == CornerMode.Stretched;
				_unitText.Text = (_isPercent ? "%" : "m");
				float num2 = (RadiusSlider.MaxValue = (_isPercent ? _maxStretchedRadius : _maxRoundRadius));
				float num4 = num2;
				if (rescaleRadius)
				{
					Radius = num * num4;
				}
				else
				{
					Radius = math.min(Radius, num4);
				}
				UpdateTextFormat();
				UpdateText();
				UpdateSlider();
				ModeSpinner.Value = mode;
				if (raiseEvents)
				{
					this.OnValueChanged?.Invoke((mode2, radius), (_mode, _radius));
				}
			}

			public void SetRadius(float radius, bool raiseEvents)
			{
				float radius2 = _radius;
				_radius = radius;
				UpdateText();
				UpdateSlider();
				if (raiseEvents)
				{
					this.OnValueChanged?.Invoke((_mode, radius2), (_mode, radius));
				}
			}

			public void UpdateFromSlice(JFuselageTool.SliceSelection slice, int corner, bool raiseEvents = false)
			{
				CornerMode mode = (slice.GetCornerStretch(corner) ? CornerMode.Stretched : CornerMode.Rounded);
				SetMode(mode, raiseEvents: false, rescaleRadius: false);
				SetRadius(slice.GetCornerRadius(corner), raiseEvents);
			}

			private void UpdateSlider()
			{
				RadiusSlider.Value = Radius;
			}

			private void UpdateText()
			{
				float num = Radius;
				if (_isPercent)
				{
					num *= 100f;
				}
				RadiusInput.Text = num.ToString(_textFormat);
			}

			private void UpdateTextFormat()
			{
				if (_isPercent)
				{
					_textFormat = "0.####";
				}
				else
				{
					_textFormat = "0.#####";
				}
			}
		}

		private class EdgeStyleControl : WidgetControl
		{
			private float _curvature;

			public float Curvature
			{
				get
				{
					return _curvature;
				}
				set
				{
					SetCurvature(value, raiseEvents: false);
				}
			}

			public InputWidget CurvatureInput { get; private set; }

			public SliderWidget CurvatureSlider { get; private set; }

			public event OnValueChanged<float> OnValueChanged;

			public EdgeStyleControl(Widget widget)
				: base(widget)
			{
				CurvatureSlider = widget.FindWidget<SliderWidget>("curvature-slider");
				CurvatureInput = widget.FindWidget<InputWidget>("curvature-input");
				CurvatureSlider.NumberOfSteps = 51;
				CurvatureSlider.ValueChanged += delegate(float val)
				{
					SetCurvature(val, raiseEvents: true);
					UpdateText();
				};
				CurvatureInput.Input.onEndEdit.AddListener(delegate(string str)
				{
					if (float.TryParse(str, out var result))
					{
						result = Mathf.Clamp01(result / 100f);
						SetCurvature(result, raiseEvents: true);
					}
					else
					{
						UpdateText();
					}
				});
				Curvature = 0.5f;
			}

			public void SetCurvature(float curvature, bool raiseEvents)
			{
				float curvature2 = _curvature;
				_curvature = curvature;
				UpdateText();
				UpdateSlider();
				if (raiseEvents)
				{
					this.OnValueChanged?.Invoke(curvature2, curvature);
				}
			}

			public void UpdateFromSlice(JFuselageTool.SliceSelection slice, int edge, bool raiseEvents = false)
			{
				SetCurvature(slice.GetEdgeCurvature(edge), raiseEvents);
			}

			private void UpdateSlider()
			{
				CurvatureSlider.Value = Curvature;
			}

			private void UpdateText()
			{
				float num = Curvature * 100f;
				CurvatureInput.Text = num.ToString("0.####");
			}
		}

		private const string PercentFormat = "0.####";

		private const string SpinnerNumericFormat = "0.#####";

		private ButtonWidget _addSectionButton;

		private CornerStyleControl _allCornerEditor;

		private EdgeStyleControl _allEdgeEditor;

		private SpinnerControl<CornerEditMode> _cornerEditMode;

		private CornerStyleControl[] _cornerEditors;

		private Widget _cornerStylesGroup;

		private SpinnerControl<CuttingEditMode> _cuttingEditMode;

		private DecimalSliderControl[] _cuttingSliders;

		private SpinnerControl<EdgeEditMode> _edgeEditMode;

		private EdgeStyleControl[] _edgeEditors;

		private Widget _edgeStylesGroup;

		private NumericSpinnerControl _heightSpinner;

		private NumericSpinnerControl _lengthSpinner;

		private ButtonWidget _navBackward;

		private ButtonWidget _navForward;

		private NumericSpinnerControl _riseSpinner;

		private SliderControl _roundnessSlider;

		private NumericSpinnerControl _runSpinner;

		private Widget _sectionEditorWidget;

		private JFuselageData _selectedFuselage;

		private SliderControl _singleFillSlider;

		private Widget _sliceEditorWidget;

		private SpinnerControl<JFuselageTool.SmoothingMode> _smoothMode;

		private NumericSpinnerControl _snapSizeSpinner;

		private ButtonWidget[] _tabButtons;

		private Widget[] _tabWidgets;

		private SliderControl _thicknessSlider;

		private JFuselageTool _tool;

		private SliderControl _trapeziumSlider;

		private NumericSpinnerControl _widthSpinner;

		private ToggleControl _syncFacesToggle;

		public float SpinnerIncrement
		{
			get
			{
				if (!(_tool.SnapDistance > 0f))
				{
					return 0.01f;
				}
				return _tool.SnapDistance;
			}
		}

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_navBackward = base.Widget.FindWidget<ButtonWidget>("prev-btn");
			_navForward = base.Widget.FindWidget<ButtonWidget>("next-btn");
			_sliceEditorWidget = base.Widget.FindWidget("slice-editor");
			_addSectionButton = base.Widget.FindWidget<ButtonWidget>("add-section-button");
			_widthSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-width"))
			{
				GetIncrementAmount = () => SpinnerIncrement,
				GetDecrementAmount = () => SpinnerIncrement,
				MinValue = 0f,
				Value = 0.5f,
				NumericFormat = "0.#####",
				OnValueChanged = delegate(float old, float value)
				{
					JFuselageTool.SliceSelection slice = _tool.Slice;
					if (slice != null && !slice.SetWidth(value))
					{
						_widthSpinner.Value = old;
					}
				}
			};
			_heightSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-height"))
			{
				GetIncrementAmount = () => SpinnerIncrement,
				GetDecrementAmount = () => SpinnerIncrement,
				MinValue = 0f,
				Value = 0.5f,
				NumericFormat = "0.#####",
				OnValueChanged = delegate(float old, float value)
				{
					JFuselageTool.SliceSelection slice = _tool.Slice;
					if (slice != null && !slice.SetHeight(value))
					{
						_heightSpinner.Value = old;
					}
				}
			};
			_syncFacesToggle = new ToggleControl(base.Widget.FindWidget("toggle-sync"));
			_syncFacesToggle.ValueChanged += delegate(bool value)
			{
				_tool.SetSliceSync(value);
			};
			_trapeziumSlider = CreatePercentSlider(base.Widget.FindWidget("slider-trapezium"));
			_trapeziumSlider.SetRange(-1f, 1f, 101);
			_trapeziumSlider.OnValueChanged += delegate(float _, float value)
			{
				_tool.Slice?.SetTrapezium(value);
			};
			_thicknessSlider = CreatePercentSlider(base.Widget.FindWidget("slider-thickness"));
			_thicknessSlider.SetRange(0.01f, 1f, 100);
			_thicknessSlider.OnValueChanged += delegate(float _, float value)
			{
				_tool.Slice?.SetThickness(value);
			};
			_smoothMode = CreateEnumSpinner<JFuselageTool.SmoothingMode>(base.Widget.FindWidget("btn-smoothing"));
			SpinnerControl<JFuselageTool.SmoothingMode> smoothMode = _smoothMode;
			smoothMode.OnValueChanged = (OnValueChanged<JFuselageTool.SmoothingMode>)Delegate.Combine(smoothMode.OnValueChanged, (OnValueChanged<JFuselageTool.SmoothingMode>)delegate(JFuselageTool.SmoothingMode _, JFuselageTool.SmoothingMode value)
			{
				_tool.Slice?.SetSmoothingMode(value);
			});
			_tabButtons = new ButtonWidget[4]
			{
				base.Widget.FindWidget<ButtonWidget>("tab-btn-3"),
				base.Widget.FindWidget<ButtonWidget>("tab-btn-0"),
				base.Widget.FindWidget<ButtonWidget>("tab-btn-1"),
				base.Widget.FindWidget<ButtonWidget>("tab-btn-2")
			};
			_tabWidgets = new Widget[4]
			{
				base.Widget.FindWidget("tab-3"),
				base.Widget.FindWidget("tab-0"),
				base.Widget.FindWidget("tab-1"),
				base.Widget.FindWidget("tab-2")
			};
			for (int num = 0; num < _tabButtons.Length; num++)
			{
				_tabButtons[num].Clicked += TabButtonClicked;
			}
			_cornerEditMode = CreateEnumSpinner<CornerEditMode>(base.Widget.FindWidget("corner-style-edit-mode"));
			_allCornerEditor = new CornerStyleControl(base.Widget.FindWidget("corner-styles-all"));
			_allCornerEditor.OnValueChanged += delegate((CornerMode Mode, float Radius) _, (CornerMode Mode, float Radius) value)
			{
				_tool.Slice?.SetAllCornerStretch(value.Mode == CornerMode.Stretched);
				_tool.Slice?.SetAllCornerRadius(value.Radius);
			};
			_cornerEditors = new CornerStyleControl[4];
			for (int num2 = 0; num2 < 4; num2++)
			{
				_cornerEditors[num2] = new CornerStyleControl(base.Widget.FindWidget($"corner-styles-{num2}"));
				int localIndex = num2;
				_cornerEditors[num2].OnValueChanged += delegate((CornerMode Mode, float Radius) _, (CornerMode Mode, float Radius) value)
				{
					_tool.Slice?.SetCornerStretch(localIndex, value.Mode == CornerMode.Stretched);
					_tool.Slice?.SetCornerRadius(localIndex, value.Radius);
				};
			}
			_cornerStylesGroup = base.Widget.FindWidget("corner-styles-widget");
			_cornerEditMode.OnValueChanged = OnCornerEditModeChanged;
			_cornerEditMode.Value = CornerEditMode.All;
			_edgeEditMode = CreateEnumSpinner<EdgeEditMode>(base.Widget.FindWidget("edge-style-edit-mode"));
			_allEdgeEditor = new EdgeStyleControl(base.Widget.FindWidget("edge-styles-all"));
			_allEdgeEditor.OnValueChanged += delegate(float _, float value)
			{
				_tool.Slice?.SetAllEdgeCurvatures(value);
			};
			_edgeEditors = new EdgeStyleControl[4];
			for (int num3 = 0; num3 < 4; num3++)
			{
				_edgeEditors[num3] = new EdgeStyleControl(base.Widget.FindWidget($"edge-curve-{num3}"));
				int localIndex2 = num3;
				_edgeEditors[num3].OnValueChanged += delegate(float _, float x)
				{
					_tool.Slice?.SetEdgeCurvature(localIndex2, x);
				};
			}
			_edgeStylesGroup = base.Widget.FindWidget("edge-styles-widget");
			_edgeEditMode.OnValueChanged = OnEdgeEditModeChanged;
			_edgeEditMode.Value = EdgeEditMode.All;
			Widget widget = base.Widget.FindWidget("cutting-widget");
			_cuttingSliders = new DecimalSliderControl[4]
			{
				CreatePercentSliderDecimal(base.Widget.FindWidget("cutting-top")),
				CreatePercentSliderDecimal(base.Widget.FindWidget("cutting-right")),
				CreatePercentSliderDecimal(base.Widget.FindWidget("cutting-bottom")),
				CreatePercentSliderDecimal(base.Widget.FindWidget("cutting-left"))
			};
			for (int num4 = 0; num4 < 4; num4++)
			{
				int side = num4;
				_cuttingSliders[num4].OnValueChanged += delegate(decimal _, decimal v)
				{
					if (_tool.Slice != null)
					{
						decimal? value = v;
						if (v <= _cuttingSliders[side].MinValue)
						{
							value = null;
						}
						_tool.Slice?.SetCutting(side, value);
					}
				};
			}
			widget.Visible = true;
			SetSelectedTab(0);
			_sliceEditorWidget.Visible = false;
			_sectionEditorWidget = base.Widget.FindWidget("section-editor");
			_lengthSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-length"))
			{
				GetIncrementAmount = () => SpinnerIncrement,
				GetDecrementAmount = () => SpinnerIncrement,
				NumericFormat = "0.#####",
				OnValueChanged = delegate(float old, float value)
				{
					if (!_tool.Section.SetLength(value) && _lengthSpinner.UserEndedEdit)
					{
						_lengthSpinner.Value = _tool.Section.GetLength();
					}
				}
			};
			_riseSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-rise"))
			{
				GetIncrementAmount = () => SpinnerIncrement,
				GetDecrementAmount = () => SpinnerIncrement,
				NumericFormat = "0.#####",
				OnValueChanged = delegate(float _, float value)
				{
					_tool.Section.SetRise(value);
				}
			};
			_runSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-run"))
			{
				GetIncrementAmount = () => SpinnerIncrement,
				GetDecrementAmount = () => SpinnerIncrement,
				NumericFormat = "0.#####",
				OnValueChanged = delegate(float _, float value)
				{
					_tool.Section.SetRun(value);
				}
			};
			_roundnessSlider = CreatePercentSlider(base.Widget.FindWidget("slider-cone-round"));
			_roundnessSlider.SetRange(0f, 1f, 101);
			_roundnessSlider.OnValueChanged += delegate(float _, float value)
			{
				_tool.Section?.SetConeRoundness(value);
			};
			_sectionEditorWidget.Visible = false;
			_snapSizeSpinner = new NumericSpinnerControl(base.Widget.FindWidget("spinner-snap"))
			{
				GetIncrementAmount = GetNextSnapStep,
				GetDecrementAmount = GetPrevSnapStep,
				Value = 0.05f,
				NumericFormat = "0.#####",
				OnValueChanged = delegate(float from, float to)
				{
					_tool.SnapDistance = to;
				}
			};
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
			_tool = designerUI.DesignerScript.Designer.Tools.JFuselageTool;
			_tool.OnSelectionChanged += SyncFromSelection;
			_tool.OnValuesChanged += RefreshValues;
			SyncFromSelection();
		}

		public void RefreshUI()
		{
			SyncFromSelection();
		}

		private static SpinnerControl<T> CreateEnumSpinner<T>(Widget widget) where T : Enum
		{
			SpinnerControl<T> spinnerControl = new SpinnerControl<T>(widget);
			spinnerControl.OnLabelRequested = EnumDisplayName<T>.Format;
			spinnerControl.Values.AddRange((T[])Enum.GetValues(typeof(T)));
			return spinnerControl;
		}

		private static SliderControl CreatePercentSlider(Widget widget)
		{
			SliderControl sliderControl = new SliderControl(widget);
			sliderControl.ValueFormat = "0.####";
			sliderControl.Unit = "%";
			sliderControl.TextValueScale = 100f;
			sliderControl.SetRange(0f, 1f, 51);
			sliderControl.SetValue(0f);
			return sliderControl;
		}

		private static DecimalSliderControl CreatePercentSliderDecimal(Widget widget)
		{
			DecimalSliderControl decimalSliderControl = new DecimalSliderControl(widget);
			decimalSliderControl.Unit = "%";
			decimalSliderControl.TextValueScale = 100m;
			decimalSliderControl.SetRange(0m, 1m, 51);
			decimalSliderControl.SetValue(0m);
			return decimalSliderControl;
		}

		private static decimal? ToDecimal(float value)
		{
			try
			{
				return (decimal)value;
			}
			catch (OverflowException)
			{
				return null;
			}
		}

		private float GetCurrentSnapStep()
		{
			return _snapSizeSpinner.Value;
		}

		private float GetCurrentStepOrDefault()
		{
			float value = _snapSizeSpinner.Value;
			if (value != 0f)
			{
				return value;
			}
			return 0.25f;
		}

		private float GetNextSnapStep()
		{
			return UserInterfaceUtility.GetNextSnapStep(_snapSizeSpinner.Value);
		}

		private float GetPrevSnapStep()
		{
			return UserInterfaceUtility.GetPrevSnapStep(_snapSizeSpinner.Value);
		}

		private void OnAddSectionClicked(Widget widget)
		{
			_tool.AddSection();
			if (UnityEngine.Random.Range(0, 250) == 7)
			{
				Game.Instance.UserInterface.Sound.PlaySound(UISound.Fuselage);
			}
		}

		private void OnCornerEditModeChanged(CornerEditMode old, CornerEditMode value)
		{
			_allCornerEditor.Visible = value == CornerEditMode.All;
			_cornerStylesGroup.Visible = value == CornerEditMode.PerCorner;
			JFuselageTool.SliceSelection slice = _tool.Slice;
			if (slice == null)
			{
				return;
			}
			if (value == CornerEditMode.PerCorner)
			{
				for (int i = 0; i < _cornerEditors.Length; i++)
				{
					_cornerEditors[i].UpdateFromSlice(slice, i);
				}
			}
			else
			{
				_allCornerEditor.UpdateFromSlice(slice, 0);
			}
		}

		private void OnEdgeEditModeChanged(EdgeEditMode old, EdgeEditMode value)
		{
			_allEdgeEditor.Visible = value == EdgeEditMode.All;
			_edgeStylesGroup.Visible = value == EdgeEditMode.PerEdge;
			JFuselageTool.SliceSelection slice = _tool.Slice;
			if (slice == null)
			{
				return;
			}
			if (value == EdgeEditMode.PerEdge)
			{
				for (int i = 0; i < _edgeEditors.Length; i++)
				{
					_edgeEditors[i].UpdateFromSlice(slice, i);
				}
			}
			else
			{
				_allEdgeEditor.UpdateFromSlice(slice, 0);
			}
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			if (_selectedFuselage != null)
			{
				_selectedFuselage.OnShapeDataChanged -= OnShapeDataChanged;
				_selectedFuselage.OnMinCuttingUpdated -= OnMinCuttingUpdated;
				_selectedFuselage = null;
			}
			if (base.Designer.Tools.SelectedTool == _tool && _tool.IsActive)
			{
				base.Designer.Tools.SelectMovePartTool();
			}
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			SyncFromSelection();
		}

		private void OnMinCuttingUpdated(float4[] minSlicing)
		{
			JFuselageTool.SliceSelection slice = _tool.Slice;
			if (slice != null)
			{
				UpdateCuttingSliders(slice);
			}
		}

		private void OnNextClicked(Widget widget)
		{
			_tool.Navigate(forwards: true, apply: true);
		}

		private void OnPrevClicked(Widget widget)
		{
			_tool.Navigate(forwards: false, apply: true);
		}

		private void OnShapeDataChanged()
		{
			JFuselageTool.SliceSelection slice = _tool.Slice;
			if (slice == null)
			{
				return;
			}
			float4 maxCornerRadii = FuselageJob.GetMaxCornerRadii(in slice.BaseParams, stretched: false);
			float4 maxCornerRadii2 = FuselageJob.GetMaxCornerRadii(in slice.BaseParams, stretched: true);
			if (_cornerEditMode.Value == CornerEditMode.All)
			{
				_allCornerEditor.MaxRoundRadius = math.cmax(maxCornerRadii);
				_allCornerEditor.MaxStretchedRadius = math.cmax(maxCornerRadii2);
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				_cornerEditors[i].MaxRoundRadius = maxCornerRadii[i];
				_cornerEditors[i].MaxStretchedRadius = maxCornerRadii2[i];
			}
		}

		private void RefreshValues()
		{
			if (_tool.Section != null)
			{
				_lengthSpinner.Value = _tool.Section.GetLength();
				_riseSpinner.Value = _tool.Section.GetRise();
				_runSpinner.Value = _tool.Section.GetRun();
			}
			if (_tool.Slice != null)
			{
				_widthSpinner.Value = _tool.Slice.GetWidth();
				_heightSpinner.Value = _tool.Slice.GetHeight();
			}
		}

		private void SetSelectedTab(int tab)
		{
			for (int i = 0; i < _tabButtons.Length; i++)
			{
				bool flag = i == tab;
				_tabButtons[i].EnableClass("btn-primary", flag);
				_tabButtons[i].EnableClass("btn-show", flag);
				_tabButtons[i].EnableClass("btn-invis", !flag);
				_tabWidgets[i].Visible = flag;
			}
		}

		private void SyncFromSelection()
		{
			if (!_tool.IsActive)
			{
				return;
			}
			_navBackward.SetStyle("interactable", _tool.CanNavigate(forwards: false).ToString());
			_navForward.SetStyle("interactable", _tool.CanNavigate(forwards: true).ToString());
			JFuselageTool.SliceSelection slice = _tool.Slice;
			JFuselageTool.SectionSelection section = _tool.Section;
			JFuselageData jFuselageData = null;
			if (slice != null)
			{
				jFuselageData = slice.PrimaryFuselage;
				_widthSpinner.Value = slice.GetWidth();
				_heightSpinner.Value = slice.GetHeight();
				_smoothMode.Value = slice.GetSmoothingMode();
				_trapeziumSlider.SetValue(slice.GetTrapezium());
				_thicknessSlider.SetValue(slice.GetThickness());
				_thicknessSlider.Visible = slice.PrimaryFuselage.SliceSupportsThickness(slice.PrimarySliceIndex);
				_addSectionButton.Visible = _tool.CanAddSection();
				_syncFacesToggle.IsOn = slice.SlicesSynced();
				bool flag = slice.PrimaryFuselage.IsCone && slice.PrimarySliceIndex == 1;
				_syncFacesToggle.Visible = !flag;
				_smoothMode.Visible = !flag;
				bool cornersEqual = slice.GetCornersEqual();
				CornerEditMode value = ((!cornersEqual) ? CornerEditMode.PerCorner : CornerEditMode.All);
				OnCornerEditModeChanged(_cornerEditMode.Value, value);
				_cornerEditMode.Value = value;
				OnShapeDataChanged();
				if (cornersEqual)
				{
					_allCornerEditor.UpdateFromSlice(slice, 0);
				}
				else
				{
					for (int i = 0; i < _cornerEditors.Length; i++)
					{
						_cornerEditors[i].UpdateFromSlice(slice, i);
					}
				}
				bool edgesEqual = slice.GetEdgesEqual();
				EdgeEditMode value2 = ((!edgesEqual) ? EdgeEditMode.PerEdge : EdgeEditMode.All);
				OnEdgeEditModeChanged(_edgeEditMode.Value, value2);
				_edgeEditMode.Value = value2;
				if (edgesEqual)
				{
					_allEdgeEditor.UpdateFromSlice(slice, 0);
				}
				else
				{
					for (int j = 0; j < _edgeEditors.Length; j++)
					{
						_edgeEditors[j].UpdateFromSlice(slice, j);
					}
				}
				UpdateCuttingSliders(slice);
			}
			if (section != null)
			{
				jFuselageData = section.PrimaryFuselage;
				_lengthSpinner.Value = section.GetLength();
				_riseSpinner.Value = section.GetRise();
				_runSpinner.Value = section.GetRun();
				_roundnessSlider.SetValue(section.GetConeRoundness());
				_roundnessSlider.Visible = section.PrimaryFuselage.IsCone;
			}
			if (jFuselageData != _selectedFuselage)
			{
				if (_selectedFuselage != null)
				{
					_selectedFuselage.OnShapeDataChanged -= OnShapeDataChanged;
					_selectedFuselage.OnMinCuttingUpdated -= OnMinCuttingUpdated;
				}
				_selectedFuselage = jFuselageData;
				if (jFuselageData != null)
				{
					jFuselageData.OnShapeDataChanged += OnShapeDataChanged;
					jFuselageData.OnMinCuttingUpdated += OnMinCuttingUpdated;
				}
			}
			_sliceEditorWidget.Visible = slice != null;
			_sectionEditorWidget.Visible = section != null;
		}

		private void TabButtonClicked(Widget widget)
		{
			Widget[] tabButtons = _tabButtons;
			SetSelectedTab(Array.IndexOf(tabButtons, widget));
		}

		private void UpdateCuttingSliders(JFuselageTool.SliceSelection slice)
		{
			decimal? num;
			decimal num2;
			decimal num3;
			int num4;
			for (int i = 0; i < _cuttingSliders.Length; _cuttingSliders[i].SetRange(num2, num3, num4 + 1), _cuttingSliders[i].SetValue(num.Value), i++)
			{
				num = slice.GetCutting(i, out var minCutting, out var maxCutting);
				minCutting += 1E-05f;
				maxCutting -= 1E-05f;
				decimal valueOrDefault = ToDecimal(minCutting).GetValueOrDefault();
				decimal obj = ToDecimal(maxCutting) ?? 1m;
				num2 = decimal.Floor(valueOrDefault * 50m) * 0.02m;
				num3 = decimal.Ceiling(obj * 50m) * 0.02m;
				num4 = (int)((num3 - num2) * 50m);
				if (num.HasValue)
				{
					decimal? num5 = num;
					decimal num6 = valueOrDefault;
					if (!((num5.GetValueOrDefault() <= num6) & num5.HasValue))
					{
						continue;
					}
				}
				num = num2;
			}
		}
	}
}
