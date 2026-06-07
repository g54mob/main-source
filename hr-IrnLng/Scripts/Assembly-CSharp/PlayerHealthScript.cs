using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
	public float CurrentHealth;

	private SubController SubCont;

	public FadeInCanvasGroup DamageGroup;

	public AudioSource DamageSound;

	private void Start()
	{
		SubCont = GameObject.Find("FakeSub").GetComponent<SubController>();
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (CurrentHealth <= 0f && !SubCont.Dead)
		{
			SubCont.DoDeath();
		}
	}

	public void TakeDamage(float d)
	{
		if (!SubCont.Dead)
		{
			CurrentHealth -= d;
			DamageGroup.ResetThis();
			DamageSound.Play();
		}
	}
}
