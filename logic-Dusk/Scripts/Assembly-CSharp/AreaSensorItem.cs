using UnityEngine;

public class AreaSensorItem : MonoBehaviour, IToggleVisibilityInSchematic, IUpdateCameraView
{
	public Color ActiveColor = Color.white;

	public Color InactiveColor = Color.white;

	public float IconScaleDV = 1f;

	public float IconScaleSV = 1.5f;

	private Room room;

	private EnemyManager enemyManager;

	private bool enemiesDetected;

	private float direction = 1f;

	private DroneUIObject droneUIObject;

	private GameObject dvOverlayObject;

	private GameObject svOverlayObject;

	public bool IsEnabled { get; set; }

	public bool IsInvisibleDueToToggle { get; set; }

	public void Initialize(Room room)
	{
		this.room = room;
		enemiesDetected = false;
		IsEnabled = base.transform;
		UpdateCameraView();
		SetVisible();
	}

	private void Start()
	{
		enemyManager = EnemyManager.Instance;
		Transform transform = base.transform.Find("DroneUI");
		if (transform != null)
		{
			droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
		}
		transform = base.transform.Find("DVOverlay");
		if (transform != null)
		{
			dvOverlayObject = transform.gameObject;
		}
		transform = base.transform.Find("SVOverlay");
		if (transform != null)
		{
			svOverlayObject = transform.gameObject;
		}
		GetComponent<Renderer>().material.color = ActiveColor;
		if (dvOverlayObject != null)
		{
			dvOverlayObject.GetComponent<Renderer>().material.color = InactiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObject.GetComponent<Renderer>().material.color = InactiveColor;
		}
	}

	private void Update()
	{
		if (GlobalSettings.IsGamePaused || !IsEnabled)
		{
			return;
		}
		bool flag = enemiesDetected;
		enemiesDetected = false;
		foreach (BaseEnemy enemy in enemyManager.Enemies)
		{
			if (enemy.CurrentRoom == room && !enemy.IsDead && enemy.GetType() != typeof(SlimeEnemy))
			{
				enemiesDetected = true;
				break;
			}
		}
		if (enemiesDetected != flag)
		{
			if (enemiesDetected)
			{
				SystemMessageManager.ShowSystemMessage("Sensor Activated: " + room.Label, ConsoleMessageType.TriggerActivatedWarning, SystemMessageImageType.SensorNotify);
				SetActive();
			}
			else
			{
				SystemMessageManager.ShowSystemMessage("Sensor Deactivated: " + room.Label, ConsoleMessageType.TriggerDeactivatedWarning, SystemMessageImageType.SensorNotify);
				SetInactive();
			}
		}
		if (enemiesDetected)
		{
			base.transform.Rotate(0f, 0f, 300f * Time.deltaTime * direction);
		}
		else
		{
			base.transform.Rotate(0f, 0f, 100f * Time.deltaTime * direction);
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			base.transform.localScale = Vector3.one * IconScaleDV;
		}
		else
		{
			base.transform.localScale = Vector3.one * IconScaleSV;
		}
	}

	public void UpdateCameraView()
	{
	}

	public void SetSchematicVisibility(bool show)
	{
		if (!show && GetComponent<Renderer>().enabled)
		{
			GetComponent<Renderer>().enabled = false;
			IsInvisibleDueToToggle = true;
		}
		else if (show && IsInvisibleDueToToggle && !GetComponent<Renderer>().enabled)
		{
			GetComponent<Renderer>().enabled = true;
			IsInvisibleDueToToggle = false;
		}
	}

	private void SetActive()
	{
		GetComponent<Renderer>().material.color = ActiveColor;
		if (dvOverlayObject != null)
		{
			dvOverlayObject.GetComponent<Renderer>().material.color = ActiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObject.GetComponent<Renderer>().material.color = ActiveColor;
		}
	}

	private void SetInactive()
	{
		GetComponent<Renderer>().material.color = InactiveColor;
		if (dvOverlayObject != null)
		{
			dvOverlayObject.GetComponent<Renderer>().material.color = InactiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObject.GetComponent<Renderer>().material.color = InactiveColor;
		}
	}

	public void SetHidden()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivated = true;
		}
		GetComponent<Renderer>().enabled = false;
		if (dvOverlayObject != null)
		{
			dvOverlayObject.GetComponent<Renderer>().enabled = false;
		}
		if (svOverlayObject != null)
		{
			svOverlayObject.GetComponent<Renderer>().enabled = false;
		}
	}

	public void SetVisible()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivated = false;
		}
		if (dvOverlayObject != null)
		{
			dvOverlayObject.GetComponent<Renderer>().enabled = true;
		}
		if (svOverlayObject != null)
		{
			svOverlayObject.GetComponent<Renderer>().enabled = true;
		}
	}
}
