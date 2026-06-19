using ClockStone;
using UnityEngine;

public class InteractableMusicPlayer : InteractableBase
{
	public string musicToPlay;

	public ParticleSystem particleRef;

	public GameObject spinnerRef;

	public Vector3 rotationSpeed;

	public GameObject moverRef;

	public Vector3 movDist;

	public float movSpeed = 10f;

	private bool turnedOn;

	private bool registered;

	private AudioObject soundObject;

	private bool muted;

	private RoomBase associatedRoom;

	private MusicPlaylistController musicRef;

	private void Start()
	{
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		ulong? num = GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!num.HasValue)
		{
			Debug.LogError("No valid room found for Music Player.");
			num = 0uL;
		}
		associatedRoom = globalComponent.GetRoomForUID(num.Value);
		musicRef = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>();
		if (turnedOn && !registered)
		{
			registered = true;
			musicRef.RegisterActiveMusicPlayer(this);
			if (associatedRoom != null)
			{
				associatedRoom.AddMusicPlayer();
			}
			if (particleRef != null)
			{
				particleRef.Play();
			}
		}
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		saveableObject.boolList.Add(turnedOn);
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		if (saveableObject.boolList.Count != 0)
		{
			if (saveableObject.boolList[0])
			{
				TurnOn();
			}
			else
			{
				TurnOff();
			}
		}
	}

	private void Awake()
	{
		TurnOff();
	}

	private void OnDestroy()
	{
		if (soundObject != null)
		{
			soundObject.Stop();
			soundObject = null;
		}
		if (turnedOn)
		{
			if (musicRef != null)
			{
				musicRef.UnregisterActiveMusicPlayer(this);
			}
			if (associatedRoom != null)
			{
				associatedRoom.RemoveMusicPlayer();
			}
		}
	}

	private void Update()
	{
		if (turnedOn)
		{
			if (spinnerRef != null)
			{
				spinnerRef.transform.Rotate(rotationSpeed * Time.deltaTime);
			}
			if (moverRef != null)
			{
				moverRef.transform.localPosition = Mathf.Sin(Time.timeSinceLevelLoad * movSpeed) * movDist;
			}
		}
	}

	public void ToggleState()
	{
		if (!turnedOn)
		{
			TurnOn();
		}
		else
		{
			TurnOff();
		}
	}

	public bool IsCurrentlyOn()
	{
		return turnedOn;
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		ToggleState();
	}

	public void Mute()
	{
		if (soundObject != null && !muted)
		{
			muted = true;
			soundObject.Pause();
		}
	}

	public void Unmute()
	{
		if (soundObject != null && muted)
		{
			muted = false;
			soundObject.Unpause();
			if (particleRef != null)
			{
				particleRef.Play();
			}
		}
	}

	public void TurnOn()
	{
		turnedOn = true;
		if (soundObject == null)
		{
			soundObject = AudioController.Play(musicToPlay, base.transform);
		}
		if (musicRef != null && !registered)
		{
			registered = true;
			musicRef.RegisterActiveMusicPlayer(this);
			if (associatedRoom != null)
			{
				associatedRoom.AddMusicPlayer();
			}
		}
		if (particleRef != null)
		{
			particleRef.Play();
		}
	}

	public void TurnOff()
	{
		turnedOn = false;
		if (soundObject != null)
		{
			soundObject.Stop();
			soundObject = null;
		}
		if (musicRef != null && registered)
		{
			registered = false;
			musicRef.UnregisterActiveMusicPlayer(this);
			if (associatedRoom != null)
			{
				associatedRoom.RemoveMusicPlayer();
			}
		}
		if (particleRef != null)
		{
			particleRef.Stop();
		}
	}
}
