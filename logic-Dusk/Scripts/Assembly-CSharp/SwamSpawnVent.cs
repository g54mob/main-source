using UnityEngine;

public class SwamSpawnVent : RoomItem
{
	private float timeAtNextSpawn;

	private float timer;

	public bool benign;

	private int enemiesReleased;

	private bool forceOverlayVisible;

	public override string ItemName
	{
		get
		{
			return "Vent";
		}
	}

	public override void Awake()
	{
		timeAtNextSpawn = Random.Range(150f, 600f);
		base.Awake();
	}

	public override void Start()
	{
		base.Start();
		if (droneViewModel != null)
		{
			Transform[] components = droneViewModel.GetComponents<Transform>();
			Transform[] array = components;
			foreach (Transform transform in array)
			{
				transform.FindChild("vent").gameObject.GetComponent<Renderer>().material.color = ActiveColor;
			}
		}
	}

	public override void Update()
	{
		if (!benign && !GlobalSettings.IsGamePaused && !GlobalSettings.GameIsOver && GlobalSettings.MissionStarted && enemiesReleased < 20)
		{
			timer += Time.deltaTime;
			if (timer >= timeAtNextSpawn)
			{
				timer = 0f;
				timeAtNextSpawn = Random.Range(150f, 600f);
				int num = 20;
				if (Random.Range(0, 100) < 30)
				{
					num = 10;
				}
				if (enemiesReleased + num > 20)
				{
					num = 20 - enemiesReleased;
				}
				enemiesReleased += num;
				SwarmManager swarmManager = EnemyManager.Instance.SpawnSwarm(base.transform.position, num, base.roomLocation);
				swarmManager.NavigateToRoomMainWaypoint(base.roomLocation);
			}
		}
		if (forceOverlayVisible && droneUIObject != null)
		{
			droneUIObject.MakeVisible();
			forceOverlayVisible = false;
		}
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone || GlobalSettings.GameIsOver || GlobalSettings.cheatMode)
		{
			GetComponent<Renderer>().enabled = show;
			if (droneViewModel != null)
			{
				droneViewModel.SetActive(show);
			}
		}
		else
		{
			GetComponent<Renderer>().enabled = false;
			if (droneViewModel != null)
			{
				droneViewModel.SetActive(false);
			}
		}
	}

	public void ForceOverlayVisibleAtNextUpdate()
	{
		forceOverlayVisible = true;
	}
}
