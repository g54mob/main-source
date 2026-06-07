using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	public class CameraControllerDebug : MonoBehaviour
	{
		private FlyByCameraController _flyBy;

		[Range(-20f, 20f)]
		[SerializeField]
		private float _flybySecondsAhead = 5f;

		[Range(-200f, 200f)]
		[SerializeField]
		private float _relativeCameraSpeed = 5f;

		public float FlybySecondsAhead
		{
			get
			{
				return _flybySecondsAhead;
			}
			set
			{
				_flybySecondsAhead = value;
			}
		}

		public float RelativeCameraSpeed
		{
			get
			{
				return _relativeCameraSpeed;
			}
			set
			{
				_relativeCameraSpeed = value;
			}
		}

		public void Initialize(FlyByCameraController flyBy)
		{
			_flyBy = flyBy;
		}

		private void OnValidate()
		{
			_flyBy?.DebugScriptSettingsChanged();
		}
	}
}
