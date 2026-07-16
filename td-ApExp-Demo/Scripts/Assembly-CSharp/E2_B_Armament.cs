using UnityEngine;

public class E2_B_Armament : MonoBehaviour
{
	[SerializeField]
	protected GameObject spawnPrefab;

	public E2_B_BossController boss;

	public Animator Anim { get; private set; }

	protected void Awake()
	{
		Anim = GetComponent<Animator>();
	}

	public virtual bool TryDisarm()
	{
		return true;
	}

	public virtual void Aim()
	{
	}

	public virtual void Fire(float damage = 0f)
	{
	}

	public virtual void PlaySpawnAnim()
	{
	}

	public virtual void OnBossFactionChanged()
	{
	}
}
