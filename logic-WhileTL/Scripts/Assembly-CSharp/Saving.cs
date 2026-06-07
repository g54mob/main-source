using Localization;
using UnityEngine;
using UnityEngine.UI;

public class Saving : ActiveComponent
{
	public enum State
	{
		Hidden = 0,
		Saving = 1,
		Running = 2
	}

	private float timer;

	private State state;

	private string progressChars = "-\\|/";

	private float progressSpeed = 10f;

	[SceneBind("Text")]
	public Text text;

	public float startSaving;

	public void EnableSave()
	{
		if (text == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
		}
		base.gameObject.SetActive(value: true);
		startSaving = Time.unscaledTime;
	}

	private Color GetRunningColor()
	{
		return ActiveComponent._staticData.Colors[1].AsNormalizedFloat();
	}

	private Color GetSavingColor()
	{
		return ActiveComponent._staticData.Colors[3].AsNormalizedFloat();
	}

	public override void Init()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		SetState(State.Hidden);
	}

	public void ShowSave()
	{
		base.gameObject.SetActive(value: true);
		timer = Time.unscaledTime;
		SetState(State.Saving);
	}

	public void SetState(State state)
	{
		this.state = state;
		switch (state)
		{
		case State.Saving:
			base.gameObject.SetActive(value: true);
			text.color = GetSavingColor();
			break;
		case State.Running:
			base.gameObject.SetActive(value: true);
			text.color = GetRunningColor();
			break;
		default:
			base.gameObject.SetActive(value: false);
			break;
		}
	}

	private void Update()
	{
		if (!base.gameObject.activeInHierarchy || ActiveComponent.Model == null || ActiveComponent.Model.construction == null || ActiveComponent.Model.construction.gameObject == null)
		{
			return;
		}
		if (ActiveComponent.Model != null && ActiveComponent.Model.construction != null && ActiveComponent.Model.construction.gameObject.activeInHierarchy && this.text != null)
		{
			if (state == State.Saving)
			{
				if (Time.unscaledTime >= timer + 2f)
				{
					SetState(ActiveComponent.Model.construction.IsTraining() ? State.Running : State.Hidden);
					return;
				}
				int num = (int)(Time.unscaledTime * 5f) % 4;
				string text = TextResources.GetString("SAVING");
				for (int i = 0; i < num; i++)
				{
					text += ".";
				}
				this.text.text = text;
			}
			else
			{
				if (state != State.Running)
				{
					return;
				}
				if (ActiveComponent.Model.construction.IsTraining())
				{
					int index = (int)(Time.unscaledTime * progressSpeed) % progressChars.Length;
					this.text.text = progressChars[index].ToString();
					if (this.text.text == "-")
					{
						this.text.text = "--";
					}
				}
				else
				{
					SetState(State.Hidden);
				}
			}
		}
		else if (this.text != null)
		{
			int num2 = (int)(Time.unscaledTime * 5f) % 4;
			string text2 = TextResources.GetString("SAVING");
			for (int j = 0; j < num2; j++)
			{
				text2 += ".";
			}
			this.text.text = text2;
			if (Time.unscaledTime - startSaving > 2f)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
