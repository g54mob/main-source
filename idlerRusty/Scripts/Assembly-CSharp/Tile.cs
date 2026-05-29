using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Collider2D collider;

	[Header("Visuals")]
	[SerializeField]
	private SpriteRenderer visual;

	[SerializeField]
	private Sprite[] sprites;

	[Header("Information")]
	[SerializeField]
	private Vector2Int coords;

	public void SetVisualActive(bool activeState)
	{
	}

	public void SetCoordsTo(int x, int y)
	{
		coords = new Vector2Int(x, y);
	}

	public void SetRandomizedVisual()
	{
		visual.sprite = sprites[getRandomSprite()];
	}

	private int getRandomSprite()
	{
		return Random.Range(0, sprites.Length);
	}

	public void SetColliderActive(bool activeState)
	{
		collider.enabled = activeState;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		if (GameManager.ins.state == GameManager.State.CanBuild)
		{
			GridSystem.ins.Build(GameManager.ins.buildingSelected, coords);
		}
		if (GameManager.ins.state == GameManager.State.CanBuildHouse)
		{
			GridSystem.ins.BuildHouse(GameManager.ins.houseSelected, coords);
		}
		if (GameManager.ins.state == GameManager.State.CanDecorate)
		{
			GridSystem.ins.Decorate(GameManager.ins.decorSelected, coords);
		}
		if (GameManager.ins.state == GameManager.State.IsMovingBuilding)
		{
			if (GameManager.ins.buildingSelectedForMoving != null)
			{
				GridSystem.ins.MoveBuilding(GameManager.ins.buildingSelectedForMoving, coords);
			}
			if (GameManager.ins.houseSelectedForMoving != null)
			{
				GridSystem.ins.MoveHouse(GameManager.ins.houseSelectedForMoving, coords);
			}
			if (GameManager.ins.decorSelectedForMoving != null)
			{
				GridSystem.ins.MoveDecoration(GameManager.ins.decorSelectedForMoving, coords);
			}
		}
	}
}
