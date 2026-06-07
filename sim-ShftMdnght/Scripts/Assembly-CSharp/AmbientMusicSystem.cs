using UnityEngine;

public class AmbientMusicSystem : MonoBehaviour
{
	public AudioSource[] ambientTracks;

	public int curTrackIndex;

	public bool inHunt;

	public static AmbientMusicSystem Instance { get; private set; }

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		InvokeRepeating("SwitchTracks", 180f, 180f);
	}

	private void SwitchTracks()
	{
		int num;
		do
		{
			num = Random.Range(0, ambientTracks.Length);
		}
		while (num == curTrackIndex);
		curTrackIndex = num;
	}

	private void FixedUpdate()
	{
		if (inHunt)
		{
			for (int i = 0; i < ambientTracks.Length; i++)
			{
				ambientTracks[i].volume = Mathf.Lerp(ambientTracks[curTrackIndex].volume, 0f, Time.deltaTime * 2f);
			}
			return;
		}
		for (int j = 0; j < ambientTracks.Length; j++)
		{
			if (j == curTrackIndex)
			{
				ambientTracks[j].volume = Mathf.Lerp(ambientTracks[curTrackIndex].volume, 0.05f, Time.deltaTime * 0.3f);
			}
			else
			{
				ambientTracks[j].volume = Mathf.Lerp(ambientTracks[curTrackIndex].volume, 0f, Time.deltaTime * 0.3f);
			}
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
