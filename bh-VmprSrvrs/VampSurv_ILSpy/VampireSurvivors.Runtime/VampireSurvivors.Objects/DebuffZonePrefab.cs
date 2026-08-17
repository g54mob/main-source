using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects;

public class DebuffZonePrefab : DamagingZonePrefab
{
	public DebuffZoneFlexible.DebuffType debuffType;

	public float debuffValue;

	protected unsafe override void SpawnPattern()
	{
		//IL_0036: Expected O, but got I4
		//IL_00f4: Expected F4, but got O
		//IL_00f4: Expected O, but got F4
		//IL_038e: Expected O, but got Ref
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_0307: Expected O, but got F4
		//IL_01b8: Expected I4, but got O
		//IL_01c0: Expected O, but got Ref
		//IL_036b: Expected F4, but got O
		List<float2> spawnLocations = GetSpawnLocations();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		object obj = 0;
		float num = default(float);
		float2 float5 = default(float2);
		object obj3 = default(object);
		object obj4 = default(object);
		Vector3 center = default(Vector3);
		object obj5 = default(object);
		object obj6 = default(object);
		while (true)
		{
			Camera main = Camera.main;
			DebuffZoneFlexible debuffZoneFlexible = DebuffZoneFlexible.CreateDebuffZone(main);
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj2 >= 0)
			{
				break;
			}
			debuffZoneFlexible.InitDamageZone(damage, duration, timeBeforeActivation, num, float5);
			((DamageZoneFlexible)debuffZoneFlexible)._warningTimeMillis = warningTime;
			((DamageZoneFlexible)debuffZoneFlexible)._haveWarningMark = hasWarningMark;
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
			float num2 = followSpeed;
			debuffZoneFlexible.InitDamageZoneBehaviour(lockX, lockY, follow, (Transform)num, (float)float5);
			float num3 = debuffValue;
			DebuffZoneFlexible.DebuffType debuffType = this.debuffType;
			debuffZoneFlexible.InitDebuffZoneBehaviour(this.debuffType, debuffValue);
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
					debuffType = (DebuffZoneFlexible.DebuffType)main2;
					DebuffZoneFlexible debuffZoneFlexible2 = (DebuffZoneFlexible)(&center);
				}
				else
				{
					zoneWidth = width;
					bool flag = lockY;
					DebuffZoneFlexible debuffZoneFlexible2 = debuffZoneFlexible;
				}
				_zoneWidth = zoneWidth;
				Vector3 vector = (Vector3)height;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				if (obj5 != null)
				{
					Camera main3 = Camera.main;
					Bounds bounds2 = CameraExtensions.OrthographicBounds(main3);
					vector = bounds2.m_Center;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v31 (UnityEngine.Bounds)+10]");
					float num5 = 0f * 2f;
					num3 = num5 * 100f;
					center = bounds2.m_Center;
					bool flag = false;
				}
				else
				{
					num3 = height;
				}
				_zoneHeight = num3;
				float zoneWidth2 = _zoneWidth;
				debuffZoneFlexible.InitDamageZoneRectangle(_zoneWidth, num3);
				bool flag2 = true;
				num2 = (float)vector;
			}
			else
			{
				float zoneWidth2 = radius;
				bool flag = enableGroundVisuals;
				_zoneRadius = radius;
				debuffZoneFlexible.InitDamageZoneCircle(radius, enableGroundVisuals);
				bool flag2 = false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			SetupVisualElement((Vector3)(&obj6), debuffZoneFlexible, alignment);
			debuffZoneFlexible.EnableZone();
			obj++;
			object obj7 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag3 = (nint)obj7 < 0;
			obj6 = obj4;
			if (!flag3)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected unsafe override void SpawnCrosshatchPattern()
	{
		//IL_0028: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected I4, but got Unknown
		//IL_01f7: Expected O, but got Ref
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_023b: Expected O, but got I4
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected I4, but got Unknown
		//IL_0465: Expected O, but got Ref
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Expected O, but got Unknown
		//IL_0061->IL04af: Incompatible stack heights: 1 vs 0
		//IL_007e->IL04af: Incompatible stack heights: 1 vs 0
		//IL_02d2->IL04af: Incompatible stack heights: 1 vs 0
		//IL_02ef->IL04af: Incompatible stack heights: 1 vs 0
		//IL_00ea->IL04af: Incompatible stack heights: 1 vs 0
		//IL_035b->IL04af: Incompatible stack heights: 1 vs 0
		//IL_01c4->IL04af: Incompatible stack heights: 3 vs 0
		//IL_0432->IL04af: Incompatible stack heights: 3 vs 0
		//IL_0256->IL054a: Incompatible stack heights: 3 vs 0
		//IL_025b->IL025b: Incompatible stack heights: 3 vs 0
		//IL_04a9->IL05f6: Incompatible stack heights: 3 vs 0
		//IL_04ae->IL04ae: Incompatible stack heights: 3 vs 0
		List<float2> verticalFixedSpawnLocations = GetVerticalFixedSpawnLocations();
		object obj;
		float num = default(float);
		float2 spawnLocation = default(float2);
		object obj6 = default(object);
		object obj8 = default(object);
		if (verticalFixedSpawnLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag = (nint)0 <= (nint)0;
			obj = 0;
			object obj2 = 0;
			if (flag)
			{
				goto IL_025b;
			}
			while (true)
			{
				Camera main = Camera.main;
				DebuffZoneFlexible debuffZoneFlexible = DebuffZoneFlexible.CreateDebuffZone(main);
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag2 = (nint)obj3 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0 || (object)debuffZoneFlexible == null)
				{
					break;
				}
				debuffZoneFlexible.InitDamageZone(damage, duration, timeBeforeActivation, num, spawnLocation);
				((DamageZoneFlexible)debuffZoneFlexible)._warningTimeMillis = warningTime;
				((DamageZoneFlexible)debuffZoneFlexible)._haveWarningMark = hasWarningMark;
				Camera main2 = Camera.main;
				if ((object)main2 == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)main2).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)main2).m_CachedPtr);
				Transform targetTransform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				((DamageZoneFlexible)debuffZoneFlexible)._followSpeed = followSpeed;
				((DamageZoneFlexible)debuffZoneFlexible)._follow = follow;
				((DamageZoneFlexible)debuffZoneFlexible)._targetTransform = targetTransform;
				((DamageZoneFlexible)debuffZoneFlexible)._lockX = false;
				debuffZoneFlexible.InitDebuffZoneBehaviour(debuffType, debuffValue);
				Camera main3 = Camera.main;
				Bounds bounds = CameraExtensions.OrthographicBounds(main3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ rax_v35 (UnityEngine.Bounds)+10]");
				float num2 = 0f * 2f;
				float num3 = num2 * 100f;
				debuffZoneFlexible.InitDamageZoneRectangle(width, num3);
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag4 = (nint)obj4 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj5 = obj2 & 1;
				DamageZoneFlexible.ZoneAlignment newAlignment = (DamageZoneFlexible.ZoneAlignment)(obj5 + 3);
				SetupVisualElement((Vector3)(&obj6), debuffZoneFlexible, newAlignment);
				debuffZoneFlexible.EnableZone();
				obj2++;
				object obj7 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag5 = (nint)obj7 < 0;
				obj6 = obj8;
				obj = 0;
				num = num;
				obj6 = obj8;
				if (flag5)
				{
					continue;
				}
				goto IL_025b;
			}
		}
		goto IL_04af;
		IL_04af:
		throw new NullReferenceException();
		IL_025b:
		List<float2> horizontalFixedSpawnLocations = GetHorizontalFixedSpawnLocations();
		if (horizontalFixedSpawnLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v49 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag6 = (nint)0 <= (nint)0;
			object obj9 = obj;
			if (flag6)
			{
				return;
			}
			while (true)
			{
				Camera main4 = Camera.main;
				DebuffZoneFlexible debuffZoneFlexible2 = DebuffZoneFlexible.CreateDebuffZone(main4);
				object obj10 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v49 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag7 = (nint)obj10 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v49 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0 || (object)debuffZoneFlexible2 == null)
				{
					break;
				}
				debuffZoneFlexible2.InitDamageZone(damage, duration, timeBeforeActivation, num, spawnLocation);
				((DamageZoneFlexible)debuffZoneFlexible2)._warningTimeMillis = warningTime;
				((DamageZoneFlexible)debuffZoneFlexible2)._haveWarningMark = hasWarningMark;
				Camera main5 = Camera.main;
				if ((object)main5 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v56 (UnityEngine.Camera)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v56 (UnityEngine.Camera)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform targetTransform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				((DamageZoneFlexible)debuffZoneFlexible2)._followSpeed = followSpeed;
				((DamageZoneFlexible)debuffZoneFlexible2)._follow = follow;
				((DamageZoneFlexible)debuffZoneFlexible2)._targetTransform = targetTransform2;
				((DamageZoneFlexible)debuffZoneFlexible2)._lockX = true;
				debuffZoneFlexible2.InitDebuffZoneBehaviour(debuffType, debuffValue);
				Camera main6 = Camera.main;
				float num4 = (float)CameraExtensions.OrthographicBounds(main6).m_Extents * 2f;
				float num5 = num4 * 100f;
				debuffZoneFlexible2.InitDamageZoneRectangle(num5, height);
				object obj11 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v49 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag9 = (nint)obj11 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v49 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj12 = obj9 & 1;
				DamageZoneFlexible.ZoneAlignment newAlignment = (DamageZoneFlexible.ZoneAlignment)(obj12 + 1);
				SetupVisualElement((Vector3)(&obj6), debuffZoneFlexible2, newAlignment);
				debuffZoneFlexible2.EnableZone();
				obj9++;
				object obj13 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v49 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag10 = (nint)obj13 < 0;
				obj6 = obj8;
				if (!flag10)
				{
					return;
				}
			}
		}
		goto IL_04af;
	}

	public DebuffZonePrefab()
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
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
