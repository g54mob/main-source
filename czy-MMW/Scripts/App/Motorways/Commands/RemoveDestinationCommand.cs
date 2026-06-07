using Factory;
using Motorways.Models;
using Server;

namespace Motorways.Commands
{
	public class RemoveDestinationCommand : Command
	{
		private DestinationModel _model;

		public override void Execute(ISimulation simulation)
		{
			_model.Remove();
		}

		public override void Reset()
		{
			base.Reset();
			_model = null;
		}

		public static RemoveDestinationCommand Create(IScope scope, DestinationModel model)
		{
			RemoveDestinationCommand removeDestinationCommand = scope.Get<RemoveDestinationCommand>();
			removeDestinationCommand._model = model;
			return removeDestinationCommand;
		}
	}
}
