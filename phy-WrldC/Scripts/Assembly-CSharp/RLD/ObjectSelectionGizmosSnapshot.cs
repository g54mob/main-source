using UnityEngine;

namespace RLD
{
	public class ObjectSelectionGizmosSnapshot
	{
		private GameObject _pivotObject;

		public GameObject PivotObject => _pivotObject;

		public ObjectSelectionGizmosSnapshot()
		{
		}

		public ObjectSelectionGizmosSnapshot(ObjectSelectionGizmosSnapshot copy)
		{
			_pivotObject = copy.PivotObject;
		}

		public void Snapshot()
		{
			if (MonoSingleton<RTObjectSelectionGizmos>.Get != null)
			{
				_pivotObject = MonoSingleton<RTObjectSelectionGizmos>.Get.PivotObject;
			}
		}
	}
}
