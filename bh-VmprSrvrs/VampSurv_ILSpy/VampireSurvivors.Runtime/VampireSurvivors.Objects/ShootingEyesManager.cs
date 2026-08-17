using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects;

public class ShootingEyesManager : IInitializable, IDisposable
{
	private GameSessionData _gameSessionData;

	private DiContainer _diContainer;

	private Camera _mainCamera;

	private ObjectPool _explosionEyesPool;

	private const float Damage = 15f;

	private const float Radius = 0.6f;

	public void Initialize()
	{
		Camera main = Camera.main;
		_mainCamera = main;
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.ExplosionEyes);
		_explosionEyesPool = pool;
	}

	public void Dispose()
	{
	}

	public void ShootOne(float radiusMul = 1f)
	{
		//IL_00e2: Expected O, but got F4
		//IL_00f0: Expected O, but got F4
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
				Vector2 spawnPos = default(Vector2);
				ShootOneAt(spawnPos);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void Stop()
	{
		IEnumerable<GameObject> allActiveObjects = _explosionEyesPool.GetAllActiveObjects();
		if (allActiveObjects != null)
		{
			List<object> list = new List<object>(allActiveObjects);
			int num = list._size;
			while (true)
			{
				num--;
				if (num >= 0)
				{
					if (num >= list._size)
					{
						break;
					}
					object[] items = list._items;
					ExplosionEye component = ((GameObject)items[num]).GetComponent<ExplosionEye>();
					component.Despawn();
					continue;
				}
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
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
			ExplosionEye component = gameObject.GetComponent<ExplosionEye>();
			component.InternalUpdate();
		}
	}

	private unsafe void ShootOneAt(Vector2 spawnPos)
	{
		//IL_0022: Expected O, but got Ref
		//IL_0022: Expected O, but got Ref
		object obj2 = default(object);
		object obj3 = default(object);
		GameObject obj = _explosionEyesPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
		Component objectComponent = _explosionEyesPool.GetObjectComponent<ExplosionEye>(obj);
		GameObject gameObject = objectComponent.gameObject;
		_diContainer.InjectGameObject(gameObject);
		((ExplosionEye)objectComponent).Init(15f, 0.6f);
		GameSessionData gameSessionData = _gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj4 = default(object);
		float num = (float)obj4 + 1f;
		float num2 = num - (float)obj4;
		float num3 = num2 * -1f;
		float num4 = num3 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		((ExplosionEye)objectComponent)._GroundFx.sortingOrder = sortingOrder;
		((ExplosionEye)objectComponent)._particlesManager.SetDepthMultiplied(num3);
	}
}
