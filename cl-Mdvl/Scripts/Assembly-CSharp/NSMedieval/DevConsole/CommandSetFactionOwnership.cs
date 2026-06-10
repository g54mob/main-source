using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandSetFactionOwnership : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandSetFactionOwnership()
		{
			Command = "switchFactionOwnership";
			Description = "Toggles building and pile ownership between player and enemy.";
			Help = "Click on buildings or piles to change faction ownership.";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null))
			{
				WorldObject asWorldObject = obj.GetAsWorldObject();
				if (asWorldObject != null && !asWorldObject.HasDisposed && (asWorldObject is BaseBuildingInstance || asWorldObject is ResourcePileInstance))
				{
					asWorldObject.SetFaction((asWorldObject.FactionOwnership != FactionOwnership.Enemy) ? FactionOwnership.Enemy : FactionOwnership.Player);
				}
			}
		}
	}
}
