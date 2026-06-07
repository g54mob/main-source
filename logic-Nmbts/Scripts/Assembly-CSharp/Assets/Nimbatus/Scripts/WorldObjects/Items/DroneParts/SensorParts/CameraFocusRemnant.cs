using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class CameraFocusRemnant : MonoBehaviour
	{
		public float Lifetime;

		public void Init()
		{
			RuntimeGlobals.Camera.AddTracker(base.transform, true, true);
			Invoke("Destroy", Lifetime);
		}

		public void Destroy()
		{
			RuntimeGlobals.Camera.RemoveTracker(base.transform);
			Object.Destroy(base.gameObject);
		}
	}
}
