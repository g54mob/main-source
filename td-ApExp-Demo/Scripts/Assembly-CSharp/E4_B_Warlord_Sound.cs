using UnityEngine;

public class E4_B_Warlord_Sound : MonoBehaviour
{
	private AudioSource audioSource;

	private Animator animator;

	[SerializeField]
	private AudioClip chaSound;

	[SerializeField]
	private AudioClip hitSound;

	[SerializeField]
	private E4_B_Warlord warlord;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
	}

	public void PlaySound()
	{
		if (!(audioSource == null))
		{
			audioSource.pitch = Random.Range(0.9f, 1.1f);
			audioSource.PlayOneShot(hitSound, 10f);
		}
	}

	public void PlayCha()
	{
		audioSource.pitch = Random.Range(0.9f, 1.1f);
		audioSource.PlayOneShot(chaSound, 10f);
	}

	public void Fast()
	{
		animator.SetFloat("SpeedMod", 3f);
	}

	public void Med()
	{
		animator.SetFloat("SpeedMod", 2f);
	}

	public void Slow()
	{
		animator.SetFloat("SpeedMod", 1f);
	}

	public void PlayNewRythm()
	{
		warlord.PlayCurrentSong();
	}

	public void PlayNextSong()
	{
		warlord.PlayNextSong();
	}
}
