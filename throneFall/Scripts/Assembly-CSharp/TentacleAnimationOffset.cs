using UnityEngine;

public class TentacleAnimationOffset : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Animator>().SetFloat("Offset", Random.value);
	}
}
