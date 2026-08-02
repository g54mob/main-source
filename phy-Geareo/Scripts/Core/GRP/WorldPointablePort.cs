using System;
using UnityEngine;

namespace GRP
{
	public class WorldPointablePort : MonoBehaviour
	{
		public OrbitCameraController cameraController;

		public Action<WorldPointerEvent> onDown;

		public Action<WorldPointerEvent> onUp;

		public Action<WorldPointerEvent> onDrag;

		public Action<WorldPointerEvent> onClick;

		public Action<WorldPointerEvent> onHover;

		public Action<WorldPointerEvent> onHoverEnter;

		public Action<WorldPointerEvent> onHoverExit;

		public WorldPointableManager manager => null;

		public bool isPointerOverUI => false;

		public bool isPointerInside => false;

		public bool isDown => false;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
