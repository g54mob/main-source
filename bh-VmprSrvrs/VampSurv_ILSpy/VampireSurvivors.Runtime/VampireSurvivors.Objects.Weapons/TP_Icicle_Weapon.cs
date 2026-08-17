using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Icicle_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int localIndex;

		public TP_Icicle_Weapon _003C_003E4__this;

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
							TP_Icicle_Weapon tP_Icicle_Weapon = _003C_003E4__this;
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

	[NonSerialized]
	public float angleTime;

	[NonSerialized]
	public float AimTime;

	[NonSerialized]
	public float AimUnit = (float)Math.PI / 6f;

	public int Spawned()
	{
		//IL_0093: Expected I4, but got O
		BulletPool projectilePool = _projectilePool;
		if (_projectilePool != null)
		{
			ObjectPool pool = projectilePool._pool;
			if ((object)projectilePool._pool != null)
			{
				Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
				if (pool._aliveObjects != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
					return (int)(num - 0);
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	protected override void Awake()
	{
		base.Awake();
		base._003CFreezeChance_003Ek__BackingField = 0.05f;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0041: Invalid comparison between O and F4
		//IL_0052: Expected F4, but got O
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0218: Invalid comparison between O and F4
		//IL_0073: Invalid comparison between O and F4
		//IL_0084: Expected F4, but got O
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00f0: Expected F4, but got O
		//IL_01cb: Invalid comparison between F4 and I4
		float num = angleTime + (float)Math.PI / 2f;
		angleTime = num;
		float aimTime = AimUnit + AimTime;
		AimTime = aimTime;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num2 = base.PAmount();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num3 = (float)vector;
		if (!flag)
		{
			float num4 = base.PAmount();
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			num3 = (float)vector;
			if (!flag2)
			{
				bool flag3 = true;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj = flag3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						num3 = (float)playerPos;
					}
					else
					{
						_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass5_0();
						CS_0024_003C_003E8__locals8._003C_003E4__this = this;
						CS_0024_003C_003E8__locals8.localIndex = (flag3 ? 1 : 0);
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
									bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj3 == null)
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
											TP_Icicle_Weapon tP_Icicle_Weapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
											{
												nint num10 = (nint)gameObject2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num5 = (float)(flag3 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num3 = num5 * 0.001f;
						Timer lastShotTimer = Timers.Register(num3, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
					float num6 = base.PAmount();
				}
				while (num3 > (float)(flag3 ? 1 : 0));
			}
		}
		float num7 = base.PInterval();
		float num8 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.35f;
			}
		}
	}
}
