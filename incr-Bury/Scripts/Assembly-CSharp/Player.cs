using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player Singleton;

	[SerializeField]
	private GameObject autoCoinPickUpTriggerSphere;

	private bool hasFallenIntoHole;

	[SerializeField]
	private GameObject flashlight;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		Flashlight_TurnOff();
	}

	private void Update()
	{
		HandleMouseCursor();
		HandleFallingIntoHole();
	}

	private void HandleMouseCursor()
	{
		if (GenericMenuManager.Singleton.menuState == GenericMenuManager.MenuState.idle)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (GenericMenuManager.Singleton.menuState == GenericMenuManager.MenuState.open)
		{
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		}
	}

	public void AutoCoinPickUpSphere_Enable()
	{
		autoCoinPickUpTriggerSphere.SetActive(value: true);
		autoCoinPickUpTriggerSphere.transform.localScale = Vector3.one * PlayerStats.Singleton.autoCoinPickUp_Radius_Current;
	}

	public void AutoCoinPickUpSphere_Disable()
	{
		autoCoinPickUpTriggerSphere.SetActive(value: false);
	}

	private void HandleFallingIntoHole()
	{
		if (!hasFallenIntoHole && base.transform.position.y < -8f && GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			FellIntoHole();
		}
	}

	private void FellIntoHole()
	{
		hasFallenIntoHole = true;
		if (GameManager.Singleton.hatchDoorEnvironment_IsActive)
		{
			CutscenesManager.Singleton.TeleportPlayerToEndGamePit();
		}
		else if (GameManager.Singleton.belladonnaBuddyEnding_IsActive)
		{
			GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
			base.transform.position = GameManager.Singleton.GetYardObject().transform.position + Vector3.up * 5f;
		}
		else
		{
			GameManager.Singleton.ForceEndRound(_fromBed: false);
		}
	}

	public void Flashlight_TurnOn()
	{
		flashlight.SetActive(value: true);
	}

	public void Flashlight_TurnOff()
	{
		flashlight.SetActive(value: false);
	}
}
