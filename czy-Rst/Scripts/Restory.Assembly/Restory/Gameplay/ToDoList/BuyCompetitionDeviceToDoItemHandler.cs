using Restory.Data.ToDoList;
using Restory.Gameplay.Competitions;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class BuyCompetitionDeviceToDoItemHandler : ToDoItemHandler
	{
		private CompetitionGameMode competitionGameMode;

		private BuyCompetitionDeviceToDoItem buyCompetitionDeviceToDoItem;

		[Inject]
		private void Construct(CompetitionGameMode competitionGameMode)
		{
			this.competitionGameMode = competitionGameMode;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			base.Initialize(item, toDoListService);
			if (!(item is BuyCompetitionDeviceToDoItem buyCompetitionDeviceToDoItem))
			{
				Debug.LogError("[BuyCompetitionDeviceToDoItemHandler] tried to initialize, but the supplied item is not [BuyCompetitionDeviceToDoItem], but [" + item.GetType().Name + "] instead!");
				return;
			}
			this.buyCompetitionDeviceToDoItem = buyCompetitionDeviceToDoItem;
			competitionGameMode.OnCompetitionPrepared += ResolveOnCompetitionPrepared;
		}

		public override void Dispose()
		{
			if (competitionGameMode.MonoShellExists())
			{
				competitionGameMode.OnCompetitionPrepared -= ResolveOnCompetitionPrepared;
			}
			buyCompetitionDeviceToDoItem = null;
			base.Dispose();
		}

		public override void ForceCheckCompletionConditions()
		{
			base.ForceCheckCompletionConditions();
			ResolveOnCompetitionPrepared();
		}

		private void ResolveOnCompetitionPrepared()
		{
			if ((bool)buyCompetitionDeviceToDoItem && (bool)competitionGameMode && (bool)competitionGameMode.CurrentDeviceInCompetition && (bool)competitionGameMode.CurrentDeviceInCompetition.Device && (buyCompetitionDeviceToDoItem.Any || buyCompetitionDeviceToDoItem.DeviceInfo == competitionGameMode.CurrentDeviceInCompetition.Device.Info))
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
