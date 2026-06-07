using TMPro;
using UnityEngine;

namespace Battle
{
	public class EnemyHpBar : MonoBehaviour
	{
		[SerializeField]
		private Transform hpBar;

		[SerializeField]
		private Transform shieldBar;

		[SerializeField]
		private TMP_Text debugHp;

		private float maxHp;

		private float maxShield;

		public void Init(float maxHp, Vector3 adjustmentPos, float maxShield = 0f)
		{
		}

		public void ChangeFillAmount(float currentHp, float currentShield = 0f)
		{
		}

		public void DisplayToggle(bool on)
		{
		}
	}
}
