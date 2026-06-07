using CTS.Core;

namespace CTS
{
	public abstract class UI_MachineMgr_CategoryFeature : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		protected UsableFurnituresCategory _category;

		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		protected SyncManager _syncManager;

		public virtual void SetDefaultValues()
		{
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_syncManager.AddListener(_category.CategoryData.SyncKey, OnSyncedValuesChanged);
		}

		protected virtual void OnDestroy()
		{
			_syncManager.RemoveListener(_category.CategoryData.SyncKey, OnSyncedValuesChanged);
		}

		private void OnSyncedValuesChanged()
		{
			Repaint();
		}

		public void Repaint()
		{
			OnRepaint();
		}

		protected abstract void OnRepaint();
	}
}
