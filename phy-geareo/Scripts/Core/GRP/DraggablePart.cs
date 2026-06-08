using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class DraggablePart : WorldPointable
	{
		private float camDistance;

		private Vector3 offset;

		private Quaternion startRotation;

		private bool isDrag;

		private bool dragged;

		private Rigidbody rb;

		private List<RelTransform> others;

		private UndoSnapshot dragSnapshot;

		private SnapController snapController;

		private Vector3 targetPosition;

		private Quaternion targetRotation;

		private List<SnapContact> snapContacts;

		private Hertz presence;

		private NetGame netGame;

		public static DraggablePart current;

		public PartView myPart { get; private set; }

		public Part part => null;

		public Project project => null;

		public bool isGhost { get; private set; }

		public float lastClick { get; private set; }

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		public override void OnDown(WorldPointerEvent evt)
		{
		}

		public override void OnDrag(WorldPointerEvent evt)
		{
		}

		private void PoolSnapContacts()
		{
		}

		public override void OnUp(WorldPointerEvent evt)
		{
		}

		public override void OnHover(WorldPointerEvent evt)
		{
		}

		public override void OnClick(WorldPointerEvent evt)
		{
		}

		public void DeleteSelection()
		{
		}

		public void HandleDoubleClick()
		{
		}

		public void HandleClick()
		{
		}
	}
}
