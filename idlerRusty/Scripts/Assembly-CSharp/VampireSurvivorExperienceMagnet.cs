using UnityEngine;

public class VampireSurvivorExperienceMagnet : MonoBehaviour
{
	private void Start()
	{
		if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.VampireSurvivors)
		{
			GameManager.ins.expMagnets.Add(this);
		}
		else
		{
			base.enabled = false;
		}
	}
}
