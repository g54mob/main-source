using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tools.Fuselage;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class FuselageShapePanelScript : DesignerSubPanelScript
	{
		private const int MaxSliderValue = 20;

		private XmlElement _addSectionRow;

		private float[] _clampAmounts;

		private float[] _cornerRadiuses;

		private XmlElement _curveOverrideRow;

		private XmlElement _fuselagePanel;

		private XmlElement _jointPanel;

		private TextMeshProUGUI _messageText;

		private List<Slider> _sliders = new List<Slider>();

		private bool _sliderUpdating;

		private SpinnerScript _spinnerDepth;

		private SpinnerScript _spinnerGridSize;

		private SpinnerScript _spinnerOffsetX;

		private SpinnerScript _spinnerOffsetY;

		private SpinnerScript _spinnerOffsetZ;

		private SpinnerScript _spinnerWidth;

		private FuselageShapeTool _tool;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			_tool = base.DesignerUi.Designer.FuselageShapeTool;
			FuselageShapeTool tool = _tool;
			tool.OnJointUpdated = (Action<FuselageJoint>)Delegate.Combine(tool.OnJointUpdated, new Action<FuselageJoint>(OnJointUpdated));
			FuselageShapeTool tool2 = _tool;
			tool2.OnJointSelected = (Action<FuselageJoint>)Delegate.Combine(tool2.OnJointSelected, new Action<FuselageJoint>(OnJointSelected));
			FuselageShapeTool tool3 = _tool;
			tool3.OnFuselageSelected = (Action<FuselageScript>)Delegate.Combine(tool3.OnFuselageSelected, new Action<FuselageScript>(OnFuselageSelected));
			_spinnerGridSize.SetNumericValue(_tool.GridSize);
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_fuselagePanel = base.xmlLayout.GetElementById("fuselage-panel");
			_jointPanel = base.xmlLayout.GetElementById("joint-panel");
			_messageText = base.xmlLayout.GetElementById<TextMeshProUGUI>("message-text");
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("corner-radius-all"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("corner-radius-1"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("corner-radius-2"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("corner-radius-3"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("corner-radius-4"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("pinch"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("slant"));
			_sliders[5].transform.parent.gameObject.SetActive(value: false);
			_sliders[6].transform.parent.gameObject.SetActive(value: false);
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("clamp-1"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("clamp-2"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("clamp-3"));
			_sliders.Add(base.xmlLayout.GetElementById<Slider>("clamp-4"));
			for (int i = 0; i < _sliders.Count; i++)
			{
				int sliderIndex = i;
				_sliders[i].onValueChanged.AddListener(delegate(float x)
				{
					OnSliderChanged(sliderIndex - 1, x);
				});
				_sliders[i].maxValue = 20f;
			}
			_spinnerDepth = base.xmlLayout.GetElementById<SpinnerScript>("spinner-depth");
			_spinnerWidth = base.xmlLayout.GetElementById<SpinnerScript>("spinner-width");
			_spinnerOffsetX = base.xmlLayout.GetElementById<SpinnerScript>("spinner-offset-x");
			_spinnerOffsetY = base.xmlLayout.GetElementById<SpinnerScript>("spinner-offset-y");
			_spinnerOffsetZ = base.xmlLayout.GetElementById<SpinnerScript>("spinner-offset-z");
			_spinnerGridSize = base.xmlLayout.GetElementById<SpinnerScript>("spinner-grid-size");
			_addSectionRow = base.xmlLayout.GetElementById("add-section-row");
			_curveOverrideRow = base.xmlLayout.GetElementById("curve-override");
		}

		public void OnFuselageOffsetChanged()
		{
			Vector3 offset = new Vector3(_spinnerOffsetX.NumericValue / 2f, _spinnerOffsetY.NumericValue / 2f, _spinnerOffsetZ.NumericValue / 2f);
			_tool.UpdateFuselageOffset(offset);
			RefreshUi();
		}

		public override void OnOpened()
		{
			SetupScaleSpinner(_spinnerWidth);
			SetupScaleSpinner(_spinnerDepth);
			float num = 2.4f;
			SetupOffsetSpinner(_spinnerOffsetX, 0f - num, num);
			SetupOffsetSpinner(_spinnerOffsetY, 0.01f, 50f);
			SetupOffsetSpinner(_spinnerOffsetZ, 0f - num, num);
			OnGridSizeChanged();
			RefreshUi();
		}

		private void OnAddSectionClicked()
		{
			ICollection<AttachPointScript> attachPoints;
			FuselageScript fuselage = _tool.AddSection(out attachPoints);
			StartCoroutine(SelectFuselage(fuselage, attachPoints));
		}

		private void OnBackwardsClicked()
		{
			_tool.ChangeSelection(moveSelectionForward: false);
		}

		private void OnCurveOverrideClicked()
		{
			FuselageData fuselage = _tool.SelectedFuselage.Data;
			Game.Instance.UserInterface.CreateCurveEditor(fuselage.DepthCurve ?? new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)), delegate(AnimationCurve curve)
			{
				fuselage.DepthCurve = curve;
			});
		}

		private void OnDepthChanged(float value)
		{
			SetSize(_tool.SelectedJoint.Scale.x, value / 2f);
		}

		private void OnForwardsClicked()
		{
			_tool.ChangeSelection(moveSelectionForward: true);
		}

		private void OnFuselageSelected(FuselageScript fuselage)
		{
			RefreshUi();
		}

		private void OnGridSizeChanged()
		{
			float num = _tool.GridSize;
			_spinnerGridSize.SetNumericValue(num);
			if (num < 0.01f)
			{
				num = 0.01f;
			}
			_spinnerOffsetX.StepSize = num;
			_spinnerOffsetY.StepSize = num;
			_spinnerOffsetZ.StepSize = num;
			_spinnerDepth.StepSize = num;
			_spinnerWidth.StepSize = num;
		}

		private void OnGridSizeSpinnerChanged()
		{
			_tool.GridSize = _spinnerGridSize.NumericValue;
			OnGridSizeChanged();
		}

		private void OnJointSelected(FuselageJoint joint)
		{
			RefreshUi();
		}

		private void OnJointUpdated(FuselageJoint joint)
		{
			RefreshJointSpinners();
		}

		private void OnSliderChanged(int sliderIndex, float value)
		{
			if (!_sliderUpdating && (_tool.SelectedJoint != null || sliderIndex == 4 || sliderIndex == 5))
			{
				_sliderUpdating = true;
				float num = value / 20f;
				num = (float)(int)(num * 100f) / 100f;
				switch (sliderIndex)
				{
				case 6:
				case 7:
				case 8:
				case 9:
					num = ((sliderIndex % 2 == 0) ? (0f - num) : num);
					_clampAmounts[sliderIndex - 6] = num;
					_tool.SelectedJoint.SetClampAmounts(_clampAmounts);
					break;
				case 5:
					_tool.UpdateFuselageSlant(0.5f * num);
					break;
				case 4:
					_tool.UpdateFuselagePinch(num);
					break;
				case 0:
				case 1:
				case 2:
				case 3:
					_cornerRadiuses[sliderIndex] = num;
					_tool.SelectedJoint.SetCornerRadiuses(_cornerRadiuses);
					break;
				default:
					_cornerRadiuses[0] = num;
					_cornerRadiuses[1] = num;
					_cornerRadiuses[2] = num;
					_cornerRadiuses[3] = num;
					_tool.SelectedJoint.SetCornerRadiuses(_cornerRadiuses);
					RefreshUi();
					break;
				}
				base.DesignerUi.Designer.CraftScript.SetStructureChanged();
				if (sliderIndex != -1)
				{
					UpdateSliderText(_sliders[sliderIndex + 1], num);
				}
				_sliderUpdating = false;
			}
		}

		private void OnWidthChanged(float value)
		{
			SetSize(value / 2f, _tool.SelectedJoint.Scale.y);
		}

		private void RefreshJointSpinners()
		{
			if (_tool.SelectedJoint != null)
			{
				_spinnerWidth.SetNumericValue(_tool.SelectedJoint.Scale.x * 2f);
				_spinnerDepth.SetNumericValue(_tool.SelectedJoint.Scale.y * 2f);
			}
		}

		private void RefreshUi()
		{
			if (_tool.SelectedJoint != null)
			{
				_jointPanel.gameObject.SetActive(value: true);
				_fuselagePanel.gameObject.SetActive(value: false);
				_messageText.gameObject.SetActive(value: false);
				_cornerRadiuses = _tool.SelectedJoint.GetCornerRadiuses();
				_clampAmounts = _tool.SelectedJoint.GetClampAmounts();
				try
				{
					_sliderUpdating = true;
					float num = 0f;
					for (int i = 0; i < 4; i++)
					{
						num += _cornerRadiuses[i];
						_sliders[i + 1].value = _cornerRadiuses[i] * 20f;
						UpdateSliderText(_sliders[i + 1], _cornerRadiuses[i]);
					}
					if (_tool.SelectedJoint.Fuselages[0].Fuselage.Data.Version >= 3 && Game.Instance.GameState.Validator.IsItemAvailable("Fuselage.Clamp"))
					{
						for (int j = 0; j < 4; j++)
						{
							_sliders[j + 7].transform.parent.gameObject.SetActive(value: true);
							_sliders[j + 7].value = _clampAmounts[j] * (float)((j % 2 == 0) ? (-20) : 20);
							UpdateSliderText(_sliders[j + 7], _clampAmounts[j]);
						}
					}
					else
					{
						for (int k = 0; k < 4; k++)
						{
							_sliders[k + 7].transform.parent.gameObject.SetActive(value: false);
						}
					}
					_sliders[0].value = num * 0.25f * 20f;
					UpdateSliderText(_sliders[0], num * 0.25f);
				}
				finally
				{
					_sliderUpdating = false;
				}
				RefreshJointSpinners();
				_addSectionRow.SetActive(_tool.CanAddSection);
			}
			else if (_tool.SelectedFuselage != null)
			{
				FuselageScript selectedFuselage = _tool.SelectedFuselage;
				_jointPanel.gameObject.SetActive(value: false);
				_fuselagePanel.gameObject.SetActive(value: true);
				_messageText.gameObject.SetActive(value: false);
				_curveOverrideRow.SetActive(selectedFuselage.Data.DepthCurved && selectedFuselage.Data.Version >= 3 && Game.Instance.GameState.Validator.IsItemAvailable("Fuselage.Curve"));
				_spinnerOffsetY.SetNumericValue(selectedFuselage.Data.Offset.y * 2f);
				if (!selectedFuselage.Data.SupportsXZOffset)
				{
					_spinnerOffsetX.transform.parent.gameObject.SetActive(value: false);
					_spinnerOffsetZ.transform.parent.gameObject.SetActive(value: false);
					_sliders[5].transform.parent.gameObject.SetActive(value: false);
					_sliders[6].transform.parent.gameObject.SetActive(value: false);
					return;
				}
				_spinnerOffsetX.transform.parent.gameObject.SetActive(value: true);
				_spinnerOffsetX.SetNumericValue(selectedFuselage.Data.Offset.x * 2f);
				_spinnerOffsetZ.transform.parent.gameObject.SetActive(value: true);
				_spinnerOffsetZ.SetNumericValue(selectedFuselage.Data.Offset.z * 2f);
				if (Game.Instance.GameState.Validator.IsItemAvailable("Fuselage.Pinch"))
				{
					float num2 = 0.5f * (selectedFuselage.Data.Deformations.x + selectedFuselage.Data.Deformations.z);
					_sliders[5].value = num2 * 20f;
					_sliders[5].transform.parent.gameObject.SetActive(value: true);
					UpdateSliderText(_sliders[4], num2);
				}
				if (Game.Instance.GameState.Validator.IsItemAvailable("Fuselage.Slant"))
				{
					_sliders[6].value = 2f * selectedFuselage.Data.Deformations.y * 20f;
					_sliders[6].transform.parent.gameObject.SetActive(value: true);
					UpdateSliderText(_sliders[6], 2f * selectedFuselage.Data.Deformations.y);
				}
			}
			else
			{
				_jointPanel.gameObject.SetActive(value: false);
				_fuselagePanel.gameObject.SetActive(value: false);
				_messageText.gameObject.SetActive(value: true);
				_messageText.text = "No shapable part selected";
			}
		}

		private IEnumerator SelectFuselage(FuselageScript fuselage, ICollection<AttachPointScript> attachPoints)
		{
			yield return null;
			yield return null;
			MovePartToolHelper.DetectAttachPointConnectionsAndConnect(attachPoints);
			_tool.SelectFuselage(fuselage);
			base.DesignerUi.Designer.CraftScript.SetStructureChanged();
		}

		private void SetSize(float x, float y)
		{
			_tool.SetJointSize(new Vector2(x, y));
			RefreshJointSpinners();
			base.DesignerUi.Designer.CraftScript.SetStructureChanged();
		}

		private void SetupOffsetSpinner(SpinnerScript spinner, float minValue, float maxValue)
		{
			spinner.MinValue = minValue;
			spinner.MaxValue = maxValue;
		}

		private void SetupScaleSpinner(SpinnerScript spinner)
		{
			spinner.MinValue = 0f;
			spinner.MaxValue = base.DesignerUi.Designer.MaxRadius * 2f;
		}

		private void UpdateSliderText(Slider slider, float percentage)
		{
			slider.transform.parent.Find("slider-value").GetComponent<TextMeshProUGUI>().text = Utilities.FormatPercentage(percentage);
		}
	}
}
