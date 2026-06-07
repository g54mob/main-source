using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandTime : Command
	{
		private const int TIME_LAYER = 99;

		public override string Name => "time";

		public override string Description => "Changes the time of the game";

		public CommandTime()
			: base(new ActionOutput[3]
			{
				new ActionOutput("pause", "Sets the time scale to zero", delegate
				{
					Singleton<TimeManager>.Instance.SetTimeScale(0f, 99);
					return Output.Success("Time Scale = 0");
				}),
				new ActionOutput("scale", "Changes the time scale", delegate(string value)
				{
					float num = Convert.ToSingle(value);
					Singleton<TimeManager>.Instance.SetTimeScale(num, 99);
					return Output.Success($"Time Scale = {num}");
				}),
				new ActionOutput("normal", "Sets the time scale to one", delegate
				{
					Singleton<TimeManager>.Instance.SetTimeScale(1f, 99);
					return Output.Success("Time Scale = 1");
				})
			})
		{
		}
	}
}
