using UnityEngine;
using UnityEngine.Rendering;

public class CentipedeSegment : MonoBehaviour
{
	[HideInInspector]
	public CentipedeController controller;

	[SerializeField]
	private SpriteRenderer bodyInsidesSr;

	[SerializeField]
	private SortingGroup sortingGroup;

	public float padding;

	public int CurrentMarkerIndex { get; private set; }

	public float SpriteHalfHeight { get; private set; }

	public void Initialize(CentipedeController controller, int index)
	{
		this.controller = controller;
		if ((bool)bodyInsidesSr)
		{
			bodyInsidesSr.sprite = controller.InsidesSpritesBody[index % 2];
		}
		SpriteHalfHeight = GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2f;
	}

	public void SetSortOrder(int order)
	{
		sortingGroup.sortingOrder = order;
	}

	public void Explode()
	{
		GetComponent<ExplodeSprite>().Explode();
		Object.Destroy(base.gameObject);
	}
}
