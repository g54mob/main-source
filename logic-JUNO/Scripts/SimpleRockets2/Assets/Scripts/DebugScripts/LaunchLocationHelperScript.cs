using Assets.Scripts.Flight;
using ModApi.Flight.GameView;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.DebugScripts
{
	public class LaunchLocationHelperScript : MonoBehaviour
	{
		[SerializeField]
		private bool _snapToGround = true;

		[ContextMenu("Create Launch Location")]
		private void GenerateLocation()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			IReferenceFrame referenceFrame = instance.ViewManager.GameView.ReferenceFrame;
			Vector3d position = referenceFrame.FrameToPlanetPosition(base.transform.position);
			Quaterniond heading = referenceFrame.FrameToPlanetRotation(base.transform.rotation);
			Vector3d velocity = referenceFrame.FrameToPlanetVelocity(Vector3.zero);
			Debug.Log(LaunchLocation.CreateLaunchLocation("New Launch Location", instance.CraftNode.Parent, position, velocity, heading, referenceFrame, (!_snapToGround) ? LaunchLocationType.SurfaceLockedAir : LaunchLocationType.SurfaceLockedGround).GenerateXml().ToString());
		}
	}
}
