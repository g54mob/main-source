using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RibbonFilterRow : MonoBehaviour
	{
		public Localize FilterNameLocalize;

		public DynamicButton Button;

		public TMP_Text CountText;

		public TMP_Text FilterName;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private Sprite _lockedBackground;

		[SerializeField]
		private Sprite _ugcBackground;

		public void ApplyLockedBackground()
		{
			_backgroundImage.sprite = _lockedBackground;
		}

		public void ApplyUGCBackground()
		{
			_backgroundImage.sprite = _ugcBackground;
		}
	}
}
