using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public abstract class PopupManager : GenericSystemBase
	{
		public abstract PopupType ManagedType { get; }

		public abstract bool UpdatePopup(Entity popup);

		public abstract Entity CreateNewPopup(Entity request);

		protected override void OnUpdate()
		{
		}

		protected bool CopyData<T>(Entity request, Entity popup) where T : struct, IManagedPopupData
		{
			if (!Require<T>(request, out T comp))
			{
				return false;
			}
			base.EntityManager.AddComponentData(popup, comp);
			return true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
