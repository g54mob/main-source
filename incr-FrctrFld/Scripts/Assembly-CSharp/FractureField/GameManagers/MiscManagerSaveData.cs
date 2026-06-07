using System.Collections.Generic;
using FractureField.Quarry.UI.Tip;
using Reactivity;

namespace FractureField.GameManagers
{
	public class MiscManagerSaveData : IConvertableSaveData
	{
		public bool IsNewGame { get; set; }

		public RFloat GameSpeed { get; set; }

		public bool HasSeenDemoPopup1 { get; set; }

		public bool HasSeenDemoPopup2 { get; set; }

		public List<TipType> TipsShown { get; set; }

		public RLong TimeInGame { get; set; }

		public RBool DisableDamageText { get; set; }

		public RBool DisableCurrencyText { get; set; }

		protected MiscManagerSaveData Save(MiscManager data)
		{
			return null;
		}
	}
}
