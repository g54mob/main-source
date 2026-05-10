using UnityEngine;

namespace TinyGiantStudio.Text
{
	public class DebugLogger
	{
		private readonly Modular3DText text;

		public DebugLogger(Modular3DText myText)
		{
		}

		private bool LoggingTurnedOn()
		{
			return false;
		}

		public void LogToDeleteCharacters(int toDeleteCount)
		{
		}

		public void LogDeletedCharacters(string name)
		{
		}

		public void LogTextUpdate(string oldText, string newText)
		{
		}

		public void LogFontUpdate(Font oldFont, Font newFont)
		{
		}

		public void LogMaterialUpdate(Material oldFont, Material newFont)
		{
		}

		public void LogSingleMeshStatus(bool usingSingleMesh)
		{
		}
	}
}
