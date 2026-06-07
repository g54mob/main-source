using UnityEngine;

public class WaterSource : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private Sprite[] sprites;

	[Header("Autumn Sprites (Override)")]
	[SerializeField]
	private Sprite[] autumnSprites;

	private int currentIndex;

	private Vector2Int coordinates;

	private void Start()
	{
		GameManager.ins.waterSources.Add(this);
		if (SaveData.ins.farmType == SaveData.FarmType.Autumn)
		{
			sprites = autumnSprites;
		}
		if (sr != null)
		{
			MoveWater();
		}
		if (sr == null)
		{
			RoundPositionToNearestPixel();
			coordinates = GridSystem.ins.getXYCoordinates(base.transform.position);
			MarkTilesAsOccupied();
		}
	}

	public void MarkTilesAsOccupied()
	{
		if (!GridSystem.ins.tile[coordinates.x, coordinates.y].occupied)
		{
			GridSystem.ins.MarkTilesAsOccupied(coordinates, new Vector2Int(1, 1), occupiedState: true);
		}
	}

	private void RoundPositionToNearestPixel()
	{
		base.transform.position = new Vector3(Mathf.Round(base.transform.position.x * 16f) / 16f, Mathf.Round(base.transform.position.y * 16f) / 16f);
	}

	private void OnDestroy()
	{
		GameManager.ins.waterSources.Remove(this);
	}

	private void MoveWater()
	{
		if (currentIndex == 0)
		{
			MoveUp();
		}
		else if (currentIndex == 2)
		{
			MoveDown();
		}
		else if (Random.value > 0.5f)
		{
			MoveUp();
		}
		else
		{
			MoveDown();
		}
	}

	private void MoveUp()
	{
		currentIndex++;
		sr.sprite = sprites[currentIndex];
		Invoke("MoveWater", Random.Range(0.5f, 3f));
	}

	private void MoveDown()
	{
		currentIndex--;
		sr.sprite = sprites[currentIndex];
		Invoke("MoveWater", Random.Range(0.5f, 3f));
	}
}
