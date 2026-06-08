using UnityEngine;

public class ScannableObject : MonoBehaviour, IUpdateCameraView
{
	public GameObject scanGhostPrefab;

	private GameObject scanGhost;

	private bool scanned;

	public bool display;

	private void Start()
	{
		scanGhost = (GameObject)Object.Instantiate(scanGhostPrefab, base.transform.position, Quaternion.identity);
		UpdateCameraView();
	}

	private void Update()
	{
	}

	public void ScanTriggered(Room room)
	{
		ICombatTarget combatTarget = (ICombatTarget)GetComponent(typeof(ICombatTarget));
		if (combatTarget != null && combatTarget.CurrentRoom == room)
		{
			if (scanGhost == null && scanGhostPrefab != null)
			{
				scanGhost = (GameObject)Object.Instantiate(scanGhostPrefab, base.transform.position, Quaternion.identity);
			}
			scanGhost.transform.position = base.transform.position;
			scanned = true;
			display = scanned && !combatTarget.IsDead;
			scanGhost.GetComponent<Renderer>().enabled = display;
		}
	}

	public void UpdateCameraView()
	{
		if (scanGhost != null)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				scanGhost.GetComponent<Renderer>().enabled = false;
			}
			else
			{
				scanGhost.GetComponent<Renderer>().enabled = display;
			}
		}
	}
}
