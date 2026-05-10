using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_projectileSplitData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/Projectile Split")]
public class GE_ProjectileSplitData : GameplayEffectData
{
	[Header("Projectile split")]
	[SerializeField]
	[Min(1f)]
	private int splitAmount = 1;

	[SerializeField]
	private float splitRadius = 1f;

	[SerializeField]
	private float splitDamageMultiplier = 1f;

	[SerializeField]
	[Tooltip("Distancia mínima y máxima a la que se spawnearán los sub proyectiles desde el centro del impacto. Para temas visuales y que no choque automáticamente con el target si es el mismo que el original.")]
	private Vector2 minMaxProjectileStartDistance = Vector2.zero;

	[SerializeField]
	private bool useCustomProjectile;

	[SerializeField]
	private Projectile projectilePrefab;

	public int SplitAmount => splitAmount;

	public float SplitRadius => splitRadius;

	public float SplitDamageMultiplier => splitDamageMultiplier;

	public Vector2 MinMaxProjectileStartDistance => minMaxProjectileStartDistance;

	public bool UseCustomProjectile => useCustomProjectile;

	public Projectile ProjectilePrefab => projectilePrefab;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetLocalizedString("GameplayEffects", "GE_projectileSplit_name", null, FallbackBehavior.UseProjectSettings);

	public override string Description
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "split-amount", SplitAmount },
				{
					"damage-multiplier",
					(int)(SplitDamageMultiplier * 100f)
				}
			};
			return new LocalizedString("GameplayEffects", "GE_projectileSplit_description").GetLocalizedString(dictionary);
		}
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_ProjectileSplit();
	}

	protected override bool ShowNameInInspector()
	{
		return false;
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
