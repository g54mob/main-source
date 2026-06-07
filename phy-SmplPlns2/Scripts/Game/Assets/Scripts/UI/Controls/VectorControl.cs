using System;
using System.Linq;
using System.Reflection;
using Jundroo.Juicy.Widgets;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.UI.Controls
{
	public class VectorControl<TVector> : WidgetControl
	{
		protected struct Decimal4
		{
			public decimal w;

			public decimal x;

			public decimal y;

			public decimal z;

			public decimal this[int index]
			{
				get
				{
					return index switch
					{
						0 => x, 
						1 => y, 
						2 => z, 
						3 => w, 
						_ => throw new IndexOutOfRangeException("Invalid Decimal4 index!"), 
					};
				}
				set
				{
					switch (index)
					{
					case 0:
						x = value;
						break;
					case 1:
						y = value;
						break;
					case 2:
						z = value;
						break;
					case 3:
						w = value;
						break;
					default:
						throw new IndexOutOfRangeException("Invalid Decimal4 index!");
					}
				}
			}

			public Decimal4(decimal x, decimal y, decimal z, decimal w)
			{
				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
			}

			public Decimal4(double x, double y, double z, double w)
			{
				this.x = (decimal)x;
				this.y = (decimal)y;
				this.z = (decimal)z;
				this.w = (decimal)w;
			}

			public Decimal4(float x, float y, float z, float w)
			{
				this.x = (decimal)x;
				this.y = (decimal)y;
				this.z = (decimal)z;
				this.w = (decimal)w;
			}

			public Decimal4(int x, int y, int z, int w)
			{
				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
			}
		}

		private static class DecimalConstants
		{
			public const double MaxValueDouble = 7.922816251426433E+28;

			public const float MaxValueFloat = 7.922816E+28f;

			public const double MinValueDouble = -7.922816251426433E+28;

			public const float MinValueFloat = -7.922816E+28f;
		}

		private class ButtonDownRepeaterHelper
		{
			private enum ButtonState
			{
				NoButtonDown = 0,
				DecreaseButtonDown = 1,
				IncreaseButtonDown = 2
			}

			private float _buttonDownTimer;

			private ButtonState _buttonState;

			private int _componentIndex;

			public VectorControl<TVector> VectorControl { get; }

			public ButtonDownRepeaterHelper(VectorControl<TVector> vectorControl)
			{
				VectorControl = vectorControl;
				_componentIndex = -1;
				_buttonState = ButtonState.NoButtonDown;
				_buttonDownTimer = vectorControl.ButtonDownRepeatDelay;
			}

			public void OnButtonDisabled(int componentIndex)
			{
				if (_componentIndex == componentIndex)
				{
					_componentIndex = -1;
					_buttonState = ButtonState.NoButtonDown;
					_buttonDownTimer = VectorControl.ButtonDownRepeatDelay;
				}
			}

			public void OnStateChanged(int componentIndex, bool increaseButton, bool buttonDown)
			{
				_buttonDownTimer = VectorControl.ButtonDownRepeatDelay;
				if (buttonDown)
				{
					_componentIndex = componentIndex;
					_buttonState = ((!increaseButton) ? ButtonState.DecreaseButtonDown : ButtonState.IncreaseButtonDown);
				}
				else
				{
					_componentIndex = -1;
					_buttonState = ButtonState.NoButtonDown;
				}
			}

			public void Update(float time)
			{
				if (_buttonState == ButtonState.NoButtonDown)
				{
					_componentIndex = -1;
					_buttonDownTimer = VectorControl.ButtonDownRepeatDelay;
					return;
				}
				_buttonDownTimer -= time;
				if (_buttonDownTimer < 0f)
				{
					_buttonDownTimer = VectorControl.ButtonDownRepeatTime;
					if (_buttonState == ButtonState.DecreaseButtonDown)
					{
						VectorControl.OnDecreaseClick(_componentIndex);
					}
					else if (_buttonState == ButtonState.IncreaseButtonDown)
					{
						VectorControl.OnIncreaseClick(_componentIndex);
					}
				}
			}
		}

		private class VectorType<TVectorType, TComponentType> : VectorType
		{
			private Func<TVectorType, Decimal4> _convertFrom;

			private Func<Decimal4, TVectorType> _convertTo;

			public VectorType(int componentCount, Func<Decimal4, TVectorType> convertTo, Func<TVectorType, Decimal4> convertFrom)
				: base(typeof(TVectorType), typeof(TComponentType), componentCount)
			{
				_convertTo = convertTo;
				_convertFrom = convertFrom;
			}

			public override Decimal4 ConvertFromTargetType(object v)
			{
				return _convertFrom((TVectorType)v);
			}

			public override object ConvertToTargetType(Decimal4 v)
			{
				return _convertTo(v);
			}
		}

		private abstract class VectorType
		{
			public int ComponentCount { get; }

			public Type ComponentType { get; }

			public decimal MaxValue { get; }

			public decimal MinValue { get; }

			public Type TargetType { get; }

			protected Func<object, int, object> GetComponent { get; }

			protected PropertyInfo IndexProperty { get; }

			protected VectorType(Type targetType, Type componentType, int componentCount)
			{
				TargetType = targetType;
				ComponentType = componentType;
				ComponentCount = componentCount;
				object obj = Activator.CreateInstance(componentType);
				(decimal, decimal) tuple;
				if (!(obj is float))
				{
					if (!(obj is int))
					{
						if (!(obj is double))
						{
							throw new NotSupportedException("Vector type '" + targetType.FullName + "' is not currently supported");
						}
						tuple = (-79228162514264300000000000000m, 79228162514264300000000000000m);
					}
					else
					{
						tuple = (-2147483648m, 2147483647m);
					}
				}
				else
				{
					tuple = (-79228160000000000000000000000m, 79228160000000000000000000000m);
				}
				(decimal, decimal) tuple2 = tuple;
				MinValue = tuple2.Item1;
				MaxValue = tuple2.Item2;
				IndexProperty = TargetType.GetProperties(BindingFlags.Instance | BindingFlags.Public).First(delegate(PropertyInfo x)
				{
					ParameterInfo[] indexParameters = x.GetIndexParameters();
					return indexParameters != null && indexParameters.Length == 1;
				});
				MethodInfo indexPropertyGet = IndexProperty.GetGetMethod();
				GetComponent = (object instance, int index) => indexPropertyGet.Invoke(instance, new object[1] { index });
			}

			public static VectorType Create(Type targetType)
			{
				object obj = Activator.CreateInstance(targetType);
				if (!(obj is Vector2))
				{
					if (!(obj is Vector3))
					{
						if (!(obj is Vector4))
						{
							if (!(obj is Vector2i))
							{
								if (!(obj is Vector3i))
								{
									if (!(obj is Vector4i))
									{
										if (!(obj is Vector2d))
										{
											if (!(obj is Vector3d))
											{
												if (!(obj is Vector4d))
												{
													if (!(obj is float2))
													{
														if (!(obj is float3))
														{
															if (!(obj is float4))
															{
																if (!(obj is int2))
																{
																	if (!(obj is int3))
																	{
																		if (!(obj is int4))
																		{
																			if (!(obj is double2))
																			{
																				if (!(obj is double3))
																				{
																					if (obj is double4)
																					{
																						return new VectorType<double4, double>(4, (Decimal4 v) => new double4((double)v.x, (double)v.y, (double)v.z, (double)v.w), (double4 v) => new Decimal4(v.x, v.y, v.z, v.w));
																					}
																					throw new NotSupportedException("Vector type '" + targetType.FullName + "' is not currently supported");
																				}
																				return new VectorType<double3, double>(3, (Decimal4 v) => new double3((double)v.x, (double)v.y, (double)v.z), (double3 v) => new Decimal4(v.x, v.y, v.z, 0.0));
																			}
																			return new VectorType<double2, double>(2, (Decimal4 v) => new double2((double)v.x, (double)v.y), (double2 v) => new Decimal4(v.x, v.y, 0.0, 0.0));
																		}
																		return new VectorType<int4, int>(4, (Decimal4 v) => new int4((int)v.x, (int)v.y, (int)v.z, (int)v.w), (int4 v) => new Decimal4(v.x, v.y, v.z, v.w));
																	}
																	return new VectorType<int3, int>(3, (Decimal4 v) => new int3((int)v.x, (int)v.y, (int)v.z), (int3 v) => new Decimal4(v.x, v.y, v.z, 0));
																}
																return new VectorType<int2, int>(2, (Decimal4 v) => new int2((int)v.x, (int)v.y), (int2 v) => new Decimal4(v.x, v.y, 0, 0));
															}
															return new VectorType<float4, float>(4, (Decimal4 v) => new float4((float)v.x, (float)v.y, (float)v.z, (float)v.w), (float4 v) => new Decimal4(v.x, v.y, v.z, v.w));
														}
														return new VectorType<float3, float>(3, (Decimal4 v) => new float3((float)v.x, (float)v.y, (float)v.z), (float3 v) => new Decimal4(v.x, v.y, v.z, 0f));
													}
													return new VectorType<float2, float>(2, (Decimal4 v) => new float2((float)v.x, (float)v.y), (float2 v) => new Decimal4(v.x, v.y, 0f, 0f));
												}
												return new VectorType<Vector4d, double>(4, (Decimal4 v) => new Vector4d((double)v.x, (double)v.y, (double)v.z, (double)v.w), (Vector4d v) => new Decimal4(v.x, v.y, v.z, v.w));
											}
											return new VectorType<Vector3d, double>(3, (Decimal4 v) => new Vector3d((double)v.x, (double)v.y, (double)v.z), (Vector3d v) => new Decimal4(v.x, v.y, v.z, 0.0));
										}
										return new VectorType<Vector2d, double>(2, (Decimal4 v) => new Vector2d((double)v.x, (double)v.y), (Vector2d v) => new Decimal4(v.x, v.y, 0.0, 0.0));
									}
									return new VectorType<Vector4i, int>(4, (Decimal4 v) => new Vector4i((int)v.x, (int)v.y, (int)v.z, (int)v.w), (Vector4i v) => new Decimal4(v.x, v.y, v.z, v.w));
								}
								return new VectorType<Vector3i, int>(3, (Decimal4 v) => new Vector3i((int)v.x, (int)v.y, (int)v.z), (Vector3i v) => new Decimal4(v.x, v.y, v.z, 0));
							}
							return new VectorType<Vector2i, int>(2, (Decimal4 v) => new Vector2i((int)v.x, (int)v.y), (Vector2i v) => new Decimal4(v.x, v.y, 0, 0));
						}
						return new VectorType<Vector4, float>(4, (Decimal4 v) => new Vector4((float)v.x, (float)v.y, (float)v.z, (float)v.w), (Vector4 v) => new Decimal4(v.x, v.y, v.z, v.w));
					}
					return new VectorType<Vector3, float>(3, (Decimal4 v) => new Vector3((float)v.x, (float)v.y, (float)v.z), (Vector3 v) => new Decimal4(v.x, v.y, v.z, 0f));
				}
				return new VectorType<Vector2, float>(2, (Decimal4 v) => new Vector2((float)v.x, (float)v.y), (Vector2 v) => new Decimal4(v.x, v.y, 0f, 0f));
			}

			public abstract Decimal4 ConvertFromTargetType(object v);

			public abstract object ConvertToTargetType(Decimal4 v);

			public string ToString(object v)
			{
				return ComponentCount switch
				{
					2 => $"{GetComponent(v, 0)},{GetComponent(v, 1)}", 
					3 => $"{GetComponent(v, 0)},{GetComponent(v, 1)},{GetComponent(v, 2)}", 
					4 => $"{GetComponent(v, 0)},{GetComponent(v, 1)},{GetComponent(v, 2)},{GetComponent(v, 3)}", 
					_ => throw new NotSupportedException($"Component count of {ComponentCount} not currently supported by this method."), 
				};
			}
		}

		private bool _allowManualEntry = true;

		private ButtonDownRepeaterHelper _buttonDownRepeater;

		private ButtonWidget[] _decreaseButtons;

		private TextWidget _headerLabel;

		private ButtonWidget[] _increaseButtons;

		private InputWidget[] _inputFields;

		private decimal _maxValue;

		private decimal _minValue;

		private Decimal4 _value;

		private Widget[] _vectorComponentWidgets;

		private VectorType _vectorType;

		public bool AllowManualEntry
		{
			get
			{
				return _allowManualEntry;
			}
			set
			{
				if (_allowManualEntry != value)
				{
					_allowManualEntry = value;
					OnAllowManualEntryChanged();
				}
			}
		}

		public float ButtonDownRepeatDelay { get; set; } = 0.3f;

		public float ButtonDownRepeatTime { get; set; } = 0.1f;

		public Func<decimal> GetStepValue { get; set; }

		public string Label
		{
			get
			{
				return _headerLabel.Text;
			}
			set
			{
				_headerLabel.Text = value;
			}
		}

		public bool ManualEntryIgnoresRange { get; set; }

		public decimal MaxValue
		{
			get
			{
				return _maxValue;
			}
			set
			{
				_maxValue = Math.Min(value, _vectorType.MaxValue);
			}
		}

		public decimal MinValue
		{
			get
			{
				return _minValue;
			}
			set
			{
				_minValue = Math.Max(value, _vectorType.MinValue);
			}
		}

		public Action<TVector> OnValueChanged { get; set; }

		public Action<TVector> OnValueChanging { get; set; }

		public decimal StepValue { get; set; } = 1m;

		public TVector Value
		{
			get
			{
				return (TVector)_vectorType.ConvertToTargetType(_value);
			}
			set
			{
				_value = _vectorType.ConvertFromTargetType(value);
				for (int i = 0; i < _vectorType.ComponentCount; i++)
				{
					_value[i] = ClampValue(_value[i], isManualEntry: true);
					UpdateInputFieldText(i, _value[i], useFormattedValue: true);
					UpdateButtonStates(i, _value[i]);
				}
			}
		}

		public Func<object, string> ValueFormatter { get; set; } = (object value) => value.ToString();

		public VectorControl(Widget widget)
			: base(widget)
		{
			_vectorType = VectorType.Create(typeof(TVector));
			MinValue = _vectorType.MinValue;
			MaxValue = _vectorType.MaxValue;
			GetStepValue = () => StepValue;
			_buttonDownRepeater = new ButtonDownRepeaterHelper(this);
			widget.gameObject.AddComponent<UpdateScript>().MonoBehaviourUpdate += OnUpdate;
			_headerLabel = widget.FindWidget<TextWidget>("vector-label-text");
			_vectorComponentWidgets = new Widget[4];
			_inputFields = new InputWidget[4];
			_increaseButtons = new ButtonWidget[4];
			_decreaseButtons = new ButtonWidget[4];
			for (int num = 0; num < 4; num++)
			{
				int index = num;
				_vectorComponentWidgets[num] = widget.FindWidget<Widget>($"spinner-input-{num}");
				_inputFields[num] = _vectorComponentWidgets[num].FindWidget<InputWidget>("value-input");
				_inputFields[num].Input.placeholder?.gameObject.SetActive(value: false);
				_increaseButtons[num] = _vectorComponentWidgets[num].FindWidget<ButtonWidget>("next-button");
				_increaseButtons[num].Clicked += delegate
				{
					OnIncreaseClick(index);
				};
				_increaseButtons[num].PointerDown += delegate
				{
					_buttonDownRepeater.OnStateChanged(index, increaseButton: true, buttonDown: true);
				};
				_increaseButtons[num].PointerUp += delegate
				{
					_buttonDownRepeater.OnStateChanged(index, increaseButton: true, buttonDown: false);
				};
				_decreaseButtons[num] = _vectorComponentWidgets[num].FindWidget<ButtonWidget>("prev-button");
				_decreaseButtons[num].Clicked += delegate
				{
					OnDecreaseClick(index);
				};
				_decreaseButtons[num].PointerDown += delegate
				{
					_buttonDownRepeater.OnStateChanged(index, increaseButton: false, buttonDown: true);
				};
				_decreaseButtons[num].PointerUp += delegate
				{
					_buttonDownRepeater.OnStateChanged(index, increaseButton: false, buttonDown: false);
				};
				_vectorComponentWidgets[num].Visible = num < _vectorType.ComponentCount;
			}
			OnAllowManualEntryChanged();
		}

		public void Configure(float stepValue, float minValue = -7.922816E+28f, float maxValue = 7.922816E+28f, bool allowManualEntry = true, bool manualEntryIgnoresRange = false)
		{
			Configure((decimal)stepValue, (decimal)minValue, (decimal)maxValue, allowManualEntry, manualEntryIgnoresRange);
		}

		public void Configure(double stepValue, double minValue = -7.922816251426433E+28, double maxValue = 7.922816251426433E+28, bool allowManualEntry = true, bool manualEntryIgnoresRange = false)
		{
			Configure((decimal)stepValue, (decimal)minValue, (decimal)maxValue, allowManualEntry, manualEntryIgnoresRange);
		}

		public void Configure(decimal stepValue, decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue, bool allowManualEntry = true, bool manualEntryIgnoresRange = false)
		{
			StepValue = stepValue;
			MinValue = minValue;
			MaxValue = maxValue;
			AllowManualEntry = allowManualEntry;
			ManualEntryIgnoresRange = manualEntryIgnoresRange;
		}

		public string GetValueAsNumericString(TVector value)
		{
			return _vectorType.ToString(value);
		}

		public void OnUpdate()
		{
			_buttonDownRepeater.Update(Time.unscaledDeltaTime);
		}

		public void SetComponentVisibility(int componentIndex, bool visible)
		{
			if (componentIndex < 0 || componentIndex >= _vectorType.ComponentCount)
			{
				throw new IndexOutOfRangeException(string.Format("{0} '{1}' is out of range. (0 -> {2})", "componentIndex", componentIndex, _vectorType.ComponentCount));
			}
			_vectorComponentWidgets[componentIndex].Visible = visible;
		}

		private decimal ClampValue(decimal componentValue, bool isManualEntry)
		{
			if (!(ManualEntryIgnoresRange && isManualEntry))
			{
				if (componentValue < _minValue)
				{
					return _minValue;
				}
				if (componentValue > _maxValue)
				{
					return _maxValue;
				}
			}
			return componentValue;
		}

		private void OnAllowManualEntryChanged()
		{
			for (int i = 0; i < 4; i++)
			{
				int index = i;
				if (AllowManualEntry)
				{
					_inputFields[i].RemoveClass("disabled");
					_inputFields[i].Input.onSelect.AddListener(delegate
					{
						OnInputFieldSelected(index);
					});
					_inputFields[i].Input.onValueChanged.AddListener(delegate
					{
						OnInputFieldValueChanged(index);
					});
					_inputFields[i].Input.onEndEdit.AddListener(delegate
					{
						OnInputFieldEndEdit(index);
					});
				}
				else
				{
					_inputFields[i].AddClass("disabled");
					_inputFields[i].Input.onSelect.RemoveListener(delegate
					{
						OnInputFieldSelected(index);
					});
					_inputFields[i].Input.onValueChanged.RemoveListener(delegate
					{
						OnInputFieldValueChanged(index);
					});
					_inputFields[i].Input.onEndEdit.RemoveListener(delegate
					{
						OnInputFieldEndEdit(index);
					});
				}
			}
		}

		private void OnDecreaseClick(int componentIndex)
		{
			OnStepValue(componentIndex, -1);
		}

		private void OnIncreaseClick(int componentIndex)
		{
			OnStepValue(componentIndex, 1);
		}

		private void OnInputFieldEndEdit(int componentIndex)
		{
			UpdateInputFieldText(componentIndex, _value[componentIndex], useFormattedValue: true);
		}

		private void OnInputFieldSelected(int componentIndex)
		{
			UpdateInputFieldText(componentIndex, _value[componentIndex], useFormattedValue: false);
		}

		private void OnInputFieldValueChanged(int componentIndex)
		{
			if (decimal.TryParse(_inputFields[componentIndex].Text, out var result))
			{
				result = ClampValue(result, isManualEntry: true);
				if (!(_value[componentIndex] == result))
				{
					UpdateComponentValue(componentIndex, result, updateText: false);
				}
			}
		}

		private void OnStepValue(int componentIndex, int steps)
		{
			decimal componentValue = _value[componentIndex];
			componentValue += (GetStepValue?.Invoke() ?? StepValue) * (decimal)steps;
			componentValue = ClampValue(componentValue, isManualEntry: false);
			if (!(_value[componentIndex] == componentValue))
			{
				UpdateComponentValue(componentIndex, componentValue, updateText: true);
			}
		}

		private void SetButtonEnabled(ButtonWidget widget, int componentIndex, bool enabled)
		{
			if (enabled)
			{
				widget.RemoveClass("disabled");
			}
			else if (widget.AddClass("disabled"))
			{
				_buttonDownRepeater.OnButtonDisabled(componentIndex);
			}
		}

		private void SetInputTextWithoutNotify(int componentIndex, string text)
		{
			_inputFields[componentIndex].Input.SetTextWithoutNotify(text);
		}

		private void UpdateButtonStates(int componentIndex, decimal componentValue)
		{
			SetButtonEnabled(_decreaseButtons[componentIndex], componentIndex, componentValue > _minValue);
			SetButtonEnabled(_increaseButtons[componentIndex], componentIndex, componentValue < _maxValue);
		}

		private void UpdateComponentValue(int componentIndex, decimal componentValue, bool updateText)
		{
			Decimal4 value = _value;
			value[componentIndex] = componentValue;
			TVector obj = (TVector)_vectorType.ConvertToTargetType(value);
			OnValueChanging?.Invoke(obj);
			_value = value;
			OnValueChanged?.Invoke(obj);
			UpdateButtonStates(componentIndex, componentValue);
			if (updateText)
			{
				UpdateInputFieldText(componentIndex, componentValue, useFormattedValue: true);
			}
		}

		private void UpdateInputFieldText(int componentIndex, decimal componentValue, bool useFormattedValue)
		{
			object obj = Convert.ChangeType(componentValue, _vectorType.ComponentType);
			string text = (useFormattedValue ? ValueFormatter(obj) : obj.ToString());
			SetInputTextWithoutNotify(componentIndex, text);
		}
	}
}
