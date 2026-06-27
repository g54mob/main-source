using System;
using Restory.Data.Email;
using Restory.Gameplay.Visits;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class EmailButtonCreateNpcVisitHandler : EmailButtonHandlerBase<EmailButtonCreateNpcVisitSettings>
	{
		private readonly CurrentDayVisitsQueueService visitsService;

		public EmailButtonCreateNpcVisitHandler(CurrentDayVisitsQueueService visitsService)
		{
			this.visitsService = visitsService;
		}

		protected override void HandleButtonPress(EmailButtonCreateNpcVisitSettings buttonSettings)
		{
			visitsService.AddNewImmediateVisit(buttonSettings.NpcToVisit, TimeSpan.FromMinutes(buttonSettings.DelayBeforeVisitInMinutes), buttonSettings.NpcTextureID, (buttonSettings.DelayAfterVisitInMinutes > 0) ? new TimeSpan?(TimeSpan.FromMinutes(buttonSettings.DelayAfterVisitInMinutes)) : ((TimeSpan?)null));
		}
	}
}
