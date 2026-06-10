using System.Collections.Generic;

namespace FIMSpace.FOptimizing
{
	public class Optimizers_CullingContainersList : List<Optimizers_CullingContainer>
	{
		public int ID { get; private set; }

		public Optimizers_CullingContainersList(int id)
		{
			ID = id;
		}

		public void Dispose()
		{
			for (int i = 0; i < base.Count; i++)
			{
				base[i].Dispose();
			}
			Clear();
		}
	}
}
