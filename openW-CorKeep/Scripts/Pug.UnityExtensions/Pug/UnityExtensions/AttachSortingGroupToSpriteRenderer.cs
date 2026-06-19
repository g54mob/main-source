using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.UnityExtensions
{
	[ExecuteInEditMode]
	public class AttachSortingGroupToSpriteRenderer : MonoBehaviour
	{
		private SortingGroup sortingGroup;

		private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			sortingGroup = GetComponent<SortingGroup>();
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void LateUpdate()
		{
			sortingGroup.sortingOrder = spriteRenderer.sortingOrder;
			sortingGroup.sortingLayerID = spriteRenderer.sortingLayerID;
			if (base.gameObject.isStatic)
			{
				base.enabled = false;
			}
		}
	}
}
