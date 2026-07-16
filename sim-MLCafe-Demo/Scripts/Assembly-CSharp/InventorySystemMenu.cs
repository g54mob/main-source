using UnityEngine;

public class InventorySystemMenu : MonoBehaviour
{
	public enum InventoryMode
	{
		None = -1,
		OnlyToolbar = 0,
		OpenCharacterInventory = 1,
		OpenOtherInventory = 2
	}

	[SerializeField]
	private GameObject context;

	[SerializeField]
	private InventoryMenu characterToolbar;

	[SerializeField]
	private InventoryMenu characterBackpack;

	[SerializeField]
	private InventoryMenu itemInventory;

	private static InventorySystemMenu instance;

	private InventoryMode currentInventoryMode;

	public static InventoryMode GetCurrentInventoryMode()
	{
		return instance.currentInventoryMode;
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
		context.SetActive(value: true);
	}

	public void Start()
	{
		characterBackpack.gameObject.SetActive(value: false);
		itemInventory.gameObject.SetActive(value: false);
		characterToolbar.gameObject.SetActive(value: false);
	}

	public static void OpenCharacterInventory()
	{
		instance.characterBackpack.gameObject.SetActive(value: true);
		instance.currentInventoryMode = InventoryMode.OpenCharacterInventory;
	}

	public static void CloseCharacterInventory()
	{
		instance.characterBackpack.gameObject.SetActive(value: false);
		instance.currentInventoryMode = InventoryMode.OnlyToolbar;
	}

	public static void OpenToolbar()
	{
		instance.characterToolbar.gameObject.SetActive(value: true);
		instance.currentInventoryMode = InventoryMode.OnlyToolbar;
	}

	public static void CloseToolbar()
	{
		instance.characterToolbar.gameObject.SetActive(value: false);
		instance.characterBackpack.gameObject.SetActive(value: false);
		instance.currentInventoryMode = InventoryMode.None;
	}

	private void Update()
	{
	}

	public static void OpenItemInventory(int inventoryId, bool isPrivateChest)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		instance.currentInventoryMode = InventoryMode.OpenOtherInventory;
		instance.itemInventory.gameObject.SetActive(value: true);
		instance.itemInventory.SetInventoryId(inventoryId);
		instance.characterBackpack.gameObject.SetActive(value: true);
		instance.itemInventory.UpdateTypeName(isPrivateChest);
	}

	public static void CloseItemInventory()
	{
		instance.currentInventoryMode = InventoryMode.OnlyToolbar;
		instance.itemInventory.gameObject.SetActive(value: false);
		instance.itemInventory.SetInventoryId(-1);
		instance.characterBackpack.gameObject.SetActive(value: false);
	}

	public void OnCloseMenu()
	{
		CloseItemInventory();
		CloseCharacterInventory();
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
	}
}
