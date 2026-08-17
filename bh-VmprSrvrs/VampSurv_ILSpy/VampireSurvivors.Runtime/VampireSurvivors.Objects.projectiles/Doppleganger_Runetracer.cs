using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Projectiles;

public class Doppleganger_Runetracer : EnemyProjectile
{
	public TrailRenderer _Trail;

	public SpriteRenderer _SpriteRenderer;

	private Timer _expireTimer;

	private float _saveVelX;

	private float _saveVelY;

	private TrailRendererPauseController _pauseController;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Diamond2", "items");
		_SpriteRenderer.sprite = sprite;
	}

	public override void InitProjectile(int index, float2 direction, EnemyBulletPool pool)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_01f7: Expected O, but got I
		//IL_025d: Expected O, but got I8
		//IL_03b3: Expected I, but got O
		//IL_027e: Expected O, but got F4
		//IL_02a8: Expected O, but got I4
		//IL_02e8: Expected F4, but got I4
		//IL_0409->IL02ed: Incompatible stack heights: 1 vs 0
		base.InitProjectile(index, direction, pool);
		base._003CDamage_003Ek__BackingField = 18f;
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			_speed = 1.1f;
			CheckRenderer();
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(((ArcadeSprite)this)._spriteRenderer, 1f);
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null && base.body != null)
					{
						Body body = base.body.setBoundsRectangle(activeCharacter._worldBoxCollider);
						BaseBody baseBody2 = base.body;
						if (base.body != null)
						{
							baseBody2._onWorldBounds = true;
							if (_expireTimer != null)
							{
								_expireTimer.Cancel();
							}
							Action onComplete = FadeOutAndDispose;
							bool flag = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer expireTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_expireTimer = expireTimer;
							SetupTrails();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							bool flag2 = (nint)0 != 0;
							Doppleganger_Runetracer doppleganger_Runetracer = this;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								if (obj == null)
								{
									MissingMethodException ex = new MissingMethodException();
									throw ex;
								}
								doppleganger_Runetracer = (Doppleganger_Runetracer)6573110936L;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v780 @ rax_v37 (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							Transform transform = base.transform;
							Vector3 euler = default(Vector3);
							Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
							bool flag3 = ((EventEmitter)(object)transform).callbacks == null;
							Quaternion value = default(Quaternion);
							Transform.set_rotation_Injected((IntPtr)((EventEmitter)(object)transform).callbacks, ref value);
							float num = _speed * 1.6500001f;
							BaseBody baseBody3 = base.body;
							float num2 = 0f * num;
							float num3 = 0f * num;
							if (base.body != null)
							{
								baseBody3._velocity = (float2)num2;
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
								{
									Rate = 1f,
									Volume = (float?)(object)1
								};
								float detune = (float)_indexInWeapon * -100f;
								soundConfig.Detune = detune;
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, flag ? 1 : 0);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FadeOutAndDispose()
	{
		//IL_0153: Expected I, but got O
		Material material = ((Renderer)_Trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(material, 0f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CheckRenderer();
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(((ArcadeSprite)this)._spriteRenderer, 0f, 0.1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Doppleganger_Runetracer>)+280]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		_expireTimer = null;
		TrailRendererPauseController pauseController = _pauseController;
		if (pauseController._trailTimeResetTimer != null)
		{
			pauseController._trailTimeResetTimer.Cancel();
		}
		pauseController._trailTimeResetTimer = null;
		base.Despawn();
	}

	protected override void OnUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_00a3: Expected F4, but got O
		//IL_00f1: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		CheckRenderer();
		int sortingOrder = default(int);
		((ArcadeSprite)this)._spriteRenderer.sortingOrder = sortingOrder;
		_Trail.sortingOrder = sortingOrder;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187261819h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v16 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018726183Ah\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v16 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I8
		//IL_01e3: Expected O, but got I4
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_0163: Expected O, but got I8
		//IL_0132: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0148: Expected O, but got I4
		//IL_0177: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_017d;
			}
		}
		obj5 = 4294967295L;
		goto IL_017d;
		IL_01fe:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)_saveVelX;
		return;
		IL_017d:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_01fe;
			}
		}
		obj6 = 4294967295L;
		goto IL_01fe;
	}

	private void SetupTrails()
	{
		//IL_035b->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_03aa->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_01cd->IL02d7: Incompatible stack heights: 3 vs 0
		//IL_029f->IL02d7: Incompatible stack heights: 7 vs 0
		float saturationMax = default(float);
		float valueMin = default(float);
		float valueMax = default(float);
		float alphaMin = default(float);
		Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.35f, saturationMax, valueMin, valueMax, alphaMin, 0.35f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_Trail != null)
		{
			_Trail.time = 1f;
			if ((object)_Trail != null)
			{
				_Trail.endWidth = 0.015f;
				_Trail.startWidth = 0.015f;
				Sprite sprite = default(Sprite);
				RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
				if ((object)_Trail != null)
				{
					Material material = ((Renderer)_Trail).GetMaterial();
					RenderingExtensions.SetAlpha(material, 1f);
					TrailRenderer trail = _Trail;
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
								_ = color.r;
								_ = 1f;
								GradientAlphaKey[] array2 = new GradientAlphaKey[4];
								if (array2 != null)
								{
									bool flag4 = array2.Length <= 0;
									_ = 1061997773;
									bool flag5 = array2.Length <= 1;
									_ = 1061997773;
									_ = 1056964608;
									bool flag6 = array2.Length <= 2;
									_ = 1056964608;
									_ = 1056964608;
									bool flag7 = array2.Length <= 3;
									_ = 1036831949;
									_ = 1065353216;
									gradient.SetKeys(array, array2);
									if ((object)_Trail != null)
									{
										_Trail.colorGradient = gradient;
										TrailRendererPauseController pauseController = RenderingExtensions.AddPauseController(_Trail);
										_pauseController = pauseController;
										return;
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

	public override void OnHitPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		bool damaged = player.GetDamaged(base._003CDamage_003Ek__BackingField);
	}

	public Doppleganger_Runetracer()
	{
		//IL_002b: Expected I, but got O
		_speed = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
