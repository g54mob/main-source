using System;
using Mandragora.PWS;

namespace Restory.Gameplay.Elements
{
	[Serializable]
	public class ElementDirtyPixelsData
	{
		public DirtyPixelsCount InitialDirtyPixelsCount = new DirtyPixelsCount();

		public int PixelsToLeaveDirtyCountRG;

		public int PixelsToLeaveDirtyCountB;

		public DirtyPixelsCount CurrentDirtyPixelsCount = new DirtyPixelsCount();
	}
}
