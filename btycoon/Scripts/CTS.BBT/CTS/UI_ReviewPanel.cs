using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class UI_ReviewPanel : MonoBehaviour
	{
		[SerializeField]
		private Sprite _serviceSprite;

		[SerializeField]
		[ShowIf("IsHumanPanel")]
		private Sprite _drinkHumanSprite;

		[SerializeField]
		[HideIf("IsHumanPanel")]
		private Sprite _drinkVampireSprite;

		[SerializeField]
		private Sprite _funSprite;

		[SerializeField]
		[ShowIf("IsHumanPanel")]
		private Sprite _toiletSprite;

		[SerializeField]
		private UI_ReviewCounter _prefab;

		[SerializeField]
		private Transform _goodReviewContainer;

		[SerializeField]
		private Transform _badReviewContainer;

		[field: SerializeField]
		public bool IsHumanPanel { get; private set; }

		public UI_ReviewCounter GoodReviewService { get; private set; }

		public UI_ReviewCounter GoodReviewDrink { get; private set; }

		public UI_ReviewCounter GoodReviewFun { get; private set; }

		public UI_ReviewCounter GoodReviewToilet { get; private set; }

		public UI_ReviewCounter BadReviewService { get; private set; }

		public UI_ReviewCounter BadReviewDrink { get; private set; }

		public UI_ReviewCounter BadReviewFun { get; private set; }

		public UI_ReviewCounter BadReviewToilet { get; private set; }

		private void Awake()
		{
			GoodReviewService = Object.Instantiate(_prefab, _goodReviewContainer);
			GoodReviewService.Init(_serviceSprite);
			BadReviewService = Object.Instantiate(_prefab, _badReviewContainer);
			BadReviewService.Init(_serviceSprite);
			GoodReviewDrink = Object.Instantiate(_prefab, _goodReviewContainer);
			BadReviewDrink = Object.Instantiate(_prefab, _badReviewContainer);
			if (IsHumanPanel)
			{
				GoodReviewDrink.Init(_drinkHumanSprite);
				BadReviewDrink.Init(_drinkHumanSprite);
			}
			else
			{
				GoodReviewDrink.Init(_drinkVampireSprite);
				BadReviewDrink.Init(_drinkVampireSprite);
			}
			GoodReviewFun = Object.Instantiate(_prefab, _goodReviewContainer);
			GoodReviewFun.Init(_funSprite);
			BadReviewFun = Object.Instantiate(_prefab, _badReviewContainer);
			BadReviewFun.Init(_funSprite);
			if (IsHumanPanel)
			{
				GoodReviewToilet = Object.Instantiate(_prefab, _goodReviewContainer);
				GoodReviewToilet.Init(_toiletSprite);
				BadReviewToilet = Object.Instantiate(_prefab, _badReviewContainer);
				BadReviewToilet.Init(_toiletSprite);
			}
		}

		public void AddServiceReview(bool good)
		{
			if (good)
			{
				GoodReviewService.CurrentValue++;
			}
			else
			{
				BadReviewService.CurrentValue++;
			}
		}

		public void AddDrinkReview(bool good)
		{
			if (good)
			{
				GoodReviewDrink.CurrentValue++;
			}
			else
			{
				BadReviewDrink.CurrentValue++;
			}
		}

		public void AddFunReview(bool good)
		{
			if (good)
			{
				GoodReviewFun.CurrentValue++;
			}
			else
			{
				BadReviewFun.CurrentValue++;
			}
		}

		public void AddToiletReview(bool good)
		{
			if (IsHumanPanel)
			{
				if (good)
				{
					GoodReviewToilet.CurrentValue++;
				}
				else
				{
					BadReviewToilet.CurrentValue++;
				}
			}
		}

		public void SetValuesFromOther(UI_ReviewPanel other)
		{
			GoodReviewService.CurrentValue = other.GoodReviewService.CurrentValue;
			GoodReviewDrink.CurrentValue = other.GoodReviewDrink.CurrentValue;
			GoodReviewFun.CurrentValue = other.GoodReviewFun.CurrentValue;
			if (GoodReviewToilet != null && other.GoodReviewToilet != null)
			{
				GoodReviewToilet.CurrentValue = other.GoodReviewToilet.CurrentValue;
			}
			BadReviewService.CurrentValue = other.BadReviewService.CurrentValue;
			BadReviewDrink.CurrentValue = other.BadReviewDrink.CurrentValue;
			BadReviewFun.CurrentValue = other.BadReviewFun.CurrentValue;
			if (BadReviewToilet != null && other.BadReviewToilet != null)
			{
				BadReviewToilet.CurrentValue = other.BadReviewToilet.CurrentValue;
			}
		}

		public void ClearValues()
		{
			GoodReviewService.CurrentValue = 0;
			GoodReviewDrink.CurrentValue = 0;
			GoodReviewFun.CurrentValue = 0;
			if (GoodReviewToilet != null)
			{
				GoodReviewToilet.CurrentValue = 0;
			}
			BadReviewService.CurrentValue = 0;
			BadReviewDrink.CurrentValue = 0;
			BadReviewFun.CurrentValue = 0;
			if (BadReviewToilet != null)
			{
				BadReviewToilet.CurrentValue = 0;
			}
		}

		public void LoadStruct(ReviewPanelSaveStruct save)
		{
			ClearValues();
			GoodReviewService.CurrentValue = save.GoodReviewService;
			GoodReviewDrink.CurrentValue = save.GoodReviewDrink;
			GoodReviewFun.CurrentValue = save.GoodReviewFun;
			if (GoodReviewToilet != null)
			{
				GoodReviewToilet.CurrentValue = save.GoodReviewToilet;
			}
			BadReviewService.CurrentValue = save.BadReviewService;
			BadReviewDrink.CurrentValue = save.BadReviewDrink;
			BadReviewFun.CurrentValue = save.BadReviewFun;
			if (BadReviewToilet != null)
			{
				BadReviewToilet.CurrentValue = save.BadReviewToilet;
			}
		}

		public ReviewPanelSaveStruct SaveStruct()
		{
			return ReviewPanelSaveStruct.CreateStruct(this);
		}
	}
}
