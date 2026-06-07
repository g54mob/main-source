using UnityEngine;

namespace JBooth.MicroSplat
{
	public class StreamEmitter : MonoBehaviour
	{
		public enum EmitterType
		{
			Water = 0,
			Lava = 1
		}

		public EmitterType emitterType;

		[Range(0f, 1f)]
		public float strength = 1f;

		private StreamManager streamMgr;

		private void OnDrawGizmos()
		{
			Gizmos.color = ((emitterType == EmitterType.Water) ? Color.blue : Color.red);
			Gizmos.DrawWireSphere(base.transform.position, base.transform.lossyScale.x);
		}

		private void OnEnable()
		{
			RaycastHit[] array = Physics.RaycastAll(new Ray(base.transform.position + Vector3.up * 10f, Vector3.down));
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
