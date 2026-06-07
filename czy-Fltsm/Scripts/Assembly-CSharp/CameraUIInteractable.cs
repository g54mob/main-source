using System;
using UnityEngine;

public class CameraUIInteractable : UIInteractable
{
	[Tooltip("Camera action that will be triggered when interacting with this UI element.")]
	[SerializeField]
	private CameraController.CameraActions _cameraAction = CameraController.CameraActions.CenterOnTownheart;

	public override void Interact()
	{
		base.Interact();
		switch (_cameraAction)
		{
		case CameraController.CameraActions.ResetCamera:
			CameraController.Instance.LoadPreset(overridePosition: false);
			break;
		case CameraController.CameraActions.CenterOnTownheart:
			if (!WorldMapManager.CenterOnTownheart())
			{
				CameraController.Instance.CenterOnTownheart();
			}
			break;
		default:
			throw new NotImplementedException($"Camera action {_cameraAction.ToString()} is not implemented.");
		}
	}
}
