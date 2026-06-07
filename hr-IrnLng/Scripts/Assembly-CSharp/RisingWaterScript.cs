using UnityEngine;

public class RisingWaterScript : MonoBehaviour
{
	public float[] Goals;

	public int CurrentGoal;

	public bool Move;

	public float MoveSpeed;

	private void Start()
	{
	}

	private void Update()
	{
		if (Move)
		{
			base.transform.position += new Vector3(0f, MoveSpeed * Time.deltaTime, 0f);
			if (base.transform.position.y >= Goals[CurrentGoal])
			{
				base.transform.position = new Vector3(base.transform.position.x, Goals[CurrentGoal], base.transform.position.z);
				Move = false;
			}
		}
	}

	public void TriggerWater(int Goal)
	{
		CurrentGoal = Goal;
		Move = true;
	}
}
