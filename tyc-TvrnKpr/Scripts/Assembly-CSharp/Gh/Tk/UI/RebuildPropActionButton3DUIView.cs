using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class RebuildPropActionButton3DUIView : BuyButton3DUIView
	{
		[SerializeField]
		private TextMeshPro _moneyText;

		private GameObjectX _gox;

		public virtual GameObjectX Gox
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateMoneyText()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnTavernMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		public override void OnClicked()
		{
		}

		private void ShowCanAffordFeedback()
		{
		}
	}
}
