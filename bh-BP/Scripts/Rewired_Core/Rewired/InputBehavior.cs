using System;
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _joystickAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisSimulation;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisSnap;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _digitalAxisInstantReverse;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisGravity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseXYAxisMode _mouseXYAxisMode;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseOtherAxisMode _mouseOtherAxisMode;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _mouseXYAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private MouseXYAxisDeltaCalc _mouseXYAxisDeltaCalc;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _mouseOtherAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _customControllerAxisSensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDoublePressSpeed;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressTime;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonShortPressExpiresIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonLongPressTime;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonLongPressExpiresIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDeadZone;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonDownBuffer;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonRepeatRate;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _buttonRepeatDelay;

		public int id
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public string name
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public float joystickAxisSensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool digitalAxisSimulation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool digitalAxisSnap
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool digitalAxisInstantReverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float digitalAxisGravity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float digitalAxisSensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MouseXYAxisMode mouseXYAxisMode
		{
			get
			{
				return default(MouseXYAxisMode);
			}
			set
			{
			}
		}

		public MouseOtherAxisMode mouseOtherAxisMode
		{
			get
			{
				return default(MouseOtherAxisMode);
			}
			set
			{
			}
		}

		public float mouseXYAxisSensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MouseXYAxisDeltaCalc mouseXYAxisDeltaCalc
		{
			get
			{
				return default(MouseXYAxisDeltaCalc);
			}
			set
			{
			}
		}

		public float mouseOtherAxisSensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float customControllerAxisSensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonDoublePressSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonShortPressTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonShortPressExpiresIn
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonLongPressTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonLongPressExpiresIn
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonDeadZone
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonDownBuffer
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonRepeatRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buttonRepeatDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public InputBehavior()
		{
		}

		public InputBehavior(InputBehavior P_0)
		{
		}

		public string ToXmlString()
		{
			return null;
		}

		public bool ImportXmlString(string xmlString)
		{
			return false;
		}

		public string ToJsonString()
		{
			return null;
		}

		public bool ImportJsonString(string jsonString)
		{
			return false;
		}

		public bool ImportData(InputBehavior inputBehavior)
		{
			return false;
		}

		public InputBehavior Clone()
		{
			return null;
		}

		public void Reset()
		{
		}

		internal SerializedObject BwcfRaJHiUnYCxvMsUhRcEYAwcVCA()
		{
			return null;
		}

		internal void ILRzduXnCrOkMEEHVhgBHktOOgWJ(SerializedObject P_0)
		{
		}

		private static void hRoGYIBtIxJJzCeEizEYQKBhNiWpb(InputBehavior P_0, InputBehavior P_1, bool P_2)
		{
		}
	}
}
