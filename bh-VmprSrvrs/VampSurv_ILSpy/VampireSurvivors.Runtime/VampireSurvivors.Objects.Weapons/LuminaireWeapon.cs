using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Weapons;

public class LuminaireWeapon : Weapon
{
	private List<PhaserSprite> _doilies;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private Rectangle _rectangle;

	private List<string> _frames;

	private float _firingCounter;

	private bool _isInitialised;

	private uint[] _colors;

	[NonSerialized]
	public float FiredTimes;

	[NonSerialized]
	public ArcanaType FirstArcana;

	protected override void OnStart()
	{
		base.OnStart();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Rectangle rectangle = new Rectangle();
		rectangle._x = 0f;
		float width = (float)renderer.pixelWidth * 0.85f;
		rectangle._width = width;
		float height = (float)renderer2.pixelHeight * 0.85f;
		rectangle._height = height;
		_rectangle = rectangle;
		_firingCounter = 0f;
		_isInitialised = false;
	}

	protected override void OnUpdate()
	{
		if (_isInitialised)
		{
			return;
		}
		_isInitialised = true;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._coherenceSync.HasStateAuthority)
			{
				SetupVFX();
			}
		}
	}

	private unsafe void SetupVFX()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Expected O, but got Unknown
		//IL_0062: Expected O, but got I
		//IL_0095: Expected I, but got O
		//IL_0111: Expected O, but got Ref
		//IL_0154: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_03b9: Expected O, but got I
		//IL_0448: Expected I4, but got I8
		//IL_04c4: Expected O, but got I
		//IL_0505: Expected I4, but got I8
		//IL_0620: Expected O, but got I
		//IL_0944: Expected O, but got I4
		//IL_0a00: Expected O, but got I
		//IL_0b3f: Expected O, but got Ref
		//IL_0a56: Expected F4, but got I
		//IL_0a56: Expected I, but got O
		//IL_07d0->IL0b31: Incompatible stack heights: 4 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		List<PhaserSprite> doilies = new List<PhaserSprite>();
		object obj3 = this + 344;
		_doilies = doilies;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
			object obj4 = default(object);
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v25+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v25+28]");
				if ((nint)0 != 0)
				{
					nint num = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v21+10]");
					float num2 = 0f * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v26 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num3 = 0;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
						_ = 0;
						int num4 = 1;
						object obj6 = default(object);
						object obj7 = default(object);
						while (true)
						{
							string text = System.Number.FormatInt32(num4, (ReadOnlySpan<char>)(&obj6), null);
							string spriteName = "doi0" + text;
							GameObject gameObject = base.gameObject;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
							PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)0, "vfx", spriteName);
							PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(phaserSprite, 0f);
							if ((object)phaserSprite == null)
							{
								break;
							}
							PhaserSprite phaserSprite3 = phaserSprite.setBlendMode(BlendMode.Add);
							PhaserSprite phaserSprite4 = phaserSprite.setAlpha(0.05f);
							if (obj7 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v27+28]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v27+28]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v43+14]");
							object obj9 = 0 ^ -0f;
							float depth = (float)obj9 - 1f;
							PhaserSprite phaserSprite5 = phaserSprite.setDepth(depth);
							List<object> doilies2 = (List<object>)(object)_doilies;
							if (_doilies == null)
							{
								break;
							}
							int version = doilies2._version + 1;
							doilies2._version = version;
							object[] items = doilies2._items;
							if (doilies2._items == null)
							{
								break;
							}
							if (doilies2._size >= items.Length)
							{
								((List<object>)(object)_doilies).AddWithResize((object)phaserSprite);
							}
							else
							{
								int size = doilies2._size + 1;
								doilies2._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							num4++;
							if (num4 <= 9)
							{
								continue;
							}
							TweenConfig tweenConfig = new TweenConfig();
							PhaserSprite[] targets = _doilies.ToArray();
							tweenConfig.targets = targets;
							tweenConfig.ease = Ease.InOutSine;
							_ = 0;
							_ = 1041865114;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
							tweenConfig.alpha = (float?)(object)0;
							StaggerConfig staggerConfig = new StaggerConfig();
							staggerConfig.ease = Ease.Linear;
							staggerConfig.start = 2f;
							Func<int, float> staggerScale = Tweens.Stagger(0.25f, staggerConfig);
							tweenConfig.staggerScale = staggerScale;
							Func<int, float> staggerDelay = Tweens.Stagger(800f);
							tweenConfig.staggerDelay = staggerDelay;
							tweenConfig.duration = 4000f;
							tweenConfig.repeat = -1;
							tweenConfig.yoyo = true;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							TweenConfig tweenConfig2 = new TweenConfig();
							PhaserSprite[] targets2 = _doilies.ToArray();
							tweenConfig2.targets = targets2;
							_ = 0;
							_ = 1135837184;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
							tweenConfig2.angle = (float?)(object)0;
							Func<int, float> staggerDelay2 = Tweens.Stagger(8f);
							tweenConfig2.staggerDelay = staggerDelay2;
							tweenConfig2.duration = 10000f;
							tweenConfig2.repeat = -1;
							MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
							bool flag = (object)GM.Core == null;
							PhaserScene s_scene = ArcadePhysics.s_scene;
							PhaserScene.Renderer renderer = s_scene._renderer;
							bool flag2 = (object)GM.Core == null;
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							Rectangle source = new Rectangle
							{
								_width = renderer.width,
								_height = renderer2.height,
								_x = 0f
							};
							bool flag3 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
							GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rbx_v16 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>((nint)(delegate*<GameObject, ParticleEmitterManager>)(&Extensions.GetOrAddComponent<ParticleEmitterManager>));
							}
							_ = 0;
							ParticleEmitterManager particlesManager;
							if (gameObject2.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240))))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
								particlesManager = (ParticleEmitterManager)0;
							}
							else
							{
								particlesManager = gameObject2.AddComponent<ParticleEmitterManager>();
							}
							_particlesManager = particlesManager;
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
							List<string> list = new List<string> { "Beam" };
							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
							((List<PhaserSprite>)(object)particleSystemConfig)._items = null;
							((List<PhaserSprite>)(object)particleSystemConfig)._syncRoot = null;
							minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
							_ = 0;
							_ = 0;
							minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
							_ = 0;
							_ = 0;
							_ = 3;
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
							_ = 0;
							_ = 0;
							_ = 1;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
							_ = 0;
							_ = 3;
							_ = 0;
							_ = 3f;
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
							_ = 0;
							_ = 0;
							_ = 0;
							obj = 3;
							_ = 0;
							_ = 50f;
							_ = 50f;
							_ = 50f;
							_ = 50f;
							_ = 0;
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
							_ = 0;
							_ = 3;
							_ = 0;
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
							_ = 0;
							_ = 0.25f;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-6C]");
							_ = 0;
							_ = 0.25f;
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
							_ = 0;
							EmitZone emitZone = new EmitZone
							{
								_type = EmitZoneType.Random,
								_source = source
							};
							_ = 0;
							_ = 1137180672;
							_ = 1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
							_ = 0;
							_ = 1;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
							_ = 0;
							_ = 1;
							ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "ParticleEmitter");
							_pfxEmitter = pfxEmitter;
							_ = _pfxEmitter;
							_ = _pfxEmitter;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								bool flag4 = obj10 == null;
							}
							object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3053 @ rax_v129 (should have been resolved before IL gen)");
							ParticleSystemRenderer component = _pfxEmitter.GetComponent<ParticleSystemRenderer>();
							bool flag5 = ((List<PhaserSprite>)(object)component)._items == null;
							ParticleSystemRenderer.set_maxParticleSize_Injected((IntPtr)((List<PhaserSprite>)(object)component)._items, 0f);
							ParticleSystem particleSystem = RenderingExtensions.SetScrollFactor(_pfxEmitter, 0f);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01d1: Expected F4, but got I4
		//IL_01da: Expected F4, but got I4
		//IL_05d5: Invalid comparison between F4 and I4
		//IL_01ec: Invalid comparison between F4 and I4
		//IL_02a2: Expected O, but got I
		//IL_062e: Expected F4, but got I4
		//IL_0637: Expected F4, but got I4
		//IL_0640: Expected F4, but got I4
		//IL_0649: Expected F4, but got I4
		//IL_0468: Invalid comparison between F4 and I4
		//IL_0664: Invalid comparison between F4 and I4
		//IL_048c: Invalid comparison between F4 and I4
		//IL_03fb: Invalid comparison between F4 and I4
		//IL_04d3: Expected I, but got O
		base.Fire(skipTriggers: true);
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				RenderingExtensions.Start(_pfxEmitter);
			}
			else
			{
				_pfxEmitter.Stop();
			}
		}
		Extensions.Shuffle((IList<object>)Gem.GEMFRAMES);
		float firingCounter = _firingCounter + 1f;
		Rectangle rectangle = _rectangle;
		_firingCounter = firingCounter;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Rectangle rectangle2 = _rectangle;
		float num = rectangle2._width * 0.5f;
		float x = (float)position - num;
		rectangle._x = x;
		Rectangle rectangle3 = _rectangle;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Rectangle rectangle4 = _rectangle;
		float num2 = rectangle4._height * 0.5f;
		object obj = default(object);
		float num3 = (rectangle3._y = num2 + (float)obj);
		float num4 = base.PAmount();
		List<Pickup> allPickupsOfTypes = PickupManager.GetAllPickupsOfTypes(new ItemType[3]
		{
			ItemType.COIN,
			ItemType.COINBAG1,
			ItemType.COINBAGMAX
		});
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B70270");
		float num5 = (float)allPickupsOfTypes._size + num3;
		float value = num5 / (float)allPickupsOfTypes._size;
		float num6 = 0f;
		float num7 = 0f;
		while (true)
		{
			if (num7 < (float)allPickupsOfTypes._size)
			{
				if (num6 < (float)allPickupsOfTypes._size)
				{
					Pickup[] items = allPickupsOfTypes._items;
					items[num6].Bless(value);
					num6++;
					num7 = num6;
					continue;
				}
				goto IL_05b6;
			}
			GameManager core2 = GM.Core;
			IEnumerable<Gem> enumerable = Enumerable.OfType<Gem>(core2._gems);
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rsi_v5 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				IEnumerable<Gem> enumerable2 = Enumerable.OfType<Gem>((IEnumerable)0);
			}
			List<object> list;
			float value2;
			PlayerOptionsData playerOptionsData;
			if (enumerable != null)
			{
				list = new List<object>(enumerable);
				((List<Gem>)(object)list)._002Ector(enumerable);
				float num9 = (float)list._size + num3;
				GameManager core3 = GM.Core;
				value2 = num9 / (float)list._size;
				PlayerOptions playerOptions = core3._playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0611;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0611;
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
			IL_05b6:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
			IL_0611:
			bool flag = !playerOptionsData._003CFlashingVFXEnabled_003Ek__BackingField;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			float num13 = 0f;
			if (flag)
			{
				while (num11 < (float)list._size)
				{
					if (num10 < (float)list._size)
					{
						object[] items2 = list._items;
						object obj2 = items2[num10];
						nint num14 = (nint)obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1073 @ rax_v54 (Il2CppClass<System.Object>)+408] (should have been resolved before IL gen)");
						num10++;
						num11 = num10;
						continue;
					}
					goto IL_05b6;
				}
			}
			else
			{
				while (num13 < (float)list._size)
				{
					if (num12 < (float)list._size)
					{
						object[] items3 = list._items;
						((Gem)items3[num12]).BlessColor(value2, num12);
						num12++;
						num13 = num12;
						continue;
					}
					goto IL_05b6;
				}
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
			break;
		}
	}

	public override void CheckArcanas()
	{
		//IL_00a2: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_0152: Expected O, but got I
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		if (FirstArcana == ArcanaType.VOID)
		{
			GameManager core = GM.Core;
			object obj2 = 0;
			object obj3 = 0;
			float newWeaponPower = default(float);
			while (true)
			{
				ArcanaManager arcanaManager2 = core._arcanaManager;
				List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				GameManager core2 = GM.Core;
				ArcanaManager arcanaManager3 = core2._arcanaManager;
				List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
				object obj5 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				if ((nint)obj5 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v15+20+v88 @ rdi_v7*4]");
					if ((nint)0 != 19)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v15+20+v88 @ rdi_v7*4]");
						if ((nint)0 != 14)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v15+20+v88 @ rdi_v7*4]");
							if ((nint)0 == 2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v15+20+v88 @ rdi_v7*4]");
								FirstArcana = ArcanaType.T00_KILLER;
								_explosionType = WeaponType.RAYEXPLOSION;
								_explodeOnExpire = true;
							}
						}
						else
						{
							FirstArcana = ArcanaType.T14_JEWELS;
							base._003CFreezeChance_003Ek__BackingField = 0.25f;
						}
					}
					else
					{
						GameManager gameMan2 = _gameMan;
						FirstArcana = ArcanaType.T19_FIRE;
						_explosionType = WeaponType.FIREEXPLOSION;
						float heartOfFirePower = base.HeartOfFirePower;
						gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
					}
					obj2++;
					core = GM.Core;
					obj3 = obj2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		CheckBeginningArcana();
	}

	public override void Cleanup()
	{
		//IL_0019: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		base.Cleanup();
		if (_doilies != null)
		{
			List<PhaserSprite> doilies = _doilies;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < doilies._size)
			{
				List<PhaserSprite> doilies2 = _doilies;
				if ((nint)obj < doilies2._size)
				{
					PhaserSprite[] items = doilies2._items;
					if ((object)items[obj] != null)
					{
						PhaserSprite phaserSprite = items[obj].setVisible(visible: false);
					}
					doilies = _doilies;
					obj++;
					obj2 = obj;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new IndexOutOfRangeException();
			}
		}
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0)
		{
			object pfxEmitter2 = _pfxEmitter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v9 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(pfxEmitter2);
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v9 (System.Object)+10]");
			ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		bool flag = _doilies == null;
		_isVisible = visible;
		if (!flag)
		{
			List<PhaserSprite> doilies = _doilies;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < doilies._size)
			{
				List<PhaserSprite> doilies2 = _doilies;
				if ((nint)obj < doilies2._size)
				{
					PhaserSprite[] items = doilies2._items;
					if ((object)items[obj] != null)
					{
						PhaserSprite phaserSprite = items[obj].setVisible(visible);
					}
					doilies = _doilies;
					obj++;
					obj2 = obj;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new IndexOutOfRangeException();
			}
		}
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0 && !visible)
		{
			object pfxEmitter2 = _pfxEmitter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v9 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(pfxEmitter2);
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v9 (System.Object)+10]");
			ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	public LuminaireWeapon()
	{
		//IL_021a: Expected I4, but got I8
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem6.png");
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
			((List<object>)(object)list).AddWithResize((object)"Gem7.png");
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
			((List<object>)(object)list).AddWithResize((object)"Gem10.png");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frames = list;
		_colors = new uint[7] { 16711680u, 16753920u, 16776960u, 32768u, 255u, 4915330u, 15631086u };
		FirstArcana = ArcanaType.VOID;
		base._002Ector();
	}
}
