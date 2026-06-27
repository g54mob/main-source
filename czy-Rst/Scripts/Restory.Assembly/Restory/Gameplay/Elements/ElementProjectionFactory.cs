using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementProjectionFactory
	{
		private readonly ElementProjectionPool elementProjectionPool;

		private readonly SmallElementProjectionPool smallElementProjectionPool;

		[Inject]
		public ElementProjectionFactory(ElementProjectionPool elementProjectionPool, SmallElementProjectionPool smallElementProjectionPool)
		{
			this.elementProjectionPool = elementProjectionPool;
			this.smallElementProjectionPool = smallElementProjectionPool;
		}

		public ElementProjection CreateElementProjection(ElementProjectionData projectionData, Transform parentTransform)
		{
			ElementProjection elementProjection = elementProjectionPool.Get<ElementProjection>(parentTransform);
			InitProjection(elementProjection, projectionData);
			return elementProjection;
		}

		public ElementProjection CreateSmallElementProjection(bool detectable, ElementProjectionData projectionData, Transform parentTransform)
		{
			ElementProjection elementProjection = smallElementProjectionPool.Get<ElementProjection>(parentTransform);
			InitProjection(elementProjection, projectionData);
			elementProjection.ToggleCollider(detectable);
			return elementProjection;
		}

		public void DestroyElementProjection(ElementProjection projection)
		{
			Object.Destroy(projection.MeshFilter.sharedMesh);
			projection.SetOutlineLayer(0);
			elementProjectionPool.Release(projection);
		}

		public void DestroySmallElementProjection(ElementProjection projection)
		{
			Object.Destroy(projection.MeshFilter.sharedMesh);
			smallElementProjectionPool.Release(projection);
		}

		private void InitProjection(ElementProjection projection, ElementProjectionData projectionData)
		{
			projection.transform.localPosition = projectionData.ElementAttachmentPosition + projectionData.MeshOffset;
			projection.transform.localRotation = Quaternion.identity;
			projection.BoxCollider.center = projectionData.ColliderCenter;
			projection.BoxCollider.size = projectionData.ColliderSize;
			projection.MeshFilter.sharedMesh = Object.Instantiate(projectionData.SharedMesh);
		}
	}
}
