using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField]
	private Camera mainCamera;

	[SerializeField]
	private Camera inventoryCamera;

	[SerializeField]
	private GameObject MainUIObj;

	[SerializeField]
	private GameObject InventoryUIObj;

	[Header("Text UI")]
	[SerializeField]
	private TMP_Text itemName;

	[SerializeField]
	private TMP_Text itemInfo;

	[SerializeField]
	private GameObject textPanel;

	[Header("Inventory Settings")]
	[SerializeField]
	private Transform pivot;

	[SerializeField]
	private GameObject[] objects;

	[SerializeField]
	private GameObject[] newObjects;

	[SerializeField]
	private float radius = 2.5f;

	[SerializeField]
	private float rotationSpeed = 1.5f;

	[SerializeField]
	private float selectedRotationSpeed = 50f;

	private FirstPersonController firstPersonController;

	private PauseMenu pauseMenu;

	private List<Vector3> positions = new List<Vector3>();

	private List<Quaternion> defaultRotations = new List<Quaternion>();

	private bool isRotating;

	private int currentSelected;

	private void Start()
	{
		firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
		pauseMenu = Object.FindAnyObjectByType<PauseMenu>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		mainCamera.enabled = true;
		inventoryCamera.enabled = false;
		ArrangeObjectsInCircle();
		InventoryUIObj.SetActive(value: false);
		GameObject[] array = objects;
		foreach (GameObject gameObject in array)
		{
			defaultRotations.Add(gameObject.transform.rotation);
		}
		UpdateInventoryUI();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			ToggleCamera();
		}
		if (Input.GetKeyDown(KeyCode.Escape) && InventoryUIObj.activeInHierarchy)
		{
			ExitInventory();
		}
		if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !isRotating)
		{
			StartCoroutine(RotateInventory(-1));
		}
		if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !isRotating)
		{
			StartCoroutine(RotateInventory(1));
		}
		if (objects.Length != 0 && !isRotating)
		{
			Vector3 eulerAngles = objects[currentSelected].transform.rotation.eulerAngles;
			eulerAngles.y += selectedRotationSpeed * Time.unscaledDeltaTime;
			objects[currentSelected].transform.rotation = Quaternion.Euler(eulerAngles);
		}
	}

	public void ToggleCamera()
	{
		if (!pauseMenu.isPaused)
		{
			if (firstPersonController.enabled)
			{
				firstPersonController.DisableInput();
			}
			else
			{
				firstPersonController.EnableInput();
			}
		}
		firstPersonController.enabled = !firstPersonController.enabled;
		mainCamera.enabled = !mainCamera.enabled;
		inventoryCamera.enabled = !inventoryCamera.enabled;
		if (MainUIObj.activeInHierarchy)
		{
			MainUIObj.SetActive(value: false);
			InventoryUIObj.SetActive(value: true);
			Time.timeScale = 0f;
			ChangeUIText(objects[currentSelected]);
			if (itemName.text == "None")
			{
				textPanel.SetActive(value: false);
			}
			else
			{
				textPanel.SetActive(value: true);
			}
		}
		else
		{
			if (pauseMenu.isPaused)
			{
				pauseMenu.ResumeGame();
			}
			MainUIObj.SetActive(value: true);
			InventoryUIObj.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}

	private void ExitInventory()
	{
		firstPersonController.enabled = !firstPersonController.enabled;
		mainCamera.enabled = !mainCamera.enabled;
		inventoryCamera.enabled = !inventoryCamera.enabled;
		MainUIObj.SetActive(value: true);
		InventoryUIObj.SetActive(value: false);
		if (!pauseMenu.isPaused)
		{
			firstPersonController.EnableInput();
			Time.timeScale = 1f;
		}
	}

	private void ArrangeObjectsInCircle()
	{
		positions.Clear();
		int num = objects.Length;
		float num2 = 360f / (float)num;
		Vector3 vector = pivot.position - pivot.forward * radius;
		positions.Add(vector);
		objects[0].transform.position = vector;
		ChangeUIText(objects[0]);
		for (int i = 1; i < num; i++)
		{
			float y = (float)i * num2;
			Vector3 vector2 = Quaternion.Euler(0f, y, 0f) * (vector - pivot.position) + pivot.position;
			positions.Add(vector2);
			objects[i].transform.position = vector2;
		}
	}

	private IEnumerator RotateInventory(int direction)
	{
		isRotating = true;
		List<Vector3> newPositions = new List<Vector3>();
		for (int i = 0; i < objects.Length; i++)
		{
			int index = (i + direction + objects.Length) % objects.Length;
			newPositions.Add(positions[index]);
		}
		ShowInfoUI(show: false);
		objects[currentSelected].transform.rotation = defaultRotations[currentSelected];
		float t = 0f;
		while (t < 1f)
		{
			t += Time.unscaledDeltaTime * rotationSpeed;
			for (int j = 0; j < objects.Length; j++)
			{
				objects[j].transform.position = Vector3.Lerp(objects[j].transform.position, newPositions[j], t);
			}
			yield return null;
		}
		for (int k = 0; k < objects.Length; k++)
		{
			objects[k].transform.position = newPositions[k];
		}
		positions = newPositions;
		isRotating = false;
		currentSelected = (currentSelected + -direction + objects.Length) % objects.Length;
		ChangeUIText(objects[currentSelected]);
		ShowInfoUI(show: true);
	}

	public void UpdateInventoryUI()
	{
		for (int i = 0; i < InventoryManager.Instance.inventoryItems.Count; i++)
		{
			string text = InventoryManager.Instance.inventoryItems[i];
			GameObject[] array = newObjects;
			foreach (GameObject gameObject in array)
			{
				if (gameObject.GetComponent<StoryClueInfo>().ReturnName() == text)
				{
					Object.Destroy(objects[i]);
					defaultRotations[i] = gameObject.transform.rotation;
					objects[i] = Object.Instantiate(gameObject, positions[i], defaultRotations[i], pivot.parent);
					break;
				}
			}
		}
		if (objects.Length != 0)
		{
			ChangeUIText(objects[currentSelected]);
		}
	}

	private void ChangeUIText(GameObject storyclue)
	{
		itemName.text = storyclue.GetComponent<StoryClueInfo>().ReturnName();
		itemInfo.text = storyclue.GetComponent<StoryClueInfo>().ReturnTextInfo();
	}

	private void ShowInfoUI(bool show)
	{
		itemName.enabled = show;
		itemInfo.enabled = show;
		if (itemName.text == "None")
		{
			textPanel.SetActive(value: false);
		}
		else
		{
			textPanel.SetActive(value: true);
		}
	}
}
