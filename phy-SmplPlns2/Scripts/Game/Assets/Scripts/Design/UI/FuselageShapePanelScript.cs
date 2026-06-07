using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class FuselageShapePanelScript : DesignerPanelScript
	{
		private const string NudgeNumericFormat = "n4";

		private Widget _addSectionButton;

		private List<SliderControl> _advancedCuttingWidgets = new List<SliderControl>();

		private SpinnerControl _cornerStyle1Button;

		private SpinnerControl _cornerStyle2Button;

		private SpinnerControl _cornerStyle3Button;

		private SpinnerControl _cornerStyle4Button;

		private SpinnerControl _cornerStylesButton;

		private Widget _cornerStylesWidget;

		private Widget _doneEditingButton;

		private SliderControl _fillBottom;

		private SliderControl _fillLeft;

		private SliderControl _fillRight;

		private SliderControl _fillTop;

		private SliderControl _fillVertical;

		private NumericSpinnerControl _length;

		private Widget _nextPrevButtonWidget;

		private NumericSpinnerControl _rise;

		private NumericSpinnerControl _run;

		private FuselageTool.FuselageSelection _selection;

		private Widget _sizeWidget;

		private NumericSpinnerControl _sliceHeight;

		private Widget _sliceWidget;

		private NumericSpinnerControl _sliceWidth;

		private bool _updateUi;

		public FuselageScript SelectedFuselagePart
		{
			get
			{
				if (base.Designer.Tools.SelectedTool == FuselageTool)
				{
					FuselageTool.FuselageSelection currentSelection = FuselageTool.CurrentSelection;
					if (currentSelection != null && !currentSelection.IsSlice)
					{
						return FuselageTool.CurrentSelection.Fuselage;
					}
				}
				if (base.Designer.SelectedPart != null)
				{
					return base.Designer.SelectedPart.GetModifier<FuselageScript>();
				}
				return null;
			}
		}

		private FuselageTool FuselageTool => base.Designer.Tools.FuselageTool;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			base.Designer.SelectedPartChangedEvent += OnSelectedPartChangedEvent;
			base.Flyout.Closed += OnFlyoutClosed;
			_sliceWidth = CreateNumericSpinner("spinner-width");
			_sliceWidth.OnValueChanged = delegate(float _, float x)
			{
				OnChangeWidth(x);
			};
			_sliceHeight = CreateNumericSpinner("spinner-height");
			_sliceHeight.OnValueChanged = delegate(float _, float x)
			{
				OnChangeHeight(x);
			};
			_length = CreateNumericSpinner("spinner-length");
			_length.OnValueChanged = delegate(float _, float x)
			{
				OnChangeLength(x);
			};
			_rise = CreateNumericSpinner("spinner-rise");
			_rise.OnValueChanged = delegate(float _, float x)
			{
				OnChangeRise(x);
			};
			_run = CreateNumericSpinner("spinner-run");
			_run.OnValueChanged = delegate(float _, float x)
			{
				OnChangeRun(x);
			};
			_sizeWidget = base.Widget.FindWidget("size-widget");
			_sliceWidget = base.Widget.FindWidget("slice-widget");
			_nextPrevButtonWidget = base.Widget.FindWidget("next-prev-buttons");
			_doneEditingButton = base.Widget.FindWidget("done-button");
			_addSectionButton = base.Widget.FindWidget("add-section-button");
			_cornerStylesWidget = base.Widget.FindWidget("corner-styles-widget");
			_fillVertical = new SliderControl(base.Widget.FindWidget("fill-vertical"));
			_fillVertical.ValueFormatter = (float x) => Utilities.FormatPercentage(x, 1);
			_fillVertical.Slider.ValueChanged += OnChangeVerticalFill;
			_fillLeft = CreateFillSlider("fill-left", delegate(float x)
			{
				FuselageData.FillParameters fillAmount = FuselageTool.CurrentSelection.FillAmount;
				fillAmount.Left = x;
				return fillAmount;
			});
			_fillRight = CreateFillSlider("fill-right", delegate(float x)
			{
				FuselageData.FillParameters fillAmount = FuselageTool.CurrentSelection.FillAmount;
				fillAmount.Right = x;
				return fillAmount;
			});
			_fillTop = CreateFillSlider("fill-top", delegate(float x)
			{
				FuselageData.FillParameters fillAmount = FuselageTool.CurrentSelection.FillAmount;
				fillAmount.Top = x;
				return fillAmount;
			});
			_fillBottom = CreateFillSlider("fill-bottom", delegate(float x)
			{
				FuselageData.FillParameters fillAmount = FuselageTool.CurrentSelection.FillAmount;
				fillAmount.Bottom = x;
				return fillAmount;
			});
			SpinnerControl obj = new SpinnerControl(base.Widget.FindWidget("spinner-fill-type"))
			{
				Values = { "Simple", "Advanced" }
			};
			obj.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(obj.OnValueChanged, (OnValueChanged<string>)delegate(string _, string value)
			{
				EnableAdvancedCutting(value != "Simple");
			});
			obj.Value = "Simple";
			EnableAdvancedCutting(enabled: false);
			_cornerStylesButton = CreateCornerStyleButton("spinner-style");
			_cornerStyle1Button = CreateCornerStyleButton("spinner-style-1", 0);
			_cornerStyle2Button = CreateCornerStyleButton("spinner-style-2", 1);
			_cornerStyle3Button = CreateCornerStyleButton("spinner-style-3", 2);
			_cornerStyle4Button = CreateCornerStyleButton("spinner-style-4", 3);
		}

		public void OnChangeVerticalFill(float value)
		{
			value = Mathf.Clamp01(value);
			if (value > 0.99f)
			{
				value = 1f;
			}
			bool flag = false;
			if (FuselageTool.CurrentSelection.IsSlice)
			{
				for (int i = 0; i < FuselageTool.CurrentSelection.Slices.Count; i++)
				{
					if (FuselageTool.CurrentSelection.Slices[i].FillAmount.Top != value)
					{
						flag = true;
					}
				}
			}
			else
			{
				flag = FuselageTool.CurrentSelection.Fuselage.Fuselage.FillFront.Top != value || FuselageTool.CurrentSelection.Fuselage.Fuselage.FillBack.Top != value;
			}
			if (flag)
			{
				FuselageData.FillParameters fillAmount = FuselageTool.CurrentSelection.FillAmount;
				fillAmount.Top = value;
				FuselageTool.CurrentSelection.FillAmount = fillAmount;
				FuselageTool.CurrentSelection.UpdateMeshes();
			}
		}

		protected virtual void Update()
		{
			if (base.Designer.Tools.SelectedTool == FuselageTool)
			{
				if (_selection == FuselageTool.CurrentSelection && !_updateUi)
				{
					return;
				}
				_updateUi = false;
				_selection = FuselageTool.CurrentSelection;
				_doneEditingButton.Visible = true;
				_nextPrevButtonWidget.Visible = true;
				if (FuselageTool.CurrentSelection.IsSlice)
				{
					_sizeWidget.Visible = false;
					_sliceWidget.Visible = true;
					Vector2 sliceScale = FuselageTool.CurrentSelection.SliceScale;
					_sliceWidth.Value = sliceScale.x;
					_sliceHeight.Value = sliceScale.y;
					_addSectionButton.Visible = FuselageTool.CanAddSection;
					FuselageData fuselage = FuselageTool.CurrentSelection.Slices[0].Fuselage.Fuselage;
					int num = 0;
					if (!FuselageTool.CurrentSelection.Slices[0].IsFront)
					{
						num = 4;
					}
					_cornerStyle1Button.Value = GetCornerLabel(fuselage.CornerTypes[num]);
					_cornerStyle2Button.Value = GetCornerLabel(fuselage.CornerTypes[num + 1]);
					_cornerStyle3Button.Value = GetCornerLabel(fuselage.CornerTypes[num + 2]);
					_cornerStyle4Button.Value = GetCornerLabel(fuselage.CornerTypes[num + 3]);
					if (fuselage.CornerTypes[num] == fuselage.CornerTypes[num + 1] && fuselage.CornerTypes[num + 1] == fuselage.CornerTypes[num + 2] && fuselage.CornerTypes[num + 2] == fuselage.CornerTypes[num + 3])
					{
						_cornerStylesButton.Value = GetCornerLabel(fuselage.CornerTypes[num]);
						_cornerStylesWidget.gameObject.SetActive(value: false);
					}
					else
					{
						_cornerStylesButton.Value = "Manual";
						_cornerStylesWidget.gameObject.SetActive(value: true);
					}
				}
				else
				{
					_sizeWidget.Visible = true;
					_sliceWidget.Visible = false;
					_addSectionButton.Visible = false;
					Vector3 offset = FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset;
					_run.Value = offset.x;
					_rise.Value = offset.y;
					_length.Value = offset.z;
				}
				UpdateFillSliders();
			}
			else
			{
				_updateUi = false;
				_selection = null;
				_sizeWidget.Visible = false;
				_sliceWidget.Visible = false;
				_nextPrevButtonWidget.Visible = false;
				_doneEditingButton.Visible = false;
			}
		}

		private static string GetCornerLabel(int cornerType)
		{
			return cornerType switch
			{
				2 => "Curved", 
				1 => "Smooth", 
				3 => "Circular", 
				_ => "Hard", 
			};
		}

		private void ChangeParameters(Vector2 changeSliceScale, Vector3 changeSize)
		{
			FuselageTool.ModifyCurrentSelection(changeSliceScale * 0.5f, changeSize);
			_updateUi = true;
			CreateUndoStep("Fuselage Parameters");
		}

		private void CornerButtonClicked(int cornerButton, string value)
		{
			int cornerType = 0;
			switch (value)
			{
			case "Curved":
				cornerType = 2;
				break;
			case "Smooth":
				cornerType = 1;
				break;
			case "Circular":
				cornerType = 3;
				break;
			}
			if (!FuselageTool.CurrentSelection.IsSlice)
			{
				return;
			}
			foreach (List<FuselageTool.FuselageSelection.Slice> allSliceGroup in FuselageTool.CurrentSelection.AllSliceGroups)
			{
				foreach (FuselageTool.FuselageSelection.Slice item in allSliceGroup)
				{
					item.SetCornerType(cornerButton, cornerType);
				}
			}
		}

		private SpinnerControl CreateCornerStyleButton(string id, int index = -1)
		{
			SpinnerControl spinnerControl = new SpinnerControl(base.Widget.FindWidget(id));
			spinnerControl.Values.Add("Curved");
			spinnerControl.Values.Add("Smooth");
			spinnerControl.Values.Add("Hard");
			spinnerControl.Values.Add("Circular");
			if (index == -1)
			{
				spinnerControl.Values.Add("Manual");
				spinnerControl.OnValueChanged = delegate(string _, string value)
				{
					OnCornerStylesChanged(value);
				};
			}
			else
			{
				spinnerControl.OnValueChanged = delegate(string _, string value)
				{
					CornerButtonClicked(index, value);
				};
			}
			return spinnerControl;
		}

		private SliderControl CreateFillSlider(string id, Func<float, FuselageData.FillParameters> changeAction)
		{
			SliderControl sliderControl = new SliderControl(base.Widget.FindWidget(id));
			sliderControl.ValueFormatter = (float x) => Utilities.FormatPercentage(x, 1);
			sliderControl.Slider.ValueChanged += delegate(float x)
			{
				FuselageData.FillParameters fillAmount = changeAction(x);
				FuselageTool.CurrentSelection.FillAmount = fillAmount;
				FuselageTool.CurrentSelection.UpdateMeshes();
				CreateUndoStep("Fuselage Fill");
			};
			_advancedCuttingWidgets.Add(sliderControl);
			return sliderControl;
		}

		private NumericSpinnerControl CreateNumericSpinner(string id)
		{
			return new NumericSpinnerControl(base.Widget.FindWidget(id))
			{
				GetIncrementAmount = () => 0.25f,
				GetDecrementAmount = () => 0.25f,
				NumericFormat = "0.#####"
			};
		}

		private void CreateUndoStep(string propertyName)
		{
			base.Designer.CreateUndoStepForSelectedPart(propertyName);
		}

		private void EnableAdvancedCutting(bool enabled)
		{
			_fillVertical.Visible = !enabled;
			foreach (SliderControl advancedCuttingWidget in _advancedCuttingWidgets)
			{
				advancedCuttingWidget.Visible = enabled;
			}
			UpdateFillSliders();
		}

		private void OnAddSectionClicked(Widget widget)
		{
			FuselageScript fuselage = FuselageTool.AddSection();
			StartCoroutine(SelectFuselage(fuselage));
		}

		private void OnChangedHeight(float value)
		{
			Vector2 sliceScale = FuselageTool.CurrentSelection.SliceScale;
			sliceScale.y = value;
			if (sliceScale.y != FuselageTool.CurrentSelection.SliceScale.y && (FuselageTool.CurrentSelection.Slices.Count <= 1 || !(sliceScale.y <= 0f)))
			{
				ChangeParameters((sliceScale - FuselageTool.CurrentSelection.SliceScale) * 2f, Vector3.zero);
			}
		}

		private void OnChangeHeight(float value)
		{
			Vector2 sliceScale = FuselageTool.CurrentSelection.SliceScale;
			sliceScale.y = value;
			if (sliceScale.y != FuselageTool.CurrentSelection.SliceScale.y && (FuselageTool.CurrentSelection.Slices.Count <= 1 || !(sliceScale.y <= 0f)))
			{
				ChangeParameters((sliceScale - FuselageTool.CurrentSelection.SliceScale) * 2f, Vector3.zero);
			}
		}

		private void OnChangeLength(float value)
		{
			Vector3 offset = FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset;
			offset.z = value;
			if (offset.z != FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset.z && !(offset.z <= 0f))
			{
				ChangeParameters(Vector2.zero, offset - FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset);
			}
		}

		private void OnChangeRise(float value)
		{
			Vector3 offset = FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset;
			offset.y = value;
			if (offset.y != FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset.y)
			{
				ChangeParameters(Vector2.zero, offset - FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset);
			}
		}

		private void OnChangeRun(float value)
		{
			Vector3 offset = FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset;
			offset.x = value;
			if (offset.x != FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset.x)
			{
				ChangeParameters(Vector2.zero, offset - FuselageTool.CurrentSelection.Fuselage.Fuselage.Offset);
			}
		}

		private void OnChangeWidth(float value)
		{
			Vector2 sliceScale = FuselageTool.CurrentSelection.SliceScale;
			sliceScale.x = value;
			if (sliceScale.x != FuselageTool.CurrentSelection.SliceScale.x && (FuselageTool.CurrentSelection.Slices.Count <= 1 || !(sliceScale.x <= 0f)))
			{
				ChangeParameters((sliceScale - FuselageTool.CurrentSelection.SliceScale) * 2f, Vector3.zero);
			}
		}

		private void OnCornerStylesChanged(string value)
		{
			int num = 0;
			switch (value)
			{
			case "Curved":
				num = 2;
				break;
			case "Smooth":
				num = 1;
				break;
			case "Circular":
				num = 3;
				break;
			}
			if (value == "Manual")
			{
				_cornerStylesWidget.gameObject.SetActive(value: true);
				_cornerStyle1Button.Value = GetCornerLabel(num);
				_cornerStyle2Button.Value = GetCornerLabel(num);
				_cornerStyle3Button.Value = GetCornerLabel(num);
				_cornerStyle4Button.Value = GetCornerLabel(num);
			}
			else
			{
				_cornerStylesWidget.gameObject.SetActive(value: false);
			}
			if (FuselageTool.CurrentSelection.IsSlice)
			{
				foreach (List<FuselageTool.FuselageSelection.Slice> allSliceGroup in FuselageTool.CurrentSelection.AllSliceGroups)
				{
					foreach (FuselageTool.FuselageSelection.Slice item in allSliceGroup)
					{
						int num2 = 0;
						if (!item.IsFront)
						{
							num2 = 4;
						}
						for (int i = 0; i < 4; i++)
						{
							item.Fuselage.Fuselage.CornerTypes[i + num2] = num;
						}
						item.Fuselage.UpdateMeshes();
					}
				}
			}
			CreateUndoStep("Fuselage Corner Style");
		}

		private void OnDoneClicked(Widget widget)
		{
			ReturnToPartProperties();
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			if (base.Designer.Tools.SelectedTool == base.Designer.Tools.FuselageTool)
			{
				base.Designer.Tools.SelectMovePartTool();
			}
		}

		private void OnNextClicked(Widget widget)
		{
			FuselageTool.ChangeSelection(moveSelectionForward: true);
		}

		private void OnPrevClicked(Widget widget)
		{
			FuselageTool.ChangeSelection(moveSelectionForward: false);
		}

		private void OnSelectedPartChangedEvent(PartScript newPart)
		{
			if (base.Flyout.IsOpen)
			{
				if (newPart == null)
				{
					base.DesignerUI.Flyouts.Selected = null;
				}
				else if (newPart.GetModifier<FuselageScript>() == null)
				{
					ReturnToPartProperties();
				}
			}
		}

		private void ReturnToPartProperties()
		{
			if (base.DesignerUI.Flyouts.Selected == base.Flyout || base.DesignerUI.Flyouts.Selected == null)
			{
				base.Designer.Tools.SelectMovePartTool();
				base.DesignerUI.Flyouts.Selected = base.DesignerUI.Flyouts.PartProperties;
			}
		}

		private IEnumerator SelectFuselage(FuselageScript fuselage)
		{
			yield return null;
			yield return null;
			FuselageTool.SelectFuselage(fuselage.PartScript.Part);
		}

		private void UpdateFillSliders()
		{
			if (FuselageTool?.CurrentSelection != null)
			{
				FuselageData.FillParameters fillAmount = FuselageTool.CurrentSelection.FillAmount;
				_fillVertical.Slider.Value = fillAmount.Top;
				_fillTop.Slider.Value = fillAmount.Top;
				_fillBottom.Slider.Value = fillAmount.Bottom;
				_fillLeft.Slider.Value = fillAmount.Left;
				_fillRight.Slider.Value = fillAmount.Right;
			}
		}
	}
}
