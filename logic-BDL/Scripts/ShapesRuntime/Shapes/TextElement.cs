using System;
using TMPro;

namespace Shapes
{
	public class TextElement : IDisposable
	{
		private static int idCounter;

		public readonly int id;

		public TextMeshPro Tmp => ShapesTextPool.Instance.GetElement(id);

		public static int GetNextId()
		{
			return idCounter++;
		}

		public TextElement()
		{
			id = GetNextId();
		}

		public void Dispose()
		{
			ShapesTextPool.Instance.ReleaseElement(id);
		}
	}
}
