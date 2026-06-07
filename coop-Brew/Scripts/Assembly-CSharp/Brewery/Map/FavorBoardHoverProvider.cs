using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Map
{
	public class FavorBoardHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		[Header("Display Settings")]
		[SerializeField]
		private bool showLocationInfo;

		[SerializeField]
		private bool showRefreshTimer;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

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

		private void AddLocationSection(List<HoverInfoSection> sections)
		{
		}

		private void AddFavorsStatusSection(List<HoverInfoSection> sections)
		{
		}

		private void AddMyFavorsSection(List<HoverInfoSection> sections)
		{
		}

		private void AddRefreshTimerSection(List<HoverInfoSection> sections)
		{
		}

		private void AddActionsSection(List<HoverInfoSection> sections)
		{
		}
	}
}
