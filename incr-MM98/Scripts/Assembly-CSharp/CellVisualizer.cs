using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellVisualizer : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler
{
	[SerializeField]
	private Image cellImage;

	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TMP_Text label;

	[SerializeField]
	private Sprite cellRevealed;

	[SerializeField]
	private Sprite flagSprite;

	[SerializeField]
	private Sprite mineSprite;

	private MineCellData _data;

	private Vector2Int _position;

	public void Setup(MineCellData data, Vector2Int position)
	{
		_data = data;
		_position = position;
		RefreshVisual();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		EventHub.Scene.Publish(new MinesweeperMouse(down: true));
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		EventHub.Scene.Publish(new MinesweeperMouse(down: false));
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left && _data.State != MineCellData.CellState.Flagged)
		{
			EventHub.Scene.Publish(new MinesweeperRevealed(_position));
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			EventHub.Scene.Publish(new MinesweeperFlagged(_position));
		}
	}

	public void RefreshVisual()
	{
		if (_data == null)
		{
			return;
		}
		switch (_data.State)
		{
		case MineCellData.CellState.Hidden:
			SetSprites(null, null);
			label.text = string.Empty;
			break;
		case MineCellData.CellState.Flagged:
			SetSprites(null, flagSprite);
			iconImage.color = Color.yellow;
			label.text = string.Empty;
			break;
		case MineCellData.CellState.Revealed:
			if (_data.IsMine)
			{
				SetSprites(cellRevealed, mineSprite);
				iconImage.color = Color.red;
				label.text = string.Empty;
				break;
			}
			SetSprites(cellRevealed, null);
			if (_data.AdjacentMineCount > 0)
			{
				label.text = ZString.Format("{0}", _data.AdjacentMineCount);
				label.color = GetNumberColor(_data.AdjacentMineCount);
			}
			else
			{
				label.text = string.Empty;
			}
			break;
		}
	}

	private void SetSprites(Sprite cell, Sprite icon)
	{
		cellImage.overrideSprite = cell;
		iconImage.overrideSprite = icon;
		iconImage.enabled = icon;
	}

	private Color GetNumberColor(int count)
	{
		return count switch
		{
			1 => Color.blue, 
			2 => Color.green, 
			3 => Color.red, 
			4 => Color.magenta, 
			_ => Color.black, 
		};
	}
}
