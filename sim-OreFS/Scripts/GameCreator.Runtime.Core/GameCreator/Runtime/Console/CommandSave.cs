using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandSave : Command
	{
		public override string Name => "store";

		public override string Description => "Manages the storage options";

		public CommandSave()
			: base(new ActionOutput[4]
			{
				new ActionOutput("save", "Saves the game at slot value", delegate(string value)
				{
					int num = Convert.ToInt32(value);
					Singleton<SaveLoadManager>.Instance.Save(num);
					return Output.Success($"Saving: {num}");
				}),
				new ActionOutput("load", "Loads a game from from the slot value", delegate(string value)
				{
					int num = Convert.ToInt32(value);
					Singleton<SaveLoadManager>.Instance.Load(num);
					return Output.Success($"Loading: {num}");
				}),
				new ActionOutput("exists", "Returns true the slot value has saved game", delegate(string value)
				{
					int num = Convert.ToInt32(value);
					bool flag = Singleton<SaveLoadManager>.Instance.HasSaveAt(num);
					return Output.Success($"Has Save at {num} = {flag}");
				}),
				new ActionOutput("restart", "Loads a scene by index and resets any progress", delegate(string value)
				{
					if (!int.TryParse(value, out var result))
					{
						return Output.Error("Unknown scene index for " + value);
					}
					Singleton<SaveLoadManager>.Instance.Restart(result);
					return Output.Success($"Restarting on scene index: {result}");
				})
			})
		{
		}
	}
}
