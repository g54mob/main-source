using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class WorldDragRect : MonoBehaviour
	{
		public class Pointer
		{
			public WorldPointerEvent evt;

			public Vector2 delta;

			public Vector2 lastPosition;

			public Vector2 dragPosition;

			public void Update()
			{
			}
		}

		public WorldPointablePort port;

		public Vector2 delta;

		public float zoomDelta;

		public Vector2 deltaNormalized;

		public float zoomDeltaNormalized;

		public Pointer pointer;

		private bool beginDrag;

		private List<RaycastResult> raycastResults;

		public bool isDown => false;

		public bool dragCtrl { get; private set; }

		private void Start()
		{
		}

		private bool IsPointerOverMe()
		{
			return false;
		}

		private void Update()
		{
		}

		public Vector2 Normalize(Vector2 value)
		{
			return default(Vector2);
		}

		public float Normalize(float value)
		{
			return 0f;
		}

		private void OnDisable()
		{
		}
	}
}
