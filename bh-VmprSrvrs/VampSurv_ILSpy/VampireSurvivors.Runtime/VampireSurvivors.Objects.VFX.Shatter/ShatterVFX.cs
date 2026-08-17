using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors.Objects.VFX.Shatter;

public class ShatterVFX : GameMonoBehaviour
{
	public enum ShatterType
	{
		Grid,
		Radial
	}

	[Serializable]
	public class ShatterDetails
	{
		public ShatterType shatterType;

		public int horizontalCuts;

		public int verticalCuts;

		public int horizontalZigzagPoints;

		public float horizontalZigzagSize;

		public int verticalZigzagPoints;

		public float verticalZigzagSize;

		public int radialSectors;

		public int radials;

		public Vector2 radialCentre;

		public bool randomizeAtRunTime;

		public int randomSeed;

		public float randomness;

		public ShatterDetails()
		{
			//IL_0037: Expected O, but got I4
			horizontalCuts = 8;
			verticalCuts = 8;
			radialSectors = 16;
			radials = 1;
			radialCentre = (Vector2)1056964608;
			_ = 1056964608;
			randomness = 0.5f;
		}
	}

	public ShatterDetails shatterDetails;

	private Vector3[] originalShatterPieceLocations;

	private Quaternion[] originalShatterPieceRotations;

	private Transform shatterGameObjectTransform;

	private bool error;

	private void Reset()
	{
		//IL_0055: Expected O, but got I4
		ShatterDetails shatterDetails = new ShatterDetails();
		shatterDetails.horizontalCuts = 8;
		shatterDetails.verticalCuts = 8;
		shatterDetails.radialSectors = 16;
		shatterDetails.radials = 1;
		shatterDetails.radialCentre = (Vector2)1056964608;
		_ = 1056964608;
		shatterDetails.randomness = 0.5f;
		this.shatterDetails = shatterDetails;
	}

