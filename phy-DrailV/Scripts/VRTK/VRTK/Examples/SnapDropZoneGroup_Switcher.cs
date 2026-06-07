using UnityEngine;

namespace VRTK.Examples
{
	public class SnapDropZoneGroup_Switcher : MonoBehaviour
	{
		private VRTK_SnapDropZone cubeZone;

		private VRTK_SnapDropZone sphereZone;

		private void Start()
		{
			cubeZone = base.transform.Find("Cube_SnapDropZone").gameObject.GetComponent<VRTK_SnapDropZone>();
			sphereZone = base.transform.Find("Sphere_SnapDropZone").GetComponent<VRTK_SnapDropZone>();
			cubeZone.ObjectEnteredSnapDropZone += DoCubeZoneSnapped;
			cubeZone.ObjectSnappedToDropZone += DoCubeZoneSnapped;
			cubeZone.ObjectExitedSnapDropZone += DoCubeZoneUnsnapped;
			cubeZone.ObjectUnsnappedFromDropZone += DoCubeZoneUnsnapped;
			sphereZone.ObjectEnteredSnapDropZone += DoSphereZoneSnapped;
			sphereZone.ObjectSnappedToDropZone += DoSphereZoneSnapped;
			sphereZone.ObjectExitedSnapDropZone += DoSphereZoneUnsnapped;
			sphereZone.ObjectUnsnappedFromDropZone += DoSphereZoneUnsnapped;
		}

		private void DoCubeZoneSnapped(object sender, SnapDropZoneEventArgs e)
		{
			if (sphereZone.GetCurrentSnappedObject() == null)
			{
				sphereZone.gameObject.SetActive(value: false);
			}
		}

		private void DoCubeZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
		{
			if (cubeZone.GetCurrentSnappedObject() == null)
			{
				sphereZone.gameObject.SetActive(value: true);
			}
		}

		private void DoSphereZoneSnapped(object sender, SnapDropZoneEventArgs e)
		{
			if (cubeZone.GetCurrentSnappedObject() == null)
			{
				cubeZone.gameObject.SetActive(value: false);
			}
		}

		private void DoSphereZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
		{
			if (sphereZone.GetCurrentSnappedObject() == null)
			{
				cubeZone.gameObject.SetActive(value: true);
			}
		}
	}
}
