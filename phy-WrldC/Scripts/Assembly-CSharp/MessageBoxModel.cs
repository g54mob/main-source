using System;
using System.Collections;

public class MessageBoxModel : BaseModel
{
	public Action ConfirmAction;

	public Func<IEnumerator> AutoConfirmAction;

	public string HeaderText { get; set; }

	public string InfoText { get; set; }

	public bool IsCancelEnabled { get; set; }

	public bool IsAutoConfirm => AutoConfirmAction != null;

	public MessageBoxModel()
	{
		IsCancelEnabled = true;
	}
}
