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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _joystickAxisSensitivity = 1f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _digitalAxisSimulation = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisSnap;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisInstantReverse;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisGravity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _digitalAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseXYAxisMode _mouseXYAxisMode;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseOtherAxisMode _mouseOtherAxisMode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _mouseXYAxisSensitivity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private MouseXYAxisDeltaCalc _mouseXYAxisDeltaCalc;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _mouseOtherAxisSensitivity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _customControllerAxisSensitivity = 1f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonDoublePressSpeed;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonShortPressTime = 0.25f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressExpiresIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonLongPressTime = 1f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonLongPressExpiresIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDeadZone;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonDownBuffer;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonRepeatRate = 30f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				while (true)
				{
					int num = 173165631;
					while (true)
					{
						switch (num ^ 0xA524C3D)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0030;
						case 1:
							return;
						}
						break;
						IL_0030:
						_digitalAxisGravity = value;
						num = 173165628;
					}
				}
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
				while (true)
				{
					int num = -188773392;
					while (true)
					{
						switch (num ^ -188773391)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0030;
						case 2:
							return;
						}
						break;
						IL_0030:
						_mouseXYAxisSensitivity = value;
						num = -188773389;
					}
				}
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
			TmfijbZUILGIfPMjACWKbxEIKPo(source, this, true);
		}

		public string ToXmlString()
		{
			try
			{
				return ZIeRIePeTSQWAIzEhmUQcKNbKpi().ToXmlString(true);
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
				wdORaALJIVHeMdYgqVfHekvpUfr(SerializedObject.FromXml(GetType(), xmlString));
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
				return ZIeRIePeTSQWAIzEhmUQcKNbKpi().ToJsonString();
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
				wdORaALJIVHeMdYgqVfHekvpUfr(SerializedObject.FromJson(GetType(), jsonString));
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
			TmfijbZUILGIfPMjACWKbxEIKPo(inputBehavior, this, false);
			return true;
		}

		public InputBehavior Clone()
		{
			return new InputBehavior(this);
		}

		public void Reset()
		{
			InputBehavior inputBehavior = ReInput.mapping.PDLBpiYomVdxEiynPbsrqAsfQgD(_id);
			if (inputBehavior == null)
			{
				while (true)
				{
					switch (0x2AE6E82F ^ 0x2AE6E82E)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			TmfijbZUILGIfPMjACWKbxEIKPo(inputBehavior, this, true);
		}

		internal SerializedObject ZIeRIePeTSQWAIzEhmUQcKNbKpi()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 5, SerializedObject.FieldOptions.ExculdeFromXml);
			while (true)
			{
				int num = 1313538739;
				while (true)
				{
					switch (num ^ 0x4E4B02B2)
					{
					case 7:
						break;
					case 1:
						serializedObject.xmlInfo = new SerializedObject.XmlInfo();
						num = 1313538740;
						continue;
					case 6:
						serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
						{
							localName = "dataVersion",
							value = 5.ToString()
						});
						num = 1313538737;
						continue;
					case 4:
						serializedObject.Add("digitalAxisSnap", _digitalAxisSnap);
						serializedObject.Add("digitalAxisInstantReverse", _digitalAxisInstantReverse);
						serializedObject.Add("digitalAxisGravity", _digitalAxisGravity);
						serializedObject.Add("digitalAxisSensitivity", _digitalAxisSensitivity);
						num = 1313538743;
						continue;
					case 2:
						serializedObject.Add("digitalAxisSimulation", _digitalAxisSimulation);
						num = 1313538742;
						continue;
					case 0:
						serializedObject.Add("mouseOtherAxisMode", _mouseOtherAxisMode);
						serializedObject.Add("mouseXYAxisSensitivity", _mouseXYAxisSensitivity);
						serializedObject.Add("mouseXYAxisDeltaCalc", _mouseXYAxisDeltaCalc);
						serializedObject.Add("mouseOtherAxisSensitivity", _mouseOtherAxisSensitivity);
						serializedObject.Add("customControllerAxisSensitivity", _customControllerAxisSensitivity);
						serializedObject.Add("buttonDoublePressSpeed", _buttonDoublePressSpeed);
						serializedObject.Add("buttonShortPressTime", _buttonShortPressTime);
						serializedObject.Add("buttonShortPressExpiresIn", _buttonShortPressExpiresIn);
						serializedObject.Add("buttonLongPressTime", _buttonLongPressTime);
						serializedObject.Add("buttonLongPressExpiresIn", _buttonLongPressExpiresIn);
						serializedObject.Add("buttonDeadZone", _buttonDeadZone);
						serializedObject.Add("buttonDownBuffer", _buttonDownBuffer);
						num = 1313538746;
						continue;
					case 3:
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
						serializedObject.Add("id", _id);
						serializedObject.Add("name", _name);
						serializedObject.Add("joystickAxisSensitivity", _joystickAxisSensitivity);
						num = 1313538736;
						continue;
					case 5:
						serializedObject.Add("mouseXYAxisMode", _mouseXYAxisMode);
						num = 1313538738;
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

		internal void wdORaALJIVHeMdYgqVfHekvpUfr(SerializedObject P_0)
		{
			Reset();
			P_0.TryGetDeserializedValueByRef("joystickAxisSensitivity", ref _joystickAxisSensitivity);
			P_0.TryGetDeserializedValueByRef("digitalAxisSimulation", ref _digitalAxisSimulation);
			P_0.TryGetDeserializedValueByRef("digitalAxisSnap", ref _digitalAxisSnap);
			P_0.TryGetDeserializedValueByRef("digitalAxisInstantReverse", ref _digitalAxisInstantReverse);
			while (true)
			{
				int num = -1661813630;
				while (true)
				{
					switch (num ^ -1661813626)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						P_0.TryGetDeserializedValueByRef("buttonShortPressExpiresIn", ref _buttonShortPressExpiresIn);
						num = -1661813629;
						continue;
					case 0:
						P_0.TryGetDeserializedValueByRef("mouseOtherAxisMode", ref _mouseOtherAxisMode);
						P_0.TryGetDeserializedValueByRef("mouseXYAxisSensitivity", ref _mouseXYAxisSensitivity);
						num = -1661813628;
						continue;
					case 5:
						P_0.TryGetDeserializedValueByRef("buttonLongPressTime", ref _buttonLongPressTime);
						num = -1661813631;
						continue;
					case 4:
						P_0.TryGetDeserializedValueByRef("digitalAxisGravity", ref _digitalAxisGravity);
						P_0.TryGetDeserializedValueByRef("digitalAxisSensitivity", ref _digitalAxisSensitivity);
						num = -1661813632;
						continue;
					case 7:
						P_0.TryGetDeserializedValueByRef("buttonLongPressExpiresIn", ref _buttonLongPressExpiresIn);
						P_0.TryGetDeserializedValueByRef("buttonDeadZone", ref _buttonDeadZone);
						P_0.TryGetDeserializedValueByRef("buttonDownBuffer", ref _buttonDownBuffer);
						P_0.TryGetDeserializedValueByRef("buttonRepeatRate", ref _buttonRepeatRate);
						P_0.TryGetDeserializedValueByRef("buttonRepeatDelay", ref _buttonRepeatDelay);
						num = -1661813618;
						continue;
					case 6:
						P_0.TryGetDeserializedValueByRef("mouseXYAxisMode", ref _mouseXYAxisMode);
						num = -1661813626;
						continue;
					case 2:
						P_0.TryGetDeserializedValueByRef("mouseXYAxisDeltaCalc", ref _mouseXYAxisDeltaCalc);
						P_0.TryGetDeserializedValueByRef("mouseOtherAxisSensitivity", ref _mouseOtherAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("customControllerAxisSensitivity", ref _customControllerAxisSensitivity);
						P_0.TryGetDeserializedValueByRef("buttonDoublePressSpeed", ref _buttonDoublePressSpeed);
						P_0.TryGetDeserializedValueByRef("buttonShortPressTime", ref _buttonShortPressTime);
						num = -1661813625;
						continue;
					case 8:
						return;
					}
					break;
				}
			}
		}

		private static void TmfijbZUILGIfPMjACWKbxEIKPo(InputBehavior P_0, InputBehavior P_1, bool P_2)
		{
			if (P_2)
			{
				P_1._id = P_0._id;
				goto IL_0012;
			}
			goto IL_0154;
			IL_0154:
			P_1._name = P_0._name;
			int num = 681935494;
			goto IL_0017;
			IL_0012:
			num = 681935495;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x28A5828F)
				{
				case 10:
					break;
				default:
					return;
				case 1:
					P_1._buttonLongPressExpiresIn = P_0._buttonLongPressExpiresIn;
					num = 681935492;
					continue;
				case 2:
					P_1._mouseXYAxisMode = P_0._mouseXYAxisMode;
					P_1._mouseOtherAxisMode = P_0._mouseOtherAxisMode;
					P_1._mouseXYAxisSensitivity = P_0._mouseXYAxisSensitivity;
					P_1._mouseOtherAxisSensitivity = P_0._mouseOtherAxisSensitivity;
					num = 681935503;
					continue;
				case 3:
					P_1._buttonDownBuffer = P_0._buttonDownBuffer;
					num = 681935498;
					continue;
				case 9:
					P_1._joystickAxisSensitivity = P_0._joystickAxisSensitivity;
					P_1._digitalAxisSimulation = P_0._digitalAxisSimulation;
					num = 681935496;
					continue;
				case 12:
					P_1._buttonDoublePressSpeed = P_0._buttonDoublePressSpeed;
					P_1._buttonShortPressTime = P_0._buttonShortPressTime;
					P_1._buttonShortPressExpiresIn = P_0._buttonShortPressExpiresIn;
					P_1._buttonLongPressTime = P_0._buttonLongPressTime;
					num = 681935502;
					continue;
				case 7:
					P_1._digitalAxisSnap = P_0._digitalAxisSnap;
					P_1._digitalAxisInstantReverse = P_0._digitalAxisInstantReverse;
					P_1._digitalAxisGravity = P_0._digitalAxisGravity;
					P_1._digitalAxisSensitivity = P_0._digitalAxisSensitivity;
					num = 681935501;
					continue;
				case 8:
					goto IL_0154;
				case 11:
					P_1._buttonDeadZone = P_0._buttonDeadZone;
					num = 681935500;
					continue;
				case 4:
					P_1._buttonRepeatDelay = P_0._buttonRepeatDelay;
					num = 681935497;
					continue;
				case 0:
					P_1._mouseXYAxisDeltaCalc = P_0._mouseXYAxisDeltaCalc;
					P_1._customControllerAxisSensitivity = P_0._customControllerAxisSensitivity;
					num = 681935491;
					continue;
				case 5:
					P_1._buttonRepeatRate = P_0._buttonRepeatRate;
					num = 681935499;
					continue;
				case 6:
					return;
				}
				break;
			}
			goto IL_0012;
		}
	}
}
