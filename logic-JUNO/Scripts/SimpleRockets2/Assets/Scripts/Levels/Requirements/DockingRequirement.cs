using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Levels;
using ModApi.Levels.Requirements;

namespace Assets.Scripts.Levels.Requirements
{
	public class DockingRequirement : LevelRequirement
	{
		private DockingPortScript _dockingWithTargetLastFrame;

		private List<DockingPortScript> _playerDockingPorts;

		public float DockAmount { get; private set; }

		public ICraftScript TargetCraft { get; set; }

		public ICraftNode TargetCraftNode { get; private set; }

		public bool TargetCraftScriptExists { get; private set; }

		public DockingRequirement(ILevel level, string targetCraftName)
			: base(level)
		{
			TargetCraftNode = GetCraftNode(targetCraftName);
			UpdateName();
		}

		public void SetTargetCraftScript(ICraftScript targetCraft)
		{
			TargetCraft = targetCraft;
			_playerDockingPorts = new List<DockingPortScript>();
			foreach (PartData part in base.Level.PlayerCraft.Data.Assembly.Parts)
			{
				DockingPortData modifier = part.GetModifier<DockingPortData>();
				if (modifier != null)
				{
					_playerDockingPorts.Add(modifier.Script);
				}
			}
			TargetCraftScriptExists = true;
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			if (!TargetCraftScriptExists && base.Status != LevelRequirementStatus.Pass)
			{
				if (TargetCraftNode.CraftScript != null)
				{
					SetTargetCraftScript(TargetCraftNode.CraftScript);
				}
				return;
			}
			bool flag = false;
			foreach (DockingPortScript playerDockingPort in _playerDockingPorts)
			{
				if (playerDockingPort != null)
				{
					if (playerDockingPort.IsDocking && playerDockingPort.OtherDockingPort?.PartScript.CraftScript.CraftNode == TargetCraftNode)
					{
						flag = true;
						base.DisplayValue = playerDockingPort.GetStatus();
						DockAmount = playerDockingPort.InspectorDockingStatusPercentage;
						_dockingWithTargetLastFrame = playerDockingPort;
						break;
					}
					if (playerDockingPort.IsDocked && _dockingWithTargetLastFrame == playerDockingPort)
					{
						DockAmount = 1f;
						base.DisplayValue = "Docked";
						base.Status = LevelRequirementStatus.Pass;
						return;
					}
				}
			}
			if (!flag)
			{
				_dockingWithTargetLastFrame = null;
				base.DisplayValue = string.Empty;
				DockAmount = 0f;
			}
			if (TargetCraft == null)
			{
				TargetCraftScriptExists = false;
			}
		}

		private ICraftNode GetCraftNode(string name)
		{
			foreach (CraftNode craftNode in ((FlightSceneScript)base.Level.FlightScene).FlightState.CraftNodes)
			{
				if (craftNode.Name == "Satellite")
				{
					return craftNode;
				}
			}
			return null;
		}

		private void UpdateName()
		{
			base.Name = "Dock with " + TargetCraftNode.Name;
		}
	}
}
