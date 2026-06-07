using Factory;

namespace Server
{
	public class SetPausedCommand : Command
	{
		private bool _pause;

		public override void Execute(ISimulation simulation)
		{
			Command.Log.Info("Executing SetPauseCommand to {0}.", _pause ? "pause" : "resume");
			simulation.IsPaused = _pause;
		}

		public override void Reset()
		{
			base.Reset();
			_pause = false;
		}

		public static SetPausedCommand Create(IScope scope, bool pause)
		{
			SetPausedCommand setPausedCommand = scope.Get<SetPausedCommand>();
			setPausedCommand._pause = pause;
			return setPausedCommand;
		}
	}
}
