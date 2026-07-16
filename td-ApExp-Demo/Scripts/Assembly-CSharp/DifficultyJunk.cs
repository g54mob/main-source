using UnityEngine;

public class DifficultyJunk : MonoBehaviour
{
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
		float z = Random.Range(15f, 346f);
		base.transform.localRotation = Quaternion.Euler(0f, 0f, z);
	}

	public void Disappear()
	{
		anim.Play("DifficultyJunkDisappear");
	}

	public void DestroySelf()
	{
		Object.Destroy(base.gameObject);
	}
}
