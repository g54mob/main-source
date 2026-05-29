using UnityEngine;

public class Tree : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private Transform[] occupyTiles;

	private void Start()
	{
		RoundPositionToNearestPixel();
		MarkTilesAsOccupied();
		RandomizeSpriteRendererPosition();
		GameManager.ins.trees.Add(this);
	}

	public void MarkTilesAsOccupied()
	{
		for (int i = 0; i < occupyTiles.Length; i++)
		{
			Vector2Int xYCoordinates = GridSystem.ins.getXYCoordinates(occupyTiles[i].position);
			GridSystem.ins.MarkTilesAsOccupied(xYCoordinates, new Vector2Int(1, 1), occupiedState: true);
		}
	}

	private void RandomizeSpriteRendererPosition()
	{
		sr = GetComponentInChildren<SpriteRenderer>();
		if (!(sr == null))
		{
			float num = 0.0625f;
			float num2 = 0.0625f;
			if (Random.value > 0.5f)
			{
				sr.transform.localPosition += Vector3.down * num2;
			}
			else
			{
				sr.transform.localPosition += Vector3.down * num2 * 2f;
			}
			if (Random.value > 0.5f)
			{
				sr.transform.localPosition += Vector3.right * num;
			}
			else
			{
				sr.transform.localPosition += Vector3.left * num;
			}
		}
	}

	private void RoundPositionToNearestPixel()
	{
		base.transform.position = new Vector3(Mathf.Round(base.transform.position.x * 16f) / 16f, Mathf.Round(base.transform.position.y * 16f) / 16f);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(base.transform.position + Vector3.up * 1.125f, new Vector3(2.25f, 2.25f));
	}
}
