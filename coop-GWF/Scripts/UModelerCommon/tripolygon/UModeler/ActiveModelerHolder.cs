using System;

namespace tripolygon.UModeler
{
	public class ActiveModelerHolder : IDisposable
	{
		private UModeler originalModeler_;

		public ActiveModelerHolder(UModeler modeler)
		{
			originalModeler_ = UMContext.activeModeler;
			UMContext.activeModeler = modeler;
		}

		public void Dispose()
		{
			UMContext.activeModeler = originalModeler_;
		}
	}
}
