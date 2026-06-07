using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	public class MMCinemachineHelpers : MonoBehaviour
	{
		public static GameObject AutomaticCinemachineShakersSetup(MMF_Player owner, string feedbackName)
		{
			GameObject gameObject = null;
			bool flag = false;
			string text = owner.name + " " + feedbackName + " feedback automatic shaker setup : ";
			if ((CinemachineBrain)Object.FindFirstObjectByType(typeof(CinemachineBrain)) == null)
			{
				Camera.main.gameObject.AddComponent<CinemachineBrain>();
				text += "Added a Cinemachine Brain to the scene. ";
			}
			CinemachineCamera cinemachineCamera = (CinemachineCamera)Object.FindFirstObjectByType(typeof(CinemachineCamera));
			if (cinemachineCamera == null)
			{
				GameObject gameObject2 = new GameObject("CinemachineCamera");
				if (Camera.main != null)
				{
					gameObject2.transform.position = Camera.main.transform.position;
				}
				cinemachineCamera = gameObject2.AddComponent<CinemachineCamera>();
				text += "Added a Cinemachine Camera to the scene. ";
				flag = true;
			}
			gameObject = cinemachineCamera.gameObject;
			if (cinemachineCamera.GetComponent<CinemachineImpulseListener>() == null)
			{
				cinemachineCamera.gameObject.AddComponent<CinemachineImpulseListener>();
				text += "Added an impulse listener. ";
			}
			if (flag)
			{
				gameObject.MMGetOrAddComponent<MMCinemachineCameraShaker>();
				gameObject.MMGetOrAddComponent<MMCinemachineZoom>();
				gameObject.MMGetOrAddComponent<MMCinemachinePriorityListener>();
				gameObject.MMGetOrAddComponent<MMCinemachineClippingPlanesShaker>();
				gameObject.MMGetOrAddComponent<MMCinemachineFieldOfViewShaker>();
				text += "Added camera shaker, zoom, priority listener, clipping planes shaker and field of view shaker to the Cinemachine Camera. ";
			}
			MMDebug.DebugLogInfo(text + "You're all set.");
			return gameObject;
		}
	}
}
