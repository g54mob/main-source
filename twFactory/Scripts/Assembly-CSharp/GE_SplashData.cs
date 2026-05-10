using UnityEngine;

public class GE_SplashData : GameplayEffectData
{
	[Header("Splash")]
	[SerializeField]
	private float splashRadius = 1f;

	[SerializeField]
	private GameObject spalshVFX;

	[SerializeField]
	[Tooltip("Determina si afecta al target del proyectil")]
	private bool affectTarget;

	[SerializeField]
	private bool customValidEnemies;

	[SerializeField]
	private Enemy.EEnemyType validEnemyTypes;

	[Header("Debug")]
	[SerializeField]
	private GameObject debugObject;

	[SerializeField]
	private bool debug;

	public float SplashRadius => splashRadius;

	public GameObject SpalshVFX => spalshVFX;

	public GameObject DebugObject => debugObject;

	public bool Debug => debug;

	public bool CustomValidEnemies => customValidEnemies;

	public Enemy.EEnemyType ValidEnemyTypes => validEnemyTypes;

	public bool AffectTarget => affectTarget;

	public override GameplayEffect InstantiateEffect()
	{
		return null;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
