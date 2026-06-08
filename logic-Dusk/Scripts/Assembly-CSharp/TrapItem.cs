using UnityEngine;

public class TrapItem : DropableItem, IUpdateCameraView
{
	public Material normalMtl;

	public Material detonatedMtl;

	private float timer;

	public override DropItemType DropType
	{
		get
		{
			return DropItemType.Trap;
		}
	}

	public Room CurrentRoom { get; private set; }

	public void Initialize(Room room, Drone drone)
	{
		CurrentRoom = room;
	}

	public override void Start()
	{
		base.Start();
		GetComponent<Renderer>().material = normalMtl;
		if (base.Destroyed)
		{
			SetDead();
			GetComponent<Renderer>().material = detonatedMtl;
		}
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
		if (base.Destroyed || base.IsInSpace)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		base.Destroyed = true;
		GameAudio.Play2DSFX(GameAudio.SoundEnum.WeaponTriggered);
		SetDead();
		GetComponent<Renderer>().material = detonatedMtl;
		float damage = 1000f;
		foreach (BaseEnemy enemy in EnemyManager.Instance.Enemies)
		{
			if (enemy.CurrentRoom == CurrentRoom)
			{
				if (Random.Range(0f, 1f) < 1f)
				{
					enemy.TakeDamage(damage, DamageType.Physical, null);
					num++;
				}
				else
				{
					num2++;
				}
			}
		}
		foreach (Drone drones in DroneManager.Instance.dronesList)
		{
			if (drones.CurrentRoom == CurrentRoom && Random.Range(0f, 1f) < 1f)
			{
				drones.TakeDamage(damage, DamageType.Physical, null);
			}
		}
		CurrentRoom.ExplosionInRoom(damage);
	}
}
