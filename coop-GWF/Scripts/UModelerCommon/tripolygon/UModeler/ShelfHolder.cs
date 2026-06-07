using System;

namespace tripolygon.UModeler
{
	public class ShelfHolder : IDisposable
	{
		private EditableMesh originalEdMesh_;

		private int shelf = -1;

		public ShelfHolder(EditableMesh editableMesh = null)
		{
			if (editableMesh == null)
			{
				editableMesh = UMContext.activeModeler.editableMesh;
			}
			originalEdMesh_ = editableMesh;
			shelf = editableMesh.shelf;
		}

		public void Dispose()
		{
			originalEdMesh_.shelf = shelf;
		}
	}
}
