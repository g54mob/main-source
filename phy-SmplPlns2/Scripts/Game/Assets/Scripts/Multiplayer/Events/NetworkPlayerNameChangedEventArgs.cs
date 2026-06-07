namespace Assets.Scripts.Multiplayer.Events
{
	public class NetworkPlayerNameChangedEventArgs : NetworkPlayerEventArgs
	{
		public string NewName { get; }

		public string PreviousName { get; }

		public NetworkPlayerNameChangedEventArgs(NetworkPlayerScript player, string previousName, string newName)
			: base(player)
		{
			PreviousName = previousName;
			NewName = newName;
		}
	}
}
