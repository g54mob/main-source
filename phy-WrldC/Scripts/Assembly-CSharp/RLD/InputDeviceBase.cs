using UnityEngine;

namespace RLD
{
	public abstract class InputDeviceBase : IInputDevice
	{
		private float _doubleTapDelay = 0.5f;

		private float _lastTapTime;

		private bool _didDoubleTap;

		private int _maxNumDeltaCaptures;

		private InputDeviceDeltaCapture[] _deltaCaptures;

		public bool DidDoubleTap => _didDoubleTap;

		public float DoubleTapDelay
		{
			get
			{
				return _doubleTapDelay;
			}
			set
			{
				_doubleTapDelay = Mathf.Max(value, 0f);
			}
		}

		public abstract InputDeviceType DeviceType { get; }

		public event InputDeviceDoubleTapHandler DoubleTap;

		public InputDeviceBase()
		{
			SetMaxNumDeltaCaptures(50);
		}

		public void SetMaxNumDeltaCaptures(int maxNumDeltaCaptures)
		{
			_maxNumDeltaCaptures = Mathf.Max(1, maxNumDeltaCaptures);
			_deltaCaptures = new InputDeviceDeltaCapture[_maxNumDeltaCaptures];
		}

		public bool CreateDeltaCapture(Vector3 deltaOrigin, out int deltaCaptureId)
		{
			deltaCaptureId = 0;
			while (deltaCaptureId < _maxNumDeltaCaptures && _deltaCaptures[deltaCaptureId] != null)
			{
				deltaCaptureId++;
			}
			if (deltaCaptureId == _maxNumDeltaCaptures)
			{
				deltaCaptureId = -1;
				return false;
			}
			InputDeviceDeltaCapture inputDeviceDeltaCapture = new InputDeviceDeltaCapture(deltaCaptureId, deltaOrigin);
			_deltaCaptures[deltaCaptureId] = inputDeviceDeltaCapture;
			return true;
		}

		public void RemoveDeltaCapture(int deltaCaptureId)
		{
			if (deltaCaptureId >= 0 && deltaCaptureId < _maxNumDeltaCaptures)
			{
				_deltaCaptures[deltaCaptureId] = null;
			}
		}

		public Vector3 GetCaptureDelta(int deltaCaptureId)
		{
			if (deltaCaptureId >= 0 && deltaCaptureId < _maxNumDeltaCaptures && _deltaCaptures[deltaCaptureId] != null)
			{
				return _deltaCaptures[deltaCaptureId].Delta;
			}
			return Vector3.zero;
		}

		public abstract Vector3 GetFrameDelta();

		public abstract Ray GetRay(Camera camera);

		public abstract Vector3 GetPositionYAxisUp();

		public abstract bool HasPointer();

		public abstract bool IsButtonPressed(int buttonIndex);

		public abstract bool WasButtonPressedInCurrentFrame(int buttonIndex);

		public abstract bool WasButtonReleasedInCurrentFrame(int buttonIndex);

		public abstract bool WasMoved();

		public void Update()
		{
			UpateFrameDeltas();
			UpdateDeltaCaptures();
			DetectAndHandleDoubleTap();
		}

		protected abstract void UpateFrameDeltas();

		private void UpdateDeltaCaptures()
		{
			int num = 0;
			Vector3 positionYAxisUp = GetPositionYAxisUp();
			while (num < _maxNumDeltaCaptures && _deltaCaptures[num] != null)
			{
				_deltaCaptures[num++].Update(positionYAxisUp);
			}
		}

		private void DetectAndHandleDoubleTap()
		{
			if (!WasButtonPressedInCurrentFrame(0))
			{
				return;
			}
			if (Time.time - _lastTapTime < _doubleTapDelay)
			{
				_lastTapTime = 0f;
				_didDoubleTap = true;
				if (this.DoubleTap != null)
				{
					this.DoubleTap(this, GetPositionYAxisUp());
				}
			}
			else
			{
				_didDoubleTap = false;
				_lastTapTime = Time.time;
			}
		}
	}
}
