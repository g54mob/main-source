using UnityEngine;

public class Sparkle : MonoBehaviour
{
	[SerializeField]
	private bool bigSparkle;

	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
		anim.SetBool("bigSparkle", bigSparkle);
		Invoke("Shine", Random.Range(0f, 15f));
	}

	private void Shine()
	{
		anim.SetTrigger("sparkle");
		Invoke("Shine", Random.Range(0f, 15f));
	}
}
