using UnityEngine;

public class BossHealthBarManager : MonoBehaviour
{
	[field: SerializeField]
	public BossHealthBar TutorialBoss { get; private set; }

	[field: SerializeField]
	public BossHealthBar Centipede { get; private set; }

	[field: SerializeField]
	public BossHealthBar Trasher { get; private set; }

	[field: SerializeField]
	public BossHealthBar Crusher { get; private set; }

	[field: SerializeField]
	public BossHealthBar Eagle { get; private set; }

	[field: SerializeField]
	public BossHealthBar Crow { get; private set; }

	[field: SerializeField]
	public BossHealthBar Falcon { get; private set; }

	[field: SerializeField]
	public BossHealthBar Warlord { get; private set; }
}
