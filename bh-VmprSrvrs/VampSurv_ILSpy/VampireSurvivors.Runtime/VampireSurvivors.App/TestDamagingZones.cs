using System;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.App;

public class TestDamagingZones : GameMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public float radius;

		public TestDamagingZones _003C_003E4__this;

		public Action _003C_003E9__0;

		internal void _003CFireOphion_003Eb__0()
		{
			//IL_00dc: Expected O, but got F4
			//IL_0133: Expected O, but got F4
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 position = gameSessionData._activeCharacter.position;
			object obj = UnityEngine.Random.value;
			float num = radius * 0.01f;
			object obj2 = default(object);
			float num2 = (float)obj2 - 0.5f;
			GameManager core2 = GM.Core;
			float num3 = num * num2;
			float x = num3 + (float)position;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			float2 position2 = gameSessionData2._activeCharacter.position;
			object obj3 = UnityEngine.Random.value;
			TestDamagingZones testDamagingZones = _003C_003E4__this;
			float num4 = num2 - 0.5f;
			float num5 = radius * 0.01f;
			float num6 = num5 * num4;
			object obj4 = default(object);
			float y = (float)obj4 - num6;
			float damage = default(float);
			float duration = default(float);
			float hitboxDelay = default(float);
			DamagingZoneOphion damagingZoneOphion = testDamagingZones._damagingZonePoolOphion.SpawnAt(x, y, 64f, damage, duration, hitboxDelay);
		}
	}

	private GameSessionData _gameSessionData;

	private ObjectPool _explosionPool;

	private DiContainer _diContainer;

	private DamagingZonePool_Ophion _damagingZonePoolOphion;

	private Timer _damagingZonesEvent;

	protected Camera MainCamera => Camera.main;

	private void Construct(GameSessionData gameSessionData, DiContainer diContainer)
	{
		_gameSessionData = gameSessionData;
		_diContainer = diContainer;
	}

	private void TestWeapons()
	{
		ObjectPool explosionPool = _explosionPool;
		if ((object)_explosionPool == null || ((UnityEngine.Object)explosionPool).m_CachedPtr == (IntPtr)0)
		{
			ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.DamagingZones);
			_explosionPool = pool;
		}
		DamagingZone_Weapons(0f, follow: true);
	}

	private void TestCoffins()
	{
		ObjectPool explosionPool = _explosionPool;
		if ((object)_explosionPool == null || ((UnityEngine.Object)explosionPool).m_CachedPtr == (IntPtr)0)
		{
			ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.DamagingZones);
			_explosionPool = pool;
		}
		DamagingZone_Coffins(0f, follow: true);
	}

	private void TestTrainees()
	{
		ObjectPool explosionPool = _explosionPool;
		if ((object)_explosionPool == null || ((UnityEngine.Object)explosionPool).m_CachedPtr == (IntPtr)0)
		{
			ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.DamagingZones);
			_explosionPool = pool;
		}
		DamagingZone_Trainees(0f, follow: true);
	}

	private void TestExplosions()
	{
		ObjectPool explosionPool = _explosionPool;
		if ((object)_explosionPool == null || ((UnityEngine.Object)explosionPool).m_CachedPtr == (IntPtr)0)
		{
			ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.DamagingZones);
			_explosionPool = pool;
		}
		DamagingZone_Explosions(0f, follow: true, 9000f);
	}

	private void TestOphion()
	{
		if (_damagingZonePoolOphion == null)
		{
			DamagingZonePool_Ophion damagingZonePoolOphion = new DamagingZonePool_Ophion();
			_damagingZonePoolOphion = damagingZonePoolOphion;
		}
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals8.radius = 400f;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals8._003C_003E9__0;
			if (CS_0024_003C_003E8__locals8._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals8._003C_003E9__0 = delegate
				{
					//IL_00dc: Expected O, but got F4
					//IL_0133: Expected O, but got F4
					GameManager core = GM.Core;
					GameSessionData gameSessionData = core._gameSessionData;
					float2 position = gameSessionData._activeCharacter.position;
					object obj = UnityEngine.Random.value;
					float num2 = CS_0024_003C_003E8__locals8.radius * 0.01f;
					object obj2 = default(object);
					float num3 = (float)obj2 - 0.5f;
					GameManager core2 = GM.Core;
					float num4 = num2 * num3;
					float x = num4 + (float)position;
					GameSessionData gameSessionData2 = core2._gameSessionData;
					float2 position2 = gameSessionData2._activeCharacter.position;
					object obj3 = UnityEngine.Random.value;
					TestDamagingZones testDamagingZones = CS_0024_003C_003E8__locals8._003C_003E4__this;
					float num5 = num3 - 0.5f;
					float num6 = CS_0024_003C_003E8__locals8.radius * 0.01f;
					float num7 = num6 * num5;
					object obj4 = default(object);
					float y = (float)obj4 - num7;
					float damage = default(float);
					float duration2 = default(float);
					float hitboxDelay = default(float);
					DamagingZoneOphion damagingZoneOphion = testDamagingZones._damagingZonePoolOphion.SpawnAt(x, y, 64f, damage, duration2, hitboxDelay);
				});
			}
			float num = (float)(flag ? 1 : 0) * 50f;
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < 13);
	}

	private void CancelOphion()
	{
		if (_damagingZonesEvent != null)
		{
			_damagingZonesEvent.Cancel();
		}
	}

	private unsafe void DamagingZone_Weapons(float xOffset = 0f, bool follow = false, float duration = 10000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_0184: Expected O, but got F4
		//IL_020c->IL0190: Incompatible stack heights: 1 vs 0
		//IL_0099->IL0190: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0190: Incompatible stack heights: 1 vs 0
		//IL_0137->IL0190: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					object obj3 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
					Transform objectComponent = (Transform)(object)_explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v29 (UnityEngine.Bounds)+10]");
							float num = 0f * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float h = num * 100f;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)(object)objectComponent).Init(100f, h, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)duration);
								_ = 1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DamagingZone_Coffins(float xOffset = 0f, bool follow = false, float duration = 10000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_0184: Expected O, but got F4
		//IL_020c->IL0190: Incompatible stack heights: 1 vs 0
		//IL_0099->IL0190: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0190: Incompatible stack heights: 1 vs 0
		//IL_0137->IL0190: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					object obj3 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
					Transform objectComponent = (Transform)(object)_explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v29 (UnityEngine.Bounds)+10]");
							float num = 0f * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float h = num * 100f;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)(object)objectComponent).Init(100f, h, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)duration);
								_ = 1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DamagingZone_Trainees(float yOffset = 0f, bool follow = false, float duration = 5000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_017c: Expected O, but got F4
		//IL_0204->IL0188: Incompatible stack heights: 1 vs 0
		//IL_0099->IL0188: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0188: Incompatible stack heights: 1 vs 0
		//IL_012f->IL0188: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&ret), (Quaternion)(&obj2));
					Transform objectComponent = (Transform)(object)_explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							object obj3 = default(object);
							float num = (float)obj3 * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float w = num * 100f;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)(object)objectComponent).Init(w, 100f, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)duration);
								_ = 1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DamagingZone_Explosions(float yOffset = 0f, bool follow = false, float duration = 5000f)
	{
		//IL_0065: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_017c: Expected O, but got F4
		//IL_0204->IL0188: Incompatible stack heights: 1 vs 0
		//IL_0099->IL0188: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0188: Incompatible stack heights: 1 vs 0
		//IL_012f->IL0188: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_explosionPool != null)
				{
					object obj2 = default(object);
					GameObject obj = _explosionPool.GetObject((Vector3)(&ret), (Quaternion)(&obj2));
					Transform objectComponent = (Transform)(object)_explosionPool.GetObjectComponent<DamagingZone>(obj);
					if ((object)objectComponent != null)
					{
						GameObject gameObject = objectComponent.gameObject;
						if (_diContainer != null)
						{
							_diContainer.InjectGameObject(gameObject);
							Camera main2 = Camera.main;
							Bounds bounds = CameraExtensions.OrthographicBounds(main2);
							object obj3 = default(object);
							float num = (float)obj3 * 2f;
							Camera main3 = Camera.main;
							if ((object)main3 != null)
							{
								Transform transform2 = main3.transform;
								float w = num * 100f;
								float durationMillis = default(float);
								float hitBoxDelayMillis = default(float);
								string skinType = default(string);
								bool follow2 = default(bool);
								((DamagingZone)(object)objectComponent).Init(w, 100f, 12f, durationMillis, hitBoxDelayMillis, skinType, follow2, (Transform)duration);
								_ = 1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FireOphion(float delay, float radius, int times)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals8.radius = radius;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
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
			Action onComplete = CS_0024_003C_003E8__locals8._003C_003E9__0;
			if (CS_0024_003C_003E8__locals8._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals8._003C_003E9__0 = delegate
				{
					//IL_00dc: Expected O, but got F4
					//IL_0133: Expected O, but got F4
					GameManager core = GM.Core;
					GameSessionData gameSessionData = core._gameSessionData;
					float2 position = gameSessionData._activeCharacter.position;
					object obj = UnityEngine.Random.value;
					float num2 = CS_0024_003C_003E8__locals8.radius * 0.01f;
					object obj2 = default(object);
					float num3 = (float)obj2 - 0.5f;
					GameManager core2 = GM.Core;
					float num4 = num2 * num3;
					float x = num4 + (float)position;
					GameSessionData gameSessionData2 = core2._gameSessionData;
					float2 position2 = gameSessionData2._activeCharacter.position;
					object obj3 = UnityEngine.Random.value;
					TestDamagingZones testDamagingZones = CS_0024_003C_003E8__locals8._003C_003E4__this;
					float num5 = num3 - 0.5f;
					float num6 = CS_0024_003C_003E8__locals8.radius * 0.01f;
					float num7 = num6 * num5;
					object obj4 = default(object);
					float y = (float)obj4 - num7;
					float damage = default(float);
					float duration2 = default(float);
					float hitboxDelay = default(float);
					DamagingZoneOphion damagingZoneOphion = testDamagingZones._damagingZonePoolOphion.SpawnAt(x, y, 64f, damage, duration2, hitboxDelay);
				});
			}
			float num = (float)(flag ? 1 : 0) * delay;
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < times);
	}

	public TestDamagingZones()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
