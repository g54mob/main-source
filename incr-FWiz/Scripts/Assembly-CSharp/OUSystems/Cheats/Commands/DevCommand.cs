namespace OUSystems.Cheats.Commands
{
	public abstract class DevCommand
	{
		public abstract string Description { get; }

		public abstract string Usage { get; }

		public abstract bool Execute(string[] args);
	}
}
