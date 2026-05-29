using UnityEngine;

public class Cursor : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer visual;

	[SerializeField]
	private SpriteRenderer whiteTransparency;

	[SerializeField]
	private Color errorColor;

	private Vector2 currentPosition;

	[SerializeField]
	private GameObject circle10;

	[SerializeField]
	private GameObject circle12;

	[SerializeField]
	private GameObject circle14;

	[SerializeField]
	private GameObject circle16;

	[SerializeField]
	private GameObject circle18;

	public void UpdatePosition(Vector2 newPosition)
	{
		if (!(currentPosition == newPosition))
		{
			base.transform.position = newPosition;
			currentPosition = newPosition;
		}
	}

	public void ChangeColor(bool white)
	{
		if (white)
		{
			visual.color = Color.white;
		}
		else
		{
			visual.color = errorColor;
		}
	}

	public void ChangeSizeTo(Vector2Int size, float dimension)
	{
		Vector2 vector = new Vector2(dimension * 0.5f, dimension * 0.5f);
		visual.transform.localPosition = vector + new Vector2((float)(-(size.x - 1)) * dimension * 0.5f, (float)(size.y - 1) * dimension * 0.5f);
		visual.size = new Vector2((float)size.x * dimension, (float)size.y * dimension);
		whiteTransparency.transform.localPosition = vector + new Vector2((float)(-(size.x - 1)) * dimension * 0.5f, (float)(size.y - 1) * dimension * 0.5f);
		whiteTransparency.size = new Vector2((float)size.x * dimension, (float)size.y * dimension);
	}

	public void ChangeRangeTo(int size)
	{
		circle10.SetActive(value: false);
		circle12.SetActive(value: false);
		circle14.SetActive(value: false);
		circle16.SetActive(value: false);
		circle18.SetActive(value: false);
		if (size == 10 || size == 12 || size == 14 || size == 16 || size == 18)
		{
			if (size == 10)
			{
				circle10.SetActive(value: true);
			}
			if (size == 12)
			{
				circle12.SetActive(value: true);
			}
			if (size == 14)
			{
				circle14.SetActive(value: true);
			}
			if (size == 16)
			{
				circle16.SetActive(value: true);
			}
			if (size == 18)
			{
				circle18.SetActive(value: true);
			}
		}
	}

	public void Show()
	{
		visual.gameObject.SetActive(value: true);
		whiteTransparency.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		visual.gameObject.SetActive(value: false);
		whiteTransparency.gameObject.SetActive(value: false);
		ChangeRangeTo(0);
	}
}
