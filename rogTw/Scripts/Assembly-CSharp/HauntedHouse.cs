using UnityEngine;

public class HauntedHouse : IncomeGenerator, IBuildable
{
	[SerializeField]
	private LayerMask graveLayerMask;

	[SerializeField]
	private GameObject UIObject;

	[SerializeField]
	private int goldBackOnDemolish;

	private bool isGathering;

	private int graveCount;

	private SimpleUI myUI;

	protected override void Start()
	{
		base.Start();
		DetectGraves();
	}

	public override void GenerateIncome()
	{
		if (isGathering)
		{
			incomePerRound = Mathf.FloorToInt((float)GameManager.instance.maxHealth / 10f * GameManager.instance.hauntedHouseTaxRate) * graveCount;
			base.GenerateIncome();
		}
	}

	public void SetStats()
	{
	}

	private void DetectGraves()
	{
		if (Physics.Raycast(base.transform.position + new Vector3(1f, 1f, 0f), -base.transform.up, out var hitInfo, 1f, graveLayerMask, QueryTriggerInteraction.Ignore))
		{
			CheckGrave(hitInfo);
		}
		if (Physics.Raycast(base.transform.position + new Vector3(-1f, 1f, 0f), -base.transform.up, out hitInfo, 1f, graveLayerMask, QueryTriggerInteraction.Ignore))
		{
			CheckGrave(hitInfo);
		}
		if (Physics.Raycast(base.transform.position + new Vector3(0f, 1f, 1f), -base.transform.up, out hitInfo, 1f, graveLayerMask, QueryTriggerInteraction.Ignore))
		{
			CheckGrave(hitInfo);
		}
		if (Physics.Raycast(base.transform.position + new Vector3(0f, 1f, -1f), -base.transform.up, out hitInfo, 1f, graveLayerMask, QueryTriggerInteraction.Ignore))
		{
			CheckGrave(hitInfo);
		}
	}

	private void CheckGrave(RaycastHit hit)
	{
		if (hit.collider.GetComponent<Grave>() != null && (double)Mathf.Abs(hit.collider.transform.position.y - base.transform.position.y) <= 0.001)
		{
			graveCount++;
			isGathering = true;
		}
	}

	public void SpawnUI()
	{
		myUI = Object.Instantiate(UIObject, base.transform.position, Quaternion.identity).GetComponent<SimpleUI>();
		myUI.SetDemolishable(base.gameObject, goldBackOnDemolish);
		if (myUI != null && isGathering)
		{
			string text = "Tax rate: " + Mathf.FloorToInt(100f * GameManager.instance.hauntedHouseTaxRate) + "%";
			text = text + "\nof " + (int)((float)GameManager.instance.maxHealth / 10f) + " (tower health)";
			text = text + "\nNearby graves: x" + graveCount;
			text = text + "\nDeath tax due: " + Mathf.FloorToInt((float)GameManager.instance.maxHealth / 10f * GameManager.instance.hauntedHouseTaxRate) * graveCount;
			text = text + "\nNet tax collected: " + base.netGold + "g.";
			myUI.SetDiscriptionText(text);
		}
	}

	public void Demolish()
	{
		RemoveIncomeGeneration();
	}
}
