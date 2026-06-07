using UnityEngine;
using UnityEngine.UI;

public class Icontip : MonoBehaviour
{
	private RectTransform rectTransform;

	public Image image;

	private bool active;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		image.enabled = false;
	}

	public void ShowWith(Sprite newSprite)
	{
		image.sprite = newSprite;
		image.enabled = true;
		FollowMousePosition();
		active = true;
	}

	public void Hide()
	{
		image.sprite = null;
		image.enabled = false;
		active = false;
	}

	private void Update()
	{
		if (active)
		{
			FollowMousePosition();
			CheckIfInsideGrid();
		}
	}

	private void FollowMousePosition()
	{
		Vector2 vector = Input.mousePosition;
		float x = vector.x / (float)Screen.width;
		float y = vector.y / (float)Screen.height;
		rectTransform.pivot = new Vector2(x, y);
		base.transform.position = vector;
	}

	private void CheckIfInsideGrid()
	{
		Vector2 worldPosition = GridSystem.ins.convertMousePositionToWorldPosition(Input.mousePosition);
		Vector2Int xYCoordinates = GridSystem.ins.getXYCoordinates(worldPosition);
		if (xYCoordinates.y < 0 || xYCoordinates.y >= GridSystem.ins.gridSize.y)
		{
			image.enabled = false;
		}
		else
		{
			image.enabled = true;
		}
	}
}
