using CTS.BBT;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_SyncButton : UI_MachineMgr_MachinePanelFeature
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		public override bool CanBeDisplayedForFurniture(FurnitureInteractor furniture)
		{
			return base._furniture.Syncing;
		}

		protected override void OnFurnitureSet(FurnitureInteractor furniture)
		{
			base._furniture.Syncing.SyncingChanged += OnRepaint;
		}

		protected override void OnFurnitureUnset(FurnitureInteractor furniture)
		{
			base._furniture.Syncing.SyncingChanged -= OnRepaint;
		}

		protected override void OnRepaint()
		{
			if ((object)base._furniture.Syncing != null)
			{
				_toggle.isOn = base._furniture.Syncing.IsSynced;
			}
		}
	}
}
