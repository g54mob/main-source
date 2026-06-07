using UnityEngine;

namespace TerrainComposer2
{
	[ExecuteInEditMode]
	public class TC_FollowTarget : MonoBehaviour
	{
		public Transform target;

		public Vector3 offset;

		public bool refresh;

		public bool followPosition = true;

		public bool followRotation = true;

		public bool followScale = true;

		public bool followScaleY = true;

		private Transform t;

		private TC_ItemBehaviour targetItem;

		private TC_ItemBehaviour item;

		private void Start()
		{
			t = base.transform;
			if (target != null)
			{
				targetItem = target.GetComponent<TC_ItemBehaviour>();
			}
			item = GetComponent<TC_ItemBehaviour>();
		}

		private void Update()
		{
			if (!(target == null))
			{
				if (followPosition)
				{
					t.position = target.position + offset;
				}
				if (followRotation)
				{
					t.rotation = target.rotation;
				}
				if (followScale)
				{
					float y = ((!followScaleY) ? target.lossyScale.y : t.localScale.y);
					t.localScale = new Vector3(target.lossyScale.x, y, target.lossyScale.z);
				}
				if (targetItem != null && item != null && item.visible != targetItem.visible)
				{
					item.visible = targetItem.visible;
					TC.RefreshOutputReferences(item.outputId);
				}
				if (refresh)
				{
					TC.repaintNodeWindow = true;
					TC.AutoGenerate();
				}
			}
		}
	}
}
