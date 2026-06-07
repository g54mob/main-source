using UnityEngine;

namespace DV.Interaction
{
	public class GrabberMouseCursor : MonoBehaviour, IGrabberCursor
	{
		public bool useCursorScreenCoordinates;

		public Camera cam;

		private IPlayerRig rig;

		public IPlayerRig Rig => rig;

		private void Awake()
		{
			rig = GetComponent<IPlayerRig>();
		}

		public void Start()
		{
			if (cam == null)
			{
				Debug.LogError("Camera is not set on GrabberMouseCursor!", this);
				Object.Destroy(this);
			}
		}

		public Ray GetRay()
		{
			if (useCursorScreenCoordinates)
			{
				return cam.ScreenPointToRay(Input.mousePosition);
			}
			return new Ray(cam.transform.position, cam.transform.forward);
		}
	}
}
