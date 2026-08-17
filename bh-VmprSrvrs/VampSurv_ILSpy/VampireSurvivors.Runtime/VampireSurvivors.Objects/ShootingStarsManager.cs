using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects;

public class ShootingStarsManager : IInitializable, IDisposable
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public ShootingStarsManager _003C_003E4__this;

		public float radiusMul;

		public Action _003C_003E9__0;

		internal void _003CAimRandom_003Eb__0()
		{
			_003C_003E4__this.ShootOne(radiusMul);
		}
	}

	private GameSessionData _gameSessionData;

	private DiContainer _diContainer;

	private Camera _mainCamera;

	private ObjectPool _explosionStarsPool;

	private const float Damage = 30f;

	private const float Radius = 0.6f;

	public void Initialize()
	{
		Camera main = Camera.main;
		_mainCamera = main;
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.ExplosionStars);
		_explosionStarsPool = pool;
	}

	public void Dispose()
	{
	}

	public void AimRandom(int times = 1, float delay = 100f, float radiusMul = 1f)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.radiusMul = radiusMul;
		if (times <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals7._003C_003E9__0;
			if (CS_0024_003C_003E8__locals7._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals7._003C_003E9__0 = delegate
				{
					CS_0024_003C_003E8__locals7._003C_003E4__this.ShootOne(CS_0024_003C_003E8__locals7.radiusMul);
				});
			}
			float num = (float)(flag ? 1 : 0) * delay;
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < times);
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
			ExplosionStar component = gameObject.GetComponent<ExplosionStar>();
			component.InternalUpdate();
		}
	}

	private void ShootOne(float radiusMul = 1f)
	{
		//IL_00e2: Expected O, but got F4
		//IL_00f0: Expected O, but got F4
		//IL_00ff->IL009d: Incompatible stack heights: 1 vs 0
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
				object obj = UnityEngine.Random.value;
				object obj2 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 241 Invalid \"Jump target not found in method: 0x186E6A6C0\"");
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ShootStarAt(Vector2 spawnPos)
	{
		//IL_0022: Expected O, but got Ref
		//IL_0022: Expected O, but got Ref
		object obj2 = default(object);
		object obj3 = default(object);
		GameObject obj = _explosionStarsPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
		Component objectComponent = _explosionStarsPool.GetObjectComponent<ExplosionStar>(obj);
		GameObject gameObject = objectComponent.gameObject;
		_diContainer.InjectGameObject(gameObject);
		((ExplosionStar)objectComponent).Init(30f, 0.6f);
		GameSessionData gameSessionData = _gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj4 = default(object);
		float num = (float)obj4 + 1f;
		float num2 = num - (float)obj4;
		float num3 = num2 * -1f;
		float num4 = num3 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		((ExplosionStar)objectComponent)._GroundFx.sortingOrder = sortingOrder;
		((ExplosionStar)objectComponent)._particlesManager.SetDepthMultiplied(num3);
	}
}
