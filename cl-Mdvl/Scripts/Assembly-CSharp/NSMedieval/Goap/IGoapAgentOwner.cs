using System;
using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IGoapAgentOwner : IGameDisposable, IDisposable
	{
		VillageMap Map { get; }

		int UniqueId { get; }

		Agent GetGoapAgent();

		string GetGoapAgentID();

		Transform GetTransform();

		bool IsInIncognitoMode();

		void TickFire(float deltaTime);
	}
}
