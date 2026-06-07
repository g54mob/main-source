using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours.Camera
{
	public class FaceCameraScript : MonoBehaviour
	{
		public Transform Target { get; set; }

		protected virtual void Start()
		{
			Target = FlightSceneScript.Instance?.CameraScript?.CameraTransform;
		}

		protected virtual void Update()
		{
			if (Target != null)
			{
				Vector3 forward = base.transform.position - Target.position;
				forward.y = 0f;
				base.transform.rotation = Quaternion.LookRotation(forward);
			}
		}
	}
}
