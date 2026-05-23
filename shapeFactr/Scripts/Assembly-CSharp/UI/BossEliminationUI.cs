using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class BossEliminationUI : MonoBehaviour
	{
		[SerializeField]
		private Sprite lastBossSprite;

		[SerializeField]
		private Image background;

		[SerializeField]
		private CanvasGroup bossInfoCanvasGroup;

		[SerializeField]
		private Image mainIcon;

		[SerializeField]
		private Image[] eliminationImages;

		public Sequence BossElimination(eEnemy enemy)
		{
			return null;
		}

		private void SetImage(eEnemy id)
		{
		}
	}
}
