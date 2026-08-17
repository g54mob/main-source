using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MechProjectile_BallisticMissile : Projectile
{
	private ParticleSystem _MissileVFX;

	private TrailRenderer _Trail;

	private const float VFXScale = 0.75f;

	private const float TrailDuration = 800f;

	protected Timer _movementTimer;

	protected Timer _expireTimer;

	private bool _cachedFlipX;

	private float _cachedWeaponSpeed;

	private float _cachedProjSpeed;

	private float _currentSpeed;

	private float _currentAngle;

	protected float _scaledTurnSpeed;

	protected float _scaledTurnDuration;

	protected float _scaledTurnDelay;

	private bool _isDecelerating;

	private bool _isTurning;

	private bool _isAccelerating;

	private bool _isDespawning;

	protected virtual float Radius => 10f;

	protected virtual float2 SpawnOffset
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
	}

	protected virtual List<float> SpawnAngles
	{
		get
		{
			//IL_0028: Expected O, but got I
			//IL_0082: Expected O, but got I
			//IL_0877: Expected O, but got I
			//IL_0116: Expected O, but got I
			//IL_08ad: Expected O, but got I
			//IL_01aa: Expected O, but got I
			//IL_08d5: Expected O, but got I
			//IL_023e: Expected O, but got I
			//IL_08fd: Expected O, but got I
			//IL_02d2: Expected O, but got I
			//IL_0925: Expected O, but got I
			//IL_0366: Expected O, but got I
			//IL_094d: Expected O, but got I
			//IL_03fa: Expected O, but got I
			//IL_0975: Expected O, but got I
			//IL_048e: Expected O, but got I
			//IL_099d: Expected O, but got I
			//IL_0522: Expected O, but got I
			//IL_09c5: Expected O, but got I
			//IL_05b6: Expected O, but got I
			//IL_09ed: Expected O, but got I
			//IL_064a: Expected O, but got I
			//IL_0a15: Expected O, but got I
			//IL_06de: Expected O, but got I
			//IL_0a3d: Expected O, but got I
			//IL_0772: Expected O, but got I
			//IL_0a65: Expected O, but got I
			//IL_0806: Expected O, but got I
			List<float> list = new List<float>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v4+18]");
			if (num >= 0)
			{
				list.AddWithResize(25f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj2 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v4+18]");
				if (num2 >= 0)
				{
					goto IL_087c;
				}
				_ = 1103626240;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v5+18]");
			if (num3 >= 0)
			{
				list.AddWithResize(155f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v5+18]");
				if (num4 >= 0)
				{
					goto IL_087c;
				}
				_ = 1125842944;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v6+18]");
			if (num5 >= 0)
			{
				list.AddWithResize(35f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj6 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v6+18]");
				if (num6 >= 0)
				{
					goto IL_087c;
				}
				_ = 1108082688;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v7+18]");
			if (num7 >= 0)
			{
				list.AddWithResize(145f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj8 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v7+18]");
				if (num8 >= 0)
				{
					goto IL_087c;
				}
				_ = 1125187584;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v8+18]");
			if (num9 >= 0)
			{
				list.AddWithResize(45f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj10 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v8+18]");
				if (num10 >= 0)
				{
					goto IL_087c;
				}
				_ = 1110704128;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v9+18]");
			if (num11 >= 0)
			{
				list.AddWithResize(135f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj12 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v9+18]");
				if (num12 >= 0)
				{
					goto IL_087c;
				}
				_ = 1124532224;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v10+18]");
			if (num13 >= 0)
			{
				list.AddWithResize(55f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj14 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v10+18]");
				if (num14 >= 0)
				{
					goto IL_087c;
				}
				_ = 1113325568;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v11+18]");
			if (num15 >= 0)
			{
				list.AddWithResize(125f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj16 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v11+18]");
				if (num16 >= 0)
				{
					goto IL_087c;
				}
				_ = 1123680256;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v12+18]");
			if (num17 >= 0)
			{
				list.AddWithResize(65f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj18 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v12+18]");
				if (num18 >= 0)
				{
					goto IL_087c;
				}
				_ = 1115815936;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v13+18]");
			if (num19 >= 0)
			{
				list.AddWithResize(115f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj20 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v13+18]");
				if (num20 >= 0)
				{
					goto IL_087c;
				}
				_ = 1122369536;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v14+18]");
			if (num21 >= 0)
			{
				list.AddWithResize(75f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj22 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v14+18]");
				if (num22 >= 0)
				{
					goto IL_087c;
				}
				_ = 1117126656;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v15+18]");
			if (num23 >= 0)
			{
				list.AddWithResize(105f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj24 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v15+18]");
				if (num24 >= 0)
				{
					goto IL_087c;
				}
				_ = 1121058816;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v16+18]");
			if (num25 >= 0)
			{
				list.AddWithResize(85f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj26 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v16+18]");
				if (num26 >= 0)
				{
					goto IL_087c;
				}
				_ = 1118437376;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v17+18]");
			if (num27 >= 0)
			{
				list.AddWithResize(95f);
				return list;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj28 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v17+18]");
			if (num28 < 0)
			{
				_ = 1119748096;
				return list;
			}
			goto IL_087c;
			IL_087c:
			return (List<float>)(object)new IndexOutOfRangeException();
		}
	}

	protected virtual float TurnSpeed => 210f;

	protected virtual float TurnDuration => 500f;

	protected virtual float TurnDelay => 800f;

	protected virtual float DecelRate => 2f;

	protected virtual float AccelRate => 5f;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0125: Invalid comparison between F4 and I
		//IL_014c: Expected F4, but got I
		//IL_01ce: Expected O, but got I4
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_0276: Expected I, but got O
		//IL_00d7: Expected F4, but got O
		//IL_03d2: Expected O, but got I
		//IL_043d: Expected F4, but got I
		//IL_00dc->IL00dc: Incompatible stack heights: 1 vs 0
		//IL_03f2->IL04db: Incompatible stack heights: 1 vs 0
		//IL_059c->IL04db: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			SetupTrail();
		}
		ParticleSystem missileVFX = _MissileVFX;
		float2 float5 = default(float2);
		float num2 = default(float);
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_MissileVFX == null)
			{
				goto IL_04db;
			}
			Transform transform = _MissileVFX.transform;
			float num = (float)float5 * 0.75f;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float2 value = default(float2);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			_MissileVFX.Play(withChildren: true);
			num2 = (float)Vector3.oneVector;
		}
		_speed = 2f;
		if ((object)_weapon != null)
		{
			float num3 = _weapon.PSpeed();
			float num4 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A0FED8]");
			if (num4 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A0FED8]");
				num2 = 0f;
			}
			_cachedWeaponSpeed = num2;
			float projectileSpeed = base.ProjectileSpeed;
			_cachedProjSpeed = num2;
			float projectileSpeed2 = base.ProjectileSpeed;
			Weapon weapon2 = _weapon;
			_currentSpeed = num2;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					_cachedFlipX = characterController._isFlipped;
					if ((object)_weapon != null)
					{
						float num5 = _weapon.PArea();
						ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
						float2 float6 = base.position;
						float2 spawnOffset = SpawnOffset;
						base.position = float5;
						ParticleSystem particleSystem = (ParticleSystem)(object)body;
						_isCullable = false;
						_isDespawning = false;
						float radius = Radius;
						float radius2 = Radius;
						object obj = float5 ^ -0f;
						float radius3 = Radius;
						object obj2 = obj ^ -0f;
						if (body != null)
						{
							nint num6 = (nint)particleSystem;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v437 @ rdx_v28 (Il2CppClass<UnityEngine.ParticleSystem>)+218] (should have been resolved before IL gen)");
							BaseBody baseBody = body;
							if (body != null)
							{
								baseBody._enable = true;
								float turnSpeed = TurnSpeed;
								float num7 = (_scaledTurnSpeed = (float)obj2 * _cachedWeaponSpeed);
								float turnDuration = TurnDuration;
								float num8 = (_scaledTurnDuration = num7 / _cachedWeaponSpeed);
								float turnDelay = TurnDelay;
								float scaledTurnDelay = num8 / _cachedWeaponSpeed;
								_isDecelerating = false;
								_isAccelerating = false;
								_scaledTurnDelay = scaledTurnDelay;
								List<float> spawnAngles = SpawnAngles;
								List<float> spawnAngles2 = SpawnAngles;
								if (spawnAngles2 != null && spawnAngles != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v59 (System.Collections.Generic.List`1<System.Single>)+18]");
									int num9 = (int)((nint)index % (nint)0);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v58 (System.Collections.Generic.List`1<System.Single>)+18]");
									bool flag2 = (nint)num9 >= (nint)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v58 (System.Collections.Generic.List`1<System.Single>)+10]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v58 (System.Collections.Generic.List`1<System.Single>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v41+18]");
										bool flag3 = (nint)num9 >= (nint)0;
										bool flag4 = !_cachedFlipX;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v41+20+v439 @ rdx_v40 (System.Int32)*4]");
										_currentAngle = 0f;
										if (!flag4)
										{
											float num10 = 180f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v41+20+v439 @ rdx_v40 (System.Int32)*4]");
											float currentAngle = num10 - 0f;
											_currentAngle = currentAngle;
										}
										SetMovementPattern();
										Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 688 Invalid \"Jump target not found in method: 0x187225980\"");
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04db;
		IL_04db:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		UpdateVelocity();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x187225630\"");
	}

	private void CheckHittingScreenEdges()
	{
		//IL_0065: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_00f8: Invalid comparison between O and F4
		//IL_01db: Invalid comparison between F4 and O
		//IL_022b: Invalid comparison between O and F4
		//IL_027b: Invalid comparison between F4 and O
		//IL_019d->IL0142: Incompatible stack heights: 1 vs 0
		//IL_0085->IL0142: Incompatible stack heights: 1 vs 0
		//IL_00c4->IL0142: Incompatible stack heights: 1 vs 0
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform weapon = (Transform)(object)_weapon;
				if ((object)_weapon != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v5 (UnityEngine.Transform)+58]");
					Transform transform2 = (Transform)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v5 (UnityEngine.Transform)+58]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v6 (UnityEngine.Transform)+198]");
						Transform transform3 = (Transform)0;
						float2 float5 = base.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v6 (UnityEngine.Transform)+198]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v7 (UnityEngine.Transform)+2C]");
							float num = 0f * 0.5f;
							object obj = default(object);
							float num2 = num + (float)obj;
							object obj2 = default(object);
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
							{
								OnHitScreenEdgeTop();
							}
							float2 float6 = base.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v7 (UnityEngine.Transform)+2C]");
							float num3 = 0f * 0.5f;
							float num4 = (float)obj - num3;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
							{
								OnHitScreenEdgeBottom();
							}
							float2 float7 = base.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v7 (UnityEngine.Transform)+28]");
							float num5 = 0f * 0.5f;
							float num6 = num5 + (float)ret;
							if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
							{
								OnHitScreenEdgeRight();
							}
							float2 float8 = base.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v7 (UnityEngine.Transform)+28]");
							float num7 = 0f * 0.5f;
							float num8 = (float)ret - num7;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float8))
							{
								OnHitScreenEdgeLeft();
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual void OnHitScreenEdgeTop()
	{
	}

	protected virtual void OnHitScreenEdgeBottom()
	{
		StartDespawn();
	}

	protected virtual void OnHitScreenEdgeRight()
	{
		StartDespawn();
	}

	protected virtual void OnHitScreenEdgeLeft()
	{
		StartDespawn();
	}

	protected virtual void SetMovementPattern()
	{
		_isDecelerating = true;
		_isAccelerating = false;
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_isTurning = true;
			Action onComplete2 = delegate
			{
				//IL_00eb: Expected O, but got I4
				_currentSpeed = _cachedProjSpeed;
				_isDecelerating = false;
				_isAccelerating = true;
				TrailRenderer trail = _Trail;
				if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
				{
					_Trail.emitting = true;
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1.5f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 1, time);
			};
			float duration2 = _scaledTurnDuration * 0.001f;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer movementTimer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_movementTimer = movementTimer2;
		};
		float duration = _scaledTurnDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer movementTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_movementTimer = movementTimer;
	}

	protected void UpdateVelocity()
	{
		//IL_010c: Expected I4, but got I8
		//IL_017d: Expected I, but got O
		//IL_0290: Expected O, but got I8
		//IL_007d: Expected I, but got O
		//IL_0345: Unsupported input type for neg.
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_013c: Expected O, but got I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected I4, but got Unknown
		//IL_0166: Expected O, but got I4
		//IL_0220: Expected O, but got F4
		//IL_0368: Expected F4, but got O
		bool flag = !_isDecelerating;
		EME_MechProjectile_BallisticMissile eME_MechProjectile_BallisticMissile = this;
		float num5 = default(float);
		if (!flag)
		{
			float decelRate = DecelRate;
			Weapon weapon = _weapon;
			if ((object)_weapon == null)
			{
				goto IL_024e;
			}
			nint num = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+460]");
			nint num2 = 0;
			float num3 = _weapon.PSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			float num4 = num5 * num5;
			num5 = deltaTime * num4;
			float num6 = 1f - num5;
			float currentSpeed = num6 * _currentSpeed;
			_currentSpeed = currentSpeed;
			eME_MechProjectile_BallisticMissile = null;
		}
		if (_isTurning)
		{
			int num7 = (int)(_indexInWeapon & 0x80000001L);
			if ((_isTurning ? 1 : 0) < (false ? 1 : 0))
			{
				object obj = num7 - 1;
				object obj2 = obj | -2;
				num7 = obj2 + 1;
			}
			bool flag2 = num7 == 1;
			object obj3 = 4294967295L;
			if (!flag2)
			{
				obj3 = 1;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			object obj4 = 0 - obj3;
			if (!_cachedFlipX)
			{
				obj4 = obj3;
			}
			float currentSpeed = (float)obj4 * _scaledTurnSpeed;
			num5 = deltaTime2 * currentSpeed;
			float currentAngle = _currentAngle - num5;
			_currentAngle = currentAngle;
			eME_MechProjectile_BallisticMissile = null;
		}
		if (_isAccelerating)
		{
			nint num8 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile_BallisticMissile>)+4B0]");
			nint num2 = 0;
			float accelRate = AccelRate;
			float deltaTime3 = PauseSystem.DeltaTime;
			float num9 = deltaTime3 * num5;
			float num10 = num9 + 1f;
			float currentSpeed2 = num10 * _currentSpeed;
			_currentSpeed = currentSpeed2;
			eME_MechProjectile_BallisticMissile = null;
		}
		float num11 = _currentAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num12 = num11 * _currentSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		ArcadeSprite sprite = _sprite;
		float num13 = num11 * _currentSpeed;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = (float2)num12;
				Transform transform = base.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Vector3 axis = default(Vector3);
				Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		goto IL_024e;
		IL_024e:
		throw new NullReferenceException();
	}

	protected void StartDecelerating()
	{
		_isDecelerating = true;
		_isAccelerating = false;
	}

	protected void EnableTurning(bool enable)
	{
		_isTurning = enable;
	}

	protected void StartAccelerating()
	{
		_isDecelerating = false;
		_isAccelerating = true;
	}

	protected void ResetMovementSpeed()
	{
		_currentSpeed = _cachedProjSpeed;
	}

	protected void EnableTrail(bool enable)
	{
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_Trail.emitting = enable;
		}
	}

	private void SetupTrail()
	{
		//IL_0315->IL0291: Incompatible stack heights: 1 vs 0
		//IL_0364->IL0291: Incompatible stack heights: 1 vs 0
		//IL_01ea->IL0291: Incompatible stack heights: 3 vs 0
		//IL_0268->IL0291: Incompatible stack heights: 5 vs 0
		float saturationMax = default(float);
		float valueMin = default(float);
		float valueMax = default(float);
		float alphaMin = default(float);
		Color color = UnityEngine.Random.ColorHSV(0.1f, 0.2f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_Trail != null)
		{
			_Trail.time = 0.8f;
			if ((object)_Trail != null)
			{
				_Trail.startWidth = 0.05f;
				if ((object)_Trail != null)
				{
					_Trail.endWidth = 0.025f;
					Sprite sprite = default(Sprite);
					RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
					if ((object)_Trail != null)
					{
						Material material = ((Renderer)_Trail).GetMaterial();
						RenderingExtensions.SetAlpha(material, 1f);
						Renderer trail = _Trail;
						if ((object)_Trail != null)
						{
							bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
							TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
							if ((object)_Trail != null)
							{
								_Trail.emitting = true;
								Gradient gradient = new Gradient();
								IntPtr ptr = Gradient.Init();
								gradient.m_Ptr = ptr;
								gradient.m_RequiresNativeCleanup = true;
								GradientColorKey[] array = new GradientColorKey[2];
								if (array != null)
								{
									bool flag2 = array.Length <= 0;
									_ = color.r;
									_ = 0;
									bool flag3 = array.Length <= 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
									_ = 0;
									_ = 1f;
									GradientAlphaKey[] array2 = new GradientAlphaKey[2];
									if (array2 != null)
									{
										bool flag4 = array2.Length <= 0;
										_ = 1061997773;
										bool flag5 = array2.Length <= 1;
										_ = 0;
										_ = 1065353216;
										gradient.SetKeys(array, array2);
										if ((object)_Trail != null)
										{
											_Trail.colorGradient = gradient;
											TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PlaySfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 1, time);
	}

	private void StartDespawn()
	{
		//IL_00e0: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		_isDespawning = true;
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		Action onComplete = delegate
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			ParticleSystem missileVFX = _MissileVFX;
			if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
			{
				_MissileVFX.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer movementTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_movementTimer = movementTimer;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile_BallisticMissile>)+370]");
		Action onComplete2 = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Timer expireTimer = Timers.Register(0.8f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void Despawn()
	{
		ParticleSystem missileVFX = _MissileVFX;
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			_MissileVFX.Clear(withChildren: true);
		}
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CSetMovementPattern_003Eb__41_0()
	{
		_isTurning = true;
		Action onComplete = delegate
		{
			//IL_00eb: Expected O, but got I4
			_currentSpeed = _cachedProjSpeed;
			_isDecelerating = false;
			_isAccelerating = true;
			TrailRenderer trail = _Trail;
			if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
			{
				_Trail.emitting = true;
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1.5f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 1, time);
		};
		float duration = _scaledTurnDuration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer movementTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_movementTimer = movementTimer;
	}

	private void _003CSetMovementPattern_003Eb__41_1()
	{
		//IL_00eb: Expected O, but got I4
		_currentSpeed = _cachedProjSpeed;
		_isDecelerating = false;
		_isAccelerating = true;
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_Trail.emitting = true;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1.5f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 1, time);
	}

	private void _003CStartDespawn_003Eb__50_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		ParticleSystem missileVFX = _MissileVFX;
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			_MissileVFX.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
	}
}
