using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	[SerializeField]
	private LayerMask clickableMask;

	private GameObject currentUI;

	private void Awake()
	{
		instance = this;
	}

	public void SetNewUI(GameObject newUI)
	{
		if (currentUI != null)
		{
			Object.Destroy(currentUI);
		}
		currentUI = newUI;
	}

	public void CloseUI(GameObject oldUI)
	{
		currentUI = null;
		Object.Destroy(oldUI);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && currentUI != null)
		{
			CloseUI(currentUI);
		}
		if (!BuildingManager.instance.buildMode && Input.GetMouseButtonDown(0))
		{
			if (CameraController.instance.firstPersonMode && !Input.GetKey(KeyCode.LeftShift))
			{
				return;
			}
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 2000f, clickableMask, QueryTriggerInteraction.Collide))
			{
				hitInfo.collider.GetComponent<IBuildable>()?.SpawnUI();
			}
		}
		if (Input.GetMouseButtonDown(1))
		{
			CloseUI(currentUI);
		}
	}
}
