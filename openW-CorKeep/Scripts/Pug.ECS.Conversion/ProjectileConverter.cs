using Pug.Conversion;
using PugTilemap;

public class ProjectileConverter : SingleAuthoringComponentConverter<ProjectileAuthoring>
{
	protected unsafe override void Convert(ProjectileAuthoring authoring)
	{
		EnsureHasComponent<OwnerReferenceCD>();
		EnsureHasComponent<ProjectileSetupCD>();
		EnsureHasComponent<ProjectileSourceCD>();
		AddComponentData(new MovementSpeedModifierCD
		{
			Value = 1f
		});
		EnsureHasComponent<TriggerAnimationOnDeathCD>();
		ProjectileCD component = new ProjectileCD
		{
			directionRadians = float.NaN,
			damageRadius = authoring.damageRadius,
			damageRadiusClient = authoring.damageRadiusClient,
			tileDamageRadius = authoring.tileDamageRadius
		};
		AddComponentData(component);
		AddComponentData(new PiercingProjectileCD
		{
			piercesEnemiesAmount = (authoring.piercesEnemies ? int.MaxValue : 0)
		});
		AddComponentData(new BouncingProjectileCD
		{
			maxBounceCount = authoring.maxBounceCount
		});
		if (authoring.shatterOnCollision)
		{
			AddComponentData(new ShatterOnCollisionProjectileCD
			{
				shards = authoring.shards,
				shardObjectID = authoring.shardObjectID
			});
		}
		if (authoring.pingPongDuration > 0f)
		{
			AddComponentData(new PingPongProjectileCD
			{
				pingPongDuration = authoring.pingPongDuration
			});
		}
		if (authoring.zigZag)
		{
			AddComponentData(default(ZigZagProjectileCD));
		}
		if (authoring.damagesTiles)
		{
			SetProperty("Projectile/damagesTiles");
		}
		if (authoring.dontDestroyOnCollision)
		{
			SetProperty("Projectile/surviveCollision");
		}
		if (authoring.isDamageable)
		{
			SetProperty("Projectile/isDamageable");
		}
		if (authoring.mayExplodeWithWindup)
		{
			SetProperty("Projectile/mayExplodeWithWindup");
		}
		if (authoring.treatDodgeAsHit)
		{
			SetProperty("Projectile/treatDodgeAsHit");
		}
		if (authoring.zigZag)
		{
			SetProperty("Projectile/zigZag");
		}
		if (authoring.ExplodeOnEnemyCollision)
		{
			SetProperty("Projectile/explodeOnEnemyCollision");
		}
		if (authoring.collideWithNonWalkableTiles)
		{
			SetProperty("Projectile/collideWithNonWalkableTiles");
		}
		if (authoring.useSpeedCurve)
		{
			EnsureHasComponent<ProjectileSpeedCurveBlendValueCD>();
			ProjectileSpeedCurveCD component2 = default(ProjectileSpeedCurveCD);
			for (int i = 0; i < 16; i++)
			{
				component2.speedCurvePoints1[i] = authoring.speedCurve1.Evaluate((float)i / 15f);
			}
			for (int j = 0; j < 16; j++)
			{
				component2.speedCurvePoints2[j] = authoring.speedCurve2.Evaluate((float)j / 15f);
			}
			AddComponentData(component2);
		}
		if (authoring.onlyAttackEveryXSecond > 0f)
		{
			AddComponentData(new ContinouslyDamagingProjectileCD
			{
				attackEveryXSecond = authoring.onlyAttackEveryXSecond
			});
		}
		EnsureHasBuffer<ProjectilePiercesWallTypesBuffer>();
		foreach (Tileset piercesWallType in authoring.piercesWallTypes)
		{
			AddToBuffer(new ProjectilePiercesWallTypesBuffer
			{
				tileset = piercesWallType
			});
		}
	}
}
