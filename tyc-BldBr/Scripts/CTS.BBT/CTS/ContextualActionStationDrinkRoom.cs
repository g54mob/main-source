using System;
using CTS.BBT;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Serializable]
	public class ContextualActionStationDrinkRoom : MenuContextualAction<StationDrink>
	{
		[SerializeField]
		private LocalizedString _serveAllDisplayName;

		public override void Setup()
		{
		}

		public override string GetDisplayName()
		{
			if (contextActor.ServeAllRooms)
			{
				return _serveAllDisplayName.GetLocalizedStringSafe();
			}
			return base.GetDisplayName();
		}

		protected override bool CanBePerformed()
		{
			return true;
		}

		protected override void Execution()
		{
			contextActor.SetServeAllRooms(!contextActor.ServeAllRooms);
		}
	}
}
