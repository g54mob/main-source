using System;
using Actors.Enemies;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using UnityEngine;
using UnityEngine.Localization;

public class EnemyData : ScriptableObject
{
	public EEnemy enemyName;

	public Material material;

	public AnimatedMeshScriptableObject animation;

	public Vector3 rendererOffset;

	public Vector3 rendererRotationOffset;

	public float rendererScale;

	public float colliderRadius;

	public float overrideHeight;

	public Vector3 colliderCenter;

	public int hp;

	public int damage;

	public int shield;

	public bool isPoison;

	public float knockbackResistance;

	public bool nukeProtection;

	public float mass;

	public float speed;

	public bool isFlying;

	public float teleportCooldown;

	public bool isRunningFromPlayer;

	public float minStayAtDistance;

	public float maxStayAtDistance;

	public int xp;

	public float despawnTime;

	public bool canBeElite;

	public bool canBeExecuted;

	public float maxSuckTime;

	public EnemySpecialAttack[] specialAttacks;

	public EMap maps;

	public int minStage;

	public float creditCost;

	public float canSpawnAfterTime;

	public LocalizedString forceName;

	public string GetName()
	{
		if (forceName != null)
		{
			if (forceName.IsEmpty)
			{
				return LocalizationUtility.GetEnemyName(enemyName);
			}
			if (forceName != null)
			{
				return forceName.GetLocalizedString();
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public int GetGold()
	{
		return 1;
	}

	public int GetXp()
	{
		return xp;
	}

	public int GetEliteXp()
	{
		//IL_0017: Expected I4, but got F8
		double a = (double)xp * (double)XpUtility.eliteEnemyXpMultiplier;
		double num = Math.Round(a);
		return (int)num;
	}

	public float GetKnockback()
	{
		return 3f;
	}

	public float GetDamage()
	{
		//IL_0007: Expected F4, but got I4
		return damage;
	}

	public EnemyData()
	{
		//IL_0029: Expected I, but got O
		rendererScale = 1f;
		colliderRadius = 0.5f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		colliderCenter = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		hp = 20;
		damage = 5;
		mass = 40f;
		speed = 5f;
		teleportCooldown = 20f;
		xp = 1;
		canBeElite = true;
		maxSuckTime = 15f;
		creditCost = 1f;
		base._002Ector();
	}
}
