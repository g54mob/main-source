using System.Collections;
using UnityEngine;

public class wfpodsk : MonoBehaviour
{
	public GameObject pod;

	public float sec;

	public void use()
	{
		if (!pod.active)
		{
			pod.SetActive(value: true);
			StartCoroutine(cor());
			if ((bool)base.gameObject.GetComponent<AudioSource>())
			{
				base.gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}

	private IEnumerator cor()
	{
		yield return new WaitForSeconds(sec);
		pod.SetActive(value: false);
	}
}
