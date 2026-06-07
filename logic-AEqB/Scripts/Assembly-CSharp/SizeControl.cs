using UnityEngine;
using UnityEngine.UI;

public class SizeControl : MonoBehaviour
{
	private GridLayoutGroup grid;

	public float scale;

	public float ratio = 1f;

	public float scale_height = 10000f;

	private void Start()
	{
		grid = GetComponent<GridLayoutGroup>();
	}

	private void Update()
	{
		if ((float)Screen.width * scale_height < (float)Screen.height * scale * ratio)
		{
			grid.cellSize = new Vector2((float)Screen.width * scale_height, (float)Screen.width * scale_height / ratio);
		}
		else
		{
			grid.cellSize = new Vector2((float)Screen.height * scale * ratio, (float)Screen.height * scale);
		}
	}
}
