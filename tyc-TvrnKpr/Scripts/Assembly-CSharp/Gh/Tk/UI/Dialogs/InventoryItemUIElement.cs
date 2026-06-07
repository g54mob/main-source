using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class InventoryItemUIElement : BaseInteractable3DUIView
	{
		[SerializeField]
		protected TextMeshProI18n _name;

		[SerializeField]
		protected Transform _preview;

		[SerializeField]
		protected Stars3DUIView _stars;

		[SerializeField]
		protected ObjectProgressBar3DUIView _containerFillValue;

		[SerializeField]
		private TraitsContainer3DUIView _traitsContainer;

		public bool showAsTemplate;

		public string namePrefix;

		protected GameItem _item;

		public virtual GameItem Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
