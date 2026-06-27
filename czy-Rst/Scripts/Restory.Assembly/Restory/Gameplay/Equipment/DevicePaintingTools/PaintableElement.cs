using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintableElement : MonoBehaviour
	{
		[SerializeField]
		private ElementBase element;

		[SerializeField]
		private PaintingTextureHolder paintingTextureHolder;

		[SerializeField]
		private Transform raycastTarget;

		public Transform RaycastTarget => raycastTarget;

		public PaintingTextureHolder PaintingTextureHolder => paintingTextureHolder;

		public ElementBase Element => element;

		private void Reset()
		{
			TryGetComponent<ElementBase>(out element);
			Rigidbody componentInChildren = GetComponentInChildren<Rigidbody>();
			if ((bool)componentInChildren)
			{
				raycastTarget = componentInChildren.transform;
			}
			paintingTextureHolder = GetComponentInChildren<PaintingTextureHolder>();
		}
	}
}
