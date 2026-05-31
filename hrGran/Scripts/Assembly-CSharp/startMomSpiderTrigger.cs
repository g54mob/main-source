using UnityEngine;

public class startMomSpiderTrigger : MonoBehaviour
{
	public GameObject momSpider;

	public GameObject scareSound;

	public bool scareSoundPlayed;

	public GameObject mainMusicHolder;

	public GameObject nightMareMusicHolder;

	public GameObject halloweenMusicHolder;

	public GameObject christmasMusicHolder;

	public GameObject spiderCellarMusicHolder;

	public GameObject huntMusicHolder;

	public GameObject huntNightmareMusicHolder;

	public GameObject huntHalloweenMusicHolder;

	public GameObject huntChristmasMusicHolder;

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
