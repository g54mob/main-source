using System;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IToolAgent : IPathfindingAgent, IGoapAgentOwner, IGameDisposable, IDisposable
	{
		void SetTool(string toolID, Transform socket = null);

		void HideTool();

		float GetAttributeValue(AttributeType stat);

		void AddExperience(SkillType skill, float amount, bool isSilent = false);
	}
}
