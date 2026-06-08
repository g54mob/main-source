using System;
using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Steam
{
	public class WorkshopItemsLoaderViewable : Viewable
	{
		[ListLoaderCrew]
		public StateSelector<List<Viewable>> items;

		[GameObjectCrew]
		public StateSelector<bool> isBusy;

		[GameObjectCrew]
		public StateSelector<bool> notBusy;

		[GameObjectCrew]
		public StateSelector<bool> isError;

		[GameObjectCrew]
		public StateSelector<bool> notError;

		[TextCrew]
		public StateSelector<string> page;

		[SelectableCrew]
		public StateSelector<bool> nextPage;

		[SelectableCrew]
		public StateSelector<bool> previousPage;

		[SelectableCrew]
		public StateSelector<bool> refresh;

		public WorkshopItemsLoader loader;

		public WorkshopItemsLoaderViewable(WorkshopItemsLoader loader, Func<WorkshopItem, Viewable> itemBuilder)
		{
		}

		[CrewMethod]
		public void Refresh()
		{
		}

		[CrewMethod]
		public void NextPage()
		{
		}

		[CrewMethod]
		public void PreviousPage()
		{
		}
	}
}
