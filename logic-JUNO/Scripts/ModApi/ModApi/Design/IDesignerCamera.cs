using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Design
{
	public interface IDesignerCamera
	{
		Camera Camera { get; }

		Transform CameraTarget { get; }

		float CurrentZoom { get; }

		float FieldOfView { get; set; }

		Transform Transform { get; }

		void FocusOnPart(IPartScript partScript);

		void Move(Vector2 direction);

		void MoveUpDown(float distance);

		void Rotate(Vector2 rotation);

		Ray ScreenPointToRay(Vector2 screenCoordinates);

		void SetTargetPosition(Vector3 position, float duration = 0.5f);

		void SetTargetRotation(Vector2 rotation, float duration = 0.5f);

		void SetTargetZoom(float zoom, float duration = 0.5f);

		void SetViewDirection(DesignerCameraViewDirection viewDirection, float duration = 0.5f);

		void Zoom(float zoomPercentage);
	}
}
