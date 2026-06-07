using UnityEngine;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandActivate : Command
	{
		public override string Name => "activate";

		public override string Description => "Sets a game object provided by its parameter as active";

		public CommandActivate()
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
			gameObject.SetActive(value: true);
			return Output.Success("Game Object '" + gameObject.name + "' = active");
		}
	}
}
