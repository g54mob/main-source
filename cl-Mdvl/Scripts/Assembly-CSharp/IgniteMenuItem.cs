using NSEipix;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Village;
using NSMedieval.Village.Map;

public class IgniteMenuItem : AdditionalMenuItemBase
{
	private readonly Vec3Int clickedGridPos;

	public IgniteMenuItem(IAdditionalMenuOwner owner)
		: base(owner, JobType.None, canDoWhileDrafted: true)
	{
		HumanoidInstance selectedWorker = GetSelectedWorker();
		if (selectedWorker == null)
		{
			base.IsEnabled = false;
			return;
		}
		clickedGridPos = GridUtils.GetGridPosition(owner.GetGuiOverlayHookTransform().position);
		if (!IsIgniteValidForSelection(selectedWorker.Map, clickedGridPos))
		{
			base.IsEnabled = false;
			return;
		}
		EquipmentInstance weapon = CombatUtils.GetWeapon(selectedWorker);
		if (weapon == null || !weapon.CanFireFlammableProjectiles)
		{
			base.IsEnabled = false;
			return;
		}
		base.Text = MonoSingleton<LocalizationController>.Instance.GetText("attack_oil_blob");
		bool flag = selectedWorker.IsNextRoundFlammable() || CombatUtils.CanLoadFlammableRound(selectedWorker);
		base.IsEnabled = selectedWorker.WorkerBehaviour.IsDrafting && !selectedWorker.IsOnFire && !Vec3Int.zero.Equals(clickedGridPos) && flag;
		if (selectedWorker.IsOnFire)
		{
			base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("worker_on_fire");
		}
		else if (!flag)
		{
			base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cant_attack_oil_without_fire_tooltip");
		}
		else
		{
			base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("attack_oil_blob_tooltip");
		}
	}

	private bool IsIgniteValidForSelection(VillageMap map, Vec3Int gridPosition)
	{
		MapNode node = map.GetNode(gridPosition);
		if (map.FireSimLogic.IsOilBlobAt(in clickedGridPos))
		{
			return true;
		}
		foreach (WorldObject worldObject in node.WorldObjects)
		{
			if (worldObject is ResourcePileInstance resourcePileInstance && (resourcePileInstance.BlueprintId == "flamable_oil" || resourcePileInstance.BlueprintId == "flamable_oil_greek_fire" || resourcePileInstance.BlueprintId == "hay"))
			{
				return true;
			}
			if (worldObject is BaseBuildingInstance baseBuildingInstance)
			{
				TrapComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<TrapComponentInstance>();
				if (componentInstance != null && (componentInstance.Blueprint.GetID() == "oil_trap" || componentInstance.Blueprint.GetID() == "oil_trap_greek_fire"))
				{
					return true;
				}
			}
			if (worldObject is PlantMapResourceInstance { BlueprintId: "hay_patch" })
			{
				return true;
			}
		}
		return false;
	}

	protected override void OnClickCallback()
	{
		base.OnClickCallback();
		HumanoidInstance selectedWorker = GetSelectedWorker();
		if (selectedWorker != null && !selectedWorker.HasDisposed)
		{
			selectedWorker.SetNextRoundFlammable(isNextFlammable: true, ignoreAllowed: true);
			AttackablePointTarget newPooled = AttackablePointTarget.GetNewPooled();
			newPooled.Init(selectedWorker.Map, clickedGridPos.ToVector3World());
			MonoSingleton<DraftManager>.Instance.HandleRightClickAttack(newPooled, draftedOnly: true);
		}
	}
}
