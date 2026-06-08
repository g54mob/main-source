using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class NewspaperSubview : MonoBehaviour, INewsItemSubview
	{
		public TextMeshPro Title;

		public TextMeshPro Tagline;

		public void SetItem(int id)
		{
		}

		public void SetLossReason(LossReason reason)
		{
			GlobalLocalisation globalLocalisation = GameData.Main.GlobalLocalisation;
			Title.text = globalLocalisation["CLOSE_REASON_TITLE"];
			switch (reason)
			{
			case LossReason.Patience:
				Tagline.text = globalLocalisation["CLOSE_REASON_PATIENCE"];
				break;
			case LossReason.Demo:
				Tagline.text = globalLocalisation["CLOSE_REASON_DEMO"];
				break;
			case LossReason.Quitting:
				Tagline.text = globalLocalisation["CLOSE_REASON_QUIT"];
				break;
			}
		}
	}
}
