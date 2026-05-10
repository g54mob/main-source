using UnityEngine;

namespace CW.Common
{
	public abstract class CwChild : MonoBehaviour
	{
		public interface IHasChildren
		{
			bool HasChild(CwChild child);
		}

		[ContextMenu("Destroy GameObject If Invalid All")]
		public void DestroyGameObjectIfInvalidAll()
		{
		}

		[ContextMenu("Destroy GameObject If Invalid")]
		public void DestroyGameObjectIfInvalid()
		{
		}

		protected abstract IHasChildren GetParent();

		protected virtual void Start()
		{
		}
	}
}
