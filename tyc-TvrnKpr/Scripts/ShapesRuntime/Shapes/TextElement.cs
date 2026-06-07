using System;
using TMPro;

namespace Shapes
{
	public class TextElement : IDisposable
	{
		private static int idCounter;

		public readonly int id;

		public TextMeshPro Tmp => null;

		public static int GetNextId()
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
