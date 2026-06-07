using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	[ExecuteInEditMode]
	public class SyncedIntersectionScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _easyRoadsIntersection;

		public Transform EasyRoadsIntersection
		{
			get
			{
				return _easyRoadsIntersection;
			}
			set
			{
				_easyRoadsIntersection = value;
			}
		}

		public void Sync()
		{
			base.gameObject.name = "Sync - " + _easyRoadsIntersection.gameObject.name;
			base.transform.SetPositionAndRotation(_easyRoadsIntersection.position, _easyRoadsIntersection.rotation);
		}

		protected virtual void Update()
		{
			if (_easyRoadsIntersection != null)
			{
				if (_easyRoadsIntersection.position != base.transform.position)
				{
					Sync();
				}
			}
			else
			{
				Debug.Log("The synced intersection no longer has a transform to track, so it has lost its purpose and removed itself.");
				Object.DestroyImmediate(base.gameObject);
			}
		}
	}
}
