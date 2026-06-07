using System.Collections;
using System.Collections.Generic;
using Mirror;
using OutlineFx;
using TMPro;
using UnityEngine;

public class ShelfManager : NetworkBehaviour
{
	public ShelfItemManager[] shelfItemManagers;

	public LayerMask dragItemLayer;

	public LayerMask dragPlaneLayer;

	public LayerMask shelfItemLayer;

	private global::OutlineFx.OutlineFx curOutline;

	public Transform primaryPos;

	public Transform secondaryPos;

	public GameObject[] productObjs;

	public Transform camTarg;

	public AudioSource completeSfx;

	public GameObject canvas;

	public float initialQueueLength;

	public InventoryManager inventoryMan;

	public RestockShelf restockShelf;

	public Animator boxAnim;

	public CameraTranslation camTranslation;

	public TextMeshProUGUI amountText;

	public int amountOfItems;

	public Collider[] itemColliders;

	public Transform mainProduct;

	private Transform curDragItem;

	private int curDragIndex;

	private bool hovering;

	private bool dragging;

	private bool inMenu = true;

	public Camera cam;

	private bool justHovered;

	private ShelfItemManager lastShelfItem;

	private ShelfItemManager lastWrongShelfItem;

	private Queue<GameObject> productsQueue = new Queue<GameObject>();

	public GameObject finishBoxParticles;

	private int fullAmountOfItemsInShelf;

	public GameObject dragTooltip;

