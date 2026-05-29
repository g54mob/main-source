using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ScoreTargetItem : MonoBehaviour
	{
		[SerializeField]
		private Image rankImage;

		[SerializeField]
		private TMP_Text targetScore;

		public void Init(MstScoreRankEntities scoreRankData)
		{
		}

		private void ChangeRnakImage(string path)
		{
		}

		private void ChangeText(int score)
		{
		}
	}
}
