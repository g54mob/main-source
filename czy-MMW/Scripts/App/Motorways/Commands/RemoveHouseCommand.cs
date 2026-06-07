using Factory;
using Motorways.Models;
using Server;

namespace Motorways.Commands
{
	public class RemoveHouseCommand : Command
	{
		private HouseModel _model;

		public override void Execute(ISimulation simulation)
		{
			_model.Remove();
		}

		public override void Reset()
		{
			base.Reset();
			_model = null;
		}

		public static RemoveHouseCommand Create(IScope scope, HouseModel model)
		{
			RemoveHouseCommand removeHouseCommand = scope.Get<RemoveHouseCommand>();
			removeHouseCommand._model = model;
			return removeHouseCommand;
		}
	}
}
