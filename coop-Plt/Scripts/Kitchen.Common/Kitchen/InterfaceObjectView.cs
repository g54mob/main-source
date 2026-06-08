using UnityEngine;

namespace Kitchen
{
	public abstract class InterfaceObjectView<TV, TR> : ResponsiveObjectView<TV, TR> where TV : IViewData
	{
		protected bool HasBeenUpdated;

		protected Transform Container;

		protected sealed override void UpdateData(TV data)
		{
			if (!HasBeenUpdated)
			{
				FirstUpdate(data);
				HasBeenUpdated = true;
			}
			HandleUpdate(data);
		}

		protected abstract void HandleUpdate(TV data);

		protected virtual void FirstUpdate(TV data)
		{
			Container = AddContainer(new Vector3(0f, 0f, -3f));
		}

		protected override T Add<T>(Transform t = null)
		{
			return base.Add<T>((t == null) ? Container : t);
		}
	}
}
