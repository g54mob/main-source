using UnityEngine;

namespace Rhizomatic.Reactive
{
	public abstract class ViewLoader : MonoBehaviour
	{
		protected abstract bool DoCanOpen(IViewable viewable);

		protected abstract View DoOpen(IViewable viewable);

		protected abstract void DoClose(View view);

		public View Open(IViewable viewable)
		{
			return null;
		}

		public void Close(View view)
		{
		}

		public bool CanOpen(IViewable viewable)
		{
			return false;
		}
	}
}
