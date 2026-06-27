using System;
using Restory.Data.Licenses;
using Restory.Data.Visits;
using Restory.Gameplay.Visits;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.Licenses
{
	public sealed class VisitsFromLicensesService : IInitializable, IDisposable
	{
		private LicensesService licensesService;

		private LicencesToVisitsTriggers triggers;

		private CurrentDayVisitsQueueService visitsService;

		public VisitsFromLicensesService(LicensesService licensesService, LicencesToVisitsTriggers triggers, CurrentDayVisitsQueueService visitsService)
		{
			this.licensesService = licensesService;
			this.triggers = triggers;
			this.visitsService = visitsService;
		}

		public void Initialize()
		{
			licensesService.OnLicenseAdded += ResolveLicenseAdded;
		}

		public void Dispose()
		{
			if (licensesService.MonoShellExists())
			{
				licensesService.OnLicenseAdded -= ResolveLicenseAdded;
			}
		}

		private void ResolveLicenseAdded(LicensesService _, LicenseInfo addedLicense)
		{
			if (triggers.TryToGetNpcToVisitForAddedLicense(addedLicense, out var npcToVisit, out var delayBeforeVisit, out var delayAfterVisit))
			{
				visitsService.AddNewImmediateVisit(npcToVisit, delayBeforeVisit, "", delayAfterVisit);
			}
		}
	}
}
