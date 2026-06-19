using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ResearchProject
	{
		private readonly ResearchProjectDefinition _definition;

		private readonly ResearchManager _researchManager;

		private readonly List<RoomItem> _assigned;

		private float _researchedPoints;

		public Action<float, ResearchProject> OnPointsAdded;

		public ResearchProjectDefinition Definition => _definition;

		public float ResearchedPoints
		{
			get
			{
				return _researchedPoints;
			}
			set
			{
				_researchedPoints = value;
			}
		}

		public float Progress => _researchedPoints / Definition.ResearchPoints;

		public List<RoomItem> Assigned => _assigned;

		public ResearchProject(ResearchProjectDefinition definition, ResearchManager researchManager, float points)
		{
			_definition = definition;
			_researchManager = researchManager;
			_researchedPoints = points;
			_assigned = new List<RoomItem>();
		}

		public override string ToString()
		{
			return _definition.NameLocalised.ToString();
		}

		public bool IsComplete()
		{
			return _researchedPoints >= _definition.ResearchPoints;
		}

		public void SetComplete()
		{
			_researchedPoints = _definition.ResearchPoints;
		}

		public bool AddPoints(float points)
		{
			if (IsComplete())
			{
				return true;
			}
			float researchedPoints = _researchedPoints;
			_researchedPoints = Mathf.Min(_researchedPoints + points, _definition.ResearchPoints);
			OnPointsAdded.InvokeSafe(_researchedPoints - researchedPoints, this);
			if (_researchedPoints >= _definition.ResearchPoints)
			{
				_researchManager.CompleteResearchProject(this);
				if (_definition.Repeatable)
				{
					_researchedPoints = 0f;
				}
				return true;
			}
			return false;
		}

		public bool IsValid(Level level)
		{
			if (IsComplete())
			{
				return false;
			}
			if (_definition.IsExcluded(level))
			{
				return false;
			}
			if (level.Metagame.IsResearchProjectUnlocked(_definition))
			{
				return true;
			}
			if (!_definition.PrerequisitesMet(level))
			{
				return false;
			}
			return true;
		}
	}
}
