using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.VFX;
using Zenject;

namespace VampireSurvivors.Objects;

public class ExplosionManager : IInitializable, IDisposable
{
	private GameSessionData _gameSessionData;

	private DiContainer _diContainer;

	private ObjectPool _explosionPool;

	public void Initialize()
	{
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.Explosions);
		_explosionPool = pool;
	}

	public void Dispose()
	{
	}

	public unsafe void SpawnExplosion(Vector2 spawnPos, float damage, float radius)
	{
		//IL_0022: Expected O, but got Ref
		//IL_0022: Expected O, but got Ref
		object obj2 = default(object);
		object obj3 = default(object);
		GameObject obj = _explosionPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
		Component objectComponent = _explosionPool.GetObjectComponent<Explosion>(obj);
		GameObject gameObject = objectComponent.gameObject;
		_diContainer.InjectGameObject(gameObject);
		((Explosion)objectComponent).Init(damage, radius);
		GameSessionData gameSessionData = _gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj4 = default(object);
		float num = (float)obj4 + 1f;
		float num2 = num - (float)obj4;
		float num3 = num2 * -1f;
		float num4 = num3 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		((Explosion)objectComponent)._GroundFx.sortingOrder = sortingOrder;
		((Explosion)objectComponent)._particlesManager.SetDepthMultiplied(num3);
	}

	public unsafe void InternalUpdate()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		Dictionary<int, GameObject>.Enumerator allActiveObjectsEnumerator = ((ObjectPool)(&obj)).GetAllActiveObjectsEnumerator();
		Dictionary<int, GameObject>.Enumerator enumerator = default(Dictionary<int, GameObject>.Enumerator);
		GameObject gameObject = default(GameObject);
		while (enumerator.MoveNext())
		{
			Explosion component = gameObject.GetComponent<Explosion>();
			component.InternalUpdate();
		}
	}
}
