using UnityEngine.Events;

namespace ManagementScripts
{
	public struct EscapableAction : IEscapable
	{
		private UnityAction action;

		public bool canBeEscapedFlag;

		public EscapableAction(UnityAction onEscape)
		{
			action = onEscape;
			canBeEscapedFlag = true;
		}

		public void Escape()
		{
			action();
		}

		public bool CanBeEscaped()
		{
			return canBeEscapedFlag;
		}
	}
}
