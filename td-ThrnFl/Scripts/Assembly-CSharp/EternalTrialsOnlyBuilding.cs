using UnityEngine;

public class EternalTrialsOnlyBuilding : PerkDestroyGameObjectModifyer
{
	public override bool IsGoingToBeDestroyed => LocalGamestate.SelectedGameMode != LocalGamestate.GameMode.EternalTrial;

	public override void Start()
	{
		if (IsGoingToBeDestroyed)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
