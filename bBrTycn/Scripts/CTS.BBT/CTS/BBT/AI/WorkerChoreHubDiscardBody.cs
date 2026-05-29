namespace CTS.BBT.AI
{
	public class WorkerChoreHubDiscardBody : WorkerChoreHub
	{
		private ActionHubDisposeBody _disposalAction;

		public WorkerChoreHubDiscardBody(ActionHubDisposeBody action)
			: base(ChoreCategory.BodyCleaning, action)
		{
			_disposalAction = action;
			_disposalAction.UseAssignation = true;
		}

		public override RoomObject GetChoreTarget()
		{
			StationMorgue stationMorgue = _disposalAction.BodyData.CurrentMorgue();
			if ((object)stationMorgue != null)
			{
				return stationMorgue.RoomObject;
			}
			if ((bool)_disposalAction.BodyBag)
			{
				return _disposalAction.BodyBag.RoomObject;
			}
			return _disposalAction.Body.RoomObject;
		}
	}
}
