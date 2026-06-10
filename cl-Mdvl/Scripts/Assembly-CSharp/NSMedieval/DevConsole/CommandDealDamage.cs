using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.View;
using NSMedieval.View.Animals;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandDealDamage : ConsoleCommand
	{
		private float damage = 15f;

		private bool active;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandDealDamage()
		{
			Command = "dealDamage";
			Description = "Damage anything you click on. (except voxels)";
			Help = "Damage any damage taking agents you click on. The command's first parameter is the damage amount to deal.";
		}

		private void CommandMethod(float damage)
		{
			if (active)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<SceneController>.Instance.UnscaledTick -= OnTick;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("DealDamage <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				this.damage = damage;
				if (this.damage == 0f)
				{
					this.damage = 10f;
				}
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<SceneController>.Instance.UnscaledTick += OnTick;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("DealDamage Mode <color=lime>activated</color>!", ConsoleMessageType.Warning);
		}

		private void OnTick(float dt)
		{
			if (MonoSingleton<SelectableObjectManager>.IsInstantiated() && Input.GetMouseButtonDown(0) && MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject != null)
			{
				SelectableObject mouseHoverObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
				IDamageTakingAgent damageTakingAgent = null;
				damageTakingAgent = ((!(mouseHoverObject is WorkerView workerView)) ? ((!(mouseHoverObject is NPCView nPCView)) ? ((!(mouseHoverObject is AnimalView animalView)) ? (mouseHoverObject.GetAsWorldObject() as IDamageTakingAgent) : animalView.AnimalInstance) : nPCView.HumanoidInstance) : workerView.HumanoidInstance);
				if (damageTakingAgent != null)
				{
					DamagePopup.Create(damageTakingAgent.GetPosition(), $"Debug Damage: {damage}");
					CombatHitManager.DealDamage(damageTakingAgent, damage);
				}
			}
		}

		private void OnRightMouseDown()
		{
			CommandMethod(damage);
		}
	}
}
