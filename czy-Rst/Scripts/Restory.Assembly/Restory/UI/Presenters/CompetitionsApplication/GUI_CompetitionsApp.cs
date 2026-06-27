using Restory.Data.PC;
using Restory.UI.Presenters.Competitions;
using Restory.UI.Presenters.PC.Apps;
using UnityEngine;

namespace Restory.UI.Presenters.CompetitionsApplication
{
	public sealed class GUI_CompetitionsApp : GUI_PcAppBase
	{
		[SerializeField]
		private GUI_CompetitionsDevicesProcurementPage procurementPage;

		protected override void LaunchProcess(PcAppInfo appInfo)
		{
			base.LaunchProcess(appInfo);
			procurementPage.Show();
		}

		protected override void StopProcess()
		{
			procurementPage.Hide();
			base.StopProcess();
		}
	}
}
