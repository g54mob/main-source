using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandVisualScripting : Command
	{
		public override string Name => "run";

		public override string Description => "Executes a Trigger, Conditions or Actions";

		public CommandVisualScripting()
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
			Args args = new Args(gameObject);
			Actions component = gameObject.GetComponent<Actions>();
			if (component != null)
			{
				component.Run(args);
				return Output.Success("Run Actions on '" + gameObject.name + "'");
			}
			Trigger component2 = gameObject.GetComponent<Trigger>();
			if (component2 != null)
			{
				component2.Execute(args);
				return Output.Success("Run Trigger on '" + gameObject.name + "'");
			}
			Conditions component3 = gameObject.GetComponent<Conditions>();
			if (component3 != null)
			{
				component3.Run(args);
				return Output.Success("Run Conditions on '" + gameObject.name + "'");
			}
			return Output.Error("Could not find anything to run on '" + gameObject.name + "'");
		}
	}
}
