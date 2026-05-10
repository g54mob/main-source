using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AgentInfoExitCondition : CanvasSimpleExitCondition
	{
		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private RoomAssignationsTool _assignationsTool;

		public override bool CanBeExitedWithEscape()
		{
			if (_assignationsTool.CurrentMode != RoomAssignationsTool.EMode.None)
			{
				_assignationsTool.SetCurrentMode(RoomAssignationsTool.EMode.None);
				return false;
			}
			return base.CanBeExitedWithEscape();
		}
	}
}
