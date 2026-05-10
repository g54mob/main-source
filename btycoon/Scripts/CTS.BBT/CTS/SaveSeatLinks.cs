using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;

namespace CTS
{
	public class SaveSeatLinks : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
		}

		public override void LoadInit(ES3Settings settings)
		{
		}

		public override void LoadPost(ES3Settings settings)
		{
			foreach (Seat item in CTSSingleton<LevelParameters>.Instance.Furnitures.Enumerate<Seat>())
			{
				if ((bool)item.ItemSlot)
				{
					item.ItemSlot.Cast<DrinkSlot>().SetMeshActive(value: true);
				}
			}
			CTSSingleton<SeatCounter>.Instance.Recalculate();
		}
	}
}
