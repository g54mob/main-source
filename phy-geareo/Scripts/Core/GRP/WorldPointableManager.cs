using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class WorldPointableManager : MonoBehaviour
	{
		private bool dragged;

		private WorldPointerEvent downEvt;

		private float downTime;

		public WorldPointerScan scan;

		public WorldPointerScan[] scans;

		private WorldPointerScan hoverHit;

		private bool isGetDown;

		private bool isGetUp;

		private bool isUpdate;

		private WorldPointerType getDownType;

		private WorldPointerType getUpType;

		private Vector3 mousePosition;

		private RaycastHit[] hits;

		private List<RaycastResult> uiHits;

		private List<WorldPointerScan> worldScans;

		public List<WorldPointablePort> ports { get; }

		public bool isDown { get; private set; }

		public bool isPointerOverUI { get; private set; }

		public bool isPointerInside { get; private set; }

		public List<PhysicsScene> physicsScenes { get; }

		public static WorldPointableManager instance { get; private set; }

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void HandlePointer()
		{
		}

		public bool GetDown(out WorldPointerType type)
		{
			type = default(WorldPointerType);
			return false;
		}

		public bool GetUp(out WorldPointerType type)
		{
			type = default(WorldPointerType);
			return false;
		}

		public WorldPointerEvent CreateEvent(WorldPointerScan scan)
		{
			return null;
		}

		public WorldPointerEvent CreateEvent(WorldPointerType type, WorldPointerScan scan)
		{
			return null;
		}

		public WorldPointerEvent CreateEvent(WorldPointer pointer, WorldPointerScan scan)
		{
			return null;
		}

		public void LockCamera()
		{
		}

		public WorldPointerScan ScanFirst(Vector3 position, float maxDistance = 3.4028235E+38f)
		{
			return null;
		}

		public WorldPointerScan[] Scan(Vector3 position, float maxDistance = 3.4028235E+38f)
		{
			return null;
		}

		public bool IsPointerOverUI()
		{
			return false;
		}

		public bool IsPointerInside()
		{
			return false;
		}
	}
}
