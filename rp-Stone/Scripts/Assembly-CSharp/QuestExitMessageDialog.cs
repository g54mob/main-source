using UnityEngine;

public class QuestExitMessageDialog : DialogNineSlice
{
	public AsciiTextBox textBox;

	public DialogButton okButton;

	public Data.Quest QuestData { get; set; }

	public void SetString(string message, string buttonLabel)
	{
		textBox.Text = Te.xt(message);
		Height = textBox.lineCount + 9;
		PositionY = -Height / 2;
		okButton.PositionY = textBox.lineCount + 3;
		okButton.label.SetValue(Te.xt(buttonLabel));
	}

	public void Show()
	{
		base.SetState(State.In);
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	private void HandleOnPressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		Hide();
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
		{
			Hide();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		okButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			textBox.Draw(r, offsetX, offsetY);
			okButton.Draw(r, offsetX, offsetY);
		}
	}

	protected override void Start()
	{
		base.Start();
		okButton.OnPressed += HandleOnPressed;
		base.OnClickedOutside += HandleOnClickedOutside;
	}

	private void OnDestroy()
	{
		okButton.OnPressed -= HandleOnPressed;
		base.OnClickedOutside -= HandleOnClickedOutside;
	}
}
