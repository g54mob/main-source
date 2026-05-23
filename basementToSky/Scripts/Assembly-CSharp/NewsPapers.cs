using System.Collections.Generic;
using UnityEngine;

public class NewsPapers : Item
{
	[SerializeField]
	private List<GameObject> newspapersGO;

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	private void Update()
	{
	}

	public void PutNewspaper()
	{
		GameObject gameObject = newspapersGO[0];
		newspapersGO.Remove(gameObject);
		Object.Destroy(gameObject);
		if (newspapersGO.Count == 0)
		{
			QuestManager.S.NewspaperDeliveryCompleted();
			Object.Destroy(base.gameObject);
			FirstPersonController.S.itemOnHand = null;
			FirstPersonController.S.ItemOutHand();
		}
	}
}
