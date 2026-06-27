using System;
using System.Collections.Generic;

namespace Restory.Gameplay.Common
{
	public class ActiveStateSwitcher
	{
		public enum WorkMode
		{
			Off = 0,
			ActiveByDefaultAndRequestersMakeItInactive = 10,
			InactiveByDefaultAndRequestersMakeItActive = 20
		}

		private bool shouldSystemBeActive;

		private readonly HashSet<IActiveStateSwitchRequester> requesters = new HashSet<IActiveStateSwitchRequester>();

		private readonly WorkMode workingMode;

		public IReadOnlyCollection<IActiveStateSwitchRequester> Requesters => requesters;

		public bool ShouldSystemBeActive
		{
			get
			{
				return shouldSystemBeActive;
			}
			private set
			{
				if (value != shouldSystemBeActive)
				{
					shouldSystemBeActive = value;
					this.OnActiveStatusSwitchRequested?.Invoke();
				}
			}
		}

		public event Action OnActiveStatusSwitchRequested;

		public ActiveStateSwitcher(WorkMode workingMode)
		{
			this.workingMode = workingMode;
			switch (workingMode)
			{
			case WorkMode.Off:
				shouldSystemBeActive = false;
				break;
			case WorkMode.ActiveByDefaultAndRequestersMakeItInactive:
				shouldSystemBeActive = true;
				break;
			case WorkMode.InactiveByDefaultAndRequestersMakeItActive:
				shouldSystemBeActive = false;
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void AddRequester(IActiveStateSwitchRequester requester)
		{
			requesters.Add(requester);
			RefreshStatus();
		}

		public void RemoveRequester(IActiveStateSwitchRequester requester)
		{
			requesters.Remove(requester);
			RefreshStatus();
		}

		public void Clear()
		{
			requesters.Clear();
		}

		private void RefreshStatus()
		{
			switch (workingMode)
			{
			case WorkMode.ActiveByDefaultAndRequestersMakeItInactive:
				ShouldSystemBeActive = requesters.Count == 0;
				break;
			case WorkMode.InactiveByDefaultAndRequestersMakeItActive:
				ShouldSystemBeActive = requesters.Count > 0;
				break;
			default:
				throw new NotImplementedException();
			case WorkMode.Off:
				break;
			}
		}
	}
}
