using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class ActionFindClosestInteractor<TInteractor> : InstantAction, IGive<TInteractor> where TInteractor : FurnitureInteractor
	{
		[SerializeField]
		private bool _debug;

		protected TInteractor FoundInteractor { get; private set; }

		protected override bool PlayAction(ActionSequence sequence)
		{
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor<TInteractor>(sequence.PlayerAgent.RoomObject, out var outFurniture, out var _))
			{
				FoundInteractor = outFurniture;
				return true;
			}
			return false;
		}

		TInteractor IGive<TInteractor>.Get()
		{
			return FoundInteractor;
		}

		public FurnitureInteractor Get()
		{
			return FoundInteractor;
		}
	}
}
