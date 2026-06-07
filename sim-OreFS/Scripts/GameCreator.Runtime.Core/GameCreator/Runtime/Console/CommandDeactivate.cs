using UnityEngine;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandDeactivate : Command
	{
		public override string Name => "deactivate";

		public override string Description => "Sets a game object provided by its parameter as inactive";

		public CommandDeactivate()
			: base(new ActionGameObjectsCollection().Get)
		{
		}

		public override Output[] Run(Input input)
		{
			return RunDefault(input, Operation);
		}

		private static Output Operation(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Output.Error("Unable to find game object");
			}
			gameObject.SetActive(value: false);
			return Output.Success("Game Object '" + gameObject.name + "' = inactive");
		}
	}
}
