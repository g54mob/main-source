using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Soldering
{
	public class SolderPointFactory
	{
		private readonly SolderPointPool solderPointPool;

		[Inject]
		public SolderPointFactory(SolderPointPool solderPointPool)
		{
			this.solderPointPool = solderPointPool;
		}

		public SolderPoint Create(SolderPointData data, Transform parent)
		{
			SolderPoint solderPoint = solderPointPool.Get<SolderPoint>(parent);
			solderPoint.transform.localPosition = data.Transform.Position;
			return solderPoint;
		}

		public void Destroy(SolderPoint solderPoint)
		{
			solderPointPool.Release(solderPoint);
		}
	}
}
