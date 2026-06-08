using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace GRP.Net
{
	public class NetProjectSessionClient : NetModuleClient
	{
		public ProjectContainer projectContainer;

		public NetIdGeneratorClient idGenerator;

		public State<Dictionary<ulong, ulong[]>> allSelections;

		public NetSessionClient<ProjectSessionStart, ProjectSessionJoin, ProjectSessionLeave> session;

		public bool joined => false;

		public override void Setup()
		{
		}

		public bool IsSelected(ulong playerId, ulong id)
		{
			return false;
		}

		public void StartSession(ProjectContainer projectContainer)
		{
		}

		public void JoinSession(ProjectContainer projectContainer)
		{
		}

		public void LeaveSession()
		{
		}

		public void LoadProject()
		{
		}

		public void UpdateSelection<T>(Selector<T> selector) where T : class, ISelectable
		{
		}

		public void UpdateSelection(ulong[] ids)
		{
		}

		public void ProjectChangeDestroy(string name, IEnumerable<EntityData> parts)
		{
		}

		public void ProjectChangeCreate(string name, IEnumerable<EntityData> parts, int[] orders)
		{
		}

		public void ProjectChangeEdit(string name, IEnumerable<EntityData> parts)
		{
		}

		public void ProjectChange(string name, ProjectChangeType type, Action<ProjectSessionChangeBuilder> builderAction)
		{
		}

		public override void Build()
		{
		}
	}
}
