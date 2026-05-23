using Rewired;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public Hp hpPlayer;

	public AttackCooldownAnimation ui;

	private ManualAttack attack;

	private Player input;

	private void Start()
	{
		input = ReInput.players.GetPlayer(0);
	}

	private void Update()
	{
		if ((bool)attack)
		{
			attack.Tick();
			attack.DisableMarkersIfDead();
			ui.SetCurrentCooldownPercentage(attack.CooldownPercentage);
		}
	}

	public void AssignManualAttack(ManualAttack target)
	{
		attack = target;
	}
}
