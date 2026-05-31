using UnityEngine;

public class RemoteSoundScript : MonoBehaviour
{
	private GameObject MyAud;

	private Transform SubCenter;

	private Transform FakeSub;

	public float MaxRange;

	public float MinRange;

	public AudioClip MyClip;

	public float MyVolume;

	public GameObject AudioPrefab;

	public bool Loop = true;

	private void Start()
	{
		SubCenter = GameObject.Find("SubCenter").transform;
		FakeSub = GameObject.Find("FakeSub").transform;
		MyAud = Object.Instantiate(AudioPrefab);
		AudioSource component = MyAud.GetComponent<AudioSource>();
		component.volume = MyVolume;
		component.maxDistance = MaxRange;
		component.minDistance = MinRange;
		component.clip = MyClip;
		if (Loop)
		{
			component.loop = true;
			component.Play();
		}
		else
		{
			component.loop = false;
		}
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		Vector3 vector = FakeSub.transform.InverseTransformPoint(base.transform.position);
		MyAud.transform.position = SubCenter.position + SubCenter.rotation * vector;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(base.transform.position, MaxRange);
		Gizmos.DrawWireSphere(base.transform.position, MinRange);
	}

	public void TriggerSound()
	{
		MyAud.GetComponent<AudioSource>().Play();
	}
}
