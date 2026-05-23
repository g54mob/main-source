using UnityEngine;

public class QuestItemPress : QuestItemBase
{
	private new void Start()
	{
		base.Start();
	}

	private void Update()
	{
	}

	public override void Interact()
	{
		MonoBehaviour.print("Quest advanced");
		playerController.GetCurrentQuest().currentAmount++;
		Object.Destroy(base.gameObject);
	}

	public override void Activate()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;
	}

	public override void Deactivate()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
}
