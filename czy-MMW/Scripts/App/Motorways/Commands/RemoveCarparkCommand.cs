using Factory;
using Motorways.Models;
using Server;

namespace Motorways.Commands
{
	public class RemoveCarparkCommand : Command
	{
		private CarparkModel _model;

		public override void Execute(ISimulation simulation)
		{
			_model.Remove();
		}

		public override void Reset()
		{
			base.Reset();
			_model = null;
		}

		public static RemoveCarparkCommand Create(IScope scope, CarparkModel model)
		{
			RemoveCarparkCommand removeCarparkCommand = scope.Get<RemoveCarparkCommand>();
			removeCarparkCommand._model = model;
			return removeCarparkCommand;
		}
	}
}
