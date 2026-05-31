using System.Collections;
using UnityEngine;

public class wfdver1 : MonoBehaviour
{
	private bool a;

	public void use()
	{
		if (!a)
		{
			base.gameObject.GetComponent<Animator>().SetTrigger("a");
			base.gameObject.GetComponent<AudioSource>().Play();
			a = true;
			StartCoroutine(b());
		}
	}

	private IEnumerator b()
	{
		yield return new WaitForSeconds(1.5f);
		a = false;
	}
}
