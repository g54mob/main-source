using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ScoreTarget : MonoBehaviour
	{
		[Header("マニュアル設定")]
		[Tooltip("マニュアルモードでstageIdが入っている時、このコンポーネント単体で値を取得する")]
		[SerializeField]
		private bool manualMode;

		[SerializeField]
		private eStageId stageId;

		[Header("オブジェクト設定")]
		[SerializeField]
		private RectTransform contents;

		[SerializeField]
		private Image[] lines;

		[SerializeField]
		private ScoreTargetItem targetItemPrefab;

		private void OnEnable()
		{
		}

		public void InitComponent(List<MstScoreRankEntities> targetScore, bool displayLine = true)
		{
		}

		private void ClearContent()
		{
		}
	}
}
