using System;
using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ApplyStateChangeEffectsGroup))]
	public class GroupDeriveStatuses : GameSystemBase
	{
		private Dictionary<Type, EntityQuery> TypeQueries;

		private EntityQuery QueryFor<T>() where T : IComponentData
		{
			if (TypeQueries == null)
			{
				TypeQueries = new Dictionary<Type, EntityQuery>();
			}
			if (!TypeQueries.ContainsKey(typeof(T)))
			{
				TypeQueries[typeof(T)] = GetEntityQuery(typeof(T));
			}
			return TypeQueries[typeof(T)];
		}

		private void ClearStatus<T>() where T : IComponentData
		{
			base.EntityManager.RemoveComponent<T>(QueryFor<T>());
		}

		private void AddStatus<T1, T2>() where T1 : IGroupStatus where T2 : IComponentData
		{
			base.EntityManager.AddComponent<T2>(QueryFor<T1>());
		}

		protected override void OnUpdate()
		{
			ClearStatus<CGroupPhaseQueue>();
			ClearStatus<CGroupPhaseOrder>();
			ClearStatus<CGroupPhaseFood>();
			ClearStatus<CAtTable>();
			AddStatus<CGroupArrive, CGroupPhaseQueue>();
			AddStatus<CGroupQueue, CGroupPhaseQueue>();
			AddStatus<CGroupWait, CGroupPhaseQueue>();
			AddStatus<CGroupWaitingForTable, CGroupPhaseQueue>();
			AddStatus<CGroupAtWaitingTable, CGroupPhaseQueue>();
			AddStatus<CGroupChoosingOrder, CGroupPhaseOrder>();
			AddStatus<CGroupReadyToOrder, CGroupPhaseOrder>();
			AddStatus<CGroupAwaitingExtra, CGroupPhaseOrder>();
			AddStatus<CGroupAwaitingOrder, CGroupPhaseFood>();
			AddStatus<CGroupEating, CGroupPhaseFood>();
			AddStatus<CGroupChoosingOrder, CAtTable>();
			AddStatus<CGroupReadyToOrder, CAtTable>();
			AddStatus<CGroupAwaitingOrder, CAtTable>();
			AddStatus<CGroupAtWaitingTable, CAtTable>();
			AddStatus<CGroupAwaitingExtra, CAtTable>();
			AddStatus<CGroupEating, CAtTable>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
