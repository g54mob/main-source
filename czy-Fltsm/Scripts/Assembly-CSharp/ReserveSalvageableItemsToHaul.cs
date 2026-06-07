using System.Collections;

public class ReserveSalvageableItemsToHaul : SalvageTaskBase
{
	public override TaskType Type => TaskType.ReserveSalvageableItemsToHaul;

	public override bool DoYieldReturn => false;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		FillItemsToSalvage();
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Reserve Salvageable Items To Haul", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Reserves items that can be salvaged from ISalvageTarget.");
	}
}
