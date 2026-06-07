using System.Collections.Generic;
using MyStuff.Interaction;
using UnityEngine;

namespace Brewery.Map
{
	public class CornFieldHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		[Header("Field Information")]
		[Tooltip("Display name for this corn field")]
		[SerializeField]
		private string fieldName;

		[Tooltip("Sneaky description")]
		[SerializeField]
		private string fieldDescription;

		[Header("Economic Data")]
		[Tooltip("Shop price per corn for comparison")]
		[SerializeField]
		private int shopPricePerCorn;

		[Header("Risk Settings")]
		[Tooltip("Base risk level (0-1, 0=safe, 1=dangerous)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float baseRiskLevel;

		[Tooltip("Distance threshold for farmer proximity warning")]
		[SerializeField]
		private float farmerProximityRange;

		[Header("Components (Auto-discovered)")]
		[Tooltip("Corn plants in this field (auto-found if empty)")]
		[SerializeField]
		private HarvestableCornPlant[] cornPlants;

		[Header("Display Settings")]
		[Tooltip("Show navigation/distance info")]
		[SerializeField]
		private bool showNavigation;

		[Tooltip("Show economic value comparison")]
		[SerializeField]
		private bool showEconomics;

		[Tooltip("Show risk assessment")]
		[SerializeField]
		private bool showRisk;

		[Tooltip("Interaction range for hints")]
		[SerializeField]
		private float interactionRange;

		[Header("Quest Integration")]
		[Tooltip("Location ID used for quest events (e.g., 'cornfield')")]
		[SerializeField]
		private string locationId;

		private void Awake()
		{
		}

		public string GetHoverTitle()
		{
			return null;
		}

		public string GetHoverSubtitle()
		{
			return null;
		}

		public List<HoverInfoSection> GetHoverSections()
		{
			return null;
		}

		public bool ShouldShowHover()
		{
			return false;
		}

		private void AddNavigationSection(List<HoverInfoSection> sections)
		{
		}

		private void AddInteractionHints(List<HoverInfoSection> sections)
		{
		}
	}
}
