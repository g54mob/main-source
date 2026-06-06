using UnityEngine;
using UnityEngine.UI;

public class TreeUI : MonoBehaviour
{
	private GameObject myTree;

	[SerializeField]
	private Text description;

	[SerializeField]
	private GameObject goldShower;

	[SerializeField]
	private GameObject treasureObject;

	public void SetStats(GameObject spawner)
	{
		myTree = spawner;
	}

	private void Start()
	{
		UIManager.instance.SetNewUI(base.gameObject);
		string text = "Chopping this tree will currently yield " + SpawnManager.instance.level * SpawnManager.instance.level + "g.";
		if (GameManager.instance.treeCardChanceMultiplier > 0)
		{
			text = text + "\nAnd, a " + Mathf.Floor(Mathf.Min(SpawnManager.instance.level * GameManager.instance.treeCardChanceMultiplier, 100)) + "% chance to drop cards.";
		}
		description.text = text;
	}

	public void Chop()
	{
		SFXManager.instance.ButtonClick();
		SFXManager.instance.PlaySound(Sound.CoinLong, base.transform.position);
		Object.Instantiate(goldShower, base.transform.position, Quaternion.identity);
		Object.Destroy(myTree.gameObject);
		ResourceManager.instance.AddMoney(SpawnManager.instance.level * SpawnManager.instance.level);
		DamageTracker.instance.AddIncome(DamageTracker.IncomeType.Tree, SpawnManager.instance.level * SpawnManager.instance.level);
		if (Random.Range(1, 100) <= SpawnManager.instance.level * GameManager.instance.treeCardChanceMultiplier)
		{
			Object.Instantiate(treasureObject, base.transform.position, Quaternion.identity);
		}
		UIManager.instance.CloseUI(base.gameObject);
	}
}
