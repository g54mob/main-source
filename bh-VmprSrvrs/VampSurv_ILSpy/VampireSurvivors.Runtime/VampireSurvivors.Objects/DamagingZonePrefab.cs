using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects;

public class DamagingZonePrefab : GameMonoBehaviour
{
	public enum SpawnType
	{
		TARGETED,
		HORIZONTAL_FIXED,
		HORIZONTAL_RANDOM,
		VERTICAL_FIXED,
		VERTICAL_RANDOM,
		CROSSHATCH
	}

	public float damage;

	public float duration;

	public float respawnCooldown;

	public float timeBeforeActivation;

	public float hitDelayMillis;

	public bool hasWarningMark;

	public float warningTime;

	public bool enableGroundVisuals;

	public bool isCircle;

	public float width;

	public float height;

	public float radius;

	public SpawnType spawnType;

	public int verticalSpawnCount;

	public int horizontalSpawnCount;

	public bool follow;

	public float followSpeed;

	public bool lockX;

	public bool lockY;

	public bool isAnimated;

	public string frameLocation;

	public int framePadding;

	public float frameScale;

	public string frameName;

	public int startingFrameNumber;

	public int endingFrameNumber;

	public int fps;

	public float offsetX;

	public float offsetY;

	public bool usingParticles;

	public bool setSpeed;

	public bool setAngle;

	public bool setRotation;

	public bool setScale;

	public DamageZoneFlexible.ZoneAlignment alignment;

	public int particleQuantity;

	public float particleFrequency;

	public float particleLifespan;

	public float minParticleSpeed;

	public float maxParticleSpeed;

	public float minParticleAngle;

	public float maxParticleAngle;

	public float minParticleRotation;

	public float maxParticleRotation;

	public float minParticleScale;

	public float maxParticleScale;

	public bool doParticlesBounce;

	protected float _zoneWidth;

	protected float _zoneHeight;

	protected float _zoneRadius;

	private float2 _originLocation;

	private Unity.Mathematics.Random _random;

	protected Camera MainCamera => Camera.main;

	public void SpawnZone(uint seed, float2 originLocation)
	{
		//IL_0076: Expected O, but got I4
		_originLocation = originLocation;
		int num = (int)(seed << 13);
		int num2 = num ^ (int)seed;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num5 ^ num4;
		bool flag = spawnType == SpawnType.CROSSHATCH;
		_random = (Unity.Mathematics.Random)num6;
		if (!flag)
		{
			SpawnPattern();
		}
		else
		{
			SpawnCrosshatchPattern();
		}
	}

