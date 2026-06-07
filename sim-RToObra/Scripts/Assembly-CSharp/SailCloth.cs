using UnityEngine;

public class SailCloth : MonoBehaviour
{
	private void Start()
	{
		if (Game.isInMoment)
		{
			GetComponent<Cloth>().enabled = false;
		}
	}

	private void Update()
	{
	}
}
