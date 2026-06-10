using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval
{
	public class CombatProjectile : MonoBehaviour
	{
		[SerializeField]
		private GameObject normalTrail;

		[SerializeField]
		private GameObject bonusTrail;

		[SerializeField]
		private GameObject penaltyTrail;

		[SerializeField]
		private GameObject fireEffect;

		[SerializeField]
		private List<GameObject> visibleMeshes;

		private void Awake()
		{
			fireEffect.gameObject.SetActive(value: false);
			SetActiveVisibleMeshes(value: true);
		}

		public void ShowBonusTrail()
		{
			normalTrail.SetActive(value: false);
			penaltyTrail.SetActive(value: false);
			bonusTrail.SetActive(value: true);
		}

		public void ShowPenaltyTrail()
		{
			normalTrail.SetActive(value: false);
			penaltyTrail.SetActive(value: true);
			bonusTrail.SetActive(value: false);
		}

		public void SetFireEffect(bool active)
		{
			fireEffect.gameObject.SetActive(active);
		}

		public void SetActiveVisibleMeshes(bool value)
		{
			foreach (GameObject visibleMesh in visibleMeshes)
			{
				visibleMesh.SetActive(value);
			}
		}
	}
}
