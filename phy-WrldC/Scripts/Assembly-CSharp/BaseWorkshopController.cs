using UnityEngine;

public abstract class BaseWorkshopController<T> : BaseController<BaseWorkshopView<T>> where T : class
{
	protected readonly Color greenColor;

	protected readonly Color yellowColor;

	protected readonly Color redColor;

	protected string uploadedTextId;

	protected string notItemTextId;

	protected string notUploadedTextId;

	protected string notUpgradedTextId;

	protected string unsubscribedTextId;

	protected string notUnsubscribedTextId;

	protected SteamWorkshopEvents steamWorkshopEvents;

	public BaseWorkshopController(BaseWorkshopView<T> view)
		: base(view)
	{
		greenColor = GameManager.Instance.GameStylesData.green;
		yellowColor = GameManager.Instance.GameStylesData.yellow;
		redColor = GameManager.Instance.GameStylesData.red;
		steamWorkshopEvents = new SteamWorkshopEvents(view);
		steamWorkshopEvents.OnFinishedCreateItemEvent += OnFinishedCreateItemHandler;
		steamWorkshopEvents.OnUploadedItemEvent += OnUploadedItemHandler;
		steamWorkshopEvents.OnNotCreateItemEvent += OnNotCreateItemHandler;
		steamWorkshopEvents.OnNotUploadedItemEvent += OnNotUploadedItemHandler;
		steamWorkshopEvents.OnNotUpgradedItemEvent += OnNotUpgradeItemHandler;
		steamWorkshopEvents.OnUnsubscribedItemEvent += OnUnsubscribedItemHandler;
		steamWorkshopEvents.OnNotUnsubscribedItemEvent += OnNotUnsubscribedItemHandler;
	}

	protected abstract void OnFinishedCreateItemHandler(ulong publishedFileId);

	protected virtual void OnUploadedItemHandler(ulong publishedFileId)
	{
		string text = LanguagesManager.Instance.GetText(uploadedTextId);
		view.SetWarningText(text, greenColor);
		view.SetOpenButtonVisibility(isVisible: true);
	}

	protected virtual void OnNotCreateItemHandler(string error)
	{
		view.SetUploadUpgradeButtonInteractivity(isInteractable: true);
		string text = LanguagesManager.Instance.GetText(notItemTextId);
		view.SetWarningText(text + "\n(" + error + ")", redColor);
	}

	protected virtual void OnNotUploadedItemHandler(string error)
	{
		view.SetUploadUpgradeButtonInteractivity(isInteractable: true);
		string text = LanguagesManager.Instance.GetText(notUploadedTextId);
		view.SetWarningText(text + "\n(" + error + ")", redColor);
	}

	protected virtual void OnNotUpgradeItemHandler(string error)
	{
		view.SetViewMode(BaseWorkshopView<T>.ViewMode.Upload);
		string text = LanguagesManager.Instance.GetText(notUpgradedTextId);
		view.SetWarningText(text + "\n(" + error + ")", redColor);
	}

	protected virtual void OnUnsubscribedItemHandler()
	{
		string text = LanguagesManager.Instance.GetText(unsubscribedTextId);
		view.SetWarningText(text, greenColor);
	}

	protected virtual void OnNotUnsubscribedItemHandler(string error)
	{
		view.SetUnsubscribeButtonInteractivity(isInteractable: true);
		string text = LanguagesManager.Instance.GetText(notUnsubscribedTextId);
		view.SetWarningText(text + "\n(" + error + ")", redColor);
	}
}
