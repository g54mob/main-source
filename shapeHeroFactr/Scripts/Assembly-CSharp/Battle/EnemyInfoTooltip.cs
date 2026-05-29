using TMPro;
using UnityEngine;

namespace Battle
{
	public class EnemyInfoTooltip : MonoBehaviour
	{
		public Vector2 displayPoint;

		public TextMeshProUGUI waveCountText;

		public new TextMeshProUGUI name;

		public TextMeshProUGUI description;

		public Canvas canvas;

		public void Init(eEnemy enemyId, int waveCount)
		{
		}

		public void DisplayText()
		{
		}

		public void HiddenText()
		{
		}

		private void OnMouseEnter()
		{
		}

		private void OnMouseExit()
		{
		}
	}
}
