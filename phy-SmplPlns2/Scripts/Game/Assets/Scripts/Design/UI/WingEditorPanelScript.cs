using System;
using System.Linq;
using System.Text;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.Airfoils;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Collections;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Lightbug.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.UI
{
	public class WingEditorPanelScript : DesignerPanelScript
	{
		private enum AirfoilEditorMode
		{
			Interpolated = 0,
			Simple = 1,
			Advanced = 2
		}

		private const string StatNamePreamble = "<line-height=0%><align=\"left\">";

		private const string StatValuePreamble = "<line-height=100%><align=\"right\">";

		private Widget _addSliceBtn;

		private SpinnerControl<IAirfoilEditor> _airfoilEditorSpinner;

		private EnumSpinnerControl<AirfoilEditorMode> _airfoilMode;

		private AirfoilPreviewWidget _airfoilPreview;

		private Widget _airfoilsAdvanced;

		private Widget _airfoilsSimple;

		private NumericSpinnerControl _bendSpinner;

		private string _cachedAdvancedAirfoil;

		private string _cachedSimpleAirfoil;

		private Widget _changeButtons;

		private ButtonWidget _changeRootBtn;

		private ButtonWidget _changeTipBtn;

		private JWingData _currentWingData;

		private ButtonWidget _deleteSectionButton;

		private bool _hasLayoutedAirfoilPreview;

		private ToggleableNumericSpinnerControl _scaleSpinner;

		private Widget _sectionGroup;

		private SpinnerControl<string> _simpleAirfoilSpinner;

		private ButtonControl _simpleTypeButton;

		private Widget _sliceGroup;

		private NumericSpinnerControl _snapSizeSpinner;

		private TextWidget _statsText;

		private ToggleableNumericSpinnerControl _sweepSpinner;

		private JWingTool _tool;

		private NumericSpinnerControl _widthSpinner;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_tool = designerUI.DesignerScript.Designer.Tools.JWingTool;
			_tool.SelectionChanged += OnToolSelectionChanged;
		}

		public void OnAddSectionClick(Widget widget)
		{
			_tool.AddSection();
		}

		public void OnChangeClicked(Widget widget, int toTip)
		{
			_tool.ChangeSelection(toTip != 0);
		}

		public void OnDeleteSectionClick(Widget widget)
		{
			_tool.DeleteCurrentSection();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_snapSizeSpinner = new NumericSpinnerControl(widget.FindWidget("spinner-snap"))
			{
				GetIncrementAmount = GetNextSnapStep,
				GetDecrementAmount = GetPrevSnapStep,
				Value = 0.05f,
				OnValueChanged = delegate(float from, float to)
				{
					_tool.SnapDistance = to;
				}
			};
			_statsText = widget.FindWidget<TextWidget>("stats-text");
			_changeButtons = widget.FindWidget("change-selection-btns");
			_changeRootBtn = _changeButtons.FindWidget<ButtonWidget>("btn-change-root");
			_changeTipBtn = _changeButtons.FindWidget<ButtonWidget>("btn-change-tip");
			_addSliceBtn = widget.FindWidget("btn-add-section");
			_sliceGroup = widget.FindWidget("slice-widget");
			_scaleSpinner = new ToggleableNumericSpinnerControl(_sliceGroup.FindWidget("spinner-scale"))
			{
				NumericFormat = "0.####",
				StepSize = GetCurrentStepOrDefault(),
				OnValueChanged = delegate(float _, float scale)
				{
					float num = _tool.SetSliceScale(scale);
					if (num != scale && _scaleSpinner.UserEndedEdit)
					{
						_scaleSpinner.Value = num;
					}
					_scaleSpinner.SetToggled(toggled: true, notify: false);
					PushUndo("Wing Scale");
				},
				OnToggleChanged = delegate(ToggleableNumericSpinnerControl _, bool toggled)
				{
					_tool.SliceScaleSet = toggled;
					PushUndo("Wing Scale");
				}
			};
			_bendSpinner = new NumericSpinnerControl(_sliceGroup.FindWidget("spinner-bend"))
			{
				StepSize = 1f,
				OnValueChanged = delegate(float _, float bend)
				{
					float num = Mathf.Clamp(bend, -30f, 30f);
					if (bend != num)
					{
						_bendSpinner.Value = num;
					}
					_tool.SliceBend = num;
					PushUndo("Wing Bend");
				},
				NumericFormat = "0.#",
				Suffix = "°"
			};
			_sectionGroup = widget.FindWidget("section-widget");
			_widthSpinner = new NumericSpinnerControl(_sectionGroup.FindWidget("spinner-width"))
			{
				NumericFormat = "0.####",
				StepSize = GetCurrentStepOrDefault(),
				OnValueChanged = delegate(float _, float width)
				{
					float num = _tool.SetSectionWidth(width);
					if (num != width && _widthSpinner.UserEndedEdit)
					{
						_widthSpinner.Value = num;
					}
					PushUndo("Wing Section Width");
				}
			};
			_sweepSpinner = new ToggleableNumericSpinnerControl(_sectionGroup.FindWidget("spinner-sweep"))
			{
				NumericFormat = "0.####",
				StepSize = GetCurrentStepOrDefault(),
				OnValueChanged = delegate(float _, float sweep)
				{
					_tool.SectionSweep = sweep;
					_sweepSpinner.SetToggled(toggled: true, notify: false);
					PushUndo("Wing Sweep");
				},
				OnToggleChanged = delegate(ToggleableNumericSpinnerControl _, bool toggled)
				{
					_tool.SectionSweepSet = toggled;
					PushUndo("Wing Sweep");
				}
			};
			_airfoilsAdvanced = _sliceGroup.FindWidget("airfoil-advanced");
			_airfoilsSimple = _sliceGroup.FindWidget("airfoil-simple");
			_airfoilMode = new EnumSpinnerControl<AirfoilEditorMode>(_sliceGroup.FindWidget("airfoil-mode"), "button", null)
			{
				OnValueChanged = OnAirfoilModeChange
			};
			_simpleAirfoilSpinner = new SpinnerControl<string>(_airfoilsSimple.FindWidget("airfoil-simple-type"), "button", null);
			_simpleAirfoilSpinner.Values.AddRange(AirfoilRegistry.SimpleAirfoilPresets.Keys);
			SpinnerControl<string> simpleAirfoilSpinner = _simpleAirfoilSpinner;
			simpleAirfoilSpinner.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(simpleAirfoilSpinner.OnValueChanged, new OnValueChanged<string>(OnAirfoilSimpleTypeChange));
			_airfoilEditorSpinner = new SpinnerControl<IAirfoilEditor>(_airfoilsAdvanced.FindWidget("airfoil-advanced-type"), "button", null)
			{
				OnValueChanged = OnAirfoilAdvancedModeChange,
				OnLabelRequested = (IAirfoilEditor e) => e.Name
			};
			_airfoilPreview = _sliceGroup.FindWidgetComponent<AirfoilPreviewWidget>("airfoil-preview");
			AddAirfoilEditor(new Naca4Editor(_airfoilsAdvanced));
			_deleteSectionButton = _sectionGroup.FindWidget<ButtonWidget>("button-delete-section");
		}

		protected void OnDestroy()
		{
			if (_tool != null)
			{
				_tool.SelectionChanged -= OnToolSelectionChanged;
			}
		}

		private static string FormatPercent(float v)
		{
			return (0.01f * v).ToString("P0");
		}

		private void AddAirfoilEditor(IAirfoilEditor editor)
		{
			_airfoilEditorSpinner.Values.Add(editor);
			editor.OnAirfoilChanged += delegate(string s)
			{
				SetAirfoil(s);
				PushUndo("Wing Airfoil");
			};
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

		private void OnAirfoilAdvancedModeChange(IAirfoilEditor oldMode, IAirfoilEditor newMode)
		{
			oldMode.SetVisible(visible: false);
			newMode.SetVisible(visible: true);
			PushUndo("Wing Airfoil Mode");
		}

		private void OnAirfoilModeChange(AirfoilEditorMode oldMode, AirfoilEditorMode mode)
		{
			if (mode == AirfoilEditorMode.Interpolated && _tool.SelectionIsFirst)
			{
				mode = AirfoilEditorMode.Simple;
				_airfoilMode.Value = mode;
			}
			_airfoilsSimple.Visible = mode == AirfoilEditorMode.Simple;
			_airfoilsAdvanced.Visible = mode == AirfoilEditorMode.Advanced;
			switch (oldMode)
			{
			case AirfoilEditorMode.Advanced:
				_cachedAdvancedAirfoil = _tool.SliceAirfoil;
				break;
			case AirfoilEditorMode.Simple:
				_cachedSimpleAirfoil = _tool.SliceAirfoil;
				break;
			}
			if (oldMode != mode)
			{
				switch (mode)
				{
				case AirfoilEditorMode.Simple:
				{
					string text = _cachedSimpleAirfoil ?? _simpleAirfoilSpinner.Values.FirstOrDefault();
					SetAirfoil(text);
					_simpleAirfoilSpinner.Value = text;
					break;
				}
				case AirfoilEditorMode.Advanced:
					if (_cachedAdvancedAirfoil != null)
					{
						SetAirfoil(_cachedAdvancedAirfoil);
						UpdateAdvancedAirfoilUI(_cachedAdvancedAirfoil);
					}
					else
					{
						ResetAdvancedAirfoilUI();
					}
					break;
				case AirfoilEditorMode.Interpolated:
					SetAirfoil(null);
					break;
				}
			}
			PushUndo("Wing Airfoil Mode");
		}

		private void OnAirfoilSimpleTypeChange(string oldType, string newType)
		{
			SetAirfoil(newType);
			PushUndo("Wing Airfoil Mode");
		}

		private void OnToolSelectionChanged(JWingData wing, JWingTool.SelectionType selectionType, int selection, ControlSurfacePartScript controlSurface)
		{
			if (wing != _currentWingData)
			{
				if (_currentWingData != null)
				{
					_currentWingData.WingDataChanged -= OnWingDataEdit;
				}
				_currentWingData = wing;
				wing.WingDataChanged += OnWingDataEdit;
			}
			UpdateStats();
			_changeButtons.Visible = controlSurface == null;
			(bool, bool) tuple = _tool.CanChangeSelection();
			_changeTipBtn.EnableClass("disabled", !tuple.Item1);
			_changeRootBtn.EnableClass("disabled", !tuple.Item2);
			_addSliceBtn.Visible = _tool.CanAddSlice();
			_sliceGroup.Visible = selectionType == JWingTool.SelectionType.Slice;
			_sectionGroup.Visible = selectionType == JWingTool.SelectionType.Section;
			if (_sliceGroup.Visible)
			{
				_scaleSpinner.Value = _tool.SliceScale.Value;
				_scaleSpinner.SetToggled(_tool.SliceScaleSet, notify: false);
				_bendSpinner.Value = _tool.SliceBend;
				UpdateAirfoilFromSlice();
			}
			if (_sectionGroup.Visible)
			{
				_widthSpinner.Value = _tool.SectionWidth.Value;
				_sweepSpinner.Value = _tool.SectionSweep.Value;
				_deleteSectionButton.Visible = _tool.CanDeleteSection;
			}
		}

		private void OnWingDataEdit()
		{
			_scaleSpinner.SetToggled(_tool.SliceScaleSet, notify: false);
			_sweepSpinner.SetToggled(_tool.SectionSweepSet, notify: false);
			UpdateStats();
		}

		private void PushUndo(string description)
		{
			string replaceKey = ((_tool.CurrentSlice != null) ? $"WingEditPanel-slice-{_tool.SelectionBaseIndex}" : ((!_tool.CurrentSection.HasValue) ? "WingEditPanel" : $"WingEditPanel-section-{_tool.SelectionBaseIndex}"));
			base.Designer.CreateUndoStepForSelectedPart(description, replaceKey);
		}

		private void ResetAdvancedAirfoilUI()
		{
			Jundroo.Common.Collections.CircularList<IAirfoilEditor> values = _airfoilEditorSpinner.Values;
			_airfoilEditorSpinner.Value = values[0];
			for (int i = 0; i < values.Count; i++)
			{
				values[i].SetVisible(i == 0);
			}
		}

		private void SetAirfoil(string airfoil)
		{
			_tool.SliceAirfoil = airfoil;
			UpdateAirfoilPreview();
		}

		private void UpdateAdvancedAirfoilUI(string airfoil)
		{
			airfoil = airfoil?.Trim();
			Jundroo.Common.Collections.CircularList<IAirfoilEditor> values = _airfoilEditorSpinner.Values;
			bool flag = false;
			foreach (IAirfoilEditor item in values)
			{
				if (!flag && airfoil != null && item.TryLoad(airfoil))
				{
					flag = true;
					_airfoilEditorSpinner.Value = item;
				}
				else
				{
					item.SetVisible(visible: false);
				}
			}
			if (!flag)
			{
				ResetAdvancedAirfoilUI();
			}
		}

		private void UpdateAirfoilFromSlice()
		{
			UpdateAirfoilPreview();
			InputWingSlice currentSlice = _tool.CurrentSlice;
			AirfoilEditorMode airfoilEditorMode;
			if (currentSlice.Airfoil.IsNullOrWhiteSpace())
			{
				airfoilEditorMode = AirfoilEditorMode.Interpolated;
			}
			else if (AirfoilRegistry.SimpleAirfoilPresets.ContainsKey(currentSlice.Airfoil))
			{
				airfoilEditorMode = AirfoilEditorMode.Simple;
				_simpleAirfoilSpinner.Value = currentSlice.Airfoil;
			}
			else
			{
				airfoilEditorMode = AirfoilEditorMode.Advanced;
			}
			_airfoilMode.Value = airfoilEditorMode;
			_airfoilsSimple.Visible = airfoilEditorMode == AirfoilEditorMode.Simple;
			_airfoilsAdvanced.Visible = airfoilEditorMode == AirfoilEditorMode.Advanced;
			_cachedAdvancedAirfoil = null;
			_cachedSimpleAirfoil = null;
			if (airfoilEditorMode != AirfoilEditorMode.Advanced)
			{
				return;
			}
			UpdateAdvancedAirfoilUI(currentSlice.Airfoil);
			foreach (IAirfoilEditor value in _airfoilEditorSpinner.Values)
			{
				if (value != _airfoilEditorSpinner.Value)
				{
					value.LoadDefault();
				}
			}
		}

		private void UpdateAirfoilPreview()
		{
			if (!_hasLayoutedAirfoilPreview)
			{
				_hasLayoutedAirfoilPreview = true;
				LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)base.Widget.transform);
			}
			_airfoilPreview.SetAirfoil(_tool.CurrentSlice?.LastDerivedSliceRoot?.Airfoil);
		}

		private void UpdateStats()
		{
			StringBuilder s = new StringBuilder();
			JWingData jWingData = _tool?.CurrentWing;
			if (jWingData != null)
			{
				AddStat("Wingspan", jWingData.WingSpan.Format(UnitType.ShortDistance, solo: false, longName: false, "#,##0.0", rtf: true));
				AddStat("Wing Area", jWingData.WingArea.Format(UnitType.Area, solo: false, longName: false, "#,##0.0", rtf: true));
				AddStat("Section Count", jWingData.WingSlices.Count.ToString());
			}
			else
			{
				s.Append("No wing selected.");
			}
			StringBuilder stringBuilder = s;
			if (stringBuilder[stringBuilder.Length - 1] == '\n')
			{
				s.Length--;
			}
			_statsText.TextMeshPro.richText = true;
			_statsText.Text = s.ToString();
			void AddStat(string name, string value)
			{
				s.Append("<line-height=0%><align=\"left\">");
				s.AppendLine(name);
				s.Append("<line-height=100%><align=\"right\">");
				s.AppendLine(value);
			}
		}
	}
}
