using System;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class StandaloneAxis2D
	{
		[CustomObfuscation]
		public delegate void ValueChangedEventHandler(Vector2 value);

		[SerializeField]
		[CustomObfuscation]
		private Axis2DCalibration _calibration;

		[CustomObfuscation]
		[SerializeField]
		private StandaloneAxis _xAxis;

		[SerializeField]
		[CustomObfuscation]
		private StandaloneAxis _yAxis;

		private bool _allowEvents;

		public Axis2DCalibration calibration => null;

		public StandaloneAxis xAxis => null;

		public StandaloneAxis yAxis => null;

		public Vector2 value => default(Vector2);

		public Vector2 valuePrev => default(Vector2);

		public Vector2 valueDelta => default(Vector2);

		public Vector2 rawValue => default(Vector2);

		public Vector2 rawValuePrev => default(Vector2);

		public Vector2 rawValueDelta => default(Vector2);

		internal Vector2 rawZero => default(Vector2);

		private event ValueChangedEventHandler _ValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ValueChangedEventHandler ValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ValueChangedEventHandler _RawValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ValueChangedEventHandler RawValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		internal StandaloneAxis2D()
		{
		}

		internal StandaloneAxis2D(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
		}

		public void SetRawValue(float x, float y)
		{
		}

		public void SetRawValue(Vector2 value)
		{
		}

		public void Clear()
		{
		}

		internal void Initialize()
		{
		}

		internal void Deinitialize()
		{
		}

		private void EvalAndSendValueChangeEvents()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private Vector2 GetCalibratedValue(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			return default(Vector2);
		}

		private Vector2 GetCalibratedValuePrev(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			return default(Vector2);
		}

		private void OnAxisValueChanged(float value)
		{
		}

		private void OnAxisRawValueChanged(float value)
		{
		}

		internal static StandaloneAxis2D CreateRelative()
		{
			return null;
		}
	}
}
