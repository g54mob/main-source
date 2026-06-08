using System;
using UnityEngine;

public class EventObjectiveRow : AsciiObject
{
	public enum State
	{
		Idle = 0,
		WaitingToExpand = 1,
		Expanding = 2,
		Collapsing = 3,
		Hidden = 4
	}

	public AsciiString title;

	public AsciiMultiColorTextBox description;

	public FilledProgressBar progressBar;

	public DialogButton claimButton;

	public DialogButton infoButton;

	public AsciiString pointsLabel;

	public EventObjectiveBase objData { get; private set; }

	private State currentState
	{
		get
		{
			return objData.state;
		}
		set
		{
			objData.state = value;
		}
	}

	private int stateElapsedTics
	{
		get
		{
			return objData.elapsedTics;
		}
		set
		{
			objData.elapsedTics = value;
		}
	}

	public float f_posY { get; set; }

	public event Action<EventObjectiveRow> OnClaimed;

	public event Action<string, string> OnExtraInfo;

	public void Setup(EventObjectiveBase objData)
	{
		this.objData = objData;
		UpdateDescription();
		if (objData.progress < objData.goal)
		{
			progressBar.percent = objData.GetPercent();
			progressBar.targetPercent = progressBar.percent;
			progressBar.label.SetValue(objData.progress + "/" + objData.goal);
			claimButton.enabled = false;
		}
		else
		{
			claimButton.enabled = true;
		}
		if (objData.rewardPoints > 1)
		{
			string value = string.Format(Te.xt("tid_event_points_bonus"), objData.rewardPoints.ToString());
			pointsLabel.SetValue(value);
		}
		else
		{
			pointsLabel.Clear();
		}
		Height = description.lineCount + 3;
		if (string.IsNullOrEmpty(objData.titleTid))
		{
			title.Clear();
			return;
		}
		title.SetValue(Te.xt(objData.titleTid));
		Height++;
	}

	public void Idle()
	{
		SetState(State.Idle);
	}

	public void Expand(int delay)
	{
		if (delay <= 0)
		{
			SetState(State.Expanding);
			return;
		}
		SetState(State.WaitingToExpand);
		stateElapsedTics = -delay;
	}

	public bool IsExpanding()
	{
		return currentState == State.Expanding;
	}

	public void Collapse()
	{
		SetState(State.Collapsing);
	}

	public bool IsCollapsing()
	{
		return currentState == State.Collapsing;
	}

	public bool IsHidden()
	{
		return currentState == State.Hidden;
	}

	private void SetState(State newState)
	{
		if (newState == State.Expanding || newState == State.Collapsing)
		{
			SfxController.singleton.Play("booklet_turn_page");
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Idle)
		{
			if (claimButton.enabled)
			{
				claimButton.UpdateTic();
			}
			if (!string.IsNullOrEmpty(objData.extraInfo))
			{
				infoButton.UpdateTic();
			}
		}
		else if (currentState == State.WaitingToExpand && stateElapsedTics >= 0)
		{
			SetState(State.Expanding);
		}
		else if (currentState == State.Expanding && stateElapsedTics >= 60)
		{
			SetState(State.Idle);
		}
		else if (currentState == State.Collapsing && stateElapsedTics >= 60)
		{
			SetState(State.Hidden);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		float b = PositionY;
		if (f_posY < 0f)
		{
			f_posY = b;
		}
		else
		{
			float t = Time.deltaTime * 8f;
			f_posY = Mathf.Lerp(f_posY, b, t);
		}
		offsetX += PositionX;
		offsetY += Mathf.RoundToInt(f_posY);
		if (objData.hasChangedDescription)
		{
			objData.hasChangedDescription = false;
			UpdateDescription();
		}
		if (currentState == State.WaitingToExpand || currentState == State.Hidden)
		{
			return;
		}
		if (currentState == State.Expanding || currentState == State.Collapsing)
		{
			int num = stateElapsedTics * 2 / 3;
			int num2 = ((currentState == State.Collapsing) ? (num + 2) : (Width / 2 - num));
			AsciiRenderProcedural.Clip c = new AsciiRenderProcedural.Clip
			{
				left = offsetX + num2,
				right = r.width - (offsetX + Width) + num2
			};
			r.PushClip(c);
		}
		if (!string.IsNullOrEmpty(objData.titleTid))
		{
			title.Draw(r, offsetX, offsetY);
			offsetY++;
		}
		description.Draw(r, offsetX, offsetY);
		offsetY += description.lineCount;
		if (currentState == State.Idle || currentState == State.Expanding)
		{
			pointsLabel.Draw(r, offsetX, offsetY);
		}
		if (claimButton.enabled)
		{
			claimButton.Draw(r, offsetX, offsetY);
		}
		else
		{
			progressBar.Draw(r, offsetX, offsetY);
			if (!string.IsNullOrEmpty(objData.extraInfo))
			{
				infoButton.Draw(r, offsetX, offsetY);
			}
		}
		if (currentState == State.Expanding || currentState == State.Collapsing)
		{
			r.PopClip();
		}
	}

	private void UpdateDescription()
	{
		description.Text = objData.description;
	}

	private void HandleClaimButtonPressed(DialogButton btn)
	{
		if (this.OnClaimed != null)
		{
			this.OnClaimed(this);
		}
	}

	private void HandleInfoButtonPressed(DialogButton btn)
	{
		if (this.OnExtraInfo != null)
		{
			string text = objData.extraInfo;
			if (text.StartsWith("tid_"))
			{
				text = Te.xt(text);
			}
			string text2 = objData.titleTid;
			if (text2 != null && text2.StartsWith("tid_"))
			{
				text2 = Te.xt(text2);
			}
			this.OnExtraInfo(text, text2);
		}
	}

	private void Awake()
	{
		claimButton.OnPressed += HandleClaimButtonPressed;
		infoButton.OnPressed += HandleInfoButtonPressed;
	}

	private void OnDestroy()
	{
		claimButton.OnPressed -= HandleClaimButtonPressed;
		infoButton.OnPressed -= HandleInfoButtonPressed;
	}
}
