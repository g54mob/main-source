using UnityEngine;

public class FireDamagerScript : MonoBehaviour
{
	public float DamageTick;

	private float DamageTimer;

	private PlayerHealthScript PHealth;

	public float MyDamage;

	public FireScript MyFire;

	private void Start()
	{
		PHealth = GameObject.Find("Player").GetComponent<PlayerHealthScript>();
		DamageTimer = Random.Range(0f, DamageTick);
	}

	private void Update()
	{
		DamageTimer += Time.deltaTime;
		if (DamageTimer > DamageTick)
		{
			DamageTimer = DamageTick;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (DamageTimer >= DamageTick && MyFire.MyIntensity > 0.3f && other.transform.tag == "Player")
		{
			PHealth.TakeDamage(MyDamage);
			DamageTimer = 0f;
		}
	}
}
