using UnityEngine;

public class MainMenuOptions : DialogNineSlice
{
	public DialogButton settingsButton;

	public DialogButton saveFilesButton;

	public DialogButton languageButton;

	public DialogButton codesButton;

	public DialogButton creditsButton;

	private int defaultHeight;

	public virtual void Show()
	{
		base.SetState(State.In);
		if (Features.CODES_SCREEN_ENABLED)
		{
			creditsButton.PositionY = codesButton.PositionY + codesButton.PositionY - languageButton.PositionY;
			Height = defaultHeight;
		}
		else
		{
			creditsButton.PositionY = codesButton.PositionY;
			Height = defaultHeight - (codesButton.PositionY - languageButton.PositionY);
		}
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		settingsButton.UpdateTic();
		saveFilesButton.UpdateTic();
		languageButton.UpdateTic();
		if (Features.CODES_SCREEN_ENABLED)
		{
			codesButton.UpdateTic();
		}
		creditsButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			settingsButton.Draw(r, offsetX, offsetY);
			saveFilesButton.Draw(r, offsetX, offsetY);
			languageButton.Draw(r, offsetX, offsetY);
			if (Features.CODES_SCREEN_ENABLED)
			{
				codesButton.Draw(r, offsetX, offsetY);
			}
			creditsButton.Draw(r, offsetX, offsetY);
		}
	}

	private void HandleOnClickedOutside()
	{
		Hide();
	}

	protected override void Start()
	{
		base.Start();
		base.OnClickedOutside += HandleOnClickedOutside;
		defaultHeight = Height;
	}

	protected void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
	}
}
