using UnityEngine;

public class Destroyer : MonoBehaviour
{
	public GameObject Target;

	public void DestroyTarget()
	{
		Object.Destroy(Target);
	}
}
