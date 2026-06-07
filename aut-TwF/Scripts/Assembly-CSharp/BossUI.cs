using DG.Tweening;
using TMPro;
using UnityEngine;

public class BossUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI bossName;

	[SerializeField]
	private StatBar healthStatBar;

	[SerializeField]
	private StatBar armorStatBar;

	[SerializeField]
	private StatBar shieldStatBar;

	[SerializeField]
	private float heightPosition = -40f;

	[SerializeField]
	private float heightHidePosition = 200f;

	[SerializeField]
	private AutoTransformRebuild autoTransformRebuild;

	private void Start()
	{
		LTFunctionLibrary.GetSpawnersManager().onBossSpawned += OnBossSpawned;
		(base.transform as RectTransform).anchoredPosition = Vector2.up * heightHidePosition;
	}

	private void OnBossSpawned(Enemy enemy)
	{
		bossName.text = "· " + enemy.Data.EnemyName + " ·";
		healthStatBar.StatsComponent = enemy.StatsComponent;
		armorStatBar.StatsComponent = enemy.StatsComponent;
		shieldStatBar.StatsComponent = enemy.StatsComponent;
		autoTransformRebuild.RebuildTransform();
		enemy.CombatComponent.onDie += OnBossDie;
		(base.transform as RectTransform).anchoredPosition = Vector2.up * heightHidePosition;
		(base.transform as RectTransform).DOAnchorPosY(heightPosition, 0.75f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
	}

	private void OnBossDie(CombatComponent combatComponent)
	{
		(base.transform as RectTransform).DOAnchorPosY(heightHidePosition, 1.25f).SetEase(Ease.OutExpo).SetUpdate(isIndependentUpdate: true)
			.SetDelay(1f);
	}
}
