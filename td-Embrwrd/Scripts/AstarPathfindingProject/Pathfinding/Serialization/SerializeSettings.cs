using System;

namespace Pathfinding.Serialization
{
	public class SerializeSettings
	{
		public bool nodes;

		[Obsolete("There is no support for pretty printing the json anymore")]
		public bool prettyPrint;

		public bool editorSettings;

		public static SerializeSettings Settings => null;
	}
}
