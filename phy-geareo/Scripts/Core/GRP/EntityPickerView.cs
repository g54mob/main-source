using Rhizomatic.ImUI;
using Rhizomatic.UI;
using UnityEngine.UI;

namespace GRP
{
	public class EntityPickerView : ImUIView<EntityPickerViewState>
	{
		public TextAdapter text;

		public Button pick;

		public Button clear;

		public EntityPickerPopup popupPrefab;

		public Id id;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(EntityPickerViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
