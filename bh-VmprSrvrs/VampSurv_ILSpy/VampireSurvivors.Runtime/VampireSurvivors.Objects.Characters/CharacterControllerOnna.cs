using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerOnna : CharacterController
{
	private SpriteRenderer _sparkSprite;

	private SpriteRenderer _ringSprite;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private int _firingIndex;

	protected unsafe override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		Action<string> frameKey = delegate(string text)
		{
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected Ref, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected Ref, but got Unknown
			//IL_01e1: Expected I8, but got I4
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Expected Ref, but got Unknown
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Expected Ref, but got Unknown
			//IL_02c5: Expected I8, but got I4
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Expected Ref, but got Unknown
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0392: Expected Ref, but got Unknown
			//IL_03a9: Expected I8, but got I4
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b8: Expected Ref, but got Unknown
			//IL_0471: Unknown result type (might be due to invalid IL or missing references)
			//IL_0476: Expected Ref, but got Unknown
			//IL_048d: Expected I8, but got I4
			//IL_0497: Unknown result type (might be due to invalid IL or missing references)
			//IL_049c: Expected Ref, but got Unknown
			//IL_0555: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Expected Ref, but got Unknown
			//IL_0571: Expected I8, but got I4
			//IL_057b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0580: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5B77]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (base._isDead || base.IsDisconnectedFromOnlinePlay)
			{
				return;
			}
			object obj = "onna_03";
			if ((object)text != "onna_03")
			{
				if (text != null && "onna_03" != null)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v3+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("onna_03" + 20), length))
						{
							goto IL_05ae;
						}
					}
				}
				object obj2 = "onna_06";
				if ((object)text != "onna_06")
				{
					if (text != null && "onna_06" != null)
					{
						int stringLength2 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v7+10]");
						if ((nint)stringLength2 == 0)
						{
							ref byte first2 = ref *(byte*)(text + 20);
							ulong length2 = (ulong)(text._stringLength + text._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("onna_06" + 20), length2))
							{
								goto IL_05ae;
							}
						}
					}
					object obj3 = "onna_09";
					if ((object)text != "onna_09")
					{
						if (text != null && "onna_09" != null)
						{
							int stringLength3 = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v9+10]");
							if ((nint)stringLength3 == 0)
							{
								ref byte first3 = ref *(byte*)(text + 20);
								ulong length3 = (ulong)(text._stringLength + text._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("onna_09" + 20), length3))
								{
									goto IL_05ae;
								}
							}
						}
						object obj4 = "onna_12";
						if ((object)text != "onna_12")
						{
							if (text != null && "onna_12" != null)
							{
								int stringLength4 = text._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v11+10]");
								if ((nint)stringLength4 == 0)
								{
									ref byte first4 = ref *(byte*)(text + 20);
									ulong length4 = (ulong)(text._stringLength + text._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("onna_12" + 20), length4))
									{
										goto IL_05ae;
									}
								}
							}
							object obj5 = "onna_15";
							if ((object)text != "onna_15")
							{
								if (text != null && "onna_15" != null)
								{
									int stringLength5 = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v13+10]");
									if ((nint)stringLength5 == 0)
									{
										ref byte first5 = ref *(byte*)(text + 20);
										ulong length5 = (ulong)(text._stringLength + text._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("onna_15" + 20), length5))
										{
											goto IL_05ae;
										}
									}
								}
								object obj6 = "onna_18";
								if ((object)text != "onna_18")
								{
									if (text == null || "onna_18" == null)
									{
										return;
									}
									int stringLength6 = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v15+10]");
									if ((nint)stringLength6 != 0)
									{
										return;
									}
									ref byte first6 = ref *(byte*)(text + 20);
									ulong length6 = (ulong)(text._stringLength + text._stringLength);
									if (!System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("onna_18" + 20), length6))
									{
										return;
									}
								}
							}
						}
					}
				}
			}
			goto IL_05ae;
			IL_05ae:
			FireWeapons();
		};
		((CharacterControllerOnna)(object)_spriteAnimation)._003CMakeLevelOne_003Eb__5_0((string)(object)frameKey);
		SpriteRenderer sparkSprite = _sparkSprite;
		Vector2 pos = default(Vector2);
		if ((object)_sparkSprite == null || ((UnityEngine.Object)sparkSprite).m_CachedPtr == (IntPtr)0)
		{
			float2 float5 = base.cachedPosition;
			GameObject gameObject = base.gameObject;
			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "blurredSharpStar");
			SpriteRenderer component = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(component, 0f);
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			((Renderer)spriteRenderer2).SetMaterial(material);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			int sortingOrder = default(int);
			spriteRenderer2.sortingOrder = sortingOrder;
			_sparkSprite = spriteRenderer2;
		}
		SpriteRenderer ringSprite = _ringSprite;
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			float2 float6 = base.cachedPosition;
			GameObject gameObject2 = base.gameObject;
			SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject2, pos, "vfx", "sPFX_ring_64");
			SpriteRenderer component2 = RenderingExtensions.SetAlpha(spriteRenderer3, 0f);
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(component2, 0f);
			Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
			((Renderer)spriteRenderer4).SetMaterial(material2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			int sortingOrder2 = default(int);
			spriteRenderer4.sortingOrder = sortingOrder2;
			_ringSprite = spriteRenderer4;
		}
	}

	private unsafe void PlaySparkle()
	{
		//IL_0070: Expected I, but got O
		//IL_00c8: Expected I, but got O
		//IL_012c: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_0156: Expected O, but got I4
		//IL_0229: Expected I, but got O
		//IL_0281: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_02e5: Expected O, but got I4
		//IL_02f3: Expected O, but got I4
		//IL_031d: Expected O, but got I4
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Transform transform = _ringSprite.transform;
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
		if ((object)_ringSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		if (_sparkTween != null)
		{
			_sparkTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		Transform transform2 = _sparkSprite.transform;
		if ((object)transform2 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sparkSprite != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scaleX = (float?)(object)1;
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 250f;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.angle = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			//IL_0053: Expected O, but got Ref
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_sparkSprite, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
			Transform transform3 = _sparkSprite.transform;
			object obj5 = default(object);
			transform3.localEulerAngles = (Vector3)(&obj5);
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onUpdate = delegate
		{
			Transform cachedTransform = base._cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			bool flag2 = (object)_sparkSprite == null;
			Transform transform3 = _sparkSprite.transform;
			bool flag3 = (object)transform3 == null;
			bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			bool flag5 = (object)_ringSprite == null;
			Transform transform4 = _ringSprite.transform;
			bool flag6 = (object)transform4 == null;
			bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
		};
		tweenConfig2.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween sparkTween = Tweens.Add(tweenConfig2);
		_sparkTween = sparkTween;
	}

	private unsafe void FireWeapons()
	{
		//IL_0476: Expected O, but got Ref
		//IL_047f: Expected O, but got I4
		//IL_0489: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_021c: Expected O, but got I
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_0277: Expected O, but got I
		//IL_02b3: Expected O, but got I
		List<Weapon> list = new List<Weapon>();
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		bool flag = (object)base._weaponsManager == null;
		List<Weapon> list2 = list;
		if (!flag)
		{
			bool flag2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
			list2 = list;
			if (!flag2)
			{
				List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj = 0;
				}
				bool flag3 = list == null;
				list2 = (List<Weapon>)(&enumerator);
				object obj2 = 0;
				object obj3 = 0;
				if (!flag3)
				{
					while (true)
					{
						if ((nint)obj3 < list._size)
						{
							if ((nint)obj2 < list._size)
							{
								list2 = (List<Weapon>)(object)list._items;
								if (list._items == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.Weapon>)+20+v83 @ rbx_v7*8]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.Weapon>)+20+v83 @ rbx_v7*8]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v8+B0]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v8+B0]");
									((Timer)0).Cancel();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v8+B8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v8+B8]");
									((Timer)0).Cancel();
								}
								obj2++;
								obj3 = obj2;
								continue;
							}
						}
						else
						{
							if (++_firingIndex >= list._size)
							{
								_firingIndex = 0;
							}
							int firingIndex = _firingIndex;
							if (_firingIndex < list._size)
							{
								Weapon[] items = list._items;
								if (list._items == null)
								{
									break;
								}
								Weapon weapon = items[firingIndex];
								if ((object)items[firingIndex] != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
								{
									items[firingIndex].Fire();
								}
								PlaySparkle();
								return;
							}
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void LevelUp()
	{
		//IL_0155: Invalid comparison between O and F4
		//IL_0046: Invalid comparison between O and F4
		//IL_0070: Invalid comparison between O and F4
		//IL_009a: Invalid comparison between O and F4
		//IL_00c4: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5B76]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.LevelUp();
		float num = base.PMoveSpeed();
		object obj = default(object);
		int frameRate;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f))
		{
			float num2 = base.PMoveSpeed();
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.5f))
			{
				float num3 = base.PMoveSpeed();
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.4f))
				{
					float num4 = base.PMoveSpeed();
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.3f))
					{
						float num5 = base.PMoveSpeed();
						bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.2f);
						frameRate = 4;
						if (!flag)
						{
							frameRate = 5;
						}
					}
					else
					{
						frameRate = 6;
					}
				}
				else
				{
					frameRate = 7;
				}
			}
			else
			{
				frameRate = 8;
			}
		}
		else
		{
			frameRate = 9;
		}
		_spriteAnimation.Play("walk", frameRate);
	}

	private unsafe void _003CMakeLevelOne_003Eb__5_0(string frameKey)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Ref, but got Unknown
		//IL_00fd: Expected I8, but got I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Ref, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected Ref, but got Unknown
		//IL_01e1: Expected I8, but got I4
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected Ref, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected Ref, but got Unknown
		//IL_02c5: Expected I8, but got I4
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected Ref, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected Ref, but got Unknown
		//IL_03a9: Expected I8, but got I4
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected Ref, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected Ref, but got Unknown
		//IL_048d: Expected I8, but got I4
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Expected Ref, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected Ref, but got Unknown
		//IL_0571: Expected I8, but got I4
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5B77]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (base._isDead || base.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		object obj = "onna_03";
		if ((object)frameKey != "onna_03")
		{
			if (frameKey != null && "onna_03" != null)
			{
				int stringLength = frameKey._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v3+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(frameKey + 20);
					ulong length = (ulong)(frameKey._stringLength + frameKey._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("onna_03" + 20), length))
					{
						goto IL_05ae;
					}
				}
			}
			object obj2 = "onna_06";
			if ((object)frameKey != "onna_06")
			{
				if (frameKey != null && "onna_06" != null)
				{
					int stringLength2 = frameKey._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v7+10]");
					if ((nint)stringLength2 == 0)
					{
						ref byte first2 = ref *(byte*)(frameKey + 20);
						ulong length2 = (ulong)(frameKey._stringLength + frameKey._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("onna_06" + 20), length2))
						{
							goto IL_05ae;
						}
					}
				}
				object obj3 = "onna_09";
				if ((object)frameKey != "onna_09")
				{
					if (frameKey != null && "onna_09" != null)
					{
						int stringLength3 = frameKey._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v9+10]");
						if ((nint)stringLength3 == 0)
						{
							ref byte first3 = ref *(byte*)(frameKey + 20);
							ulong length3 = (ulong)(frameKey._stringLength + frameKey._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("onna_09" + 20), length3))
							{
								goto IL_05ae;
							}
						}
					}
					object obj4 = "onna_12";
					if ((object)frameKey != "onna_12")
					{
						if (frameKey != null && "onna_12" != null)
						{
							int stringLength4 = frameKey._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v11+10]");
							if ((nint)stringLength4 == 0)
							{
								ref byte first4 = ref *(byte*)(frameKey + 20);
								ulong length4 = (ulong)(frameKey._stringLength + frameKey._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("onna_12" + 20), length4))
								{
									goto IL_05ae;
								}
							}
						}
						object obj5 = "onna_15";
						if ((object)frameKey != "onna_15")
						{
							if (frameKey != null && "onna_15" != null)
							{
								int stringLength5 = frameKey._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v13+10]");
								if ((nint)stringLength5 == 0)
								{
									ref byte first5 = ref *(byte*)(frameKey + 20);
									ulong length5 = (ulong)(frameKey._stringLength + frameKey._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("onna_15" + 20), length5))
									{
										goto IL_05ae;
									}
								}
							}
							object obj6 = "onna_18";
							if ((object)frameKey != "onna_18")
							{
								if (frameKey == null || "onna_18" == null)
								{
									return;
								}
								int stringLength6 = frameKey._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v15+10]");
								if ((nint)stringLength6 != 0)
								{
									return;
								}
								ref byte first6 = ref *(byte*)(frameKey + 20);
								ulong length6 = (ulong)(frameKey._stringLength + frameKey._stringLength);
								if (!System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("onna_18" + 20), length6))
								{
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_05ae;
		IL_05ae:
		FireWeapons();
	}

	private void _003CPlaySparkle_003Eb__6_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
	}

	private unsafe void _003CPlaySparkle_003Eb__6_1()
	{
		//IL_0053: Expected O, but got Ref
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_sparkSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
		Transform transform = _sparkSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CPlaySparkle_003Eb__6_2()
	{
		Transform cachedTransform = base._cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_sparkSprite == null;
		Transform transform = _sparkSprite.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag5 = (object)_ringSprite == null;
		Transform transform2 = _ringSprite.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
	}

	private void _003CPlaySparkle_003Eb__6_3()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
	}
}
