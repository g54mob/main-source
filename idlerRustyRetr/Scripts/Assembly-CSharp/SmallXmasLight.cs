using UnityEngine;

public class SmallXmasLight : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	private Color colr;

	private bool onOff;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		colr = spriteRenderer.color;
		RoundToNearestPixel();
		onOff = Random.value < 0.5f;
		ChangeOnOff();
	}

	private void ChangeOnOff()
	{
		onOff = !onOff;
		spriteRenderer.color = new Color(colr.r, colr.g, colr.b, onOff ? 0f : 0.3f);
		TriggerOnOff();
	}

	private void TriggerOnOff()
	{
		float num = Random.Range(0.5f, 1f);
		if (onOff)
		{
			num *= 2.5f;
		}
		Invoke("ChangeOnOff", num);
	}

	private void RoundToNearestPixel()
	{
		Vector3 position = base.transform.position;
		position.x = Mathf.Round(position.x * 16f) / 16f;
		position.y = Mathf.Round(position.y * 16f) / 16f;
		base.transform.position = position;
	}
}
