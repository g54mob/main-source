using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors;

public class DeathFightDirecter : PhaserSprite
{
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public PhaserSprite thing;

		internal void _003CBreakSomething_003Eb__0()
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("MaskBreakingShake");
			PhaserSprite phaserSprite = thing.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public PhaserSprite mask;

		internal unsafe void _003CBreakMask_003Eb__0()
		{
			//IL_0023: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			PhaserSprite phaserSprite = mask.setTintFill(isEnabled: false, (Color?)(object)(&obj));
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("MaskBreakingShake");
			PhaserSprite phaserSprite2 = mask;
			phaserSprite2._spriteAnimation.SetAnimation("explode");
		}
	}

	private sealed class _003C_BlockCutscene_003Ed__40(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DeathFightDirecter _003C_003E4__this;

		private float _003CstruggleTimer_003E5__2;

		private float2 _003CprojectileStartPos_003E5__3;

		private float _003CstruggleRange_003E5__4;

		private float2 _003CtargetPos_003E5__5;

		private float2 _003CtoBlockTarget_003E5__6;

		private Vector3 _003CscytheRotation_003E5__7;

		private float _003CsoundTimer_003E5__8;

		private List<Transform> _003CoriginalCameraTargets_003E5__9;

		private Camera _003CmainCamera_003E5__10;

		private float _003CorthographicSize_003E5__11;

		private float2 _003CstartBodyPos_003E5__12;

		private float2 _003CbodyTargetPos_003E5__13;

		private float2 _003CleftHandOffset_003E5__14;

		private GameObject _003CcameraTarget_003E5__15;

		private PhaserSprite _003CfullscreenGlitch_003E5__16;

		private float _003CfadeTimer_003E5__17;

		private List<PhaserSprite> _003Cmasks_003E5__18;

		private Color _003CstartColor_003E5__19;

		private Vector3 _003CtilesetStartPos_003E5__20;

		private List<PhaserSprite> _003Ceyes_003E5__21;

		private float _003CexplosionTimer_003E5__22;

		private int _003Ci_003E5__23;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 247 Invalid \"Jump target not found in method: 0x186DBA102\"");
			return (byte)_003C_003E1__state != 0;
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

	private float _Radius1;

	private float _Radius2;

	private float _Radius3;

	private float _Radius4;

	private float _Radius5;

	private float _Radius6;

	private float _Radius7;

	private float _myAngle1;

	private float _myAngle2;

	private float _myAngle3;

	private float _myAngle4;

	private float _myAngle5;

	private float _myAngle6;

	private float _myAngle7;

	private PhaserSprite _eye1;

	private PhaserSprite _eye2;

	private PhaserSprite _eye3;

	private PhaserSprite _eye4;

	private PhaserSprite _eye5;

	private PhaserSprite _eye6;

	private PhaserSprite _eye7;

	private TileSprite _stars1;

	private TileSprite _stars2;

	private PhaserSprite _LeftHand;

	private PhaserSprite _RightHand;

	private float _angleUnit;

	private SpriteMask _spriteMask;

	private List<MultiTargetTween> _allTweens;

	public Transform _protectionTarget;

	public Transform _projectileToBlock;

	public Enemy_TP_Death _death;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_2231: Expected O, but got Ref
		//IL_012c: Expected O, but got I4
		//IL_022c: Expected O, but got I4
		//IL_0327: Expected O, but got I4
		//IL_0422: Expected O, but got I4
		//IL_051d: Expected O, but got I4
		//IL_0618: Expected O, but got I4
		//IL_0713: Expected O, but got I4
		//IL_0827: Expected O, but got I
		//IL_085b: Expected O, but got I4
		//IL_0985: Expected O, but got I
		//IL_09b9: Expected O, but got I4
		//IL_0c56: Expected O, but got Ref
		//IL_0d52: Expected I, but got O
		//IL_0dbe: Expected O, but got Ref
		//IL_0eba: Expected I, but got O
		//IL_0f21: Expected O, but got Ref
		//IL_101d: Expected I, but got O
		//IL_1084: Expected O, but got Ref
		//IL_1180: Expected I, but got O
		//IL_11e7: Expected O, but got Ref
		//IL_12e3: Expected I, but got O
		//IL_134a: Expected O, but got Ref
		//IL_1446: Expected I, but got O
		//IL_14ad: Expected O, but got Ref
		//IL_15a9: Expected I, but got O
		//IL_16ff: Expected I, but got O
		//IL_19ae: Expected O, but got I4
		//IL_19ae: Expected F4, but got I4
		//IL_1cb7: Expected O, but got I4
		//IL_1cb7: Expected F4, but got I4
		//IL_1e3f: Expected O, but got I
		//IL_1e7e: Expected O, but got I
		//IL_1f2f: Expected I4, but got O
		//IL_1f5d: Expected I, but got O
		//IL_1fd9: Expected I4, but got O
		//IL_2082: Expected I4, but got O
		//IL_20ac: Expected I, but got O
		//IL_2051: Expected I4, but got O
		//IL_212a: Expected I4, but got O
		//IL_0114->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0163->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_01ab->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0214->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0263->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_02a6->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_030f->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_035e->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_03a1->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_040a->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0459->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_049c->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0505->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0554->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0597->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0600->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_064f->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0692->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_06fb->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_074a->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_078d->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0808->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0843->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0877->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_08a6->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_08d0->IL21dd: Incompatible stack heights: 1 vs 0
		//IL_0966->IL21dd: Incompatible stack heights: 2 vs 0
		//IL_09a1->IL21dd: Incompatible stack heights: 2 vs 0
		//IL_09d5->IL21dd: Incompatible stack heights: 2 vs 0
		//IL_0a04->IL21dd: Incompatible stack heights: 2 vs 0
		//IL_0a33->IL21dd: Incompatible stack heights: 2 vs 0
		//IL_0a5d->IL21dd: Incompatible stack heights: 2 vs 0
		//IL_2399->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0ac6->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0b1b->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0b3d->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0b79->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0b9b->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0bf0->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0c12->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0c83->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0cbb->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0d06->IL21dd: Incompatible stack heights: 3 vs 0
		//IL_0d83->IL21dd: Incompatible stack heights: 4 vs 0
		//IL_0deb->IL21dd: Incompatible stack heights: 4 vs 0
		//IL_0e23->IL21dd: Incompatible stack heights: 4 vs 0
		//IL_0e6e->IL21dd: Incompatible stack heights: 4 vs 0
		//IL_0ee6->IL21dd: Incompatible stack heights: 5 vs 0
		//IL_0f4e->IL21dd: Incompatible stack heights: 5 vs 0
		//IL_0f86->IL21dd: Incompatible stack heights: 5 vs 0
		//IL_0fd1->IL21dd: Incompatible stack heights: 5 vs 0
		//IL_1049->IL21dd: Incompatible stack heights: 6 vs 0
		//IL_10b1->IL21dd: Incompatible stack heights: 6 vs 0
		//IL_10e9->IL21dd: Incompatible stack heights: 6 vs 0
		//IL_1134->IL21dd: Incompatible stack heights: 6 vs 0
		//IL_11ac->IL21dd: Incompatible stack heights: 7 vs 0
		//IL_1214->IL21dd: Incompatible stack heights: 7 vs 0
		//IL_124c->IL21dd: Incompatible stack heights: 7 vs 0
		//IL_1297->IL21dd: Incompatible stack heights: 7 vs 0
		//IL_130f->IL21dd: Incompatible stack heights: 8 vs 0
		//IL_1377->IL21dd: Incompatible stack heights: 8 vs 0
		//IL_13af->IL21dd: Incompatible stack heights: 8 vs 0
		//IL_13fa->IL21dd: Incompatible stack heights: 8 vs 0
		//IL_1472->IL21dd: Incompatible stack heights: 9 vs 0
		//IL_14da->IL21dd: Incompatible stack heights: 9 vs 0
		//IL_1512->IL21dd: Incompatible stack heights: 9 vs 0
		//IL_155d->IL21dd: Incompatible stack heights: 9 vs 0
		//IL_15d5->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_161e->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_16ed->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1672->IL1672: Incompatible stack heights: 11 vs 10
		//IL_16cb->IL16cb: Incompatible stack heights: 11 vs 10
		//IL_177f->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_17a7->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_17d2->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1801->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_181f->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_184a->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1879->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1897->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_18c2->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_18f1->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_190f->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_193a->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_195c->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_19e7->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1a12->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1a41->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1a5e->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1aaf->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1ada->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1b09->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1b27->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1b52->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1b81->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1b9f->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1bca->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1bf9->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1c17->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1c42->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1c65->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1cf0->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1d1b->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1d4a->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1d67->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1db9->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1de5->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1e2a->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_1e5f->IL21dd: Incompatible stack heights: 10 vs 0
		//IL_23f3->IL21dd: Incompatible stack heights: 11 vs 0
		//IL_1e9e->IL21dd: Incompatible stack heights: 11 vs 0
		//IL_1ec5->IL21dd: Incompatible stack heights: 12 vs 0
		//IL_1f4b->IL21dd: Incompatible stack heights: 12 vs 0
		//IL_1f1b->IL1f1b: Incompatible stack heights: 13 vs 12
		//IL_1fbe->IL21dd: Incompatible stack heights: 12 vs 0
		//IL_2017->IL21dd: Incompatible stack heights: 12 vs 0
		//IL_206e->IL206e: Incompatible stack heights: 13 vs 12
		object obj2 = default(object);
		object obj = (object)(&obj2);
		EnsureSpriteRenderer();
		List<MultiTargetTween> allTweens = new List<MultiTargetTween>();
		_allTweens = allTweens;
		_Radius1 = 0.64f;
		_Radius2 = 0.64f;
		_Radius3 = 0.64f;
		_Radius4 = 0.64f;
		_Radius5 = 0.64f;
		_Radius6 = 0.64f;
		_Radius7 = 0.64f;
		_myAngle2 = 1.4451327f;
		_myAngle3 = (float)Math.PI * 41f / 50f;
		_myAngle4 = 3.8327432f;
		_myAngle5 = 4.4610615f;
		_myAngle6 = 4.9637165f;
		_myAngle7 = 5.215044f;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "enemiesM", "mask_sun_0");
			if ((object)phaserSprite != null)
			{
				PhaserSprite eye = phaserSprite.setScale(2f, (float?)(object)0);
				_eye1 = eye;
				PhaserSprite eye2 = _eye1;
				if ((object)_eye1 != null)
				{
					int num = default(int);
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("mask_sun_", 0, 30, "enemiesM", num);
					if ((object)eye2._spriteAnimation != null)
					{
						bool flag2 = default(bool);
						Action action = default(Action);
						bool autoSetAnimation = default(bool);
						eye2._spriteAnimation.AddAnimation("explode", animationFrames, 8, (byte)num != 0, flag2, action, autoSetAnimation);
						GameObject gameObject2 = base.gameObject;
						PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "enemiesM", "mask_moon_0");
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite eye3 = phaserSprite2.setScale(1.75f, (float?)(object)0);
							_eye2 = eye3;
							PhaserSprite eye4 = _eye2;
							if ((object)_eye2 != null)
							{
								List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("mask_moon_", 0, 30, "enemiesM", num);
								if ((object)eye4._spriteAnimation != null)
								{
									eye4._spriteAnimation.AddAnimation("explode", animationFrames2, 8, (byte)num != 0, flag2, action, autoSetAnimation);
									GameObject gameObject3 = base.gameObject;
									PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "enemiesM", "mask_city_0");
									if ((object)phaserSprite3 != null)
									{
										PhaserSprite eye5 = phaserSprite3.setScale(1.5f, (float?)(object)0);
										_eye3 = eye5;
										PhaserSprite eye6 = _eye3;
										if ((object)_eye3 != null)
										{
											List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("mask_city_", 0, 30, "enemiesM", num);
											if ((object)eye6._spriteAnimation != null)
											{
												eye6._spriteAnimation.AddAnimation("explode", animationFrames3, 8, (byte)num != 0, flag2, action, autoSetAnimation);
												GameObject gameObject4 = base.gameObject;
												PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "enemiesM", "mask_seawind_0");
												if ((object)phaserSprite4 != null)
												{
													PhaserSprite eye7 = phaserSprite4.setScale(1.25f, (float?)(object)0);
													_eye4 = eye7;
													PhaserSprite eye8 = _eye4;
													if ((object)_eye4 != null)
													{
														List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("mask_seawind_", 0, 30, "enemiesM", num);
														if ((object)eye8._spriteAnimation != null)
														{
															eye8._spriteAnimation.AddAnimation("explode", animationFrames4, 8, (byte)num != 0, flag2, action, autoSetAnimation);
															GameObject gameObject5 = base.gameObject;
															PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "enemiesM", "mask_volcano_0");
															if ((object)phaserSprite5 != null)
															{
																PhaserSprite eye9 = phaserSprite5.setScale(1f, (float?)(object)0);
																_eye5 = eye9;
																PhaserSprite eye10 = _eye5;
																if ((object)_eye5 != null)
																{
																	List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("mask_volcano_", 0, 30, "enemiesM", num);
																	if ((object)eye10._spriteAnimation != null)
																	{
																		eye10._spriteAnimation.AddAnimation("explode", animationFrames5, 8, (byte)num != 0, flag2, action, autoSetAnimation);
																		GameObject gameObject6 = base.gameObject;
																		PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject6, pos, "enemiesM", "mask_stone_0");
																		if ((object)phaserSprite6 != null)
																		{
																			PhaserSprite eye11 = phaserSprite6.setScale(0.75f, (float?)(object)0);
																			_eye6 = eye11;
																			PhaserSprite eye12 = _eye6;
																			if ((object)_eye6 != null)
																			{
																				List<Sprite> animationFrames6 = SpriteManager.GetAnimationFrames("mask_stone_", 0, 30, "enemiesM", num);
																				if ((object)eye12._spriteAnimation != null)
																				{
																					eye12._spriteAnimation.AddAnimation("explode", animationFrames6, 8, (byte)num != 0, flag2, action, autoSetAnimation);
																					GameObject gameObject7 = base.gameObject;
																					PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject7, pos, "enemiesM", "nomask_0");
																					if ((object)phaserSprite7 != null)
																					{
																						PhaserSprite eye13 = phaserSprite7.setScale(0.5f, (float?)(object)0);
																						_eye7 = eye13;
																						PhaserSprite eye14 = _eye7;
																						if ((object)_eye7 != null)
																						{
																							List<Sprite> animationFrames7 = SpriteManager.GetAnimationFrames("nomask_", 0, 30, "enemiesM", num);
																							if ((object)eye14._spriteAnimation != null)
																							{
																								eye14._spriteAnimation.AddAnimation("explode", animationFrames7, 8, (byte)num != 0, flag2, action, autoSetAnimation);
																								GameObject gameObject8 = base.gameObject;
																								PhaserSprite phaserSprite8 = RenderingExtensions.AddPhaserSprite(gameObject8, pos, "enemiesM", "hand_01");
																								_ = 0;
																								_ = 1056964608;
																								_ = 1;
																								if ((object)phaserSprite8 != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
																									PhaserSprite phaserSprite9 = phaserSprite8.setOrigin(1f, (float?)(object)0);
																									if ((object)phaserSprite9 != null)
																									{
																										PhaserSprite phaserSprite10 = phaserSprite9.setScale(1f, (float?)(object)0);
																										if ((object)phaserSprite10 != null)
																										{
																											PhaserSprite phaserSprite11 = phaserSprite10.setFlipY(flipY: true);
																											if ((object)phaserSprite11 != null)
																											{
																												Transform transform2 = phaserSprite11.transform;
																												if ((object)transform2 != null)
																												{
																													bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																													nint num2 = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4285 @ rcx_v126 (Il2CppMethodInfo)+38]");
																													if ((nint)0 == 0)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																													}
																													Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
																													_LeftHand = phaserSprite11;
																													GameObject gameObject9 = base.gameObject;
																													PhaserSprite phaserSprite12 = RenderingExtensions.AddPhaserSprite(gameObject9, pos, "enemiesM", "hand_01");
																													_ = 0;
																													_ = 1056964608;
																													_ = 1;
																													if ((object)phaserSprite12 != null)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
																														PhaserSprite phaserSprite13 = phaserSprite12.setOrigin(0f, (float?)(object)0);
																														if ((object)phaserSprite13 != null)
																														{
																															PhaserSprite phaserSprite14 = phaserSprite13.setScale(1f, (float?)(object)0);
																															if ((object)phaserSprite14 != null)
																															{
																																PhaserSprite phaserSprite15 = phaserSprite14.setFlipY(flipY: true);
																																if ((object)phaserSprite15 != null)
																																{
																																	PhaserSprite phaserSprite16 = phaserSprite15.setFlipX(flipX: true);
																																	if ((object)phaserSprite16 != null)
																																	{
																																		Transform transform3 = phaserSprite16.transform;
																																		if ((object)transform3 != null)
																																		{
																																			bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																																			nint num3 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4439 @ rcx_v139 (Il2CppMethodInfo)+38]");
																																			if ((nint)0 == 0)
																																			{
																																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																																			}
																																			Transform.SetParent_Injected(((UnityEngine.Object)transform3).m_CachedPtr, (IntPtr)0, true);
																																			_RightHand = phaserSprite16;
																																			List<Sprite> animationFrames8 = SpriteManager.GetAnimationFrames("hand_revive_", 1, 2, "enemiesM", num);
																																			PhaserSprite leftHand = _LeftHand;
																																			if ((object)_LeftHand != null && (object)leftHand._spriteAnimation != null)
																																			{
																																				leftHand._spriteAnimation.AddAnimation("idle", animationFrames8, 8, (byte)num != 0, flag2, action, autoSetAnimation);
																																				PhaserSprite leftHand2 = _LeftHand;
																																				if ((object)_LeftHand != null && (object)leftHand2._spriteAnimation != null)
																																				{
																																					leftHand2._spriteAnimation.SetAnimation("idle");
																																					PhaserSprite rightHand = _RightHand;
																																					if ((object)_RightHand != null && (object)rightHand._spriteAnimation != null)
																																					{
																																						rightHand._spriteAnimation.AddAnimation("idle", animationFrames8, 8, (byte)num != 0, flag2, action, autoSetAnimation);
																																						PhaserSprite rightHand2 = _RightHand;
																																						if ((object)_RightHand != null && (object)rightHand2._spriteAnimation != null)
																																						{
																																							rightHand2._spriteAnimation.SetAnimation("idle");
																																							TweenConfig tweenConfig = new TweenConfig();
																																							Dictionary<string, object> dictionary = new Dictionary<string, object>();
																																							object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																																							_ = 1050924810;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																							if (dictionary != null)
																																							{
																																								object value = default(object);
																																								bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_Radius1", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																								if (tweenConfig != null)
																																								{
																																									_ = 1148993536;
																																									_ = 1;
																																									_ = 4294967295L;
																																									object[] array = new object[1];
																																									if (array != null)
																																									{
																																										void* value2 = ((IntPtr*)(&array))->m_value;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																										object obj5 = default(object);
																																										bool flag6 = obj5 == null;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																										((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
																																										MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																																										if (_allTweens != null)
																																										{
																																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																											TweenConfig tweenConfig2 = new TweenConfig();
																																											Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
																																											object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																																											_ = 1050924810;
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																											if (dictionary2 != null)
																																											{
																																												object value3 = default(object);
																																												bool flag7 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_Radius2", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																												if (tweenConfig2 != null)
																																												{
																																													_ = 1150820352;
																																													_ = 1;
																																													_ = 4294967295L;
																																													object[] array2 = new object[1];
																																													if (array2 != null)
																																													{
																																														void* value4 = ((IntPtr*)(&array2))->m_value;
																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																														object obj7 = default(object);
																																														bool flag8 = obj7 == null;
																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																														((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
																																														MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																																														if (_allTweens != null)
																																														{
																																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																															TweenConfig tweenConfig3 = new TweenConfig();
																																															Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
																																															object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																																															_ = 1050924810;
																																															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																															if (dictionary3 != null)
																																															{
																																																object value5 = default(object);
																																																bool flag9 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_Radius3", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																																if (tweenConfig3 != null)
																																																{
																																																	_ = 1153048576;
																																																	_ = 1;
																																																	_ = 4294967295L;
																																																	object[] array3 = new object[1];
																																																	if (array3 != null)
																																																	{
																																																		void* value6 = ((IntPtr*)(&array3))->m_value;
																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																		object obj9 = default(object);
																																																		bool flag10 = obj9 == null;
																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																		((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
																																																		MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
																																																		if (_allTweens != null)
																																																		{
																																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																			TweenConfig tweenConfig4 = new TweenConfig();
																																																			Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
																																																			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																																																			_ = 1050924810;
																																																			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																																			if (dictionary4 != null)
																																																			{
																																																				object value7 = default(object);
																																																				bool flag11 = ((Dictionary<object, object>)(object)dictionary4).TryInsert((object)"_Radius4", value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																																				if (tweenConfig4 != null)
																																																				{
																																																					_ = 1154113536;
																																																					_ = 1;
																																																					_ = 4294967295L;
																																																					object[] array4 = new object[1];
																																																					if (array4 != null)
																																																					{
																																																						void* value8 = ((IntPtr*)(&array4))->m_value;
																																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																						object obj11 = default(object);
																																																						bool flag12 = obj11 == null;
																																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																						((UnityEngine.Object)(object)tweenConfig4).m_CachedPtr = (IntPtr)array4;
																																																						MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
																																																						if (_allTweens != null)
																																																						{
																																																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																							TweenConfig tweenConfig5 = new TweenConfig();
																																																							Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
																																																							object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																																																							_ = 1050924810;
																																																							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																																							if (dictionary5 != null)
																																																							{
																																																								object value9 = default(object);
																																																								bool flag13 = ((Dictionary<object, object>)(object)dictionary5).TryInsert((object)"_Radius5", value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																																								if (tweenConfig5 != null)
																																																								{
																																																									_ = 1156096000;
																																																									_ = 1;
																																																									_ = 4294967295L;
																																																									object[] array5 = new object[1];
																																																									if (array5 != null)
																																																									{
																																																										void* value10 = ((IntPtr*)(&array5))->m_value;
																																																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																										object obj13 = default(object);
																																																										bool flag14 = obj13 == null;
																																																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																										((UnityEngine.Object)(object)tweenConfig5).m_CachedPtr = (IntPtr)array5;
																																																										MultiTargetTween multiTargetTween5 = Tweens.Add(tweenConfig5);
																																																										if (_allTweens != null)
																																																										{
																																																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																											TweenConfig tweenConfig6 = new TweenConfig();
																																																											Dictionary<string, object> dictionary6 = new Dictionary<string, object>();
																																																											object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																																																											_ = 1050924810;
																																																											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																																											if (dictionary6 != null)
																																																											{
																																																												object value11 = default(object);
																																																												bool flag15 = ((Dictionary<object, object>)(object)dictionary6).TryInsert((object)"_Radius6", value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																																												if (tweenConfig6 != null)
																																																												{
																																																													_ = 1157836800;
																																																													_ = 1;
																																																													_ = 4294967295L;
																																																													object[] array6 = new object[1];
																																																													if (array6 != null)
																																																													{
																																																														void* value12 = ((IntPtr*)(&array6))->m_value;
																																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																														object obj15 = default(object);
																																																														bool flag16 = obj15 == null;
																																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																														((UnityEngine.Object)(object)tweenConfig6).m_CachedPtr = (IntPtr)array6;
																																																														MultiTargetTween multiTargetTween6 = Tweens.Add(tweenConfig6);
																																																														if (_allTweens != null)
																																																														{
																																																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																															TweenConfig tweenConfig7 = new TweenConfig();
																																																															Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
																																																															object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																																																															_ = 1050924810;
																																																															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																																															if (dictionary7 != null)
																																																															{
																																																																object value13 = default(object);
																																																																bool flag17 = ((Dictionary<object, object>)(object)dictionary7).TryInsert((object)"_Radius7", value13, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																																																if (tweenConfig7 != null)
																																																																{
																																																																	_ = 1158828032;
																																																																	_ = 1;
																																																																	_ = 4294967295L;
																																																																	object[] array7 = new object[1];
																																																																	if (array7 != null)
																																																																	{
																																																																		void* value14 = ((IntPtr*)(&array7))->m_value;
																																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																		object obj17 = default(object);
																																																																		bool flag18 = obj17 == null;
																																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																		((UnityEngine.Object)(object)tweenConfig7).m_CachedPtr = (IntPtr)array7;
																																																																		MultiTargetTween multiTargetTween7 = Tweens.Add(tweenConfig7);
																																																																		if (_allTweens != null)
																																																																		{
																																																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																																			TweenConfig tweenConfig8 = new TweenConfig();
																																																																			object[] array8 = new object[2];
																																																																			if (array8 != null)
																																																																			{
																																																																				if ((object)_LeftHand != null)
																																																																				{
																																																																					void* value15 = ((IntPtr*)(&array8))->m_value;
																																																																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																					object obj18 = default(object);
																																																																					bool flag19 = obj18 == null;
																																																																				}
																																																																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																				if ((object)_RightHand != null)
																																																																				{
																																																																					void* value16 = ((IntPtr*)(&array8))->m_value;
																																																																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																					object obj19 = default(object);
																																																																					bool flag20 = obj19 == null;
																																																																				}
																																																																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																				if (tweenConfig8 != null)
																																																																				{
																																																																					((UnityEngine.Object)(object)tweenConfig8).m_CachedPtr = (IntPtr)array8;
																																																																					_ = 0;
																																																																					_ = 1053609165;
																																																																					_ = 1;
																																																																					_ = 0;
																																																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
																																																																					_ = 0;
																																																																					_ = 1063675494;
																																																																					_ = 1;
																																																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
																																																																					_ = 0;
																																																																					_ = 1148846080;
																																																																					_ = 1;
																																																																					_ = 4294967295L;
																																																																					MultiTargetTween multiTargetTween8 = Tweens.Add(tweenConfig8);
																																																																					if (_allTweens != null)
																																																																					{
																																																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																																						if ((object)GM.Core != null)
																																																																						{
																																																																							PhaserScene scene = GM.Core.scene;
																																																																							if (scene != null)
																																																																							{
																																																																								PhaserScene.Renderer renderer = scene._renderer;
																																																																								if (scene._renderer != null && (object)GM.Core != null)
																																																																								{
																																																																									PhaserScene scene2 = GM.Core.scene;
																																																																									if (scene2 != null)
																																																																									{
																																																																										PhaserScene.Renderer renderer2 = scene2._renderer;
																																																																										if (scene2._renderer != null && (object)GM.Core != null)
																																																																										{
																																																																											PhaserScene scene3 = GM.Core.scene;
																																																																											if (scene3 != null)
																																																																											{
																																																																												PhaserScene.Renderer renderer3 = scene3._renderer;
																																																																												if (scene3._renderer != null && (object)GM.Core != null)
																																																																												{
																																																																													PhaserScene scene4 = GM.Core.scene;
																																																																													if (scene4 != null && scene4._renderer != null)
																																																																													{
																																																																														float y = renderer2.height * 0.5f;
																																																																														float x = renderer.width * 0.5f;
																																																																														TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, renderer3.width, num, (string)flag2, (string)(object)action);
																																																																														TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
																																																																														if ((object)GM.Core != null)
																																																																														{
																																																																															PhaserScene scene5 = GM.Core.scene;
																																																																															if (scene5 != null)
																																																																															{
																																																																																PhaserScene.Renderer renderer4 = scene5._renderer;
																																																																																if (scene5._renderer != null && (object)tileSprite != null)
																																																																																{
																																																																																	int depth = renderer4.pixelHeight - 1;
																																																																																	TileSprite stars = tileSprite.SetDepth(depth);
																																																																																	_stars1 = stars;
																																																																																	if ((object)GM.Core != null)
																																																																																	{
																																																																																		PhaserScene scene6 = GM.Core.scene;
																																																																																		if (scene6 != null)
																																																																																		{
																																																																																			PhaserScene.Renderer renderer5 = scene6._renderer;
																																																																																			if (scene6._renderer != null && (object)GM.Core != null)
																																																																																			{
																																																																																				PhaserScene scene7 = GM.Core.scene;
																																																																																				if (scene7 != null)
																																																																																				{
																																																																																					PhaserScene.Renderer renderer6 = scene7._renderer;
																																																																																					if (scene7._renderer != null && (object)GM.Core != null)
																																																																																					{
																																																																																						PhaserScene scene8 = GM.Core.scene;
																																																																																						if (scene8 != null)
																																																																																						{
																																																																																							PhaserScene.Renderer renderer7 = scene8._renderer;
																																																																																							if (scene8._renderer != null && (object)GM.Core != null)
																																																																																							{
																																																																																								PhaserScene scene9 = GM.Core.scene;
																																																																																								if (scene9 != null && scene9._renderer != null)
																																																																																								{
																																																																																									float y2 = renderer6.height * 0.5f;
																																																																																									float x2 = renderer5.width * 0.5f;
																																																																																									TileSprite component2 = RenderingExtensions.AddTileSprite(this, x2, y2, renderer7.width, num, (string)flag2, (string)(object)action);
																																																																																									TileSprite tileSprite2 = RenderingExtensions.SetScrollFactor(component2, 0f);
																																																																																									if ((object)GM.Core != null)
																																																																																									{
																																																																																										PhaserScene scene10 = GM.Core.scene;
																																																																																										if (scene10 != null)
																																																																																										{
																																																																																											PhaserScene.Renderer renderer8 = scene10._renderer;
																																																																																											if (scene10._renderer != null && (object)tileSprite2 != null)
																																																																																											{
																																																																																												int depth2 = renderer8.pixelHeight - 1;
																																																																																												TileSprite stars2 = tileSprite2.SetDepth(depth2);
																																																																																												_stars2 = stars2;
																																																																																												if ((object)base._spriteRenderer != null)
																																																																																												{
																																																																																													GameObject gameObject10 = base._spriteRenderer.gameObject;
																																																																																													if ((object)gameObject10 != null)
																																																																																													{
																																																																																														SpriteMask spriteMask = gameObject10.AddComponent<SpriteMask>();
																																																																																														_spriteMask = spriteMask;
																																																																																														Transform stars3 = (Transform)(object)_stars1;
																																																																																														if ((object)_stars1 != null)
																																																																																														{
																																																																																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rsi_v54 (UnityEngine.Transform)+28]");
																																																																																															Transform transform4 = (Transform)0;
																																																																																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rsi_v54 (UnityEngine.Transform)+28]");
																																																																																															if ((nint)0 != 0)
																																																																																															{
																																																																																																bool flag21 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																																																																																																SpriteRenderer.set_maskInteraction_Injected(((UnityEngine.Object)transform4).m_CachedPtr, SpriteMaskInteraction.VisibleInsideMask);
																																																																																																Transform stars4 = (Transform)(object)_stars2;
																																																																																																if ((object)_stars2 != null)
																																																																																																{
																																																																																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rsi_v56 (UnityEngine.Transform)+28]");
																																																																																																	Transform transform5 = (Transform)0;
																																																																																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rsi_v56 (UnityEngine.Transform)+28]");
																																																																																																	if ((nint)0 != 0)
																																																																																																	{
																																																																																																		bool flag22 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
																																																																																																		SpriteRenderer.set_maskInteraction_Injected(((UnityEngine.Object)transform5).m_CachedPtr, SpriteMaskInteraction.VisibleInsideMask);
																																																																																																		TweenConfig tweenConfig9 = new TweenConfig();
																																																																																																		object[] array9 = new object[1];
																																																																																																		if (array9 != null)
																																																																																																		{
																																																																																																			if ((object)_stars2 != null)
																																																																																																			{
																																																																																																				TileSprite tileSprite3 = RenderingExtensions.SetScrollFactor(_stars2, 0f);
																																																																																																				bool flag23 = (object)tileSprite3 == null;
																																																																																																			}
																																																																																																			TileSprite tileSprite4 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array9, 0f, (byte)(int)_stars2 != 0);
																																																																																																			if (tweenConfig9 != null)
																																																																																																			{
																																																																																																				((UnityEngine.Object)(object)tweenConfig9).m_CachedPtr = (IntPtr)array9;
																																																																																																				_ = 0;
																																																																																																				_ = 1058642330;
																																																																																																				_ = 1;
																																																																																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
																																																																																																				_ = 0;
																																																																																																				_ = 1148846080;
																																																																																																				_ = 1;
																																																																																																				_ = 4294967295L;
																																																																																																				MultiTargetTween multiTargetTween9 = Tweens.Add(tweenConfig9);
																																																																																																				if (_allTweens != null)
																																																																																																				{
																																																																																																					TileSprite tileSprite5 = RenderingExtensions.SetScrollFactor((TileSprite)(object)_allTweens, 0f, (byte)(int)_stars2 != 0);
																																																																																																					TweenConfig tweenConfig10 = new TweenConfig();
																																																																																																					object[] array10 = new object[1];
																																																																																																					if (array10 != null)
																																																																																																					{
																																																																																																						if ((object)_stars1 != null)
																																																																																																						{
																																																																																																							TileSprite tileSprite6 = RenderingExtensions.SetScrollFactor(_stars1, 0f, (byte)(int)_stars2 != 0);
																																																																																																							bool flag24 = (object)tileSprite6 == null;
																																																																																																						}
																																																																																																						TileSprite tileSprite7 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array10, 0f, (byte)(int)_stars1 != 0);
																																																																																																						bool flag25 = tweenConfig10 == null;
																																																																																																						((UnityEngine.Object)(object)tweenConfig10).m_CachedPtr = (IntPtr)array10;
																																																																																																						_ = 0;
																																																																																																						_ = 1058642330;
																																																																																																						_ = 1;
																																																																																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
																																																																																																						_ = 0;
																																																																																																						_ = 1148846080;
																																																																																																						_ = 1140457472;
																																																																																																						_ = 1;
																																																																																																						_ = 4294967295L;
																																																																																																						MultiTargetTween multiTargetTween10 = Tweens.Add(tweenConfig10);
																																																																																																						bool flag26 = _allTweens == null;
																																																																																																						TileSprite tileSprite8 = RenderingExtensions.SetScrollFactor((TileSprite)(object)_allTweens, 0f, (byte)(int)_stars1 != 0);
																																																																																																						List<Sprite> animationFrames9 = SpriteManager.GetAnimationFrames("v_i", 1, 4, "enemiesM", num);
																																																																																																						bool flag27 = (object)base._spriteAnimation == null;
																																																																																																						base._spriteAnimation.AddAnimation("idle", animationFrames9, 12, (byte)num != 0, flag2, action, autoSetAnimation);
																																																																																																						bool flag28 = (object)base._spriteAnimation == null;
																																																																																																						base._spriteAnimation.SetAnimation("idle");
																																																																																																						SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(base._spriteRenderer, 5f);
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
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0b07: Expected O, but got I4
		//IL_0b72: Expected O, but got Ref
		//IL_0be5: Expected O, but got Ref
		//IL_0c14: Expected O, but got I
		//IL_0c31: Expected O, but got I
		//IL_0273: Expected O, but got I
		//IL_07a9: Expected O, but got I
		//IL_0cb2: Expected O, but got Ref
		//IL_0d15: Expected O, but got Ref
		//IL_0833: Expected O, but got I
		//IL_0d78: Expected O, but got Ref
		//IL_087b: Expected O, but got I
		//IL_0ddb: Expected O, but got Ref
		//IL_08c3: Expected O, but got I
		//IL_0e3e: Expected O, but got Ref
		//IL_090b: Expected O, but got I
		//IL_0ea1: Expected O, but got Ref
		//IL_0953: Expected O, but got I
		//IL_0f04: Expected O, but got Ref
		//IL_09a6: Expected O, but got I
		//IL_09d4: Expected O, but got I
		//IL_04db->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_055d->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_023e->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_059d->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_0617->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_0ba8->IL0a38: Incompatible stack heights: 2 vs 0
		//IL_0697->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_06d6->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_0c81->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_070f->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_0291->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_0754->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_0794->IL0a38: Incompatible stack heights: 1 vs 0
		//IL_0300->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_032c->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_03c8->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_03f7->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_0425->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_045d->IL0a38: Incompatible stack heights: 3 vs 0
		//IL_0496->IL05d2: Incompatible stack heights: 3 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		PhaserSprite phaserSprite = setAlpha(1f);
		PhaserSprite phaserSprite2 = setTint(16777215u);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(base._spriteRenderer, 5f);
		Transform transform = base.transform;
		Camera main = Camera.main;
		object obj3;
		float num5;
		float num6;
		float num7;
		if ((object)main != null)
		{
			Transform parent = main.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				float2 float5 = base.position;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
						{
							PhaserScene s_scene3 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && s_scene3._renderer != null)
							{
								float deltaTime = PauseSystem.DeltaTime;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BE70");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
								UpdateDepths();
								float2 float6 = base.position;
								SpriteRenderer spriteRenderer2 = base._spriteRenderer;
								if ((object)base._spriteRenderer != null)
								{
									bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
									obj3 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr);
									Transform protectionTarget = _protectionTarget;
									if ((object)_protectionTarget != null && ((UnityEngine.Object)protectionTarget).m_CachedPtr != (IntPtr)0)
									{
										Transform protectionTarget2 = _protectionTarget;
										if ((object)_protectionTarget != null)
										{
											_ = 0;
											_ = 0;
											bool flag2 = ((UnityEngine.Object)protectionTarget2).m_CachedPtr == (IntPtr)0;
											object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
											Transform.get_position_Injected(((UnityEngine.Object)protectionTarget2).m_CachedPtr, out *(Vector3*)obj4);
											Transform projectileToBlock = _projectileToBlock;
											if ((object)_projectileToBlock != null)
											{
												_ = 0;
												_ = 0;
												bool flag3 = ((UnityEngine.Object)projectileToBlock).m_CachedPtr == (IntPtr)0;
												object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
												Transform.get_position_Injected(((UnityEngine.Object)projectileToBlock).m_CachedPtr, out *(Vector3*)obj5);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-79]");
												nint num = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
												object obj6 = num - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-75]");
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
												object obj7 = num2 - 0;
												float2 float7 = BlockPosition();
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
												_ = 0;
												_ = 1056964608;
												_ = 1;
												if ((object)_LeftHand != null)
												{
													PhaserSprite leftHand = _LeftHand;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
													PhaserSprite phaserSprite3 = leftHand.setOrigin(0.5f, (float?)(object)0);
													if ((object)_LeftHand != null)
													{
														float2 float8 = _LeftHand.position;
														float deltaTime2 = PauseSystem.DeltaTime;
														float num3 = deltaTime2 * 4f;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BE70");
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
														if ((object)_LeftHand != null)
														{
															Transform transform2 = _LeftHand.transform;
															if ((object)transform2 != null)
															{
																Vector3 localEulerAngles = transform2.localEulerAngles;
																float deltaTime3 = PauseSystem.DeltaTime;
																float maxDelta = deltaTime3 * 145f;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
																float target = (float)obj7 * 57.29578f;
																float num4 = Mathf.MoveTowardsAngle(localEulerAngles.z, target, maxDelta);
																_LeftHand.angle = num4;
																PhaserSprite leftHand2 = _LeftHand;
																if ((object)_LeftHand != null)
																{
																	SpriteAnimation spriteAnimation = leftHand2._spriteAnimation;
																	if ((object)leftHand2._spriteAnimation != null)
																	{
																		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
																		if ((object)_LeftHand != null)
																		{
																			PhaserSprite phaserSprite4 = _LeftHand.setFrame("hand_clap_L", "enemiesM");
																			if ((object)_LeftHand != null)
																			{
																				PhaserSprite phaserSprite5 = _LeftHand.setDepth(6000);
																				num5 = 0.59999996f;
																				num6 = 0.2f;
																				num7 = 2f;
																				goto IL_05d2;
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
									else
									{
										float num8 = UnityEngine.Random.Range(-0.015f, 0.015f);
										float num9 = UnityEngine.Random.Range(-0.015f, 0.015f);
										if ((object)_LeftHand != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
											float num10 = 0f + 0.2f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
											float num11 = 0f - 0.59999996f;
											float y = num10 + num9;
											float x = num11 + num8;
											PhaserSprite phaserSprite6 = _LeftHand.setPosition(x, y);
											if ((object)phaserSprite6 != null)
											{
												float depth = (float)obj3 + 2f;
												PhaserSprite phaserSprite7 = phaserSprite6.setDepth(depth);
												if ((object)_LeftHand != null)
												{
													_LeftHand.angle = -90f;
													num5 = 0.59999996f;
													num6 = 0.2f;
													num7 = 2f;
													goto IL_05d2;
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
		goto IL_0a38;
		IL_05d2:
		float num12 = UnityEngine.Random.Range(-0.015f, 0.015f);
		float num13 = UnityEngine.Random.Range(-0.015f, 0.015f);
		if ((object)_RightHand != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
			float num14 = 0f + num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			float num15 = 0f + num5;
			float y2 = num14 + num13;
			float x2 = num15 + num12;
			PhaserSprite phaserSprite8 = _RightHand.setPosition(x2, y2);
			if ((object)phaserSprite8 != null)
			{
				float depth2 = (float)obj3 + num7;
				PhaserSprite phaserSprite9 = phaserSprite8.setDepth(depth2);
				if ((object)_RightHand != null)
				{
					_RightHand.angle = 90f;
					PhaserSprite leftHand3 = _LeftHand;
					if ((object)_LeftHand != null)
					{
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(leftHand3._spriteRenderer, 16777215u);
						PhaserSprite rightHand = _RightHand;
						if ((object)_RightHand != null)
						{
							SpriteRenderer spriteRenderer4 = RenderingExtensions.SetTint(rightHand._spriteRenderer, 16777215u);
							Transform eye = (Transform)(object)_eye1;
							if ((object)_eye1 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdi_v36 (UnityEngine.Transform)+28]");
								Transform transform3 = (Transform)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdi_v36 (UnityEngine.Transform)+28]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Color*)obj8);
								PhaserSprite eye2 = _eye2;
								bool flag6 = (object)_eye2 == null;
								Transform spriteRenderer5 = (Transform)(object)eye2._spriteRenderer;
								bool flag7 = (object)eye2._spriteRenderer == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								bool flag8 = ((UnityEngine.Object)spriteRenderer5).m_CachedPtr == (IntPtr)0;
								object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer5).m_CachedPtr, ref *(Color*)obj9);
								Transform eye3 = (Transform)(object)_eye3;
								bool flag9 = (object)_eye3 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2740 @ rdi_v40 (UnityEngine.Transform)+28]");
								Transform transform4 = (Transform)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2740 @ rdi_v40 (UnityEngine.Transform)+28]");
								bool flag10 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								bool flag11 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Color*)obj10);
								Transform eye4 = (Transform)(object)_eye4;
								bool flag12 = (object)_eye4 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ rdi_v42 (UnityEngine.Transform)+28]");
								Transform transform5 = (Transform)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ rdi_v42 (UnityEngine.Transform)+28]");
								bool flag13 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								bool flag14 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
								object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Color*)obj11);
								Transform eye5 = (Transform)(object)_eye5;
								bool flag15 = (object)_eye5 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2350 @ rdi_v44 (UnityEngine.Transform)+28]");
								Transform transform6 = (Transform)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2350 @ rdi_v44 (UnityEngine.Transform)+28]");
								bool flag16 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								bool flag17 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
								object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Color*)obj12);
								Transform eye6 = (Transform)(object)_eye6;
								bool flag18 = (object)_eye6 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2202 @ rdi_v46 (UnityEngine.Transform)+28]");
								Transform transform7 = (Transform)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2202 @ rdi_v46 (UnityEngine.Transform)+28]");
								bool flag19 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								bool flag20 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
								object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Color*)obj13);
								Transform eye7 = (Transform)(object)_eye7;
								bool flag21 = (object)_eye7 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2084 @ rdi_v48 (UnityEngine.Transform)+28]");
								Transform transform8 = (Transform)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2084 @ rdi_v48 (UnityEngine.Transform)+28]");
								bool flag22 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								bool flag23 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
								object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Color*)obj14);
								Transform stars = (Transform)(object)_stars1;
								bool flag24 = (object)_stars1 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1889 @ rdi_v50 (UnityEngine.Transform)+28]");
								SpriteRenderer spriteRenderer6 = RenderingExtensions.SetTint((SpriteRenderer)0, 16777215u);
								Transform stars2 = (Transform)(object)_stars2;
								bool flag25 = (object)_stars2 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1891 @ rdi_v52 (UnityEngine.Transform)+28]");
								SpriteRenderer spriteRenderer7 = RenderingExtensions.SetTint((SpriteRenderer)0, 16777215u);
								UpdateMaskPositions();
								bool flag26 = (object)base._spriteRenderer == null;
								Sprite sprite = base._spriteRenderer.sprite;
								bool flag27 = (object)_spriteMask == null;
								_spriteMask.sprite = sprite;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0a38;
		IL_0a38:
		throw new NullReferenceException();
	}

	private void UpdateDirecterSubObjects()
	{
		UpdateDepths();
		UpdateMaskPositions();
	}

	private void UpdateDepths()
	{
		//IL_0010: Invalid comparison between F4 and I4
		//IL_0066: Expected O, but got I4
		//IL_009d: Invalid comparison between F4 and I4
		//IL_00f3: Expected O, but got I4
		//IL_012a: Invalid comparison between F4 and I4
		//IL_0180: Expected O, but got I4
		//IL_01b7: Invalid comparison between F4 and I4
		//IL_020d: Expected O, but got I4
		//IL_0244: Invalid comparison between F4 and I4
		//IL_029a: Expected O, but got I4
		//IL_02d1: Invalid comparison between F4 and I4
		//IL_0327: Expected O, but got I4
		//IL_035e: Invalid comparison between F4 and I4
		//IL_0396: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int num = default(int);
		PhaserSprite phaserSprite = setDepth(num);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (!(_myAngle1 < 0f))
		{
			float num2 = 1f;
		}
		else
		{
			float num2 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		int num3 = num << 6;
		object obj = num3 + 73;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int num4 = default(int);
		PhaserSprite phaserSprite2 = _eye1.setDepth(num4);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (!(_myAngle2 < 0f))
		{
			float num5 = 1f;
		}
		else
		{
			float num5 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		int num6 = num4 << 6;
		object obj2 = num6 + 73;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int num7 = default(int);
		PhaserSprite phaserSprite3 = _eye2.setDepth(num7);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (!(_myAngle3 < 0f))
		{
			float num8 = 1f;
		}
		else
		{
			float num8 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		int num9 = num7 << 6;
		object obj3 = num9 + 73;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int num10 = default(int);
		PhaserSprite phaserSprite4 = _eye3.setDepth(num10);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (!(_myAngle4 < 0f))
		{
			float num11 = 1f;
		}
		else
		{
			float num11 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		int num12 = num10 << 6;
		object obj4 = num12 + 73;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int num13 = default(int);
		PhaserSprite phaserSprite5 = _eye4.setDepth(num13);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (!(_myAngle5 < 0f))
		{
			float num14 = 1f;
		}
		else
		{
			float num14 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		int num15 = num13 << 6;
		object obj5 = num15 + 73;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int num16 = default(int);
		PhaserSprite phaserSprite6 = _eye5.setDepth(num16);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (!(_myAngle6 < 0f))
		{
			float num17 = 1f;
		}
		else
		{
			float num17 = -1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		int num18 = num16 << 6;
		object obj6 = num18 + 73;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int num19 = default(int);
		PhaserSprite phaserSprite7 = _eye6.setDepth(num19);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (_myAngle7 < 0f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
		int num20 = num19 << 6;
		object obj7 = num20 + 73;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
		int depth = default(int);
		PhaserSprite phaserSprite8 = _eye7.setDepth(depth);
		TileSprite stars = _stars1;
		int sortingOrder = num + 1;
		stars._spriteRenderer.sortingOrder = sortingOrder;
		TileSprite stars2 = _stars2;
		int sortingOrder2 = num + 1;
		stars2._spriteRenderer.sortingOrder = sortingOrder2;
	}

	private void UpdateMaskPositions()
	{
		//IL_0983: Expected O, but got F4
		//IL_005e: Expected O, but got F4
		//IL_00d7: Invalid comparison between I4 and F4
		//IL_0122: Expected F4, but got I4
		//IL_015b: Expected O, but got I4
		//IL_01cd: Expected O, but got F4
		//IL_0236: Invalid comparison between I4 and F4
		//IL_0281: Expected F4, but got I4
		//IL_02aa: Expected O, but got I4
		//IL_031c: Expected O, but got F4
		//IL_0385: Invalid comparison between I4 and F4
		//IL_03d0: Expected F4, but got I4
		//IL_0409: Expected O, but got I4
		//IL_047b: Expected O, but got F4
		//IL_04e4: Invalid comparison between I4 and F4
		//IL_052f: Expected F4, but got I4
		//IL_0568: Expected O, but got I4
		//IL_05da: Expected O, but got F4
		//IL_0643: Invalid comparison between I4 and F4
		//IL_068e: Expected F4, but got I4
		//IL_06c7: Expected O, but got I4
		//IL_0739: Expected O, but got F4
		//IL_07a2: Invalid comparison between I4 and F4
		//IL_07ed: Expected F4, but got I4
		//IL_0816: Expected O, but got I4
		//IL_0888: Expected O, but got F4
		//IL_08f1: Invalid comparison between I4 and F4
		//IL_093c: Expected F4, but got I4
		//IL_0975: Expected O, but got I4
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float num = (float)obj2 * 1000f;
		float num2 = num * 0.4f;
		float num3 = num2 * _angleUnit;
		float num4 = num2 * _angleUnit;
		float myAngle = num3 + _myAngle1;
		float num5 = num2 * _angleUnit;
		float myAngle2 = num4 + _myAngle3;
		float myAngle3 = num5 + _myAngle2;
		_myAngle1 = myAngle;
		float num6 = num2 * _angleUnit;
		_myAngle3 = myAngle2;
		float num7 = num2 * _angleUnit;
		float myAngle4 = num6 + _myAngle4;
		_myAngle2 = myAngle3;
		float myAngle5 = num7 + _myAngle5;
		_myAngle4 = myAngle4;
		float num8 = num2 * _angleUnit;
		float num9 = num2 * _angleUnit;
		float myAngle6 = num8 + _myAngle6;
		_myAngle5 = myAngle5;
		float myAngle7 = num9 + _myAngle7;
		_myAngle6 = myAngle6;
		_myAngle7 = myAngle7;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num10 = _myAngle1 * 1.0799999f;
		float x = num10 + (float)float5;
		_eye1.X = x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		object obj3 = _Radius2 ^ -0f;
		object obj4 = default(object);
		float num11 = (float)obj4 + 0.64f;
		float num12 = _myAngle2 * (float)obj3;
		float y = num12 + num11;
		_eye1.Y = y;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num13 = _myAngle1 * 0.5f;
		float num14 = num13 + 0.5f;
		if (!(0f > num14))
		{
			if (num14 > 1f)
			{
				num14 = 1f;
			}
		}
		else
		{
			num14 = 0f;
		}
		float num15 = num14 * 1.5f;
		float xScale = num15 + 0.5f;
		PhaserSprite phaserSprite = _eye1.setScale(xScale, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num16 = _myAngle2 * 1.0799999f;
		float x2 = num16 + (float)float5;
		_eye2.X = x2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num17 = (float)obj4 + 0.64f;
		object obj5 = _Radius4 ^ -0f;
		float num18 = _myAngle3 * (float)obj5;
		float y2 = num18 + num17;
		_eye2.Y = y2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num19 = _myAngle2 * 0.5f;
		float num20 = num19 + 0.5f;
		if (!(0f > num20))
		{
			if (num20 > 1f)
			{
				num20 = 1f;
			}
		}
		else
		{
			num20 = 0f;
		}
		float xScale2 = num20 + 0.75f;
		PhaserSprite phaserSprite2 = _eye2.setScale(xScale2, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num21 = _myAngle3 * 1.0799999f;
		float x3 = num21 + (float)float5;
		_eye3.X = x3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num22 = (float)obj4 + 0.64f;
		object obj6 = _Radius6 ^ -0f;
		float num23 = _myAngle4 * (float)obj6;
		float y3 = num23 + num22;
		_eye3.Y = y3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num24 = _myAngle3 * 0.5f;
		float num25 = num24 + 0.5f;
		if (!(0f > num25))
		{
			if (num25 > 1f)
			{
				num25 = 1f;
			}
		}
		else
		{
			num25 = 0f;
		}
		float num26 = num25 * 0.5f;
		float xScale3 = num26 + 1f;
		PhaserSprite phaserSprite3 = _eye3.setScale(xScale3, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num27 = _myAngle4 * 1.0799999f;
		float x4 = num27 + (float)float5;
		_eye4.X = x4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num28 = (float)obj4 + 0.64f;
		object obj7 = _Radius1 ^ -0f;
		float num29 = _myAngle5 * (float)obj7;
		float y4 = num29 + num28;
		_eye4.Y = y4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num30 = _myAngle4 * 0.5f;
		float num31 = num30 + 0.5f;
		if (!(0f > num31))
		{
			if (num31 > 1f)
			{
				num31 = 1f;
			}
		}
		else
		{
			num31 = 0f;
		}
		float num32 = num31 * 0f;
		float xScale4 = num32 + 1.25f;
		PhaserSprite phaserSprite4 = _eye4.setScale(xScale4, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num33 = _myAngle5 * 1.0799999f;
		float x5 = num33 + (float)float5;
		_eye5.X = x5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num34 = (float)obj4 + 0.64f;
		object obj8 = _Radius3 ^ -0f;
		float num35 = _myAngle6 * (float)obj8;
		float y5 = num35 + num34;
		_eye5.Y = y5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num36 = _myAngle5 * 0.5f;
		float num37 = num36 + 0.5f;
		if (!(0f > num37))
		{
			if (num37 > 1f)
			{
				num37 = 1f;
			}
		}
		else
		{
			num37 = 0f;
		}
		float num38 = num37 * 0.5f;
		float xScale5 = num38 + 1f;
		PhaserSprite phaserSprite5 = _eye5.setScale(xScale5, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num39 = _myAngle6 * 1.0799999f;
		float x6 = num39 + (float)float5;
		_eye6.X = x6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num40 = (float)obj4 + 0.64f;
		object obj9 = _Radius5 ^ -0f;
		float num41 = _myAngle7 * (float)obj9;
		float y6 = num41 + num40;
		_eye6.Y = y6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num42 = _myAngle6 * 0.5f;
		float num43 = num42 + 0.5f;
		if (!(0f > num43))
		{
			if (num43 > 1f)
			{
				num43 = 1f;
			}
		}
		else
		{
			num43 = 0f;
		}
		float xScale6 = num43 + 0.75f;
		PhaserSprite phaserSprite6 = _eye6.setScale(xScale6, (float?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num44 = _myAngle7 * 1.0799999f;
		float x7 = num44 + (float)float5;
		_eye7.X = x7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num45 = (float)obj4 + 0.64f;
		object obj10 = _Radius7 ^ -0f;
		float num46 = _myAngle1 * (float)obj10;
		float y7 = num46 + num45;
		_eye7.Y = y7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num47 = _myAngle7 * 0.5f;
		float num48 = num47 + 0.5f;
		if (!(0f > num48))
		{
			if (num48 > 1f)
			{
				num48 = 1f;
			}
		}
		else
		{
			num48 = 0f;
		}
		float num49 = num48 * 1.5f;
		float xScale7 = num49 + 0.5f;
		PhaserSprite phaserSprite7 = _eye7.setScale(xScale7, (float?)(object)0);
	}

	protected override void OnDestroy()
	{
		//IL_007d: Expected I4, but got O
		//IL_007d: Expected O, but got I
		bool flag = _allTweens == null;
		PhaserSprite phaserSprite = this;
		if (!flag)
		{
			List<MultiTargetTween>.Enumerator enumerator = default(List<MultiTargetTween>.Enumerator);
			while (enumerator.MoveNext())
			{
			}
			phaserSprite = (PhaserSprite)(object)_allTweens;
			if (_allTweens != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v2 (VampireSurvivors.Framework.Phaser.PhaserSprite)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)phaserSprite).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)phaserSprite).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)phaserSprite).m_CachedPtr, 0, (int)((MonoBehaviour)phaserSprite).m_CancellationTokenSource);
				}
				PhaserSprite eye = _eye1;
				if ((object)_eye1 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _eye1;
					if ((object)_eye1 == null)
					{
						goto IL_0598;
					}
					_eye1.destroy();
				}
				PhaserSprite eye2 = _eye2;
				if ((object)_eye2 != null && ((UnityEngine.Object)eye2).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _eye2;
					if ((object)_eye2 == null)
					{
						goto IL_0598;
					}
					_eye2.destroy();
				}
				PhaserSprite eye3 = _eye3;
				if ((object)_eye3 != null && ((UnityEngine.Object)eye3).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _eye3;
					if ((object)_eye3 == null)
					{
						goto IL_0598;
					}
					_eye3.destroy();
				}
				PhaserSprite eye4 = _eye4;
				if ((object)_eye4 != null && ((UnityEngine.Object)eye4).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _eye4;
					if ((object)_eye4 == null)
					{
						goto IL_0598;
					}
					_eye4.destroy();
				}
				PhaserSprite eye5 = _eye5;
				if ((object)_eye5 != null && ((UnityEngine.Object)eye5).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _eye5;
					if ((object)_eye5 == null)
					{
						goto IL_0598;
					}
					_eye5.destroy();
				}
				PhaserSprite eye6 = _eye6;
				if ((object)_eye6 != null && ((UnityEngine.Object)eye6).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _eye6;
					if ((object)_eye6 == null)
					{
						goto IL_0598;
					}
					_eye6.destroy();
				}
				PhaserSprite eye7 = _eye7;
				if ((object)_eye7 != null && ((UnityEngine.Object)eye7).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _eye7;
					if ((object)_eye7 == null)
					{
						goto IL_0598;
					}
					_eye7.destroy();
				}
				PhaserSprite leftHand = _LeftHand;
				if ((object)_LeftHand != null && ((UnityEngine.Object)leftHand).m_CachedPtr != (IntPtr)0)
				{
					phaserSprite = _LeftHand;
					if ((object)_LeftHand == null)
					{
						goto IL_0598;
					}
					_LeftHand.destroy();
				}
				PhaserSprite rightHand = _RightHand;
				if ((object)_RightHand != null && ((UnityEngine.Object)rightHand).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_RightHand == null)
					{
						goto IL_0598;
					}
					_RightHand.destroy();
				}
				TileSprite stars = _stars1;
				if ((object)_stars1 != null && ((UnityEngine.Object)stars).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_stars1 == null)
					{
						goto IL_0598;
					}
					_stars1.destroy();
				}
				TileSprite stars2 = _stars2;
				if ((object)_stars2 == null || ((UnityEngine.Object)stars2).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if ((object)_stars2 != null)
				{
					_stars2.destroy();
					return;
				}
			}
		}
		goto IL_0598;
		IL_0598:
		throw new NullReferenceException();
	}

	public void StartBlockCutscene()
	{
		_003C_BlockCutscene_003Ed__40 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private float BlockDistance()
	{
		return 0.2f;
	}

	private float2 BlockPosition()
	{
		//IL_0098->IL003d: Incompatible stack heights: 1 vs 0
		Transform projectileToBlock = _projectileToBlock;
		if ((object)_projectileToBlock != null)
		{
			bool flag = ((UnityEngine.Object)projectileToBlock).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)projectileToBlock).m_CachedPtr, out Vector3 _);
			Transform protectionTarget = _protectionTarget;
			if ((object)_protectionTarget != null)
			{
				bool flag2 = ((UnityEngine.Object)protectionTarget).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)protectionTarget).m_CachedPtr, out Vector3 _);
				float2 result = default(float2);
				return result;
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator _BlockCutscene()
	{
		_003C_BlockCutscene_003Ed__40 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void BreakSomething(PhaserSprite thing)
	{
		//IL_002e: Expected O, but got I4
		//IL_00d9: Expected O, but got F4
		//IL_0087: Expected O, but got Ref
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass41_0();
		CS_0024_003C_003E8__locals3.thing = thing;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * -600f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 0f, 10, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj3 = default(object);
		PhaserSprite phaserSprite = CS_0024_003C_003E8__locals3.thing.setTintFill(isEnabled: true, (Color?)(object)(&obj3));
		TweenCallback onComplete = delegate
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("MaskBreakingShake");
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals3.thing.setVisible(visible: false);
		};
		Tween tween = UITimerHelper.RegisterMillis(120f, onComplete);
	}

	private unsafe void BreakMask(PhaserSprite mask)
	{
		//IL_002e: Expected O, but got I4
		//IL_00d9: Expected O, but got F4
		//IL_0087: Expected O, but got Ref
		_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass42_0();
		CS_0024_003C_003E8__locals4.mask = mask;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * -600f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 0f, 10, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj3 = default(object);
		PhaserSprite phaserSprite = CS_0024_003C_003E8__locals4.mask.setTintFill(isEnabled: true, (Color?)(object)(&obj3));
		TweenCallback onComplete = delegate
		{
			//IL_0023: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj4 = default(object);
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals4.mask.setTintFill(isEnabled: false, (Color?)(object)(&obj4));
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("MaskBreakingShake");
			PhaserSprite mask2 = CS_0024_003C_003E8__locals4.mask;
			mask2._spriteAnimation.SetAnimation("explode");
		};
		Tween tween = UITimerHelper.RegisterMillis(120f, onComplete);
	}

	public DeathFightDirecter()
	{
		//IL_002b: Expected I, but got O
		_angleUnit = (float)Math.PI / 360f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
