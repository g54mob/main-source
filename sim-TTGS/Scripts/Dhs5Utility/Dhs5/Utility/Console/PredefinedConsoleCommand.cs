using System.Collections.Generic;

namespace Dhs5.Utility.Console
{
	public abstract class PredefinedConsoleCommand : ConsoleCommandObject
	{
		public ValidCommandCallback Callback => OnCommandValidated;

		private void OnEnable()
		{
			CreateCommand();
		}

		private void CreateCommand()
		{
			List<ConsoleCommandPiece> list = OnCreateCommand();
			if (list.IsValid())
			{
				SetCommandPieces(list);
			}
		}

		protected abstract List<ConsoleCommandPiece> OnCreateCommand();

		protected abstract void OnCommandValidated(ValidCommand validCommand);
	}
}
