using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Career.Research;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Career.Milestones
{
	public class MilestoneContext
	{
		public const string XmlElementName = "Milestones";

		private string _activePlanetName;

		private List<Milestone> _milestones = new List<Milestone>();

		private TechTree _techTree;

		public IFlightContext Flight { get; private set; }

		public IReadOnlyList<Milestone> Milestones => _milestones;

		public event Milestone.MilestoneTierDelegate MilestoneAdvancedToNextTier;

		public MilestoneContext(XElement xml, XElement statusXml, TechTree techTree)
		{
			_techTree = techTree;
			IEnumerable<XElement> enumerable = xml?.Elements("Milestone");
			if (enumerable != null)
			{
				foreach (XElement item in enumerable)
				{
					try
					{
						Milestone milestone = new Milestone(item);
						milestone.AdvancedToNextTier += OnMilestoneAdvancedToNextTier;
						_milestones.Add(milestone);
					}
					catch (Exception ex)
					{
						Debug.LogError("Unable to parse milestone XML: " + item?.ToString() + "\n\n" + ex.Message);
					}
				}
			}
			IEnumerable<XElement> enumerable2 = statusXml?.Elements("Milestone");
			if (enumerable2 != null)
			{
				foreach (XElement item2 in enumerable2)
				{
					string id = item2.GetStringAttribute("id");
					Milestone milestone2 = _milestones.Where((Milestone x) => x.Id == id).FirstOrDefault();
					if (milestone2 != null)
					{
						milestone2.RestoreStatus(item2);
					}
					else
					{
						Debug.LogError("Could not find milestone with id '" + id + "'");
					}
				}
			}
			CheckMilestoneAchievements();
		}

		public XElement GenerateStatusXml()
		{
			XElement xElement = new XElement("Milestones");
			foreach (Milestone milestone in _milestones)
			{
				xElement.Add(milestone.GenerateStatusXml());
			}
			return xElement;
		}

		public List<Milestone> GetMilestonesForPlanet(string planetName)
		{
			return Milestones.Where((Milestone x) => x.Planet == planetName).ToList();
		}

		public bool IsMilestoneActive(Milestone milestone, string planetName)
		{
			string itemId = "Milestone." + milestone.Id;
			bool flag = !_techTree.ItemValueExists(itemId) || (_techTree.GetItemValue(itemId)?.ValueAsBool ?? true);
			if ((milestone.Persistent || !milestone.IsComplete) && flag)
			{
				if (milestone.Planet != null)
				{
					return milestone.Planet == planetName;
				}
				return true;
			}
			return false;
		}

		public void OnFlightEnd()
		{
			UpdateMilestones(MilestoneEventType.FlightEnd);
			foreach (Milestone milestone in Milestones)
			{
				milestone.OnFlightEnd();
			}
			Flight.CraftOrbit -= OnCraftOrbit;
			Flight.CraftHyperbolicOrbit -= OnCraftHyperbolicOrbit;
			Flight.CraftContact -= OnCraftContact;
			Flight.CraftChangedSoi -= OnCraftChangedSoi;
			Flight.CraftDocked -= OnCraftDocked;
			Flight = null;
			RefreshActiveMilestones(null);
		}

		public void OnFlightStart(IFlightContext flight, bool isNewLaunch)
		{
			Flight = flight;
			Flight.CraftOrbit += OnCraftOrbit;
			Flight.CraftHyperbolicOrbit += OnCraftHyperbolicOrbit;
			Flight.CraftContact += OnCraftContact;
			Flight.CraftChangedSoi += OnCraftChangedSoi;
			Flight.CraftDocked += OnCraftDocked;
			RefreshActiveMilestones(Flight.Planet?.Name);
			foreach (Milestone milestone in Milestones)
			{
				milestone.OnFlightStart(Flight);
			}
			if (isNewLaunch)
			{
				UpdateMilestones(MilestoneEventType.Launch);
			}
			UpdateMilestones(MilestoneEventType.FlightStart);
		}

		public void OnFlightUpdate()
		{
			if (_activePlanetName != Flight.Planet?.Name)
			{
				RefreshActiveMilestones(Flight.Planet?.Name);
			}
			UpdateMilestones(MilestoneEventType.Update);
		}

		private void CheckMilestoneAchievements()
		{
			if (Game.InLevel || !_techTree.IsStockCareer)
			{
				return;
			}
			int num = 1;
			int[] array = new int[6];
			foreach (Milestone milestone in Milestones)
			{
				num += milestone.CurrentTierIndex;
				for (int i = 1; i <= milestone.CurrentTierIndex; i++)
				{
					if (i < array.Length)
					{
						array[i]++;
					}
				}
			}
			if (num > 10)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesCompleted1);
			}
			if (num > 25)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesCompleted2);
			}
			if (num > 50)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesCompleted3);
			}
			if (array[1] >= 3)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesTier1);
			}
			if (array[2] >= 3)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesTier2);
			}
			if (array[3] >= 3)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesTier3);
			}
			if (array[4] >= 3)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesTier4);
			}
			if (array[5] >= 3)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.MilestonesTier5);
			}
		}

		private void OnCraftChangedSoi()
		{
			RefreshActiveMilestones(Flight.Planet?.Name);
		}

		private void OnCraftContact(ICraftNode craft, int numDroods)
		{
			UpdateMilestones(MilestoneEventType.SurfaceContact);
		}

		private void OnCraftDocked()
		{
			UpdateMilestones(MilestoneEventType.Dock);
		}

		private void OnCraftHyperbolicOrbit(ICraftNode craft, int numDroods)
		{
			UpdateMilestones(MilestoneEventType.HyperbolicOrbit);
		}

		private void OnCraftOrbit(ICraftNode craft, int numDroods)
		{
			UpdateMilestones(MilestoneEventType.Orbit);
		}

		private void OnMilestoneAdvancedToNextTier(Milestone milestone, Milestone.MilestoneTier tier)
		{
			this.MilestoneAdvancedToNextTier?.Invoke(milestone, tier);
			RefreshActiveMilestones(Flight.Planet?.Name);
			Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog($"Milestone '{milestone.Name}' tier {milestone.CurrentTierIndex + 1} complete", FlightLogEntryCategory.Default);
			CheckMilestoneAchievements();
		}

		private void RefreshActiveMilestones(string planetName)
		{
			_activePlanetName = planetName;
			foreach (Milestone milestone in Milestones)
			{
				milestone.IsActive = IsMilestoneActive(milestone, _activePlanetName);
			}
		}

		private void UpdateMilestones(MilestoneEventType eventType)
		{
			if (Game.InLevel || Game.Instance.GameState.Career.Money < 0 || (Flight.CraftNode.IsDestroyed && eventType != MilestoneEventType.FlightEnd))
			{
				return;
			}
			foreach (Milestone milestone in Milestones)
			{
				if (!milestone.IsComplete && milestone.IsActive && milestone.EventType == eventType)
				{
					try
					{
						milestone.Update();
					}
					catch (Exception)
					{
						Debug.LogError("Milestone " + milestone.Id + " failed to update: " + milestone.Expression);
					}
				}
			}
		}
	}
}
