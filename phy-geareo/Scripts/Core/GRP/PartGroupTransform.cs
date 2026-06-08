using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class PartGroupTransform
	{
		public Part target;

		public List<RelTransform> others;

		public float snapStep;

		public bool move;

		public bool rotate;

		public float dragValue;

		public bool isDragging;

		public Vector3 startPosition;

		private Quaternion startRotation;

		public UndoSnapshot snapshot;

		public NetGame netGame;

		public Hertz hertz;

		public void BeginDrag(Project project, bool presence = false)
		{
		}

		public void Drag(Project project, Vector3 dir, float value, bool presence = false, bool guide = false)
		{
		}

		public void EndDrag(Project project)
		{
		}

		public PartTransformData[] SerializeTargets()
		{
			return null;
		}

		public static PartTransformData[] SerializeTargets(Part target, List<RelTransform> others)
		{
			return null;
		}
	}
}
