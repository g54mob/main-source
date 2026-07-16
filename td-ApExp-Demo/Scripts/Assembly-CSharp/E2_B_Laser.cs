using UnityEngine;

public class E2_B_Laser : MonoBehaviour
{
	[SerializeField]
	private E2_B_BossBController boss;

	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void Charge()
	{
		anim.SetTrigger("Charging");
	}

	public void Shoot()
	{
		anim.SetTrigger("Fire");
	}

	public void Abort()
	{
		anim.SetTrigger("Abort");
	}
}
