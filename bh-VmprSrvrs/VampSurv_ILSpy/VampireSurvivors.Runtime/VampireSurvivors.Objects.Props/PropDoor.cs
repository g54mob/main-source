using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Props;

public class PropDoor : GameMonoBehaviour
{
	private ArcadeSprite _sideA;

	private ArcadeSprite _sideB;

	private ArcadeSprite _openingZone;

	private Vector3 _openingScaleA;

	private Vector3 _openingScaleB;

	private Vector2 _originA;

	private Vector2 _originB;

	private float _openingSpeed;

	private float _closingSpeed;

	private SpriteRenderer _sideARenderer;

	private SpriteRenderer _sideBRenderer;

	private Material _sideAMaterial;

	private Material _sideBMaterial;

	private float _proportionClosed;

	private Vector3 _startingScaleA;

	private Vector3 _startingScaleB;

	private bool _anyoneInRange;

	private void Start()
	{
		//IL_0148->IL00e7: Incompatible stack heights: 1 vs 0
		//IL_007c->IL00e7: Incompatible stack heights: 1 vs 0
		//IL_01a7->IL00e7: Incompatible stack heights: 2 vs 0
		//IL_00c3->IL00e7: Incompatible stack heights: 2 vs 0
		if ((object)_sideA != null)
		{
			Transform transform = _sideA.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				_startingScaleA = ret;
				_ = 0;
				if ((object)_sideB != null)
				{
					Transform transform2 = _sideB.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
						_startingScaleB = ret;
						_ = 0;
						if ((object)_sideARenderer != null)
						{
							Material material = ((Renderer)_sideARenderer).GetMaterial();
							_sideAMaterial = material;
							if ((object)_sideBRenderer != null)
							{
								Material material2 = ((Renderer)_sideBRenderer).GetMaterial();
								_sideBMaterial = material2;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		Vector2 origin = default(Vector2);
		AddSide(_sideA, origin);
		AddSide(_sideB, origin);
		AddOpeningZone(_openingZone);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		RemoveSide(_sideA);
		RemoveSide(_sideB);
		ArcadeSprite openingZone = _openingZone;
		if (openingZone.body != null && PhysicsManager._sInstance != null)
		{
			openingZone.body.destroy();
			openingZone.body = null;
		}
	}

	protected override void OnUpdate()
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_011c: Invalid comparison between F4 and O
		//IL_01a7: Expected O, but got I4
		//IL_01b0: Expected F4, but got I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_007c: Invalid comparison between F4 and O
		//IL_013c: Expected F4, but got I4
		//IL_0145: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_01e3: Invalid comparison between O and F4
		//IL_036a: Invalid comparison between F4 and O
		//IL_00a5: Expected O, but got I4
		//IL_022c: Expected F4, but got I4
		//IL_0260: Invalid comparison between O and F4
		//IL_02a9: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3F2E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float num;
		float num3;
		object obj2;
		float num4;
		float proportionClosed;
		if (!_anyoneInRange)
		{
			float deltaTime = PauseSystem.DeltaTime;
			num = deltaTime * _closingSpeed;
			float num2 = 1f - _proportionClosed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num2 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				num3 = 1f;
				obj2 = 0;
				num4 = 1f;
				goto IL_0351;
			}
			obj2 = 0;
			proportionClosed = 1f;
			num4 = 1f;
		}
		else
		{
			float deltaTime2 = PauseSystem.DeltaTime;
			num = deltaTime2 * _openingSpeed;
			float num5 = 0f - _proportionClosed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj3 = num5 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				num3 = 0f;
				obj2 = 0;
				num4 = 1f;
				goto IL_0351;
			}
			obj2 = 0;
			proportionClosed = 0f;
			num4 = 1f;
		}
		goto IL_037e;
		IL_037e:
		_proportionClosed = proportionClosed;
		Transform transform = _sideA.transform;
		float proportionClosed2 = _proportionClosed;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_proportionClosed))
		{
			if (proportionClosed2 > num4)
			{
				proportionClosed2 = num4;
			}
		}
		else
		{
			proportionClosed2 = 0f;
		}
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = _sideB.transform;
		float proportionClosed3 = _proportionClosed;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_proportionClosed))
		{
			if (proportionClosed3 > num4)
			{
				proportionClosed3 = num4;
			}
		}
		else
		{
			proportionClosed3 = 0f;
		}
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		bool flag4 = (object)_sideAMaterial == null;
		int num6 = Shader.PropertyToID("_ProportionClosed");
		_sideAMaterial.SetFloatImpl(num6, _proportionClosed);
		bool flag5 = (object)_sideBMaterial == null;
		int num7 = Shader.PropertyToID("_ProportionClosed");
		_sideBMaterial.SetFloatImpl(num7, _proportionClosed);
		_anyoneInRange = false;
		return;
		IL_0351:
		float num8 = num3 - _proportionClosed;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			float num9 = num4 * num;
			proportionClosed = num9 + _proportionClosed;
		}
		else
		{
			float num10 = -1f * num;
			proportionClosed = num10 + _proportionClosed;
		}
		goto IL_037e;
	}

	private unsafe void AddSide(ArcadeSprite side, Vector2 origin)
	{
		//IL_0008: Expected O, but got Ref
		//IL_02bf: Expected O, but got Ref
		//IL_0347: Expected O, but got Ref
		//IL_0163: Expected O, but got I
		//IL_0163: Expected O, but got I
		//IL_03cf: Expected O, but got Ref
		//IL_041e: Expected O, but got I
		//IL_041e: Expected F4, but got I
		//IL_0488: Expected O, but got Ref
		//IL_04bb: Expected O, but got I
		//IL_0520: Expected O, but got Ref
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Expected O, but got Unknown
		//IL_0568: Expected O, but got Ref
		//IL_0310->IL0281: Incompatible stack heights: 1 vs 0
		//IL_0129->IL0281: Incompatible stack heights: 1 vs 0
		//IL_038f->IL0281: Incompatible stack heights: 2 vs 0
		//IL_017f->IL0281: Incompatible stack heights: 2 vs 0
		//IL_01c6->IL0281: Incompatible stack heights: 2 vs 0
		//IL_01f5->IL0281: Incompatible stack heights: 2 vs 0
		//IL_0448->IL0281: Incompatible stack heights: 3 vs 0
		//IL_022e->IL0281: Incompatible stack heights: 3 vs 0
		//IL_04e0->IL0281: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			Factory add = s_scene.add;
			if (s_scene.add != null && add._world != null)
			{
				PhaserGameObject phaserGameObject = add._world.enableBody(side);
				if ((object)side != null)
				{
					side.CheckRenderer();
					if ((object)side._spriteRenderer != null)
					{
						Sprite sprite = side._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							_ = 0;
							bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj3);
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
							_ = 0;
							_ = 1;
							side.CheckRenderer();
							if ((object)side._spriteRenderer != null)
							{
								Sprite sprite2 = side._spriteRenderer.sprite;
								if ((object)sprite2 != null)
								{
									_ = 0;
									bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
									object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
									Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out *(Rect*)obj4);
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B]");
									_ = 0;
									_ = 1;
									if (side.body != null)
									{
										BaseBody body = side.body;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
										BaseBody baseBody = body.setSize((float?)(object)num, (float?)(object)0, center: false);
										if (baseBody != null)
										{
											baseBody._enable = true;
											baseBody._immovable = true;
											side.CheckRenderer();
											if ((object)side._spriteRenderer != null)
											{
												Transform transform = side._spriteRenderer.transform;
												if ((object)transform != null)
												{
													_ = 0;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v57 (UnityEngine.Transform)+10]");
													bool flag3 = (nint)0 == 0;
													object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v57 (UnityEngine.Transform)+10]");
													Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-5]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
													nint num2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
													ArcadeSprite arcadeSprite = side.setOrigin(num2, (float?)(object)0);
													side.CheckRenderer();
													if ((object)side._spriteRenderer != null)
													{
														Transform transform2 = side._spriteRenderer.transform;
														if ((object)transform2 != null)
														{
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v65 (UnityEngine.Transform)+10]");
															bool flag4 = (nint)0 == 0;
															object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v65 (UnityEngine.Transform)+10]");
															Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
															nint num3 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
															object obj7 = num3 - 0;
															Transform transform3 = side.transform;
															if ((object)transform3 != null)
															{
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v71 (UnityEngine.Transform)+10]");
																bool flag5 = (nint)0 == 0;
																object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v71 (UnityEngine.Transform)+10]");
																Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj8);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
																object obj9 = 0 + obj7;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v71 (UnityEngine.Transform)+10]");
																bool flag6 = (nint)0 == 0;
																object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v71 (UnityEngine.Transform)+10]");
																Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj10);
																PhysicsManager sInstance = PhysicsManager._sInstance;
																bool flag7 = PhysicsManager._sInstance == null;
																bool flag8 = sInstance._doorGroup == null;
																Group obj11 = sInstance._doorGroup.add(side);
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

	private void RemoveSide(ArcadeSprite side)
	{
		//IL_0072: Expected O, but got I
		if (side.body != null && PhysicsManager._sInstance != null)
		{
			PhysicsManager sInstance = PhysicsManager._sInstance;
			if (sInstance._doorGroup != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v8+50]");
				((Group)0).remove(side);
				side.body.destroy();
				side.body = null;
			}
		}
	}

	private void AddOpeningZone(ArcadeSprite zone)
	{
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_0289->IL020f: Incompatible stack heights: 1 vs 0
		//IL_0093->IL020f: Incompatible stack heights: 1 vs 0
		//IL_0333->IL020f: Incompatible stack heights: 2 vs 0
		//IL_00cc->IL020f: Incompatible stack heights: 2 vs 0
		//IL_00ee->IL020f: Incompatible stack heights: 2 vs 0
		//IL_012b->IL020f: Incompatible stack heights: 2 vs 0
		//IL_0169->IL020f: Incompatible stack heights: 2 vs 0
		//IL_02e5->IL020f: Incompatible stack heights: 2 vs 0
		//IL_030c->IL020f: Incompatible stack heights: 2 vs 0
		//IL_01c7->IL020f: Incompatible stack heights: 2 vs 0
		if ((object)zone != null)
		{
			zone.CheckRenderer();
			if ((object)zone._spriteRenderer != null)
			{
				Sprite sprite = zone._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
					zone.CheckRenderer();
					if ((object)zone._spriteRenderer != null)
					{
						Sprite sprite2 = zone._spriteRenderer.sprite;
						if ((object)sprite2 != null)
						{
							bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect _);
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								Factory add = s_scene.add;
								if (s_scene.add != null && add._world != null)
								{
									PhaserGameObject phaserGameObject = add._world.enableBody(zone);
									if (zone.body != null)
									{
										BaseBody baseBody = zone.body.setSize((float?)(object)1, (float?)(object)1);
										if (baseBody != null)
										{
											baseBody._enable = true;
											baseBody._immovable = true;
											PhaserScene s_scene2 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhysicsManager sInstance = PhysicsManager._sInstance;
												if (PhysicsManager._sInstance != null)
												{
													ArcadePhysicsCallback collideCallback = OnPlayerOverlapsZone;
													if (s_scene2.add != null)
													{
														ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
														CallbackContext callbackContext = default(CallbackContext);
														Collider collider = s_scene2.add.overlap(zone, sInstance._playerGroup, collideCallback, processCallback, callbackContext);
														ArcadeSprite arcadeSprite = zone.setVisible(visible: false);
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
		throw new NullReferenceException();
	}

	private bool OnPlayerOverlapsZone(CallbackContext context, ArcadeColliderType zone, ArcadeColliderType player)
	{
		_anyoneInRange = true;
		return false;
	}

	private void RemoveOpeningZone(ArcadeSprite zone)
	{
		if (zone.body != null && PhysicsManager._sInstance != null)
		{
			zone.body.destroy();
			zone.body = null;
		}
	}

	public PropDoor()
	{
		//IL_002b: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0083: Expected I, but got O
		Vector3 vector = default(Vector3);
		_openingScaleA = vector;
		_openingScaleB = vector;
		_ = 1f;
		_ = 1f;
		_originA = (Vector2)0;
		_ = 1056964608;
		_originB = (Vector2)1065353216;
		_ = 1056964608;
		_openingSpeed = 1f;
		_closingSpeed = 1f;
		_proportionClosed = 1f;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
