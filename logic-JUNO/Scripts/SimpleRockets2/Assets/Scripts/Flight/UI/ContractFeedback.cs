using System;
using System.Collections.Generic;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class ContractFeedback
	{
		public class FeedbackRating
		{
			private XmlElement _element;

			public int Rating { get; set; }

			public FeedbackRating(XmlElement element)
			{
				_element = element;
				for (int i = 1; i <= 5; i++)
				{
					XmlElement elementByInternalId = _element.GetElementByInternalId($"Star-{i}");
					int rating = i;
					elementByInternalId.AddOnClickEvent(delegate
					{
						SetRating(rating);
					});
				}
			}

			private void SetRating(int rating)
			{
				Debug.Log($"Rating: {rating}");
				Rating = rating;
				for (int i = 1; i <= 5; i++)
				{
					XmlElement elementByInternalId = _element.GetElementByInternalId($"Star-{i}");
					if (i <= rating)
					{
						elementByInternalId.AddClass("feedback-star-selected");
					}
					else
					{
						elementByInternalId.RemoveClass("feedback-star-selected");
					}
				}
			}
		}

		private FeedbackRating _feedbackDifficulty;

		private FeedbackRating _feedbackFun;

		public Action Closed { get; set; }

		public XmlElement Element { get; }

		public ContractFeedback(XmlElement template, Contract contract)
		{
			ContractFeedback contractFeedback = this;
			Element = UiUtilities.CloneTemplate(template, template.parentElement);
			Element.GetElementByInternalId("cancel-button").AddOnClickEvent(delegate
			{
				contractFeedback.CloseFeedback();
			});
			Element.GetElementByInternalId("submit-button").AddOnClickEvent(delegate
			{
				if (contractFeedback._feedbackFun.Rating > 0 && contractFeedback._feedbackDifficulty.Rating > 0)
				{
					contractFeedback.OnFeedbackSubmitted(contract, contractFeedback._feedbackFun.Rating, contractFeedback._feedbackDifficulty.Rating);
				}
			});
			_feedbackFun = new FeedbackRating(Element.GetElementByInternalId("feedback-fun"));
			_feedbackDifficulty = new FeedbackRating(Element.GetElementByInternalId("feedback-difficulty"));
		}

		private void CloseFeedback()
		{
			UnityEngine.Object.Destroy(Element.gameObject);
			Closed?.Invoke();
		}

		private void OnFeedbackSubmitted(Contract contract, int ratingFun, int ratingDifficulty)
		{
			if (Game.Instance.Analytics.Enabled)
			{
				float num = contract.Difficulty / 3f * 5f;
				float num2 = (float)ratingDifficulty / num;
				Game.Instance.Analytics.LogEvent("ContractFeedback", new Dictionary<string, object>
				{
					{ "ContractId", contract.Id },
					{ "ContractFeedbackRatingFun", ratingFun },
					{ "ContractFeedbackRatingDifficulty", ratingDifficulty },
					{ "ContractFeedbackRatingDifficultyDelta", num2 }
				});
			}
			CloseFeedback();
		}
	}
}
