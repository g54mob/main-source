using UnityEngine;

namespace JBooth.MicroSplat
{
	public class StreamCollider : MonoBehaviour
	{
		public enum ColliderType
		{
			Water = 0,
			Lava = 1,
			Both = 2
		}

		private StreamManager streamMgr;

		public ColliderType colliderType = ColliderType.Both;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(base.transform.position, base.transform.lossyScale.x);
		}

		private void OnEnable()
		{
			RaycastHit[] array = Physics.RaycastAll(new Ray(base.transform.position + Vector3.up * 50f, Vector3.down));
			for (int i = 0; i < array.Length; i++)
			{
				StreamManager component = array[i].collider.GetComponent<StreamManager>();
				if (component == null && array[i].collider.transform.parent != null)
				{
					component = array[i].collider.transform.parent.GetComponent<StreamManager>();
				}
				if (component != null)
				{
					streamMgr = component;
					component.Register(this);
					break;
				}
			}
		}

		private void OnDisable()
		{
			if (streamMgr != null)
			{
				streamMgr.Unregister(this);
				streamMgr = null;
			}
		}
	}
}
