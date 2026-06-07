using UnityEngine;
using UnityEngine.EventSystems;

public class BuildSlot : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public enum State
	{
		Empty = 0,
		NeedsBuilding = 1,
		IsBuilding = 2,
		Built = 3
	}

	public State state;

	[SerializeField]
	private BuildingSO buildingSO;

	[SerializeField]
	private GameObject highlight;

	[SerializeField]
	private GameObject markedForConstruction;

	[SerializeField]
	private Animator poofAnimation;

	private SpriteRenderer sr;

	private Collider2D coll;

	private void Start()
	{
		highlight.SetActive(value: false);
		markedForConstruction.SetActive(value: false);
		sr = GetComponent<SpriteRenderer>();
		coll = GetComponent<Collider2D>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		highlight.SetActive(value: false);
		if (GameManager.ins.state == GameManager.State.CanBuild && state == State.Empty)
		{
			PlaceBuilding(GameManager.ins.buildingSelected);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanBuild && state == State.Empty)
		{
			highlight.SetActive(value: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		highlight.SetActive(value: false);
	}

	private void PlaceBuilding(BuildingSO type)
	{
		GameManager.ins.SetStateToIdle();
		buildingSO = type;
		int spareParts = buildingSO.spareParts;
		int biofuel = buildingSO.biofuel;
		if (Inventory.ins.spareParts >= spareParts)
		{
			Inventory.ins.AddSpareParts(-spareParts);
			if (Inventory.ins.biofuel >= biofuel)
			{
				Inventory.ins.AddBiofuel(-biofuel);
				state = State.NeedsBuilding;
				markedForConstruction.SetActive(value: true);
			}
			else
			{
				ErrorFeedback();
			}
		}
		else
		{
			ErrorFeedback();
		}
	}

	private void ErrorFeedback()
	{
	}

	public void StartBuilding()
	{
		state = State.IsBuilding;
	}

	public void CompleteBuild()
	{
		poofAnimation.SetTrigger("poof");
		state = State.Built;
		Object.Instantiate(buildingSO.prefab, base.transform);
		sr.enabled = false;
		coll.enabled = false;
		markedForConstruction.SetActive(value: false);
	}
}
