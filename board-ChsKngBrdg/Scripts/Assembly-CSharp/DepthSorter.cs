using UnityEngine;

public class DepthSorter : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	public int orderOffset;

	public void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Update()
	{
		spriteRenderer.sortingOrder = (int)(base.transform.position.y * -100f) + orderOffset;
	}
}
