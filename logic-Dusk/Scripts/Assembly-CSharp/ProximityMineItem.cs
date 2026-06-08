using System;
using System.Linq;
using UnityEngine;

public class ProximityMineItem : DropableItem
{
	public Material normalMtl;

	public Material detonatedMtl;

	public AudioSource explosionSound;

	public AudioClip[] explosionSoundArray;

	private EnemyManager enemyManager;

	private DroneManager droneManager;

	private float timer;

	private float timeSinceTripped;

	public override DropItemType DropType
	{
		get
		{
			return DropItemType.ProximityMine;
		}
	}

	public bool IsArmed { get; private set; }

	public bool IsTripped { get; set; }

	public Room CurrentRoom { get; private set; }

	public void Initialize(Room room, Drone drone)
	{
		CurrentRoom = room;
	}

	private void Awake()
	{
		int num = UnityEngine.Random.Range(0, explosionSoundArray.Length);
		explosionSound.clip = explosionSoundArray[num];
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
		}
	}

	public void Detonate()
	{
		if (base.Destroyed)
		{
			return;
		}
		IsTripped = false;
		IsArmed = false;
		base.Destroyed = true;
		GameAudio.Play2DSFX(GameAudio.SoundEnum.WeaponTriggered);
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			explosionSound.volume = GameAudio.RemoteVolume * 1f;
			explosionSound.Play();
		}
		SetDead();
		SystemMessageManager.ShowSystemMessage("Proximity mine detonated", ConsoleMessageType.Info);
		int num = 0;
		int num2 = 0;
		GetComponent<Renderer>().material = detonatedMtl;
		float num3 = 225f;
		if (enemyManager == null)
		{
			enemyManager = EnemyManager.Instance;
		}
		foreach (BaseEnemy enemy in enemyManager.Enemies)
		{
			bool flag = enemy.CurrentRoom == CurrentRoom;
			bool flag2 = enemy.CurrentRoom == null && enemy.CurrentCorridor != null && enemy.CurrentCorridor.rooms.Any((Room x) => x == CurrentRoom);
			if (flag || flag2)
			{
				if (UnityEngine.Random.Range(0f, 1f) < 1f)
				{
					enemy.TakeDamage(CommonMethods.SplashDamage(num3, base.transform.position, enemy.Position), DamageType.Physical, null);
					num++;
				}
				else
				{
					num2++;
				}
			}
		}
		foreach (Drone drones in droneManager.dronesList)
		{
			bool flag3 = drones.CurrentRoom == CurrentRoom;
			bool flag4 = drones.CurrentRoom == null && drones.CurrentCorridor != null && drones.CurrentCorridor.rooms.Any((Room x) => x == CurrentRoom);
			if ((flag3 || flag4) && UnityEngine.Random.Range(0f, 1f) < 1f)
			{
				float num4 = CommonMethods.SplashDamage(num3, base.transform.position, drones.Position);
				num4 = (float)Math.Round(num4, 0);
				drones.TakeDamage(num4, DamageType.Physical, null);
			}
		}
		if (CurrentRoom != null)
		{
			CurrentRoom.ExplosionInRoom(num3, DamageType.Splash, base.transform.position);
		}
	}
}
