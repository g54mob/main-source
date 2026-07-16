using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Enemy Killed/Create New")]
public class MilestoneEnemyKilled : Milestone
{
	[field: SerializeField]
	[field: Tooltip("If you leave this field as None it will count every enemy killed regardles of its type.")]
	public EnemyTypes EnemyType { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.EnemyKilled;
		if (base.Completed)
		{
			return;
		}
		EnemyManager.Instance.EnemySpawned += CheckEnemy;
		EnemyManager.Instance.CentipedeDestroyed += delegate
		{
			if (EnemyType == EnemyTypes.Centipede && (base.TimeInSeconds == 0f || !(GameManager.Instance.playtimeInRun >= base.TimeInSeconds) || (base.TrainType != TrainType.Regular && base.TrainType != Train.Instance.currentTrain.trainType)))
			{
				base.AddProgress();
			}
		};
		EnemyManager.Instance.DualBossDestroyed += delegate
		{
			if (EnemyType == EnemyTypes.MetropolisRulers && (base.TimeInSeconds == 0f || !(GameManager.Instance.playtimeInRun >= base.TimeInSeconds) || (base.TrainType != TrainType.Regular && base.TrainType != Train.Instance.currentTrain.trainType)))
			{
				base.AddProgress();
			}
		};
		EnemyManager.Instance.BirdTrioDestroyed += delegate
		{
			if (EnemyType == EnemyTypes.AirRaidCommander && (base.TimeInSeconds == 0f || !(GameManager.Instance.playtimeInRun >= base.TimeInSeconds) || (base.TrainType != TrainType.Regular && base.TrainType != Train.Instance.currentTrain.trainType)))
			{
				base.AddProgress();
			}
		};
		EnemyManager.Instance.WarlordDestroyed += delegate
		{
			if (EnemyType == EnemyTypes.Warlord && (base.TimeInSeconds == 0f || !(GameManager.Instance.playtimeInRun >= base.TimeInSeconds) || (base.TrainType != TrainType.Regular && base.TrainType != Train.Instance.currentTrain.trainType)))
			{
				base.AddProgress();
			}
		};
	}

	protected void CheckEnemy(EnemyBase enemy)
	{
		if (!(enemy is EnemyComponent))
		{
			if (EnemyType == EnemyTypes.None)
			{
				enemy.DeathInfoEvent += AddProgress;
			}
			else if (EnemyType == enemy.EnemyType)
			{
				enemy.DeathInfoEvent += AddProgress;
			}
		}
	}

	public override void Complete()
	{
		base.Complete();
		EnemyManager.Instance.EnemySpawned -= CheckEnemy;
	}

	public void AddProgress(HealthChangeInfo info)
	{
		if (info != null && info.source != null && info.source is Object obj && obj != null && obj != EnemyManager.Instance)
		{
			base.AddProgress();
		}
	}
}
