using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Unused_TP_AlchemyWhip_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int localIndex;

		public Unused_TP_AlchemyWhip_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__1()
		{
			//IL_00c2: Expected O, but got I4
			//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.shiftWhipForce(localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private int _iterations;

	private int _totalNodes;

	private float _nodeDistance;

	private Vector2 _gravity;

	private Vector2 _whipForce;

	private VerletNode[] _nodes;

	private Projectile[] _whipProjectiles;

	private List<float2> _whipFireList;

	private float _flipNum;

	private float _tempArea;

	private Timer _resetFireTimer;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0094: Expected I, but got O
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_010f: Expected I, but got O
		//IL_016e->IL019a: Incompatible stack heights: 1 vs 0
		//IL_02c7->IL019a: Incompatible stack heights: 1 vs 0
		//IL_00b7->IL00b7: Incompatible stack heights: 2 vs 1
		//IL_0249->IL019a: Incompatible stack heights: 2 vs 0
		//IL_0132->IL0132: Incompatible stack heights: 3 vs 2
		//IL_0275->IL027a: Incompatible stack heights: 3 vs 1
		//IL_027a->IL015f: Incompatible stack heights: 3 vs 1
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		VerletNode[] nodes = new VerletNode[_totalNodes];
		_nodes = nodes;
		Projectile[] whipProjectiles = new Projectile[_totalNodes];
		_whipProjectiles = whipProjectiles;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			if (_totalNodes <= 0)
			{
				goto IL_015f;
			}
			Transform transform2 = null;
			object obj2 = default(object);
			object obj = obj2;
			WeaponType weaponType3 = WeaponType.VOID;
			object obj3 = default(object);
			Vector2 pos = default(Vector2);
			object obj4 = default(object);
			while (true)
			{
				VerletNode[] nodes2 = _nodes;
				VerletNode verletNode = null;
				verletNode.position = ret;
				verletNode.oldPosition = ret;
				if (_nodes == null)
				{
					break;
				}
				if (verletNode != null)
				{
					nint num = (nint)nodes2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag2 = obj3 == null;
				}
				bool flag3 = (int)weaponType3 >= nodes2.Length;
				nodes2[(int)weaponType3] = verletNode;
				obj -= _nodeDistance;
				transform2 = _targetTransform;
				Transform whipProjectiles2 = (Transform)(object)_whipProjectiles;
				Projectile projectile = base.FireOneProjectile(pos, (int)weaponType3, _targetTransform);
				if (_whipProjectiles == null)
				{
					break;
				}
				if ((object)projectile != null)
				{
					nint num2 = (nint)whipProjectiles2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag4 = obj4 == null;
				}
				WeaponType num3 = weaponType3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (UnityEngine.Transform)+18]");
				bool flag5 = (nint)num3 >= (nint)0;
				weaponType3++;
				if ((int)weaponType3 < _totalNodes)
				{
					continue;
				}
				goto IL_015f;
			}
		}
		goto IL_019a;
		IL_015f:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 480 Invalid \"Jump target not found in method: 0x187485880\"");
		goto IL_019a;
		IL_019a:
		throw new NullReferenceException();
	}

	private void updateScale()
	{
		//IL_0060: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_00b7: Expected O, but got I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		float num = base.PArea();
		float num2 = default(float);
		_tempArea = num2;
		float num3 = base.PArea();
		float num4 = num2 * 0.04f;
		Projectile[] whipProjectiles = _whipProjectiles;
		float num5 = (_nodeDistance = num4 + 0.04f);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < whipProjectiles.Length)
		{
			Projectile[] whipProjectiles2 = _whipProjectiles;
			float num6 = base.PArea();
			num5 += 4f;
			ArcadeSprite arcadeSprite = whipProjectiles2[obj].setScale(num5, (float?)(object)0);
			whipProjectiles = _whipProjectiles;
			obj++;
			obj2 = obj;
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_02ed: Expected I, but got O
		//IL_0303: Expected O, but got I
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_0387: Expected I, but got O
		//IL_04a3: Expected O, but got I4
		//IL_04de: Expected I, but got I8
		//IL_0285: Expected O, but got I4
		//IL_0293: Expected O, but got I4
		//IL_012a: Invalid comparison between F4 and I4
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_03c5: Invalid comparison between O and F4
		//IL_0363: Expected I, but got I8
		//IL_0226: Invalid comparison between F4 and I4
		float num = base.PArea();
		float num2 = default(float);
		bool flag = _tempArea == num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187485A26h\"");
		if (!flag)
		{
			updateScale();
		}
		Projectile[] whipProjectiles = _whipProjectiles;
		bool flag2 = false;
		bool flag3 = false;
		while ((flag2 ? 1 : 0) < whipProjectiles.Length)
		{
			Projectile[] whipProjectiles2 = _whipProjectiles;
			Projectile projectile = whipProjectiles2[flag3 ? 1u : 0u];
			BaseBody body = projectile.body;
			flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
			body._enable = true;
			whipProjectiles = _whipProjectiles;
			flag2 = flag3;
		}
		shiftWhipForce(0);
		float num3 = base.PAmount();
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (num2 > 1f)
		{
			float num4 = base.PAmount();
			if (num2 > 1f)
			{
				int num5 = 1;
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					num2 = (float)num5 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if (!(num2 > 0f))
					{
						shiftWhipForce(num5);
					}
					else
					{
						_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass13_0();
						CS_0024_003C_003E8__locals7._003C_003E4__this = this;
						CS_0024_003C_003E8__locals7.localIndex = num5;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_00c2: Expected O, but got I4
							//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals7._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj5 == null)
									{
										return;
									}
									if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
									{
										CS_0024_003C_003E8__locals7._003C_003E4__this.shiftWhipForce(CS_0024_003C_003E8__locals7.localIndex);
										return;
									}
								}
							}
							throw new NullReferenceException();
						};
						float num6 = (float)num5 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num2 = num6 * 0.001f;
						Timer lastShotTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					num5++;
					float num7 = base.PAmount();
				}
				while (num2 > (float)num5);
			}
		}
		if (_resetFireTimer != null)
		{
			Timer resetFireTimer = _resetFireTimer;
			if (!_resetFireTimer.IsDone)
			{
				num2 = _resetFireTimer.GetTimeElapsed();
				resetFireTimer._timeElapsedBeforeCancel = (float?)(object)1;
				resetFireTimer._timeElapsedBeforePause = (float?)(object)0;
			}
		}
		WeaponData currentWeaponData3 = _currentWeaponData;
		float num8 = base.PAmount();
		Action action = null;
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(Unused_TP_AlchemyWhip_Weapon._003CFire_003Eb__13_0);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		nint num10;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num10 = unchecked((nint)6447293664L);
				goto IL_049a;
			}
		}
		num10 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_049a;
		IL_049a:
		object obj3 = 24;
		float num11 = num2 * currentWeaponData3._003CrepeatInterval_003Ek__BackingField;
		float num12 = num11 * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		Timer resetFireTimer2 = Timers.Register(num12, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_resetFireTimer = resetFireTimer2;
		float num13 = base.PInterval();
		float num14 = _lastFiringInterval - num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num14 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num15 = base.PInterval();
			_lastFiringInterval = num12;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void shiftWhipForce(int index)
	{
		//IL_0051: Expected O, but got I
		//IL_0097: Expected O, but got I
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00e5: Expected O, but got F4
		List<float2> whipFireList = _whipFireList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		int num = (int)((nint)index % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj = 0;
			List<float2> whipFireList2 = _whipFireList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v8 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)num < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v8 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v7+20+v52 @ rdx_v5 (System.Int32)*8]");
				object obj3 = 0 * _flipNum;
				float num2 = (float)obj3 * 1000f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v9+24+v52 @ rdx_v5 (System.Int32)*8]");
				float num3 = 0f * 1000f;
				_whipForce = (Vector2)num2;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void InternalUpdate()
	{
		//IL_0028: Expected O, but got I4
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0077: Expected O, but got F4
		//IL_0094: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		base.InternalUpdate();
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		object obj = (flipX ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		float flipNum = (float)obj2 - 1f;
		_flipNum = flipNum;
		Simulate();
		float num = _flipNum * -5f;
		_gravity = (Vector2)num;
		bool flag = _iterations <= 0;
		object obj3 = 0;
		if (!flag)
		{
			do
			{
				ApplyConstraints();
				obj3++;
			}
			while ((nint)obj3 < _iterations);
		}
		VerletNode[] nodes = _nodes;
		object obj4 = 0;
		object obj5 = 0;
		float2 position = default(float2);
		while ((nint)obj5 < nodes.Length)
		{
			Projectile[] whipProjectiles = _whipProjectiles;
			whipProjectiles[obj4].position = position;
			obj4++;
			obj5 = obj4;
			nodes = _nodes;
		}
	}

	private unsafe void Simulate()
	{
		//IL_0051: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0262: Expected O, but got F4
		//IL_011d: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_0278: Expected O, but got F4
		//IL_032e: Expected O, but got F4
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_0320->IL0268: Incompatible stack heights: 1 vs 0
		//IL_01bd->IL0268: Incompatible stack heights: 1 vs 0
		//IL_01fb->IL0268: Incompatible stack heights: 1 vs 0
		//IL_022e->IL0068: Incompatible stack heights: 1 vs 0
		VerletNode[] nodes = _nodes;
		bool flag = _nodes == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			float2 float5 = default(float2);
			object obj15 = default(object);
			float2 float6 = default(float2);
			while (true)
			{
				if ((nint)obj < nodes.Length)
				{
					VerletNode[] nodes2 = _nodes;
					if (_nodes == null)
					{
						break;
					}
					VerletNode verletNode = nodes2[obj2];
					if (nodes2[obj2] == null)
					{
						break;
					}
					object obj3 = verletNode.position - verletNode.oldPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v10 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v10 (VampireSurvivors.Objects.Weapons.VerletNode)+1C]");
					object obj4 = num - 0;
					object obj5 = _gravity + _whipForce;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.Unused_TP_AlchemyWhip_Weapon)+168]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.Unused_TP_AlchemyWhip_Weapon)+170]");
					object obj6 = num2 + 0;
					object obj7 = Time.fixedDeltaTime;
					object obj8 = Time.fixedDeltaTime;
					object obj9 = float5 * float5;
					object obj10 = obj9 * obj6;
					object obj11 = obj9 * obj5;
					object obj12 = obj11 + obj3;
					object obj13 = obj10 + obj4;
					Vector2 position = (Vector2)(obj12 + (object)verletNode.position);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v10 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
					object obj14 = obj13 + 0;
					verletNode.position = position;
					ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
					{
						break;
					}
					Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					float2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
					if (arcadeSprite.body != null)
					{
						BaseBody body = arcadeSprite.body;
						ArcadeTransform arcadeTransform = body._transform;
						if (body._transform == null)
						{
							break;
						}
						arcadeTransform.position = ret;
						float5 = ret;
					}
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
					{
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							break;
						}
						float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						float5 = float6;
					}
					obj2++;
					verletNode.oldPosition = verletNode.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v10 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
					_ = 0;
					nodes = _nodes;
					if (_nodes == null)
					{
						break;
					}
					obj = obj2;
					continue;
				}
				float num3 = (float)_whipForce * 0.4f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.Unused_TP_AlchemyWhip_Weapon)+170]");
				float num4 = 0f * 0.4f;
				_whipForce = (Vector2)num3;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void ApplyConstraints()
	{
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0188: Expected O, but got I
		//IL_01b5: Expected F4, but got I4
		//IL_02ab: Expected O, but got F4
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_02f6: Expected O, but got F4
		//IL_00ed: Expected O, but got I4
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_014a: Expected O, but got F4
		VerletNode[] nodes = _nodes;
		object obj = 0;
		object obj2 = 0;
		object obj7 = default(object);
		while (true)
		{
			object obj3 = nodes.Length - 1;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				VerletNode[] nodes2 = _nodes;
				VerletNode[] nodes3 = _nodes;
				VerletNode verletNode = nodes2[obj2];
				object obj4 = obj2 + 1;
				VerletNode verletNode2 = nodes3[obj4];
				if (obj2 == null)
				{
					bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					object obj5 = (flipX ? 1 : 0) ^ 1;
					object obj6 = obj5 << 4;
					float num = (float)obj7 + 0.12f;
					object obj8 = 8 - obj6;
					float num2 = (float)obj8 * 0.01f;
					float num3 = num2 + (float)position;
					verletNode.position = (Vector2)num3;
				}
				object obj9 = verletNode.position - verletNode2.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rbx_v6 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbp_v6 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
				object obj10 = num4 - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbp_v6 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
				bool flag = (nint)0 <= (nint)0;
				float num5 = 0f;
				if (!flag)
				{
					VerletNode[] nodes4 = _nodes;
					float num6 = _nodeDistance / (float)nodes4.Length;
					float num7 = num6 * (float)obj2;
					float num8 = num7 + 0.02f;
					float num9 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbp_v6 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
					float num10 = num9 - 0f;
					float num11 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbp_v6 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
					num5 = num11 / 0f;
				}
				float num12 = num5 * 0.5f;
				float num13 = num12 * (float)obj10;
				float num14 = num12 * (float)obj9;
				float num15 = (float)verletNode.position + num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rbx_v6 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
				float num16 = 0f + num13;
				verletNode.position = (Vector2)num15;
				float num17 = (float)verletNode2.position - num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbp_v6 (VampireSurvivors.Objects.Weapons.VerletNode)+14]");
				float num18 = 0f - num13;
				obj2++;
				verletNode2.position = (Vector2)num17;
				nodes = _nodes;
				obj = obj2;
				continue;
			}
			break;
		}
	}

	public Unused_TP_AlchemyWhip_Weapon()
	{
		//IL_00e9: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		_iterations = 80;
		_gravity = (Vector2)0;
		_whipForce = (Vector2)0;
		_totalNodes = 20;
		_ = 3248488448L;
		float2 item = default(float2);
		_whipFireList = new List<float2>
		{
			item, item, item, item, item, item, item, item, item, item,
			item
		};
		_flipNum = 1f;
		base._002Ector();
	}

	private void _003CFire_003Eb__13_0()
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		Projectile[] whipProjectiles = _whipProjectiles;
		Projectile[] whipProjectiles2 = _whipProjectiles;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < whipProjectiles.Length)
		{
			Projectile projectile = whipProjectiles2[obj2];
			BaseBody body = projectile.body;
			obj2++;
			body._enable = false;
			whipProjectiles2 = _whipProjectiles;
			obj = obj2;
			whipProjectiles = _whipProjectiles;
		}
	}
}
