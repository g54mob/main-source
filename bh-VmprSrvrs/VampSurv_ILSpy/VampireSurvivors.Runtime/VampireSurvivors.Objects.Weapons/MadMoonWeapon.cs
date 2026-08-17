using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Weapons;

public class MadMoonWeapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<bool> _003C_003E9__30_1;

		public static Func<bool> _003C_003E9__30_0;

		public static Converter<MadMoonSymbol, int> _003C_003E9__42_0;

		public static Converter<string, MadMoonSymbol> _003C_003E9__43_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CSpinning_003Eb__30_1()
		{
			return !PauseSystem._paused;
		}

		internal bool _003CSpinning_003Eb__30_0()
		{
			return !PauseSystem._paused;
		}

		internal int _003CSerializeFinalSymbols_003Eb__42_0(MadMoonSymbol e)
		{
			return (int)e;
		}

		internal MadMoonSymbol _003CDeserializeFinalSymbols_003Eb__43_0(string e)
		{
			return (MadMoonSymbol)StringExtensions.ToInt(e);
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public MadMoonWeapon _003C_003E4__this;

		public int reel;

		public TweenCallback _003C_003E9__2;

		internal void _003CStartSpinning_003Eb__2()
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			MadMoonWeapon madMoonWeapon = _003C_003E4__this;
			MadMoonReelState[] reelStates = madMoonWeapon.reelStates;
			int num = reel;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rcx_v4 (VampireSurvivors.Objects.Weapons.MadMoonReelState[])+20+v119 @ rax_v5 (System.Int32)*4]");
			if ((nint)0 == 2 && _003C_003E4__this.isActiveAndEnabled)
			{
				MadMoonWeapon madMoonWeapon2 = _003C_003E4__this;
				object obj = reel * madMoonWeapon2.timeBetweenZones;
				float duration = (float)obj + madMoonWeapon2.spinTime;
				_003CSpinning_003Ed__30 obj2 = null;
				obj2._003C_003E1__state = 0;
				obj2._003C_003E4__this = madMoonWeapon2;
				obj2.reel = reel;
				obj2.duration = duration;
				Coroutine coroutine = madMoonWeapon2.StartCoroutine(obj2);
				MadMoonWeapon madMoonWeapon3 = _003C_003E4__this;
				MadMoonReelState[] reelStates2 = madMoonWeapon3.reelStates;
				int num2 = reel;
				_ = 3;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_1
	{
		public MadMoonProjectile projectile;

		public _003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals1;

		public TweenCallback _003C_003E9__1;

		internal void _003CStartSpinning_003Eb__0()
		{
			_003C_003Ec__DisplayClass29_0 obj = CS_0024_003C_003E8__locals1;
			MadMoonWeapon madMoonWeapon = obj._003C_003E4__this;
			TweenCallback callback = _003C_003E9__1;
			float num = (float)obj.reel * madMoonWeapon.delayBetweenReels;
			if (_003C_003E9__1 == null)
			{
				callback = (_003C_003E9__1 = delegate
				{
					projectile.startMoving();
					_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals10 = CS_0024_003C_003E8__locals1;
					TweenCallback callback2 = CS_0024_003C_003E8__locals10._003C_003E9__2;
					if (CS_0024_003C_003E8__locals10._003C_003E9__2 == null)
					{
						TweenCallback tweenCallback = delegate
						{
							//IL_009e: Unknown result type (might be due to invalid IL or missing references)
							//IL_00a3: Expected O, but got Unknown
							MadMoonWeapon madMoonWeapon2 = CS_0024_003C_003E8__locals10._003C_003E4__this;
							MadMoonReelState[] reelStates = madMoonWeapon2.reelStates;
							int reel = CS_0024_003C_003E8__locals10.reel;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rcx_v4 (VampireSurvivors.Objects.Weapons.MadMoonReelState[])+20+v119 @ rax_v5 (System.Int32)*4]");
							if ((nint)0 == 2 && CS_0024_003C_003E8__locals10._003C_003E4__this.isActiveAndEnabled)
							{
								MadMoonWeapon madMoonWeapon3 = CS_0024_003C_003E8__locals10._003C_003E4__this;
								object obj2 = CS_0024_003C_003E8__locals10.reel * madMoonWeapon3.timeBetweenZones;
								float duration = (float)obj2 + madMoonWeapon3.spinTime;
								_003CSpinning_003Ed__30 obj3 = null;
								obj3._003C_003E1__state = 0;
								obj3._003C_003E4__this = madMoonWeapon3;
								obj3.reel = CS_0024_003C_003E8__locals10.reel;
								obj3.duration = duration;
								Coroutine coroutine = madMoonWeapon3.StartCoroutine(obj3);
								MadMoonWeapon madMoonWeapon4 = CS_0024_003C_003E8__locals10._003C_003E4__this;
								MadMoonReelState[] reelStates2 = madMoonWeapon4.reelStates;
								int reel2 = CS_0024_003C_003E8__locals10.reel;
								_ = 3;
							}
						};
						callback2 = tweenCallback;
					}
					Tween tween2 = DOVirtual.DelayedCall(0.45f, callback2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					tween2.stringId = "DefaultGameTweenId";
				});
			}
			float delay = num + 0.5f;
			Tween tween = DOVirtual.DelayedCall(delay, callback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween.stringId = "DefaultGameTweenId";
			madMoonWeapon._reelDelayTween = tween;
		}

		internal void _003CStartSpinning_003Eb__1()
		{
			projectile.startMoving();
			_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals10 = CS_0024_003C_003E8__locals1;
			TweenCallback callback = CS_0024_003C_003E8__locals10._003C_003E9__2;
			if (CS_0024_003C_003E8__locals10._003C_003E9__2 == null)
			{
				TweenCallback tweenCallback = delegate
				{
					//IL_009e: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a3: Expected O, but got Unknown
					MadMoonWeapon madMoonWeapon = CS_0024_003C_003E8__locals10._003C_003E4__this;
					MadMoonReelState[] reelStates = madMoonWeapon.reelStates;
					int reel = CS_0024_003C_003E8__locals10.reel;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rcx_v4 (VampireSurvivors.Objects.Weapons.MadMoonReelState[])+20+v119 @ rax_v5 (System.Int32)*4]");
					if ((nint)0 == 2 && CS_0024_003C_003E8__locals10._003C_003E4__this.isActiveAndEnabled)
					{
						MadMoonWeapon madMoonWeapon2 = CS_0024_003C_003E8__locals10._003C_003E4__this;
						object obj = CS_0024_003C_003E8__locals10.reel * madMoonWeapon2.timeBetweenZones;
						float duration = (float)obj + madMoonWeapon2.spinTime;
						_003CSpinning_003Ed__30 obj2 = null;
						obj2._003C_003E1__state = 0;
						obj2._003C_003E4__this = madMoonWeapon2;
						obj2.reel = CS_0024_003C_003E8__locals10.reel;
						obj2.duration = duration;
						Coroutine coroutine = madMoonWeapon2.StartCoroutine(obj2);
						MadMoonWeapon madMoonWeapon3 = CS_0024_003C_003E8__locals10._003C_003E4__this;
						MadMoonReelState[] reelStates2 = madMoonWeapon3.reelStates;
						int reel2 = CS_0024_003C_003E8__locals10.reel;
						_ = 3;
					}
				};
				callback = tweenCallback;
			}
			Tween tween = DOVirtual.DelayedCall(0.45f, callback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween.stringId = "DefaultGameTweenId";
		}
	}

	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public MadMoonSymbol[] result;

		internal bool _003CsetFinalSymbols_003Eb__0(MadMoonSymbol x)
		{
			//IL_0068: Expected I4, but got O
			//IL_0046: Expected O, but got I
			MadMoonSymbol[] array = result;
			if (array.Length > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20]");
				object obj = (nint)x - (nint)0;
				return obj == null;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CSpinning_003Ed__30(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public MadMoonWeapon _003C_003E4__this;

		public int reel;

		private float _003CstartTime_003E5__2;

		private float _003CpausedTime_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_00f0: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_00a7: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_041a: Expected I4, but got O
			//IL_0082: Expected I4, but got I8
			//IL_0173: Expected I, but got O
			//IL_0198: Expected I, but got O
			//IL_01a8: Expected O, but got I
			//IL_006e: Expected I4, but got I8
			//IL_01e4: Expected O, but got I
			bool flag = _003C_003E1__state == 0;
			float num3;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					float time = Time.time;
					float num = time - _003CpausedTime_003E5__3;
					float num2 = num + duration;
					duration = num2;
					goto IL_012c;
				}
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						_003C_003E1__state = -1;
						goto IL_0314;
					}
					goto IL_0349;
				}
				_003C_003E1__state = -1;
				float time2 = Time.time;
				num3 = time2;
			}
			else
			{
				_003C_003E1__state = -1;
				float time3 = Time.time;
				float time4 = Time.time;
				float time5 = Time.time;
				_003CstartTime_003E5__2 = time5;
				num3 = time4;
			}
			float num4 = _003CstartTime_003E5__2 + duration;
			if (!(num4 > num3))
			{
				if (!PauseSystem._paused)
				{
					goto IL_0314;
				}
				Func<bool> predicate = _003C_003Ec._003C_003E9__30_0;
				if (_003C_003Ec._003C_003E9__30_0 == null)
				{
					Func<bool> func = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180005010");
					_003C_003Ec._003C_003E9__30_0 = func;
					predicate = func;
				}
				WaitUntil waitUntil = new WaitUntil(predicate);
				_003C_003E2__current = waitUntil;
				_003C_003E1__state = 3;
			}
			else
			{
				if (!PauseSystem._paused)
				{
					goto IL_012c;
				}
				float time6 = Time.time;
				_003CpausedTime_003E5__3 = time6;
				Func<bool> predicate2 = _003C_003Ec._003C_003E9__30_1;
				if (_003C_003Ec._003C_003E9__30_1 == null)
				{
					Func<bool> func2 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180005010");
					_003C_003Ec._003C_003E9__30_1 = func2;
					predicate2 = func2;
				}
				WaitUntil waitUntil2 = new WaitUntil(predicate2);
				_003C_003E2__current = waitUntil2;
				_003C_003E1__state = 1;
			}
			goto IL_041a;
			IL_0349:
			return false;
			IL_0216:
			UnityEngine.Object obj3;
			if ((bool)obj3)
			{
				MadMoonSymbol randomSymbol = _003C_003E4__this.getRandomSymbol();
				if ((object)obj3 == null)
				{
					goto IL_040c;
				}
				Vector2 pos = default(Vector2);
				((MadMoonProjectile)obj3).AfterInit(MadMoonSymbolType.Spinning, randomSymbol, reel, pos);
			}
			WaitForSeconds waitForSeconds = null;
			waitForSeconds.m_Seconds = 0.2f;
			_003C_003E2__current = waitForSeconds;
			_003C_003E1__state = 2;
			goto IL_041a;
			IL_012c:
			if ((object)_003C_003E4__this != null)
			{
				Vector2 pos2 = default(Vector2);
				obj3 = _003C_003E4__this.FireOneProjectile(pos2, 0);
				nint num5 = (nint)typeof(MadMoonProjectile);
				if ((object)obj3 != null)
				{
					nint num6 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ r8_v22 (Il2CppClass<UnityEngine.Object>)+130]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
					if (num7 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ r8_v22 (Il2CppClass<UnityEngine.Object>)+C8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v67+FFFFFFF8+v479 @ rax_v64*8]");
						if (0 == (nint)typeof(MadMoonProjectile))
						{
							goto IL_0216;
						}
					}
					throw new InvalidCastException();
				}
				goto IL_0216;
			}
			goto IL_040c;
			IL_040c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_041a:
			return true;
			IL_0314:
			if ((object)_003C_003E4__this != null)
			{
				_003C_003E4__this.Stopping(reel);
				goto IL_0349;
			}
			goto IL_040c;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private Bounds camBounds;

	private float2 playerPos;

	private Camera _camera;

	private BulletPool _reelZonePool;

	protected Projectile _reelZonePrefab;

	public int numOfReels = 4;

	public int symbolsPerReel = 3;

	private float spinTime = 2f;

	private float delayBetweenReels = 0.2f;

	public Vector2 slotMachineSize;

	public Vector2 slotMachinePos;

	private MadMoonReelState[] reelStates;

	private MadMoonProjectile[] landedProjectiles;

	public MadMoonSymbol[] finalSymbols;

	private float[] symbolWeights;

	private float timeBetweenZones;

	private GameObject blackBar;

	private Tween _blackbarTween;

	private Tween _reelDelayTween;

	private float winChance;

	private bool hasWinningSymbols;

	private bool _emitterBuilt;

	private ParticleSystem _EmitterCoins;

	private ParticleSystem _EmitterSkulls;

	private ParticleSystem _EmitterGems;

	private ParticleSystem _EmitterClovers;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_0427: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		//IL_013f: Expected O, but got I4
		//IL_013f: Expected O, but got I
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0486: Expected O, but got I
		//IL_056d: Expected I, but got O
		//IL_05fa->IL03e2: Incompatible stack heights: 1 vs 0
		base.InitWeapon(characterController, weaponType);
		Action<OnlineSignals.MadMoonSpin> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r9_v2 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r9_v2 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r9_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj3 = 6447148272L;
				goto IL_041e;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+MadMoonSpin>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+MadMoonSpin>)+20]");
		_ = 0;
		goto IL_041e;
		IL_041e:
		object obj4 = 24;
		_ = 6447743536L;
		if (_signalBus != null)
		{
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdi_v14 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj5 = null;
			if (obj5 != null)
			{
				Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.MadMoonSpin>)obj5)._003CSubscribeId_003Eb__0;
				((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.MadMoonSpin>)0)._003CSubscribeId_003Eb__0((object)1);
				object obj7 = default(object);
				object obj6 = obj7 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				SignalBus signalBus = _signalBus;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v43 (System.Object)+10]");
				Type signalType = default(Type);
				Action<object> callback = default(Action<object>);
				signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
				MadMoonProjectile[] array = new MadMoonProjectile[numOfReels];
				landedProjectiles = array;
				MadMoonReelState[] array2 = new MadMoonReelState[numOfReels];
				reelStates = array2;
				float[] array3 = new float[numOfReels];
				symbolWeights = array3;
				BulletPool reelZonePool = new BulletPool(_reelZonePrefab, 5);
				_reelZonePool = reelZonePool;
				Camera main = Camera.main;
				_camera = main;
				MadMoonReelState[] array4 = reelStates;
				bool flag = reelStates == null;
				bool flag2 = false;
				bool flag3 = false;
				if (!flag)
				{
					object obj8 = default(object);
					Vector3 value = default(Vector3);
					while (true)
					{
						if ((flag2 ? 1 : 0) < array4.Length)
						{
							MadMoonReelState[] array5 = reelStates;
							if (reelStates == null)
							{
								break;
							}
							if ((flag3 ? 1 : 0) < array5.Length)
							{
								bool flag4 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
								_ = 0;
								array4 = reelStates;
								if (reelStates == null)
								{
									break;
								}
								flag2 = flag4;
								flag3 = flag4;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
						((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
						BuildEmitter();
						camBounds = (Bounds)CameraExtensions.OrthographicBounds(_camera).m_Center;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ rax_v65 (UnityEngine.Bounds)+10]");
						_ = 0;
						float num3 = (float)obj8 * 2f;
						float num4 = num3 / 2.7f;
						float num5 = num4 + (float)obj8;
						slotMachinePos = (Vector2)camBounds;
						if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
						{
							IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rax_v74 (UnityEngine.Transform)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rax_v74 (UnityEngine.Transform)+10]");
							Transform.set_position_Injected((IntPtr)0, ref value);
							if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
							{
								IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
								Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
								nint num6 = (nint)_camera;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rdi_v18 (Il2CppMethodInfo)+10]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rdi_v18 (Il2CppMethodInfo)+10]");
								IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
								Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1440 @ rax_v83 (UnityEngine.Transform)+10]");
								bool flag7 = (nint)0 == 0;
								nint num7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1800 @ rcx_v77 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((nint)(delegate*<Transform, IntPtr>)(&UnityEngine.Object.MarshalledUnityObject.Marshal));
								}
								bool flag8 = (object)transform3 == null;
								nint parent = 0;
								if (!flag8)
								{
									parent = ((UnityEngine.Object)transform3).m_CachedPtr;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1440 @ rax_v83 (UnityEngine.Transform)+10]");
								Transform.SetParent_Injected((IntPtr)0, (IntPtr)parent, true);
								return;
							}
						}
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
						break;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0132: Expected O, but got I
		//IL_0174: Invalid comparison between F4 and I4
		//IL_003e: Expected O, but got I8
		timeBetweenZones = 0.25f;
		updateWeights();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		MadMoonWeapon madMoonWeapon = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			madMoonWeapon = (MadMoonWeapon)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v49 @ rax_v12 (should have been resolved before IL gen)");
		bool flag2 = winChance < 0f;
		setFinalSymbols(hasWinningSymbols = !flag2);
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
			if (numOfReels > 0)
			{
				int num;
				do
				{
					StartSpinning(0);
					num = 0 + 1;
				}
				while (num < numOfReels);
			}
			GameObject gameObject = blackBar;
			if ((object)blackBar != null)
			{
				bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				Transform component = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
				float num2 = 0f / 3f;
				float xScale = (float)slotMachineSize * 1.1f;
				float yScale = num2 / 1.4f;
				Transform transform = RenderingExtensions.SetScale(component, xScale, yScale);
				FadeBlackBar(fadeOn: true);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void StartSpinning(int reel)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_00bb: Expected I, but got O
		//IL_00f2: Expected I, but got O
		//IL_0102: Expected O, but got I
		//IL_013e: Expected O, but got I
		//IL_0186: Expected I, but got O
		//IL_018e: Expected I, but got O
		//IL_019e: Expected O, but got I
		//IL_01da: Expected O, but got I
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		_003C_003Ec__DisplayClass29_0 obj = new _003C_003Ec__DisplayClass29_0();
		obj._003C_003E4__this = this;
		obj.reel = reel;
		MadMoonReelState[] array = reelStates;
		_ = 2;
		if (symbolsPerReel <= 0)
		{
			return;
		}
		MadMoonProjectile madMoonProjectile = null;
		Vector2 pos = default(Vector2);
		Vector2 pos2 = default(Vector2);
		while (true)
		{
			_003C_003Ec__DisplayClass29_1 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass29_1();
			CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
			int num = (int)((nint)0 / (nint)symbolsPerReel);
			object obj2 = num * madMoonProjectile;
			Projectile projectile = base.FireOneProjectile(pos, 0);
			nint num2 = (nint)typeof(MadMoonProjectile);
			if ((object)projectile == null)
			{
				CS_0024_003C_003E8__locals15.projectile = null;
				goto IL_020c;
			}
			nint num3 = (nint)projectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rax_v44+FFFFFFF8+v638 @ rax_v43*8]");
				if (0 == (nint)typeof(MadMoonProjectile))
				{
					CS_0024_003C_003E8__locals15.projectile = (MadMoonProjectile)projectile;
					nint num5 = (nint)typeof(MadMoonProjectile);
					nint num6 = (nint)projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
					if (num7 < 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v46+FFFFFFF8+v503 @ rax_v45*8]");
					if (0 != (nint)typeof(MadMoonProjectile))
					{
						break;
					}
					goto IL_020c;
				}
			}
			throw new InvalidCastException();
			IL_020c:
			MadMoonProjectile projectile2 = CS_0024_003C_003E8__locals15.projectile;
			if ((object)CS_0024_003C_003E8__locals15.projectile != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				MadMoonSymbol randomSymbol = getRandomSymbol();
				_003C_003Ec__DisplayClass29_0 obj7 = CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1;
				CS_0024_003C_003E8__locals15.projectile.AfterInit(MadMoonSymbolType.Starting, randomSymbol, obj7.reel, pos2);
				Tween tween = CS_0024_003C_003E8__locals15.projectile.FadeOn();
				TweenCallback tweenCallback = delegate
				{
					_003C_003Ec__DisplayClass29_0 obj8 = CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1;
					MadMoonWeapon madMoonWeapon = obj8._003C_003E4__this;
					TweenCallback callback = CS_0024_003C_003E8__locals15._003C_003E9__1;
					float num8 = (float)obj8.reel * madMoonWeapon.delayBetweenReels;
					if (CS_0024_003C_003E8__locals15._003C_003E9__1 == null)
					{
						callback = (CS_0024_003C_003E8__locals15._003C_003E9__1 = delegate
						{
							CS_0024_003C_003E8__locals15.projectile.startMoving();
							_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals25 = CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1;
							TweenCallback callback2 = CS_0024_003C_003E8__locals25._003C_003E9__2;
							if (CS_0024_003C_003E8__locals25._003C_003E9__2 == null)
							{
								TweenCallback tweenCallback2 = delegate
								{
									//IL_009e: Unknown result type (might be due to invalid IL or missing references)
									//IL_00a3: Expected O, but got Unknown
									MadMoonWeapon madMoonWeapon2 = CS_0024_003C_003E8__locals25._003C_003E4__this;
									MadMoonReelState[] array2 = madMoonWeapon2.reelStates;
									int reel2 = CS_0024_003C_003E8__locals25.reel;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rcx_v4 (VampireSurvivors.Objects.Weapons.MadMoonReelState[])+20+v119 @ rax_v5 (System.Int32)*4]");
									if ((nint)0 == 2 && CS_0024_003C_003E8__locals25._003C_003E4__this.isActiveAndEnabled)
									{
										MadMoonWeapon madMoonWeapon3 = CS_0024_003C_003E8__locals25._003C_003E4__this;
										object obj9 = CS_0024_003C_003E8__locals25.reel * madMoonWeapon3.timeBetweenZones;
										float duration = (float)obj9 + madMoonWeapon3.spinTime;
										_003CSpinning_003Ed__30 obj10 = null;
										obj10._003C_003E1__state = 0;
										obj10._003C_003E4__this = madMoonWeapon3;
										obj10.reel = CS_0024_003C_003E8__locals25.reel;
										obj10.duration = duration;
										Coroutine coroutine = madMoonWeapon3.StartCoroutine(obj10);
										MadMoonWeapon madMoonWeapon4 = CS_0024_003C_003E8__locals25._003C_003E4__this;
										MadMoonReelState[] array3 = madMoonWeapon4.reelStates;
										int reel3 = CS_0024_003C_003E8__locals25.reel;
										_ = 3;
									}
								};
								callback2 = tweenCallback2;
							}
							Tween tween3 = DOVirtual.DelayedCall(0.45f, callback2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							tween3.stringId = "DefaultGameTweenId";
						});
					}
					float delay = num8 + 0.5f;
					Tween tween2 = DOVirtual.DelayedCall(delay, callback);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					tween2.stringId = "DefaultGameTweenId";
					madMoonWeapon._reelDelayTween = tween2;
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
			}
			madMoonProjectile = (MadMoonProjectile)(madMoonProjectile + 1);
			if ((nint)madMoonProjectile >= symbolsPerReel)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	private IEnumerator Spinning(int reel, float duration)
	{
		_003CSpinning_003Ed__30 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.reel = reel;
		return obj;
	}

	public unsafe void Stopping(int reel)
	{
		//IL_005c: Expected O, but got I4
		//IL_029d: Expected O, but got I4
		//IL_02af: Expected I, but got O
		//IL_008a: Expected I, but got O
		//IL_009a: Expected O, but got I
		//IL_00d6: Expected O, but got I
		//IL_022a: Expected I, but got O
		MadMoonReelState[] array = reelStates;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
		int num = (int)((nint)0 / (nint)symbolsPerReel);
		float num2 = (float)num * 0.5f;
		bool flag = false;
		Vector2 pos = default(Vector2);
		object obj5 = default(object);
		while (true)
		{
			if (!hasWinningSymbols)
			{
				bool flag2 = false;
			}
			else
			{
				object obj = reel - 3;
				bool flag3 = obj == null;
				bool flag2 = flag3;
			}
			Projectile projectile = base.FireOneProjectile((Vector2)0, 0);
			nint num3 = (nint)typeof(MadMoonProjectile);
			UnityEngine.Object obj2;
			if ((object)projectile == null)
			{
				obj2 = null;
				goto IL_0110;
			}
			nint num4 = (nint)projectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v29+FFFFFFF8+v586 @ rax_v28*8]");
				bool flag4 = 0 != (nint)typeof(MadMoonProjectile);
				obj2 = projectile;
				if (!flag4)
				{
					goto IL_0110;
				}
			}
			throw new InvalidCastException();
			IL_0110:
			if ((bool)obj2)
			{
				if (flag)
				{
					MadMoonSymbol[] array2 = finalSymbols;
					((MadMoonProjectile)obj2).setSprite((MadMoonSymbol)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[reel]));
					MadMoonSymbol[] array3 = finalSymbols;
					((MadMoonProjectile)obj2).AfterInit(MadMoonSymbolType.Winning, (MadMoonSymbol)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[reel]), reel, pos);
					MadMoonProjectile[] array4 = landedProjectiles;
					nint num6 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (obj5 == null)
					{
						break;
					}
					array4[reel] = (MadMoonProjectile)obj2;
					flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
					continue;
				}
				MadMoonSymbol randomSymbol = getRandomSymbol();
				((MadMoonProjectile)obj2).AfterInit(MadMoonSymbolType.Landing, randomSymbol, reel, pos);
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			if ((flag ? 1 : 0) >= 3)
			{
				return;
			}
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public unsafe void SpawnZone(int reel)
	{
		//IL_0849: Expected O, but got I4
		//IL_085b: Expected I, but got O
		//IL_014e: Expected I, but got O
		//IL_015e: Expected O, but got I
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		//IL_019a: Expected O, but got I
		//IL_00f7: Expected O, but got I
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0267: Expected O, but got I4
		//IL_07cc: Expected O, but got I4
		//IL_02d1: Expected I, but got O
		//IL_02e7: Expected O, but got I
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_036b: Expected I, but got O
		//IL_0956: Expected F4, but got I4
		//IL_08b2: Expected O, but got I4
		//IL_08c9: Expected I, but got I8
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected I4, but got Unknown
		//IL_03e3: Expected F4, but got I4
		//IL_08f0: Expected O, but got I4
		//IL_0347: Expected I, but got I8
		//IL_04a9: Expected F4, but got I4
		//IL_0930: Expected O, but got I4
		//IL_03fe: Expected F4, but got I8
		//IL_096a: Expected O, but got I4
		//IL_0470: Expected F4, but got I8
		//IL_09b2: Expected O, but got I4
		//IL_04c4: Expected F4, but got I8
		//IL_05b7: Expected O, but got I4
		//IL_05e6: Expected F4, but got I4
		//IL_0606: Expected O, but got I4
		//IL_063e: Expected F4, but got I4
		//IL_065e: Expected O, but got I4
		//IL_0696: Expected F4, but got I4
		//IL_06b6: Expected O, but got I4
		//IL_06ee: Expected F4, but got I4
		//IL_070e: Expected O, but got I4
		//IL_0746: Expected F4, but got I4
		//IL_0774: Expected O, but got I4
		//IL_079e: Expected F4, but got I4
		MadMoonSymbol[] array = finalSymbols;
		bool flag = reel < 0;
		MadMoonZoneProjectile madMoonZoneProjectile = null;
		if (!flag)
		{
			MadMoonZoneProjectile madMoonZoneProjectile2 = null;
			MadMoonZoneProjectile madMoonZoneProjectile3 = null;
			bool flag2;
			do
			{
				madMoonZoneProjectile = (MadMoonZoneProjectile)(madMoonZoneProjectile3 + 1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20+v235 @ rdx_v25 (VampireSurvivors.Objects.Projectiles.MadMoonZoneProjectile)*4]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20+reel @ rdx (System.Int32)*4]");
				if (num != 0)
				{
					madMoonZoneProjectile = madMoonZoneProjectile3;
				}
				madMoonZoneProjectile2 = (MadMoonZoneProjectile)(madMoonZoneProjectile2 + 1);
				flag2 = (nint)madMoonZoneProjectile2 <= reel;
				madMoonZoneProjectile3 = madMoonZoneProjectile;
			}
			while (flag2);
		}
		if (hasWinningSymbols && reel == 3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20+reel @ rdx (System.Int32)*4]");
			bool flag3 = (nint)0 == 0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20+reel @ rdx (System.Int32)*4]");
				object obj = -1;
				if (!flag3)
				{
					object obj2 = obj - 1;
					if (!flag3 && (nint)obj2 == 1)
					{
						goto IL_013c;
					}
				}
			}
		}
		Projectile projectile = base.FireOneProjectile((Vector2)0, 0);
		nint num2 = (nint)typeof(MadMoonZoneProjectile);
		MadMoonZoneProjectile madMoonZoneProjectile4;
		if ((object)projectile != null)
		{
			nint num3 = (nint)projectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonZoneProjectile>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonZoneProjectile>)+130]");
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v79+FFFFFFF8+v455 @ rax_v78*8]");
				bool flag4 = 0 != (nint)typeof(MadMoonZoneProjectile);
				madMoonZoneProjectile4 = (MadMoonZoneProjectile)projectile;
				if (!flag4)
				{
					goto IL_088c;
				}
			}
			throw new InvalidCastException();
		}
		goto IL_013c;
		IL_08a9:
		object obj5 = 24;
		TweenCallback tweenCallback;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Tween tween = DOVirtual.DelayedCall(0.5f, tweenCallback);
		goto IL_0370;
		IL_0370:
		SoundManager.SoundConfig soundConfig;
		SoundManager.SoundConfig soundConfig3;
		int num12 = default(int);
		if (reel != 0)
		{
			if (reel == 1)
			{
				MadMoonSymbol[] array2 = finalSymbols;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v54 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v54 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+24]");
				bool flag5 = num5 == 0;
				float detune = 400f;
				if (!flag5)
				{
					detune = 4.2949668E+09f;
				}
				object obj6 = !flag5;
				if (obj6 == null)
				{
				}
				soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Detune = detune;
				soundConfig.Volume = (float?)(object)1;
				goto IL_07df;
			}
			if (reel == 2)
			{
				MadMoonSymbol[] array3 = finalSymbols;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v45 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v45 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+24]");
				float detune2;
				if (num6 != 0)
				{
					detune2 = 4.2949668E+09f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v45 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+24]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v45 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+28]");
					bool flag6 = num7 == 0;
					float num8 = 800f;
					if (!flag6)
					{
						num8 = 4.2949668E+09f;
					}
					object obj7 = !flag6;
					detune2 = num8;
					if (obj7 == null)
					{
						detune2 = num8;
					}
				}
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Rate = 1f;
				soundConfig2.Detune = detune2;
				soundConfig2.Volume = (float?)(object)1;
				soundConfig3 = soundConfig2;
				goto IL_093a;
			}
			if (reel != 3)
			{
				return;
			}
			MadMoonSymbol[] array4 = finalSymbols;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v30 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v30 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+24]");
			if (num9 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v30 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+24]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v30 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+28]");
				if (num10 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v30 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+28]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v30 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+2C]");
					if (num11 == 0)
					{
						SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
						soundConfig4.Rate = 1f;
						soundConfig4.Volume = (float?)(object)1;
						soundConfig4.Detune = 400f;
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig4, 150f, 10, num12);
						SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
						soundConfig5.Volume = (float?)(object)1;
						soundConfig5.Rate = 1f;
						soundConfig5.Detune = 800f;
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Groove, soundConfig5, 150f, 10, num12);
						SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
						soundConfig6.Volume = (float?)(object)1;
						soundConfig6.Rate = 1f;
						soundConfig6.Detune = 1600f;
						PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Groove, soundConfig6, 150f, 10, num12);
						SoundManager.SoundConfig soundConfig7 = new SoundManager.SoundConfig();
						soundConfig7.Volume = (float?)(object)1;
						soundConfig7.Rate = 1f;
						soundConfig7.Detune = -1000f;
						PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Groove, soundConfig7, 150f, 10, num12);
						SoundManager.SoundConfig soundConfig8 = new SoundManager.SoundConfig();
						soundConfig8.Volume = (float?)(object)1;
						soundConfig8.Rate = 1f;
						soundConfig8.Detune = -2000f;
						PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Groove, soundConfig8, 150f, 10, num12);
						SoundManager.SoundConfig soundConfig9 = new SoundManager.SoundConfig();
						soundConfig9.Rate = 1f;
						soundConfig9.Volume = (float?)(object)1;
						soundConfig9.Detune = -4000f;
						PlaySoundResult playSoundResult6 = SoundManager.PlaySound(SfxType.Groove, soundConfig9, 150f, 10, num12);
						return;
					}
				}
			}
		}
		soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -400f;
		goto IL_07df;
		IL_093a:
		PlaySoundResult playSoundResult7 = SoundManager.PlaySound(SfxType.Groove, soundConfig3, 150f, 10, num12);
		return;
		IL_07df:
		soundConfig3 = soundConfig;
		goto IL_093a;
		IL_088c:
		if ((object)madMoonZoneProjectile4 != null && ((UnityEngine.Object)madMoonZoneProjectile4).m_CachedPtr != (IntPtr)0)
		{
			MadMoonProjectile[] array5 = landedProjectiles;
			int level = madMoonZoneProjectile - 1;
			MadMoonSymbol effect = default(MadMoonSymbol);
			float value = default(float);
			bool specialBonus = default(bool);
			madMoonZoneProjectile4.AfterInit(array5[reel], timeBetweenZones, level, num12, effect, value, specialBonus);
		}
		object obj8 = numOfReels - 1;
		if (reel != (nint)obj8)
		{
			goto IL_0370;
		}
		tweenCallback = null;
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ r10_v6 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(MadMoonWeapon.Restart);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ r10_v6 (Il2CppMethodInfo)+4C]");
		object obj9 = (nint)0 >> 4;
		object obj10 = obj9 & 1;
		nint num14;
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ r10_v6 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num14 = unchecked((nint)6447293664L);
				goto IL_08a9;
			}
		}
		num14 = ((Delegate)tweenCallback).method_ptr;
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		goto IL_08a9;
		IL_013c:
		madMoonZoneProjectile4 = null;
		goto IL_088c;
	}

	private void Restart()
	{
		//IL_0179: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_007e: Expected I, but got O
		MadMoonProjectile[] array = new MadMoonProjectile[numOfReels];
		landedProjectiles = array;
		MadMoonReelState[] array2 = reelStates;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array2.Length)
		{
			MadMoonReelState[] array3 = reelStates;
			_ = 0;
			obj2++;
			array2 = reelStates;
			obj = obj2;
		}
		List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
		if (enumerator.MoveNext())
		{
			nint num = (nint)typeof(MadMoonProjectile);
			MadMoonProjectile madMoonProjectile = null;
			MadMoonProjectile madMoonProjectile2 = null;
			throw new NullReferenceException();
		}
		base.ResetFiringTimer();
	}

	private void FadeBlackBar(bool fadeOn)
	{
		//IL_00cb: Expected F4, but got I4
		if (_blackbarTween != null)
		{
			Tween blackbarTween = _blackbarTween;
			if (blackbarTween._003Cactive_003Ek__BackingField)
			{
				if (blackbarTween.isPlaying)
				{
					return;
				}
			}
			else if (Debugger._logPriority > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DAF]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Debugger.LogWarning("This Tween has been killed and is now invalid");
			}
		}
		SpriteRenderer component = blackBar.GetComponent<SpriteRenderer>();
		float endValue = ((!fadeOn) ? 0f : 0.65f);
		TweenerCore<Color, Color, ColorOptions> blackbarTween2 = DOTweenModuleSprite.DOFade(component, endValue, 0.2f);
		_blackbarTween = blackbarTween2;
	}

	private void updateWeights()
	{
		//IL_0040: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_0130: Expected F4, but got O
		//IL_015e: Expected F4, but got O
		//IL_018c: Expected F4, but got O
		//IL_01ba: Expected F4, but got O
		//IL_01d2: Expected O, but got I4
		//IL_01e5: Expected O, but got I4
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		object obj = default(object);
		bool flag = 0 <= (nint)obj;
		object obj2 = obj;
		if (!flag)
		{
			obj2 = 0;
		}
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PGrowth();
		bool flag2 = 0 <= (nint)obj;
		object obj3 = obj;
		if (!flag2)
		{
			obj3 = 0;
		}
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
		bool flag3 = 0 <= (nint)obj;
		object obj4 = obj;
		if (!flag3)
		{
			obj4 = 0;
		}
		float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PCurse();
		bool flag4 = 0 > (nint)obj;
		object obj5 = 0;
		if (!flag4)
		{
			obj5 = obj;
		}
		float[] array = symbolWeights;
		object obj6 = obj2 + obj5;
		object obj7 = obj6 + obj3;
		object obj8 = obj7 + obj4;
		object obj9 = obj2 / obj8;
		array[2] = (float)obj9;
		float[] array2 = symbolWeights;
		object obj10 = obj5 / obj8;
		array2[0] = (float)obj10;
		float[] array3 = symbolWeights;
		object obj11 = obj3 / obj8;
		array3[1] = (float)obj11;
		float[] array4 = symbolWeights;
		object obj12 = obj4 / obj8;
		array4[3] = (float)obj12;
		float[] array5 = symbolWeights;
		object obj13 = 1;
		float[] array6 = symbolWeights;
		object obj14 = 1;
		while ((nint)obj13 < array5.Length)
		{
			object obj15 = obj14 - 1;
			object obj16 = obj14 + 1;
			float num5 = array6[obj15] + array6[obj14];
			array6[obj14] = num5;
			obj13 = obj16;
			array5 = symbolWeights;
			obj14 = obj16;
		}
	}

	private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
	{
		float num = value - fromLow;
		object obj = default(object);
		float num2 = (float)obj - toLow;
		float num3 = fromHigh - fromLow;
		float num4 = num * num2;
		float num5 = num4 / num3;
		return num5 + toLow;
	}

	private float2 getSlotMachinePos()
	{
		float2 result = default(float2);
		return result;
	}

	private float2 getTopLeftSymbolPos()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rcx+190h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rcx+194h]\"");
		float2 result = default(float2);
		return result;
	}

	public void setFinalSymbols(bool won)
	{
		//IL_002e: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0234: Expected O, but got I
		//IL_027c: Expected O, but got I
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass39_0();
		MadMoonSymbol[] result = new MadMoonSymbol[numOfReels];
		CS_0024_003C_003E8__locals6.result = result;
		if (!won)
		{
			object obj = 0;
			object obj2 = 0;
			MadMoonSymbol[] result2;
			while (true)
			{
				result2 = CS_0024_003C_003E8__locals6.result;
				if ((nint)obj >= result2.Length)
				{
					break;
				}
				bool includeWilds = obj2 != null;
				MadMoonSymbol randomSymbol = getRandomSymbol(weighted: true, includeWilds);
				object obj3 = obj2 + 1;
				obj = obj3;
				obj2 = obj3;
			}
			Func<MadMoonSymbol, bool> predicate = delegate(MadMoonSymbol x)
			{
				//IL_0068: Expected I4, but got O
				//IL_0046: Expected O, but got I
				MadMoonSymbol[] result4 = CS_0024_003C_003E8__locals6.result;
				if (result4.Length <= 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (VampireSurvivors.Objects.Weapons.MadMoonSymbol[])+20]");
				object obj5 = (nint)x - (nint)0;
				return obj5 == null;
			};
			if (Enumerable.All(result2, predicate))
			{
				hasWinningSymbols = true;
			}
		}
		else
		{
			MadMoonSymbol randomSymbol2 = getRandomSymbol(weighted: true, includeWilds: false);
			MadMoonSymbol[] result3 = new MadMoonSymbol[4];
			CS_0024_003C_003E8__locals6.result = result3;
		}
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			finalSymbols = CS_0024_003C_003E8__locals6.result;
			return;
		}
		OnlineStageManager instance = OnlineStageManager._instance;
		CoherenceSync sync = instance._sync;
		NetworkEntityState networkEntityState = sync._003CEntityState_003Ek__BackingField;
		if (sync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v26 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v26 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v26 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj4 = -3;
				bool flag2 = obj4 == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		object instance2 = OnlineStageManager._instance;
		string param = SerializeFinalSymbols(CS_0024_003C_003E8__locals6.result);
		Action<string, long> action = OnlineStageManager._instance.SetMadMoonSymbols;
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v7 (System.Object)+78]");
		long param2 = default(long);
		bool flag3 = ((CoherenceSync)0).SendCommand((Action<object, long>)action, MessageTarget.All, param, param2);
	}

	public MadMoonSymbol getRandomSymbol(bool weighted = false, bool includeWilds = true)
	{
		//IL_010f: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_007b: Expected O, but got I8
		//IL_00b3: Invalid comparison between F4 and I4
		//IL_0177: Expected O, but got I
		//IL_01ad: Expected O, but got I
		if (weighted)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			MadMoonWeapon madMoonWeapon = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				madMoonWeapon = (MadMoonWeapon)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v76 @ rax_v36 (should have been resolved before IL gen)");
			float[] array = symbolWeights;
			bool flag2 = symbolWeights == null;
			float[] array2 = symbolWeights;
			MadMoonSymbol madMoonSymbol = MadMoonSymbol.Curse;
			MadMoonSymbol madMoonSymbol2 = MadMoonSymbol.Curse;
			while ((int)madMoonSymbol < array.Length)
			{
				if (!(array2[(int)madMoonSymbol2] > 0f))
				{
					madMoonSymbol2++;
					madMoonSymbol = madMoonSymbol2;
					continue;
				}
				return madMoonSymbol2;
			}
			Debug.LogError("shouldnt ever reach here");
			return MadMoonSymbol.Crown;
		}
		nint num = (nint)typeof(MadMoonSymbol);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			object obj4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v407 @ rdx_v10+8F8] (should have been resolved before IL gen)");
			Array array3 = default(Array);
			bool flag3 = array3 == null;
			int length = array3.Length;
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v347 @ rax_v26 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 258 ConditionalJump @-1, v158 @ ZF_v13 (System.Boolean) --- -1 Nop");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 83 ConditionalJump @-1, v112 @ ZF_v20 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
		ArgumentNullException ex2 = new ArgumentNullException("enumType");
		throw ex2;
	}

	public void SyncFinalSymbols(string serializedFinalSymbols)
	{
		MadMoonSymbol[] array = DeserializeFinalSymbols(serializedFinalSymbols);
		finalSymbols = array;
	}

	public unsafe string SerializeFinalSymbols(MadMoonSymbol[] symbols)
	{
		//IL_0025: Expected O, but got I
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0285: Expected I4, but got I8
		//IL_0113: Expected I, but got O
		//IL_011c: Expected O, but got I4
		//IL_00b8: Expected O, but got I
		//IL_0251: Expected O, but got I4
		//IL_0085: Expected O, but got I8
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected I, but got Unknown
		//IL_01d3: Expected O, but got I
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_018f: Expected O, but got I
		//IL_019f: Expected O, but got I
		Converter<MadMoonSymbol, int> converter = _003C_003Ec._003C_003E9__42_0;
		if (_003C_003Ec._003C_003E9__42_0 != null)
		{
			goto IL_00cf;
		}
		Converter<MadMoonSymbol, int> converter2 = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v9 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		_ = _003C_003Ec._003C_003E9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v9 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v9 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj3 = 6447986704L;
				goto IL_0248;
			}
		}
		else if (_003C_003Ec._003C_003E9 == null)
		{
			int num2 = ((_003C_003Ec)null)._003CSerializeFinalSymbols_003Eb__42_0((MadMoonSymbol)(-2019369760));
			throw num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v42 (System.Converter`2<VampireSurvivors.Objects.Weapons.MadMoonSymbol, System.Int32>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v42 (System.Converter`2<VampireSurvivors.Objects.Weapons.MadMoonSymbol, System.Int32>)+20]");
		_ = 0;
		goto IL_0248;
		IL_00cf:
		if (symbols != null)
		{
			if (converter != null)
			{
				nint num3 = unchecked((nint)null);
				object obj4 = 0;
				while ((nint)obj4 < symbols.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v93 @ rdi_v6 (System.Converter`2<VampireSurvivors.Objects.Weapons.MadMoonSymbol, System.Int32>)+18] (should have been resolved before IL gen)");
					object obj5 = obj4 + 1;
					obj4 = obj5;
				}
				bool flag = "," != null;
				object obj6 = ",";
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v34+B8]");
					object obj8 = 0;
					obj6 = obj8;
				}
				char* separator = (char*)(nint)(obj6 + 20);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ r14_v4+10]");
				return string.JoinCore<int>(separator, 0, (IEnumerable<int>)num3);
			}
			ArgumentNullException ex = new ArgumentNullException("converter");
			ex._002Ector("converter");
			throw ex;
		}
		ArgumentNullException ex2 = new ArgumentNullException("array");
		throw ex2;
		IL_0248:
		object obj9 = 24;
		_ = 6447986720L;
		_003C_003Ec._003C_003E9__42_0 = converter2;
		converter = converter2;
		goto IL_00cf;
	}

	public MadMoonSymbol[] DeserializeFinalSymbols(string str)
	{
		//IL_01aa: Expected I, but got O
		//IL_003f: Expected O, but got I
		//IL_004f: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_01db: Expected I, but got O
		//IL_00f0: Expected O, but got I4
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		bool flag = "," != null;
		string text = ",";
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v49+B8]");
			object obj2 = 0;
			text = (string)obj2;
		}
		StringSplitOptions options = default(StringSplitOptions);
		string[] array = str.SplitInternal(text, (string[])null, 2147483647, options);
		Converter<string, MadMoonSymbol> converter = _003C_003Ec._003C_003E9__43_0;
		bool flag2 = _003C_003Ec._003C_003E9__43_0 != null;
		nint num = (nint)text;
		if (!flag2)
		{
			Converter<string, MadMoonSymbol> converter2 = (string e) => (MadMoonSymbol)StringExtensions.ToInt(e);
			nint num2 = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.MadMoonWeapon+<>c>)+B8]");
			num = 0;
			_003C_003Ec._003C_003E9__43_0 = converter2;
			converter = converter2;
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r14_v5 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			MadMoonSymbol madMoonSymbol = ((_003C_003Ec)0)._003CDeserializeFinalSymbols_003Eb__43_0((string)num);
		}
		if (array != null)
		{
			if (converter != null)
			{
				MadMoonSymbol[] result = null;
				object obj3 = 0;
				while ((nint)obj3 < array.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ rbp_v6 (System.Converter`2<System.String, VampireSurvivors.Objects.Weapons.MadMoonSymbol>)+18] (should have been resolved before IL gen)");
					object obj4 = obj3 + 1;
					obj3 = obj4;
				}
				return result;
			}
			ArgumentNullException ex = new ArgumentNullException("converter");
			ex._002Ector("converter");
			throw ex;
		}
		ArgumentNullException ex2 = new ArgumentNullException("array");
		ex2._002Ector("array");
		throw ex2;
	}

	public void OnSpinRemotely(OnlineSignals.MadMoonSpin sig)
	{
		MadMoonSymbol[] array = DeserializeFinalSymbols((string)sig);
		finalSymbols = array;
	}

	private unsafe void BuildEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0063: Expected O, but got I
		//IL_007f: Expected O, but got I4
		//IL_0150: Expected O, but got Ref
		//IL_016a: Expected native int or pointer, but got O
		//IL_0e6e: Expected O, but got I4
		//IL_0182: Expected O, but got Ref
		//IL_019c: Expected native int or pointer, but got O
		//IL_01b6: Expected O, but got I
		//IL_01d6: Expected O, but got Ref
		//IL_01f0: Expected native int or pointer, but got O
		//IL_0e8b: Expected O, but got I4
		//IL_0222: Expected O, but got Ref
		//IL_023c: Expected native int or pointer, but got O
		//IL_0ec5: Expected O, but got I
		//IL_0282: Expected O, but got I4
		//IL_02a8: Expected O, but got I
		//IL_035d: Expected O, but got I
		//IL_0379: Expected O, but got I4
		//IL_04e1: Expected O, but got Ref
		//IL_04fb: Expected native int or pointer, but got O
		//IL_0eff: Expected O, but got I
		//IL_0533: Expected O, but got Ref
		//IL_054d: Expected native int or pointer, but got O
		//IL_0567: Expected O, but got I
		//IL_0587: Expected O, but got Ref
		//IL_05a1: Expected native int or pointer, but got O
		//IL_0f39: Expected O, but got I
		//IL_05d9: Expected O, but got Ref
		//IL_05f3: Expected native int or pointer, but got O
		//IL_0f6b: Expected O, but got I
		//IL_0639: Expected O, but got I4
		//IL_065f: Expected O, but got I
		//IL_0714: Expected O, but got I
		//IL_0730: Expected O, but got I4
		//IL_0801: Expected O, but got Ref
		//IL_081b: Expected native int or pointer, but got O
		//IL_0fa5: Expected O, but got I
		//IL_0853: Expected O, but got Ref
		//IL_086d: Expected native int or pointer, but got O
		//IL_0887: Expected O, but got I
		//IL_08a7: Expected O, but got Ref
		//IL_08c1: Expected native int or pointer, but got O
		//IL_0fdf: Expected O, but got I
		//IL_08f9: Expected O, but got Ref
		//IL_0913: Expected native int or pointer, but got O
		//IL_1019: Expected O, but got I
		//IL_0959: Expected O, but got I4
		//IL_097f: Expected O, but got I
		//IL_0a34: Expected O, but got I
		//IL_0a50: Expected O, but got I4
		//IL_0b21: Expected O, but got Ref
		//IL_0b3b: Expected native int or pointer, but got O
		//IL_0b80: Expected O, but got I
		//IL_0ba8: Expected O, but got Ref
		//IL_0bc2: Expected native int or pointer, but got O
		//IL_0be1: Expected O, but got I
		//IL_0bfc: Expected O, but got Ref
		//IL_0c16: Expected native int or pointer, but got O
		//IL_0c5b: Expected O, but got I
		//IL_0c88: Expected O, but got Ref
		//IL_0ca2: Expected native int or pointer, but got O
		//IL_0ce7: Expected O, but got I
		//IL_0d22: Expected O, but got I4
		//IL_0d43: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_emitterBuilt)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"CoinGold.png");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 368));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(225f, 275f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 400));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig._collideBottom = (bool?)(object)0;
			Transform parent = base.transform;
			ParticleSystem emitterCoins = particleEmitterManager.CreateEmitter(particleSystemConfig, parent);
			_EmitterCoins = emitterCoins;
			Transform transform = _EmitterCoins.transform;
			Transform parent2 = base.transform;
			transform.parent = parent2;
			GameObject gameObject2 = base.gameObject;
			ParticleEmitterManager particleEmitterManager2 = gameObject2.AddComponent<ParticleEmitterManager>();
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("items");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			List<string> list2 = new List<string>();
			int version2 = list2._version + 1;
			list2._version = version2;
			string[] items2 = list2._items;
			if (list2._size >= items2.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"GemBlue.png");
			}
			else
			{
				int size2 = list2._size + 1;
				list2._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list2._version + 1;
			list2._version = version3;
			string[] items3 = list2._items;
			if (list2._size >= items3.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"GemGreen.png");
			}
			else
			{
				int size3 = list2._size + 1;
				list2._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1B0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1C0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 464));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1D0]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 496));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(225f, 275f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 528));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+220]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
			particleSystemConfig2._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig2._collideBottom = (bool?)(object)0;
			Transform parent3 = base.transform;
			ParticleSystem emitterGems = particleEmitterManager2.CreateEmitter(particleSystemConfig2, parent3);
			_EmitterGems = emitterGems;
			Transform transform2 = _EmitterGems.transform;
			Transform parent4 = base.transform;
			transform2.parent = parent4;
			GameObject gameObject3 = base.gameObject;
			ParticleEmitterManager particleEmitterManager3 = gameObject3.AddComponent<ParticleEmitterManager>();
			ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("items");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig3._quantity = (int?)(object)0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			List<string> list3 = new List<string>();
			int version4 = list3._version + 1;
			list3._version = version4;
			string[] items4 = list3._items;
			if (list3._size >= items4.Length)
			{
				((List<object>)(object)list3).AddWithResize((object)"Clover2.png");
			}
			else
			{
				int size4 = list3._size + 1;
				list3._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig3._frame = list3;
			ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 560));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+230]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+240]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
			particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 592));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+250]");
			particleSystemConfig3._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+260]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 624));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(225f, 275f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+270]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
			particleSystemConfig3._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+88]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 656));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+290]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
			particleSystemConfig3._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
			particleSystemConfig3._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig3._collideBottom = (bool?)(object)0;
			Transform parent5 = base.transform;
			ParticleSystem emitterClovers = particleEmitterManager3.CreateEmitter(particleSystemConfig3, parent5);
			_EmitterClovers = emitterClovers;
			Transform transform3 = _EmitterClovers.transform;
			Transform parent6 = base.transform;
			transform3.parent = parent6;
			GameObject gameObject4 = base.gameObject;
			ParticleEmitterManager particleEmitterManager4 = gameObject4.AddComponent<ParticleEmitterManager>();
			ParticleSystemConfig particleSystemConfig4 = new ParticleSystemConfig("items");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig4._quantity = (int?)(object)0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig4._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			List<string> list4 = new List<string>();
			int version5 = list4._version + 1;
			list4._version = version5;
			string[] items5 = list4._items;
			if (list4._size >= items5.Length)
			{
				((List<object>)(object)list4).AddWithResize((object)"SkullToken.png");
			}
			else
			{
				int size5 = list4._size + 1;
				list4._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig4._frame = list4;
			ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 688));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2B0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2C0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B8]");
			particleSystemConfig4._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve15 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 720));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve15, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
			particleSystemConfig4._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2E0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve16 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 752));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve16, new ParticleSystem.MinMaxCurve(225f, 275f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2F0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+300]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			particleSystemConfig4._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve17 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 784));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve17, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+310]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+320]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+108]");
			particleSystemConfig4._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+118]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+128]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
			particleSystemConfig4._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+3D0]");
			particleSystemConfig4._collideBottom = (bool?)(object)0;
			Transform parent7 = base.transform;
			ParticleSystem emitterSkulls = particleEmitterManager4.CreateEmitter(particleSystemConfig4, parent7);
			_EmitterSkulls = emitterSkulls;
			Transform transform4 = _EmitterSkulls.transform;
			Transform parent8 = base.transform;
			transform4.parent = parent8;
			bool fixedTimeStep = default(bool);
			_EmitterSkulls.Simulate(0f, withChildren: true, restart: true, fixedTimeStep);
			_EmitterClovers.Simulate(0f, withChildren: true, restart: true, fixedTimeStep);
			_EmitterGems.Simulate(0f, withChildren: true, restart: true, fixedTimeStep);
			_EmitterCoins.Simulate(0f, withChildren: true, restart: true, fixedTimeStep);
			_emitterBuilt = true;
		}
	}

	public unsafe void PlayParticleVFXAt(Vector3 finalPos, MadMoonSymbol mmSymbol)
	{
		//IL_0008: Expected O, but got Ref
		//IL_026e: Expected O, but got I
		//IL_005f: Expected O, but got I4
		//IL_0292: Expected O, but got I
		//IL_02b2: Expected O, but got I
		//IL_01e5: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0209: Expected O, but got I
		//IL_0229: Expected O, but got I
		//IL_014c: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_0190: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_0232->IL0304: Incompatible stack heights: 2 vs 1
		//IL_00a4->IL02d8: Incompatible stack heights: 0 vs 1
		//IL_02d8->IL02d8: Incompatible stack heights: 2 vs 1
		//IL_0199->IL0304: Incompatible stack heights: 2 vs 1
		//IL_024f->IL024f: Incompatible stack heights: 3 vs 0
		//IL_01b0->IL01b0: Incompatible stack heights: 3 vs 0
		//IL_0117->IL0304: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = finalPos.z;
		_ = finalPos.x;
		_ = 0;
		_ = 1;
		_ = 1;
		bool flag = mmSymbol == MadMoonSymbol.Curse;
		if (flag)
		{
			goto IL_024f;
		}
		object obj3 = mmSymbol - 1;
		if (flag)
		{
			goto IL_01b0;
		}
		object obj4 = obj3 - 1;
		object obj5;
		IntPtr cachedPtr;
		object obj6;
		object obj7;
		if (!flag)
		{
			if ((nint)obj4 != 1)
			{
				return;
			}
			ParticleSystem emitterCoins = _EmitterCoins;
			bool flag2 = (object)_EmitterCoins == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			_ = 0;
			_ = 0;
			_ = 0;
			cachedPtr = ((UnityEngine.Object)emitterCoins).m_CachedPtr;
			bool flag3 = ((UnityEngine.Object)emitterCoins).m_CachedPtr == (IntPtr)0;
			obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			obj7 = 0;
		}
		else
		{
			ParticleSystem emitterClovers = _EmitterClovers;
			bool flag4 = (object)_EmitterClovers == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			_ = 0;
			_ = 0;
			_ = 0;
			cachedPtr = ((UnityEngine.Object)emitterClovers).m_CachedPtr;
			bool flag5 = ((UnityEngine.Object)emitterClovers).m_CachedPtr == (IntPtr)0;
			obj6 = 0;
			bool flag6 = (nint)0 != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			obj7 = 0;
			if (!flag6)
			{
				bool flag7 = (nint)0 == 0;
				goto IL_01b0;
			}
		}
		goto IL_0304;
		IL_0304:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v667 @ rax_v26 (should have been resolved before IL gen)");
		return;
		IL_01b0:
		ParticleSystem emitterGems = _EmitterGems;
		bool flag8 = (object)_EmitterGems == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
		obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
		_ = 0;
		_ = 0;
		_ = 0;
		cachedPtr = ((UnityEngine.Object)emitterGems).m_CachedPtr;
		bool flag9 = ((UnityEngine.Object)emitterGems).m_CachedPtr == (IntPtr)0;
		obj6 = 0;
		bool flag10 = (nint)0 != 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
		obj7 = 0;
		if (!flag10)
		{
			bool flag11 = (nint)0 == 0;
			goto IL_024f;
		}
		goto IL_0304;
		IL_024f:
		ParticleSystem emitterSkulls = _EmitterSkulls;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
		obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
		_ = 0;
		_ = 0;
		_ = 0;
		cachedPtr = ((UnityEngine.Object)emitterSkulls).m_CachedPtr;
		bool flag12 = ((UnityEngine.Object)emitterSkulls).m_CachedPtr == (IntPtr)0;
		obj6 = 0;
		bool flag13 = (nint)0 != 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
		obj7 = 0;
		if (!flag13)
		{
			bool flag14 = (nint)0 == 0;
			return;
		}
		goto IL_0304;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (_blackbarTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_blackbarTween);
		}
		if (_reelDelayTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_reelDelayTween);
		}
	}
}
