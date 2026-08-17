using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySlimeXL : EnemyController
{
	protected bool HasSpawned;

	private MultiTargetTween _onEnterTween;

	protected virtual int EnemiesToSpawnAmount => 2;

	protected virtual EnemyType EnemyToSpawnOnDeath => EnemyType.EX_PHALIEN_L;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		base.InitEnemy(enemyType, asRemote);
		HasSpawned = false;
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween onEnterTween = Tweens.Add(tweenConfig);
		_onEnterTween = onEnterTween;
	}

	protected override void Die()
	{
		//IL_0084: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		base.Die();
		if (HasSpawned || !_coherenceSync.HasStateAuthority)
		{
			return;
		}
		HasSpawned = true;
		float2 float5 = base.position;
		float2 float6 = base.position;
		int enemiesToSpawnAmount = EnemiesToSpawnAmount;
		if (enemiesToSpawnAmount <= 0)
		{
			return;
		}
		object obj = 0;
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		int enemiesToSpawnAmount2;
		do
		{
			GameManager core = GM.Core;
			EnemyType enemyToSpawnOnDeath = EnemyToSpawnOnDeath;
			GameObject gameObject = core._stage.SpawnEnemy(enemyToSpawnOnDeath, spawnPos, asRemote: false, forceSpawn);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				int num = base.depth;
				int num2 = num - 1;
				ArcadeSprite arcadeSprite = component.setDepth(num2);
			}
			obj++;
			enemiesToSpawnAmount2 = EnemiesToSpawnAmount;
		}
		while ((nint)obj < enemiesToSpawnAmount2);
	}
}
