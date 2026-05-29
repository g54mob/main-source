using UnityEngine;
using UnityEngine.EventSystems;

public class Decoration : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[Header("Information")]
	public int decorId;

	public Vector2Int size = new Vector2Int(1, 1);

	public Sprite decorSprite;

	public Sprite snowSprite;

	public int spareParts;

	public int biofuel;

	[Header("References")]
	private Vector2Int anchorCoord;

	[SerializeField]
	private GameObject highlight;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[Header("Overrides")]
	public int statProgress;

	public bool isFlower;

	public bool flipX;

	private void Start()
	{
		highlight.GetComponent<SpriteRenderer>().sortingOrder = 99;
		highlight.SetActive(value: false);
		if (isFlower)
		{
			GameManager.ins.flowers.Add(base.transform);
		}
		if (flipX && (bool)spriteRenderer)
		{
			spriteRenderer.flipX = Random.value < 0.5f;
		}
		if ((bool)snowSprite && (bool)spriteRenderer && SaveData.ins.farmType == SaveData.FarmType.WinterSnow)
		{
			spriteRenderer.sprite = snowSprite;
		}
	}

	private void Update()
	{
		if (GameManager.ins.state == GameManager.State.CanDemolish)
		{
			if (!highlight.activeInHierarchy)
			{
				highlight.SetActive(value: true);
			}
			return;
		}
		if (highlight.activeInHierarchy)
		{
			highlight.SetActive(value: false);
		}
		if (GameManager.ins.state == GameManager.State.CanMoveBuilding && GameManager.ins.qualityUpdate)
		{
			if (!highlight.activeInHierarchy)
			{
				highlight.SetActive(value: true);
			}
		}
		else if (highlight.activeInHierarchy)
		{
			highlight.SetActive(value: false);
		}
	}

	public void AddAnchorCoord(Vector2Int coord)
	{
		anchorCoord = coord;
	}

	public void SetProgressStat(int value)
	{
		statProgress = value;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanDemolish)
		{
			Demolish();
		}
		if (GameManager.ins.state == GameManager.State.CanMoveBuilding && GameManager.ins.qualityUpdate)
		{
			SelectThisDecorationToMove();
		}
	}

	public void SelectThisDecorationToMove()
	{
		GameManager.ins.state = GameManager.State.IsMovingBuilding;
		GameManager.ins.decorSelectedForMoving = this;
		GameManager.ins.buildingSelectedForMoving = null;
		GameManager.ins.houseSelectedForMoving = null;
	}

	public void SetNewDecorationCoord(Vector2Int target)
	{
		if (!(target == anchorCoord))
		{
			GridSystem.ins.QuickDecorate(this, target, statProgress);
			Demolish();
		}
	}

	public void Demolish()
	{
		GameManager.ins.gridSystem.RemoveDecorAt(anchorCoord, size);
		if (isFlower)
		{
			GameManager.ins.flowers.Remove(base.transform);
		}
		Object.Destroy(base.gameObject);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(base.transform.position + new Vector3(0.5625f, 0.5625f), new Vector2(0.75f, 0.75f));
	}
}
