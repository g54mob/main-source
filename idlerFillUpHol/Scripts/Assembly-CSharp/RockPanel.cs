using System;

public class RockPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow OverflowRow;

	public MixedRow AmountRow;

	public MixedRow ScafoldingRow;

	public MixedRow ThrowFurtherRow;

	public WorkerRow WorkerRow;

	private Rock Building => (Rock)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Rock");
		OverflowRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Overflow!");
		AmountRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		ScafoldingRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Scaff.");
		ThrowFurtherRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Further");
		WorkerRow.Initialize(base.gameObject, "Worker");
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Rock", "", "There's a rock in the way. Remove the rock to make more space.", ""));
		AmountRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Durability", "", "Each working peon reduces durability. At zero, building is destroyed and:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard", Building.GetLifeLeft().ToNumber() + "/" + Building.GetCurrentMaxLife().ToNumber()));
		ScafoldingRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Scaffolding", "", "Increase max worker", Building.HasScafoldingAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasScafoldingAttribute.GetCost()).ToNumber() + "$")));
		ThrowFurtherRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Further", Building.HasThrowFurtherAttribute.Level + "/" + Building.HasThrowFurtherAttribute.GetMaxLevel(), "Throw trash further to the right.", Building.HasThrowFurtherAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowFurtherAttribute.GetCost()).ToNumber() + "$")));
		OverflowRow.SetTooltip("Overflow", "Too much trash in front to continue the work.");
		WorkerRow.SetTooltip("Worker", "Add or remove peon worker to operate the building.");
		ScafoldingRow.ButtonPressEvent += ScafoldingRowPress;
		ThrowFurtherRow.ButtonPressEvent += ThrowFurtherRowPress;
		WorkerRow.MinusPressEvent += UnreserveCharacter;
		WorkerRow.PlusPressEvent += ReserveCharacter;
	}

	private void Update()
	{
		if (Building == null)
		{
			WorldCanvasController.Instance.ClosePanel();
			return;
		}
		OverflowRow.gameObject.SetActive(Building.GarbageCounter.IsOverLimit);
		AmountRow.SetForStability(GetRockPercentage());
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		ScafoldingRow.SetForUpgrade(Building, Building.HasScafoldingAttribute);
		ThrowFurtherRow.SetForLevelUpgrade(Building, Building.HasThrowFurtherAttribute);
		if (Building.HasScafoldingAttribute.IsEnabled && Rock.GlobalInfo.CanThrowFurtherAttribute.IsEnabled)
		{
			ThrowFurtherRow.gameObject.SetActive(value: true);
		}
		else
		{
			ThrowFurtherRow.gameObject.SetActive(value: false);
		}
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	private float GetRockPercentage()
	{
		if (Building.GetLifeLeft() <= 0)
		{
			return 0f;
		}
		if (Building.GetLifeLeft() >= Building.GetCurrentMaxLife())
		{
			return 1f;
		}
		return (float)Building.GetLifeLeft() / (float)Building.GetCurrentMaxLife();
	}

	public void ScafoldingRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasScafoldingAttribute);
	}

	public void ThrowFurtherRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasThrowFurtherAttribute);
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
}
