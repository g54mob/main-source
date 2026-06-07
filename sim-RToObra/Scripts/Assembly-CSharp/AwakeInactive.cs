using UnityEngine;

public class AwakeInactive : MonoBehaviour
{
	private void Awake()
	{
		if (!(Game.instance == null))
		{
			base.gameObject.SetActive(false);
		}
	}
}
