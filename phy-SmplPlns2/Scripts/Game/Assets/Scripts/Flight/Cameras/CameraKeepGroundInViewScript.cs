using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class CameraKeepGroundInViewScript : MonoBehaviour
	{
		public float HowMuchPlaneToKeepInView = 0.5f;

		public float MaxFov = 100f;

		public float MaxFovDistance = 300f;

		public float MinFov = 3f;

		public float MinFovDist = 1500f;

		public Transform ObjectToTrack;

		public float ZoomSpeed = 5f;

		private Transform _objectToTrack;

		private bool _zoomed;

		protected virtual void Start()
		{
			if (ObjectToTrack == null)
			{
				Debug.LogError("Object to track is null");
			}
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Z))
			{
				_zoomed = !_zoomed;
			}
			float num = Vector3.Distance(base.transform.position, _objectToTrack.position);
			if (_zoomed)
			{
				float b;
				if (num >= MinFovDist)
				{
					b = MinFov;
				}
				else if (num <= MaxFovDistance)
				{
					b = MaxFov;
				}
				else
				{
					float num2 = MinFovDist - MaxFovDistance;
					float num3 = MaxFov - MinFov;
					float num4 = (MinFovDist - num) / num2;
					b = MinFov + num4 * num3;
				}
				GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, b, Time.unscaledDeltaTime * ZoomSpeed);
			}
			else
			{
				GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, MaxFov, Time.unscaledDeltaTime * ZoomSpeed);
			}
			base.transform.LookAt(_objectToTrack.transform.position);
		}
	}
}
