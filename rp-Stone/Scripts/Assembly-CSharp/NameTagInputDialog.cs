using System.Text;
using UnityEngine;

public class NameTagInputDialog : DialogNineSlice
{
	public AsciiString title;

	public AsciiString errorMessage;

	public AsciiTextInputField inputField;

	public DialogButton inputFieldButton;

	public int iconY;

	public DialogButton confirmButton;

	public DialogButton cancelButton;

	private int standaloneOffsetY = 5;

	private const float errorDuration = 1.2f;

	private float errorTimeRemaining;

	private AsciiSprite icon;

	private string lastInputText = "";

	public Item item { get; set; }

	public virtual void Show()
	{
		base.SetState(State.In);
		inputField.text = "";
		inputField.ActivateInput();
		icon = item.GetIcon();
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		base.enabled = newState != State.Disabled;
	}

	private void Update()
	{
		errorTimeRemaining -= Utils.deltaTime;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Idle)
		{
			if (lastInputText != inputField.text)
			{
				lastInputText = inputField.text;
				inputField.text = SanitizeEndChar(inputField.text);
			}
			if (!inputField.IsActive())
			{
				inputFieldButton.UpdateTic();
			}
			confirmButton.UpdateTic();
			cancelButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			title.Draw(r, offsetX, offsetY);
			icon.Draw(r, offsetX + Width / 2, offsetY + iconY);
			inputField.Draw(r, offsetX, offsetY);
			inputFieldButton.Draw(r, offsetX, offsetY);
			if (errorTimeRemaining > 0f)
			{
				Color colorOverride = Color.Lerp(Color.red, Color.black, 1f - errorTimeRemaining / 1.2f);
				errorMessage.Draw(r, offsetX, offsetY, colorOverride);
			}
			confirmButton.Draw(r, offsetX, offsetY);
			cancelButton.Draw(r, offsetX, offsetY);
		}
	}

	private void HandleEndEdit(string textValue)
	{
		if (base.CurrentState == State.Idle || base.CurrentState == State.In)
		{
			inputField.ActivateInput();
		}
	}

	private void ShowError()
	{
		errorMessage.SetValue(Te.xt("Too short."));
		errorTimeRemaining = 1.2f;
	}

	private void HandleInputFieldPressed(DialogButton btn)
	{
		inputField.ActivateInput();
	}

	private void HandleConfirmButtonPressed(DialogButton btn)
	{
		if (inputField.text.Length <= 0)
		{
			ShowError();
			inputField.ActivateInput();
			return;
		}
		Hide();
		string newNameTag = Sanitize(inputField.text);
		Item item = ItemFactory.singleton.ApplyNameTag(this.item, newNameTag);
		Inventory.Singleton.RemoveItem(this.item, 1);
		Inventory.Singleton.AddItem(item);
		Inventory.Singleton.RemoveItemById("name_tag", 1);
		AnvilScreen.UnequipAndReequip(this.item, item);
		UtilityBeltKeyShortcuts.singleton.ReportCraft((Weapon)this.item, (Weapon)item);
	}

	private string Sanitize(string inStr)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in inStr)
		{
			switch (c)
			{
			case '"':
				stringBuilder.Append('\'');
				break;
			case '“':
				stringBuilder.Append('\'');
				break;
			case '”':
				stringBuilder.Append('\'');
				break;
			case '＂':
				stringBuilder.Append('\'');
				break;
			case '[':
				stringBuilder.Append('［');
				break;
			case ']':
				stringBuilder.Append('］');
				break;
			case '{':
				stringBuilder.Append('｛');
				break;
			case '}':
				stringBuilder.Append('｝');
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		return stringBuilder.ToString();
	}

	private string SanitizeEndChar(string inStr)
	{
		if (inStr.Length <= 0)
		{
			return inStr;
		}
		int num = inStr.Length - 1;
		return inStr[num] switch
		{
			'"' => inStr.Remove(num) + "'", 
			'“' => inStr.Remove(num) + "'", 
			'”' => inStr.Remove(num) + "'", 
			'＂' => inStr.Remove(num) + "'", 
			_ => inStr, 
		};
	}

	private void HandleCancelButtonPressed(DialogButton btn)
	{
		Hide();
	}

	protected override void Awake()
	{
		base.Awake();
		inputField.OnEndEdit += HandleEndEdit;
		PositionY += standaloneOffsetY;
		inputFieldButton.OnPressed += HandleInputFieldPressed;
		confirmButton.OnPressed += HandleConfirmButtonPressed;
		cancelButton.OnPressed += HandleCancelButtonPressed;
	}
}
