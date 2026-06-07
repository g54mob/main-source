using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class LarderController : MonoBehaviour, IPersistable
	{
		[PersistenceOptIn]
		private float _timeSinceLastCheck;

		public float checkInterval;

		private Dictionary<string, int> _currentStock;

		private void Start()
		{
		}

		public void Update()
		{
		}

		private void CheckReservedLarderSpots()
		{
		}

		public void Reset()
		{
		}

		private void UpdateCraftingJobsState()
		{
		}

		private bool UpdateJobState(INeedsIngredients_Job job, IEnumerable<Tuple<GameItemTemplate, int>> neededItemAmounts)
		{
			return false;
		}

		private void UpdateCurrentStock()
		{
		}

		private void CheckCraftingJobs()
		{
		}

		public IEnumerable<string> GetCraftingIssues(string templateId)
		{
			return null;
		}
	}
}
