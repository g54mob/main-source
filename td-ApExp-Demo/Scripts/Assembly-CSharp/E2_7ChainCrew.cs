using System.Collections.Generic;
using UnityEngine;

public class E2_7ChainCrew : EnemyBase
{
	[Header("Chain Crew Fields")]
	[SerializeField]
	private GameObject chainerPrefab;

	private new void Start()
	{
		ModuleSlot moduleSlot = Train.Instance.Wagons[0].ModuleSlots[0];
		List<Wagon> wagons = Train.Instance.Wagons;
		ModuleSlot moduleSlot2 = wagons[wagons.Count - 1].ModuleSlots[^1];
		EnemyManager.Instance.SpawnEnemy(chainerPrefab, EnemyPositionOnScreen.TopOfScreen).GetComponent<E2_7Chainer>().SetOriginalTarget(moduleSlot2.GetAnchorPoint(north: true));
		EnemyManager.Instance.SpawnEnemy(chainerPrefab, EnemyPositionOnScreen.TopOfScreen).GetComponent<E2_7Chainer>().SetOriginalTarget(moduleSlot.GetAnchorPoint(north: true));
		EnemyManager.Instance.SpawnEnemy(chainerPrefab, EnemyPositionOnScreen.BottomOfScreen).GetComponent<E2_7Chainer>().SetOriginalTarget(moduleSlot2.GetAnchorPoint(north: false));
		EnemyManager.Instance.SpawnEnemy(chainerPrefab, EnemyPositionOnScreen.BottomOfScreen).GetComponent<E2_7Chainer>().SetOriginalTarget(moduleSlot.GetAnchorPoint(north: false));
		Object.Destroy(base.gameObject);
	}
}
