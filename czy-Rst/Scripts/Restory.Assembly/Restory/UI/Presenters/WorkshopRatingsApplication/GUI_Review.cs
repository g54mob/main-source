using System;
using System.Linq;
using Restory.Data.Localization;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkshopRatings;
using Restory.UI.Views.Shops;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.WorkshopRatingsApplication
{
	public class GUI_Review : MonoBehaviour
	{
		[SerializeField]
		private Image npcNameImage;

		[SerializeField]
		private TextMeshProUGUI npcNameText;

		[SerializeField]
		private TextMeshProUGUI reviewText;

		[SerializeField]
		private GUI_SellerRatingView ratingView;

		[SerializeField]
		private GUI_ShopDateView dateView;

		private GameCalendar gameCalendar;

		private LocalizationSystem localizationSystem;

		[Inject]
		private void Construct(GameCalendar gameCalendar, LocalizationSystem localizationSystem)
		{
			this.gameCalendar = gameCalendar;
			this.localizationSystem = localizationSystem;
		}

		public void Init(Review review)
		{
			npcNameImage.overrideSprite = ((review.NpcInfo != null) ? review.NpcInfo.Icon : null);
			npcNameText.text = GetNpcNameText(review);
			reviewText.text = GetLocalizedComment(review.Comment);
			ratingView.SetRating(review.Rating);
			dateView.SetDateTime(gameCalendar.CurrentDateTime - review.ReviewDate);
		}

		private string GetLocalizedComment(ReviewComment comment)
		{
			if (comment.Sentences == null || comment.Sentences.Length == 0)
			{
				return string.Empty;
			}
			return comment.Sentences.Select(delegate(string sentence)
			{
				string translation = localizationSystem.GetTranslation(sentence);
				return (!string.IsNullOrEmpty(translation)) ? translation : sentence;
			}).Aggregate((string a, string b) => a + " " + b);
		}

		private string GetNpcNameText(Review review)
		{
			if (!(review.NpcInfo != null))
			{
				return review.EmailContact.EmailAddress;
			}
			return localizationSystem.GetTranslation(review.NpcInfo.NameLocalizationKey);
		}

		public void Clean()
		{
			npcNameText.text = string.Empty;
			reviewText.text = string.Empty;
			ratingView.SetRating(5);
			dateView.SetDateTime(TimeSpan.Zero);
		}
	}
}