	protected unsafe virtual void SpawnPattern()
	{
		//IL_0036: Expected O, but got I4
		//IL_00fe: Expected F4, but got O
		//IL_00fe: Expected O, but got F4
		//IL_037b: Expected O, but got Ref
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02f2: Expected O, but got F4
		//IL_0199: Expected I4, but got O
		//IL_01a1: Expected O, but got Ref
		//IL_0358: Expected F4, but got O
		List<float2> spawnLocations = GetSpawnLocations();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		object obj = 0;
		float num2 = default(float);
		float2 float5 = default(float2);
		object obj3 = default(object);
		object obj4 = default(object);
		Vector3 center = default(Vector3);
		object obj5 = default(object);
		object obj6 = default(object);
		while (true)
		{
			Camera main = Camera.main;
			DamageZoneFlexible damageZoneFlexible = DamageZoneFlexible.CreateZone(main);
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj2 >= 0)
			{
				break;
			}
			float num = duration;
			damageZoneFlexible.InitDamageZone(damage, duration, timeBeforeActivation, num2, float5);
			damageZoneFlexible._warningTimeMillis = warningTime;
			damageZoneFlexible._haveWarningMark = hasWarningMark;
			Camera camera;
			if (~(follow ? 1u : 0u) == 0)
			{
				VampireSurvivors.Objects.Characters.CharacterController randomCharacterController = GetRandomCharacterController();
				camera = (Camera)(object)randomCharacterController;
			}
			else
			{
				camera = Camera.main;
			}
			Transform transform = camera.transform;
			float num3 = followSpeed;
			damageZoneFlexible.InitDamageZoneBehaviour(lockX, lockY, follow, (Transform)num2, (float)float5);
			if (!isCircle)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				float zoneWidth;
				if (obj3 != null)
				{
					Camera main2 = Camera.main;
					Bounds bounds = CameraExtensions.OrthographicBounds(main2);
					float num4 = (float)obj4 * 2f;
					zoneWidth = num4 * 100f;
					bool flag = false;
					bool flag2 = (byte)(int)main2 != 0;
					DamageZoneFlexible damageZoneFlexible2 = (DamageZoneFlexible)(&center);
				}
				else
				{
					zoneWidth = width;
					bool flag = lockY;
					bool flag2 = lockX;
					DamageZoneFlexible damageZoneFlexible2 = damageZoneFlexible;
				}
				_zoneWidth = zoneWidth;
				Vector3 vector = (Vector3)height;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				if (obj5 != null)
				{
					Camera main3 = Camera.main;
					Bounds bounds2 = CameraExtensions.OrthographicBounds(main3);
					vector = bounds2.m_Center;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ rax_v30 (UnityEngine.Bounds)+10]");
					float num5 = 0f * 2f;
					num = num5 * 100f;
					center = bounds2.m_Center;
					bool flag = false;
				}
				else
				{
					num = height;
				}
				_zoneHeight = num;
				bool flag3 = enableGroundVisuals;
				float zoneWidth2 = _zoneWidth;
				damageZoneFlexible.InitDamageZoneRectangle(_zoneWidth, num, enableGroundVisuals);
				num3 = (float)vector;
			}
			else
			{
				float zoneWidth2 = radius;
				bool flag = enableGroundVisuals;
				_zoneRadius = radius;
				damageZoneFlexible.InitDamageZoneCircle(radius, enableGroundVisuals);
				bool flag3 = false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			SetupVisualElement((Vector3)(&obj6), damageZoneFlexible, alignment);
			damageZoneFlexible.EnableZone();
			obj++;
			object obj7 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag4 = (nint)obj7 < 0;
			obj6 = obj4;
			if (!flag4)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected unsafe virtual void SpawnCrosshatchPattern()
	{
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected I4, but got Unknown
		//IL_01d6: Expected O, but got Ref
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected I4, but got Unknown
		//IL_04f9: Expected O, but got Ref
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Expected O, but got Unknown
		//IL_0059->IL0543: Incompatible stack heights: 1 vs 0
		//IL_0076->IL0543: Incompatible stack heights: 1 vs 0
		//IL_02eb->IL0543: Incompatible stack heights: 1 vs 0
		//IL_00e2->IL0543: Incompatible stack heights: 1 vs 0
		//IL_0308->IL0543: Incompatible stack heights: 1 vs 0
		//IL_0370->IL0543: Incompatible stack heights: 1 vs 0
		//IL_039f->IL0543: Incompatible stack heights: 1 vs 0
		//IL_03e2->IL0543: Incompatible stack heights: 2 vs 0
		//IL_01a3->IL0543: Incompatible stack heights: 3 vs 0
		//IL_0408->IL0543: Incompatible stack heights: 2 vs 0
		//IL_0231->IL05de: Incompatible stack heights: 3 vs 0
		//IL_0236->IL0236: Incompatible stack heights: 3 vs 0
		//IL_04c6->IL0543: Incompatible stack heights: 4 vs 0
		//IL_053d->IL028d: Incompatible stack heights: 4 vs 0
		//IL_0542->IL0542: Incompatible stack heights: 4 vs 0
		List<float2> verticalFixedSpawnLocations = GetVerticalFixedSpawnLocations();
		Camera camera;
		float num = default(float);
		float2 spawnLocation = default(float2);
		object obj2 = default(object);
		object obj3 = default(object);
		if (verticalFixedSpawnLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag = (nint)0 <= (nint)0;
			camera = null;
			Camera camera2 = null;
			if (flag)
			{
				goto IL_0236;
			}
			while (true)
			{
				Camera main = Camera.main;
				DamageZoneFlexible damageZoneFlexible = DamageZoneFlexible.CreateZone(main);
				Camera camera3 = camera2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag2 = (nint)camera3 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0 || (object)damageZoneFlexible == null)
				{
					break;
				}
				damageZoneFlexible.InitDamageZone(damage, duration, timeBeforeActivation, num, spawnLocation);
				damageZoneFlexible._warningTimeMillis = warningTime;
				damageZoneFlexible._haveWarningMark = hasWarningMark;
				Camera main2 = Camera.main;
				if ((object)main2 == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)main2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)main2).m_CachedPtr);
				Transform targetTransform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				damageZoneFlexible._followSpeed = followSpeed;
				damageZoneFlexible._follow = follow;
				damageZoneFlexible._targetTransform = targetTransform;
				damageZoneFlexible._lockX = false;
				Camera main3 = Camera.main;
				Bounds bounds = CameraExtensions.OrthographicBounds(main3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1169 @ rax_v34 (UnityEngine.Bounds)+10]");
				float num2 = 0f * 2f;
				float num3 = num2 * 100f;
				damageZoneFlexible.InitDamageZoneRectangle(width, num3, enableGroundVisuals);
				Camera camera4 = camera2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag4 = (nint)camera4 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj = camera2 & 1;
				DamageZoneFlexible.ZoneAlignment newAlignment = (DamageZoneFlexible.ZoneAlignment)(obj + 3);
				SetupVisualElement((Vector3)(&obj2), damageZoneFlexible, newAlignment);
				damageZoneFlexible.EnableZone();
				camera2 = (Camera)(camera2 + 1);
				Camera camera5 = camera2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag5 = (nint)camera5 < 0;
				obj2 = obj3;
				camera = null;
				num = num;
				obj2 = obj3;
				if (flag5)
				{
					continue;
				}
				goto IL_0236;
			}
		}
		goto IL_0543;
		IL_0543:
		throw new NullReferenceException();
		IL_0236:
		List<float2> horizontalFixedSpawnLocations = GetHorizontalFixedSpawnLocations();
		if (horizontalFixedSpawnLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v48 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag6 = (nint)0 <= (nint)0;
			Camera camera6 = camera;
			if (flag6)
			{
				return;
			}
			while (true)
			{
				Camera main4 = Camera.main;
				DamageZoneFlexible damageZoneFlexible2 = DamageZoneFlexible.CreateZone(main4);
				Camera camera7 = camera6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v48 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag7 = (nint)camera7 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v48 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0 || (object)damageZoneFlexible2 == null)
				{
					break;
				}
				damageZoneFlexible2.InitDamageZone(damage, duration, timeBeforeActivation, num, spawnLocation);
				damageZoneFlexible2._warningTimeMillis = warningTime;
				damageZoneFlexible2._haveWarningMark = hasWarningMark;
				GameManager core = GM.Core;
				if ((object)GM.Core == null)
				{
					break;
				}
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
				if (core._mainCharacters == null)
				{
					break;
				}
				bool flag8 = mainCharacters._size <= 0;
				if (mainCharacters._items == null)
				{
					break;
				}
				Camera main5 = Camera.main;
				if ((object)main5 == null)
				{
					break;
				}
				bool flag9 = ((UnityEngine.Object)main5).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)main5).m_CachedPtr);
				Transform targetTransform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				damageZoneFlexible2._followSpeed = followSpeed;
				damageZoneFlexible2._follow = follow;
				damageZoneFlexible2._targetTransform = targetTransform2;
				damageZoneFlexible2._lockX = true;
				Camera main6 = Camera.main;
				float num4 = (float)CameraExtensions.OrthographicBounds(main6).m_Extents * 2f;
				float num5 = num4 * 100f;
				damageZoneFlexible2.InitDamageZoneRectangle(num5, height, enableGroundVisuals);
				Camera camera8 = camera6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v48 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag10 = (nint)camera8 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v48 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj4 = camera6 & 1;
				DamageZoneFlexible.ZoneAlignment newAlignment = (DamageZoneFlexible.ZoneAlignment)(obj4 + 1);
				SetupVisualElement((Vector3)(&obj2), damageZoneFlexible2, newAlignment);
				damageZoneFlexible2.EnableZone();
				camera6 = (Camera)(camera6 + 1);
				Camera camera9 = camera6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v48 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag11 = (nint)camera9 < 0;
				obj2 = obj3;
				if (!flag11)
				{
					return;
				}
			}
		}
		goto IL_0543;
	}

	protected unsafe void SetupVisualElement(Vector3 pos, DamageZoneFlexible zone, DamageZoneFlexible.ZoneAlignment newAlignment)
	{
		//IL_0008: Expected O, but got Ref
		//IL_019b: Expected O, but got Ref
		//IL_0135: Expected O, but got I
		//IL_01f3: Expected O, but got I
		//IL_021b: Expected O, but got I
		//IL_0229: Expected O, but got Ref
		//IL_023f: Expected native int or pointer, but got O
		//IL_0259: Expected O, but got I
		//IL_0060: Expected O, but got I
		//IL_00e0: Expected F4, but got I4
		//IL_02af: Expected O, but got I
		//IL_02d1: Expected O, but got I
		//IL_02f3: Expected O, but got I
		//IL_0315: Expected O, but got I
		//IL_03e2: Expected O, but got Ref
		//IL_0438: Expected F4, but got I4
		//IL_038e: Expected O, but got Ref
		//IL_03aa: Expected native int or pointer, but got O
		//IL_05b6: Expected native int or pointer, but got O
		//IL_05d0: Expected O, but got I
		//IL_058b: Expected O, but got I
		//IL_044b: Expected O, but got Ref
		//IL_04a1: Expected F4, but got I4
		//IL_05ee: Expected native int or pointer, but got O
		//IL_0608: Expected O, but got I
		//IL_04d3: Expected O, but got Ref
		//IL_04ef: Expected native int or pointer, but got O
		//IL_0635: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!usingParticles)
		{
			int num = default(int);
			DamageZoneFlexible damageZoneFlexible;
			List<Sprite> newAnimFrames;
			if (~(isAnimated ? 1u : 0u) == 0)
			{
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(frameName, startingFrameNumber, endingFrameNumber, frameLocation, num);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+6F]");
				damageZoneFlexible = (DamageZoneFlexible)0;
				newAnimFrames = animationFrames;
			}
			else
			{
				List<Sprite> list = new List<Sprite>();
				Sprite sprite = SpriteManager.GetSprite(frameName, frameLocation);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
				newAnimFrames = list;
				damageZoneFlexible = zone;
			}
			float num2 = default(float);
			damageZoneFlexible.InitSpriteVisuals(newAnimFrames, fps, offsetX, num, num2);
			return;
		}
		DamageZoneFlexible damageZoneFlexible2;
		DamageZoneFlexible.ZoneAlignment newAlignment2;
		List<string> frames;
		if (~(isAnimated ? 1u : 0u) == 0)
		{
			List<string> list2 = SpriteManager.GenerateFrameNames(startingFrameNumber, endingFrameNumber, framePadding, frameName);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+6F]");
			damageZoneFlexible2 = (DamageZoneFlexible)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+77]");
			newAlignment2 = DamageZoneFlexible.ZoneAlignment.Center;
			frames = list2;
		}
		else
		{
			List<string> list3 = new List<string>();
			list3.Add(frameName);
			frames = list3;
			damageZoneFlexible2 = zone;
			newAlignment2 = newAlignment;
		}
		Vector3 pos2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		_ = pos.x;
		_ = pos.z;
		ParticleSystemConfig particleSystemConfig = DamageZoneFlexible.BaseConfig(pos2, frames, frameLocation);
		_ = 0;
		_ = particleQuantity;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = particleFrequency;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
		particleSystemConfig._frequency = (float?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(particleLifespan));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-31]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-21]");
		_ = 0;
		if (!isCircle)
		{
			_ = doParticlesBounce;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
			particleSystemConfig._collideTop = (bool?)(object)0;
			_ = doParticlesBounce;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
			particleSystemConfig._collideBottom = (bool?)(object)0;
			_ = doParticlesBounce;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
			particleSystemConfig._collideLeft = (bool?)(object)0;
			_ = doParticlesBounce;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
			particleSystemConfig._collideRight = (bool?)(object)0;
		}
		else
		{
			particleSystemConfig._circleCollision = true;
			particleSystemConfig._circleCollisionRadius = radius;
			if (!doParticlesBounce)
			{
				particleSystemConfig._circleCollision = false;
			}
		}
		if (isAnimated)
		{
			particleSystemConfig._fps = fps;
		}
		if (setSpeed)
		{
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(minParticleSpeed, maxParticleSpeed));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-21]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-11]");
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-1]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+F]");
			_ = 0;
		}
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = 0;
		_ = 0;
		float max;
		float min;
		if (setRotation)
		{
			max = maxParticleAngle;
			min = minParticleAngle;
		}
		else
		{
			max = 360f;
			min = 0f;
		}
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(min, max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-31]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-21]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = 0;
		_ = 0;
		float max2;
		float min2;
		if (setRotation)
		{
			max2 = maxParticleRotation;
			min2 = minParticleRotation;
		}
		else
		{
			max2 = 360f;
			min2 = 0f;
		}
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min2, max2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-31]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-21]");
		_ = 0;
		if (setScale)
		{
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(minParticleScale, maxParticleScale));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-21]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-11]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-1]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+F]");
			_ = 0;
		}
		damageZoneFlexible2.InitParticleVisuals(particleSystemConfig, newAlignment2);
	}

	protected List<float2> GetSpawnLocations()
	{
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		List<float2> list = new List<float2>();
		SpawnType spawnType = this.spawnType;
		if (this.spawnType <= SpawnType.CROSSHATCH)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v6+6E1935C+v46 @ rax_v4 (VampireSurvivors.Objects.DamagingZonePrefab+SpawnType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rcx_v13 (should have been resolved before IL gen)");
		}
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
		throw ex;
	}

	protected VampireSurvivors.Objects.Characters.CharacterController GetRandomCharacterController()
	{
		//IL_00ee: Expected O, but got I4
		GameManager core = GM.Core;
		float2 position = default(float2);
		bool includeFollowers = default(bool);
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			return GM.Core.GetClosestPlayer(position, PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
		}
		GameManager core2 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core2._characters;
		object obj = UnityEngine.Random.RandomRangeInt(0, characters._size);
		if ((nint)obj < characters._size)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = characters._items;
			bool flag = (nint)obj >= items.Length;
			return items[obj];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private float2 GetTargetedSpawnLocation()
	{
		VampireSurvivors.Objects.Characters.CharacterController randomCharacterController = GetRandomCharacterController();
		if ((object)randomCharacterController != null)
		{
			Transform transform = randomCharacterController.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				float2 result = default(float2);
				return result;
			}
		}
		throw new NullReferenceException();
	}

	protected List<float2> GetVerticalFixedSpawnLocations()
	{
		//IL_01d9: Expected O, but got I4
		//IL_00b0: Expected O, but got I4
		//IL_00d8: Expected O, but got I
		//IL_0131: Expected O, but got I
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_011b->IL01e7: Incompatible stack heights: 0 vs 1
		//IL_020c->IL0211: Incompatible stack heights: 1 vs 0
		//IL_0211->IL0170: Incompatible stack heights: 1 vs 0
		float2 float5 = default(float2);
		bool includeFollowers = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
		Transform transform = closestPlayer.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			List<float2> list = new List<float2>();
			object obj = verticalSpawnCount + 1;
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			float num = (float)float5 * 2f;
			float num2 = num * 0.5f;
			float num3 = num / (float)obj;
			if ((nint)obj > 1)
			{
				object obj2 = 1;
				do
				{
					float num4 = (float)obj2 * num3;
					float num5 = num4 - num2;
					float num6 = (float)ret + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v21+18]");
					if (num7 >= 0)
					{
						list.AddWithResize(float5);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						object obj4 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v21+18]");
						bool flag = num8 >= 0;
					}
					obj2++;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
			}
			return list;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	private List<float2> GetVerticalRandomSpawnLocations(float zoneSizeAdjustment)
	{
		//IL_00b1: Expected O, but got I4
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_00c6: Expected O, but got I
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0180->IL01f1: Incompatible stack heights: 1 vs 0
		//IL_0185->IL0185: Incompatible stack heights: 1 vs 0
		List<float2> verticalFixedSpawnLocations = GetVerticalFixedSpawnLocations();
		float2 position = default(float2);
		bool includeFollowers = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(position, PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
		Transform transform = closestPlayer.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v22 (UnityEngine.Bounds)+10]");
			float num = 0f * 2f;
			float num2 = num * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)0 > (nint)1)
			{
				object obj = 1;
				object obj11 = default(object);
				bool flag2;
				do
				{
					object obj2 = (object)_random << 13;
					object obj3 = obj2 ^ (object)_random;
					object obj4 = (object)_random >> 9;
					object obj5 = obj4 | 0x3F800000;
					object obj6 = obj3 >> 17;
					object obj7 = obj6 ^ obj3;
					object obj8 = obj7 << 5;
					Unity.Mathematics.Random random = (Unity.Mathematics.Random)(obj8 ^ obj7);
					_random = random;
					object obj9 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					bool flag = (nint)obj9 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					object obj10 = 0;
					float num3 = num - zoneSizeAdjustment;
					float num4 = (float)obj5 - 1f;
					float num5 = num3 * num4;
					float num6 = num5 + (float)obj11;
					float num7 = num6 - num2;
					float num8 = num7 + zoneSizeAdjustment;
					object obj12 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v25+20+v128 @ r8_v9*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					flag2 = (nint)obj12 < 0;
					obj = obj12;
				}
				while (flag2);
			}
			return verticalFixedSpawnLocations;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	protected List<float2> GetHorizontalFixedSpawnLocations()
	{
		//IL_01e1: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_00e0: Expected O, but got I
		//IL_0139: Expected O, but got I
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0123->IL01ef: Incompatible stack heights: 0 vs 1
		//IL_0214->IL0219: Incompatible stack heights: 1 vs 0
		//IL_0219->IL0178: Incompatible stack heights: 1 vs 0
		float2 float5 = default(float2);
		bool includeFollowers = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
		Transform transform = closestPlayer.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			List<float2> list = new List<float2>();
			object obj = horizontalSpawnCount + 1;
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rax_v22 (UnityEngine.Bounds)+10]");
			float num = 0f * 2f;
			float num2 = num * 0.5f;
			float num3 = num / (float)obj;
			if ((nint)obj > 1)
			{
				object obj2 = 1;
				object obj3 = default(object);
				do
				{
					float num4 = (float)obj2 * num3;
					float num5 = num4 - num2;
					float num6 = (float)obj3 + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v21+18]");
					if (num7 >= 0)
					{
						list.AddWithResize(float5);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						object obj5 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v18 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v21+18]");
						bool flag = num8 >= 0;
					}
					obj2++;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
			}
			return list;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	private List<float2> GetHorizontalRandomSpawnLocations(float zoneSizeAdjustment)
	{
		//IL_00a9: Expected O, but got I4
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_00be: Expected O, but got I
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0178->IL01e9: Incompatible stack heights: 1 vs 0
		//IL_017d->IL017d: Incompatible stack heights: 1 vs 0
		List<float2> horizontalFixedSpawnLocations = GetHorizontalFixedSpawnLocations();
		float2 float5 = default(float2);
		bool includeFollowers = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
		Transform transform = closestPlayer.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			float num = (float)float5 * 2f;
			float num2 = num * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)0 > (nint)0)
			{
				object obj = 0;
				bool flag2;
				do
				{
					object obj2 = (object)_random << 13;
					object obj3 = obj2 ^ (object)_random;
					object obj4 = (object)_random >> 9;
					object obj5 = obj4 | 0x3F800000;
					object obj6 = obj3 >> 17;
					object obj7 = obj6 ^ obj3;
					object obj8 = obj7 << 5;
					Unity.Mathematics.Random random = (Unity.Mathematics.Random)(obj8 ^ obj7);
					_random = random;
					object obj9 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					bool flag = (nint)obj9 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					object obj10 = 0;
					float num3 = num - zoneSizeAdjustment;
					float num4 = (float)obj5 - 1f;
					float num5 = num3 * num4;
					float num6 = num5 + (float)ret;
					float num7 = num6 - num2;
					float num8 = num7 + zoneSizeAdjustment;
					object obj11 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v25+24+v136 @ rsi_v8*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					flag2 = (nint)obj11 < 0;
					obj = obj11;
				}
				while (flag2);
			}
			return horizontalFixedSpawnLocations;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	public DamagingZonePrefab()
	{
		//IL_013f: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3772]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		timeBeforeActivation = 500f;
		warningTime = 600f;
		enableGroundVisuals = true;
		width = -1f;
		height = -1f;
		verticalSpawnCount = 1;
		horizontalSpawnCount = 1;
		frameLocation = "";
		framePadding = 2;
		frameScale = 1f;
		fps = 1;
		particleQuantity = 1;
		particleFrequency = 1000f;
		particleLifespan = 10f;
		minParticleSpeed = 0.1f;
		maxParticleSpeed = 1f;
		maxParticleAngle = 360f;
		maxParticleRotation = 360f;
		minParticleScale = 0.1f;
		maxParticleScale = 1f;
		doParticlesBounce = true;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
