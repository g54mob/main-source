using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class TutorialEvent_SetTileSlotState : TutorialEvent
	{
		[SerializeField]
		private TileSlotState targetState;

		private List<TileSlot> exceptionTileSlots = new List<TileSlot>();

		public void AddException(TileSlot exceptionTileSlot)
		{
			exceptionTileSlots.Add(exceptionTileSlot);
		}

		public override void Begin()
		{
			List<TileSlot> list = new List<TileSlot>(OverwritingSingleton<IngameUi>.Instance.tileSlotPreviewer.AllValidTileSlots);
			foreach (TileSlot exceptionTileSlot in exceptionTileSlots)
			{
				list.Remove(exceptionTileSlot);
			}
			foreach (TileSlot item in list)
			{
				item.SetState(targetState);
			}
		}

		public override void Finish()
		{
		}

		public override void Skip()
		{
		}
	}
}
