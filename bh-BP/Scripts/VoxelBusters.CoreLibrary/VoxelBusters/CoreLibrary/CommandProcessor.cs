using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

namespace VoxelBusters.CoreLibrary
{
	public class CommandProcessor
	{
		[Serializable]
		public class CommandEvent : UnityEvent<ICommand>
		{
		}

		public enum CommandExecutionOrder
		{
			None = 0,
			Sequential = 1
		}

		private List<ICommand> m_inprogressCommands;

		private List<ICommand> m_pendingCommands;

		public CommandExecutionOrder ExecutionOrder { get; private set; }

		public event Callback<ICommand> OnCompletion
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public CommandProcessor(CommandExecutionOrder order)
		{
		}

		public void AddCommand(ICommand command)
		{
		}

		public void InvalidateAll()
		{
		}

		public void Update()
		{
		}

		private void ProcessCommandInternal(ICommand command)
		{
		}

		private void ProcessInprogressCommands()
		{
		}

		private void ProcessCommandsInSequentialOrder()
		{
		}

		private void PostCommandCompleteEvent(ICommand command)
		{
		}
	}
}
