using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_AlucardSword2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, bool> _003C_003E9__9_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CCheckOtherEvos_003Eb__9_0(Equipment x)
		{
			//IL_006d: Expected I4, but got O
			//IL_0034: Expected I4, but got O
			if ((object)x != null && x._currentJsonDataObject != null)
			{
				bool flag = (byte)(int)x._currentJsonDataObject.ToObject<object>() != 0;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v4 (System.Boolean)+60]");
					return false;
				}
				return flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int localIndex;

		public TP_AlucardSword2_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_012f: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
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
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							TP_AlucardSword2_Weapon tP_AlucardSword2_Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private const int MaxGhostsPerFire = 6;

	private int _totalOtherEvos;

	private int _fireCounter;

	public int NumOtherEvos
	{
		get
		{
			int result = _totalOtherEvos;
			if (_totalOtherEvos > 5)
			{
				result = 5;
			}
			return result;
		}
	}

	public int ModFireCounter
	{
		get
		{
			//IL_0018: Expected O, but got I
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected I4, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
			nint num = default(nint);
			object obj = num >> 31;
			object obj2 = num + obj;
			object obj3 = obj2 * 2;
			object obj4 = obj2 + obj3;
			object obj5 = obj4 + obj4;
			return _fireCounter - obj5;
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0033: Expected I, but got O
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_00b8: Expected O, but got I4
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022b: Invalid comparison between O and F4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_010d: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = FireOneProjectile(vector, 0, _targetTransform);
		nint num = (nint)this;
		float num2 = base.PAmount();
		float num3 = (float)vector * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj2 = default(object);
		object obj = obj2 + 1;
		if ((nint)obj < 6)
		{
			if ((nint)obj <= 1)
			{
				goto IL_01f2;
			}
		}
		else
		{
			obj = 6;
		}
		bool flag = true;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			object obj3 = flag * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj3 <= 0)
			{
				Vector2 playerPos = base.PlayerPos;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				num3 = (float)playerPos;
			}
			else
			{
				_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass7_0();
				CS_0024_003C_003E8__locals8._003C_003E4__this = this;
				CS_0024_003C_003E8__locals8.localIndex = (flag ? 1 : 0);
				WeaponData currentWeaponData2 = _currentWeaponData;
				Action onComplete = delegate
				{
					//IL_012f: Expected O, but got I4
					//IL_00b4: Expected O, but got I
					//IL_00e9: Expected I, but got O
					//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
					//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
					//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
					if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
					{
						GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj5 == null)
							{
								return;
							}
							GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
									float2 position2 = ((ArcadeSprite)0).position;
									TP_AlucardSword2_Weapon tP_AlucardSword2_Weapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
									{
										nint num8 = (nint)gameObject2;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
										return;
									}
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num4 = (float)(flag ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				num3 = num4 * 0.001f;
				Timer lastShotTimer = Timers.Register(num3, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < (nint)obj);
		goto IL_01f2;
		IL_01f2:
		float num5 = base.PInterval();
		float num6 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num6 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num7 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		int fireCounter = _fireCounter + 1;
		_fireCounter = fireCounter;
		CheckOtherEvos();
		return base.FireOneProjectile(pos, index, target, pool);
	}

	private void CheckOtherEvos()
	{
		//IL_01f0: Expected I, but got O
		//IL_0206: Expected O, but got I
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_02c9: Expected O, but got I4
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_00d8: Expected O, but got I4
		_totalOtherEvos = 0;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		Func<Equipment, bool> predicate = _003C_003Ec._003C_003E9__9_0;
		if (_003C_003Ec._003C_003E9__9_0 == null)
		{
			Func<Equipment, bool> func = (_003C_003Ec._003C_003E9__9_0 = delegate(Equipment x)
			{
				//IL_006d: Expected I4, but got O
				//IL_0034: Expected I4, but got O
				if ((object)x == null || x._currentJsonDataObject == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				bool flag2 = (byte)(int)x._currentJsonDataObject.ToObject<object>() != 0;
				if (flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v4 (System.Boolean)+60]");
					return false;
				}
				return flag2;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSword2_Weapon+<>c>)+B8]");
			object obj = (nint)0 + (nint)8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			predicate = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj4 * 8;
				object obj6 = 6603577472L + obj5;
				object obj7 = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj8 = 1 << (int)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v14+462E0]");
					object obj9 = 0 | obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v14+462E0]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v14+462E0]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v14+462E0]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v14+462E0]");
				}
				while (num3 != 0);
				predicate = func;
			}
		}
		IEnumerable<Equipment> enumerable = Enumerable.Where(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, predicate);
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj10 = 0;
				throw new NullReferenceException();
			}
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}
}
