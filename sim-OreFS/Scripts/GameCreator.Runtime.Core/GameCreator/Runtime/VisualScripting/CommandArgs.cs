using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	public readonly struct CommandArgs
	{
		public PropertyName Command { get; }

		public GameObject Target { get; }

		public CommandArgs(PropertyName command)
		{
			Command = command;
			Target = null;
		}

		public CommandArgs(PropertyName command, GameObject target)
			: this(command)
		{
			Target = target;
		}
	}
}
