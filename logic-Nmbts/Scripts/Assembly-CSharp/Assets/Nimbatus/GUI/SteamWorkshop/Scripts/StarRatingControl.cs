using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Workshop;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class StarRatingControl : SerializedMonoBehaviour
	{
		public List<UITexture> Stars;

		public UILabel NotEnoughRatingsLabel;

		public Color ActiveColor;

		public Color InactiveColor;

		private WorkshopItemResult _item;

		public void Init(WorkshopItemResult item)
		{
			_item = item;
			UpdateRating();
		}

		private void UpdateRating()
		{
			if (_item.UpVotes + _item.DownVotes < 25)
			{
				NotEnoughRatingsLabel.text = LocalizationManager.GetTermTranslation("DroneHangar/NotEnoughRatings");
				{
					foreach (UITexture star in Stars)
					{
						star.color = InactiveColor;
					}
					return;
				}
			}
			NotEnoughRatingsLabel.text = "";
			float num = 1f / (float)Stars.Count;
			float num2 = 0f;
			foreach (UITexture star2 in Stars)
			{
				if (num2 < _item.Score)
				{
					star2.color = ActiveColor;
				}
				else
				{
					star2.color = InactiveColor;
				}
				num2 += num;
			}
		}
	}
}
