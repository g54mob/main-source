using System;
using TMPro;

public class TemplePanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private Temple Building => (Temple)PanelColumn.Buildings;

	private void Start()
	{
		StabilityRow.gameObject.SetActive(value: false);
		Title.Initialize(base.gameObject, "Temple");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Temple", "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		WorkerRow.SetTooltip("Worker", "Add or remove peon worker to operate the building.");
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		LevelRow.ButtonPressEvent += UpgradeLevel;
		WorkerRow.MinusPressEvent += UnreserveCharacter;
		WorkerRow.PlusPressEvent += ReserveCharacter;
		_deleteButtonText = DestroyButton.transform.Find("ButtonText").GetComponent<TMP_Text>();
	}

	private void Update()
	{
		if (Building == null)
		{
			WorldCanvasController.Instance.ClosePanel();
			return;
		}
		Title.UpdateTitleForLevel(Building.GetLevel());
		LevelRow.SetForLevelUp(Building);
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	public void UpgradeLevel(object o, EventArgs e)
	{
		TryIncreaseLevel(Building);
	}

	public void ReserveCharacter(object o, EventArgs e)
	{
		CharV2 charV = GameController.Instance.PeonController.FindWorkerForJob(Building);
		if (charV != null && Building.AddWorker(charV))
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_worker_add);
		}
	}

	public void UnreserveCharacter(object o, EventArgs e)
	{
		if (Building.RemoveOneWorker())
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_worker_remove);
		}
	}

	public void DestroyColumn()
	{
		if (ProcessDestroyColumn())
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_destroy_building_m);
			PanelColumn.DestroyBuilding(null, GameController.Instance.GetManualDestroyPercentage(), canOutputMedium: false);
			WorldCanvasController.Instance.ClosePanel();
		}
	}

	public static string GetTooltip(Temple building, bool forNextLevel = false)
	{
		string text = "";
		if (!forNextLevel)
		{
			text = "Peon will pray and call for help from another dimension.\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num != 0 && forNextLevel)
		{
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max worker\n";
			}
			if (num == 2)
			{
				text += "Add a portal.";
			}
			if (num == 3 && Temple.GlobalInfo.CanExtraPortal1Attribute.IsEnabled)
			{
				text += "Add a portal.";
			}
			if (num == 4 && Temple.GlobalInfo.CanExtraPortal2Attribute.IsEnabled)
			{
				text += "Add a portal.";
			}
			if (num == 9 && Temple.GlobalInfo.CanHaveLazerAttribute.IsEnabled)
			{
				text += "Activate the lazer.";
			}
		}
		return text;
	}
}
