using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Fibonacci2_Projectile : Projectile
{
	private const float Radius = 16f;

	private const float FibOffsetModifier = 0.01f;

	private readonly List<string> SuitFrames;

	private LEM_Fibonacci2_Weapon _trueWeapon;

	private int _fibIndex;

	private List<int> _fibSequence;

	private List<float2> _fibOffsets;

	private Transform _container;

	private float2 _offset;

	private float _angle;

	private float _angleForNextOffset;

	private bool _isDespawning;

	private float _cachedArea;

	private bool _updateFlushVFX;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfxFlush;

	private ParticleSystem _pfxSuit;

	private Timer _despawnTimer;

	private Timer _pfxFlushTimer;

	private Timer _pfxSuitTimer;

	private float SpeedModifier
	{
		get
		{
			float num = _weapon.PSpeed();
			object obj = default(object);
			return (float)obj * 200f;
		}
	}

	private float ScaledAlpha
	{
		get
		{
			//IL_001d: Invalid comparison between F4 and O
			//IL_0046: Invalid comparison between O and F4
			float num = _weapon.PArea();
			object obj = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			float result = 1f;
			if (!flag)
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
				{
					return 0.6f;
				}
				float num2 = (float)obj - 1f;
				float num3 = num2 * 0.39999998f;
				float num4 = num3 * 0.25f;
				result = 1f - num4;
			}
			return result;
		}
	}

	private bool ForceStopEmittingFlushParticles
	{
		get
		{
			//IL_00b0: Expected I4, but got O
			//IL_001c: Expected O, but got I
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			List<int> fibSequence = _fibSequence;
			if (_fibSequence != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj = -_fibIndex;
				object obj2 = obj - 7;
				object obj3 = obj ^ 7;
				object obj4 = obj ^ obj2;
				object obj5 = obj3 & obj4;
				bool flag = (nint)obj5 < 0;
				bool flag2 = (nint)obj2 < 0;
				bool flag3 = obj2 == null;
				bool flag4 = flag2 != flag;
				return flag4 | flag3;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private bool ForceStopEmittingSuitParticles
	{
		get
		{
			//IL_00b0: Expected I4, but got O
			//IL_001c: Expected O, but got I
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			List<int> fibSequence = _fibSequence;
			if (_fibSequence != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj = -_fibIndex;
				object obj2 = obj - 9;
				object obj3 = obj ^ 9;
				object obj4 = obj ^ obj2;
				object obj5 = obj3 & obj4;
				bool flag = (nint)obj5 < 0;
				bool flag2 = (nint)obj2 < 0;
				bool flag3 = obj2 == null;
				bool flag4 = flag2 != flag;
				return flag4 | flag3;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystem();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0029: Expected I, but got O
		//IL_0031: Expected I4, but got O
		//IL_0041: Expected O, but got I
		//IL_00c1: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_05e9: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_01eb: Expected O, but got I
		//IL_03cd: Expected O, but got I
		//IL_03e4: Expected O, but got I
		//IL_0417: Expected F4, but got I
		//IL_0325: Expected O, but got I
		//IL_033b: Expected O, but got I
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0466: Expected O, but got I4
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Expected O, but got Unknown
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Expected O, but got Unknown
		//IL_048a: Expected O, but got I4
		//IL_048a: Expected O, but got I4
		//IL_04e9: Invalid comparison between F4 and I4
		//IL_072d: Expected O, but got I4
		//IL_0506: Expected F4, but got I4
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		BulletPool bulletPool;
		if ((object)_weapon == null)
		{
			bulletPool = pool;
			trueWeapon = (float?)(object)0;
			goto IL_05b4;
		}
		nint num = (nint)typeof(LEM_Fibonacci2_Weapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Fibonacci2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v2 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Fibonacci2_Weapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v2 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v100+FFFFFFF8+v72 @ rax_v95*8]");
			if (0 == (nint)typeof(LEM_Fibonacci2_Weapon))
			{
				obj3 = 1;
				goto IL_05c3;
			}
		}
		obj3 = 0;
		goto IL_05c3;
		IL_05c3:
		bool flag = obj3 == null;
		bulletPool = (BulletPool)(object)typeof(LEM_Fibonacci2_Weapon);
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			bulletPool = (BulletPool)(object)typeof(LEM_Fibonacci2_Weapon);
			trueWeapon = (float?)_weapon;
		}
		goto IL_05b4;
		IL_05b4:
		_trueWeapon = (LEM_Fibonacci2_Weapon)trueWeapon;
		LEM_Fibonacci2_Weapon trueWeapon2 = _trueWeapon;
		_isCullable = false;
		_isDespawning = false;
		_updateFlushVFX = false;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbp_v10 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		if (((LEM_Fibonacci1_Weapon)trueWeapon2)._003CFibonacciSequence_003Ek__BackingField != null)
		{
			List<int> fibSequence = new List<int>(((LEM_Fibonacci1_Weapon)trueWeapon2)._003CFibonacciSequence_003Ek__BackingField);
			_fibSequence = fibSequence;
			LEM_Fibonacci2_Weapon trueWeapon3 = _trueWeapon;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rbp_v11 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				((List<int>)0)._002Ector((IEnumerable<int>)((LEM_Fibonacci1_Weapon)trueWeapon2)._003CFibonacciSequence_003Ek__BackingField);
			}
			if (((LEM_Fibonacci1_Weapon)trueWeapon3)._003CFibonacciOffsets_003Ek__BackingField != null)
			{
				List<float2> fibOffsets = new List<float2>(((LEM_Fibonacci1_Weapon)trueWeapon3)._003CFibonacciOffsets_003Ek__BackingField);
				_fibOffsets = fibOffsets;
				((List<float2>)(object)_fibSequence)._002Ector((IEnumerable<float2>)((LEM_Fibonacci1_Weapon)trueWeapon3)._003CFibonacciOffsets_003Ek__BackingField);
				List<float2> fibOffsets2 = _fibOffsets;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)0 >= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)0 > (nint)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
						int num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
						if ((nint)0 == 0)
						{
							ArgumentNullException ex = new ArgumentNullException("array");
							ex._002Ector("array");
							throw ex;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ r9_v15 (System.Int32)+18]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						if (num6 < 0)
						{
							object obj4 = new ArgumentException();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
							throw obj4;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
						object obj5 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
						LEM_Fibonacci2_Projectile lEM_Fibonacci2_Projectile = (LEM_Fibonacci2_Projectile)((nint)0 + (nint)32);
						object obj6 = obj5 * 8;
						BulletPool bulletPool2 = (BulletPool)(object)((object)lEM_Fibonacci2_Projectile + obj6);
						bulletPool2 = pool;
						lEM_Fibonacci2_Projectile = this;
						do
						{
							lEM_Fibonacci2_Projectile = (LEM_Fibonacci2_Projectile)(object)bulletPool2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rdx_v40 (VampireSurvivors.Objects.Pools.BulletPool)+4]");
							_ = 0;
							lEM_Fibonacci2_Projectile = (LEM_Fibonacci2_Projectile)(lEM_Fibonacci2_Projectile + 8);
							bulletPool2 = (BulletPool)(object)lEM_Fibonacci2_Projectile;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rcx_v62 (VampireSurvivors.Objects.Projectiles.LEM_Fibonacci2_Projectile)+4]");
							_ = 0;
							bulletPool2 = (BulletPool)(bulletPool2 - 8);
						}
						while (System.Runtime.CompilerServices.Unsafe.As<LEM_Fibonacci2_Projectile, UIntPtr>(ref lEM_Fibonacci2_Projectile) < System.Runtime.CompilerServices.Unsafe.As<BulletPool, UIntPtr>(ref bulletPool2));
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v21 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
					_ = (nint)0 + (nint)1;
					List<float2> fibOffsets3 = _fibOffsets;
					_fibIndex = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v51 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v51 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v52+20]");
						_offset = (float2)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v52+24]");
						_ = 0;
						float startingAngle = _trueWeapon.StartingAngle;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v52+20]");
						_angle = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v52+20]");
						float num7 = (_angleForNextOffset = 0f - 90f);
						float num8 = _weapon.PArea();
						_cachedArea = num7;
						ArcadeSprite arcadeSprite = setScale(num7, (float?)(object)0);
						BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
						BaseBody baseBody2 = body;
						baseBody2._enable = true;
						InitPfx();
						RotateContainer();
						float num9 = _weapon.PSpeed();
						float num10 = num7 - 1f;
						if (!(num10 > 0f))
						{
							num10 = 0f;
						}
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						float num11 = num10 * 600f;
						soundConfig.Rate = 1f;
						float num12 = (float)_indexInWeapon * -100f;
						float detune = num12 + num11;
						soundConfig.Detune = detune;
						soundConfig.Volume = (float?)(object)1;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_fibonacci_stream, soundConfig, 200f, 10, time);
						UpdateAll();
						return;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.count, System.ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
			}
			Exception ex2 = System.Linq.Error.ArgumentNull("source");
			throw ex2;
		}
		Exception ex3 = System.Linq.Error.ArgumentNull("source");
		throw ex3;
	}

	private void InitPfx()
	{
		if (_pfxFlushTimer != null)
		{
			_pfxFlushTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_updateFlushVFX = true;
		};
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer pfxFlushTimer = Timers.Register(0.1f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_pfxFlushTimer = pfxFlushTimer;
		List<string> list = new List<string>();
		LEM_Fibonacci2_Weapon trueWeapon = _trueWeapon;
		List<string> suitFrames = SuitFrames;
		int num = trueWeapon._003CFireCounter_003Ek__BackingField % suitFrames._size;
		if (num < suitFrames._size)
		{
			string[] items = suitFrames._items;
			int version = list._version + 1;
			list._version = version;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)items[num]);
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			RenderingExtensions.SetFrames(_pfxSuit, list, null, clearExistingFrames: false, flag ? 1 : 0);
			if (_pfxSuitTimer != null)
			{
				_pfxSuitTimer.Cancel();
			}
			Action onComplete2 = PlaySuitPfx;
			Timer pfxSuitTimer = Timers.Register(0.1f, onComplete2, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_pfxSuitTimer = pfxSuitTimer;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe void RotateContainer()
	{
		//IL_0209: Expected O, but got Ref
		//IL_0188->IL0188: Incompatible stack heights: 1 vs 0
		Transform container = _container;
		if ((object)_container != null && ((UnityEngine.Object)container).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0188;
		}
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		Vector3 value = default(Vector3);
		if ((object)gameObject != null)
		{
			Transform container2 = gameObject.transform;
			_container = container2;
			if ((object)_trueWeapon != null)
			{
				Transform parent = _trueWeapon.transform;
				if ((object)_container != null)
				{
					_container.SetParent(parent, worldPositionStays: true);
					if ((object)_container != null)
					{
						((UnityEngine.Object)_container).SetName("Fibonacci2Projectile_Container");
						if ((object)_container != null)
						{
							Transform transform = _container.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							Transform transform2 = base.transform;
							transform2.SetParent(_container, worldPositionStays: true);
							value = Vector3.zeroVector;
							goto IL_0188;
						}
					}
				}
			}
		}
		goto IL_020a;
		IL_0188:
		if ((object)_trueWeapon != null && (object)_container != null)
		{
			Transform transform3 = _container.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
			if ((object)transform3 != null)
			{
				transform3.localEulerAngles = (Vector3)(&value);
				return;
			}
		}
		goto IL_020a;
		IL_020a:
		throw new NullReferenceException();
	}

	private void PlaySpinningSfx()
	{
		//IL_002d: Invalid comparison between F4 and I4
		//IL_00d6: Expected O, but got I4
		//IL_004d: Expected F4, but got I4
		float num = _weapon.PSpeed();
		object obj = default(object);
		float num2 = (float)obj - 1f;
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		float num3 = num2 * 600f;
		soundConfig.Rate = 1f;
		float num4 = (float)_indexInWeapon * -100f;
		float detune = num4 + num3;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_fibonacci_stream, soundConfig, 200f, 10, time);
	}

	public override void InternalUpdate()
	{
		UpdateAll();
	}

	public unsafe void UpdateAll()
	{
		//IL_0059: Expected O, but got Ref
		if (!_isDespawning)
		{
			UpdateAngleAndOffset();
			UpdatePosition();
			Transform transform = _cachedTransform.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
			UpdateVfx();
		}
	}

	private void UpdateAngleAndOffset()
	{
		//IL_0031: Invalid comparison between I4 and F4
		//IL_0170: Expected O, but got I4
		//IL_01be: Expected I, but got O
		//IL_00a8: Expected O, but got I
		//IL_00bd: Expected O, but got I4
		//IL_00d2: Expected F4, but got I
		//IL_00e4: Expected O, but got I
		float num = _angleForNextOffset;
		if (!(_angleForNextOffset < _angle))
		{
			float angleForNextOffset = _angleForNextOffset - 90f;
			_angleForNextOffset = angleForNextOffset;
			if (!((float)_fibIndex < 8f))
			{
				BaseBody baseBody = body;
				_isDespawning = true;
				baseBody._enable = false;
				ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
				if (_despawnTimer != null)
				{
					_despawnTimer.Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Fibonacci2_Projectile>)+370]");
				Action onComplete = new Action(this, (IntPtr)0);
				nint num2 = (nint)this;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer despawnTimer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_despawnTimer = despawnTimer;
				return;
			}
			List<float2> fibOffsets = _fibOffsets;
			int num3 = ++_fibIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v19 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj = 0;
			object obj2 = _fibIndex + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v20+20+v63 @ rax_v26*8]");
			num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v20+20+v63 @ rax_v26*8]");
			_offset = (float2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v20+24+v63 @ rax_v26*8]");
			_ = 0;
		}
		float num4 = _weapon.PSpeed();
		float num5 = num * 200f;
		float deltaTime = PauseSystem.DeltaTime;
		float num6 = deltaTime * num5;
		float num7 = _angle - num6;
		_angle = num7;
	}

	private void UpdatePosition()
	{
		//IL_003a: Expected O, but got I
		//IL_005a->IL00b1: Incompatible stack heights: 1 vs 0
		//IL_00a2->IL00b1: Incompatible stack heights: 1 vs 0
		List<int> fibSequence = _fibSequence;
		float num = _angle * ((float)Math.PI / 180f);
		int fibIndex = _fibIndex;
		if (_fibSequence != null)
		{
			int fibIndex2 = _fibIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdi_v1 (System.Collections.Generic.List`1<System.Int32>)+18]");
			bool flag = (nint)fibIndex2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdi_v1 (System.Collections.Generic.List`1<System.Int32>)+10]");
			List<int> list = (List<int>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdi_v1 (System.Collections.Generic.List`1<System.Int32>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				List<int> cachedTransform = (List<int>)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v9 (System.Collections.Generic.List`1<System.Int32>)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v9 (System.Collections.Generic.List`1<System.Int32>)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected((IntPtr)0, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateRotation()
	{
		//IL_0026: Expected O, but got Ref
		Transform transform = _cachedTransform.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private unsafe void UpdateVfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0029: Expected O, but got I
		//IL_0079: Expected O, but got I
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00da: Expected O, but got Ref
		//IL_0106: Expected native int or pointer, but got O
		//IL_0138: Expected O, but got Ref
		//IL_0145: Expected native int or pointer, but got O
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0189: Expected O, but got I4
		//IL_01ec: Expected O, but got Ref
		//IL_020c: Expected O, but got Ref
		//IL_0248: Expected O, but got Ref
		//IL_03ab: Expected O, but got Ref
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_02fa: Expected O, but got I
		//IL_041b->IL03dc: Incompatible stack heights: 1 vs 0
		//IL_0420->IL03e1: Incompatible stack heights: 1 vs 0
		//IL_02e0->IL030c: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = !_updateFlushVFX;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if (flag)
		{
			return;
		}
		List<int> fibSequence = _fibSequence;
		if (_fibSequence != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj3 = -_fibIndex;
			bool flag2 = (nint)obj3 == 7;
			if ((nint)obj3 <= 7)
			{
				return;
			}
			List<int> fibSequence2 = _fibSequence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = -_fibIndex;
			float maxInclusive = (float)obj4 + _angle;
			float minInclusive = _angle - (float)obj4;
			float num = UnityEngine.Random.Range(minInclusive, maxInclusive);
			object obj5 = obj4 + 1;
			float num2 = _cachedArea * 0.05f;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			float num3 = num * -1f;
			float min = num2 * (float)obj5;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(min, 0f));
			float scaledAlpha = ScaledAlpha;
			float min2 = scaledAlpha * 0.25f;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(min2, 0f));
			object obj6 = obj4 >> 1;
			if (flag2)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj7 = num3 ^ 0;
			object obj8 = 0;
			Vector2 pos = default(Vector2);
			while ((object)_pfxFlush != null)
			{
				Transform transform = _pfxFlush.transform;
				if ((object)transform == null)
				{
					break;
				}
				Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				transform.localEulerAngles = localEulerAngles;
				ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
				_ = 0;
				RenderingExtensions.SetScale(_pfxFlush, minMaxCurve3);
				ParticleSystem.MinMaxCurve value = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				_ = 0;
				RenderingExtensions.SetAlpha(_pfxFlush, value);
				Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
				if ((object)cachedTrans == null)
				{
					break;
				}
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)obj9);
				if (body != null)
				{
					BaseBody baseBody = body;
					ArcadeTransform arcadeTransform = baseBody._transform;
					if (baseBody._transform == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
					arcadeTransform.position = (float2)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
					_ = 0;
				}
				RenderingExtensions.EmitParticleAt(_pfxFlush, pos, 1);
				obj8++;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
				{
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PlaySuitPfx()
	{
		//IL_001c: Expected O, but got I
		//IL_0062: Expected O, but got I
		//IL_00a0: Invalid comparison between I4 and F4
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_00c7: Expected F4, but got I4
		//IL_010b: Expected O, but got Ref
		//IL_011a: Expected O, but got Ref
		//IL_0133: Expected O, but got Ref
		List<int> fibSequence = _fibSequence;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+18]");
		object obj = -_fibIndex;
		if ((nint)obj > 9)
		{
			List<int> fibSequence2 = _fibSequence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = -_fibIndex;
			float maxInclusive = (float)obj2 + _angle;
			float minInclusive = _angle - (float)obj2;
			float num = UnityEngine.Random.Range(minInclusive, maxInclusive);
			float num2;
			if (!(0f > _cachedArea))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm1,xmm0\"");
				num2 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				num2 = _cachedArea;
			}
			float num3 = num2 * 0.03f;
			object obj3 = obj2 + 1;
			float min = num3 * (float)obj3;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
			float scaledAlpha = ScaledAlpha;
			float min2 = scaledAlpha * 0.5f;
			ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(min2, 0f);
			Transform transform = _pfxSuit.transform;
			object obj4 = default(object);
			transform.localEulerAngles = (Vector3)(&obj4);
			ParticleSystem.MinMaxCurve minMaxCurve3 = default(ParticleSystem.MinMaxCurve);
			RenderingExtensions.SetScale(_pfxSuit, (ParticleSystem.MinMaxCurve)(&minMaxCurve3));
			RenderingExtensions.SetAlpha(_pfxSuit, (ParticleSystem.MinMaxCurve)(&minMaxCurve3));
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(_pfxSuit, pos, 1);
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_02fb: Expected O, but got Ref
		//IL_0315: Expected native int or pointer, but got O
		//IL_08eb: Expected O, but got I
		//IL_034d: Expected O, but got Ref
		//IL_0374: Expected O, but got I
		//IL_038e: Expected native int or pointer, but got O
		//IL_03a8: Expected O, but got I
		//IL_03c8: Expected O, but got Ref
		//IL_03dd: Expected native int or pointer, but got O
		//IL_03f7: Expected O, but got I
		//IL_0630: Expected O, but got Ref
		//IL_064a: Expected native int or pointer, but got O
		//IL_0664: Expected O, but got I
		//IL_0684: Expected O, but got Ref
		//IL_069e: Expected native int or pointer, but got O
		//IL_0991: Expected O, but got I
		//IL_06d6: Expected O, but got Ref
		//IL_06fd: Expected O, but got I
		//IL_0724: Expected O, but got I
		//IL_073e: Expected native int or pointer, but got O
		//IL_0758: Expected O, but got I
		//IL_0778: Expected O, but got Ref
		//IL_078d: Expected native int or pointer, but got O
		//IL_07a7: Expected O, but got I
		//IL_048f: Expected I4, but got I8
		//IL_0855: Expected I4, but got I8
		//IL_094c: Expected I, but got O
		//IL_0951->IL08c1: Incompatible stack heights: 1 vs 0
		//IL_0a10->IL0975: Incompatible stack heights: 7 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager pfxManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
			pfxManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxManager = pfxManager;
		ParticleSystem pfxFlush = _pfxFlush;
		Vector3 value = default(Vector3);
		if ((object)_pfxFlush == null || ((UnityEngine.Object)pfxFlush).m_CachedPtr == (IntPtr)0)
		{
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 8f;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"BulletBlue");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"BulletBlue");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"bubble");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(20f, 40f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-51]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-41]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-79]");
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-69]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(2000f, 3000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-11]");
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-1]");
			_ = 0;
			particleSystemConfig._on = false;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			Transform parent = base.transform;
			ParticleSystem pfxFlush2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfxFlush = pfxFlush2;
			RenderingExtensions.SetDepth(_pfxFlush, -1999);
			Transform transform = _pfxFlush.transform;
			bool flag = (object)((ParticleSystemConfig)(object)transform)._x == null;
			Transform.set_localPosition_Injected((IntPtr)((ParticleSystemConfig)(object)transform)._x, ref value);
		}
		ParticleSystem pfxSuit = _pfxSuit;
		if ((object)_pfxSuit == null || ((UnityEngine.Object)pfxSuit).m_CachedPtr == (IntPtr)0)
		{
			Circle circle2 = new Circle();
			circle2._x = 0f;
			circle2._radius = 8f;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("LEM_vfx");
			List<string> list2 = new List<string>();
			bool flag2 = list2 == null;
			int version4 = list2._version + 1;
			list2._version = version4;
			string[] items4 = list2._items;
			bool flag3 = list2._items == null;
			if (list2._size >= items4.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"LEM_VFX_Heart");
			}
			else
			{
				int num4 = list2._size + 1;
				list2._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			bool flag4 = particleSystemConfig2 == null;
			particleSystemConfig2._frame = list2;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(-30f, 30f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-11]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-1]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(20f, 40f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1F]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2F]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 0;
			_ = 1140457472;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
			particleSystemConfig2._frequency = (float?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1000f, 2000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-51]");
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-41]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-79]");
			particleSystemConfig2._gravity = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-69]");
			_ = 0;
			particleSystemConfig2._on = false;
			particleSystemConfig2._emitZone = new EmitZone
			{
				_type = EmitZoneType.Random,
				_source = circle2
			};
			Transform parent2 = base.transform;
			bool flag5 = (object)_pfxManager == null;
			ParticleSystem pfxSuit2 = _pfxManager.CreateEmitter(particleSystemConfig2, parent2);
			_pfxSuit = pfxSuit2;
			RenderingExtensions.SetDepth(_pfxSuit, -1998);
			bool flag6 = (object)_pfxSuit == null;
			Transform transform2 = _pfxSuit.transform;
			bool flag7 = (object)transform2 == null;
			bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		}
	}

	private void StartDespawn()
	{
		//IL_0023: Expected O, but got I4
		//IL_0071: Expected I, but got O
		BaseBody baseBody = body;
		_isDespawning = true;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Fibonacci2_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		_updateFlushVFX = false;
		RenderingExtensions.StopEmitting(_pfxFlush);
		RenderingExtensions.ForceClear(_pfxFlush);
		RenderingExtensions.StopEmitting(_pfxSuit);
		RenderingExtensions.ForceClear(_pfxFlush);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_pfxFlushTimer != null)
		{
			_pfxFlushTimer.Cancel();
		}
		if (_pfxSuitTimer != null)
		{
			_pfxSuitTimer.Cancel();
		}
		base.Despawn();
	}

	public LEM_Fibonacci2_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"LEM_VFX_Heart");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"LEM_VFX_Club");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"LEM_VFX_Diamond");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"LEM_VFX_Spade");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		SuitFrames = list;
		base._002Ector();
	}

	private void _003CInitPfx_003Eb__30_0()
	{
		_updateFlushVFX = true;
	}
}
