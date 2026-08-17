using System;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Pools;

public class DamagingZonePool_Ophion : Group
{
	private ObjectPool _pool;

	public DamagingZonePool_Ophion(int capacity = 50)
		: base(capacity)
	{
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.DamagingZonesOphion);
		_pool = pool;
	}

	public unsafe DamagingZoneOphion SpawnAt(float x, float y, float radius, float damage, float duration, float hitboxDelay)
	{
		//IL_0037: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		DamagingZoneOphion objectComponent;
		if ((object)_pool != null)
		{
			float2 float5 = default(float2);
			Quaternion quaternion2 = default(Quaternion);
			GameObject obj = _pool.GetObject((Vector3)(&float5), (Quaternion)(&quaternion2));
			objectComponent = _pool.GetObjectComponent<DamagingZoneOphion>(obj);
			if ((object)objectComponent == null || ((UnityEngine.Object)objectComponent).m_CachedPtr == (IntPtr)0)
			{
				goto IL_023f;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameObject gameObject = objectComponent.gameObject;
				if (core._diContainer != null)
				{
					core._diContainer.InjectGameObject(gameObject);
					objectComponent.Init(this);
					if ((object)objectComponent._groundFx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
						Circle collider = objectComponent._collider;
						if (objectComponent._collider != null)
						{
							collider._x = x;
							collider._y = y;
							float2 position = default(float2);
							objectComponent.position = position;
							Circle collider2 = objectComponent._collider;
							if (objectComponent._collider != null)
							{
								float num = (collider2._radius = radius * 0.01f);
								float diameter = num + num;
								collider2._diameter = diameter;
								float scale = radius + radius;
								PhaserSprite phaserSprite = RenderingExtensions.SetScale(objectComponent._groundFx, scale);
								float damage2 = default(float);
								objectComponent._damage = damage2;
								float hitDelay = default(float);
								objectComponent._hitDelay = hitDelay;
								float duration2 = default(float);
								objectComponent._duration = duration2;
								objectComponent.OnRecycle();
								Group obj2 = add(objectComponent);
								goto IL_023f;
							}
						}
					}
				}
			}
		}
		return (DamagingZoneOphion)(object)new NullReferenceException();
		IL_023f:
		return objectComponent;
	}

	public void Return(DamagingZoneOphion element)
	{
		ObjectPool pool = _pool;
		if ((object)_pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = element.gameObject;
			_pool.Release(obj);
		}
	}

	public void Destroy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		ObjectPool pool = _pool;
		if ((object)_pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			_pool.ReleaseAll();
		}
		ObjectPool pool2 = _pool;
		if ((object)_pool != null && ((UnityEngine.Object)pool2).m_CachedPtr != (IntPtr)0)
		{
			MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
			ObjectPool pool3 = _pool;
			int num = masterObjectPooler._poolTable.FindEntry(pool3._name);
			if (num >= 0)
			{
				ObjectPool pool4 = _pool;
				MasterObjectPooler._003CInstance_003Ek__BackingField.DestroyPool(pool4._name);
			}
		}
	}
}
