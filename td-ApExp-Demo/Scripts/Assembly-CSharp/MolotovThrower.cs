using UnityEngine;

public class MolotovThrower : MonoBehaviour
{
	private Animator Anim;

	private E2_6MolotovBiker Biker;

	private void Start()
	{
		Anim = GetComponent<Animator>();
		Biker = GetComponentInParent<E2_6MolotovBiker>();
	}

	public void ThrowProjectile()
	{
		Biker.ThrowMolotov();
	}

	public void CompleteThrow()
	{
		Biker.CompleteMolotovThrow();
	}

	public void SetThrow()
	{
		Anim.SetTrigger("Throw");
	}
}
