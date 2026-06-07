using System;

namespace Shapes
{
	public class TextElement : IDisposable
	{
		private static int idCounter;

		public readonly int id;

		public TextMeshProShapes Tmp => ShapesObjPool<TextMeshProShapes, ShapesTextPool>.Instance.GetElement(id);

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
			ShapesObjPool<TextMeshProShapes, ShapesTextPool>.Instance.ReleaseElement(id);
		}
	}
}
