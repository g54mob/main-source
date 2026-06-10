using System;
using NSMedieval.Goap;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval
{
	public interface IAdditionalMenuOwner : IGameDisposable, IDisposable
	{
		string GetAdditionalMenuId();

		IGoapTargetable GetAsTarget();

		Transform GetGuiOverlayHookTransform();

		bool ShouldMenuFollowHookTransform();
	}
}
