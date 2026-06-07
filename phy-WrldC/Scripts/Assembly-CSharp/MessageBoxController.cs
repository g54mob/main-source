public class MessageBoxController : BaseController<MessageBoxView, MessageBoxModel>
{
	public MessageBoxController(MessageBoxView view, MessageBoxModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.SetHeaderText(model.HeaderText);
		view.SetInfoText(model.InfoText);
		view.SetCancelButtonVisibility(model.IsCancelEnabled);
		view.SetConfirmButtonVisibility(!model.IsAutoConfirm);
		view.SetIconType(!model.IsAutoConfirm);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "MessageBoxView.ConfirmButtonEvent"))
		{
			if (eventName == "MessageBoxView.CancelButtonEvent")
			{
				GameManager.Instance.ExitSubState();
			}
		}
		else
		{
			GameManager.Instance.ExitSubState();
			model?.ConfirmAction();
		}
	}
}
