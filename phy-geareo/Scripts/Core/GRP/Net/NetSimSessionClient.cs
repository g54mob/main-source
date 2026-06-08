using System.Collections.Generic;

namespace GRP.Net
{
	public class NetSimSessionClient : NetModuleClient
	{
		public ProjectSim projectSim;

		public SimSessionStart startMsg;

		public Dictionary<int, bool> keyboard;

		public NetSessionClient<SimSessionStart, SimSessionJoin, SimSessionLeave> session;

		public bool joined => false;

		public override void Setup()
		{
		}

		public void StartSession(ProjectSim projectSim)
		{
		}

		public void JoinSession(ProjectSim projectSim)
		{
		}

		public void LeaveSession()
		{
		}

		public void UpdateState(ProjectSimState state)
		{
		}

		public void SendKeyboardChange(SimSessionKeyboardChange msg)
		{
		}

		public override void Build()
		{
		}
	}
}
