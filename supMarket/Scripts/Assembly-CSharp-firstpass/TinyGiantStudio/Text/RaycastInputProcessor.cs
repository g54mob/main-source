using UnityEngine;

namespace TinyGiantStudio.Text
{
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Input System/Raycast Input Processor", 20052)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/input/mouse-touch/raycast-input-processor")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RaycastSelector))]
	public class RaycastInputProcessor : MonoBehaviour
	{
		[Tooltip("If not assigned, it will automatically get Camera.main on Start")]
		public Camera myCamera;

		public Transform pointerOnUI;

		public Transform currentTarget;

		private bool dragging;

		private RaycastSelector raycastSelector;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void SelectPress()
		{
		}

		private void Dragging()
		{
		}

		private bool PressedButton()
		{
			return false;
		}

		private bool MouseClicked()
		{
			return false;
		}

		private bool Tapped()
		{
			return false;
		}

		private Transform RaycastCheck()
		{
			return null;
		}

		private void DetectDragEnd()
		{
		}

		private bool MouseButtonReleased()
		{
			return false;
		}
	}
}
