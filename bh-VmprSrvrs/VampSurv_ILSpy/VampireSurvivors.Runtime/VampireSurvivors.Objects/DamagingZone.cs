using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects;

public class DamagingZone : PoolablePhaserSprite
{
	private Transform _cachedTransform;

	private bool _activateDamage;

	private bool _hasHit;

	private bool _follow;

	private string _skin;

	private float _damage;

	private float _durationMillis;

	private float _hitDelayMillis;

	private Timer _hitboxTimer;

	private Timer _despawnTimer;

	private PhaserSprite _groundFx;

	private ParticleSystem _currentEmitter1;

	private ParticleSystem _currentEmitter2;

	private ParticleEmitterManager _particlesManagerWeapons;

	private ParticleSystem _pfxEmitterW1;

	private ParticleSystem _pfxEmitterW2;

	private GravityWell _wellW;

	private ParticleEmitterManager _particlesManagerTrainees;

	private ParticleSystem _pfxEmitterT1;

	private ParticleSystem _pfxEmitterT2;

	private GravityWell _wellT;

	private ParticleEmitterManager _particlesManagerExplosions;

	private ParticleSystem _pfxEmitterE1;

	private ParticleSystem _pfxEmitterE2;

	private GravityWell _wellE;

	private ParticleEmitterManager _particlesManagerCoffins;

	private ParticleSystem _pfxEmitterC1;

	private ParticleSystem _pfxEmitterC2;

	private GravityWell _wellC;

	private const string SkinWeapons = "Weapons";

	private const string SkinCoffins = "Coffins";

	private const string SkinTrainees = "Trainees";

	private const string SkinExplosions = "Explosions";

	private Transform _targetTransform;

	private bool _003CLockX_003Ek__BackingField;

	private bool _003CLockY_003Ek__BackingField;

	public bool LockX
	{
		get
		{
			return _003CLockX_003Ek__BackingField;
		}
		set
		{
			_003CLockX_003Ek__BackingField = value;
		}
	}

