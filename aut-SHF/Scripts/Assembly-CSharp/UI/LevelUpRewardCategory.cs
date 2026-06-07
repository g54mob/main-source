using TMPro;
using UnityEngine;

namespace UI
{
	public class LevelUpRewardCategory : RewardCategoryButton
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text prevStr;

		[SerializeField]
		private TMP_Text nextStr;

		[SerializeField]
		private GameObject comparisonGroup;

		public void Init(string title = null, string prevStr = null, string nextStr = null)
		{
		}
	}
}
