namespace Pathfinding.Serialization
{
	public class SerializeSettings
	{
		public bool nodes = true;

		public bool editorSettings;

		public static SerializeSettings Settings => new SerializeSettings
		{
			nodes = false
		};
	}
}
