using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestRow : DialogButton, INewIndicatorProvider
{
	public enum Mode
	{
		Empty = 0,
		Normal = 1,
		NormalWithCost = 2,
		Progress = 3
	}

	private const int insufficientResourcesBlinkDuration = 20;

	public static Data.Quest questInProgress;

	public AsciiString questName;

	public AsciiString questNameIcon;

	public AsciiString newIndicator;

	public AsciiString[] costFields;

	public int costFieldsRegionX;

	public int costFieldsRegionWidth = 40;

	public int costFieldsRegionXIcon;

	public int costFieldsRegionWidthIcon = 40;

	public int preferredDescriptionWidth = 34;

	public ProgressBar progressBar;

	public AsciiAnimation[] starDifficultyAnimations;

	public int iconPosX = 5;

	private ButtonSheen mySheen;

	private Data.Quest data;

	private int insufficientResourcesTicsRemaining;

	private List<Data.Resource> insufficientResources = new List<Data.Resource>();

	private AsciiSprite icon;

	private AsciiString selectedNameField;

	private AsciiString secondaryField = new AsciiString();

	private AsciiString thirdField = new AsciiString();

	private AsciiAnimation starAnim;

	private Color difficultyColor;

	public AsciiSprite deltaLaurelsIconPrefab;

	private static AsciiSprite deltaLaurelsIcon;

	public AsciiString deltaLaurelsLabel;

	private bool showDeltaLaurels;

	private bool wasVisible;

	public Data.Quest QuestData
	{
		get
		{
			return data;
		}
		set
		{
			data = value;
			UpdateContents();
		}
	}

	public Mode mode { get; set; }

	public bool isVisible { get; private set; }

	public event Action<Data.Quest> OnProgressBarComplete;

	protected override void Awake()
	{
		base.Awake();
		progressBar.OnComplete += HandleOnProgressBarComplete;
		mySheen = GetComponent<ButtonSheen>();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		progressBar.OnComplete -= HandleOnProgressBarComplete;
	}

	private void HandleOnProgressBarComplete(Data.TimeProgress timeData)
	{
		questInProgress = null;
		timeData.running = false;
		if (this.OnProgressBarComplete != null)
		{
			this.OnProgressBarComplete(QuestData);
		}
	}

	public override void UpdateTic()
	{
		if (DrawEnabled())
		{
			base.UpdateTic();
			insufficientResourcesTicsRemaining--;
		}
		if (data != null && data.timeProgress != null && data.timeProgress.running)
		{
			QuestExceptions.UpdateTic(data);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		UpdateVisibility(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		Color colorOverride = (DrawEnabled() ? ColorConstants.white : ColorConstants.grey);
		DrawIcon(r, offsetX, offsetY);
		if (mode == Mode.Normal)
		{
			if (starAnim == null)
			{
				selectedNameField.Draw(r, offsetX, offsetY, colorOverride);
			}
			else
			{
				int num = offsetX;
				int num2 = offsetY - 1;
				selectedNameField.Draw(r, num, num2, colorOverride);
				num += selectedNameField.PositionX - 5;
				num2 += selectedNameField.PositionY + 2;
				starAnim.Sprite.Draw(r, num, num2);
				if (difficultyColor != ColorConstants.white)
				{
					for (int i = 1; i < 11; i++)
					{
						AsciiCellProcedural cell = r.GetCell(num + i, num2);
						cell?.SetForeground(cell.GetForeground() * difficultyColor);
					}
				}
				if (HamartiaEventController.IsEventActive())
				{
					num = offsetX + 30;
					num2 = offsetY + 4;
					if (HamartiaEventController.singleton.IsStrongQuest(QuestData.id))
					{
						r.SetCell(num, num2, SpecialSymbols.Map('↑'), ColorConstants.red);
					}
					else
					{
						r.SetCell(num, num2, SpecialSymbols.Map('↓'), ColorConstants.cyan);
					}
				}
			}
		}
		else if (mode == Mode.NormalWithCost)
		{
			selectedNameField.Draw(r, offsetX, offsetY - 1, colorOverride);
			if (data.costs != null)
			{
				for (int j = 0; j < data.costs.Length && j < costFields.Length; j++)
				{
					if (insufficientResourcesTicsRemaining > 0 && insufficientResources.Contains(data.costs[j].resource))
					{
						int num3 = 10;
						int num4 = num3 >> 1;
						if (insufficientResourcesTicsRemaining % num3 > num4)
						{
							costFields[j].Draw(r, offsetX, offsetY, ColorConstants.red);
						}
						else
						{
							costFields[j].Draw(r, offsetX, offsetY, colorOverride);
						}
					}
					else
					{
						costFields[j].Draw(r, offsetX, offsetY, colorOverride);
					}
				}
			}
		}
		else if (mode == Mode.Progress)
		{
			if (string.IsNullOrEmpty(secondaryField.Value))
			{
				selectedNameField.Draw(r, offsetX, offsetY - 1);
				progressBar.Draw(r, offsetX + ((icon != null) ? 4 : 0), offsetY);
			}
			else
			{
				int offsetY2 = offsetY - 2;
				selectedNameField.Draw(r, offsetX, offsetY2);
				secondaryField.Draw(r, offsetX, offsetY2);
				int num5 = offsetY;
				if (!string.IsNullOrEmpty(thirdField.Value))
				{
					thirdField.Draw(r, offsetX, offsetY2);
					num5++;
				}
				progressBar.Draw(r, offsetX + ((icon != null) ? 4 : 0), num5);
			}
		}
		DrawNewIndicator(r, offsetX, offsetY);
		if (mySheen != null)
		{
			mySheen.Draw(r, offsetX, offsetY);
		}
		offsetX -= PositionX;
		offsetY -= PositionY;
		base.Draw(r, offsetX, offsetY);
	}

	protected virtual void DrawIcon(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (showDeltaLaurels)
		{
			if (deltaLaurelsIcon != null)
			{
				deltaLaurelsIcon.Draw(r, offsetX + 7, offsetY + 2);
			}
			deltaLaurelsLabel.Draw(r, offsetX, offsetY);
		}
		else if (icon != null)
		{
			int offsetX2 = offsetX + iconPosX;
			int offsetY2 = offsetY + (Height >> 1);
			if (DrawEnabled())
			{
				icon.Draw(r, offsetX2, offsetY2);
			}
			else
			{
				icon.Draw(r, offsetX2, offsetY2, ColorConstants.grey);
			}
		}
	}

	private void UpdateVisibility(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		isVisible = offsetX < r.width && offsetY >= r.clip.top - 1 && offsetY + Height <= r.height - r.clip.bottom + 1;
		if (!wasVisible && isVisible && data != null)
		{
			QuestController.singleton.MarkAsSeen(data.id);
		}
		wasVisible = isVisible;
	}

	private void DrawNewIndicator(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (IsNewIndicating())
		{
			if (DrawEnabled())
			{
				newIndicator.Draw(r, offsetX, offsetY);
			}
			else
			{
				newIndicator.Draw(r, offsetX, offsetY, ColorConstants.grey);
			}
		}
	}

	public virtual bool IsNewIndicating()
	{
		if (data != null)
		{
			return !QuestController.singleton.HasPlayed(data.id);
		}
		return false;
	}

	public virtual Color GetNewIndicatorColor()
	{
		return ColorConstants.red;
	}

	public virtual string GetNewIndicatorString()
	{
		if (string.IsNullOrEmpty(data.customIndicator))
		{
			return Te.xt("New!");
		}
		return Te.xt(data.customIndicator);
	}

	public void BeginProgress()
	{
		data.timeProgress.running = true;
		UpdateContents();
		if (icon != null)
		{
			AsciiAnimation component = icon.GetComponent<AsciiAnimation>();
			if (component != null)
			{
				component.Play();
			}
		}
	}

	private bool DrawEnabled()
	{
		if (questInProgress == null || questInProgress == data)
		{
			if (!(data.id != "rocky_plateau"))
			{
				return ProgressFlags.GetFlag("deadwood_valley_1");
			}
			return true;
		}
		return false;
	}

	public void DisplayInsufficientResources(List<Data.Cost> resources)
	{
		insufficientResourcesTicsRemaining = 20;
		insufficientResources.Clear();
		for (int i = 0; i < resources.Count; i++)
		{
			insufficientResources.Add(resources[i].resource);
		}
	}

	public void SetStarDifficulty(int difficulty, bool animated)
	{
		if (difficulty == 0)
		{
			starAnim = null;
			return;
		}
		int num = (difficulty - 1) % 5;
		starAnim = starDifficultyAnimations[num];
		difficultyColor = UpgradeRelicScreen.GetColorForDifficulty(difficulty);
		starAnim.Stop();
		if (mode == Mode.Normal)
		{
			if (animated)
			{
				starAnim.Play();
			}
			else
			{
				starAnim.Sprite.SetFrameIndex(starAnim.Sprite.FrameCount - 1);
			}
		}
	}

	protected virtual void UpdateContents()
	{
		if (data != null)
		{
			icon = null;
			showDeltaLaurels = false;
			EventController.EventData activeAndStartedEvent = EventController.singleton.GetActiveAndStartedEvent();
			int starDifficultyForQuest = QuestController.singleton.GetStarDifficultyForQuest(data.id);
			if (activeAndStartedEvent != null && activeAndStartedEvent.uniqueCoeficient > 0f && activeAndStartedEvent.uniqueLocation == data.id && (starDifficultyForQuest >= 5 || (starDifficultyForQuest >= 3 && data.id != "rocky_plateau")))
			{
				showDeltaLaurels = true;
				string value = Mathf.RoundToInt(activeAndStartedEvent.uniqueCoeficient / TreasureFactory.singleton.uniqueCoeficient * 100f) + "%";
				deltaLaurelsLabel.SetValue(value);
				if (deltaLaurelsIcon == null)
				{
					deltaLaurelsIcon = UnityEngine.Object.Instantiate(deltaLaurelsIconPrefab);
				}
			}
			else if (data.iconId != null)
			{
				icon = IconLoader.Singleton.GetSharedIcon(data.iconId);
				if (icon != null)
				{
					icon.Load();
					AsciiAnimation component = icon.GetComponent<AsciiAnimation>();
					if (component != null && !component.playOnStart)
					{
						component.Stop();
					}
					icon.SetFrameIndex(0);
				}
			}
			secondaryField.Clear();
			thirdField.Clear();
			if (icon == null && !showDeltaLaurels)
			{
				selectedNameField = questName;
			}
			else
			{
				selectedNameField = questNameIcon;
			}
			if (data.timeProgress != null && data.timeProgress.running)
			{
				mode = Mode.Progress;
				if (data.progressBar == null || data.progressBar == "")
				{
					Utils.LogWarning("Quest " + data.id + " is showing progress but a specific progress label is not specified.");
					selectedNameField.SetValue(Te.xt(data.name) + "...");
				}
				else
				{
					questInProgress = data;
					string text = Te.xt(data.progressBar);
					string[] array = Utils.BreakIntoLines(text, preferredDescriptionWidth);
					if (array.Length >= 3)
					{
						thirdField.color = selectedNameField.color;
						thirdField.alignment = selectedNameField.alignment;
						thirdField.PositionX = selectedNameField.PositionX;
						thirdField.PositionY = selectedNameField.PositionY + 2;
						thirdField.SetValue(array[2]);
					}
					if (array.Length >= 2)
					{
						selectedNameField.SetValue(array[0]);
						secondaryField.color = selectedNameField.color;
						secondaryField.alignment = selectedNameField.alignment;
						secondaryField.PositionX = selectedNameField.PositionX;
						secondaryField.PositionY = selectedNameField.PositionY + 1;
						secondaryField.SetValue(array[1]);
					}
					else
					{
						selectedNameField.SetValue(text);
					}
				}
				progressBar.TimeData = data.timeProgress;
				progressBar.Play();
			}
			else
			{
				if (data.costs != null && data.costs.Length != 0)
				{
					mode = Mode.NormalWithCost;
					SetupCostFields();
				}
				else
				{
					mode = Mode.Normal;
				}
				selectedNameField.SetValue(Te.xt(data.name));
				progressBar.TimeData = null;
				progressBar.Stop();
			}
			insufficientResourcesTicsRemaining = 0;
			newIndicator.SetValue(GetNewIndicatorString());
			if (mySheen != null && (data.timeProgress == null || !data.timeProgress.running) && !QuestController.singleton.HasPlayed(data.id))
			{
				mySheen.Play();
			}
		}
		else
		{
			mode = Mode.Empty;
		}
		wasVisible = false;
	}

	private void SetupCostFields()
	{
		int num = costFieldsRegionX;
		int num2 = costFieldsRegionWidth;
		if (icon != null)
		{
			num = costFieldsRegionXIcon;
			num2 = costFieldsRegionWidthIcon;
		}
		for (int i = 0; i < data.costs.Length && i < costFields.Length; i++)
		{
			Data.Cost cost = data.costs[i];
			string resourceCostFormatted = MoneyUI.GetResourceCostFormatted(cost.resource, cost.amount);
			costFields[i].SetValue(resourceCostFormatted);
		}
		int positionX = num + (num2 >> 1);
		if (data.costs.Length == 1)
		{
			costFields[0].PositionX = positionX;
			costFields[0].alignment = AsciiString.Alignment.Center;
		}
		else if (data.costs.Length == 2)
		{
			int num3 = num2 >> 3;
			costFields[0].PositionX = num + num3;
			costFields[0].alignment = AsciiString.Alignment.Left;
			costFields[1].PositionX = num + num2 - 1 - num3;
			costFields[1].alignment = AsciiString.Alignment.Right;
		}
		else if (data.costs.Length >= 3)
		{
			costFields[0].PositionX = num;
			costFields[0].alignment = AsciiString.Alignment.Left;
			costFields[1].PositionX = positionX;
			costFields[1].alignment = AsciiString.Alignment.Center;
			costFields[2].PositionX = num + num2 - 1;
			costFields[2].alignment = AsciiString.Alignment.Right;
		}
	}
}
