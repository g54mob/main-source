using UnityEngine;

public class sound : MonoBehaviour
{
	public AudioClip aud;

	public int x;

	private bool enab;

	public void use()
	{
		if (!base.gameObject.GetComponent<AudioSource>().isPlaying && !enab)
		{
			if (aud == null)
			{
				base.gameObject.GetComponent<AudioSource>().Play();
			}
			else if (x < 0)
			{
				base.gameObject.GetComponent<AudioSource>().Play();
				x++;
			}
			else
			{
				base.gameObject.GetComponent<AudioSource>().clip = aud;
				base.gameObject.GetComponent<AudioSource>().Play();
				enab = true;
			}
		}
	}
}
