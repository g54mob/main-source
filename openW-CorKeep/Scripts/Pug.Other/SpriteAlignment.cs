using UnityEngine;

public class SpriteAlignment : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public Transform aligner;

	public bool alignToRight;

	private void Update()
	{
		float num = (alignToRight ? 1 : (-1));
		aligner.transform.localPosition = new Vector3(num * (spriteRenderer.size.x / 2f), 0f, 0f);
	}
}
