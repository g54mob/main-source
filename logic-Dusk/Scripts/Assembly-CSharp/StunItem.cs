using UnityEngine;

public class StunItem : DropableItem, IUpdateCameraView
{
	public Material normalMtl;

	public Material detonatedMtl;

	public AudioSource stunSound;

	private EnemyManager enemyManager;

	private DroneManager droneManager;

	private float timer;

	private float timeSinceTripped;

	public override DropItemType DropType
	{
		get
		{
			return DropItemType.StunBomb;
		}
	}

	public bool IsArmed { get; private set; }

	public bool IsTripped { get; set; }

	public Room CurrentRoom { get; private set; }

	public void Initialize(Room room, Drone drone)
	{
		CurrentRoom = room;
	}

	public override void Start()
	{
		base.Start();
		enemyManager = EnemyManager.Instance;
		droneManager = DroneManager.Instance;
		GetComponent<Renderer>().material = normalMtl;
	}

	protected override void Update()
	{
		if (!GlobalSettings.IsGamePaused && !base.Destroyed)
		{
			timer += Time.deltaTime;
			if (timer < 0.5f)
			{
				GetComponent<Renderer>().material = detonatedMtl;
			}
			else if (timer < 1f)
			{
				GetComponent<Renderer>().material = normalMtl;
			}
			else
			{
				timer = 0f;
			}
			if (IsTripped && !IsArmed)
			{
				timeSinceTripped += Time.deltaTime;
				if (timeSinceTripped >= 0.5f)
				{
					timeSinceTripped = 0f;
					IsArmed = true;
				}
			}
		}
		base.Update();
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (droneUIObject != null)
			{
				GetComponent<Renderer>().enabled = !droneUIObject.Deactivated;
			}
			if (base.Destroyed)
			{
				GetComponent<Renderer>().material = detonatedMtl;
			}
			else
			{
				GetComponent<Renderer>().material = normalMtl;
			}
		}
		else
		{
			GetComponent<Renderer>().enabled = false;
			if (stunSound.isPlaying)
			{
				stunSound.Stop();
			}
		}
		base.UpdateCameraView();
	}

	public void Detonate()
	{
		if (base.Destroyed)
		{
			return;
		}
		int num = 0;
		base.Destroyed = true;
		GameAudio.Play2DSFX(GameAudio.SoundEnum.WeaponTriggered);
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			stunSound.volume = GameAudio.RemoteVolume * 1f;
			stunSound.Play();
		}
		SetDead();
		GetComponent<Renderer>().material = detonatedMtl;
		int count = CurrentRoom.corridors.Count;
		for (int i = 0; i < count; i++)
		{
			Corridor corridor = CurrentRoom.corridors[i];
			if (corridor.knownEnemiesList != null)
			{
				int count2 = corridor.knownEnemiesList.Count;
				for (int j = 0; j < count2; j++)
				{
					BaseEnemy baseEnemy = corridor.knownEnemiesList[j];
					baseEnemy.Stun(20f, 35f);
					num++;
				}
			}
		}
		if (CurrentRoom.knownEnemiesList != null)
		{
			int count3 = CurrentRoom.knownEnemiesList.Count;
			for (int k = 0; k < count3; k++)
			{
				BaseEnemy baseEnemy2 = CurrentRoom.knownEnemiesList[k];
				baseEnemy2.Stun(20f, 35f);
				num++;
			}
		}
		foreach (Drone drones in droneManager.dronesList)
		{
			if (drones.CurrentRoom == CurrentRoom && Random.Range(0f, 1f) < 1f)
			{
				drones.Stun(5f, 12f);
			}
		}
		CurrentRoom.StunInRoom(10f, 12f);
	}
}
