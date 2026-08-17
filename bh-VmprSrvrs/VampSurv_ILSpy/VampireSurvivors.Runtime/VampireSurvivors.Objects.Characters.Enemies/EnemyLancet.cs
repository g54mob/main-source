using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyLancet : PoolableMonoBehaviour
{
	private SpriteRenderer _groundFx;

	private Transform _cachedTransform;

	private GameSessionData _gameSessionData;

	private PlayerOptions _playerOptions;

	private EnemyGallo _owner;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _gravityWell;

	private bool _hasHit;

	private Tween _despawnTimer;

	private Circle _circle;

	private const float Radius = 30f;

	private const float Diameter = 60f;

	private float _003CDuration_003Ek__BackingField;

	public float Duration
	{
		get
		{
			return _003CDuration_003Ek__BackingField;
		}
		set
		{
			_003CDuration_003Ek__BackingField = value;
		}
	}

	protected virtual void FakeConstruct()
	{
		GameManager core = GM.Core;
		_gameSessionData = core._gameSessionData;
		GameManager core2 = GM.Core;
		_playerOptions = core2._playerOptions;
	}

	private void Awake()
	{
		//IL_0096->IL0109: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0109: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		Transform cachedTransform2 = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 _);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, null, "UnityCircle");
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 1f);
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)spriteRenderer2 != null)
			{
				((Renderer)spriteRenderer2).SetMaterial(material);
				SpriteRenderer groundFx = RenderingExtensions.SetTint(spriteRenderer2, 255u);
				_groundFx = groundFx;
				if ((object)_groundFx != null)
				{
					_groundFx.enabled = false;
					GenerateParticleSystems();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void OnDrawGizmos()
	{
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rbx_v2 (System.Object)+10]");
		double ret;
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
		double y = default(double);
		VSDebug.DrawDebugCircle(ret, y, 0.29999998211860657);
	}

	public unsafe void Init()
	{
		//IL_0215->IL0195: Incompatible stack heights: 1 vs 0
		//IL_0039->IL0195: Incompatible stack heights: 1 vs 0
		//IL_00b5->IL0195: Incompatible stack heights: 3 vs 0
		//IL_02c1->IL0195: Incompatible stack heights: 3 vs 0
		FakeConstruct();
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			if ((object)_groundFx != null)
			{
				_groundFx.enabled = false;
				if ((object)_groundFx != null)
				{
					Transform transform = _groundFx.transform;
					bool flag2 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v24 (UnityEngine.Transform)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v24 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					float y = default(float);
					_circle = new Circle
					{
						_x = ret,
						_y = y,
						_radius = 0.29999998f
					};
					_hasHit = false;
					if (_despawnTimer != null)
					{
						TweenExtensions.Kill(_despawnTimer);
					}
					if ((object)_groundFx != null)
					{
						Transform target = _groundFx.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 60f, 0.120000005f);
						TweenCallback tweenCallback = Despawn;
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v36 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore != null)
						{
							_despawnTimer = tweenerCore;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetDepthPlease(float depth)
	{
		float num = depth * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		_groundFx.sortingOrder = sortingOrder;
		_particlesManager.SetDepthMultiplied(depth);
	}

	public unsafe void InternalUpdate()
	{
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_00ea->IL01db: Incompatible stack heights: 3 vs 0
		//IL_00b4->IL01c0: Incompatible stack heights: 3 vs 2
		//IL_013b->IL01db: Incompatible stack heights: 3 vs 0
		if (_hasHit)
		{
			return;
		}
		GameManager core = GM.Core;
		List<CharacterController>.Enumerator characters = (List<CharacterController>.Enumerator)core._characters;
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
		bool playWeaponDamageFx = default(bool);
		bool ignoreInvulnerabilityForRestoringTint = default(bool);
		while (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
			bool flag = (object)cachedTrans == null;
			bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (arcadeSprite.body != null)
			{
				BaseBody body = arcadeSprite.body;
				ArcadeTransform arcadeTransform = body._transform;
				bool flag3 = body._transform == null;
				arcadeTransform.position = ret;
			}
			bool flag4 = _circle == null;
			bool flag5 = _circle.Contains((Vector2)enumerator2);
			bool flag6 = !flag5;
			characters = enumerator2;
			if (!flag6)
			{
				float num = _003CDuration_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rbx_v11 (ArcadeSprite)+278]");
				characters = (List<CharacterController>.Enumerator)(num + 0);
				((CharacterController)null).OnGetDamaged("#0000ff", 30f, false, playWeaponDamageFx, ignoreInvulnerabilityForRestoringTint);
				_hasHit = true;
			}
		}
		if (_hasHit)
		{
			OnHit();
		}
	}

	public void SetOwner(EnemyGallo enemyGallo)
	{
		_owner = enemyGallo;
	}

	private void Despawn()
	{
		EnemyGallo owner = _owner;
		if ((object)_owner != null && ((UnityEngine.Object)owner).m_CachedPtr != (IntPtr)0)
		{
			EnemyGallo owner2 = _owner;
			List<EnemyLancet> enemyLancetProjectiles = owner2._enemyLancetProjectiles;
			if (enemyLancetProjectiles._size != 0)
			{
				int num = Array.IndexOf((object[])enemyLancetProjectiles._items, (object)this, 0, enemyLancetProjectiles._size);
				if (num != -1)
				{
					bool flag = ((List<object>)(object)owner2._enemyLancetProjectiles).Remove((object)this);
				}
			}
		}
		RenderingExtensions.StopEmitting(_pfxEmitter);
		RenderingExtensions.StopEmitting(_pfxEmitter2);
		if (_despawnTimer != null)
		{
			TweenExtensions.Kill(_despawnTimer);
		}
		_groundFx.enabled = false;
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
	}

	private void OnHit()
	{
		//IL_0224: Expected O, but got I4
		//IL_02de: Expected O, but got F4
		//IL_02b8->IL0264: Incompatible stack heights: 1 vs 0
		RenderingExtensions.Start(_pfxEmitter);
		RenderingExtensions.Start(_pfxEmitter2);
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
				{
					goto IL_0264;
				}
				if ((object)_groundFx != null)
				{
					_groundFx.enabled = true;
					if ((object)_groundFx != null)
					{
						Transform transform = _groundFx.transform;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						goto IL_0264;
					}
				}
			}
		}
		goto IL_0258;
		IL_0258:
		throw new NullReferenceException();
		IL_0264:
		if (_despawnTimer != null)
		{
			TweenExtensions.Kill(_despawnTimer);
		}
		if ((object)_groundFx != null)
		{
			Transform target = _groundFx.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 60f, 0.120000005f);
			TweenCallback tweenCallback = Despawn;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (tweenerCore != null)
			{
				_despawnTimer = tweenerCore;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				object obj = UnityEngine.Random.value;
				float num = (float)Vector3.oneVector - 0.5f;
				float detune = num * 500f;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, time);
				return;
			}
		}
		goto IL_0258;
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007e: Expected O, but got I
		//IL_0297: Expected O, but got I4
		//IL_02b0: Expected O, but got Ref
		//IL_02ca: Expected native int or pointer, but got O
		//IL_02e4: Expected O, but got I
		//IL_0304: Expected O, but got Ref
		//IL_031e: Expected native int or pointer, but got O
		//IL_0338: Expected O, but got I
		//IL_0358: Expected O, but got Ref
		//IL_0372: Expected native int or pointer, but got O
		//IL_0a2b: Expected O, but got I4
		//IL_038a: Expected O, but got Ref
		//IL_03b1: Expected O, but got I
		//IL_03cb: Expected native int or pointer, but got O
		//IL_0a5d: Expected O, but got I
		//IL_0403: Expected O, but got Ref
		//IL_042a: Expected O, but got I
		//IL_0444: Expected native int or pointer, but got O
		//IL_0a97: Expected O, but got I
		//IL_06b6: Expected O, but got I4
		//IL_06cf: Expected O, but got Ref
		//IL_06e9: Expected native int or pointer, but got O
		//IL_0703: Expected O, but got I
		//IL_0723: Expected O, but got Ref
		//IL_073d: Expected native int or pointer, but got O
		//IL_0757: Expected O, but got I
		//IL_0777: Expected O, but got Ref
		//IL_0791: Expected native int or pointer, but got O
		//IL_0ad1: Expected O, but got I
		//IL_07c9: Expected O, but got Ref
		//IL_07f0: Expected O, but got I
		//IL_080a: Expected native int or pointer, but got O
		//IL_0818: Expected O, but got I4
		//IL_0af9: Expected O, but got I4
		//IL_0864: Expected O, but got I
		//IL_0885: Expected O, but got I
		//IL_093c: Expected O, but got I
		//IL_00df->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_012e->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_01e2->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_0264->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_0496->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_04fe->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_054d->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_0601->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_0683->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_08ad->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_0922->IL09ae: Incompatible stack heights: 2 vs 0
		//IL_0980->IL09ae: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			GameObject gameObject = base.gameObject;
			_ = 0;
			bool flag2 = (object)gameObject == null;
			ParticleEmitterManager particlesManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 368))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
				particlesManager = (ParticleEmitterManager)0;
			}
			else
			{
				particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_particlesManager = particlesManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"feedback-5");
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version2 = list._version + 1;
					list._version = version2;
					string[] items2 = list._items;
					if (list._items != null)
					{
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"feedback-4");
						}
						else
						{
							int size2 = list._size + 1;
							list._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						if (particleSystemConfig != null)
						{
							particleSystemConfig._frame = list;
							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
							particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
							particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
							particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
							particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
							_ = 0;
							_ = 2;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
							particleSystemConfig._quantity = (int?)(object)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
							particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
							_ = 0;
							_ = 1073741824;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
							particleSystemConfig._frequency = (float?)(object)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B8]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
							particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
							_ = 0;
							particleSystemConfig._on = false;
							if ((object)_particlesManager != null)
							{
								ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
								_pfxEmitter2 = pfxEmitter;
								ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
								List<string> list2 = new List<string>();
								if (list2 != null)
								{
									int version3 = list2._version + 1;
									list2._version = version3;
									string[] items3 = list2._items;
									if (list2._items != null)
									{
										if (list2._size >= items3.Length)
										{
											((List<object>)(object)list2).AddWithResize((object)"feedback-5");
										}
										else
										{
											int size3 = list2._size + 1;
											list2._size = size3;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version4 = list2._version + 1;
										list2._version = version4;
										string[] items4 = list2._items;
										if (list2._items != null)
										{
											if (list2._size >= items4.Length)
											{
												((List<object>)(object)list2).AddWithResize((object)"feedback-4");
											}
											else
											{
												int size4 = list2._size + 1;
												list2._size = size4;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											if (particleSystemConfig2 != null)
											{
												particleSystemConfig2._frame = list2;
												minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
												particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C8]");
												particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D8]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E8]");
												particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F8]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 264));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+108]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+118]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
												particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
												_ = 0;
												_ = 2;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
												particleSystemConfig2._quantity = (int?)(object)0;
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
												obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+128]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+138]");
												_ = 0;
												obj = 1;
												particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)obj;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
												_ = 0;
												_ = 0;
												_ = 1065353216;
												_ = 1;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
												particleSystemConfig2._frequency = (float?)(object)0;
												_ = 1;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
												particleSystemConfig2._blendMode = (BlendMode?)(object)0;
												particleSystemConfig2._on = false;
												if ((object)_particlesManager != null)
												{
													ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
													_pfxEmitter = pfxEmitter2;
													GravityWellConfig gravityWellConfig = new GravityWellConfig();
													_ = 0;
													_ = 1;
													object obj3 = default(object);
													float num = (float)obj3 + 0.19999999f;
													if (gravityWellConfig != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
														gravityWellConfig._y = (float?)(object)0;
														gravityWellConfig._power = 1f;
														gravityWellConfig._epsilon = 50f;
														gravityWellConfig._gravity = 20f;
														if ((object)_particlesManager != null)
														{
															GravityWell gravityWell = _particlesManager.CreateGravityWell(gravityWellConfig, null, "Well");
															_gravityWell = gravityWell;
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
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public EnemyLancet()
	{
		//IL_002b: Expected I, but got O
		_003CDuration_003Ek__BackingField = 0.3f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