	private void Start()
	{
		ShelfItemManager[] array = shelfItemManagers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].shelfMan = this;
		}
	}

	private void OnEnable()
	{
		dragging = false;
		canvas.SetActive(value: false);
		dragTooltip.SetActive(value: false);
		dragTooltip.SetActive(value: true);
		amountText.gameObject.SetActive(value: true);
		Collider[] array = itemColliders;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = true;
		}
		amountOfItems = restockShelf.curPlayerMan.inventoryMan.crateStorages[restockShelf.curPlayerMan.inventoryMan.curInventorySlot];
		InitObjectQueue();
		StartCoroutine(MoveCamToPosition());
	}

	private void OnDisable()
	{
		Collider[] array = itemColliders;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
		restockShelf.curPlayerMan.inventoryMan.ChangePlayerCrateStorage(restockShelf.curPlayerMan.inventoryMan.curInventorySlot, amountOfItems);
	}

	private void InitObjectQueue()
	{
		int num = amountOfItems;
		if (num == 0)
		{
			num = 15;
		}
		amountText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		amountText.text = num.ToString();
		while (productsQueue.Count > 0)
		{
			Object.Destroy(productsQueue.Dequeue());
		}
		for (int i = 0; i < shelfItemManagers.Length; i++)
		{
			for (int j = 0; j < 4 - shelfItemManagers[i].products.Count; j++)
			{
				productsQueue.Enqueue(Object.Instantiate(productObjs[i], base.transform.position, primaryPos.rotation));
			}
		}
		List<GameObject> list = new List<GameObject>(productsQueue);
		for (int num2 = list.Count - 1; num2 > 0; num2--)
		{
			int index = Random.Range(0, num2 + 1);
			GameObject value = list[num2];
			list[num2] = list[index];
			list[index] = value;
		}
		productsQueue.Clear();
		foreach (GameObject item in list)
		{
			productsQueue.Enqueue(item);
			item.SetActive(value: false);
		}
		initialQueueLength = productsQueue.Count;
		if (productsQueue.Count >= 2)
		{
			GameObject[] array = productsQueue.ToArray();
			array[0].SetActive(value: true);
			array[0].GetComponent<DragItem>().col.enabled = true;
			curDragIndex = array[0].GetComponent<DragItem>().itemIndex;
			array[0].transform.position = primaryPos.position;
			if (amountOfItems > 1)
			{
				array[1].SetActive(value: true);
				array[1].transform.position = secondaryPos.position;
			}
			mainProduct = array[0].transform;
		}
		else if (productsQueue.Count == 1)
		{
			GameObject[] array2 = productsQueue.ToArray();
			array2[0].SetActive(value: true);
			array2[0].transform.position = primaryPos.position;
			array2[0].GetComponent<DragItem>().col.enabled = true;
			curDragIndex = array2[0].GetComponent<DragItem>().itemIndex;
			mainProduct = array2[0].transform;
		}
		else
		{
			restockShelf.Invoke("StopInteract", 0.01f);
			restockShelf.Invoke("StopLookAt", 0.03f);
			StoreManager.Instance.SetAlert("Shelf already full!", "red");
		}
		StopCoroutine(SwapProductPos());
		StartCoroutine(SwapProductPos());
	}

	private void Update()
	{
		cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, camTarg.rotation, Time.deltaTime * 13f);
		if (!dragging && productsQueue.Count > 0)
		{
			ShootRay();
		}
		else if (dragging)
		{
			DragItem();
		}
	}

	private IEnumerator MoveCamToPosition()
	{
		cam.transform.position = Vector3.Lerp(cam.transform.position, camTarg.position, Time.deltaTime * 13f);
		if (Vector3.Distance(cam.transform.position, camTarg.position) < 0.2f)
		{
			camTranslation.started = true;
		}
		else
		{
			yield return null;
		}
	}

	private void ShootRay()
	{
		if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hitInfo, 30f, dragItemLayer))
		{
			curOutline = hitInfo.collider.GetComponent<global::OutlineFx.OutlineFx>();
			curOutline.enabled = true;
			if (Input.GetButtonDown("Fire1"))
			{
				dragging = true;
				curDragItem = curOutline.transform;
				curDragItem.gameObject.GetComponent<AudioSource>().Play();
				curOutline.enabled = false;
				curOutline = null;
			}
		}
		else if (curOutline != null)
		{
			curOutline.enabled = false;
			curOutline = null;
		}
		mainProduct.position = Vector3.Lerp(mainProduct.position, primaryPos.position, Time.deltaTime * 15f);
		mainProduct.eulerAngles = new Vector3(mainProduct.eulerAngles.x, mainProduct.eulerAngles.y, 0f);
	}

	private void DragItem()
	{
		if (!curDragItem)
		{
			return;
		}
		if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hitInfo, 30f, dragPlaneLayer))
		{
			curDragItem.position = Vector3.Lerp(curDragItem.position, hitInfo.point, Time.deltaTime * 15f);
			curDragItem.eulerAngles = new Vector3(curDragItem.eulerAngles.x, curDragItem.eulerAngles.y, (curDragItem.position.x - hitInfo.point.x) * 90f);
		}
		ShelfItemManager[] array = shelfItemManagers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].outline.enabled = false;
		}
		if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hitInfo2, 30f, shelfItemLayer))
		{
			ShelfItemManager componentInParent = hitInfo2.collider.GetComponentInParent<ShelfItemManager>();
			if (componentInParent.itemIndex == curDragIndex && componentInParent != lastShelfItem)
			{
				lastShelfItem = componentInParent;
				componentInParent.Hover(curDragItem.position);
				curDragItem.gameObject.SetActive(value: false);
				hovering = true;
				justHovered = true;
				if (lastWrongShelfItem != null)
				{
					lastWrongShelfItem.outline.enabled = false;
					lastWrongShelfItem = null;
				}
			}
			else if (componentInParent.itemIndex != curDragIndex)
			{
				hovering = false;
				lastWrongShelfItem = componentInParent;
				componentInParent.outline._color = Color.red;
				componentInParent.outline.enabled = true;
			}
		}
		else if (justHovered)
		{
			hovering = false;
			justHovered = false;
			if (lastShelfItem != null)
			{
				lastShelfItem.Unhover();
				lastShelfItem = null;
				curDragItem.gameObject.SetActive(value: true);
			}
		}
		else if (lastWrongShelfItem != null)
		{
			lastWrongShelfItem.outline.enabled = false;
			lastWrongShelfItem = null;
		}
		if (Input.GetButtonUp("Fire1"))
		{
			if (hovering)
			{
				hovering = false;
				CompleteItem();
			}
			else
			{
				dragging = false;
			}
			if (lastWrongShelfItem != null)
			{
				lastWrongShelfItem.outline.enabled = false;
				lastWrongShelfItem = null;
			}
		}
	}

	private void CompleteItem()
	{
		StoreManager.Instance.ChangeRevenue("Stocked Item", 1f);
		if (base.isServer)
		{
			lastShelfItem.AddItemRpc(autoSort: false);
		}
		else
		{
			lastShelfItem.AddItem(autoSort: false);
		}
		dragTooltip.GetComponent<Animator>().SetTrigger("End");
		completeSfx.Play();
		dragging = false;
		lastShelfItem.outline.enabled = false;
		lastShelfItem = null;
		Object.Destroy(productsQueue.Dequeue());
		amountOfItems--;
		if (amountOfItems < 0)
		{
			amountOfItems = 15;
		}
		amountText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		amountText.text = amountOfItems.ToString();
		if (amountOfItems == 0)
		{
			while (productsQueue.Count > 0)
			{
				Object.Destroy(productsQueue.Dequeue());
			}
			amountText.gameObject.SetActive(value: false);
			boxAnim.SetTrigger("Finish");
			inventoryMan.Invoke("DestroyObject", 2f);
			restockShelf.Invoke("StopInteract", 1.99f);
			restockShelf.Invoke("StopLookAt", 2.01f);
			restockShelf.RecalculateProducts();
			return;
		}
		if (productsQueue.Count >= 2)
		{
			GameObject[] array = productsQueue.ToArray();
			array[0].SetActive(value: true);
			array[0].GetComponent<DragItem>().col.enabled = true;
			curDragIndex = array[0].GetComponent<DragItem>().itemIndex;
			if (amountOfItems > 1)
			{
				array[1].SetActive(value: true);
				array[1].transform.position = new Vector3(secondaryPos.position.x, secondaryPos.position.y - 1f, secondaryPos.position.z);
			}
			mainProduct = array[0].transform;
		}
		else if (productsQueue.Count == 1)
		{
			GameObject[] array2 = productsQueue.ToArray();
			array2[0].GetComponent<DragItem>().col.enabled = true;
			curDragIndex = array2[0].GetComponent<DragItem>().itemIndex;
			mainProduct = array2[0].transform;
		}
		else
		{
			restockShelf.FinishedStocking();
			restockShelf.Invoke("StopInteract", 0.49f);
			restockShelf.Invoke("StopLookAt", 0.51f);
		}
		StopCoroutine(SwapProductPos());
		StartCoroutine(SwapProductPos());
		restockShelf.RecalculateProducts();
	}

	private IEnumerator SwapProductPos()
	{
		float elapsedTime = 0f;
		while (elapsedTime < 0.2f)
		{
			GameObject[] array = productsQueue.ToArray();
			if (array.Length >= 1)
			{
				array[0].transform.position = Vector3.Lerp(array[0].transform.position, primaryPos.position, Time.deltaTime * 13f);
				if (array.Length >= 2)
				{
					array[1].transform.position = Vector3.Lerp(array[1].transform.position, secondaryPos.position, Time.deltaTime * 13f);
				}
			}
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	public void RemoveRandomItems(int amountOfItems)
	{
		if (ClientPlayer.Instance.isServer)
		{
			Queue<int> queue = new Queue<int>();
			for (int i = 0; i < amountOfItems; i++)
			{
				int item = Random.Range(0, shelfItemManagers.Length);
				queue.Enqueue(item);
			}
			while (queue.Count > 0)
			{
				int num = queue.Dequeue();
				shelfItemManagers[num].ServerRemoveItem();
			}
			restockShelf.Invoke("RecalculateProducts", 0.3f);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
