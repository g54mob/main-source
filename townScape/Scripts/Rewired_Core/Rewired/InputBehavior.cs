using System;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputBehavior
	{
		[CustomObfuscation]
		[SerializeField]
		private int _id;

		[CustomObfuscation]
		[SerializeField]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private float _joystickAxisSensitivity;

		[CustomObfuscation]
		[SerializeField]
		private bool _digitalAxisSimulation;

		[CustomObfuscation]
		[SerializeField]
		private bool _digitalAxisSnap;

		[CustomObfuscation]
		[SerializeField]
		private bool _digitalAxisInstantReverse;

		[CustomObfuscation]
		[SerializeField]
		private float _digitalAxisGravity;

		[CustomObfuscation]
		[SerializeField]
		private float _digitalAxisSensitivity;

		[CustomObfuscation]
		[SerializeField]
		private MouseXYAxisMode _mouseXYAxisMode;

		[CustomObfuscation]
		[SerializeField]
		private MouseOtherAxisMode _mouseOtherAxisMode;

		[SerializeField]
		[CustomObfuscation]
		private float _mouseXYAxisSensitivity;

		[SerializeField]
		[CustomObfuscation]
		private MouseXYAxisDeltaCalc _mouseXYAxisDeltaCalc;

		[CustomObfuscation]
		[SerializeField]
		private float _mouseOtherAxisSensitivity;

		[SerializeField]
		[CustomObfuscation]
		private float _customControllerAxisSensitivity;

		[CustomObfuscation]
		[SerializeField]
		private float _buttonDoublePressSpeed;

		[CustomObfuscation]
		[SerializeField]
		private float _buttonShortPressTime;

		[SerializeField]
		[CustomObfuscation]
		private float _buttonShortPressExpiresIn;

		[CustomObfuscation]
		[SerializeField]
		private float _buttonLongPressTime;

		[CustomObfuscation]
		[SerializeField]
		private float _buttonLongPressExpiresIn;

		[CustomObfuscation]
		[SerializeField]
		private float _buttonDeadZone;

		[CustomObfuscation]
		[SerializeField]
		private float _buttonDownBuffer;

		[SerializeField]
		[CustomObfuscation]
		private float _buttonRepeatRate;

		[SerializeField]
		[CustomObfuscation]
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

		public InputBehavior(InputBehavior source)
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

		internal SerializedObject kkMVitTdvBlPPYxCUKxcfnCitZi()
		{
			return null;
		}

		internal void ZWqiYvVBnOSmHpdITpVnhXnqEKp(SerializedObject P_0)
		{
		}

		private static void iETeFaHsXEhJsTvQtSecgHvDZgo(InputBehavior P_0, InputBehavior P_1, bool P_2)
		{
		}
	}
}
