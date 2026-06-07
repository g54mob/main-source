using UnityEngine;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandDestroy : Command
	{
		public override string Name => "destroy";

		public override string Description => "Destroys a game object provided by its parameter";

		public CommandDestroy()
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
			Output result = Output.Success("Destroy Game Object '" + gameObject.name + "'");
			Object.Destroy(gameObject);
			return result;
		}
	}
}
