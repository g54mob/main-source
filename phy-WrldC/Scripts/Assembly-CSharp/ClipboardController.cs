using UnityEngine.UI;

public class ClipboardController : ClipboardControllerBase<CreationView, CreationModel>
{
	private readonly ToggleGroup toggleGroup;

	public ClipboardController(ClipboardView view, ClipboardModel model, ToggleGroup toggleGroup)
		: base((ClipboardViewBase<CreationView, CreationModel>)view, (ClipboardModelBase<CreationModel>)model, toggleGroup)
	{
	}

	protected override void SaveButtonHandler(CreationModel itemModel)
	{
		GameManager.Instance.ToSaveCreationModel = itemModel;
		GameManager.Instance.ChangeState(SaveCreationState.Instance);
	}
}
