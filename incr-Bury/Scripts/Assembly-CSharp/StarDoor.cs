using UnityEngine;

public class StarDoor : MonoBehaviour
{
	private bool hasOpenedDoor;

	private Animator anim;

	private GameObject keyThatTouchedUs;

	[SerializeField]
	private GameObject dummyAnimKey;

	[Header("Audio")]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip audio_KeyTurn;

	[SerializeField]
	private AudioClip audio_DoorOpen;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	private void Start()
	{
		dummyAnimKey.SetActive(value: false);
	}

	private void Update()
	{
		GameManager.Singleton.isStarDoorOpen = hasOpenedDoor;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.transform.root.gameObject.CompareTag("PickUp"))
		{
			return;
		}
		try
		{
			if (other.transform.root.gameObject.GetComponent<PickUppable>().GetItemIdentity() == ItemIdentity.StarKey)
			{
				Debug.Log("Opening Star Door!");
				keyThatTouchedUs = other.transform.root.gameObject;
				OpenStarDoor();
				AllWaysStillStandingAchievementCheck();
			}
		}
		catch
		{
			Debug.Log("Failed to find a pickuppable script attached to this object? Weird. Ignoring.");
		}
	}

	public void OpenStarDoor()
	{
		if (hasOpenedDoor)
		{
			return;
		}
		hasOpenedDoor = true;
		anim.Play("StarDoor_Open", -1, 0f);
		AudioManager.Singleton.PlayStarRoomAmbience();
		if (!keyThatTouchedUs)
		{
			return;
		}
		try
		{
			if (keyThatTouchedUs.GetComponent<PickUppable>().isHeld)
			{
				GameManager.Singleton.playerObject.GetComponent<PlayerGrabber>().ClearItemInHand();
			}
		}
		catch
		{
		}
		keyThatTouchedUs.SetActive(value: false);
	}

	public void PlayAudio_KeyTurn()
	{
		audioSource.PlayOneShot(audio_KeyTurn, AudioManager.Singleton.sfxVolume * 1.7f);
	}

	public void PlayAudio_DoorOpen()
	{
		audioSource.PlayOneShot(audio_DoorOpen, AudioManager.Singleton.sfxVolume * 1.7f);
	}

	private void AllWaysStillStandingAchievementCheck()
	{
		int num = 0;
		foreach (BreakableWall walls_Master in GameManager.Singleton.walls_MasterList)
		{
			if ((bool)walls_Master && walls_Master.gameObject.activeSelf)
			{
				num++;
			}
		}
		if (num == GameManager.Singleton.walls_MasterList.Count && !AchievementHelper.IsAchievementUnlocked("ACH_OpenStarDoorWithoutBreakingWalls"))
		{
			AchievementHelper.UnlockAchievement("ACH_OpenStarDoorWithoutBreakingWalls");
		}
	}
}
