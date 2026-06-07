using UnityEngine;

public class Invulnerable : MonoBehaviour
{
	private Hp hp;

	private void Start()
	{
		hp = GetComponent<Hp>();
	}

	private void Update()
	{
		hp.Heal(1000000f);
	}
}