	public bool LockY
	{
		get
		{
			return _003CLockY_003Ek__BackingField;
		}
		set
		{
			_003CLockY_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		EnsureSpriteRenderer();
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0127: Expected O, but got F4
		//IL_0134: Expected O, but got F4
		//IL_0159: Invalid comparison between F4 and I4
		//IL_0168: Invalid comparison between F4 and I4
		//IL_082f: Expected O, but got I4
		//IL_0837: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Expected O, but got Unknown
		//IL_00b0: Expected O, but got F4
		//IL_00bd: Expected O, but got F4
		//IL_00e2: Invalid comparison between F4 and I4
		//IL_00f1: Invalid comparison between F4 and I4
		//IL_09dd: Invalid comparison between O and F4
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0237: Expected O, but got F4
		//IL_025c: Invalid comparison between F4 and I4
		//IL_026b: Invalid comparison between F4 and I4
		//IL_0863: Expected O, but got I4
		//IL_086b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01dd: Invalid comparison between F4 and I4
		//IL_01ec: Invalid comparison between F4 and I4
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected Ref, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected Ref, but got Unknown
		//IL_03c9: Expected I8, but got I4
		//IL_0982: Expected O, but got I4
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected Ref, but got Unknown
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Expected Ref, but got Unknown
		//IL_04b3: Expected I8, but got I4
		//IL_0763: Expected I, but got O
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected Ref, but got Unknown
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Expected Ref, but got Unknown
		//IL_059d: Expected I8, but got I4
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Expected Ref, but got Unknown
		//IL_066b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Expected Ref, but got Unknown
		//IL_0687: Expected I8, but got I4
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
		Transform targetTransform = _targetTransform;
		bool flag2 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
		float ret2;
		Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out *(Vector3*)(&ret2));
		if (_follow)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 0.01f;
			float num2 = num * 0.01f;
			float num3 = num2 * 0.01f;
			bool flag3;
			bool flag4;
			bool flag5;
			if (ret2 > ret)
			{
				float num4 = ret + num3;
				float num5 = ret2 - num4;
				object obj = ret2 ^ num4;
				object obj2 = ret2 ^ num5;
				object obj3 = obj & obj2;
				flag3 = (nint)obj3 < 0;
				flag4 = num5 < 0f;
				flag5 = num5 == 0f;
			}
			else
			{
				float num4 = ret - num3;
				float num6 = num4 - ret2;
				object obj4 = num4 ^ ret2;
				object obj5 = num4 ^ num6;
				object obj6 = obj4 & obj5;
				flag3 = (nint)obj6 < 0;
				flag4 = num6 < 0f;
				flag5 = num6 == 0f;
			}
			bool flag6 = flag4 == flag3;
			object obj7 = !flag5;
			object obj8 = flag6 & obj7;
			if (obj8 == null)
			{
				float num4 = ret2;
			}
			float num7 = num2 * 0.01f;
			object obj9 = default(object);
			float num8 = default(float);
			bool flag7;
			bool flag8;
			bool flag9;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8))
			{
				float num9 = num7 + num8;
				float num10 = (float)obj9 - num9;
				object obj10 = obj9 ^ num9;
				object obj11 = obj9 ^ num10;
				object obj12 = obj10 & obj11;
				flag7 = (nint)obj12 < 0;
				flag8 = num10 < 0f;
				flag9 = num10 == 0f;
				float num11 = num8;
			}
			else
			{
				float num11 = num8 - num7;
				float num12 = num11 - (float)obj9;
				object obj13 = num11 ^ obj9;
				object obj14 = num11 ^ num12;
				object obj15 = obj13 & obj14;
				flag7 = (nint)obj15 < 0;
				flag8 = num12 < 0f;
				flag9 = num12 == 0f;
			}
			bool flag10 = flag8 == flag7;
			object obj16 = !flag9;
			object obj17 = flag10 & obj16;
			if (obj17 != null)
			{
				float num13 = ret2;
			}
		}
		else
		{
			float num13 = ret2;
		}
		if (_003CLockX_003Ek__BackingField)
		{
		}
		float value = default(float);
		if (!_003CLockY_003Ek__BackingField)
		{
			object cachedTransform2 = _cachedTransform;
			bool flag11 = (object)_cachedTransform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ rbx_v13 (System.Object)+10]");
			bool flag12 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ rbx_v13 (System.Object)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&ret));
			bool flag13 = (object)_groundFx == null;
			Transform transform = _groundFx.transform;
			bool flag14 = (object)transform == null;
			bool flag15 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			ParticleSystem currentEmitter = _currentEmitter1;
			if ((object)_currentEmitter1 == null || ((UnityEngine.Object)currentEmitter).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			string skin = _skin;
			object obj18 = "Coffins";
			if ((object)_skin != "Coffins")
			{
				if (_skin != null && "Coffins" != null)
				{
					int stringLength = skin._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rdx_v25+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(_skin + 20);
						ref byte second = ref *(byte*)("Coffins" + 20);
						ulong length = (ulong)(skin._stringLength + skin._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref second, length))
						{
							goto IL_06d6;
						}
					}
				}
				object obj19 = "Weapons";
				if ((object)_skin == "Weapons")
				{
					goto IL_06cb;
				}
				if (_skin != null && "Weapons" != null)
				{
					int stringLength2 = skin._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1622 @ rdx_v37+10]");
					if ((nint)stringLength2 == 0)
					{
						ref byte first2 = ref *(byte*)(_skin + 20);
						ref byte second2 = ref *(byte*)("Weapons" + 20);
						ulong length2 = (ulong)(skin._stringLength + skin._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first2, ref second2, length2))
						{
							goto IL_06cb;
						}
					}
				}
				object obj20 = "Trainees";
				if ((object)_skin == "Trainees")
				{
					goto IL_06c0;
				}
				if (_skin != null && "Trainees" != null)
				{
					int stringLength3 = skin._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1761 @ rdx_v41+10]");
					if ((nint)stringLength3 == 0)
					{
						ref byte first3 = ref *(byte*)(_skin + 20);
						ref byte second3 = ref *(byte*)("Trainees" + 20);
						ulong length3 = (ulong)(skin._stringLength + skin._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first3, ref second3, length3))
						{
							goto IL_06c0;
						}
					}
				}
				object obj21 = "Explosions";
				if ((object)_skin == "Explosions")
				{
					goto IL_06b5;
				}
				if (_skin != null && "Explosions" != null)
				{
					int stringLength4 = skin._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1507 @ rdx_v45+10]");
					if ((nint)stringLength4 == 0)
					{
						ref byte first4 = ref *(byte*)(_skin + 20);
						ref byte second4 = ref *(byte*)("Explosions" + 20);
						ulong length4 = (ulong)(skin._stringLength + skin._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first4, ref second4, length4))
						{
							goto IL_06b5;
						}
					}
				}
			}
			goto IL_06d6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-C0), the output could be wrong!");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 440 ConditionalJump @-1, v885 @ ZF_v32 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1028 Jump @-1 --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1092 Jump @-1 --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 98 ConditionalJump @-1, v278 @ ZF_v5 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 174 ConditionalJump @-1, v497 @ ZF_v19 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 353 ConditionalJump @-1, v805 @ ZF_v26 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 384 ConditionalJump @-1, v947 @ ZF_v28 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 426 ConditionalJump @-1, v886 @ ZF_v31 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 471 ConditionalJump @-1, v1313 @ ZF_v34 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
		IL_06d6:
		SetEmitterInCenter();
		goto IL_06e1;
		IL_06c0:
		SetEmitterOnTheRight();
		goto IL_06e1;
		IL_06e1:
		if (_hasHit || !_activateDamage)
		{
			return;
		}
		Bounds bounds = _groundFx.Bounds;
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		Vector3 _unity_self = default(Vector3);
		while (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			float2 float5 = ((ArcadeSprite)null).position;
			object obj22 = Bounds.Contains_Injected(ref *(Bounds*)(&_unity_self), ref *(Vector3*)(&value));
			if (obj22 != null)
			{
				nint num14 = (nint)arcadeSprite;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1988 @ r8_v13 (Il2CppClass<ArcadeSprite>)+5F8] (should have been resolved before IL gen)");
			}
		}
		return;
		IL_06b5:
		SetEmitterOnTheLeft();
		goto IL_06e1;
		IL_06cb:
		SetEmitterOnTheTop();
		goto IL_06e1;
	}

	public unsafe void Init(float w, float h, float damage, float durationMillis, float hitBoxDelayMillis, string skinType, bool follow, Transform targetTransform)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0814: Expected O, but got I
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_084c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0851: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_04c0: Expected O, but got I4
		//IL_08a4: Expected I, but got O
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Expected O, but got Unknown
		//IL_0939: Expected F4, but got I
		//IL_0939: Expected F4, but got I
		//IL_094b: Expected F4, but got I
		//IL_095d: Expected F4, but got I
		//IL_096f: Expected O, but got I
		//IL_05cb: Expected I4, but got F4
		//IL_063f: Expected I, but got O
		//IL_06ec: Expected O, but got I
		//IL_07bb: Expected O, but got I
		//IL_0987: Expected O, but got F4
		//IL_07f6: Expected F4, but got I4
		//IL_01aa->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_01e2->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0359->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0211->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0240->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0396->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_028e->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_03d3->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_02f3->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_031d->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0410->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_044d->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0479->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_04a6->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0613->IL07fb: Incompatible stack heights: 4 vs 0
		//IL_0684->IL07fb: Incompatible stack heights: 4 vs 0
		//IL_0662->IL0662: Incompatible stack heights: 5 vs 4
		object obj2 = default(object);
		object obj = obj2 - 47;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		_targetTransform = (Transform)0;
		PhaserSprite phaserSprite = setFrame("WhiteDot", "vfx");
		PhaserSprite phaserSprite2 = setVisible(visible: false);
		if ((object)phaserSprite2 != null)
		{
			PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.2f);
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
			_ = 0;
			if ((object)phaserSprite3 != null)
			{
				Color? tintColor = (Color?)(object)(obj - 73);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
				_ = 0;
				PhaserSprite phaserSprite4 = phaserSprite3.setTintFill(isEnabled: true, tintColor);
				MakeEmitters_Weapons();
				MakeEmitters_Coffins();
				MakeEmitters_Trainees();
				MakeEmitters_Explosions();
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj3 = obj - 89;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
					Transform groundFx = (Transform)(object)_groundFx;
					if ((object)_groundFx != null && ((UnityEngine.Object)groundFx).m_CachedPtr != (IntPtr)0)
					{
						goto IL_033f;
					}
					PhaserWorld instance = PhaserWorld.Instance;
					if ((object)instance != null)
					{
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite5 = instance.AddPhaserSprite(pos, "vfx", "WhiteDot");
						if ((object)phaserSprite5 != null)
						{
							PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
							if ((object)phaserSprite6 != null)
							{
								PhaserSprite phaserSprite7 = phaserSprite6.setVisible(visible: false);
								if ((object)phaserSprite7 != null)
								{
									PhaserSprite phaserSprite8 = phaserSprite7.setBlendMode(BlendMode.Add);
									_ = 0;
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
									_ = 0;
									if ((object)phaserSprite8 != null)
									{
										Color? tintColor2 = (Color?)(object)(obj - 73);
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
										_ = 0;
										PhaserSprite phaserSprite9 = phaserSprite8.setTintFill(isEnabled: true, tintColor2);
										if ((object)phaserSprite9 != null)
										{
											GameObject gameObject = phaserSprite9.gameObject;
											if ((object)gameObject != null)
											{
												((UnityEngine.Object)gameObject).SetName("GroundFx (DamagingZone)");
												_groundFx = phaserSprite9;
												goto IL_033f;
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
		goto IL_07fb;
		IL_07fb:
		throw new NullReferenceException();
		IL_033f:
		if ((object)_particlesManagerWeapons != null)
		{
			Transform transform2 = _particlesManagerWeapons.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
			if ((object)_particlesManagerCoffins != null)
			{
				Transform transform3 = _particlesManagerCoffins.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
				if ((object)_particlesManagerTrainees != null)
				{
					Transform transform4 = _particlesManagerTrainees.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
					if ((object)_particlesManagerExplosions != null)
					{
						Transform transform5 = _particlesManagerExplosions.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
						if ((object)_groundFx != null)
						{
							GameObject gameObject2 = _groundFx.gameObject;
							if ((object)gameObject2 != null)
							{
								gameObject2.SetActive(value: true);
								if ((object)_groundFx != null)
								{
									PhaserSprite phaserSprite10 = _groundFx.setScale(1f, (float?)(object)0);
									object cachedTransform = _cachedTransform;
									nint num = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1282 @ rax_v56 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num2 = 0;
									bool flag2 = (object)_cachedTransform == null;
									_ = Vector3.zeroVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1146 @ rax_v57 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rdi_v12 (System.Object)+10]");
									bool flag3 = (nint)0 == 0;
									object obj4 = obj - 73;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rdi_v12 (System.Object)+10]");
									Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj4);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
									float num4 = default(float);
									SetExplosionSize(num3, 0f, w, num4);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+57]");
									_durationMillis = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+5F]");
									_hitDelayMillis = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
									_skin = (string)0;
									_damage = damage;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
									_follow = false;
									bool flag4 = (object)_groundFx == null;
									PhaserSprite phaserSprite11 = _groundFx.setDepth(1);
									_003CLockX_003Ek__BackingField = false;
									_activateDamage = false;
									if (_hitboxTimer != null)
									{
										_hitboxTimer.Cancel();
									}
									Action onComplete = delegate
									{
										_hasHit = false;
									};
									float num5 = _hitDelayMillis * 0.001f;
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType timerType = default(TimerType);
									Timer hitboxTimer = Timers.Register(num5, onComplete, null, isLooped: true, (byte)(int)num4 != 0, autoDestroyOwner, repeat, timerType, isOnlineTimer: false, canPause: false);
									_hitboxTimer = hitboxTimer;
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										if ((object)_groundFx != null)
										{
											nint num6 = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj5 = default(object);
											bool flag5 = obj5 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											tweenConfig.targets = array;
											_ = 0;
											tweenConfig.yoyo = true;
											tweenConfig.repeat = 2;
											tweenConfig.duration = 300f;
											_ = 1056964608;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
											tweenConfig.alpha = (float?)(object)0;
											TweenCallback onStart = delegate
											{
												PhaserSprite phaserSprite12 = _groundFx.setVisible(visible: true);
											};
											tweenConfig.onStart = onStart;
											TweenCallback onComplete2 = Shoot;
											tweenConfig.onComplete = onComplete2;
											MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
											if (_despawnTimer != null)
											{
												_despawnTimer.Cancel();
											}
											_despawnTimer = null;
											SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
											_ = 0;
											_ = 1063675494;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
											soundConfig.Volume = (float?)(object)0;
											soundConfig.Rate = 1f;
											object obj6 = UnityEngine.Random.value;
											float detune = num5 * 500f;
											soundConfig.Rate = 1f;
											soundConfig.Detune = detune;
											_ = 0;
											_ = 0;
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, (float)timerType);
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
		goto IL_07fb;
	}

	public void TriggerDespawnDelayed()
	{
		PhaserSprite phaserSprite = setVisible(visible: false);
		GameObject gameObject = _groundFx.gameObject;
		gameObject.SetActive(value: false);
		RenderingExtensions.StopEmitting(_pfxEmitterW1);
		RenderingExtensions.StopEmitting(_pfxEmitterW2);
		RenderingExtensions.StopEmitting(_pfxEmitterC1);
		RenderingExtensions.StopEmitting(_pfxEmitterC2);
		RenderingExtensions.StopEmitting(_pfxEmitterT1);
		RenderingExtensions.StopEmitting(_pfxEmitterT2);
		RenderingExtensions.StopEmitting(_pfxEmitterE1);
		RenderingExtensions.StopEmitting(_pfxEmitterE2);
		float remainingLifetime = RenderingExtensions.GetRemainingLifetime(_currentEmitter1);
		float remainingLifetime2 = RenderingExtensions.GetRemainingLifetime(_currentEmitter2);
		bool flag = !(remainingLifetime < remainingLifetime2);
		float duration = remainingLifetime;
		if (!flag)
		{
			duration = remainingLifetime2;
		}
		Action onComplete = Despawn;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void Despawn()
	{
		GameObject obj = base.gameObject;
		base._ParentPool.Release(obj);
		_activateDamage = false;
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		PhaserSprite phaserSprite = setVisible(visible: false);
		GameObject gameObject = _groundFx.gameObject;
		gameObject.SetActive(value: false);
		Transform transform = _particlesManagerWeapons.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
		Transform transform2 = _particlesManagerCoffins.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
		Transform transform3 = _particlesManagerTrainees.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
		Transform transform4 = _particlesManagerExplosions.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
	}

	private void SetExplosionSize(float x, float y, float width, float height)
	{
		Transform transform = _groundFx.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		Transform transform2 = base.transform;
		bool flag3 = (object)transform2 == null;
		bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value3 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value3);
	}

	private void SetExplosionDamage(float damage, float durationMillis, float hitDelayMillis)
	{
		_damage = damage;
		_durationMillis = durationMillis;
		_hitDelayMillis = hitDelayMillis;
	}

	private unsafe void Shoot()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0b1d: Expected O, but got I
		//IL_0b39: Expected O, but got F4
		//IL_0bab: Expected O, but got Ref
		//IL_0bcd: Expected O, but got I4
		//IL_00e3: Expected I, but got O
		//IL_0137: Expected I, but got O
		//IL_01c7: Expected O, but got I
		//IL_01f5: Expected O, but got I
		//IL_0224: Expected O, but got I
		//IL_0c26: Expected O, but got Ref
		//IL_0c62: Expected I8, but got I
		//IL_02d3: Expected I8, but got I
		//IL_02fc: Expected I8, but got I
		//IL_0333: Expected I8, but got I
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected Ref, but got Unknown
		//IL_036d: Expected I8, but got I4
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected Ref, but got Unknown
		//IL_0a8d: Expected O, but got I
		//IL_0ab6: Expected I4, but got F4
		//IL_0d01: Expected O, but got Ref
		//IL_060b: Expected I4, but got F4
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Expected Ref, but got Unknown
		//IL_0481: Expected I8, but got I4
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected Ref, but got Unknown
		//IL_086d: Expected F4, but got I
		//IL_0988: Expected O, but got I
		//IL_09c1: Expected I4, but got F4
		//IL_0899: Expected I4, but got F4
		//IL_0631: Expected I4, but got F4
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected Ref, but got Unknown
		//IL_0590: Expected I8, but got I4
		//IL_059a: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Expected Ref, but got Unknown
		//IL_08a4: Expected O, but got I
		//IL_0764: Expected F4, but got I
		//IL_0665: Expected I4, but got F4
		//IL_0790: Expected I4, but got F4
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Expected Ref, but got Unknown
		//IL_069a: Expected I8, but got I4
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a9: Expected Ref, but got Unknown
		//IL_06d1: Expected I4, but got F4
		//IL_079b: Expected O, but got I
		//IL_00b7->IL0ae6: Incompatible stack heights: 1 vs 0
		//IL_017c->IL0ae6: Incompatible stack heights: 1 vs 0
		//IL_0106->IL0106: Incompatible stack heights: 2 vs 1
		//IL_015a->IL015a: Incompatible stack heights: 2 vs 1
		//IL_02ad->IL0ae6: Incompatible stack heights: 1 vs 0
		//IL_0a32->IL0ae6: Incompatible stack heights: 2 vs 0
		//IL_092d->IL0ae6: Incompatible stack heights: 2 vs 0
		//IL_081a->IL0ae6: Incompatible stack heights: 2 vs 0
		//IL_0614->IL0c75: Incompatible stack heights: 2 vs 4
		//IL_0ad6->IL0ad6: Incompatible stack heights: 5 vs 4
		//IL_0740->IL0ae6: Incompatible stack heights: 2 vs 0
		//IL_063a->IL0c75: Incompatible stack heights: 2 vs 4
		//IL_066e->IL0c75: Incompatible stack heights: 2 vs 4
		//IL_09e7->IL09e7: Incompatible stack heights: 5 vs 2
		//IL_06da->IL0c75: Incompatible stack heights: 2 vs 4
		//IL_08e2->IL08e2: Incompatible stack heights: 5 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1056964608;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		soundConfig.Volume = (float?)(object)0;
		soundConfig.Rate = 1f;
		object obj3 = UnityEngine.Random.value;
		object obj4 = default(object);
		float num = (float)obj4 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 500f;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, num2);
		ulong num6;
		ParticleSystem particleSystem2;
		ulong num7;
		bool useRealTime;
		ParticleSystem particleSystem;
		ulong num5;
		if ((object)_groundFx != null)
		{
			Transform transform = _groundFx.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = (byte)(~(((SoundManager.SoundConfig)(object)transform).Mute ? 1u : 0u)) != 0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
				Transform.get_localScale_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform).Mute ? 1 : 0), out *(Vector3*)obj5);
				PhaserSprite phaserSprite = setScale(0f, (float?)(object)0);
				PhaserSprite phaserSprite2 = setAlpha(0f);
				PhaserSprite phaserSprite3 = setVisible(visible: true);
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[2];
				if (array != null)
				{
					if ((object)_cachedTransform != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj6 = default(object);
						bool flag2 = obj6 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)((PhaserSprite)this)._spriteRenderer != null)
					{
						nint num4 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj7 = default(object);
						bool flag3 = obj7 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
						_ = 0;
						_ = 1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
						tweenConfig.scaleX = (float?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2B]");
						_ = 0;
						_ = 1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
						tweenConfig.scaleY = (float?)(object)0;
						tweenConfig.duration = 500f;
						_ = 1036831949;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
						tweenConfig.alpha = (float?)(object)0;
						TweenCallback onStart = delegate
						{
							PhaserSprite phaserSprite4 = setVisible(visible: true);
							PhaserSprite phaserSprite5 = setAlpha(0f);
						};
						tweenConfig.onStart = onStart;
						TweenCallback onComplete = delegate
						{
							_activateDamage = true;
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							_ = 0;
							_ = 0;
							bool flag4 = (byte)(~(((SoundManager.SoundConfig)(object)transform2).Mute ? 1u : 0u)) != 0;
							object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
							Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform2).Mute ? 1 : 0), out *(Vector3*)obj8);
							object obj9 = "Weapons";
							string skin = _skin;
							bool flag5 = (object)_skin == "Weapons";
							num5 = 0uL;
							particleSystem = null;
							if (!flag5)
							{
								bool flag6 = _skin == null;
								num6 = 0uL;
								particleSystem2 = null;
								if (!flag6)
								{
									bool flag7 = "Weapons" == null;
									num6 = 0uL;
									particleSystem2 = null;
									if (!flag7)
									{
										int stringLength = skin._stringLength;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1566 @ rdx_v54+10]");
										bool flag8 = (nint)stringLength != 0;
										num6 = 0uL;
										particleSystem2 = null;
										if (!flag8)
										{
											ref byte first = ref *(byte*)(_skin + 20);
											num6 = (ulong)(skin._stringLength + skin._stringLength);
											bool flag9 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Weapons" + 20), num6);
											particleSystem2 = null;
											num5 = num6;
											particleSystem = null;
											if (flag9)
											{
												goto IL_09ec;
											}
										}
									}
								}
								object obj10 = "Coffins";
								if ((object)_skin != "Coffins")
								{
									bool flag10 = _skin == null;
									num5 = num6;
									if (!flag10)
									{
										bool flag11 = "Coffins" == null;
										num5 = num6;
										if (!flag11)
										{
											int stringLength2 = skin._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1715 @ rdx_v75+10]");
											bool flag12 = (nint)stringLength2 != 0;
											num5 = num6;
											if (!flag12)
											{
												ref byte first2 = ref *(byte*)(_skin + 20);
												num5 = (ulong)(skin._stringLength + skin._stringLength);
												bool flag13 = System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Coffins" + 20), num5);
												num6 = num5;
												particleSystem2 = null;
												if (flag13)
												{
													goto IL_08e7;
												}
											}
										}
									}
									object obj11 = "Trainees";
									if ((object)_skin != "Trainees")
									{
										bool flag14 = _skin == null;
										num7 = num5;
										if (!flag14)
										{
											bool flag15 = "Trainees" == null;
											num7 = num5;
											if (!flag15)
											{
												int stringLength3 = skin._stringLength;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1882 @ rdx_v87+10]");
												bool flag16 = (nint)stringLength3 != 0;
												num7 = num5;
												if (!flag16)
												{
													ref byte first3 = ref *(byte*)(_skin + 20);
													num7 = (ulong)(skin._stringLength + skin._stringLength);
													bool flag17 = System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("Trainees" + 20), num7);
													num5 = num7;
													if (flag17)
													{
														goto IL_07be;
													}
												}
											}
										}
										object obj12 = "Explosions";
										if ((object)_skin != "Explosions")
										{
											bool flag18 = _skin == null;
											useRealTime = (byte)(int)num2 != 0;
											if (!flag18)
											{
												bool flag19 = "Explosions" == null;
												useRealTime = (byte)(int)num2 != 0;
												if (!flag19)
												{
													int stringLength4 = skin._stringLength;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2050 @ rdx_v93+10]");
													bool flag20 = (nint)stringLength4 != 0;
													useRealTime = (byte)(int)num2 != 0;
													if (!flag20)
													{
														ref byte first4 = ref *(byte*)(_skin + 20);
														num7 = (ulong)(skin._stringLength + skin._stringLength);
														bool flag21 = System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("Explosions" + 20), num7);
														bool flag22 = !flag21;
														useRealTime = (byte)(int)num2 != 0;
														if (!flag22)
														{
															goto IL_06e4;
														}
													}
												}
											}
											goto IL_0c75;
										}
										goto IL_06e4;
									}
									goto IL_07be;
								}
								goto IL_08e7;
							}
							goto IL_09ec;
						}
					}
				}
			}
		}
		goto IL_0ae6;
		IL_0ae6:
		throw new NullReferenceException();
		IL_08e7:
		RenderingExtensions.Start(_pfxEmitterC1);
		RenderingExtensions.Start(_pfxEmitterC2);
		_currentEmitter1 = _pfxEmitterC1;
		_currentEmitter2 = _pfxEmitterC2;
		if ((object)_wellC == null)
		{
			goto IL_0ae6;
		}
		Transform transform3 = _wellC.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B]");
		float num8 = 0f + 0.32f;
		bool flag23 = (object)transform3 == null;
		bool num9 = flag23;
		_ = 0;
		bool mute = ((SoundManager.SoundConfig)(object)transform3).Mute;
		bool flag24 = (byte)(~(((SoundManager.SoundConfig)(object)transform3).Mute ? 1u : 0u)) != 0;
		bool num10 = flag24;
		object obj13 = 0;
		bool flag25 = (nint)0 != 0;
		object obj15 = default(object);
		object obj14 = obj15;
		num5 = num6;
		particleSystem = particleSystem2;
		float num11 = 150f;
		useRealTime = (byte)(int)num2 != 0;
		if (!flag25)
		{
			bool flag26 = (nint)0 == 0;
			goto IL_09ec;
		}
		goto IL_0cf3;
		IL_0cf3:
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2564 @ rax_v91 (should have been resolved before IL gen)");
		goto IL_0c75;
		IL_0c75:
		Action onComplete2 = delegate
		{
			_activateDamage = false;
			TriggerDespawnDelayed();
		};
		float duration = _durationMillis * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		goto IL_0ad6;
		IL_09ec:
		RenderingExtensions.Start(_pfxEmitterW1);
		RenderingExtensions.Start(_pfxEmitterW2);
		_currentEmitter1 = _pfxEmitterW1;
		_currentEmitter2 = _pfxEmitterW2;
		if ((object)_wellW == null)
		{
			goto IL_0ae6;
		}
		Transform transform4 = _wellW.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B]");
		num8 = 0f + 0.32f;
		bool flag27 = (object)transform4 == null;
		num9 = flag27;
		_ = 0;
		mute = ((SoundManager.SoundConfig)(object)transform4).Mute;
		bool flag28 = (byte)(~(((SoundManager.SoundConfig)(object)transform4).Mute ? 1u : 0u)) != 0;
		num10 = flag28;
		obj13 = 0;
		bool flag29 = (nint)0 != 0;
		obj14 = obj15;
		num11 = 150f;
		useRealTime = (byte)(int)num2 != 0;
		if (!flag29)
		{
			bool flag30 = (nint)0 == 0;
			goto IL_0ad6;
		}
		goto IL_0cf3;
		IL_0ad6:
		_despawnTimer = despawnTimer;
		return;
		IL_07be:
		RenderingExtensions.Start(_pfxEmitterT1);
		RenderingExtensions.Start(_pfxEmitterT2);
		_currentEmitter1 = _pfxEmitterT1;
		particleSystem = _pfxEmitterT2;
		_currentEmitter2 = _pfxEmitterT2;
		if ((object)_wellT == null)
		{
			goto IL_0ae6;
		}
		Transform transform5 = _wellT.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		float num12 = 0f * 0.4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		num8 = 0f - num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B]");
		num11 = 0f;
		bool flag31 = (object)transform5 == null;
		num9 = flag31;
		_ = 0;
		useRealTime = (byte)(int)num2 != 0;
		mute = ((SoundManager.SoundConfig)(object)transform5).Mute;
		bool flag32 = (byte)(~(((SoundManager.SoundConfig)(object)transform5).Mute ? 1u : 0u)) != 0;
		num10 = flag32;
		obj13 = 0;
		bool flag33 = (nint)0 != 0;
		obj14 = obj15;
		if (!flag33)
		{
			bool flag34 = (nint)0 == 0;
			goto IL_08e7;
		}
		goto IL_0cf3;
		IL_06e4:
		RenderingExtensions.Start(_pfxEmitterE1);
		RenderingExtensions.Start(_pfxEmitterE2);
		_currentEmitter1 = _pfxEmitterE1;
		particleSystem = _pfxEmitterE2;
		_currentEmitter2 = _pfxEmitterE2;
		if ((object)_wellE == null)
		{
			goto IL_0ae6;
		}
		Transform transform6 = _wellE.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B]");
		num8 = 0f;
		bool flag35 = (object)transform6 == null;
		num9 = flag35;
		_ = 0;
		useRealTime = (byte)(int)num2 != 0;
		mute = ((SoundManager.SoundConfig)(object)transform6).Mute;
		bool flag36 = (byte)(~(((SoundManager.SoundConfig)(object)transform6).Mute ? 1u : 0u)) != 0;
		num10 = flag36;
		obj13 = 0;
		obj14 = obj15;
		num5 = num7;
		num11 = 150f;
		goto IL_0cf3;
	}

	private float Approach(float start, float end, float shift)
	{
		if (end > start)
		{
			float num = start + shift;
			if (num > end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start - shift;
		if (num2 < end)
		{
			num2 = end;
		}
		return num2;
	}

	private void SetEmitterInCenter()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_currentEmitter1 == null;
		Transform transform = _currentEmitter1.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag5 = (object)_currentEmitter2 == null;
		Transform transform2 = _currentEmitter2.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		SetEmitterBounds();
	}

	private unsafe void SetEmitterOnTheRight()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
		Bounds bounds = _groundFx.Bounds;
		bool flag2 = (object)_currentEmitter1 == null;
		Transform transform = _currentEmitter1.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&ret));
		bool flag5 = (object)_currentEmitter2 == null;
		Transform transform2 = _currentEmitter2.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
		SetEmitterBounds();
	}

	private unsafe void SetEmitterOnTheLeft()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
		Bounds bounds = _groundFx.Bounds;
		bool flag2 = (object)_currentEmitter1 == null;
		Transform transform = _currentEmitter1.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&ret));
		bool flag5 = (object)_currentEmitter2 == null;
		Transform transform2 = _currentEmitter2.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
		SetEmitterBounds();
	}

	private void SetEmitterOnTheTop()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
		Bounds bounds = _groundFx.Bounds;
		bool flag2 = (object)_currentEmitter1 == null;
		Transform transform = _currentEmitter1.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
		bool flag5 = (object)_currentEmitter2 == null;
		Transform transform2 = _currentEmitter2.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		SetEmitterBounds();
	}

	private void SetEmitterBounds()
	{
		//IL_0061: Expected O, but got I4
		//IL_00a5: Expected O, but got I4
		PfxData component = _currentEmitter1.GetComponent<PfxData>();
		PfxData component2 = _currentEmitter2.GetComponent<PfxData>();
		ParticleSystemConfig particleSystemConfig = component._003CCurrentConfig_003Ek__BackingField;
		Bounds bounds = _groundFx.Bounds;
		particleSystemConfig._boundsWorld = (Bounds?)(object)1;
		_ = 0;
		ParticleSystemConfig particleSystemConfig2 = component2._003CCurrentConfig_003Ek__BackingField;
		Bounds bounds2 = _groundFx.Bounds;
		particleSystemConfig2._boundsWorld = (Bounds?)(object)1;
		_ = 0;
		RenderingExtensions.SetCollisionBoundsWorld(_currentEmitter1, component._003CCurrentConfig_003Ek__BackingField);
		RenderingExtensions.SetCollisionBoundsWorld(_currentEmitter2, component2._003CCurrentConfig_003Ek__BackingField);
	}

	private void MakeParticleSystems()
	{
		MakeEmitters_Weapons();
		MakeEmitters_Coffins();
		MakeEmitters_Trainees();
		MakeEmitters_Explosions();
	}

	private unsafe void MakeEmitters_Weapons()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0d1e: Expected O, but got I4
		//IL_0d44: Expected O, but got I4
		//IL_0d6b: Expected O, but got I4
		//IL_0d84: Expected O, but got Ref
		//IL_0d9e: Expected native int or pointer, but got O
		//IL_0db8: Expected O, but got I
		//IL_0dd8: Expected O, but got Ref
		//IL_0df2: Expected native int or pointer, but got O
		//IL_189e: Expected O, but got I4
		//IL_0e0a: Expected O, but got Ref
		//IL_0e31: Expected O, but got I
		//IL_0e4b: Expected native int or pointer, but got O
		//IL_18d0: Expected O, but got I
		//IL_0e9c: Expected O, but got I
		//IL_190a: Expected O, but got I
		//IL_0edc: Expected O, but got I
		//IL_0ef7: Expected O, but got I
		//IL_0f12: Expected O, but got I
		//IL_0f26: Expected O, but got I4
		//IL_0f3b: Expected O, but got I
		//IL_13d5: Expected O, but got I4
		//IL_13fb: Expected O, but got I4
		//IL_1422: Expected O, but got I4
		//IL_1436: Expected O, but got Ref
		//IL_1450: Expected native int or pointer, but got O
		//IL_146f: Expected O, but got I
		//IL_148a: Expected O, but got Ref
		//IL_14a4: Expected native int or pointer, but got O
		//IL_14e9: Expected O, but got I
		//IL_1516: Expected O, but got Ref
		//IL_153d: Expected O, but got I
		//IL_1557: Expected native int or pointer, but got O
		//IL_1565: Expected O, but got I4
		//IL_158d: Expected O, but got I4
		//IL_15db: Expected O, but got I
		//IL_161a: Expected O, but got I
		//IL_1654: Expected O, but got I
		//IL_166f: Expected O, but got I
		//IL_168a: Expected O, but got I
		//IL_169e: Expected O, but got I4
		//IL_16b3: Expected O, but got I
		//IL_1782: Expected O, but got I
		//IL_1797: Expected O, but got I
		//IL_00db->IL1808: Incompatible stack heights: 1 vs 0
		//IL_012a->IL1808: Incompatible stack heights: 1 vs 0
		//IL_01de->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0292->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0346->IL1808: Incompatible stack heights: 1 vs 0
		//IL_03fa->IL1808: Incompatible stack heights: 1 vs 0
		//IL_04ae->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0562->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0616->IL1808: Incompatible stack heights: 1 vs 0
		//IL_06ca->IL1808: Incompatible stack heights: 1 vs 0
		//IL_077e->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0832->IL1808: Incompatible stack heights: 1 vs 0
		//IL_08e6->IL1808: Incompatible stack heights: 1 vs 0
		//IL_099a->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0a4e->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0b02->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0bb6->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0c6a->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0cec->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0f7a->IL1808: Incompatible stack heights: 1 vs 0
		//IL_0fe2->IL1808: Incompatible stack heights: 1 vs 0
		//IL_1031->IL1808: Incompatible stack heights: 1 vs 0
		//IL_10e5->IL1808: Incompatible stack heights: 1 vs 0
		//IL_1199->IL1808: Incompatible stack heights: 1 vs 0
		//IL_124d->IL1808: Incompatible stack heights: 1 vs 0
		//IL_13a3->IL1808: Incompatible stack heights: 1 vs 0
		//IL_16f2->IL1808: Incompatible stack heights: 1 vs 0
		//IL_1757->IL1808: Incompatible stack heights: 1 vs 0
		//IL_17db->IL1808: Incompatible stack heights: 1 vs 0
		//IL_1808->IL1842: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleEmitterManager particlesManagerWeapons = _particlesManagerWeapons;
		if ((object)_particlesManagerWeapons != null && ((UnityEngine.Object)particlesManagerWeapons).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = CreateEmitterGameObject("ParticlesManagerWeapons");
		if ((object)gameObject != null)
		{
			ParticleEmitterManager particlesManagerWeapons2 = gameObject.AddComponent<ParticleEmitterManager>();
			_particlesManagerWeapons = particlesManagerWeapons2;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
				List<string> list = new List<string>();
				list._002Ector();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"Axe.png");
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
								((List<object>)(object)list).AddWithResize((object)"Cat.png");
							}
							else
							{
								int size2 = list._size + 1;
								list._size = size2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version3 = list._version + 1;
							list._version = version3;
							string[] items3 = list._items;
							if (list._items != null)
							{
								if (list._size >= items3.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"Cross.png");
								}
								else
								{
									int size3 = list._size + 1;
									list._size = size3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								int version4 = list._version + 1;
								list._version = version4;
								string[] items4 = list._items;
								if (list._items != null)
								{
									if (list._size >= items4.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"Diamond2.png");
									}
									else
									{
										int size4 = list._size + 1;
										list._size = size4;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version5 = list._version + 1;
									list._version = version5;
									string[] items5 = list._items;
									if (list._items != null)
									{
										if (list._size >= items5.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"Garlic.png");
										}
										else
										{
											int size5 = list._size + 1;
											list._size = size5;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version6 = list._version + 1;
										list._version = version6;
										string[] items6 = list._items;
										if (list._items != null)
										{
											if (list._size >= items6.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"Guns.png");
											}
											else
											{
												int size6 = list._size + 1;
												list._size = size6;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											int version7 = list._version + 1;
											list._version = version7;
											string[] items7 = list._items;
											if (list._items != null)
											{
												if (list._size >= items7.Length)
												{
													((List<object>)(object)list).AddWithResize((object)"Guns2.png");
												}
												else
												{
													int size7 = list._size + 1;
													list._size = size7;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version8 = list._version + 1;
												list._version = version8;
												string[] items8 = list._items;
												if (list._items != null)
												{
													if (list._size >= items8.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"HolyBook.png");
													}
													else
													{
														int size8 = list._size + 1;
														list._size = size8;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													int version9 = list._version + 1;
													list._version = version9;
													string[] items9 = list._items;
													if (list._items != null)
													{
														if (list._size >= items9.Length)
														{
															((List<object>)(object)list).AddWithResize((object)"HolyWater.png");
														}
														else
														{
															int size9 = list._size + 1;
															list._size = size9;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version10 = list._version + 1;
														list._version = version10;
														string[] items10 = list._items;
														if (list._items != null)
														{
															if (list._size >= items10.Length)
															{
																((List<object>)(object)list).AddWithResize((object)"Knife.png");
															}
															else
															{
																int size10 = list._size + 1;
																list._size = size10;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version11 = list._version + 1;
															list._version = version11;
															string[] items11 = list._items;
															if (list._items != null)
															{
																if (list._size >= items11.Length)
																{
																	((List<object>)(object)list).AddWithResize((object)"LighningRing.png");
																}
																else
																{
																	int size11 = list._size + 1;
																	list._size = size11;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																int version12 = list._version + 1;
																list._version = version12;
																string[] items12 = list._items;
																if (list._items != null)
																{
																	if (list._size >= items12.Length)
																	{
																		((List<object>)(object)list).AddWithResize((object)"Pentagram.png");
																	}
																	else
																	{
																		int size12 = list._size + 1;
																		list._size = size12;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	int version13 = list._version + 1;
																	list._version = version13;
																	string[] items13 = list._items;
																	if (list._items != null)
																	{
																		if (list._size >= items13.Length)
																		{
																			((List<object>)(object)list).AddWithResize((object)"Song.png");
																		}
																		else
																		{
																			int size13 = list._size + 1;
																			list._size = size13;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		}
																		int version14 = list._version + 1;
																		list._version = version14;
																		string[] items14 = list._items;
																		if (list._items != null)
																		{
																			if (list._size >= items14.Length)
																			{
																				((List<object>)(object)list).AddWithResize((object)"trapano.png");
																			}
																			else
																			{
																				int size14 = list._size + 1;
																				list._size = size14;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			}
																			int version15 = list._version + 1;
																			list._version = version15;
																			string[] items15 = list._items;
																			if (list._items != null)
																			{
																				if (list._size >= items15.Length)
																				{
																					((List<object>)(object)list).AddWithResize((object)"WandHoly.png");
																				}
																				else
																				{
																					int size15 = list._size + 1;
																					list._size = size15;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				int version16 = list._version + 1;
																				list._version = version16;
																				string[] items16 = list._items;
																				if (list._items != null)
																				{
																					if (list._size >= items16.Length)
																					{
																						((List<object>)(object)list).AddWithResize((object)"WandFire.png");
																					}
																					else
																					{
																						int size16 = list._size + 1;
																						list._size = size16;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					}
																					int version17 = list._version + 1;
																					list._version = version17;
																					string[] items17 = list._items;
																					if (list._items != null)
																					{
																						if (list._size >= items17.Length)
																						{
																							((List<object>)(object)list).AddWithResize((object)"Whip.png");
																						}
																						else
																						{
																							int size17 = list._size + 1;
																							list._size = size17;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						}
																						if (particleSystemConfig != null)
																						{
																							particleSystemConfig._frame = list;
																							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
																							particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							float constant = default(float);
																							minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
																							particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
																							particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(70f, 110f));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
																							particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(600f, 800f));
																							particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
																							_ = 0;
																							_ = 1;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																							particleSystemConfig._quantity = (int?)(object)0;
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(2f, 0f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
																							particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
																							_ = 0;
																							_ = 0;
																							_ = 1065353216;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																							particleSystemConfig._frequency = (float?)(object)0;
																							minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
																							_ = 0;
																							_ = 0;
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
																							particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
																							_ = 0;
																							_ = 257;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																							particleSystemConfig._collideTop = (bool?)(object)0;
																							_ = 257;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																							particleSystemConfig._collideBottom = (bool?)(object)0;
																							_ = 257;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																							particleSystemConfig._collideLeft = (bool?)(object)0;
																							_ = 257;
																							particleSystemConfig._bounds = (Rect?)(object)1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																							particleSystemConfig._collideRight = (bool?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
																							_ = 0;
																							particleSystemConfig._on = false;
																							if ((object)_particlesManagerWeapons != null)
																							{
																								ParticleSystem pfxEmitterW = _particlesManagerWeapons.CreateEmitter(particleSystemConfig, null, "PfxEmitterW2");
																								_pfxEmitterW2 = pfxEmitterW;
																								ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("items");
																								List<string> list2 = new List<string>();
																								if (list2 != null)
																								{
																									int version18 = list2._version + 1;
																									list2._version = version18;
																									string[] items18 = list2._items;
																									if (list2._items != null)
																									{
																										if (list2._size >= items18.Length)
																										{
																											((List<object>)(object)list2).AddWithResize((object)"Axe.png");
																										}
																										else
																										{
																											int size18 = list2._size + 1;
																											list2._size = size18;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										}
																										int version19 = list2._version + 1;
																										list2._version = version19;
																										string[] items19 = list2._items;
																										if (list2._items != null)
																										{
																											if (list2._size >= items19.Length)
																											{
																												((List<object>)(object)list2).AddWithResize((object)"Cat.png");
																											}
																											else
																											{
																												int size19 = list2._size + 1;
																												list2._size = size19;
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																											}
																											int version20 = list2._version + 1;
																											list2._version = version20;
																											string[] items20 = list2._items;
																											if (list2._items != null)
																											{
																												if (list2._size >= items20.Length)
																												{
																													((List<object>)(object)list2).AddWithResize((object)"Cross.png");
																												}
																												else
																												{
																													int size20 = list2._size + 1;
																													list2._size = size20;
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																												}
																												int version21 = list2._version + 1;
																												list2._version = version21;
																												string[] items21 = list2._items;
																												if (list2._items != null)
																												{
																													if (list2._size >= items21.Length)
																													{
																														((List<object>)(object)list2).AddWithResize((object)"Diamond2.png");
																													}
																													else
																													{
																														int size21 = list2._size + 1;
																														list2._size = size21;
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																													}
																													list2.Add("Garlic.png");
																													list2.Add("Guns.png");
																													list2.Add("Guns2.png");
																													list2.Add("HolyBook.png");
																													list2.Add("HolyWater.png");
																													list2.Add("Knife.png");
																													list2.Add("LighningRing.png");
																													list2.Add("Pentagram.png");
																													list2.Add("Song.png");
																													list2.Add("trapano.png");
																													list2.Add("WandHoly.png");
																													list2.Add("WandFire.png");
																													list2.Add("Whip.png");
																													if (particleSystemConfig2 != null)
																													{
																														particleSystemConfig2._frame = list2;
																														minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
																														particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
																														_ = 0;
																														minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
																														particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
																														_ = 0;
																														minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
																														particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																														_ = 0;
																														ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
																														_ = 0;
																														_ = 0;
																														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(70f, 110f));
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
																														particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
																														_ = 0;
																														ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
																														_ = 0;
																														_ = 0;
																														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(400f, 600f));
																														_ = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
																														_ = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
																														_ = 0;
																														_ = 1;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
																														particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
																														_ = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																														_ = 0;
																														ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
																														_ = 0;
																														_ = 2;
																														_ = 1;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																														particleSystemConfig2._quantity = (int?)(object)0;
																														_ = 0;
																														_ = 0;
																														System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(2f, 0f));
																														obj = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
																														_ = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
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
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																														particleSystemConfig2._frequency = (float?)(object)0;
																														minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
																														_ = 0;
																														_ = 0;
																														_ = 1;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
																														particleSystemConfig2._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
																														_ = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
																														_ = 0;
																														_ = 257;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																														particleSystemConfig2._collideTop = (bool?)(object)0;
																														_ = 257;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																														particleSystemConfig2._collideBottom = (bool?)(object)0;
																														_ = 257;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																														particleSystemConfig2._collideLeft = (bool?)(object)0;
																														_ = 257;
																														particleSystemConfig2._bounds = (Rect?)(object)1;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																														particleSystemConfig2._collideRight = (bool?)(object)0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
																														_ = 0;
																														particleSystemConfig2._on = false;
																														if ((object)_particlesManagerWeapons != null)
																														{
																															ParticleSystem pfxEmitterW2 = _particlesManagerWeapons.CreateEmitter(particleSystemConfig2, null, "PfxEmitterW1");
																															_pfxEmitterW1 = pfxEmitterW2;
																															GravityWellConfig gravityWellConfig = new GravityWellConfig();
																															_ = 0;
																															_ = 1;
																															if (gravityWellConfig != null)
																															{
																																_ = 0;
																																_ = 1;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																																gravityWellConfig._y = (float?)(object)0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																																gravityWellConfig._x = (float?)(object)0;
																																gravityWellConfig._power = 1f;
																																gravityWellConfig._epsilon = 50f;
																																gravityWellConfig._gravity = 20f;
																																if ((object)_particlesManagerWeapons != null)
																																{
																																	GravityWell wellW = _particlesManagerWeapons.CreateGravityWell(gravityWellConfig, null, "WellW");
																																	_wellW = wellW;
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void MakeEmitters_Coffins()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0292: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_02df: Expected O, but got I4
		//IL_02f8: Expected O, but got Ref
		//IL_0312: Expected native int or pointer, but got O
		//IL_032c: Expected O, but got I
		//IL_034c: Expected O, but got Ref
		//IL_0366: Expected native int or pointer, but got O
		//IL_0380: Expected O, but got I
		//IL_03a0: Expected O, but got Ref
		//IL_03ba: Expected native int or pointer, but got O
		//IL_0be0: Expected O, but got I4
		//IL_03d2: Expected O, but got Ref
		//IL_03f9: Expected O, but got I
		//IL_0413: Expected native int or pointer, but got O
		//IL_0c12: Expected O, but got I
		//IL_0464: Expected O, but got I
		//IL_0c4c: Expected O, but got I
		//IL_04a4: Expected O, but got I
		//IL_04bf: Expected O, but got I
		//IL_04da: Expected O, but got I
		//IL_04ee: Expected O, but got I4
		//IL_0503: Expected O, but got I
		//IL_0761: Expected O, but got I4
		//IL_0787: Expected O, but got I4
		//IL_07ae: Expected O, but got I4
		//IL_07c7: Expected O, but got Ref
		//IL_07e1: Expected native int or pointer, but got O
		//IL_07fb: Expected O, but got I
		//IL_081b: Expected O, but got Ref
		//IL_0835: Expected native int or pointer, but got O
		//IL_084f: Expected O, but got I
		//IL_086f: Expected O, but got Ref
		//IL_0889: Expected native int or pointer, but got O
		//IL_0c86: Expected O, but got I
		//IL_08c1: Expected O, but got Ref
		//IL_08e8: Expected O, but got I
		//IL_0902: Expected native int or pointer, but got O
		//IL_0910: Expected O, but got I4
		//IL_0cae: Expected O, but got I4
		//IL_0956: Expected O, but got I
		//IL_0cf5: Expected O, but got I
		//IL_0996: Expected O, but got I
		//IL_09b1: Expected O, but got I
		//IL_09cc: Expected O, but got I
		//IL_09e0: Expected O, but got I4
		//IL_09f5: Expected O, but got I
		//IL_0ac4: Expected O, but got I
		//IL_0ad9: Expected O, but got I
		//IL_00db->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_012a->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_01de->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_0260->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_0542->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_05aa->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_05f9->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_06ad->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_072f->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_0a34->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_0a99->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_0b1d->IL0b4a: Incompatible stack heights: 1 vs 0
		//IL_0b4a->IL0b84: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleEmitterManager particlesManagerCoffins = _particlesManagerCoffins;
		if ((object)_particlesManagerCoffins != null && ((UnityEngine.Object)particlesManagerCoffins).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = CreateEmitterGameObject("ParticlesManagerCoffins");
		if ((object)gameObject != null)
		{
			ParticleEmitterManager particlesManagerCoffins2 = gameObject.AddComponent<ParticleEmitterManager>();
			_particlesManagerCoffins = particlesManagerCoffins2;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
				List<string> list = new List<string>();
				list._002Ector();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"CoffinLid.png");
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
								((List<object>)(object)list).AddWithResize((object)"Coffin.png");
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
								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
								particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								float constant = default(float);
								minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
								particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(400f, 600f));
								particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
								_ = 0;
								_ = 1;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
								particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
								_ = 0;
								_ = 0;
								_ = 1065353216;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
								particleSystemConfig._frequency = (float?)(object)0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
								_ = 0;
								_ = 0;
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
								particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
								_ = 0;
								_ = 257;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
								particleSystemConfig._collideTop = (bool?)(object)0;
								_ = 257;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
								particleSystemConfig._collideBottom = (bool?)(object)0;
								_ = 257;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
								particleSystemConfig._collideLeft = (bool?)(object)0;
								_ = 257;
								particleSystemConfig._bounds = (Rect?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
								particleSystemConfig._collideRight = (bool?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
								_ = 0;
								particleSystemConfig._on = false;
								if ((object)_particlesManagerCoffins != null)
								{
									ParticleSystem pfxEmitterC = _particlesManagerCoffins.CreateEmitter(particleSystemConfig, null, "PfxEmitterC2");
									_pfxEmitterC2 = pfxEmitterC;
									ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("items");
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
												((List<object>)(object)list2).AddWithResize((object)"CoffinLid.png");
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
													((List<object>)(object)list2).AddWithResize((object)"Coffin.png");
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
													minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
													particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
													particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
													particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
													particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
													particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(300f, 400f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
													particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
													_ = 0;
													_ = 1;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
													particleSystemConfig2._quantity = (int?)(object)0;
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 0f));
													obj = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
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
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
													particleSystemConfig2._frequency = (float?)(object)0;
													minMaxCurve = new ParticleSystem.MinMaxCurve(0.5f);
													_ = 0;
													_ = 0;
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
													particleSystemConfig2._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
													_ = 0;
													_ = 257;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
													particleSystemConfig2._collideTop = (bool?)(object)0;
													_ = 257;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
													particleSystemConfig2._collideBottom = (bool?)(object)0;
													_ = 257;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
													particleSystemConfig2._collideLeft = (bool?)(object)0;
													_ = 257;
													particleSystemConfig2._bounds = (Rect?)(object)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
													particleSystemConfig2._collideRight = (bool?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
													_ = 0;
													particleSystemConfig2._on = false;
													if ((object)_particlesManagerCoffins != null)
													{
														ParticleSystem pfxEmitterC2 = _particlesManagerCoffins.CreateEmitter(particleSystemConfig2, null, "PfxEmitterC1");
														_pfxEmitterC1 = pfxEmitterC2;
														GravityWellConfig gravityWellConfig = new GravityWellConfig();
														_ = 0;
														_ = 1;
														if (gravityWellConfig != null)
														{
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
															gravityWellConfig._y = (float?)(object)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
															gravityWellConfig._x = (float?)(object)0;
															gravityWellConfig._power = 1f;
															gravityWellConfig._epsilon = 50f;
															gravityWellConfig._gravity = 20f;
															if ((object)_particlesManagerCoffins != null)
															{
																GravityWell wellC = _particlesManagerCoffins.CreateGravityWell(gravityWellConfig, null, "WellC");
																_wellC = wellC;
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
		}
		throw new NullReferenceException();
	}

	private unsafe void MakeEmitters_Trainees()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04ae: Expected O, but got I4
		//IL_04d4: Expected O, but got I4
		//IL_04fb: Expected O, but got I4
		//IL_0514: Expected O, but got Ref
		//IL_052e: Expected native int or pointer, but got O
		//IL_0548: Expected O, but got I
		//IL_0568: Expected O, but got Ref
		//IL_0582: Expected native int or pointer, but got O
		//IL_0fe3: Expected O, but got I4
		//IL_059a: Expected O, but got Ref
		//IL_05c1: Expected O, but got I
		//IL_05db: Expected native int or pointer, but got O
		//IL_1015: Expected O, but got I
		//IL_062c: Expected O, but got I
		//IL_104f: Expected O, but got I
		//IL_066c: Expected O, but got I
		//IL_0687: Expected O, but got I
		//IL_06a2: Expected O, but got I
		//IL_06b6: Expected O, but got I4
		//IL_06cb: Expected O, but got I
		//IL_0b82: Expected O, but got I4
		//IL_0ba8: Expected O, but got I4
		//IL_0bcf: Expected O, but got I4
		//IL_0be8: Expected O, but got Ref
		//IL_0c02: Expected native int or pointer, but got O
		//IL_0c1c: Expected O, but got I
		//IL_0c3c: Expected O, but got Ref
		//IL_0c56: Expected native int or pointer, but got O
		//IL_1089: Expected O, but got I
		//IL_0c94: Expected O, but got Ref
		//IL_0cb5: Expected O, but got I
		//IL_0ccf: Expected native int or pointer, but got O
		//IL_0cdd: Expected O, but got I4
		//IL_10b1: Expected O, but got I4
		//IL_0d23: Expected O, but got I
		//IL_10f8: Expected O, but got I
		//IL_0d60: Expected O, but got I4
		//IL_0dbe: Expected O, but got I
		//IL_0dd9: Expected O, but got I
		//IL_0df4: Expected O, but got I
		//IL_0e0f: Expected O, but got I
		//IL_0ec7: Expected O, but got I
		//IL_0edc: Expected O, but got I
		//IL_00db->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_012a->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_01de->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0292->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0346->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_03fa->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_047c->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_070a->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_07af->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_07fe->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_08b2->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0966->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0a1a->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0ace->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0b50->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0e37->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0e9c->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0f20->IL0f4d: Incompatible stack heights: 1 vs 0
		//IL_0f4d->IL0f87: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleEmitterManager particlesManagerTrainees = _particlesManagerTrainees;
		if ((object)_particlesManagerTrainees != null && ((UnityEngine.Object)particlesManagerTrainees).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = CreateEmitterGameObject("ParticlesManagerTrainees");
		if ((object)gameObject != null)
		{
			ParticleEmitterManager particlesManagerTrainees2 = gameObject.AddComponent<ParticleEmitterManager>();
			_particlesManagerTrainees = particlesManagerTrainees2;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("enemies3");
				List<string> list = new List<string>();
				list._002Ector();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"HoodieR_i01.png");
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
								((List<object>)(object)list).AddWithResize((object)"HoodieP_i01.png");
							}
							else
							{
								int size2 = list._size + 1;
								list._size = size2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version3 = list._version + 1;
							list._version = version3;
							string[] items3 = list._items;
							if (list._items != null)
							{
								if (list._size >= items3.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"HoodieG_i01.png");
								}
								else
								{
									int size3 = list._size + 1;
									list._size = size3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								int version4 = list._version + 1;
								list._version = version4;
								string[] items4 = list._items;
								if (list._items != null)
								{
									if (list._size >= items4.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"HoodieB_i01.png");
									}
									else
									{
										int size4 = list._size + 1;
										list._size = size4;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version5 = list._version + 1;
									list._version = version5;
									string[] items5 = list._items;
									if (list._items != null)
									{
										if (list._size >= items5.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"HoodieY_i01.png");
										}
										else
										{
											int size5 = list._size + 1;
											list._size = size5;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										if (particleSystemConfig != null)
										{
											particleSystemConfig._frame = list;
											ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
											particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											float constant = default(float);
											minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
											particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
											particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(160f, 200f));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
											particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(500f, 600f));
											particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
											_ = 0;
											_ = 1;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
											particleSystemConfig._quantity = (int?)(object)0;
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 1f));
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
											particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
											_ = 0;
											_ = 0;
											_ = 1065353216;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
											particleSystemConfig._frequency = (float?)(object)0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
											_ = 0;
											_ = 0;
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
											particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
											_ = 0;
											_ = 257;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
											particleSystemConfig._collideTop = (bool?)(object)0;
											_ = 257;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
											particleSystemConfig._collideBottom = (bool?)(object)0;
											_ = 257;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
											particleSystemConfig._collideLeft = (bool?)(object)0;
											_ = 257;
											particleSystemConfig._bounds = (Rect?)(object)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
											particleSystemConfig._collideRight = (bool?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
											_ = 0;
											particleSystemConfig._on = false;
											if ((object)_particlesManagerTrainees != null)
											{
												ParticleSystem pfxEmitterT = _particlesManagerTrainees.CreateEmitter(particleSystemConfig, null, "PfxEmitterT2");
												_pfxEmitterT2 = pfxEmitterT;
												Line line = null;
												line._x1 = 0f;
												line._y1 = -0.32f;
												line._x2 = 0f;
												line._y2 = 0.32f;
												ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("enemies3");
												List<string> list2 = new List<string>();
												if (list2 != null)
												{
													int version6 = list2._version + 1;
													list2._version = version6;
													string[] items6 = list2._items;
													if (list2._items != null)
													{
														if (list2._size >= items6.Length)
														{
															((List<object>)(object)list2).AddWithResize((object)"HoodieR_i01.png");
														}
														else
														{
															int size6 = list2._size + 1;
															list2._size = size6;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version7 = list2._version + 1;
														list2._version = version7;
														string[] items7 = list2._items;
														if (list2._items != null)
														{
															if (list2._size >= items7.Length)
															{
																((List<object>)(object)list2).AddWithResize((object)"HoodieP_i01.png");
															}
															else
															{
																int size7 = list2._size + 1;
																list2._size = size7;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version8 = list2._version + 1;
															list2._version = version8;
															string[] items8 = list2._items;
															if (list2._items != null)
															{
																if (list2._size >= items8.Length)
																{
																	((List<object>)(object)list2).AddWithResize((object)"HoodieG_i01.png");
																}
																else
																{
																	int size8 = list2._size + 1;
																	list2._size = size8;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																int version9 = list2._version + 1;
																list2._version = version9;
																string[] items9 = list2._items;
																if (list2._items != null)
																{
																	if (list2._size >= items9.Length)
																	{
																		((List<object>)(object)list2).AddWithResize((object)"HoodieB_i01.png");
																	}
																	else
																	{
																		int size9 = list2._size + 1;
																		list2._size = size9;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	int version10 = list2._version + 1;
																	list2._version = version10;
																	string[] items10 = list2._items;
																	if (list2._items != null)
																	{
																		if (list2._size >= items10.Length)
																		{
																			((List<object>)(object)list2).AddWithResize((object)"HoodieY_i01.png");
																		}
																		else
																		{
																			int size10 = list2._size + 1;
																			list2._size = size10;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		}
																		if (particleSystemConfig2 != null)
																		{
																			particleSystemConfig2._frame = list2;
																			minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
																			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
																			_ = 0;
																			minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
																			particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
																			_ = 0;
																			minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
																			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(160f, 200f));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
																			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(450f, 550f));
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
																			_ = 0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
																			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																			_ = 0;
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
																			_ = 1;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																			particleSystemConfig2._quantity = (int?)(object)0;
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 1f));
																			obj = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
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
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																			particleSystemConfig2._frequency = (float?)(object)0;
																			minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
																			particleSystemConfig2._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
																			particleSystemConfig2._bounds = (Rect?)(object)1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
																			_ = 0;
																			particleSystemConfig2._emitZone = new EmitZone
																			{
																				_type = EmitZoneType.Random,
																				_source = line
																			};
																			_ = 257;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																			particleSystemConfig2._collideTop = (bool?)(object)0;
																			_ = 257;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																			particleSystemConfig2._collideBottom = (bool?)(object)0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																			particleSystemConfig2._collideLeft = (bool?)(object)0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																			particleSystemConfig2._collideRight = (bool?)(object)0;
																			particleSystemConfig2._on = false;
																			if ((object)_particlesManagerTrainees != null)
																			{
																				ParticleSystem pfxEmitterT2 = _particlesManagerTrainees.CreateEmitter(particleSystemConfig2, null, "PfxEmitterT1");
																				_pfxEmitterT1 = pfxEmitterT2;
																				GravityWellConfig gravityWellConfig = new GravityWellConfig();
																				_ = 0;
																				_ = 1;
																				if (gravityWellConfig != null)
																				{
																					_ = 0;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																					gravityWellConfig._y = (float?)(object)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																					gravityWellConfig._x = (float?)(object)0;
																					gravityWellConfig._power = 1f;
																					gravityWellConfig._epsilon = 50f;
																					gravityWellConfig._gravity = 20f;
																					if ((object)_particlesManagerTrainees != null)
																					{
																						GravityWell wellT = _particlesManagerTrainees.CreateGravityWell(gravityWellConfig, null, "WellT");
																						_wellT = wellT;
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
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void MakeEmitters_Explosions()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0292: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_02df: Expected O, but got I4
		//IL_02f8: Expected O, but got Ref
		//IL_0312: Expected native int or pointer, but got O
		//IL_032c: Expected O, but got I
		//IL_034c: Expected O, but got Ref
		//IL_0366: Expected native int or pointer, but got O
		//IL_0380: Expected O, but got I
		//IL_03a0: Expected O, but got Ref
		//IL_03ba: Expected native int or pointer, but got O
		//IL_0ccd: Expected O, but got I4
		//IL_03d2: Expected O, but got Ref
		//IL_03f9: Expected O, but got I
		//IL_0413: Expected native int or pointer, but got O
		//IL_0cff: Expected O, but got I
		//IL_044b: Expected O, but got Ref
		//IL_0472: Expected O, but got I
		//IL_048c: Expected native int or pointer, but got O
		//IL_0d39: Expected O, but got I
		//IL_0d73: Expected O, but got I
		//IL_04f6: Expected O, but got I
		//IL_0511: Expected O, but got I
		//IL_052c: Expected O, but got I
		//IL_0540: Expected O, but got I4
		//IL_0555: Expected O, but got I
		//IL_07f0: Expected O, but got I4
		//IL_0816: Expected O, but got I4
		//IL_083d: Expected O, but got I4
		//IL_0856: Expected O, but got Ref
		//IL_0870: Expected native int or pointer, but got O
		//IL_088a: Expected O, but got I
		//IL_08aa: Expected O, but got Ref
		//IL_08c4: Expected native int or pointer, but got O
		//IL_08de: Expected O, but got I
		//IL_08fe: Expected O, but got Ref
		//IL_0926: Expected native int or pointer, but got O
		//IL_0934: Expected O, but got I4
		//IL_0d9b: Expected O, but got I4
		//IL_0961: Expected O, but got Ref
		//IL_0988: Expected O, but got I
		//IL_09a2: Expected native int or pointer, but got O
		//IL_0de2: Expected O, but got I
		//IL_09f9: Expected O, but got I
		//IL_0a1a: Expected O, but got I
		//IL_0e1c: Expected O, but got I
		//IL_0a57: Expected O, but got I4
		//IL_0aa8: Expected O, but got I
		//IL_0ac3: Expected O, but got I
		//IL_0ade: Expected O, but got I
		//IL_0af9: Expected O, but got I
		//IL_0bb1: Expected O, but got I
		//IL_0bc6: Expected O, but got I
		//IL_00db->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_012a->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_01de->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0260->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0594->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0639->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0688->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_073c->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_07be->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0b21->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0b86->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0c0a->IL0c37: Incompatible stack heights: 1 vs 0
		//IL_0c37->IL0c71: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleEmitterManager particlesManagerExplosions = _particlesManagerExplosions;
		if ((object)_particlesManagerExplosions != null && ((UnityEngine.Object)particlesManagerExplosions).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = CreateEmitterGameObject("ParticlesManagerExplosions");
		if ((object)gameObject != null)
		{
			ParticleEmitterManager particlesManagerExplosions2 = gameObject.AddComponent<ParticleEmitterManager>();
			_particlesManagerExplosions = particlesManagerExplosions2;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
				List<string> list = new List<string>();
				list._002Ector();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"Smoke1.png");
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
								((List<object>)(object)list).AddWithResize((object)"Smoke2.png");
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
								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
								particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								float constant = default(float);
								minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
								particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-20f, 20f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A8]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(800f, 1200f));
								particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
								_ = 0;
								_ = 2;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D8]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E8]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
								particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
								_ = 0;
								_ = 1065353216;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
								particleSystemConfig._frequency = (float?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F8]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+108]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
								_ = 0;
								_ = 0;
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
								particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
								_ = 0;
								_ = 257;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
								particleSystemConfig._collideTop = (bool?)(object)0;
								_ = 257;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
								particleSystemConfig._collideBottom = (bool?)(object)0;
								_ = 257;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
								particleSystemConfig._collideLeft = (bool?)(object)0;
								_ = 257;
								particleSystemConfig._bounds = (Rect?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
								particleSystemConfig._collideRight = (bool?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
								_ = 0;
								particleSystemConfig._on = false;
								if ((object)_particlesManagerExplosions != null)
								{
									ParticleSystem pfxEmitterE = _particlesManagerExplosions.CreateEmitter(particleSystemConfig, null, "PfxEmitterE2");
									_pfxEmitterE2 = pfxEmitterE;
									Line line = null;
									line._x1 = 0f;
									line._y1 = -0.32f;
									line._x2 = 0f;
									line._y2 = 0.32f;
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
												((List<object>)(object)list2).AddWithResize((object)"HitSmoke1");
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
													((List<object>)(object)list2).AddWithResize((object)"HitSmoke2");
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
													minMaxCurve = new ParticleSystem.MinMaxCurve(ret);
													particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
													particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
													particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+118]");
													particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+128]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(-20f, 20f));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+138]");
													particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+148]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 344));
													particleSystemConfig2._angleSteps = 16;
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(-800f, -1200f));
													obj = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+158]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+168]");
													_ = 0;
													obj = 1;
													particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)obj;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 376));
													_ = 0;
													_ = 2;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
													particleSystemConfig2._quantity = (int?)(object)0;
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+178]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+188]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
													particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
													_ = 0;
													_ = 0;
													_ = 1065353216;
													_ = 1;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
													particleSystemConfig2._frequency = (float?)(object)0;
													_ = 1;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
													particleSystemConfig2._blendMode = (BlendMode?)(object)0;
													minMaxCurve = new ParticleSystem.MinMaxCurve(0.9f);
													_ = 0;
													_ = 0;
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
													particleSystemConfig2._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
													particleSystemConfig2._bounds = (Rect?)(object)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A125C0]");
													_ = 0;
													particleSystemConfig2._emitZone = new EmitZone
													{
														_type = EmitZoneType.Random,
														_source = line
													};
													_ = 257;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
													particleSystemConfig2._collideTop = (bool?)(object)0;
													_ = 257;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
													particleSystemConfig2._collideBottom = (bool?)(object)0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
													particleSystemConfig2._collideLeft = (bool?)(object)0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
													particleSystemConfig2._collideRight = (bool?)(object)0;
													particleSystemConfig2._on = false;
													if ((object)_particlesManagerExplosions != null)
													{
														ParticleSystem pfxEmitterE2 = _particlesManagerExplosions.CreateEmitter(particleSystemConfig2, null, "PfxEmitterE1");
														_pfxEmitterE1 = pfxEmitterE2;
														GravityWellConfig gravityWellConfig = new GravityWellConfig();
														_ = 0;
														_ = 1;
														if (gravityWellConfig != null)
														{
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
															gravityWellConfig._y = (float?)(object)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
															gravityWellConfig._x = (float?)(object)0;
															gravityWellConfig._power = 1f;
															gravityWellConfig._epsilon = 50f;
															gravityWellConfig._gravity = 20f;
															if ((object)_particlesManagerExplosions != null)
															{
																GravityWell wellE = _particlesManagerExplosions.CreateGravityWell(gravityWellConfig, null, "WellE");
																_wellE = wellE;
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
		}
		throw new NullReferenceException();
	}

	private GameObject CreateEmitterGameObject(string childName)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, childName);
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				Transform transform2 = gameObject.transform;
				string cachedTransform = (string)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = cachedTransform._stringLength == 0;
					Transform.get_position_Injected((IntPtr)cachedTransform._stringLength, out Vector3 _);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					return gameObject;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StopAllEmitters()
	{
		RenderingExtensions.StopEmitting(_pfxEmitterW1);
		RenderingExtensions.StopEmitting(_pfxEmitterW2);
		RenderingExtensions.StopEmitting(_pfxEmitterC1);
		RenderingExtensions.StopEmitting(_pfxEmitterC2);
		RenderingExtensions.StopEmitting(_pfxEmitterT1);
		RenderingExtensions.StopEmitting(_pfxEmitterT2);
		RenderingExtensions.StopEmitting(_pfxEmitterE1);
		RenderingExtensions.StopEmitting(_pfxEmitterE2);
	}

	private void ToggleParentAllEmitters(bool shouldParent)
	{
		Transform transform = _particlesManagerWeapons.transform;
		if (shouldParent)
		{
			Transform cachedTransform = _cachedTransform;
		}
		else
		{
			Transform cachedTransform = null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
		Transform transform2 = _particlesManagerCoffins.transform;
		if (shouldParent)
		{
			Transform cachedTransform2 = _cachedTransform;
		}
		else
		{
			Transform cachedTransform2 = null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
		Transform transform3 = _particlesManagerTrainees.transform;
		if (shouldParent)
		{
			Transform cachedTransform3 = _cachedTransform;
		}
		else
		{
			Transform cachedTransform3 = null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
		Transform transform4 = _particlesManagerExplosions.transform;
		bool flag = !shouldParent;
		Transform transform5 = null;
		if (!flag)
		{
			transform5 = _cachedTransform;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E0E1B0");
	}

	private static void SetParentAndScale(Transform trans, Transform parent)
	{
		trans.SetParent(parent, worldPositionStays: true);
		bool flag = ((UnityEngine.Object)trans).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)trans).m_CachedPtr, ref value);
	}

	public DamagingZone()
	{
		//IL_0084: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3768]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_skin = "Explosions";
		_damage = 1f;
		_durationMillis = 250f;
		_hitDelayMillis = 500f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CInit_003Eb__44_0()
	{
		_hasHit = false;
	}

	private void _003CInit_003Eb__44_1()
	{
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: true);
	}

	private void _003CShoot_003Eb__49_1()
	{
		PhaserSprite phaserSprite = setVisible(visible: true);
		PhaserSprite phaserSprite2 = setAlpha(0f);
	}

	private void _003CShoot_003Eb__49_2()
	{
		_activateDamage = true;
	}

	private void _003CShoot_003Eb__49_0()
	{
		_activateDamage = false;
		TriggerDespawnDelayed();
	}
}
