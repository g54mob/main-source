using UnityEngine;

public class POIRelocator : MonoBehaviour
{
	private void Start()
	{
		GameManager.WorldManager.CreateWorldParent();
		base.transform.SetParent(GameManager.WorldManager.WorldParent);
	}

	private void FixedUpdate()
	{
		if (base.transform.position.z > 500f)
		{
			base.transform.position = FlotsamGame.SetZ(base.transform.position, -500f);
		}
	}
}
