using UnityEngine;

namespace CW.Common
{
	public abstract class CwChild : MonoBehaviour
	{
		public interface IHasChildren
		{
			bool HasChild(CwChild child);
		}

		public void DestroyGameObjectIfInvalid()
		{
		}

		protected abstract IHasChildren GetParent();

		protected virtual void Start()
		{
		}
	}
}
