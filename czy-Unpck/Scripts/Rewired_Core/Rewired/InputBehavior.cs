using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputBehavior
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _joystickAxisSensitivity = 1f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _digitalAxisSimulation = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _digitalAxisSnap;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisInstantReverse;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _digitalAxisGravity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisSensitivity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private MouseXYAxisMode _mouseXYAxisMode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private MouseOtherAxisMode _mouseOtherAxisMode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _mouseXYAxisSensitivity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private MouseXYAxisDeltaCalc _mouseXYAxisDeltaCalc;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _mouseOtherAxisSensitivity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _customControllerAxisSensitivity = 1f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDoublePressSpeed;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressTime = 0.25f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressExpiresIn;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonLongPressTime = 1f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonLongPressExpiresIn;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonDeadZone;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonDownBuffer;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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
			HndZLlZFpVEsROdDhPfLIpcZFHE(source, this, true);
		}

		public string ToXmlString()
		{
			try
			{
				return ZUgwEqRCyKfmmTriWKhFHBtsphC().ToXmlString(writeDocumentTag: true);
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
				mJCczqeFiFMzoayoFJmEwVIjyQZW(SerializedObject.FromXml(GetType(), xmlString));
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
				return ZUgwEqRCyKfmmTriWKhFHBtsphC().ToJsonString();
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
				mJCczqeFiFMzoayoFJmEwVIjyQZW(SerializedObject.FromJson(GetType(), jsonString));
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
			HndZLlZFpVEsROdDhPfLIpcZFHE(inputBehavior, this, false);
			return true;
		}

		public InputBehavior Clone()
		{
			return new InputBehavior(this);
		}

		public void Reset()
		{
			InputBehavior inputBehavior = ReInput.mapping.LCBlTwSOZFBVudqRecZeDkCwyUh(_id);
			if (inputBehavior != null)
			{
				HndZLlZFpVEsROdDhPfLIpcZFHE(inputBehavior, this, true);
			}
		}

		internal SerializedObject ZUgwEqRCyKfmmTriWKhFHBtsphC()
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
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				prefix = "xsi",
				localName = "schemaLocation",
				ns = null,
				value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.4", "/", GetType().Name, ".xsd")
			});
			while (true)
			{
				int num = -1495484142;
				while (true)
				{
					switch (num ^ -1495484139)
					{
					case 0:
						break;
					case 8:
						serializedObject.Add("buttonLongPressTime", _buttonLongPressTime);
						serializedObject.Add("buttonLongPressExpiresIn", _buttonLongPressExpiresIn);
						serializedObject.Add("buttonDeadZone", _buttonDeadZone);
						serializedObject.Add("buttonDownBuffer", _buttonDownBuffer);
						num = -1495484138;
						continue;
					case 6:
						serializedObject.Add("mouseOtherAxisMode", _mouseOtherAxisMode);
						num = -1495484143;
						continue;
					case 2:
						serializedObject.Add("digitalAxisSensitivity", _digitalAxisSensitivity);
						serializedObject.Add("mouseXYAxisMode", _mouseXYAxisMode);
						num = -1495484141;
						continue;
					case 4:
						serializedObject.Add("mouseXYAxisSensitivity", _mouseXYAxisSensitivity);
						serializedObject.Add("mouseXYAxisDeltaCalc", _mouseXYAxisDeltaCalc);
						serializedObject.Add("mouseOtherAxisSensitivity", _mouseOtherAxisSensitivity);
						num = -1495484144;
						continue;
					case 1:
						serializedObject.Add("joystickAxisSensitivity", _joystickAxisSensitivity);
						serializedObject.Add("digitalAxisSimulation", _digitalAxisSimulation);
						serializedObject.Add("digitalAxisSnap", _digitalAxisSnap);
						serializedObject.Add("digitalAxisInstantReverse", _digitalAxisInstantReverse);
						serializedObject.Add("digitalAxisGravity", _digitalAxisGravity);
						num = -1495484137;
						continue;
					case 5:
						serializedObject.Add("customControllerAxisSensitivity", _customControllerAxisSensitivity);
						serializedObject.Add("buttonDoublePressSpeed", _buttonDoublePressSpeed);
						serializedObject.Add("buttonShortPressTime", _buttonShortPressTime);
						serializedObject.Add("buttonShortPressExpiresIn", _buttonShortPressExpiresIn);
						num = -1495484131;
						continue;
					case 7:
						serializedObject.Add("id", _id);
						serializedObject.Add("name", _name);
						num = -1495484140;
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

		internal void mJCczqeFiFMzoayoFJmEwVIjyQZW(SerializedObject P_0)
		{
			Reset();
			while (true)
			{
				int num = -2113198316;
				while (true)
				{
					switch (num ^ -2113198315)
					{
					case 0:
						break;
					case 1:
						P_0.TryGetDeserializedValueByRef("joystickAxisSensitivity", ref _joystickAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("digitalAxisSimulation", ref _digitalAxisSimulation);
						P_0.TryGetDeserializedValueByRef("digitalAxisSnap", ref _digitalAxisSnap);
						P_0.TryGetDeserializedValueByRef("digitalAxisInstantReverse", ref _digitalAxisInstantReverse);
						P_0.TryGetDeserializedValueByRef("digitalAxisGravity", ref _digitalAxisGravity);
						P_0.TryGetDeserializedValueByRef("digitalAxisSensitivity", ref _digitalAxisSensitivity);
						num = -2113198313;
						continue;
					case 2:
						P_0.TryGetDeserializedValueByRef("mouseXYAxisMode", ref _mouseXYAxisMode);
						P_0.TryGetDeserializedValueByRef("mouseOtherAxisMode", ref _mouseOtherAxisMode);
						P_0.TryGetDeserializedValueByRef("mouseXYAxisSensitivity", ref _mouseXYAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("mouseXYAxisDeltaCalc", ref _mouseXYAxisDeltaCalc);
						P_0.TryGetDeserializedValueByRef("mouseOtherAxisSensitivity", ref _mouseOtherAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("customControllerAxisSensitivity", ref _customControllerAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("buttonDoublePressSpeed", ref _buttonDoublePressSpeed);
						P_0.TryGetDeserializedValueByRef("buttonShortPressTime", ref _buttonShortPressTime);
						P_0.TryGetDeserializedValueByRef("buttonShortPressExpiresIn", ref _buttonShortPressExpiresIn);
						num = -2113198314;
						continue;
					default:
						P_0.TryGetDeserializedValueByRef("buttonLongPressTime", ref _buttonLongPressTime);
						P_0.TryGetDeserializedValueByRef("buttonLongPressExpiresIn", ref _buttonLongPressExpiresIn);
						P_0.TryGetDeserializedValueByRef("buttonDeadZone", ref _buttonDeadZone);
						P_0.TryGetDeserializedValueByRef("buttonDownBuffer", ref _buttonDownBuffer);
						P_0.TryGetDeserializedValueByRef("buttonRepeatRate", ref _buttonRepeatRate);
						P_0.TryGetDeserializedValueByRef("buttonRepeatDelay", ref _buttonRepeatDelay);
						return;
					}
					break;
				}
			}
		}

		private static void HndZLlZFpVEsROdDhPfLIpcZFHE(InputBehavior P_0, InputBehavior P_1, bool P_2)
		{
			if (P_2)
			{
				P_1._id = P_0._id;
				goto IL_0012;
			}
			goto IL_00cd;
			IL_00cd:
			P_1._name = P_0._name;
			int num = 1788120963;
			goto IL_0017;
			IL_0012:
			num = 1788120966;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x6A948F82)
				{
				case 7:
					break;
				case 9:
					P_1._digitalAxisSensitivity = P_0._digitalAxisSensitivity;
					num = 1788120968;
					continue;
				case 0:
					P_1._mouseOtherAxisSensitivity = P_0._mouseOtherAxisSensitivity;
					P_1._mouseXYAxisDeltaCalc = P_0._mouseXYAxisDeltaCalc;
					num = 1788120970;
					continue;
				case 10:
					P_1._mouseXYAxisMode = P_0._mouseXYAxisMode;
					P_1._mouseOtherAxisMode = P_0._mouseOtherAxisMode;
					P_1._mouseXYAxisSensitivity = P_0._mouseXYAxisSensitivity;
					num = 1788120962;
					continue;
				case 11:
					P_1._buttonDownBuffer = P_0._buttonDownBuffer;
					num = 1788120960;
					continue;
				case 4:
					goto IL_00cd;
				case 2:
					P_1._buttonRepeatRate = P_0._buttonRepeatRate;
					num = 1788120961;
					continue;
				case 8:
					P_1._customControllerAxisSensitivity = P_0._customControllerAxisSensitivity;
					P_1._buttonDoublePressSpeed = P_0._buttonDoublePressSpeed;
					P_1._buttonShortPressTime = P_0._buttonShortPressTime;
					P_1._buttonShortPressExpiresIn = P_0._buttonShortPressExpiresIn;
					P_1._buttonLongPressTime = P_0._buttonLongPressTime;
					P_1._buttonLongPressExpiresIn = P_0._buttonLongPressExpiresIn;
					P_1._buttonDeadZone = P_0._buttonDeadZone;
					num = 1788120969;
					continue;
				case 6:
					P_1._digitalAxisSnap = P_0._digitalAxisSnap;
					P_1._digitalAxisInstantReverse = P_0._digitalAxisInstantReverse;
					P_1._digitalAxisGravity = P_0._digitalAxisGravity;
					num = 1788120971;
					continue;
				case 1:
					P_1._joystickAxisSensitivity = P_0._joystickAxisSensitivity;
					num = 1788120967;
					continue;
				case 5:
					P_1._digitalAxisSimulation = P_0._digitalAxisSimulation;
					num = 1788120964;
					continue;
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
