using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "CameraParamters", menuName = "CTS/Camera/Parameters")]
	public class SOCameraParemeters : ScriptableObject
	{
		[field: Header("Base")]
		[field: SerializeField]
		public float BaseHeight { get; private set; }

		[field: SerializeField]
		public float HeightOffset { get; private set; } = 1f;

		[field: Header("Movement")]
		[field: SerializeField]
		public bool WantModifyMovement { get; private set; }

		[field: SerializeField]
		[field: ShowIf("WantModifyMovement")]
		public CameraMovementStruct Movements { get; private set; }

		[field: HorizontalLine(2f, EColor.Gray)]
		[field: Space(15f)]
		[field: Header("Rotation")]
		[field: SerializeField]
		public bool WantModifyRotation { get; private set; }

		[field: SerializeField]
		[field: ShowIf("WantModifyRotation")]
		public CameraRotationStruct Rotate { get; private set; }

		[field: HorizontalLine(2f, EColor.Gray)]
		[field: Space(15f)]
		[field: Header("Mouse Click")]
		[field: SerializeField]
		public bool WantModifyMouseClick { get; private set; }

		[field: SerializeField]
		[field: ShowIf("WantModifyMouseClick")]
		public CameraMouseControlsStruct MouseClick { get; private set; }

		[field: HorizontalLine(2f, EColor.Gray)]
		[field: Space(15f)]
		[field: Header("Zoom")]
		[field: SerializeField]
		public bool WantModifyZoom { get; private set; }

		[field: SerializeField]
		[field: ShowIf("WantModifyZoom")]
		public CameraZoomStruct Zoom { get; private set; }

		public void ChangeValue(CameraRotationStruct cameraRotation, CameraZoomStruct cameraZoom, CameraMovementStruct cameraMovements, CameraMouseControlsStruct cameraMouseControls)
		{
			WantModifyMouseClick = true;
			WantModifyZoom = true;
			WantModifyRotation = true;
			WantModifyMovement = true;
			Movements = cameraMovements;
			Rotate = cameraRotation;
			MouseClick = cameraMouseControls;
			Zoom = cameraZoom;
		}
	}
}