	public unsafe SpriteRenderer[] Shatter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00ae: Expected O, but got Ref
		//IL_0107: Expected O, but got Ref
		//IL_01a2: Expected I, but got O
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_13e6: Expected O, but got I4
		//IL_038e: Expected O, but got Ref
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected Ref, but got Unknown
		//IL_0315: Expected I8, but got I4
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected Ref, but got Unknown
		//IL_1433: Expected I4, but got O
		//IL_1ba6: Expected I, but got O
		//IL_157b: Expected O, but got I4
		//IL_15c3: Expected O, but got I4
		//IL_1607: Expected O, but got Ref
		//IL_04a4: Expected O, but got I4
		//IL_04ca: Expected O, but got I4
		//IL_04df: Expected F4, but got O
		//IL_12c8: Expected O, but got I
		//IL_16aa: Expected I, but got O
		//IL_16ff: Expected O, but got Ref
		//IL_177f: Expected O, but got Ref
		//IL_127a: Expected O, but got I
		//IL_1818: Expected O, but got Ref
		//IL_1890: Expected O, but got I4
		//IL_18a7: Expected I4, but got O
		//IL_18be: Expected O, but got I4
		//IL_18d5: Expected I4, but got O
		//IL_18df: Expected O, but got I4
		//IL_190c: Expected O, but got I4
		//IL_089e: Expected O, but got I
		//IL_0703: Expected O, but got I
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_078e: Expected O, but got Unknown
		//IL_0825: Invalid comparison between I and F4
		//IL_1932: Invalid comparison between F4 and I
		//IL_1ca3: Expected O, but got I4
		//IL_1cc4: Invalid comparison between I and F4
		//IL_0849: Expected F4, but got I
		//IL_1956: Invalid comparison between F4 and I
		//IL_085e: Expected F4, but got I
		//IL_1ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce6: Expected O, but got Unknown
		//IL_0873: Expected F4, but got I
		//IL_0888: Expected F4, but got I
		//IL_0a13: Expected native int or pointer, but got O
		//IL_0a25: Expected F4, but got O
		//IL_0a20: Expected native int or pointer, but got O
		//IL_0a32: Expected O, but got Ref
		//IL_0acc: Invalid comparison between F4 and I4
		//IL_0ae9: Expected F4, but got I4
		//IL_0b18: Invalid comparison between F4 and I4
		//IL_0b35: Expected F4, but got I4
		//IL_0b82: Invalid comparison between I4 and F4
		//IL_0ba2: Expected F4, but got I4
		//IL_0be8: Invalid comparison between I4 and F4
		//IL_0c08: Expected F4, but got I4
		//IL_0c6e: Expected O, but got Ref
		//IL_0cbf: Expected O, but got I4
		//IL_0d10: Invalid comparison between I4 and F4
		//IL_0e39: Expected O, but got I
		//IL_0d59: Expected F4, but got I4
		//IL_0d7e: Invalid comparison between I4 and F4
		//IL_0dda: Expected F4, but got I4
		//IL_0ea1: Expected O, but got Ref
		//IL_0ea1: Expected O, but got I
		//IL_0eb2: Expected O, but got I
		//IL_1a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9f: Expected O, but got Unknown
		//IL_0dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbf: Expected O, but got Unknown
		//IL_0f1d: Expected O, but got Ref
		//IL_0f79: Expected O, but got I
		//IL_0f82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f87: Expected O, but got Unknown
		//IL_0f99: Expected O, but got F4
		//IL_0fa2: Expected O, but got I4
		//IL_0fba: Expected O, but got I
		//IL_0fc2: Expected I4, but got O
		//IL_022c->IL12f0: Incompatible stack heights: 1 vs 0
		//IL_025f->IL12f0: Incompatible stack heights: 1 vs 0
		//IL_13b1->IL12f0: Incompatible stack heights: 1 vs 0
		//IL_035e->IL01cd: Incompatible stack heights: 1 vs 0
		//IL_13fe->IL12f0: Incompatible stack heights: 2 vs 0
		//IL_03c8->IL133b: Incompatible stack heights: 1 vs 0
		//IL_14b7->IL12f0: Incompatible stack heights: 5 vs 0
		//IL_0468->IL15db: Incompatible stack heights: 12 vs 11
		//IL_1014->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_104a->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_0578->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_05a2->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_12cd->IL12eb: Incompatible stack heights: 14 vs 0
		//IL_05de->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_1115->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_1141->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_116b->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_11fe->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_122b->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_1257->IL12f0: Incompatible stack heights: 14 vs 0
		//IL_127f->IL12eb: Incompatible stack heights: 14 vs 0
		//IL_0692->IL12f0: Incompatible stack heights: 29 vs 0
		//IL_08cc->IL12f0: Incompatible stack heights: 29 vs 0
		//IL_0757->IL12f0: Incompatible stack heights: 31 vs 0
		//IL_090d->IL12f0: Incompatible stack heights: 29 vs 0
		//IL_094e->IL12f0: Incompatible stack heights: 29 vs 0
		//IL_07e2->IL12f0: Incompatible stack heights: 33 vs 0
		//IL_098f->IL12f0: Incompatible stack heights: 29 vs 0
		//IL_09d0->IL12f0: Incompatible stack heights: 29 vs 0
		//IL_1ceb->IL196a: Incompatible stack heights: 34 vs 28
		//IL_19aa->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_19f2->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_1a2b->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_1a64->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0c44->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0cc8->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0df7->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0e55->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0e87->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_1ab1->IL1ab1: Incompatible stack heights: 34 vs 32
		//IL_0ed3->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0dd1->IL1ab1: Incompatible stack heights: 34 vs 32
		//IL_0efd->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0f54->IL12f0: Incompatible stack heights: 32 vs 0
		//IL_0fd7->IL1ad8: Incompatible stack heights: 32 vs 14
		object obj = default(object);
		Vector3 vector = (Vector3)(&obj);
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		if (!(component != null))
		{
			goto IL_12cd;
		}
		if ((object)component != null)
		{
			Sprite sprite = component.sprite;
			if (!(sprite != null))
			{
				goto IL_12cd;
			}
			Sprite sprite2 = component.sprite;
			if ((object)sprite2 != null)
			{
				object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16));
				Rect textureRect = sprite2.textureRect;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				Sprite sprite3 = component.sprite;
				if ((object)sprite3 != null)
				{
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16));
					Rect textureRect2 = sprite3.textureRect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					ShatterDetails shatterDetails = this.shatterDetails;
					if (this.shatterDetails != null)
					{
						if (shatterDetails.randomizeAtRunTime)
						{
							System.Random random = new System.Random();
							if (random == null)
							{
								goto IL_12f0;
							}
							nint num = (nint)random;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1591 @ rdx_v209 (Il2CppClass<UnityEngine.Sprite>)+188] (should have been resolved before IL gen)");
						}
						string text = GetName();
						string text2 = text + " - ShatterVFX";
						Transform[] componentsInChildren = GetComponentsInChildren<Transform>(includeInactive: true);
						int num2 = 1;
						string text3 = text2;
						Vector3 value = default(Vector3);
						Quaternion ret = default(Quaternion);
						string text8 = default(string);
						Vector2 vector3 = default(Vector2);
						object obj17 = default(object);
						Vector3[] array10 = default(Vector3[]);
						Quaternion[] array11 = default(Quaternion[]);
						uint extrude = default(uint);
						SpriteMeshType meshType = default(SpriteMeshType);
						while (true)
						{
							bool flag = componentsInChildren == null;
							Sprite sprite4 = null;
							if (flag)
							{
								break;
							}
							string text5;
							while ((nint)sprite4 < componentsInChildren.Length)
							{
								bool flag2 = (nint)sprite4 >= componentsInChildren.Length;
								if ((object)componentsInChildren[(object)sprite4] == null)
								{
									goto end_IL_133b;
								}
								GameObject gameObject = componentsInChildren[(object)sprite4].gameObject;
								if ((object)gameObject == null)
								{
									goto end_IL_133b;
								}
								string text4 = ((UnityEngine.Object)gameObject).GetName();
								if ((object)text4 != text3)
								{
									if (text4 != null && text3 != null && text4._stringLength == text3._stringLength)
									{
										ref byte second = ref *(byte*)(text3 + 20);
										ulong length = (ulong)(text4._stringLength + text4._stringLength);
										bool flag3 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text4 + 20), ref second, length);
										text5 = null;
										if (flag3)
										{
											goto IL_035e;
										}
									}
									sprite4 = (Sprite)(sprite4 + 1);
									continue;
								}
								goto IL_035e;
							}
							GameObject gameObject2 = new GameObject();
							GameObject.Internal_CreateGameObject(gameObject2, text3);
							bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
							GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
							if ((object)gameObject3 == null)
							{
								break;
							}
							bool flag5 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
							object obj4 = GameObject.get_layer_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr);
							if ((object)gameObject2 == null)
							{
								break;
							}
							bool flag6 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
							GameObject.set_layer_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, (int)obj4);
							bool flag7 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
							shatterGameObjectTransform = transform;
							bool flag8 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
							Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
							if ((object)shatterGameObjectTransform == null)
							{
								break;
							}
							shatterGameObjectTransform.SetParent(parent, worldPositionStays: true);
							string text6 = (string)(object)shatterGameObjectTransform;
							bool flag9 = (object)shatterGameObjectTransform == null;
							bool flag10 = text6._stringLength == 0;
							Transform.set_localPosition_Injected((IntPtr)text6._stringLength, ref value);
							string text7 = (string)(object)shatterGameObjectTransform;
							bool flag11 = (object)shatterGameObjectTransform == null;
							bool flag12 = text7._stringLength == 0;
							Transform.set_localRotation_Injected((IntPtr)text7._stringLength, ref ret);
							nint num3 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4911 @ rax_v183 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num4 = 0;
							bool flag13 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
							object obj5 = SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)component).m_CachedPtr);
							if (obj5 != null)
							{
							}
							bool flag14 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
							object obj6 = SpriteRenderer.get_flipY_Injected(((UnityEngine.Object)component).m_CachedPtr);
							if (obj6 == null)
							{
								text8 = (string)(object)shatterGameObjectTransform;
								bool flag15 = (object)shatterGameObjectTransform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4912 @ rcx_v161 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
								_ = 0;
							}
							bool flag16 = text8._stringLength == 0;
							object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 32));
							Transform.set_localScale_Injected((IntPtr)text8._stringLength, ref *(Vector3*)obj7);
							bool flag17 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
							GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
							Vector2[][] array = generateShatterShapes();
							_ = 0;
							List<Vector3> list = new List<Vector3>();
							List<Quaternion> list2 = new List<Quaternion>();
							bool flag18 = array == null;
							object obj8 = array.Length;
							SpriteRenderer[] array2 = new SpriteRenderer[array.Length];
							Vector3 vector2 = Vector3.oneVector;
							object obj9 = 0;
							Sprite sprite5 = null;
							string text9 = (string)(object)list2;
							float num5 = (float)vector3;
							Sprite sprite6 = null;
							bool flag19 = true;
							SpriteRenderer spriteRenderer = component;
							Sprite sprite7 = null;
							while (true)
							{
								SpriteRenderer spriteRenderer2;
								float num9;
								float num10;
								float num11;
								float num12;
								if ((nint)sprite7 < array.Length)
								{
									int num6 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 384));
									string text10 = ((int*)num6)->ToString();
									string text11 = "Piece " + text10;
									GameObject gameObject4 = new GameObject();
									GameObject.Internal_CreateGameObject(gameObject4, text11);
									GameObject gameObject5 = base.gameObject;
									if ((object)gameObject5 == null)
									{
										break;
									}
									int layer = gameObject5.layer;
									if ((object)gameObject4 == null)
									{
										break;
									}
									gameObject4.layer = layer;
									Transform transform2 = gameObject4.transform;
									if ((object)transform2 == null)
									{
										break;
									}
									transform2.SetParent(shatterGameObjectTransform, worldPositionStays: true);
									bool flag20 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr4 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
									Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
									nint num7 = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3640 @ rcx_v249 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num8 = 0;
									bool flag21 = (object)transform3 == null;
									_ = Vector3.oneVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3638 @ rax_v289 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
									_ = 0;
									bool flag22 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 16));
									Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj10);
									bool flag23 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr5 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
									Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
									bool flag24 = (object)transform4 == null;
									_ = Quaternion.identityQuaternion;
									bool flag25 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 32));
									Transform.set_localRotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Quaternion*)obj11);
									spriteRenderer2 = gameObject4.AddComponent<SpriteRenderer>();
									bool flag26 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
									SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)(&ret));
									bool flag27 = (object)spriteRenderer2 == null;
									bool flag28 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
									object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16));
									SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, ref *(Color*)obj12);
									bool flag29 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
									IntPtr sharedMaterial_Injected = Renderer.GetSharedMaterial_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
									Material material = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(sharedMaterial_Injected);
									((Renderer)spriteRenderer2).SetMaterial(material);
									bool flag30 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
									string text12 = (string)Renderer.get_sortingLayerID_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
									bool flag31 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
									Renderer.set_sortingLayerID_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, (int)text12);
									bool flag32 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
									string text13 = (string)Renderer.get_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
									bool flag33 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
									Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, (int)text13);
									object obj13 = array.Length;
									num9 = -3.4028235E+38f;
									num10 = 3.4028235E+38f;
									num11 = -3.4028235E+38f;
									num12 = 3.4028235E+38f;
									object obj14 = 0;
									while (true)
									{
										bool flag34 = System.Runtime.CompilerServices.Unsafe.As<Sprite, UIntPtr>(ref sprite5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13);
										Vector2[] array3 = array[(object)sprite5];
										if (array[(object)sprite5] == null)
										{
											break;
										}
										if ((nint)obj14 < array3.Length)
										{
											Vector2[] array4 = array[(object)sprite5];
											bool flag35 = (nint)obj14 >= array4.Length;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)+188]");
											nint num13 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rdx_v191 (UnityEngine.Vector2[])+20+v469 @ rcx_v287*8]");
											object obj15 = num13 * 0;
											bool flag36 = (nint)sprite5 >= array.Length;
											Vector2[] array5 = array[(object)sprite5];
											if (array[(object)sprite5] == null)
											{
												break;
											}
											bool flag37 = (nint)obj14 >= array5.Length;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdx_v192 (UnityEngine.Vector2[])+24+v469 @ rcx_v287*8]");
											object obj16 = obj17 * 0;
											bool flag38 = (nint)sprite5 >= array.Length;
											Vector2[] array6 = array[(object)sprite5];
											if (array[(object)sprite5] == null)
											{
												break;
											}
											bool flag39 = (nint)obj14 >= array6.Length;
											Vector2[] array7 = array[(object)sprite5];
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rdx_v193 (UnityEngine.Vector2[])+20+v469 @ rcx_v287*8]");
											if (!(0f > num12))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rdx_v193 (UnityEngine.Vector2[])+20+v469 @ rcx_v287*8]");
												num12 = 0f;
											}
											Vector2[] array8 = array[(object)sprite5];
											float num14 = num11;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6466 @ rdx_v194 (UnityEngine.Vector2[])+20+v469 @ rcx_v287*8]");
											if (!(num14 > 0f))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6466 @ rdx_v194 (UnityEngine.Vector2[])+20+v469 @ rcx_v287*8]");
												num11 = 0f;
											}
											obj13 = array.Length;
											Vector2[] array9 = array[(object)sprite5];
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6484 @ rdx_v195 (UnityEngine.Vector2[])+24+v469 @ rcx_v287*8]");
											if (!(0f > num10))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6484 @ rdx_v195 (UnityEngine.Vector2[])+24+v469 @ rcx_v287*8]");
												num10 = 0f;
											}
											float num15 = num9;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6399 @ rdx_v196 (UnityEngine.Vector2[])+24+v469 @ rcx_v287*8]");
											if (!(num15 > 0f))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6399 @ rdx_v196 (UnityEngine.Vector2[])+24+v469 @ rcx_v287*8]");
												num9 = 0f;
											}
											obj14++;
											continue;
										}
										goto IL_088d;
									}
									break;
								}
								if ((object)sprite6 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-78]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049EA70");
									originalShatterPieceLocations = array10;
									if (text9 == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B74C0");
									originalShatterPieceRotations = array11;
								}
								else
								{
									string text14 = GetName();
									string message = "Sprite Shatter (" + text14 + "): No shattered pieces were created. This is probably because the pieces are too small for the sprite, or the sprite has too much transparency.";
									Debug.LogError(message);
									error = true;
								}
								if (!error)
								{
									Sprite sprite8 = (Sprite)(object)shatterGameObjectTransform;
									UnityEngine.Object obj18;
									if ((object)shatterGameObjectTransform != null && ((UnityEngine.Object)sprite8).m_CachedPtr != (IntPtr)0)
									{
										if ((object)shatterGameObjectTransform == null)
										{
											break;
										}
										Transform parent2 = shatterGameObjectTransform.parent;
										if ((object)parent2 == null)
										{
											break;
										}
										GameObject gameObject6 = parent2.gameObject;
										if ((object)gameObject6 == null)
										{
											break;
										}
										SpriteRenderer component2 = gameObject6.GetComponent<SpriteRenderer>();
										obj18 = component2;
									}
									else
									{
										obj18 = null;
									}
									Sprite sprite9 = (Sprite)(object)shatterGameObjectTransform;
									if ((object)shatterGameObjectTransform != null && ((UnityEngine.Object)sprite9).m_CachedPtr != (IntPtr)0 && obj18 != null)
									{
										if ((object)obj18 == null)
										{
											break;
										}
										((Renderer)obj18).enabled = false;
										if ((object)shatterGameObjectTransform == null)
										{
											break;
										}
										GameObject gameObject7 = shatterGameObjectTransform.gameObject;
										if ((object)gameObject7 == null)
										{
											break;
										}
										gameObject7.SetActive(value: true);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-70]");
										return (SpriteRenderer[])0;
									}
									string text15 = GetName();
									string message2 = "Sprite Shatter (" + text15 + "): The Sprite Shatter game object or its Sprite Renderer could not be found. Please initialise the \"Sprite Shatter\" component again.";
									Debug.LogWarning(message2);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-70]");
								return (SpriteRenderer[])0;
								IL_088d:
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-80]");
								Transform transform5 = ((GameObject)0).transform;
								Sprite sprite10 = spriteRenderer.sprite;
								if ((object)sprite10 == null)
								{
									break;
								}
								Vector2 pivot = sprite10.pivot;
								Sprite sprite11 = spriteRenderer.sprite;
								if ((object)sprite11 == null)
								{
									break;
								}
								Vector2 textureRectOffset = sprite11.GetTextureRectOffset();
								Sprite sprite12 = spriteRenderer.sprite;
								if ((object)sprite12 == null)
								{
									break;
								}
								Vector2 pivot2 = sprite12.pivot;
								Sprite sprite13 = spriteRenderer.sprite;
								if ((object)sprite13 == null)
								{
									break;
								}
								Vector2 textureRectOffset2 = sprite13.GetTextureRectOffset();
								Sprite sprite14 = spriteRenderer.sprite;
								if ((object)sprite14 == null)
								{
									break;
								}
								float pixelsPerUnit = sprite14.pixelsPerUnit;
								float z = 0f / pixelsPerUnit;
								bool flag40 = (object)transform5 == null;
								((Vector3*)(nint)vector)->z = z;
								((Vector3*)(nint)vector)->x = (float)vector3;
								transform5.localPosition = (Vector3)(&obj);
								bool flag41 = (nint)sprite5 >= array.Length;
								Sprite sprite15 = (Sprite)(object)array[(object)sprite5];
								ushort[] triangles = generateMeshTriangles(array[(object)sprite5]);
								Sprite sprite16 = component.sprite;
								bool flag42 = (object)sprite16 == null;
								float num16 = sprite16.textureRect.m_XMin + num12;
								if (!(num16 > 0f))
								{
									num16 = 0f;
								}
								Sprite sprite17 = component.sprite;
								if ((object)sprite17 == null)
								{
									break;
								}
								float num17 = sprite17.textureRect.m_YMin + num10;
								if (!(num17 > 0f))
								{
									num17 = 0f;
								}
								float num18 = num11 - num12;
								float num19 = num9 - num10;
								Sprite sprite18 = component.sprite;
								if ((object)sprite18 == null)
								{
									break;
								}
								Rect textureRect3 = sprite18.textureRect;
								float num20 = num16 + num18;
								float num21 = textureRect3.m_XMin + (float)vector3;
								float num22 = num20 - num21;
								if (0f > num22)
								{
									num22 = 0f;
								}
								float num23 = num18 - num22;
								Sprite sprite19 = component.sprite;
								if ((object)sprite19 == null)
								{
									break;
								}
								Rect textureRect4 = sprite19.textureRect;
								float num24 = num19 + num17;
								object obj19 = vector3 + vector3;
								float num25 = num24 - (float)obj19;
								if (0f > num25)
								{
									num25 = 0f;
								}
								float num26 = num19 - num25;
								Sprite sprite20 = component.sprite;
								if ((object)sprite20 == null)
								{
									break;
								}
								Texture2D texture = sprite20.texture;
								Sprite sprite21 = component.sprite;
								if ((object)sprite21 == null)
								{
									break;
								}
								float pixelsPerUnit2 = sprite21.pixelsPerUnit;
								Rect rect = (Rect)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96));
								Sprite sprite22 = Sprite.Create(texture, rect, vector3, pixelsPerUnit2, extrude, meshType);
								bool flag43 = array[(object)sprite5] == null;
								object obj20 = 0;
								if (flag43)
								{
									break;
								}
								while (true)
								{
									object obj21 = obj20;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v78 (UnityEngine.Sprite)+18]");
									if ((nint)obj21 >= 0)
									{
										break;
									}
									object obj22 = obj20;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v78 (UnityEngine.Sprite)+18]");
									bool flag44 = (nint)obj22 >= 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v78 (UnityEngine.Sprite)+20+v481 @ rcx_v315*8]");
									float num27 = 0f - num12;
									if (!(0f > num27))
									{
										if (num27 > num23)
										{
											num27 = num23;
										}
									}
									else
									{
										num27 = 0f;
									}
									object obj23 = obj20;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v78 (UnityEngine.Sprite)+18]");
									bool flag45 = (nint)obj23 >= 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v78 (UnityEngine.Sprite)+24+v481 @ rcx_v315*8]");
									float num28 = 0f - num10;
									if (!(0f > num28))
									{
										if (num28 > num26)
										{
											object obj24 = obj20 + 1;
											obj20 = obj24;
											continue;
										}
									}
									else
									{
										num28 = 0f;
									}
									object obj25 = obj20 + 1;
									obj20 = obj25;
								}
								if ((object)sprite22 == null)
								{
									break;
								}
								sprite22.OverrideGeometry(array[(object)sprite5], triangles);
								spriteRenderer2.sprite = sprite22;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-80]");
								Transform transform6 = ((GameObject)0).transform;
								if ((object)transform6 == null)
								{
									break;
								}
								Vector3 localPosition = transform6.localPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-78]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-78]");
								((List<Vector3>)0).Add((Vector3)(&vector2));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-80]");
								Transform transform7 = ((GameObject)0).transform;
								if ((object)transform7 == null)
								{
									break;
								}
								Quaternion localRotation = transform7.localRotation;
								if (list2 == null)
								{
									break;
								}
								num5 = localRotation.x;
								Quaternion item = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 48));
								_ = localRotation.x;
								list2.Add(item);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)-70]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)+180]");
								sprite6 = (Sprite)((nint)0 + (nint)1);
								sprite5 = (Sprite)(sprite5 + 1);
								vector2 = (Vector3)localPosition.x;
								obj9 = 0;
								text9 = (string)(object)list2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (UnityEngine.Vector3)+180]");
								obj8 = 0;
								flag19 = (byte)(int)spriteRenderer2 != 0;
								spriteRenderer = component;
								sprite7 = sprite5;
							}
							break;
							IL_035e:
							num2++;
							string text16 = GetName();
							string text17 = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&ret), null);
							string text18 = text16 + " - ShatterVFX (" + text17 + ")";
							text5 = ")";
							text3 = text18;
							continue;
							end_IL_133b:
							break;
						}
					}
				}
			}
		}
		goto IL_12f0;
		IL_12cd:
		error = true;
		return new SpriteRenderer[0];
		IL_12f0:
		throw new NullReferenceException();
	}

	public unsafe Vector2[][] generateShatterShapes()
	{
		//IL_007f: Expected O, but got I4
		//IL_1157: Expected O, but got I4
		//IL_116a: Expected O, but got I4
		//IL_0112: Expected F4, but got I4
		//IL_011b: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		//IL_11e1: Expected O, but got I4
		//IL_11ea: Expected O, but got I4
		//IL_138b: Expected O, but got I4
		//IL_1394: Expected O, but got I4
		//IL_030e: Expected O, but got I4
		//IL_0317: Expected O, but got I4
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_1239: Expected O, but got I
		//IL_125b: Expected O, but got I4
		//IL_126a: Expected O, but got I4
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1290: Expected O, but got Unknown
		//IL_12a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a5: Expected O, but got Unknown
		//IL_12be: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c3: Expected O, but got Unknown
		//IL_27f5: Expected I, but got O
		//IL_12f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fb: Expected O, but got Unknown
		//IL_069f: Expected O, but got I4
		//IL_06b3: Expected O, but got I4
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_1582: Expected O, but got I4
		//IL_158b: Expected O, but got I4
		//IL_13ec: Expected O, but got I
		//IL_2999: Expected O, but got I4
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_0394: Expected O, but got F4
		//IL_03b4: Expected O, but got F4
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_2d3d: Expected O, but got I4
		//IL_140e: Expected O, but got I4
		//IL_141d: Expected O, but got I4
		//IL_143e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1443: Expected O, but got Unknown
		//IL_1453: Unknown result type (might be due to invalid IL or missing references)
		//IL_1458: Expected O, but got Unknown
		//IL_1471: Unknown result type (might be due to invalid IL or missing references)
		//IL_1476: Expected O, but got Unknown
		//IL_088b: Expected O, but got I4
		//IL_0894: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		//IL_1599: Expected O, but got I4
		//IL_14a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ae: Expected O, but got Unknown
		//IL_18b1: Expected O, but got I4
		//IL_08b0: Expected O, but got I4
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Expected O, but got Unknown
		//IL_197d: Invalid comparison between F4 and I4
		//IL_19a6: Expected O, but got I4
		//IL_18f1: Invalid comparison between F4 and I4
		//IL_191a: Expected O, but got I4
		//IL_15b1: Expected O, but got I4
		//IL_06ef: Expected O, but got I4
		//IL_28b1: Expected F4, but got I4
		//IL_28ba: Expected F4, but got I4
		//IL_2d98: Expected O, but got I4
		//IL_2dab: Expected O, but got I4
		//IL_1932: Expected O, but got I4
		//IL_184c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1851: Expected O, but got Unknown
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_15e0: Expected O, but got I4
		//IL_19be: Expected O, but got I4
		//IL_19e7: Expected O, but got I4
		//IL_1745: Expected F4, but got I4
		//IL_174e: Expected F4, but got I4
		//IL_10ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f3: Expected O, but got Unknown
		//IL_161f: Expected O, but got I4
		//IL_28ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f3: Expected O, but got Unknown
		//IL_07ce: Expected F4, but got I4
		//IL_07d7: Expected F4, but got I4
		//IL_07f6: Expected O, but got I
		//IL_04b3: Invalid comparison between O and F4
		//IL_04d4: Expected F4, but got O
		//IL_19f6: Expected O, but got I4
		//IL_2cfc: Expected O, but got I
		//IL_1770: Expected O, but got I4
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_082b: Expected O, but got Unknown
		//IL_1808: Unknown result type (might be due to invalid IL or missing references)
		//IL_180d: Expected O, but got Unknown
		//IL_1823: Unknown result type (might be due to invalid IL or missing references)
		//IL_1828: Expected O, but got Unknown
		//IL_1679: Expected O, but got I
		//IL_1682: Unknown result type (might be due to invalid IL or missing references)
		//IL_1687: Expected O, but got Unknown
		//IL_2c49: Expected O, but got I4
		//IL_04f3: Invalid comparison between F4 and O
		//IL_0515: Expected F4, but got O
		//IL_169c: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a1: Expected O, but got Unknown
		//IL_2ca2: Expected O, but got I4
		//IL_0556: Expected F4, but got O
		//IL_2749: Unknown result type (might be due to invalid IL or missing references)
		//IL_274e: Expected O, but got Unknown
		//IL_16f8: Expected O, but got I
		//IL_1701: Unknown result type (might be due to invalid IL or missing references)
		//IL_1706: Expected O, but got Unknown
		//IL_171b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1720: Expected O, but got Unknown
		//IL_094f: Expected O, but got I
		//IL_0958: Unknown result type (might be due to invalid IL or missing references)
		//IL_095d: Expected O, but got Unknown
		//IL_0594: Expected F4, but got O
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Expected O, but got Unknown
		//IL_09a1: Expected O, but got I
		//IL_09be: Expected O, but got I
		//IL_1a62: Expected O, but got I
		//IL_1a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7c: Expected O, but got Unknown
		//IL_1a99: Expected O, but got I
		//IL_1aa9: Expected O, but got I
		//IL_0c42: Expected O, but got I
		//IL_09f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fb: Expected O, but got Unknown
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0d: Expected I4, but got Unknown
		//IL_0608: Expected I4, but got O
		//IL_0621: Expected F4, but got O
		//IL_1ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abc: Expected O, but got Unknown
		//IL_1acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad1: Expected O, but got Unknown
		//IL_1ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aec: Expected O, but got Unknown
		//IL_1afc: Expected F4, but got I
		//IL_1b0c: Expected O, but got I
		//IL_1b24: Expected F4, but got I
		//IL_1b2d: Expected O, but got I4
		//IL_1b4d: Expected F4, but got I
		//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5c: Expected O, but got Unknown
		//IL_0c86: Expected O, but got I
		//IL_0ca3: Expected O, but got I
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a20: Expected O, but got Unknown
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2e: Expected O, but got Unknown
		//IL_0a3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a40: Expected I4, but got Unknown
		//IL_0a50: Expected O, but got I
		//IL_0a6a: Expected O, but got I
		//IL_0a94: Expected O, but got I
		//IL_0ab1: Expected O, but got I
		//IL_0aca: Invalid comparison between I4 and F4
		//IL_0cdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce0: Expected O, but got Unknown
		//IL_0ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf2: Expected I4, but got Unknown
		//IL_29c0: Invalid comparison between I4 and F4
		//IL_1b62: Expected O, but got I
		//IL_0d00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d05: Expected O, but got Unknown
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d18: Expected I4, but got Unknown
		//IL_0d28: Expected O, but got I
		//IL_1d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3c: Expected O, but got Unknown
		//IL_0d42: Expected O, but got I
		//IL_0d6c: Expected O, but got I
		//IL_0d89: Expected O, but got I
		//IL_0da2: Invalid comparison between I4 and F4
		//IL_2e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e92: Expected O, but got Unknown
		//IL_2a49: Invalid comparison between I4 and F4
		//IL_0b4e: Invalid comparison between I4 and F4
		//IL_1e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e84: Expected O, but got Unknown
		//IL_1ead: Expected O, but got I4
		//IL_1d7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d84: Expected O, but got Unknown
		//IL_1d91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d96: Expected I4, but got Unknown
		//IL_1dab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db0: Expected I4, but got Unknown
		//IL_1dff: Expected O, but got I
		//IL_1e0f: Expected F4, but got I
		//IL_1c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4f: Expected O, but got Unknown
		//IL_0e12: Expected F4, but got I4
		//IL_2a0a: Invalid comparison between I4 and F4
		//IL_1f37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f3c: Expected O, but got Unknown
		//IL_1f56: Expected O, but got I4
		//IL_1bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb1: Expected O, but got Unknown
		//IL_1c25: Expected O, but got I
		//IL_1c35: Expected F4, but got I
		//IL_1ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed5: Expected O, but got Unknown
		//IL_1c92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c97: Expected O, but got Unknown
		//IL_1ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca9: Expected I4, but got Unknown
		//IL_1cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc3: Expected I4, but got Unknown
		//IL_1d12: Expected O, but got I
		//IL_1d22: Expected F4, but got I
		//IL_2eca: Expected O, but got I4
		//IL_0e2a: Expected O, but got I4
		//IL_2f01: Expected O, but got Ref
		//IL_1efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f00: Expected O, but got Unknown
		//IL_1f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0e: Expected O, but got Unknown
		//IL_1f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1c: Expected O, but got Unknown
		//IL_103f: Invalid comparison between I4 and F4
		//IL_2709: Expected O, but got I4
		//IL_2736: Unknown result type (might be due to invalid IL or missing references)
		//IL_273b: Expected O, but got Unknown
		//IL_108a: Expected F4, but got I4
		//IL_0e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e64: Expected O, but got Unknown
		//IL_0e74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e79: Expected O, but got Unknown
		//IL_2f56: Expected O, but got F4
		//IL_1fd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd5: Expected O, but got Unknown
		//IL_2ac4: Invalid comparison between I4 and F4
		//IL_2058: Expected F4, but got O
		//IL_2069: Expected O, but got I4
		//IL_2aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af3: Expected O, but got Unknown
		//IL_31b5: Invalid comparison between I4 and F4
		//IL_20be: Expected F4, but got I4
		//IL_20c7: Expected F4, but got I4
		//IL_10ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d3: Expected O, but got Unknown
		//IL_24e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ee: Expected O, but got Unknown
		//IL_2506: Invalid comparison between I4 and F4
		//IL_2548: Expected F4, but got I4
		//IL_2583: Unknown result type (might be due to invalid IL or missing references)
		//IL_2588: Expected O, but got Unknown
		//IL_25d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_25de: Expected O, but got Unknown
		//IL_25f6: Invalid comparison between I4 and F4
		//IL_215d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2162: Expected O, but got Unknown
		//IL_217a: Invalid comparison between I4 and F4
		//IL_3069: Expected O, but got I4
		//IL_2641: Expected F4, but got I4
		//IL_2258: Expected F4, but got I4
		//IL_30e0: Expected O, but got F4
		//IL_3010: Invalid comparison between I4 and F4
		//IL_30ee: Invalid comparison between I4 and F4
		//IL_3118: Unknown result type (might be due to invalid IL or missing references)
		//IL_311d: Expected O, but got Unknown
		//IL_3144: Expected F4, but got O
		//IL_315d: Expected F4, but got O
		//IL_22cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d4: Expected O, but got Unknown
		//IL_235b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2360: Expected O, but got Unknown
		//IL_2378: Invalid comparison between I4 and F4
		//IL_2ff9: Expected O, but got I4
		//IL_23f9: Expected F4, but got I4
		//IL_3059: Expected O, but got F4
		//IL_2327: Expected O, but got F4
		//IL_23eb: Expected O, but got F4
		ShatterDetails shatterDetails = this.shatterDetails;
		Vector2[][] result;
		if (this.shatterDetails != null)
		{
			System.Random random = new System.Random(shatterDetails.randomSeed);
			ShatterDetails shatterDetails2 = this.shatterDetails;
			if (this.shatterDetails != null)
			{
				float x = default(float);
				float y = default(float);
				float x2 = default(float);
				float y2 = default(float);
				Vector2 vector2 = default(Vector2);
				if (shatterDetails2.shatterType != ShatterType.Grid)
				{
					object obj = shatterDetails2.radials * shatterDetails2.radialSectors;
					Vector2[][] array = new Vector2[obj][];
					ShatterDetails shatterDetails3 = this.shatterDetails;
					if (this.shatterDetails != null)
					{
						float[] array2 = new float[shatterDetails3.radialSectors];
						ShatterDetails shatterDetails4 = this.shatterDetails;
						if (this.shatterDetails != null)
						{
							float num = (float)Math.PI * -2f / (float)shatterDetails4.radialSectors;
							float num2 = shatterDetails4.radialSectors;
							object obj2 = 0;
							object obj3 = 0;
							while ((nint)obj2 < shatterDetails4.radialSectors)
							{
								if (random != null)
								{
									double num3 = random.NextDouble();
									ShatterDetails shatterDetails5 = this.shatterDetails;
									if (this.shatterDetails != null && array2 != null)
									{
										shatterDetails4 = this.shatterDetails;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm9\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
										float num4 = 0f * num;
										float num5 = num4 * shatterDetails5.randomness;
										object obj4 = obj3 + 1;
										num2 = (float)obj3 * num;
										float num6 = num5 * 0.9f;
										float num7 = num6 + num2;
										array2[obj3] = num7;
										if (this.shatterDetails != null)
										{
											obj2 = obj4;
											obj3 = obj4;
											continue;
										}
									}
								}
								goto IL_27b5;
							}
							ShatterDetails shatterDetails6 = this.shatterDetails;
							if (this.shatterDetails != null)
							{
								int[] array3 = new int[shatterDetails6.radialSectors];
								ShatterDetails shatterDetails7 = this.shatterDetails;
								if (this.shatterDetails != null)
								{
									Vector2[] array4 = new Vector2[shatterDetails7.radialSectors];
									ShatterDetails shatterDetails8 = this.shatterDetails;
									if (this.shatterDetails != null)
									{
										float num8 = -0f;
										object obj5 = 0;
										float num16 = default(float);
										for (object obj6 = 0; (nint)obj6 < shatterDetails8.radialSectors; num8 = -0f, obj6 = obj5)
										{
											nint num9 = (nint)typeof(Vector2);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ rax_v214 (Il2CppClass<UnityEngine.Vector2>)+B8]");
											nint num10 = 0;
											if (array2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												float num11 = array2[obj5];
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rcx_v165 (Il2CppStaticFields<UnityEngine.Vector2>)+14]");
												object obj7 = num11 * 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
												object obj8 = array2[obj5] * Vector2.upVector;
												float num12 = (float)obj7 + (float)obj8;
												object obj9 = array2[obj5] ^ num8;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
												object obj10 = array2[obj5] ^ num8;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rcx_v165 (Il2CppStaticFields<UnityEngine.Vector2>)+14]");
												object obj11 = obj9 * 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												object obj12 = obj10 * (object)Vector2.upVector;
												float num13 = (float)obj11 + (float)obj12;
												object obj13 = 0;
												while (true)
												{
													if (obj13 == null || (nint)obj13 != 3)
													{
													}
													if (((nint)obj13 < 2 && obj13 == null) || (nint)obj13 == 3)
													{
													}
													bool flag = ShatterMaths._2DLinesIntersect(0f, 0f, num12, num13, x, y, x2, y2);
													bool flag2 = !flag;
													float num14 = num12;
													float num15 = num13;
													float num7 = 0f;
													num2 = 0f;
													if (!flag2)
													{
														Vector2 vector = ShatterMaths._2DLineIntersectionPoint(0f, 0f, num12, num13, x, y, x2, y2);
														if (array4 == null)
														{
															break;
														}
														bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-0.5001f));
														num14 = num12;
														num15 = num13;
														num7 = (float)vector;
														num2 = num16;
														if (!flag3)
														{
															bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5001f) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
															num14 = 0.5001f;
															num15 = num13;
															num7 = (float)vector;
															num2 = num16;
															if (!flag4)
															{
																bool flag5 = !(num16 > -0.5001f);
																num14 = 0.5001f;
																num15 = num13;
																num7 = (float)vector;
																num2 = num16;
																if (!flag5)
																{
																	bool flag6 = 0.5001f > num16;
																	num14 = 0.5001f;
																	num15 = num13;
																	num7 = (float)vector;
																	num2 = num16;
																	if (flag6)
																	{
																		if (array3 == null)
																		{
																			break;
																		}
																		array3[obj5] = (int)obj13;
																		num14 = 0.5001f;
																		num15 = num13;
																		num7 = (float)vector;
																		num2 = num16;
																		goto IL_28e5;
																	}
																}
															}
														}
													}
													obj13++;
													if ((nint)obj13 < 4)
													{
														continue;
													}
													goto IL_28e5;
													IL_28e5:
													obj5++;
													shatterDetails8 = this.shatterDetails;
													if (this.shatterDetails == null)
													{
														break;
													}
													goto IL_062e;
												}
											}
											goto IL_27b5;
											IL_062e:;
										}
										if (this.shatterDetails != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B023D0");
											ShatterDetails shatterDetails9 = this.shatterDetails;
											if (this.shatterDetails != null)
											{
												object obj14 = 0;
												ShatterDetails shatterDetails10 = this.shatterDetails;
												object obj15 = 0;
												object obj18 = default(object);
												while (true)
												{
													bool flag7 = (nint)obj15 >= shatterDetails9.radialSectors;
													object obj16 = 0;
													if (flag7)
													{
														break;
													}
													while (shatterDetails10 != null)
													{
														if ((nint)obj16 >= shatterDetails10.radials)
														{
															goto IL_0835;
														}
														object obj17 = shatterDetails10.radials - 1;
														if (obj16 == obj17)
														{
															float num14 = 1f;
														}
														else
														{
															if (random == null)
															{
																break;
															}
															double num17 = random.NextDouble();
															if (this.shatterDetails == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm9\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rax+30h]\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm3,xmm2\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm3,xmm0\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm3,xmm1\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,r12d\"");
															float num7 = 0f / 0f;
															float num14 = num7;
															float num15 = 0f;
															num2 = 0f;
															shatterDetails10 = this.shatterDetails;
														}
														if (obj18 == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+10]");
														object obj19 = 0;
														object obj20 = obj14;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1882 @ rax_v151+10]");
														object obj21 = obj20 * 0;
														object obj22 = obj21 + obj16;
														obj16++;
													}
													goto IL_27b5;
													IL_0835:
													obj14++;
													shatterDetails9 = shatterDetails10;
													obj15 = obj14;
												}
												ShatterDetails shatterDetails11 = this.shatterDetails;
												bool flag8 = this.shatterDetails == null;
												float num18 = -0.5f;
												ShatterVFX shatterVFX = this;
												object obj23 = 0;
												object obj24 = 0;
												ShatterDetails shatterDetails12 = null;
												if (!flag8)
												{
													Vector2 vector4 = default(Vector2);
													while (true)
													{
														bool flag9 = (nint)obj24 >= shatterDetails11.radialSectors;
														result = array;
														if (flag9)
														{
															break;
														}
														object obj25 = 0;
														while (true)
														{
															shatterDetails11 = shatterVFX.shatterDetails;
															if (shatterVFX.shatterDetails == null)
															{
																break;
															}
															if ((nint)obj25 >= shatterDetails11.radials)
															{
																goto IL_10e5;
															}
															List<Vector2> list = new List<Vector2>();
															if (obj25 != null)
															{
																if (array4 == null || obj18 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+10]");
																object obj26 = 0;
																object obj27 = obj25 - 1;
																object obj28 = obj23;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1883 @ rax_v201+10]");
																object obj29 = obj28 * 0;
																object obj30 = obj29 + obj27;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+20+v635 @ rbx_v34*8]");
																nint num19 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v673 @ rax_v204*4]");
																object obj31 = num19 * 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+24+v635 @ rbx_v34*8]");
																nint num20 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v673 @ rax_v204*4]");
																object obj32 = num20 * 0;
																ShatterDetails shatterDetails13 = shatterVFX.shatterDetails;
																if (shatterVFX.shatterDetails == null)
																{
																	break;
																}
																object obj33 = obj23 + 1;
																int num21 = obj33 % shatterDetails13.radialSectors;
																object obj34 = obj25 - 1;
																object obj35 = obj23 + 1;
																int num22 = obj35 % shatterDetails13.radialSectors;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+10]");
																object obj36 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ rax_v210+10]");
																object obj37 = (nint)num22 * (nint)0;
																object obj38 = obj37 + obj34;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+20+v1869 @ rdx_v92 (System.Int32)*8]");
																nint num23 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v769 @ rcx_v161*4]");
																object obj39 = num23 * 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+24+v1869 @ rdx_v92 (System.Int32)*8]");
																nint num24 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v769 @ rcx_v161*4]");
																object obj40 = num24 * 0;
																float num25 = (float)obj39 + 0.5f;
																if (0f > num25 || num25 > 1f)
																{
																}
																float num26 = (float)obj40 + 0.5f;
																if (0f > num26 || num26 > 1f)
																{
																}
																if (list == null)
																{
																	break;
																}
																list.Add(vector2);
																float num27 = (float)obj31 + 0.5f;
																if (0f > num27 || num27 > 1f)
																{
																}
																float num28 = (float)obj32 + 0.5f;
																if (0f > num28 || num28 > 1f)
																{
																}
																list.Add(vector2);
															}
															else
															{
																if (shatterVFX.shatterDetails == null || list == null)
																{
																	break;
																}
																list.Add(vector2);
																if (array4 == null)
																{
																	break;
																}
															}
															if (obj18 == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+10]");
															object obj41 = 0;
															object obj42 = obj23;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1886 @ rax_v165+10]");
															object obj43 = obj42 * 0;
															object obj44 = obj43 + obj25;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+20+v635 @ rbx_v34*8]");
															nint num29 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v3524 @ rcx_v141*4]");
															object obj45 = num29 * 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+24+v635 @ rbx_v34*8]");
															nint num30 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v3524 @ rcx_v141*4]");
															object obj46 = num30 * 0;
															ShatterDetails shatterDetails14 = shatterVFX.shatterDetails;
															if (shatterVFX.shatterDetails == null)
															{
																break;
															}
															object obj47 = obj23 + 1;
															int num31 = obj47 % shatterDetails14.radialSectors;
															object obj48 = obj23 + 1;
															int num32 = obj48 % shatterDetails14.radialSectors;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+10]");
															object obj49 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1888 @ rax_v172+10]");
															object obj50 = (nint)num32 * (nint)0;
															object obj51 = obj50 + obj25;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+20+v1870 @ rdx_v76 (System.Int32)*8]");
															nint num33 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v3594 @ rcx_v145*4]");
															object obj52 = num33 * 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v137 (UnityEngine.Vector2[])+24+v1870 @ rdx_v76 (System.Int32)*8]");
															nint num34 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rax_v143+20+v3594 @ rcx_v145*4]");
															object obj53 = num34 * 0;
															float num35 = (float)obj45 + 0.5f;
															if (0f > num35 || num35 > 1f)
															{
															}
															float num7 = (float)obj46 + 0.5f;
															if (!(0f > num7))
															{
																if (num7 > 1f)
																{
																	num7 = 1f;
																}
															}
															else
															{
																num7 = 0f;
															}
															list.Add(vector2);
															ShatterDetails shatterDetails15 = shatterVFX.shatterDetails;
															if (shatterVFX.shatterDetails == null)
															{
																break;
															}
															object obj54 = shatterDetails15.radials - 1;
															if (obj25 != obj54)
															{
																goto IL_1026;
															}
															List<Vector2> list2 = (List<Vector2>)(object)shatterVFX.shatterDetails;
															object obj55 = obj23 + 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rcx_v151 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+2C]");
															Vector2 vector3 = (Vector2)(obj55 % 0);
															if (array3 == null)
															{
																break;
															}
															Vector2 item;
															if (array3[obj23] == 0 && array3[(object)vector3] == 1)
															{
																item = vector2;
															}
															else
															{
																if (array3[obj23] == 1 && array3[(object)vector3] == 2)
																{
																	list2.Add(vector3);
																}
																else
																{
																	if (array3[obj23] == 2 && array3[(object)vector3] == 3)
																	{
																		item = vector2;
																		goto IL_2a99;
																	}
																	if (array3[obj23] != 3 || array3[(object)vector3] != 0)
																	{
																		goto IL_1026;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
																}
																item = vector4;
															}
															goto IL_2a99;
															IL_1026:
															num18 = (float)obj52 + 0.5f;
															if (!(0f > num18))
															{
																if (num18 > 1f)
																{
																	num18 = 1f;
																}
															}
															else
															{
																num18 = 0f;
															}
															float num36 = (float)obj53 + 0.5f;
															if (0f > num36 || num36 > 1f)
															{
															}
															list.Add(vector2);
															ShatterDetails shatterDetails16 = (ShatterDetails)(shatterDetails12 + 1);
															list.Add(vector2);
															if (array == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															obj25++;
															shatterVFX = this;
															shatterDetails12 = shatterDetails16;
															continue;
															IL_2a99:
															list.Add(item);
															goto IL_1026;
														}
														goto IL_27b5;
														IL_10e5:
														obj23++;
														bool flag10 = shatterVFX.shatterDetails != null;
														obj24 = obj23;
														if (flag10)
														{
															continue;
														}
														goto IL_27b5;
													}
													goto IL_2787;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				else if (this.shatterDetails != null)
				{
					object obj56 = shatterDetails2.verticalCuts + 1;
					object obj57 = shatterDetails2.horizontalCuts + 1;
					object obj58 = obj57 * obj56;
					Vector2[][] array5 = new Vector2[obj58][];
					if (this.shatterDetails != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B023D0");
						ShatterDetails shatterDetails17 = this.shatterDetails;
						if (this.shatterDetails != null)
						{
							object obj59 = 0;
							object obj60 = 0;
							object obj61 = default(object);
							object obj66 = default(object);
							while ((nint)obj60 < shatterDetails17.horizontalCuts)
							{
								object obj63;
								if (random != null)
								{
									while (true)
									{
										double num37 = random.NextDouble();
										ShatterDetails shatterDetails18 = this.shatterDetails;
										if (this.shatterDetails == null || obj61 == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1736 @ rax_v14+10]");
										object obj62 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm6\"");
										obj63 = shatterDetails18.horizontalCuts + 1;
										object obj64 = 0 + 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm1\"");
										object obj65 = obj66 * shatterDetails18.randomness;
										object obj67 = obj59;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1896 @ rax_v126+10]");
										object obj68 = obj67 * 0;
										float num7 = (float)obj65 * 0.99f;
										object obj69 = obj68 + 0;
										bool flag11 = (nint)obj64 < 2;
										obj66 = obj63;
										if (flag11)
										{
											continue;
										}
										goto IL_12ed;
									}
								}
								goto IL_27b5;
								IL_12ed:
								obj59++;
								bool flag12 = this.shatterDetails != null;
								obj66 = obj63;
								shatterDetails17 = this.shatterDetails;
								obj60 = obj59;
								if (flag12)
								{
									continue;
								}
								goto IL_27b5;
							}
							if (this.shatterDetails != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B023D0");
								ShatterDetails shatterDetails19 = this.shatterDetails;
								bool flag13 = this.shatterDetails == null;
								object obj70 = 0;
								object obj71 = 0;
								if (!flag13)
								{
									int num39 = default(int);
									while ((nint)obj71 < shatterDetails19.verticalCuts)
									{
										object obj73;
										if (random != null)
										{
											while (true)
											{
												double num38 = random.NextDouble();
												ShatterDetails shatterDetails20 = this.shatterDetails;
												if (this.shatterDetails == null || num39 == 0)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v19 (System.Int32)+10]");
												object obj72 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm6\"");
												obj73 = shatterDetails20.verticalCuts + 1;
												object obj74 = 0 + 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm1\"");
												object obj75 = obj66 * shatterDetails20.randomness;
												object obj76 = obj70;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1897 @ rax_v118+10]");
												object obj77 = obj76 * 0;
												float num7 = (float)obj75 * 0.99f;
												object obj78 = obj77 + 0;
												bool flag14 = (nint)obj74 < 2;
												obj66 = obj73;
												if (flag14)
												{
													continue;
												}
												goto IL_14a0;
											}
										}
										goto IL_27b5;
										IL_14a0:
										obj70++;
										bool flag15 = this.shatterDetails != null;
										obj66 = obj73;
										shatterDetails19 = this.shatterDetails;
										obj71 = obj70;
										if (flag15)
										{
											continue;
										}
										goto IL_27b5;
									}
									if (this.shatterDetails != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B023D0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
										object obj79 = default(object);
										if (obj79 != null)
										{
											ShatterDetails shatterDetails21 = this.shatterDetails;
											if (this.shatterDetails != null)
											{
												object obj80 = 0;
												object obj81 = 0;
												while (true)
												{
													object obj82 = shatterDetails21.verticalCuts + 1;
													if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj81) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj82))
													{
														break;
													}
													object obj83 = 0;
													while (true)
													{
														ShatterDetails shatterDetails22 = this.shatterDetails;
														if (this.shatterDetails == null)
														{
															break;
														}
														object obj84 = shatterDetails22.horizontalCuts + 1;
														if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj83) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj84))
														{
															goto IL_1843;
														}
														object obj85 = shatterDetails22.verticalCuts + 1;
														object obj86 = obj80 / obj85;
														float x3;
														float num14;
														if (obj80 != null)
														{
															object obj87 = shatterDetails22.verticalCuts + 1;
															if (obj80 == obj87)
															{
																x3 = 1f;
															}
															else
															{
																if (num39 == 0)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v19 (System.Int32)+10]");
																object obj88 = 0;
																object obj89 = obj80 - 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1898 @ rax_v114+10]");
																object obj90 = 0 * obj89;
																float num40 = (float)obj86;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v19 (System.Int32)+20+v3240 @ rdx_v46*4]");
																x3 = num40 + 0f;
															}
															ShatterDetails shatterDetails23 = this.shatterDetails;
															object obj91 = shatterDetails23.verticalCuts + 1;
															if (obj80 == obj91)
															{
																num14 = 1f;
															}
															else
															{
																if (num39 == 0)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v19 (System.Int32)+10]");
																object obj92 = 0;
																object obj93 = obj80 - 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1899 @ rax_v113+10]");
																object obj94 = 0 * obj93;
																float num41 = (float)obj86;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v19 (System.Int32)+24+v3179 @ rdx_v44*4]");
																num14 = num41 + 0f;
															}
														}
														else
														{
															x3 = 0f;
															num14 = 0f;
														}
														if (obj83 != null)
														{
															ShatterDetails shatterDetails24 = this.shatterDetails;
															object obj95 = shatterDetails24.horizontalCuts + 1;
															if (obj83 != obj95 && obj61 == null)
															{
																break;
															}
															ShatterDetails shatterDetails25 = this.shatterDetails;
															object obj96 = shatterDetails25.horizontalCuts + 1;
															if (obj83 != obj96 && obj61 == null)
															{
																break;
															}
														}
														Vector2 vector5 = ShatterMaths._2DLineIntersectionPoint(x3, -0.0001f, num14, 1.0001f, x, y, x2, y2);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+10]");
														object obj97 = 0;
														object obj98 = obj80;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1902 @ rax_v104+10]");
														object obj99 = obj98 * 0;
														object obj100 = obj99 + obj83;
														obj83++;
														float num15 = 1.0001f;
													}
													goto IL_27b5;
													IL_1843:
													obj80++;
													obj81 = obj80;
													shatterDetails21 = this.shatterDetails;
												}
												ShatterDetails shatterDetails26 = this.shatterDetails;
												if (this.shatterDetails != null)
												{
													bool flag16 = shatterDetails26.horizontalZigzagPoints <= 0;
													object obj101 = 0;
													if (!flag16)
													{
														bool flag17 = shatterDetails26.horizontalZigzagSize < 0.0001f;
														float num42 = shatterDetails26.horizontalZigzagSize - 0.0001f;
														bool flag18 = num42 == 0f;
														bool flag19 = !flag17;
														bool flag20 = !flag18;
														obj101 = flag20 & flag19;
													}
													ShatterDetails shatterDetails27;
													object obj102;
													ShatterDetails shatterDetails28;
													if (shatterDetails26.verticalZigzagPoints <= 0)
													{
														shatterDetails27 = this.shatterDetails;
														obj102 = 0;
														shatterDetails28 = this.shatterDetails;
													}
													else
													{
														shatterDetails28 = this.shatterDetails;
														bool flag21 = shatterDetails28.verticalZigzagSize < 0.0001f;
														float num43 = shatterDetails28.verticalZigzagSize - 0.0001f;
														bool flag22 = num43 == 0f;
														bool flag23 = !flag21;
														bool flag24 = !flag22;
														obj102 = flag24 & flag23;
														shatterDetails27 = shatterDetails28;
													}
													ShatterDetails shatterDetails29 = this.shatterDetails;
													object obj103 = shatterDetails28.horizontalCuts + 1;
													Vector2 vector6 = (Vector2)(shatterDetails29.verticalCuts + 1);
													float num44 = shatterDetails27.horizontalZigzagSize / (float)obj103;
													float num45 = shatterDetails29.verticalZigzagSize / (float)vector6;
													List<Vector2> list3 = new List<Vector2>();
													ShatterDetails shatterDetails30 = this.shatterDetails;
													if (this.shatterDetails != null)
													{
														object obj104 = 0;
														object obj105 = obj61;
														float num46 = num44;
														float num47 = num45;
														Vector2 vector7 = vector6;
														object obj106 = 0;
														object obj145 = default(object);
														Vector2 vector8 = default(Vector2);
														object obj147 = default(object);
														object obj148 = default(object);
														while (true)
														{
															bool flag25 = (nint)obj106 > shatterDetails30.verticalCuts;
															result = array5;
															if (flag25)
															{
																break;
															}
															object obj107 = 0;
															while (true)
															{
																ShatterDetails shatterDetails31 = this.shatterDetails;
																if (this.shatterDetails == null)
																{
																	break;
																}
																if ((nint)obj107 <= shatterDetails31.horizontalCuts)
																{
																	if (list3 == null)
																	{
																		break;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3126 @ rax_v38 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
																	_ = (nint)0 + (nint)1;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+10]");
																	object obj108 = 0;
																	object obj109 = obj104;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1903 @ rax_v43+10]");
																	object obj110 = obj109 * 0;
																	object obj111 = obj110 + obj107;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+10]");
																	object obj112 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+20+v3546 @ rcx_v32*8]");
																	object obj113 = 0;
																	object obj114 = obj104 + 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1904 @ rax_v45+10]");
																	object obj115 = obj114 * 0;
																	object obj116 = obj115 + obj107;
																	object obj117 = obj104 + 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+24+v3615 @ rcx_v37*8]");
																	float num48 = 0f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+20+v3615 @ rcx_v37*8]");
																	object obj118 = 0;
																	List<Vector2> list4 = list3;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+24+v3546 @ rcx_v32*8]");
																	float num49 = 0f;
																	obj105 = 0;
																	object obj119 = obj104;
																	object obj120 = obj107;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+24+v3615 @ rcx_v37*8]");
																	float num50 = 0f;
																	while (true)
																	{
																		bool flag26;
																		bool flag27;
																		bool flag28;
																		bool flag31;
																		if (obj105 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+10]");
																			object obj121 = 0;
																			if ((nint)obj105 != 1)
																			{
																				if ((nint)obj105 != 2)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1905 @ rax_v85+10]");
																					object obj122 = 0 * obj119;
																					object obj123 = obj122 + obj120;
																					object obj124 = obj104 ^ obj104;
																					object obj125 = obj104 & obj124;
																					flag26 = (nint)obj125 < 0;
																					flag27 = (nint)obj104 < 0;
																					flag28 = obj104 == null;
																					obj113 = obj118;
																					num49 = num48;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+20+v3777 @ rcx_v68*8]");
																					obj118 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+24+v3777 @ rcx_v68*8]");
																					num50 = 0f;
																					goto IL_2e23;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1905 @ rax_v85+10]");
																				object obj126 = 0 * obj119;
																				object obj127 = obj126 + obj107;
																				ShatterDetails shatterDetails32 = this.shatterDetails;
																				if (this.shatterDetails == null)
																				{
																					break;
																				}
																				object obj128 = obj107 - shatterDetails32.horizontalCuts;
																				int num51 = obj107 ^ shatterDetails32.horizontalCuts;
																				object obj129 = obj107 ^ obj128;
																				int num52 = num51 & obj129;
																				bool flag29 = num52 < 0;
																				bool flag30 = (nint)obj128 < 0;
																				flag31 = flag30 != flag29;
																				obj113 = obj118;
																				num49 = num48;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+28+v760 @ rcx_v66*8]");
																				obj118 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+2C+v760 @ rcx_v66*8]");
																				num50 = 0f;
																			}
																			else
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1905 @ rax_v85+10]");
																				object obj130 = 0 * obj117;
																				object obj131 = obj130 + obj107;
																				ShatterDetails shatterDetails33 = this.shatterDetails;
																				if (this.shatterDetails == null)
																				{
																					break;
																				}
																				object obj132 = obj104 - shatterDetails33.verticalCuts;
																				int num53 = obj104 ^ shatterDetails33.verticalCuts;
																				object obj133 = obj104 ^ obj132;
																				int num54 = num53 & obj133;
																				bool flag32 = num54 < 0;
																				bool flag33 = (nint)obj132 < 0;
																				flag31 = flag33 != flag32;
																				obj113 = obj118;
																				num49 = num48;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+28+v761 @ rcx_v63*8]");
																				obj118 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v29+2C+v761 @ rcx_v63*8]");
																				num50 = 0f;
																			}
																			goto IL_2e4e;
																		}
																		object obj134 = obj107 ^ obj107;
																		object obj135 = obj107 & obj134;
																		flag26 = (nint)obj135 < 0;
																		flag27 = (nint)obj107 < 0;
																		flag28 = obj107 == null;
																		goto IL_2e23;
																		IL_2e23:
																		bool flag34 = flag27 == flag26;
																		bool flag35 = !flag28;
																		flag31 = flag35 & flag34;
																		goto IL_2e4e;
																		IL_2e84:
																		obj105++;
																		if ((nint)obj105 >= 4)
																		{
																			goto IL_26a6;
																		}
																		list4 = list3;
																		num48 = num50;
																		obj119 = obj104;
																		obj120 = obj107;
																		continue;
																		IL_2e4e:
																		list4.Add(vector2);
																		bool flag36 = !flag31;
																		float num55 = num49;
																		vector7 = vector2;
																		if (flag36)
																		{
																			goto IL_2e84;
																		}
																		object obj136 = ~obj105;
																		object obj137 = obj136 & obj101;
																		object obj138 = obj137 & 1;
																		bool flag37 = obj138 == null;
																		bool flag38 = (nint)obj138 < 0;
																		object obj139 = !flag37;
																		List<Vector2> list5 = list4;
																		if (obj139 == null)
																		{
																			list5 = (List<Vector2>)(obj105 & 0x80000001L);
																			if (flag38)
																			{
																				object obj140 = list5 - 1;
																				object obj141 = obj140 | -2;
																				list5 = (List<Vector2>)(obj141 + 1);
																			}
																			bool flag39 = (nint)list5 != 1;
																			object obj142 = 0;
																			if (!flag39)
																			{
																				obj142 = obj102;
																			}
																			bool flag40 = obj142 == null;
																			num55 = num49;
																			vector7 = vector2;
																			if (flag40)
																			{
																				goto IL_2e84;
																			}
																		}
																		object obj143 = obj105 & 1;
																		bool flag41 = obj143 == null;
																		object obj144 = !flag41;
																		float num56;
																		if (obj144 == null)
																		{
																			num56 = num44 * 0.25f;
																			if (this.shatterDetails == null)
																			{
																				break;
																			}
																		}
																		else
																		{
																			num56 = num47 * 0.25f;
																			if (this.shatterDetails == null)
																			{
																				break;
																			}
																		}
																		list5.Add(vector2);
																		num46 = (float)obj118 - (float)obj113;
																		((List<Vector2>)(&obj145)).Add(vector2);
																		float num57;
																		float x3;
																		if ((nint)obj105 >= 2)
																		{
																			object obj146 = vector8 & 1;
																			if (obj146 != null)
																			{
																				x3 = -0f;
																				num57 = num56;
																				goto IL_2f1e;
																			}
																		}
																		num57 = num56 ^ -0f;
																		x3 = -0f;
																		goto IL_2f1e;
																		IL_2690:
																		obj145 = obj147;
																		num47 = num45;
																		goto IL_2e84;
																		IL_2f1e:
																		float num58 = (float)obj147 * num57;
																		num55 = (float)obj148 * num57;
																		bool flag42 = (nint)vector8 <= 0;
																		vector7 = (Vector2)num57;
																		if (!flag42)
																		{
																			object obj149 = obj118 - obj113;
																			float num59 = num50 - num49;
																			float num60 = num50;
																			float num61 = x3;
																			float num62 = (float)vector8;
																			float num63 = num55;
																			object obj150 = 0;
																			while (true)
																			{
																				num58 ^= num61;
																				num55 = num63 ^ num61;
																				float num64 = (float)obj150 + 0.5f;
																				float num65 = num64 / num62;
																				float num66;
																				float num67;
																				if (!(0f > num65))
																				{
																					if (num65 > 1f)
																					{
																						num66 = (float)obj113 + (float)obj149;
																						num65 = 1f;
																						goto IL_2f87;
																					}
																					num67 = num65;
																				}
																				else
																				{
																					num65 = 0f;
																					num67 = 0f;
																				}
																				float num68 = num67 * (float)obj149;
																				num66 = num68 + (float)obj113;
																				goto IL_2f87;
																				IL_2453:
																				float num69 = 1f;
																				goto IL_3077;
																				IL_232c:
																				float num71;
																				float num70 = num71 - num60;
																				float num72 = num56 * 1.25f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
																				object obj151 = num70 & 0;
																				num46 = (float)obj151 / num72;
																				float num74;
																				float num75;
																				float num76;
																				if (!(0f > num46))
																				{
																					if (num46 > 1f)
																					{
																						float num73 = num74 * 1f;
																						num75 = num71 + num55;
																						num76 = num66 + num73;
																						num46 = 1f;
																						vector7 = (Vector2)num72;
																						goto IL_3007;
																					}
																				}
																				else
																				{
																					num46 = 0f;
																				}
																				float num77 = num74 * num46;
																				num75 = num71 + num55;
																				num76 = num66 + num77;
																				vector7 = (Vector2)num72;
																				goto IL_3007;
																				IL_30a3:
																				float num79;
																				float num78 = num79 * num46;
																				num76 = num66 + num58;
																				float num80 = num78 + num71;
																				num75 = num80;
																				float num81;
																				vector7 = (Vector2)num81;
																				goto IL_3007;
																				IL_3007:
																				if (0f > num76 || num76 > 1f)
																				{
																				}
																				if (0f > num75 || num75 > 1f)
																				{
																				}
																				list3.Add(vector2);
																				obj150++;
																				bool flag43 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj150) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector8);
																				x3 = -0f;
																				float num14 = num59;
																				float num15 = (float)vector8;
																				num60 = num50;
																				num61 = -0f;
																				num62 = (float)vector8;
																				num63 = num55;
																				if (flag43)
																				{
																					continue;
																				}
																				goto IL_2690;
																				IL_3077:
																				num79 = num55 * num69;
																				bool flag44;
																				if (obj105 != null)
																				{
																					if ((nint)obj105 != 2)
																					{
																						goto IL_25aa;
																					}
																					flag44 = obj104 == null;
																				}
																				else
																				{
																					ShatterDetails shatterDetails34 = this.shatterDetails;
																					if (this.shatterDetails == null)
																					{
																						break;
																					}
																					object obj152 = obj104 - shatterDetails34.verticalCuts;
																					flag44 = obj152 == null;
																				}
																				object obj153 = !flag44;
																				if (obj153 != null)
																				{
																					goto IL_25aa;
																				}
																				num46 = 1f;
																				goto IL_30a3;
																				IL_2f87:
																				float num82 = num65 * num59;
																				num71 = num82 + num49;
																				float num83;
																				float num84;
																				float num85;
																				if (obj105 != null)
																				{
																					if ((nint)obj105 != 2)
																					{
																						if ((nint)obj105 == 1)
																						{
																							bool flag45 = obj107 == null;
																							num83 = num49;
																							if (flag45)
																							{
																								goto IL_21b6;
																							}
																						}
																						else if ((nint)obj105 == 3)
																						{
																							ShatterDetails shatterDetails35 = this.shatterDetails;
																							if (this.shatterDetails == null)
																							{
																								break;
																							}
																							if ((nint)obj107 == shatterDetails35.horizontalCuts)
																							{
																								num84 = 1f;
																								num85 = num49;
																								goto IL_2fc2;
																							}
																						}
																						float num86 = num71 - num49;
																						num83 = num56 * 1.25f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
																						object obj154 = num86 & 0;
																						num84 = (float)obj154 / num83;
																						if (!(0f > num84))
																						{
																							bool flag46 = !(num84 > 1f);
																							num85 = num83;
																							if (!flag46)
																							{
																								goto IL_21b6;
																							}
																						}
																						else
																						{
																							num84 = 0f;
																							num85 = num83;
																						}
																						goto IL_2fc2;
																					}
																					ShatterDetails shatterDetails36 = this.shatterDetails;
																					if (this.shatterDetails == null)
																					{
																						break;
																					}
																					bool flag47 = (nint)obj104 != shatterDetails36.verticalCuts;
																					num81 = num49;
																					if (!flag47)
																					{
																						goto IL_2453;
																					}
																				}
																				else
																				{
																					bool flag48 = obj104 == null;
																					num81 = num49;
																					if (flag48)
																					{
																						goto IL_2453;
																					}
																				}
																				float num87 = num66 - (float)obj113;
																				num81 = num56 * 1.25f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
																				object obj155 = num87 & 0;
																				num69 = (float)obj155 / num81;
																				if (!(0f > num69))
																				{
																					if (num69 > 1f)
																					{
																						goto IL_2453;
																					}
																				}
																				else
																				{
																					num69 = 0f;
																				}
																				goto IL_3077;
																				IL_21b6:
																				num84 = 1f;
																				num85 = num83;
																				goto IL_2fc2;
																				IL_2fc2:
																				num74 = num58 * num84;
																				bool flag49;
																				if ((nint)obj105 != 1)
																				{
																					if ((nint)obj105 != 3)
																					{
																						goto IL_232c;
																					}
																					flag49 = obj107 == null;
																				}
																				else
																				{
																					ShatterDetails shatterDetails37 = this.shatterDetails;
																					if (this.shatterDetails == null)
																					{
																						break;
																					}
																					object obj156 = obj107 - shatterDetails37.horizontalCuts;
																					flag49 = obj156 == null;
																				}
																				object obj157 = !flag49;
																				if (obj157 != null)
																				{
																					goto IL_232c;
																				}
																				float num88 = num74 * 1f;
																				num75 = num71 + num55;
																				num76 = num66 + num88;
																				num46 = 1f;
																				vector7 = (Vector2)num85;
																				goto IL_3007;
																				IL_25aa:
																				float num89 = num66 - (float)obj118;
																				num81 = num56 * 1.25f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
																				object obj158 = num89 & 0;
																				num46 = (float)obj158 / num81;
																				if (!(0f > num46))
																				{
																					if (num46 > 1f)
																					{
																						num46 = 1f;
																					}
																				}
																				else
																				{
																					num46 = 0f;
																				}
																				goto IL_30a3;
																			}
																			break;
																		}
																		goto IL_2690;
																	}
																	break;
																}
																goto IL_2740;
																IL_26a6:
																ShatterDetails shatterDetails38 = this.shatterDetails;
																if (this.shatterDetails == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B73D0");
																if (array5 == null)
																{
																	break;
																}
																object obj159 = shatterDetails38.horizontalCuts + 1;
																object obj160 = obj159 * obj104;
																object obj161 = obj160 + obj107;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																obj107++;
															}
															goto IL_27b5;
															IL_2740:
															obj104++;
															bool flag50 = this.shatterDetails != null;
															obj106 = obj104;
															shatterDetails30 = this.shatterDetails;
															if (flag50)
															{
																continue;
															}
															goto IL_27b5;
														}
														goto IL_2787;
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
		goto IL_27b5;
		IL_27b5:
		return (Vector2[][])(object)new NullReferenceException();
		IL_2787:
		return result;
	}

	private unsafe static bool transformArrayContainsGameObject(Transform[] transformArray, string gameObjectName)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_018c: Expected I4, but got O
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Ref, but got Unknown
		//IL_0125: Expected I8, but got I4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Ref, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < transformArray.Length)
			{
				if ((nint)obj2 >= transformArray.Length)
				{
					break;
				}
				GameObject gameObject = transformArray[obj2].gameObject;
				string text = ((UnityEngine.Object)gameObject).GetName();
				if ((object)text != gameObjectName)
				{
					if (text == null || gameObjectName == null || text._stringLength != gameObjectName._stringLength)
					{
						goto IL_0157;
					}
					ref byte second = ref *(byte*)(gameObjectName + 20);
					ulong length = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(text + 20), ref second, length))
					{
						goto IL_0157;
					}
				}
				return true;
			}
			return false;
			IL_0157:
			obj2++;
			obj = obj2;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private void shatter()
	{
		if (error)
		{
			return;
		}
		Transform transform = shatterGameObjectTransform;
		bool flag = (object)shatterGameObjectTransform == null;
		Renderer renderer = null;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			renderer = null;
			if (!flag2)
			{
				Transform parent = shatterGameObjectTransform.parent;
				GameObject gameObject = parent.gameObject;
				SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
				renderer = component;
			}
		}
		Transform transform2 = shatterGameObjectTransform;
		if ((object)shatterGameObjectTransform != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0 && (object)renderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
		{
			renderer.enabled = false;
			GameObject gameObject2 = shatterGameObjectTransform.gameObject;
			gameObject2.SetActive(value: true);
		}
		else
		{
			string text = GetName();
			string message = "Sprite Shatter (" + text + "): The Sprite Shatter game object or its Sprite Renderer could not be found. Please initialise the \"Sprite Shatter\" component again.";
			Debug.LogWarning(message);
		}
	}

	public void Destroy()
	{
		if (error)
		{
			return;
		}
		Transform transform = shatterGameObjectTransform;
		bool flag = (object)shatterGameObjectTransform == null;
		Renderer renderer = null;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			renderer = null;
			if (!flag2)
			{
				Transform parent = shatterGameObjectTransform.parent;
				GameObject gameObject = parent.gameObject;
				SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
				renderer = component;
			}
		}
		Transform transform2 = shatterGameObjectTransform;
		if ((object)shatterGameObjectTransform != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0 && (object)renderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
		{
			renderer.enabled = true;
			GameObject obj = shatterGameObjectTransform.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
		else
		{
			string text = GetName();
			string message = "Sprite Shatter (" + text + "): The Sprite Shatter game object or its Sprite Renderer could not be found. Please initialise the \"Sprite Shatter\" component again.";
			Debug.LogWarning(message);
		}
	}

	private unsafe ushort[] generateMeshTriangles(Vector2[] vertices)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0204: Expected O, but got I4
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_0241: Expected O, but got I
		//IL_024a: Expected O, but got I4
		//IL_0253: Expected O, but got I4
		//IL_025c: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0f3b: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_00e5: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_011f: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_0170: Invalid comparison between F4 and I4
		//IL_017f: Invalid comparison between F4 and I4
		//IL_01a8: Expected O, but got I4
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01c8: Expected I4, but got O
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_0e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e18: Expected O, but got Unknown
		//IL_0340: Expected O, but got I
		//IL_0e42: Expected O, but got I
		//IL_03cb: Expected O, but got I
		//IL_03db: Expected O, but got I
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Expected O, but got Unknown
		//IL_0425: Expected O, but got I
		//IL_03f0: Expected O, but got I
		//IL_047c: Expected O, but got I
		//IL_04e1: Expected O, but got I
		//IL_04f6: Expected O, but got I
		//IL_0ffc: Expected O, but got I
		//IL_052a: Expected O, but got I
		//IL_053f: Expected O, but got I
		//IL_1030: Expected O, but got I
		//IL_0554: Expected O, but got I
		//IL_0569: Expected O, but got I
		//IL_057e: Expected O, but got I
		//IL_0f08: Expected O, but got I
		//IL_0593: Expected O, but got I
		//IL_05a8: Expected O, but got I
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Expected O, but got Unknown
		//IL_08e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Expected O, but got Unknown
		//IL_08ff: Expected I4, but got O
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Expected O, but got Unknown
		//IL_0950: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Expected O, but got Unknown
		//IL_0987: Expected I4, but got O
		//IL_09f1: Expected O, but got I
		//IL_0a01: Expected O, but got I
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_0a25: Expected O, but got I4
		//IL_0cd3: Expected O, but got I4
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a6: Expected O, but got Unknown
		//IL_0d69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6e: Expected O, but got Unknown
		//IL_0aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Expected O, but got Unknown
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06de: Expected O, but got Unknown
		//IL_0d94: Expected O, but got I4
		//IL_0dad: Expected O, but got I4
		//IL_0d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4b: Expected O, but got Unknown
		//IL_0d11: Expected O, but got I
		//IL_0d1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1f: Expected O, but got Unknown
		//IL_0d2f: Expected O, but got I
		//IL_0ab9: Expected O, but got I
		//IL_0ac9: Expected O, but got I
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_0b49: Expected O, but got I
		//IL_0f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f83: Expected O, but got Unknown
		//IL_0b5e: Expected O, but got I
		//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b91: Expected O, but got Unknown
		//IL_0bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb1: Expected O, but got Unknown
		//IL_0bf0: Expected O, but got I
		//IL_0c0d: Expected O, but got I
		//IL_0c2a: Expected O, but got I
		//IL_0c7f: Invalid comparison between F4 and I4
		//IL_0c8e: Expected O, but got I4
		//IL_07b7: Expected F4, but got I
		//IL_07c7: Expected F4, but got I
		//IL_0813: Expected F4, but got I
		//IL_0813: Expected F4, but got I
		//IL_0813: Expected F4, but got I
		//IL_0813: Expected F4, but got Ref
		//IL_0caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Expected O, but got Unknown
		//IL_0cc5: Expected O, but got I4
		//IL_08ba: Expected O, but got I4
		//IL_088e: Expected O, but got I
		//IL_0899: Expected O, but got I4
		LinkedList<ushort> linkedList = null;
		object obj = 0;
		object obj2 = 0;
		float x = default(float);
		float y = default(float);
		float xPos = default(float);
		float yPos = default(float);
		NullReferenceException ex15 = default(NullReferenceException);
		while (true)
		{
			if ((nint)obj2 < vertices.Length)
			{
				object obj3 = vertices.Length - 1;
				object obj4 = obj3 + obj;
				object obj5 = obj4 % vertices.Length;
				if ((nint)obj5 >= vertices.Length)
				{
					break;
				}
				object obj6 = obj + 1;
				object obj7 = obj6 % vertices.Length;
				if ((nint)obj7 >= vertices.Length || (nint)obj >= vertices.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v426 @ rdx_v15*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v201 @ rdi_v4*8]");
				object obj8 = num - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v426 @ rdx_v15*8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v201 @ rdi_v4*8]");
				object obj9 = num2 - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v190 @ rdx_v17*8]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v201 @ rdi_v4*8]");
				object obj10 = num3 - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v190 @ rdx_v17*8]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v201 @ rdi_v4*8]");
				object obj11 = num4 - 0;
				object obj12 = obj11 * obj8;
				float num5 = (float)obj10 * (float)obj9;
				float num6 = (float)obj12 - num5;
				bool flag = num6 < 0f;
				bool flag2 = num6 == 0f;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				object obj13 = flag4 & flag3;
				object obj14 = obj13 * 32768;
				ushort value = (ushort)(int)(obj14 + obj);
				LinkedListNode<ushort> linkedListNode = linkedList.AddLast(value);
				obj++;
				obj2 = obj;
				continue;
			}
			object obj15 = vertices.Length - 2;
			object obj16 = obj15 * 2;
			object obj17 = obj15 + obj16;
			ushort[] array = new ushort[obj17];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
			NullReferenceException ex = (NullReferenceException)0;
			object obj18 = 0;
			object obj19 = 0;
			object obj20 = 32768;
			while (true)
			{
				object obj21 = 32767;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+18]");
					object obj40;
					NullReferenceException ex12;
					if ((nint)0 > (nint)2)
					{
						object obj22 = obj18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+18]");
						bool flag5 = (nint)obj22 >= 0;
						LinkedListNode<ushort> node = (LinkedListNode<ushort>)(object)ex;
						if (!flag5)
						{
							bool flag6;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v8 (System.Collections.Generic.LinkedListNode`1<System.UInt16>)+28]");
								if (0 >= (nint)obj20)
								{
									object obj23 = obj18;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+18]");
									object obj24 = obj23 - 0;
									flag6 = obj24 == null;
									object obj25 = obj18;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+18]");
									if ((nint)obj25 >= 0)
									{
										break;
									}
									NullReferenceException ex2 = new NullReferenceException();
									bool flag7 = ex2 != null;
									NullReferenceException ex3 = ex2;
									if (!flag7)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
										ex3 = (NullReferenceException)0;
									}
									obj18++;
									node = (LinkedListNode<ushort>)(object)ex3;
									continue;
								}
								object obj26 = obj18;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+18]");
								object obj27 = obj26 - 0;
								flag6 = obj27 == null;
								break;
							}
							if (!flag6)
							{
								NullReferenceException ex4 = new NullReferenceException();
								Exception ex5;
								if (ex4 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
									if (0 == (nint)ex4)
									{
										goto IL_0db7;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
									object obj28 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v80+20]");
									object obj29 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v45+28]");
									ex5 = (Exception)0;
								}
								else
								{
									NullReferenceException ex6 = new NullReferenceException();
									ex5 = ((Exception)ex6)._innerException;
								}
								object obj30 = (object)ex5 & obj21;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v8 (System.Collections.Generic.LinkedListNode`1<System.UInt16>)+28]");
								object obj31 = 0;
								NullReferenceException ex7 = new NullReferenceException();
								NullReferenceException ex8;
								if (ex7 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
									ex8 = (NullReferenceException)0;
								}
								else
								{
									ex8 = new NullReferenceException();
								}
								object obj32 = ((Exception)ex8)._innerException & 0x7FFF;
								if ((nint)obj30 >= vertices.Length)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v198 @ r15_v9*8]");
								Vector2 vector = (Vector2)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v8 (System.Collections.Generic.LinkedListNode`1<System.UInt16>)+28]");
								if ((nint)0 >= (nint)vertices.Length)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v81 @ r13_v8*8]");
								nint num7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v198 @ r15_v9*8]");
								if (num7 <= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v81 @ r13_v8*8]");
									vector = (Vector2)0;
								}
								if ((nint)obj32 >= vertices.Length)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v198 @ r15_v9*8]");
								Vector2 vector2 = (Vector2)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v141 @ rbp_v8*8]");
								if (0 <= (nint)vector)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v141 @ rbp_v8*8]");
									vector = (Vector2)0;
								}
								Vector2 vector3 = vector2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v81 @ r13_v8*8]");
								if ((nint)vector3 <= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v81 @ r13_v8*8]");
									vector2 = (Vector2)0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v198 @ r15_v9*8]");
								Vector2 vector4 = (Vector2)0;
								Vector2 vector5 = vector2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v141 @ rbp_v8*8]");
								if ((nint)vector5 <= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v141 @ rbp_v8*8]");
									vector2 = (Vector2)0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v81 @ r13_v8*8]");
								if (0 <= (nint)vector4)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v81 @ r13_v8*8]");
									vector4 = (Vector2)0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v198 @ r15_v9*8]");
								Vector2 vector6 = (Vector2)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v141 @ rbp_v8*8]");
								if (0 <= (nint)vector4)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v141 @ rbp_v8*8]");
									vector4 = (Vector2)0;
								}
								Vector2 vector7 = vector6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v81 @ r13_v8*8]");
								if ((nint)vector7 <= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v81 @ r13_v8*8]");
									vector6 = (Vector2)0;
								}
								Vector2 vector8 = vector6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v141 @ rbp_v8*8]");
								if ((nint)vector8 <= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v141 @ rbp_v8*8]");
									vector6 = (Vector2)0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
								NullReferenceException ex9 = (NullReferenceException)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
								NullReferenceException ex10;
								for (bool flag8 = (nint)0 == 0; !flag8; ex10 = new NullReferenceException(), flag8 = ex10 == null, ex9 = ex10)
								{
									object obj33 = ((Exception)ex9)._innerException - 32768;
									if ((nint)obj33 < 0 || obj33 == obj30)
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v8 (System.Collections.Generic.LinkedListNode`1<System.UInt16>)+28]");
									if (obj33 == null || obj33 == obj32)
									{
										continue;
									}
									object obj34 = ((Exception)ex9)._innerException - 32768;
									if ((nint)obj34 >= vertices.Length)
									{
										goto end_IL_0ddb;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v492 @ rax_v65*8]");
									if (0 < (nint)vector)
									{
										continue;
									}
									object obj35 = ((Exception)ex9)._innerException - 32768;
									Vector2 vector9 = vector2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v1281 @ rax_v67*8]");
									if ((nint)vector9 < 0)
									{
										continue;
									}
									object obj36 = ((Exception)ex9)._innerException - 32768;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v1282 @ rax_v69*8]");
									if (0 < (nint)vector4)
									{
										continue;
									}
									object obj37 = ((Exception)ex9)._innerException - 32768;
									Vector2 vector10 = vector6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v493 @ rax_v71*8]");
									if ((nint)vector10 < 0)
									{
										continue;
									}
									if ((nint)obj30 >= vertices.Length)
									{
										goto end_IL_0ddb;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v8 (System.Collections.Generic.LinkedListNode`1<System.UInt16>)+28]");
									if ((nint)0 >= (nint)vertices.Length || (nint)obj32 >= vertices.Length)
									{
										goto end_IL_0ddb;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v81 @ r13_v8*8]");
									float num5 = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v81 @ r13_v8*8]");
									float num6 = 0f;
									ref Vector2 reference = ref vertices[obj30];
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v198 @ r15_v9*8]");
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v81 @ r13_v8*8]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v81 @ r13_v8*8]");
									bool flag9 = ShatterMaths.pointIn2DTriangle((nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference), num8, num9, 0f, x, y, xPos, yPos);
									bool flag10 = flag9;
									if (!flag9)
									{
										continue;
									}
									goto IL_0855;
								}
								if ((nint)obj19 >= array.Length)
								{
									break;
								}
								object obj38 = obj19 + 1;
								array[obj19] = (ushort)(int)obj32;
								if ((nint)obj38 >= array.Length)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v8 (System.Collections.Generic.LinkedListNode`1<System.UInt16>)+28]");
								array[obj38] = 0;
								object obj39 = obj19 + 2;
								obj40 = obj39 + 1;
								if ((nint)obj39 >= array.Length)
								{
									break;
								}
								array[obj39] = (ushort)(int)obj30;
								NullReferenceException ex11 = new NullReferenceException();
								if (ex11 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
									if (0 == (nint)ex11)
									{
										ex12 = null;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
										object obj41 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1404 @ rax_v59+20]");
										ex12 = (NullReferenceException)0;
									}
								}
								else
								{
									NullReferenceException ex13 = new NullReferenceException();
									ex12 = ex13;
								}
								linkedList.Remove(node);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+18]");
								if ((nint)0 > (nint)2)
								{
									object obj42 = 0;
									NullReferenceException ex14 = ex15;
									LinkedList<ushort> linkedList2 = linkedList;
									while (true)
									{
										if ((nint)((Exception)ex12)._innerException >= 32768)
										{
											NullReferenceException ex16 = new NullReferenceException();
											NullReferenceException ex17;
											if (ex16 == null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
												if (0 == (nint)ex16)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
												object obj43 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1530 @ rax_v56+20]");
												ex17 = (NullReferenceException)0;
											}
											else
											{
												ex17 = new NullReferenceException();
											}
											object obj44 = ((Exception)ex17)._innerException & 0x7FFF;
											if ((nint)obj44 >= vertices.Length)
											{
												goto end_IL_0ddb;
											}
											NullReferenceException ex18 = new NullReferenceException();
											Exception ex19;
											if (ex18 == null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
												object obj45 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v32+28]");
												ex19 = (Exception)0;
											}
											else
											{
												NullReferenceException ex20 = new NullReferenceException();
												ex19 = ((Exception)ex20)._innerException;
											}
											object obj46 = ex19 & 0x7FFF;
											if ((nint)obj46 >= vertices.Length)
											{
												goto end_IL_0ddb;
											}
											object obj47 = ex19 & 0x7FFF;
											linkedList2 = (LinkedList<ushort>)(object)((Exception)ex12)._innerException;
											ex14 = (NullReferenceException)(((Exception)ex12)._innerException - 32768);
											if ((nint)ex14 >= vertices.Length)
											{
												goto end_IL_0ddb;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v496 @ rax_v47*8]");
											nint num10 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+FFFC0020+v884 @ rcx_v21 (System.Collections.Generic.LinkedList`1<System.UInt16>)*8]");
											vector6 = (Vector2)(num10 - 0);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v496 @ rax_v47*8]");
											nint num11 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+FFFC0024+v884 @ rcx_v21 (System.Collections.Generic.LinkedList`1<System.UInt16>)*8]");
											vector4 = (Vector2)(num11 - 0);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+20+v1568 @ rcx_v28*8]");
											nint num12 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+FFFC0020+v884 @ rcx_v21 (System.Collections.Generic.LinkedList`1<System.UInt16>)*8]");
											object obj48 = num12 - 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+24+v1568 @ rcx_v28*8]");
											float num13 = 0f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [vertices @ rdx (UnityEngine.Vector2[])+FFFC0024+v884 @ rcx_v21 (System.Collections.Generic.LinkedList`1<System.UInt16>)*8]");
											float num14 = num13 - 0f;
											float num15 = num14 * (float)vector6;
											float num5 = (float)obj48 * (float)vector4;
											float num6 = num15 - num5;
											bool flag11 = num6 > 0f;
											obj21 = 32767;
											if (!flag11)
											{
												Exception innerException = (Exception)(((Exception)ex12)._innerException + 32768);
												((Exception)ex12)._innerException = innerException;
												obj21 = 32767;
											}
										}
										else
										{
											obj21 = 32767;
										}
										if (obj42 == null)
										{
											ex14 = new NullReferenceException();
											if (ex14 == null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
												ex12 = (NullReferenceException)0;
												obj42++;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
												linkedList2 = (LinkedList<ushort>)0;
											}
											else
											{
												ex14 = new NullReferenceException();
												obj42++;
												ex12 = ex14;
												linkedList2 = (LinkedList<ushort>)(object)ex14;
											}
										}
										else
										{
											obj42++;
											if ((nint)obj42 >= 2)
											{
												goto IL_0d8b;
											}
										}
									}
									goto IL_0db7;
								}
							}
						}
					}
					return array;
					IL_0db7:
					throw new NullReferenceException();
					IL_0d8b:
					obj18 = 0;
					ex = ex12;
					obj19 = obj40;
					obj20 = 32768;
				}
				break;
				IL_0855:
				NullReferenceException ex21 = new NullReferenceException();
				if (ex21 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v2 (System.Collections.Generic.LinkedList`1<System.UInt16>)+10]");
					ex = (NullReferenceException)0;
					obj20 = 32768;
				}
				else
				{
					NullReferenceException ex22 = new NullReferenceException();
					ex = ex22;
					obj20 = 32768;
				}
			}
			break;
			continue;
			end_IL_0ddb:
			break;
		}
		return (ushort[])(object)new IndexOutOfRangeException();
	}

	public ShatterVFX()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
