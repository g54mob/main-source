using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Utils
{
	[ExecutionOrder(100)]
	public class HandAlignTool : MonoBehaviour
	{
		private Vector3 originalPos;

		private Quaternion originalRot;

		private void LateUpdate()
		{
			if (!TransmogrifyControllers.IsControllerReadyRight)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.G))
			{
				GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
				controllerRightHand.transform.parent.Find("Model")?.gameObject.SetActive(value: true);
				Transform child = controllerRightHand.GetComponentInChildren<VRTK_SDKTransformModify_DV>().transform.GetChild(0);
				SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, SDK_BaseController.ControllerHand.Right, enablePointer: true);
				TransmogrifyControllers.overrideControllersTransparent = true;
				TransmogrifyControllers.RefreshControllerMaterials();
				child.Find("OrientationReference/CalibrationHelper").gameObject.SetActive(value: true);
			}
			if (Input.GetKeyUp(KeyCode.G))
			{
				GameObject controllerRightHand2 = VRTK_DeviceFinder.GetControllerRightHand();
				controllerRightHand2.transform.parent.Find("Model")?.gameObject.SetActive(value: false);
				SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, SDK_BaseController.ControllerHand.Right, enablePointer: false);
				TransmogrifyControllers.overrideControllersTransparent = false;
				TransmogrifyControllers.RefreshControllerMaterials();
				controllerRightHand2.GetComponentInChildren<VRTK_SDKTransformModify_DV>().transform.GetChild(0).Find("OrientationReference/CalibrationHelper").gameObject.SetActive(value: false);
			}
			if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.G))
			{
				if (Input.GetKeyDown(KeyCode.H))
				{
					Transform child2 = VRTK_DeviceFinder.GetControllerRightHand().GetComponentInChildren<VRTK_SDKTransformModify_DV>().transform.GetChild(0);
					originalRot = child2.rotation;
					originalPos = child2.position;
				}
				DoHands();
			}
		}

		private void DoHands()
		{
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			Transform child = controllerRightHand.GetComponentInChildren<VRTK_SDKTransformModify_DV>().transform.GetChild(0);
			child.position = originalPos;
			child.rotation = originalRot;
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(controllerRightHand);
			VRTK_ControllerReference.GetControllerReference(controllerLeftHand);
			PipaUtils.AnchorData anchorData = PipaUtils.GetAnchorData(controllerReference);
			anchorData.handOffset = child.localPosition;
			anchorData.handRotation = child.localRotation;
			PipaUtils.SetAnchorData(controllerReference, anchorData);
			TransmogrifyControllers.AlignBeamObjects(controllerRightHand);
			TransmogrifyControllers.AlignBeamObjects(controllerLeftHand);
		}

		private void OnDestroy()
		{
			PipaUtils.SaveAnchorData();
		}
	}
}
