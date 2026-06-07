using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

public class OzoneShield : BuildableExtendableBase
{
	[SerializeField]
	private BuildableProperties _fusionReactorProperties;

	[SerializeReference]
	[InstantiateSerializeReference]
	private ScenarioTriggerableBase _triggerable;

	private void Start()
	{
		if ((bool)base.Buildable.BuildableAnimator && (bool)base.Buildable.BuildableAnimator.Animator && GameManager.WorldManager.World.HasEndTile)
		{
			base.Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
		}
		else
		{
			GameEventDispatcher.AddListener(GameEventType.ActivateOzoneShield, OnActivateOzoneShield);
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActivateOzoneShield, OnActivateOzoneShield);
	}

	public void Trigger()
	{
		if (_triggerable.TryTrigger())
		{
			GameManager.UIManager.ClosePanel(PanelID.BuildablePanel);
		}
	}

	public bool IsInteractable()
	{
		if (IsConnected() && !_triggerable.WasTriggered)
		{
			return _triggerable.ConditionsAreMet();
		}
		return false;
	}

	private bool IsConnected()
	{
		if (base.Buildable.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable) && buildableExtendable.EnergyGrid != null)
		{
			foreach (IEnergyGridComponent component in buildableExtendable.EnergyGrid.Components)
			{
				if (component is EnergyPassiveGenerator { IsGenerating: not false } energyPassiveGenerator && energyPassiveGenerator.Buildable.Properties == _fusionReactorProperties)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void OnActivateOzoneShield(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActivateOzoneShield, OnActivateOzoneShield);
		base.Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
	}
}
