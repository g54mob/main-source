using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class ContextualActionNoWorkerSelected : MenuContextualAction<SewerHole>
	{
		[SerializeField]
		private LocalizedString _selectedWorkerWrongText;

		private static readonly List<Worker> _workers = new List<Worker>();

		public override void Setup()
		{
		}

		public override string GetDisplayName()
		{
			WorldSelector.GetAllSelected(_workers);
			if (_workers.Count <= 0)
			{
				return base.GetDisplayName();
			}
			foreach (Worker worker in _workers)
			{
				if (worker.ObjectHolding.IsHolding<BodyBag>())
				{
					return "This shouldn't be visible";
				}
			}
			return _selectedWorkerWrongText.GetLocalizedStringSafe();
		}

		public override bool ShowAlways()
		{
			WorldSelector.GetAllSelected(_workers);
			if (_workers.Count <= 0)
			{
				return true;
			}
			foreach (Worker worker in _workers)
			{
				if (worker.ObjectHolding.IsHolding<BodyBag>())
				{
					return false;
				}
			}
			return true;
		}

		protected override bool CanBePerformed()
		{
			return false;
		}

		protected override void Execution()
		{
		}
	}
}
