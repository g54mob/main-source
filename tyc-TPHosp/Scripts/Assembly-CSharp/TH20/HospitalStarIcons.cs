using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class HospitalStarIcons : MonoBehaviour
	{
		[SerializeField]
		private Sprite _starSprite;

		[SerializeField]
		private Sprite _starHolderSprite;

		[SerializeField]
		private Image _starIcon1;

		[SerializeField]
		private Image _starIcon2;

		[SerializeField]
		private Image _starIcon3;

		public void Setup(MetagameHospitalRecord.StarIndex starIndex)
		{
			switch (starIndex)
			{
			case MetagameHospitalRecord.StarIndex.Star1:
				Setup(1);
				break;
			case MetagameHospitalRecord.StarIndex.Star2:
				Setup(2);
				break;
			case MetagameHospitalRecord.StarIndex.Star3:
				Setup(3);
				break;
			default:
				Setup(0);
				break;
			}
		}

		public void Setup(int numStars)
		{
			switch (numStars)
			{
			case 0:
				_starIcon1.overrideSprite = _starHolderSprite;
				_starIcon2.overrideSprite = _starHolderSprite;
				_starIcon3.overrideSprite = _starHolderSprite;
				break;
			case 1:
				_starIcon1.overrideSprite = _starSprite;
				_starIcon2.overrideSprite = _starHolderSprite;
				_starIcon3.overrideSprite = _starHolderSprite;
				break;
			case 2:
				_starIcon1.overrideSprite = _starSprite;
				_starIcon2.overrideSprite = _starSprite;
				_starIcon3.overrideSprite = _starHolderSprite;
				break;
			default:
				_starIcon1.overrideSprite = _starSprite;
				_starIcon2.overrideSprite = _starSprite;
				_starIcon3.overrideSprite = _starSprite;
				break;
			}
		}
	}
}
