using UnityEngine;

public class WallInstance : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer wallRenderer;

	[SerializeField]
	private Collider collider;

	[SerializeField]
	public CafeWallPieceVariant wallVariant;

	[SerializeField]
	private Item toolBrush;

	public bool isDefaultInteractable;

	private int id = -1;

	private InteractableComponent interactableComponent;

	private WallVisualizerComponent visualizerComponent;

	private WallPaintInstance paintInstance;

	private void Start()
	{
		if (wallVariant == null)
		{
			wallVariant = new CafeWallPieceVariant();
		}
		if (wallVariant.name != "" && GameStateManager.GetCurrentGameState() != GameStateManager.GameState.TitleScreen)
		{
			wallVariant = ShopBuilder.GetCafeBuildingOptionsLibrary().GetBuildingSet(0).GetVariantByName(wallVariant.name);
		}
		if (InventorySystem.IsValidated())
		{
			toolBrush = Item.Create(InventorySystem.GetItemLibrary().GetItemByName("Paint Brush"), 1, null);
		}
	}

	public void Init(WallVisualizerComponent visualizerComponent, int id, CafeWallPieceVariant variant)
	{
		this.id = id;
		this.visualizerComponent = visualizerComponent;
		wallVariant = variant;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			if (!(base.transform.GetChild(i).GetComponent<Collider>() == GetComponent<Collider>()) && (bool)base.transform.GetChild(i).GetComponent<Collider>())
			{
				collider = base.transform.GetChild(i).GetComponent<Collider>();
				break;
			}
		}
		collider.gameObject.layer = LayerMask.NameToLayer("Interactable");
		wallRenderer = collider.gameObject.GetComponent<MeshRenderer>();
		if (collider.gameObject.GetComponent<InteractableComponent>() == null)
		{
			interactableComponent = collider.gameObject.AddComponent<InteractableComponent>();
		}
		else
		{
			interactableComponent = collider.GetComponent<InteractableComponent>();
		}
		interactableComponent.needsItemToBeActive = !isDefaultInteractable;
		interactableComponent.activeItem = toolBrush;
		interactableComponent.OnPlayerInteractionEvent.AddListener(OnPlayerInteraction);
		interactableComponent.OnPlayerActionEvent.AddListener(OnPlayerAction);
		paintInstance = GetComponent<WallPaintInstance>();
		if (paintInstance == null)
		{
			paintInstance = base.gameObject.AddComponent<WallPaintInstance>();
		}
		paintInstance.Init(visualizerComponent.room, visualizerComponent.wall, id);
		paintInstance.targetRenderer.Add(wallRenderer);
	}

	public int GetID()
	{
		return id;
	}

	private void OnPlayerInteraction(CharacterControllerComponent character)
	{
		if (character.socket.IsHoldingItem() && character.socket.GetItemComponent().item.id == toolBrush.id)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_demo_notavailable");
		}
	}

	private void OnPlayerAction(CharacterControllerComponent character)
	{
	}

	private void OnDestroy()
	{
		if (!(interactableComponent == null))
		{
			interactableComponent.OnPlayerInteractionEvent.RemoveAllListeners();
		}
	}
}
