using UnityEngine;

public class liftkn : MonoBehaviour
{
	public lift l;

	public void use()
	{
		base.gameObject.GetComponent<AudioSource>().Play();
		base.gameObject.GetComponent<BoxCollider>().enabled = false;
		base.gameObject.GetComponent<Animator>().enabled = true;
		l.a();
	}
}
