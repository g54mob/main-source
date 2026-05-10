using UnityEngine;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Input System/Raycast Selector", 20052)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/input/mouse-touch/raycast-selector")]
	public class RaycastSelector : MonoBehaviour
	{
		[SerializeField]
		private LayerMask UILayer;

		[SerializeField]
		private float maxRayDistance;

		[Tooltip("True = How normal UI works. It toggles if clicking a inputfield enables it and clicking somewhere else disables it")]
		public bool onlyOneTargetFocusedAtOnce;

		[Tooltip("Unhovering mouse from a Btn will unselect it")]
		public bool unselectBtnOnUnhover;

		private Transform clickedTarget;

		public Transform RaycastCheck(Ray ray)
		{
			return null;
		}

		public void PressTarget(Transform hit)
		{
		}

		private void PressInputString(Transform hit)
		{
		}

		private void PressSlider(Transform hit)
		{
		}

		private void PressButton(Transform hit)
		{
		}

		private void UnFocusPreviouslySelectedItems(Transform hit)
		{
		}

		public void SelectTarget(Transform target)
		{
		}

		private void SelectSlider(Transform hit)
		{
		}

		private void SelectButton(Transform hit)
		{
		}

		public void UnselectTarget(Transform target)
		{
		}

		private void UnselectSlider(Transform hit)
		{
		}

		private void UnselectButton(Transform hit)
		{
		}

		public void Dragging(Transform hit, Vector3 cursorPosition)
		{
		}

		private void DragSlider(Transform hit, Vector3 cursorPosition)
		{
		}

		private void DragButton(Transform hit)
		{
		}

		public void DragEnded(Transform hit, Transform currentTarget)
		{
		}

		private void DragEndOnSlider(Transform hit)
		{
		}

		private void DragEndOnButton(Transform hit, Transform currentTarget)
		{
		}

		private bool InteractWithButton(Button button)
		{
			return false;
		}

		private bool InteractWithSlider(SliderHandle sliderHandle)
		{
			return false;
		}

		private bool InteractWithInputString(InputField inputString)
		{
			return false;
		}
	}
}
