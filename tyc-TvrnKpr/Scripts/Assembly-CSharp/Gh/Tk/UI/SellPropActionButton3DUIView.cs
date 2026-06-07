using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class SellPropActionButton3DUIView : Button3DUIView
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

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		private void UpdateMoneyText()
		{
		}
	}
}
