using DG.Tweening;
using SaveData;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ScoreDetailItem : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text scoreTitle;

		[SerializeField]
		private TMP_Text score;

		[SerializeField]
		private RectTransform animationGroupRect;

		[SerializeField]
		private CanvasGroup animationCanvasGroup;

		[SerializeField]
		private int ascensionBonusTextScale;

		public Sequence sequence;

		private MstScoreRecordEntities _mstData;

		public void Init(ScoreDetailModel model, float duration = 0f, float delay = 0f)
		{
		}

		public void DisplayScoreDesc()
		{
		}

		public void HiddenScoreDesc()
		{
		}
	}
}
