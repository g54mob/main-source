using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectSelectionSnapshot
	{
		private List<GameObject> _snapshotObjects = new List<GameObject>();

		private ObjectSelectionGizmosSnapshot _gizmosSnapshot = new ObjectSelectionGizmosSnapshot();

		public int NumObjects => _snapshotObjects.Count;

		public List<GameObject> SnapshotObjects => new List<GameObject>(_snapshotObjects);

		public ObjectSelectionGizmosSnapshot GizmosSnapshot => new ObjectSelectionGizmosSnapshot(_gizmosSnapshot);

		public ObjectSelectionSnapshot()
		{
		}

		public ObjectSelectionSnapshot(ObjectSelectionSnapshot copy)
		{
			_snapshotObjects = copy.SnapshotObjects;
			_gizmosSnapshot = copy.GizmosSnapshot;
		}

		public void Snapshot()
		{
			_snapshotObjects = new List<GameObject>(MonoSingleton<RTObjectSelection>.Get.SelectedObjects);
			_gizmosSnapshot.Snapshot();
		}
	}
}
