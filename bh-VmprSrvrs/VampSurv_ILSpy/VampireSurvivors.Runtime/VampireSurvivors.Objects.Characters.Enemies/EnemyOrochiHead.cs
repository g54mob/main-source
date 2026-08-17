using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Curves;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyOrochiHead : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public SpriteRenderer s;

		public TweenCallback _003C_003E9__1;

		internal void _003CSingleWarning_003Eb__0()
		{
			//IL_003e: Expected I, but got O
			//IL_0094: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = s.transform;
			if ((object)transform != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.duration = 200f;
			tweenConfig.delay = 200f;
			TweenCallback onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					UnityEngine.Object.Destroy(s, 0f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CSingleWarning_003Eb__1()
		{
			UnityEngine.Object.Destroy(s, 0f);
		}
	}

	private TrailRenderer _Trail;

	private float _minAngleRotDeg;

	private float _maxAngleRotDeg;

	private float _angleRng;

	private float _attackTime;

	private float _attackDelay;

	private const float ATTACK_DELAY = 5000f;

	private int _headIndex;

	private Vector2 _targetVector;

	private Vector2 _startingPosition;

	private Vector2 _currentVector;

	public float _AttackLerp;

	private Vector2 _neckPosition;

	private MultiTargetTween _attackTween;

	private MultiTargetTween _retreatTween;

	private MultiTargetTween _fadeTrailTween;

	private Vector2 _headOffset;

	private Vector2 _invHeadOffset;

	private EnemyOrochimario _trueOwner;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0037: Expected I, but got O
		//IL_00d6: Expected I, but got O
		//IL_0072: Expected I, but got O
		//IL_0111: Expected I, but got O
		//IL_00a8: Expected O, but got F4
		//IL_0158: Expected O, but got F4
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		_angleRng = 0f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v4 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_targetVector = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v6 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_startingPosition = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num5 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num6 = 0;
		_currentVector = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v10 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		_neckPosition = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		base._003CIsCullable_003Ek__BackingField = false;
		InitTrail();
		object obj = UnityEngine.Random.value;
		float num9 = (_attackTime = (float)Vector2.zeroVector * 5000f);
		object obj2 = UnityEngine.Random.value;
		float num10 = num9 * 5000f;
		float attackDelay = num10 + 5000f;
		_attackDelay = attackDelay;
		SetRandomStartingPosition();
	}

	private unsafe void InitTrail()
	{
		//IL_021b: Expected O, but got Ref
		//IL_03d1->IL034d: Incompatible stack heights: 1 vs 0
		//IL_041c->IL034d: Incompatible stack heights: 2 vs 0
		//IL_00e7->IL034d: Incompatible stack heights: 2 vs 0
		//IL_0138->IL034d: Incompatible stack heights: 2 vs 0
		//IL_0476->IL034d: Incompatible stack heights: 3 vs 0
		//IL_04d0->IL034d: Incompatible stack heights: 4 vs 0
		//IL_052a->IL034d: Incompatible stack heights: 5 vs 0
		//IL_0584->IL034d: Incompatible stack heights: 6 vs 0
		//IL_01d8->IL034d: Incompatible stack heights: 6 vs 0
		//IL_0204->IL034d: Incompatible stack heights: 6 vs 0
		//IL_0235->IL034d: Incompatible stack heights: 6 vs 0
		//IL_0261->IL034d: Incompatible stack heights: 6 vs 0
		//IL_02af->IL034d: Incompatible stack heights: 6 vs 0
		//IL_05d4->IL034d: Incompatible stack heights: 7 vs 0
		//IL_02f7->IL034d: Incompatible stack heights: 7 vs 0
		//IL_0325->IL034d: Incompatible stack heights: 7 vs 0
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null && currentEnemyData._003CflagName_003Ek__BackingField != null)
		{
			string spriteName = currentEnemyData._003CflagName_003Ek__BackingField.Replace(".png", "");
			EnemyData currentEnemyData2 = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				Sprite sprite = SpriteManager.GetSprite(spriteName, currentEnemyData2._003CtextureName_003Ek__BackingField);
				if ((object)sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
					string trail = (string)(object)_Trail;
					if ((object)_Trail != null)
					{
						bool flag2 = trail._stringLength == 0;
						TrailRenderer.Clear_Injected((IntPtr)trail._stringLength);
						if ((object)_Trail != null)
						{
							_Trail.emitting = true;
							if ((object)_Trail != null)
							{
								Material material = ((Renderer)_Trail).GetMaterial();
								Material material2 = new Material(material);
								Texture2D texture = sprite.texture;
								if ((object)material2 != null)
								{
									material2.mainTexture = texture;
									((Renderer)_Trail).SetMaterial(material2);
									bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
									Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
									Texture2D texture2 = sprite.texture;
									if ((object)texture2 != null)
									{
										int width = texture2.width;
										bool flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
										Texture2D texture3 = sprite.texture;
										if ((object)texture3 != null)
										{
											int height = texture3.height;
											bool flag5 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
											Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
											Texture2D texture4 = sprite.texture;
											if ((object)texture4 != null)
											{
												int width2 = texture4.width;
												bool flag6 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
												Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret5);
												Texture2D texture5 = sprite.texture;
												if ((object)texture5 != null)
												{
													int height2 = texture5.height;
													if ((object)_Trail != null)
													{
														Material material3 = ((Renderer)_Trail).GetMaterial();
														if ((object)material3 != null)
														{
															material3.SetVector("_SpriteRect", (Vector4)(&ret5));
															if ((object)_Trail != null)
															{
																Material material4 = ((Renderer)_Trail).GetMaterial();
																if ((object)material4 != null)
																{
																	int num = Shader.PropertyToID("_FlipY");
																	material4.SetFloatImpl(num, 1f);
																	string trail2 = (string)(object)_Trail;
																	if ((object)_Trail != null)
																	{
																		bool flag7 = trail2._stringLength == 0;
																		TrailRenderer.set_textureMode_Injected((IntPtr)trail2._stringLength, LineTextureMode.Stretch);
																		if ((object)_Trail != null)
																		{
																			object obj = default(object);
																			float num2 = (float)obj / 100f;
																			_Trail.startWidth = num2;
																			if ((object)_Trail != null)
																			{
																				_Trail.endWidth = num2;
																				if ((object)_Trail != null)
																				{
																					Material material5 = ((Renderer)_Trail).GetMaterial();
																					RenderingExtensions.SetAlpha(material5, 1f);
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
		throw new NullReferenceException();
	}

	public override void SetOwner(GameObject owner)
	{
		_owner = owner;
		EnemyOrochimario component = _owner.GetComponent<EnemyOrochimario>();
		_trueOwner = component;
	}

	public void SetHeadIndex(int index)
	{
		_headIndex = index;
		if (index == 0)
		{
			_hp = (_maxHp += _maxHp);
		}
	}

	public void SetRandomStartingPosition()
	{
		//IL_007d: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_008d: Expected O, but got F4
		//IL_00d6: Expected O, but got F4
		//IL_0123: Expected O, but got F4
		if (_headIndex != 0)
		{
			CheckRenderer();
			bool flag = ((ArcadeSprite)this)._spriteRenderer.flipX;
			object obj = (flag ? 1 : 0) ^ 1;
			object obj2 = obj * 2;
			Transform transform = (Transform)(obj2 - 1);
			object obj3 = UnityEngine.Random.value;
			object obj4 = default(object);
			float num = (float)obj4 - 0.25f;
			float num2 = num * 64f;
			float num3 = num2 * (float)transform;
			float num4 = num3 * 0.01f;
			_startingPosition = (Vector2)num4;
			Transform cachedTransform = _cachedTransform;
			bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			object obj5 = UnityEngine.Random.value;
			float num5 = num4 * -45f;
			object obj6 = default(object);
			float num6 = (float)obj6 * -44f;
			float num7 = num5 + num6;
			float num8 = num7 * 0.01f;
			float num9 = num8 * -1f;
		}
		else
		{
			_startingPosition = (Vector2)0;
			_ = 1054280253;
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_05b1: Expected I, but got O
		//IL_00a1: Expected O, but got I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected I4, but got Unknown
		//IL_00fe: Expected O, but got I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected I4, but got Unknown
		//IL_0125: Expected I, but got O
		//IL_060a: Expected O, but got Ref
		//IL_0629: Expected I, but got O
		//IL_0669: Expected O, but got Ref
		//IL_0688: Expected I, but got O
		//IL_06c8: Expected O, but got Ref
		//IL_0708: Expected O, but got I
		//IL_075f: Expected O, but got Ref
		//IL_07d0: Expected I, but got O
		//IL_0226: Expected O, but got I
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_02e4: Expected O, but got I
		//IL_0330: Expected O, but got I4
		//IL_0354: Expected I, but got O
		//IL_0849: Expected O, but got Ref
		//IL_0868: Expected I, but got O
		//IL_08c2: Expected O, but got Ref
		//IL_097c: Expected O, but got Ref
		//IL_0998: Expected I, but got O
		//IL_09f2: Expected O, but got Ref
		//IL_0a39: Expected O, but got I
		//IL_0a6a: Expected O, but got I
		//IL_0412: Expected O, but got Ref
		//IL_0420: Expected native int or pointer, but got O
		//IL_0433: Expected O, but got Ref
		//IL_051c: Expected F4, but got I4
		//IL_07ea->IL059a: Incompatible stack heights: 5 vs 0
		//IL_0210->IL059a: Incompatible stack heights: 5 vs 0
		//IL_0809->IL059a: Incompatible stack heights: 5 vs 0
		//IL_02ae->IL059a: Incompatible stack heights: 5 vs 0
		//IL_030e->IL059a: Incompatible stack heights: 5 vs 0
		//IL_036e->IL059a: Incompatible stack heights: 5 vs 0
		//IL_0882->IL059a: Incompatible stack heights: 6 vs 0
		//IL_093f->IL059a: Incompatible stack heights: 7 vs 0
		//IL_09b2->IL059a: Incompatible stack heights: 8 vs 0
		//IL_0a94->IL059a: Incompatible stack heights: 9 vs 0
		//IL_03d6->IL059a: Incompatible stack heights: 9 vs 0
		//IL_046c->IL059a: Incompatible stack heights: 10 vs 0
		//IL_0544->IL059a: Incompatible stack heights: 10 vs 0
		//IL_04d4->IL059a: Incompatible stack heights: 10 vs 0
		//IL_0570->IL059a: Incompatible stack heights: 10 vs 0
		//IL_0500->IL059a: Incompatible stack heights: 10 vs 0
		//IL_0aaf->IL05da: Incompatible stack heights: 10 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.OnUpdate();
		nint num = (nint)_trueOwner;
		if ((object)_trueOwner == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Il2CppMethodInfo)+10]");
		if ((nint)0 == 0 || base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		int num18;
		float value;
		Material material2;
		if ((object)_trueOwner != null)
		{
			int num2 = _trueOwner.depth;
			object obj3 = _headIndex + 9;
			int num3 = obj3 + num2;
			ArcadeSprite arcadeSprite = setDepth(num3);
			int num4 = base.depth;
			if ((object)_Trail != null)
			{
				object obj4 = num4 - _headIndex;
				int sortingOrder = obj4 - 8;
				_Trail.sortingOrder = sortingOrder;
				nint num5 = (nint)_cachedTransform;
				if ((object)_trueOwner != null)
				{
					float2 float5 = _trueOwner.position;
					if ((object)_trueOwner != null)
					{
						float2 float6 = _trueOwner.position;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rdi_v26 (Il2CppMethodInfo)+10]");
						bool flag = (nint)0 == 0;
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rdi_v26 (Il2CppMethodInfo)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj5);
						nint num6 = (nint)_cachedTransform;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rdi_v27 (Il2CppMethodInfo)+10]");
						bool flag2 = (nint)0 == 0;
						object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rdi_v27 (Il2CppMethodInfo)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
						nint num7 = (nint)_cachedTransform;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rdi_v28 (Il2CppMethodInfo)+10]");
						bool flag3 = (nint)0 == 0;
						object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rdi_v28 (Il2CppMethodInfo)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj7);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9520");
						object cachedTransform = _cachedTransform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
						_currentVector = (Vector2)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
						_ = 0;
						bool flag4 = (object)_cachedTransform == null;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rsi_v26 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rsi_v26 (System.Object)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj8);
						float deltaTime = PauseSystem.DeltaTime;
						float num8 = deltaTime * 1000f;
						if (!((_attackTime = num8 + _attackTime) < _attackDelay))
						{
							Attack();
							_attackTime = 0f;
						}
						nint num9 = (nint)_trueOwner;
						if ((object)_trueOwner != null)
						{
							((ArcadeSprite)_trueOwner).CheckRenderer();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdi_v30 (Il2CppMethodInfo)+48]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdi_v30 (Il2CppMethodInfo)+48]");
								Vector2 vector = ((!((SpriteRenderer)0).flipX) ? _headOffset : _invHeadOffset);
								if ((object)_trueOwner != null)
								{
									float2 float7 = _trueOwner.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
									Vector2 neckPosition = 0 + vector;
									_neckPosition = neckPosition;
									if ((object)_trueOwner != null)
									{
										float2 float8 = _trueOwner.position;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
										nint num10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyOrochiHead)+2D4]");
										object obj9 = num10 + 0;
										CheckRenderer();
										if ((object)((ArcadeSprite)this)._spriteRenderer != null)
										{
											bool flag6 = ((ArcadeSprite)this)._spriteRenderer.flipX;
											object obj10 = (flag6 ? 1 : 0) ^ 1;
											float angleRng = (float)obj10 - 1f;
											_angleRng = angleRng;
											nint num11 = (nint)_cachedTransform;
											if ((object)_cachedTransform != null)
											{
												_ = 0;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdi_v31 (Il2CppMethodInfo)+10]");
												bool flag7 = (nint)0 == 0;
												object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdi_v31 (Il2CppMethodInfo)+10]");
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj11);
												nint num12 = (nint)_cachedTransform;
												if ((object)_cachedTransform != null)
												{
													_ = 0;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rdi_v32 (Il2CppMethodInfo)+10]");
													bool flag8 = (nint)0 == 0;
													object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rdi_v32 (Il2CppMethodInfo)+10]");
													Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj12);
													float num13 = _angleRng * _maxAngleRotDeg;
													float num14 = num13 + _minAngleRotDeg;
													float num15 = num14 * _AttackLerp;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18732FD60");
													Renderer cachedTransform2 = (Renderer)(object)_cachedTransform;
													if ((object)_cachedTransform != null)
													{
														_ = 0;
														_ = 0;
														bool flag9 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
														object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
														Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Vector3*)obj13);
														nint num16 = (nint)_cachedTransform;
														if ((object)_cachedTransform != null)
														{
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdi_v34 (Il2CppMethodInfo)+10]");
															bool flag10 = (nint)0 == 0;
															object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdi_v34 (Il2CppMethodInfo)+10]");
															Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj14);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-15]");
															float num17 = 0f + 0.32f;
															QuadraticBezierCurve quadraticBezierCurve = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
															quadraticBezierCurve._p0 = (Vector2)0;
															quadraticBezierCurve._p2 = _neckPosition;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyOrochiHead)+2B0]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
															quadraticBezierCurve._p1 = (Vector2)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
															_ = 0;
															if (quadraticBezierCurve != null)
															{
																Vector3[] points = quadraticBezierCurve.GetPoints(5);
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD370");
																if ((object)_Trail != null)
																{
																	_Trail.Clear();
																	IEnumerable<Vector3> enumerable = default(IEnumerable<Vector3>);
																	bool flag11 = enumerable == null;
																	System.Linq.Buffer<Vector3> buffer = (System.Linq.Buffer<Vector3>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
																	_ = 0;
																	System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)buffer, new System.Linq.Buffer<Vector3>(enumerable));
																	System.Linq.Buffer<Vector3> buffer2 = (System.Linq.Buffer<Vector3>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
																	_ = 0;
																	Vector3[] positions = ((System.Linq.Buffer<Vector3>*)buffer2)->ToArray();
																	if ((object)_Trail != null)
																	{
																		_Trail.AddPositions(positions);
																		float2 float9 = base.position;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
																		if (0 <= (nint)_targetVector)
																		{
																			if ((object)_Trail != null)
																			{
																				Material material = ((Renderer)_Trail).GetMaterial();
																				if ((object)material != null)
																				{
																					num18 = Shader.PropertyToID("_FlipY");
																					value = 0f;
																					material2 = material;
																					goto IL_0a99;
																				}
																			}
																		}
																		else if ((object)_Trail != null)
																		{
																			Material material3 = ((Renderer)_Trail).GetMaterial();
																			if ((object)material3 != null)
																			{
																				num18 = Shader.PropertyToID("_FlipY");
																				value = 1f;
																				material2 = material3;
																				goto IL_0a99;
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
		IL_0a99:
		material2.SetFloatImpl(num18, value);
	}

	private void Attack()
	{
		//IL_009f: Expected I, but got O
		//IL_01fe: Expected I, but got O
		//IL_0305: Expected F4, but got O
		if (!base._003CIsTimeStopped_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 targetVector = gameSessionData._activeCharacter.position;
			_targetVector = targetVector;
			if (_attackTween != null)
			{
				_attackTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_AttackLerp", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 200f;
			tweenConfig.yoyo = true;
			tweenConfig.delay = 500f;
			TweenCallback onComplete = delegate
			{
				SetRandomStartingPosition();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween attackTween = Tweens.Add(tweenConfig);
			_attackTween = attackTween;
			if (_retreatTween != null)
			{
				_retreatTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_AttackLerp", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary2;
			tweenConfig2.duration = 400f;
			tweenConfig2.delay = 700f;
			MultiTargetTween retreatTween = Tweens.Add(tweenConfig2);
			_retreatTween = retreatTween;
			float2 float5 = base.position;
			float2 float6 = base.position;
			object obj3 = default(object);
			float y = (float)obj3 + 0.16f;
			SingleWarning((float)float5, y);
		}
	}

	private void SetCurrentVector()
	{
		//IL_0098->IL003d: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Transform cachedTransform2 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9520");
				Vector2 currentVector = default(Vector2);
				_currentVector = currentVector;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		EnemyOrochimario trueOwner = _trueOwner;
		if ((object)_trueOwner != null && ((UnityEngine.Object)trueOwner).m_CachedPtr != (IntPtr)0)
		{
			_trueOwner.GetDamaged(value, showHitVfx, damageKb, WeaponType.VOID, hasKb: false);
		}
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
	}

	protected override void Die()
	{
		//IL_0013: Expected O, but got I4
		//IL_0084: Expected O, but got F4
		base.Die();
		FadeTrails();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * -600f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 1000f, 2, time);
		GM.Core.FrameFreeze();
	}

	public override void Disappear()
	{
		base.Disappear();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x187737FB0\"");
	}

	protected void FadeTrails()
	{
		//IL_009f: Expected I, but got O
		//IL_0103: Expected O, but got I4
		_Trail.emitting = false;
		if (_fadeTrailTween != null)
		{
			_fadeTrailTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Material material = ((Renderer)_Trail).GetMaterial();
		if ((object)material != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween fadeTrailTween = Tweens.Add(tweenConfig);
		_fadeTrailTween = fadeTrailTween;
	}

	private void SingleWarning(float x, float y)
	{
		//IL_008a: Expected O, but got I4
		//IL_0277: Expected O, but got F4
		//IL_00b9: Expected F4, but got O
		//IL_01cd: Expected O, but got I4
		//IL_0269->IL020b: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL020b: Incompatible stack heights: 1 vs 0
		//IL_012b->IL020b: Incompatible stack heights: 1 vs 0
		//IL_019a->IL020b: Incompatible stack heights: 1 vs 0
		//IL_0178->IL0178: Incompatible stack heights: 2 vs 1
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass31_0();
		Vector2 vector = default(Vector2);
		string text = default(string);
		string spriteName = default(string);
		SpriteRenderer component = RenderingExtensions.AddSprite(this, x, y, vector, text, spriteName);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
		if ((object)spriteRenderer != null)
		{
			bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 9000);
			if (CS_0024_003C_003E8__locals9 != null)
			{
				CS_0024_003C_003E8__locals9.s = spriteRenderer;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Volume = (float?)(object)1,
					Rate = 1f
				};
				object obj = UnityEngine.Random.value;
				float num = (float)vector * 500f;
				_ = 1065353216;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, (float)text);
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if ((object)CS_0024_003C_003E8__locals9.s != null)
				{
					Transform transform = CS_0024_003C_003E8__locals9.s.transform;
					if (array != null)
					{
						if ((object)transform != null)
						{
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform, 0f);
							bool flag2 = (object)spriteRenderer2 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							tweenConfig.duration = 200f;
							tweenConfig.scale = (float?)(object)1;
							TweenCallback onComplete = delegate
							{
								//IL_003e: Expected I, but got O
								//IL_0094: Expected O, but got I4
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								Transform transform2 = CS_0024_003C_003E8__locals9.s.transform;
								if ((object)transform2 != null)
								{
									nint num2 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									if (obj2 == null)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig2.targets = array2;
								tweenConfig2.scale = (float?)(object)1;
								tweenConfig2.duration = 200f;
								tweenConfig2.delay = 200f;
								TweenCallback onComplete2 = CS_0024_003C_003E8__locals9._003C_003E9__1;
								if (CS_0024_003C_003E8__locals9._003C_003E9__1 == null)
								{
									onComplete2 = (CS_0024_003C_003E8__locals9._003C_003E9__1 = delegate
									{
										UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals9.s, 0f);
									});
								}
								tweenConfig2.onComplete = onComplete2;
								MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
							};
							tweenConfig.onComplete = onComplete;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public EnemyOrochiHead()
	{
		//IL_003e: Expected O, but got I4
		_minAngleRotDeg = 5f;
		_maxAngleRotDeg = 10f;
		_attackDelay = 5000f;
		_ = 1057635696;
		_headOffset = (Vector2)0;
		_ = 1057635696;
		base._002Ector();
	}

	private void _003CAttack_003Eb__25_0()
	{
		SetRandomStartingPosition();
	}
}
