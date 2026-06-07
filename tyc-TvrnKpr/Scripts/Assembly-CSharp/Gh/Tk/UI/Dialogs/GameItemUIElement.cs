using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class GameItemUIElement : BaseInteractable3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _name;

		[SerializeField]
		private Transform _preview;

		[SerializeField]
		private Stars3DUIView _stars;

		[SerializeField]
		private TextMeshProI18n _amountText;

		private string _orginalAmountText;

		[SerializeField]
		private CraftableTargetAmountElement _targetAmountElement;

		private StockInfo _stockInfo;

		private GameItem _item;

		public bool HasTargetAmountElement => false;

		public StockInfo StockInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameItem Item
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

		private GameObjectX[] GetObjectsToCycle()
		{
			return null;
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
