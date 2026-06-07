using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputBehavior
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _joystickAxisSensitivity = 1f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisSimulation = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisSnap;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _digitalAxisInstantReverse;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _digitalAxisGravity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _digitalAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseXYAxisMode _mouseXYAxisMode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private MouseOtherAxisMode _mouseOtherAxisMode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _mouseXYAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseXYAxisDeltaCalc _mouseXYAxisDeltaCalc;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _mouseOtherAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _customControllerAxisSensitivity = 1f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDoublePressSpeed;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonShortPressTime = 0.25f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressExpiresIn;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonLongPressTime = 1f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonLongPressExpiresIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDeadZone;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDownBuffer;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonRepeatRate = 30f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonRepeatDelay;

		public int id
		{
			get
			{
				return _id;
			}
			internal set
			{
				_id = value;
			}
		}

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public float joystickAxisSensitivity
		{
			get
			{
				return _joystickAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				_joystickAxisSensitivity = value;
			}
		}

		public bool digitalAxisSimulation
		{
			get
			{
				return _digitalAxisSimulation;
			}
			set
			{
				_digitalAxisSimulation = value;
			}
		}

		public bool digitalAxisSnap
		{
			get
			{
				return _digitalAxisSnap;
			}
			set
			{
				_digitalAxisSnap = value;
			}
		}

		public bool digitalAxisInstantReverse
		{
			get
			{
				return _digitalAxisInstantReverse;
			}
			set
			{
				_digitalAxisInstantReverse = value;
			}
		}

		public float digitalAxisGravity
		{
			get
			{
				return _digitalAxisGravity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				_digitalAxisGravity = value;
			}
		}

		public float digitalAxisSensitivity
		{
			get
			{
				return _digitalAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				_digitalAxisSensitivity = value;
			}
		}

		public MouseXYAxisMode mouseXYAxisMode
		{
			get
			{
				return _mouseXYAxisMode;
			}
			set
			{
				_mouseXYAxisMode = value;
			}
		}

		public MouseOtherAxisMode mouseOtherAxisMode
		{
			get
			{
				return _mouseOtherAxisMode;
			}
			set
			{
				_mouseOtherAxisMode = value;
			}
		}

		public float mouseXYAxisSensitivity
		{
			get
			{
				return _mouseXYAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				_mouseXYAxisSensitivity = value;
			}
		}

		public MouseXYAxisDeltaCalc mouseXYAxisDeltaCalc
		{
			get
			{
				return _mouseXYAxisDeltaCalc;
			}
			set
			{
				_mouseXYAxisDeltaCalc = value;
			}
		}

		public float mouseOtherAxisSensitivity
		{
			get
			{
				return _mouseOtherAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				_mouseOtherAxisSensitivity = value;
			}
		}

		public float customControllerAxisSensitivity
		{
			get
			{
				return _customControllerAxisSensitivity;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				_customControllerAxisSensitivity = value;
			}
		}

		public float buttonDoublePressSpeed
		{
			get
			{
				return _buttonDoublePressSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				_buttonDoublePressSpeed = value;
			}
		}

		public float buttonShortPressTime
		{
			get
			{
				return _buttonShortPressTime;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				_buttonShortPressTime = value;
			}
		}

		public float buttonShortPressExpiresIn
		{
			get
			{
				return _buttonShortPressExpiresIn;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				_buttonShortPressExpiresIn = value;
			}
		}

		public float buttonLongPressTime
		{
			get
			{
				return _buttonLongPressTime;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				_buttonLongPressTime = value;
			}
		}

		public float buttonLongPressExpiresIn
		{
			get
			{
				return _buttonLongPressExpiresIn;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.MaxValue);
				_buttonLongPressExpiresIn = value;
			}
		}

		public float buttonDeadZone
		{
			get
			{
				return _buttonDeadZone;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 1f);
				_buttonDeadZone = value;
			}
		}

		public float buttonDownBuffer
		{
			get
			{
				return _buttonDownBuffer;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, float.PositiveInfinity);
				_buttonDownBuffer = value;
			}
		}

		public float buttonRepeatRate
		{
			get
			{
				return _buttonRepeatRate;
			}
			set
			{
				value = MathTools.Max(0.001f, value);
				_buttonRepeatRate = value;
			}
		}

		public float buttonRepeatDelay
		{
			get
			{
				return _buttonRepeatDelay;
			}
			set
			{
				value = MathTools.Max(0f, value);
				_buttonRepeatDelay = value;
			}
		}

		public InputBehavior()
		{
		}

		public InputBehavior(InputBehavior source)
			: this()
		{
			qrrMkmbOWNfvYrIioIRAUiWIiGl(source, this, true);
		}

		public string ToXmlString()
		{
			try
			{
				return muekHnlfFKTrtweZHZQKTUPbigj().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing InputBehavior to XML. " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			try
			{
				TCWWrbhTnTgbtRDgCDABRkmhLPq(SerializedObject.FromXml(GetType(), xmlString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error reading InputBehavior from XML. " + ex.Message);
				return false;
			}
		}

		public string ToJsonString()
		{
			try
			{
				return muekHnlfFKTrtweZHZQKTUPbigj().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing InputBehavior to JSON. " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportJsonString(string jsonString)
		{
			try
			{
				TCWWrbhTnTgbtRDgCDABRkmhLPq(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error reading InputBehavior from JSON. " + ex.Message);
				return false;
			}
		}

		public bool ImportData(InputBehavior inputBehavior)
		{
			if (inputBehavior == null)
			{
				return false;
			}
			qrrMkmbOWNfvYrIioIRAUiWIiGl(inputBehavior, this, false);
			return true;
		}

		public InputBehavior Clone()
		{
			return new InputBehavior(this);
		}

		public void Reset()
		{
			InputBehavior inputBehavior = ReInput.mapping.qYFsxrqwiREGrENynyCzXdevhUS(_id);
			if (inputBehavior == null)
			{
				return;
			}
			while (true)
			{
				qrrMkmbOWNfvYrIioIRAUiWIiGl(inputBehavior, this, true);
				int num = 1160759440;
				while (true)
				{
					switch (num ^ 0x452FC891)
					{
					case 0:
						goto IL_0015;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0015:
					num = 1160759443;
				}
			}
		}

		internal SerializedObject muekHnlfFKTrtweZHZQKTUPbigj()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 5, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 5.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "id",
				value = _id.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				prefix = "xmlns",
				localName = "xsi",
				ns = null,
				value = "http://www.w3.org/2001/XMLSchema-instance"
			});
			while (true)
			{
				int num = -696715837;
				while (true)
				{
					switch (num ^ -696715838)
					{
					case 6:
						break;
					case 5:
						serializedObject.Add("buttonLongPressTime", _buttonLongPressTime);
						serializedObject.Add("buttonLongPressExpiresIn", _buttonLongPressExpiresIn);
						serializedObject.Add("buttonDeadZone", _buttonDeadZone);
						serializedObject.Add("buttonDownBuffer", _buttonDownBuffer);
						num = -696715834;
						continue;
					case 3:
						serializedObject.Add("mouseXYAxisMode", _mouseXYAxisMode);
						serializedObject.Add("mouseOtherAxisMode", _mouseOtherAxisMode);
						serializedObject.Add("mouseXYAxisSensitivity", _mouseXYAxisSensitivity);
						num = -696715840;
						continue;
					case 0:
						serializedObject.Add("name", _name);
						serializedObject.Add("joystickAxisSensitivity", _joystickAxisSensitivity);
						serializedObject.Add("digitalAxisSimulation", _digitalAxisSimulation);
						serializedObject.Add("digitalAxisSnap", _digitalAxisSnap);
						serializedObject.Add("digitalAxisInstantReverse", _digitalAxisInstantReverse);
						serializedObject.Add("digitalAxisGravity", _digitalAxisGravity);
						num = -696715835;
						continue;
					case 7:
						serializedObject.Add("digitalAxisSensitivity", _digitalAxisSensitivity);
						num = -696715839;
						continue;
					case 8:
						serializedObject.Add("buttonShortPressTime", _buttonShortPressTime);
						serializedObject.Add("buttonShortPressExpiresIn", _buttonShortPressExpiresIn);
						num = -696715833;
						continue;
					case 1:
						serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
						{
							prefix = "xsi",
							localName = "schemaLocation",
							ns = null,
							value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.4", "/", GetType().Name, ".xsd")
						});
						serializedObject.Add("id", _id);
						num = -696715838;
						continue;
					case 2:
						serializedObject.Add("mouseXYAxisDeltaCalc", _mouseXYAxisDeltaCalc);
						serializedObject.Add("mouseOtherAxisSensitivity", _mouseOtherAxisSensitivity);
						serializedObject.Add("customControllerAxisSensitivity", _customControllerAxisSensitivity);
						serializedObject.Add("buttonDoublePressSpeed", _buttonDoublePressSpeed);
						num = -696715830;
						continue;
					default:
						serializedObject.Add("buttonRepeatRate", _buttonRepeatRate);
						serializedObject.Add("buttonRepeatDelay", _buttonRepeatDelay);
						return serializedObject;
					}
					break;
				}
			}
		}

		internal void TCWWrbhTnTgbtRDgCDABRkmhLPq(SerializedObject P_0)
		{
			Reset();
			P_0.TryGetDeserializedValueByRef("joystickAxisSensitivity", ref _joystickAxisSensitivity);
			while (true)
			{
				int num = -1675133926;
				while (true)
				{
					switch (num ^ -1675133925)
					{
					case 5:
						break;
					case 1:
						P_0.TryGetDeserializedValueByRef("digitalAxisSimulation", ref _digitalAxisSimulation);
						P_0.TryGetDeserializedValueByRef("digitalAxisSnap", ref _digitalAxisSnap);
						P_0.TryGetDeserializedValueByRef("digitalAxisInstantReverse", ref _digitalAxisInstantReverse);
						num = -1675133928;
						continue;
					case 7:
						P_0.TryGetDeserializedValueByRef("buttonLongPressExpiresIn", ref _buttonLongPressExpiresIn);
						num = -1675133923;
						continue;
					case 6:
						P_0.TryGetDeserializedValueByRef("buttonDeadZone", ref _buttonDeadZone);
						P_0.TryGetDeserializedValueByRef("buttonDownBuffer", ref _buttonDownBuffer);
						num = -1675133927;
						continue;
					case 0:
						P_0.TryGetDeserializedValueByRef("buttonDoublePressSpeed", ref _buttonDoublePressSpeed);
						P_0.TryGetDeserializedValueByRef("buttonShortPressTime", ref _buttonShortPressTime);
						P_0.TryGetDeserializedValueByRef("buttonShortPressExpiresIn", ref _buttonShortPressExpiresIn);
						num = -1675133921;
						continue;
					case 3:
						P_0.TryGetDeserializedValueByRef("digitalAxisGravity", ref _digitalAxisGravity);
						P_0.TryGetDeserializedValueByRef("digitalAxisSensitivity", ref _digitalAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("mouseXYAxisMode", ref _mouseXYAxisMode);
						P_0.TryGetDeserializedValueByRef("mouseOtherAxisMode", ref _mouseOtherAxisMode);
						P_0.TryGetDeserializedValueByRef("mouseXYAxisSensitivity", ref _mouseXYAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("mouseXYAxisDeltaCalc", ref _mouseXYAxisDeltaCalc);
						P_0.TryGetDeserializedValueByRef("mouseOtherAxisSensitivity", ref _mouseOtherAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("customControllerAxisSensitivity", ref _customControllerAxisSensitivity);
						num = -1675133925;
						continue;
					case 4:
						P_0.TryGetDeserializedValueByRef("buttonLongPressTime", ref _buttonLongPressTime);
						num = -1675133924;
						continue;
					default:
						P_0.TryGetDeserializedValueByRef("buttonRepeatRate", ref _buttonRepeatRate);
						P_0.TryGetDeserializedValueByRef("buttonRepeatDelay", ref _buttonRepeatDelay);
						return;
					}
					break;
				}
			}
		}

		private static void qrrMkmbOWNfvYrIioIRAUiWIiGl(InputBehavior P_0, InputBehavior P_1, bool P_2)
		{
			if (P_2)
			{
				P_1._id = P_0._id;
				goto IL_0012;
			}
			goto IL_013f;
			IL_013f:
			P_1._name = P_0._name;
			int num = 269348924;
			goto IL_0017;
			IL_0012:
			num = 269348922;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x100DF03E)
				{
				case 0:
					break;
				case 1:
					P_1._mouseXYAxisDeltaCalc = P_0._mouseXYAxisDeltaCalc;
					P_1._customControllerAxisSensitivity = P_0._customControllerAxisSensitivity;
					P_1._buttonDoublePressSpeed = P_0._buttonDoublePressSpeed;
					P_1._buttonShortPressTime = P_0._buttonShortPressTime;
					P_1._buttonShortPressExpiresIn = P_0._buttonShortPressExpiresIn;
					P_1._buttonLongPressTime = P_0._buttonLongPressTime;
					P_1._buttonLongPressExpiresIn = P_0._buttonLongPressExpiresIn;
					P_1._buttonDeadZone = P_0._buttonDeadZone;
					P_1._buttonDownBuffer = P_0._buttonDownBuffer;
					P_1._buttonRepeatRate = P_0._buttonRepeatRate;
					num = 269348925;
					continue;
				case 2:
					P_1._joystickAxisSensitivity = P_0._joystickAxisSensitivity;
					P_1._digitalAxisSimulation = P_0._digitalAxisSimulation;
					P_1._digitalAxisSnap = P_0._digitalAxisSnap;
					P_1._digitalAxisInstantReverse = P_0._digitalAxisInstantReverse;
					P_1._digitalAxisGravity = P_0._digitalAxisGravity;
					P_1._digitalAxisSensitivity = P_0._digitalAxisSensitivity;
					P_1._mouseXYAxisMode = P_0._mouseXYAxisMode;
					P_1._mouseOtherAxisMode = P_0._mouseOtherAxisMode;
					P_1._mouseXYAxisSensitivity = P_0._mouseXYAxisSensitivity;
					P_1._mouseOtherAxisSensitivity = P_0._mouseOtherAxisSensitivity;
					num = 269348927;
					continue;
				case 4:
					goto IL_013f;
				default:
					P_1._buttonRepeatDelay = P_0._buttonRepeatDelay;
					return;
				}
				break;
			}
			goto IL_0012;
		}
	}
}
