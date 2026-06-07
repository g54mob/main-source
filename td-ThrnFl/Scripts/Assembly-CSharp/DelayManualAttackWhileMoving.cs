using UnityEngine;

public class DelayManualAttackWhileMoving : MonoBehaviour
{
	public ManualAttack manualAttack;

	public PlayerMovement playerMovement;

	[BalancingParameter(BalancingParameter.EType.Percentage)]
	public float percentage = 1f;

	private void Update()
	{
		if (playerMovement.Moving)
		{
			manualAttack.Cooldown += Time.deltaTime * percentage;
		}
	}
}
