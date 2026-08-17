using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DParallax : BasePC2D, IPostMover
{
	private sealed class _003CAnimate_003Ed__23(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DParallax _003C_003E4__this;

		public float duration;

		public bool value;

		public EaseType easeType;

		private float[] _003CcurrentSpeeds_003E5__2;

		private float _003Ct_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_01ef: Expected I4, but got I8
			//IL_0029: Expected O, but got I
			//IL_006d: Expected F4, but got I4
			//IL_0076: Expected F4, but got I4
			//IL_0085: Invalid comparison between F4 and I4
			//IL_0242: Expected F4, but got I4
			//IL_024b: Expected F4, but got I4
			//IL_04c9: Expected O, but got I
			//IL_00ac: Expected O, but got I
			//IL_0260: Invalid comparison between F4 and I
			//IL_00c1: Invalid comparison between F4 and I
			//IL_045b: Expected I4, but got O
			//IL_00e8: Expected O, but got I
			//IL_00fd: Invalid comparison between F4 and I
			//IL_0315: Invalid comparison between F4 and I4
			//IL_02bc: Invalid comparison between F4 and I4
			//IL_0124: Expected O, but got I
			//IL_033c: Expected O, but got I
			//IL_0351: Invalid comparison between F4 and I
			//IL_0142: Invalid comparison between F4 and I4
			//IL_0378: Expected F4, but got I
			//IL_0182: Expected F4, but got I
			BasePC2D basePC2D = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rsi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v23+18]");
				float[] array = new float[0];
				_003CcurrentSpeeds_003E5__2 = array;
				float[] array3 = default(float[]);
				float[] array2 = array3;
				float[] array4 = _003CcurrentSpeeds_003E5__2;
				float num = 0f;
				float num2 = 0f;
				while (num2 < (float)array4.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rsi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
					object obj2 = 0;
					float num3 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v28+18]");
					if (num3 < 0f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v28+10]");
						object obj3 = 0;
						float num4 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v23+18]");
						if (num4 < 0f)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v23+20+v126 @ rdx_v18 (System.Single)*8]");
							object obj4 = 0;
							array2 = _003CcurrentSpeeds_003E5__2;
							if (num < (float)array2.Length)
							{
								float num5 = num + 1f;
								float[] array5 = array2;
								float num6 = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v30+18]");
								array5[num6] = 0f;
								array4 = _003CcurrentSpeeds_003E5__2;
								num = num5;
								num2 = num5;
								continue;
							}
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					goto IL_044d;
				}
				_003Ct_003E5__3 = 0f;
				array3 = array2;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0408;
				}
				_003C_003E1__state = -1;
			}
			if (1f < _003Ct_003E5__3)
			{
				goto IL_0408;
			}
			ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
			float num7 = proCamera2D._003CDeltaTime_003Ek__BackingField / duration;
			float num8 = num7 + _003Ct_003E5__3;
			_003Ct_003E5__3 = num8;
			float num9 = 0f;
			float num10 = 0f;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rsi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
				object obj5 = 0;
				float num11 = num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v7+18]");
				if (num11 < 0f)
				{
					float start;
					float end;
					if (!value)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						float[] array6 = _003CcurrentSpeeds_003E5__2;
						if (!(num9 < (float)array6.Length))
						{
							break;
						}
						start = array6[num9];
						end = 1f;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						float[] array3 = _003CcurrentSpeeds_003E5__2;
						if (!(num9 < (float)array3.Length))
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rsi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
						object obj6 = 0;
						float num12 = num9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v8+18]");
						if (!(num12 < 0f))
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v8+20+v108 @ rdi_v4 (System.Single)*4]");
						end = 0f;
						start = array3[num9];
					}
					num8 = Utils.EaseFromTo(start, end, _003Ct_003E5__3, easeType);
					num9++;
					num10 = num9;
					continue;
				}
				ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
				bool flag = proCamera2D2.UpdateType != UpdateType.FixedUpdate;
				WaitForFixedUpdate waitForFixedUpdate = null;
				if (!flag)
				{
					bool flag2 = proCamera2D2.IgnoreTimeScale;
					waitForFixedUpdate = null;
					if (!flag2)
					{
						waitForFixedUpdate = proCamera2D2._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = waitForFixedUpdate;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_044d;
			IL_0408:
			return false;
			IL_044d:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
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

	public static string ExtensionName = "Parallax";

	public List<ProCamera2DParallaxLayer> ParallaxLayers;

	public bool ParallaxHorizontal;

	public bool ParallaxVertical;

	public bool ParallaxZoom;

	public Vector3 RootPosition;

	public int FrontDepthStart;

	public int BackDepthStart;

	public bool UseIndependentAxisSpeeds;

	public bool AutomaticallyConfigureCameraClearFlags;

	private float _initialOrtographicSize;

	private float[] _initialSpeeds;

	private Coroutine _animateCoroutine;

	private int _pmOrder;

	public int PMOrder
	{
		get
		{
			return _pmOrder;
		}
		set
		{
			_pmOrder = value;
		}
	}

	protected override void Awake()
	{
		//IL_0410: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_00e4: Expected O, but got I
		//IL_00f5: Expected I4, but got O
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_053e: Expected O, but got F4
		//IL_054a: Expected F4, but got O
		//IL_059d: Expected O, but got I4
		//IL_03c0->IL03c0: Incompatible stack heights: 5 vs 0
		//IL_00ff->IL0454: Incompatible stack heights: 2 vs 1
		//IL_02b4->IL049f: Incompatible stack heights: 11 vs 3
		//IL_03d0->IL03d0: Incompatible stack heights: 6 vs 0
		//IL_05b8->IL04e7: Incompatible stack heights: 9 vs 4
		//IL_05ed->IL04e7: Incompatible stack heights: 10 vs 4
		List<ProCamera2DParallaxLayer>.Enumerator enumerator = default(List<ProCamera2DParallaxLayer>.Enumerator);
		while (true)
		{
			base.Awake();
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D == null || ((UnityEngine.Object)proCamera2D).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			object obj = Application.isPlaying;
			if (obj != null)
			{
				CalculateParallaxObjectsOffset();
			}
			bool flag = ParallaxLayers == null;
			while (enumerator.MoveNext())
			{
				ProCamera2D proCamera2D2 = null;
				IntPtr cachedPtr = ((UnityEngine.Object)proCamera2D2).m_CachedPtr;
				if (((UnityEngine.Object)proCamera2D2).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v704 @ r15_v15 (System.IntPtr)+10]");
					if ((nint)0 != 0)
					{
						bool flag2 = ((UnityEngine.Object)proCamera2D2).m_CachedPtr == (IntPtr)0;
						Transform transform = ((Component)(nint)((UnityEngine.Object)proCamera2D2).m_CachedPtr).transform;
						proCamera2D2.CenterTargetOnStart = (byte)(int)transform != 0;
					}
				}
			}
			List<ProCamera2DParallaxLayer> parallaxLayers = ParallaxLayers;
			bool flag3 = ParallaxLayers == null;
			float[] initialSpeeds = new float[parallaxLayers._size];
			_initialSpeeds = initialSpeeds;
			float[] initialSpeeds2 = _initialSpeeds;
			bool flag4 = _initialSpeeds == null;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj3 < initialSpeeds2.Length)
			{
				float[] initialSpeeds3 = _initialSpeeds;
				List<ProCamera2DParallaxLayer> parallaxLayers2 = ParallaxLayers;
				bool flag5 = ParallaxLayers == null;
				bool flag6 = (nint)obj2 >= parallaxLayers2._size;
				ProCamera2DParallaxLayer[] items = parallaxLayers2._items;
				bool flag7 = parallaxLayers2._items == null;
				bool flag8 = (nint)obj2 >= items.Length;
				ProCamera2DParallaxLayer proCamera2DParallaxLayer = items[obj2];
				bool flag9 = items[obj2] == null;
				bool flag10 = _initialSpeeds == null;
				bool flag11 = (nint)obj2 >= initialSpeeds3.Length;
				initialSpeeds3[obj2] = proCamera2DParallaxLayer.Speed;
				obj2++;
				initialSpeeds2 = _initialSpeeds;
				bool flag12 = _initialSpeeds == null;
				obj3 = obj2;
			}
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			bool flag13 = (object)proCamera2D3 == null;
			ProCamera2D gameCamera = (ProCamera2D)(object)proCamera2D3.GameCamera;
			if ((object)proCamera2D3.GameCamera == null || ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0)
			{
				break;
			}
			ProCamera2D proCamera2D4 = base.ProCamera2D;
			bool flag14 = (object)proCamera2D4 == null;
			ProCamera2D gameCamera2 = (ProCamera2D)(object)proCamera2D4.GameCamera;
			bool flag15 = (object)proCamera2D4.GameCamera == null;
			if (((UnityEngine.Object)gameCamera2).m_CachedPtr != (IntPtr)0)
			{
				object obj4 = Camera.get_orthographicSize_Injected(((UnityEngine.Object)gameCamera2).m_CachedPtr);
				_initialOrtographicSize = (float)ParallaxLayers;
				ProCamera2D proCamera2D5 = base.ProCamera2D;
				bool flag16 = (object)proCamera2D5 == null;
				ProCamera2D gameCamera3 = (ProCamera2D)(object)proCamera2D5.GameCamera;
				bool flag17 = (object)proCamera2D5.GameCamera == null;
				bool flag18 = ((UnityEngine.Object)gameCamera3).m_CachedPtr == (IntPtr)0;
				object obj5 = Camera.get_orthographic_Injected(((UnityEngine.Object)gameCamera3).m_CachedPtr);
				if (obj5 == null)
				{
					bool flag19 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					Behaviour.set_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr, false);
				}
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(proCamera2D4.GameCamera);
		}
		ProCamera2D proCamera2D6 = base.ProCamera2D;
		bool flag20 = (object)proCamera2D6 == null;
		proCamera2D6.AddPostMover(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._postMovers).Remove((object)this);
		}
	}

	public void PostMove(float deltaTime)
	{
		//IL_0040: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			Move();
		}
	}

	public unsafe void CalculateParallaxObjectsOffset()
	{
		//IL_0056: Expected I4, but got O
		//IL_006d: Expected O, but got Ref
		//IL_049c->IL010e: Incompatible stack heights: 3 vs 0
		ProCamera2DParallaxObject[] array = UnityEngine.Object.FindObjectsOfType<ProCamera2DParallaxObject>();
		Dictionary<int, ProCamera2DParallaxLayer> dictionary = new Dictionary<int, ProCamera2DParallaxLayer>();
		int num = 0;
		List<ProCamera2DParallaxLayer>.Enumerator enumerator = default(List<ProCamera2DParallaxLayer>.Enumerator);
		while (num <= 31)
		{
			System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)ParallaxLayers;
			if (enumerator.MoveNext())
			{
				object obj = null;
				List<ProCamera2DParallaxLayer>.Enumerator enumerator2 = (List<ProCamera2DParallaxLayer>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			num++;
			int num2 = 0;
		}
		int num3 = 0;
		List<ProCamera2DParallaxLayer>.Enumerator enumerator3 = default(List<ProCamera2DParallaxLayer>.Enumerator);
		object obj3 = default(object);
		List<ProCamera2DParallaxLayer>.Enumerator value = default(List<ProCamera2DParallaxLayer>.Enumerator);
		for (int num4 = 0; num4 < array.Length; num4 = num3)
		{
			Transform transform = array[num3].transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Func<Vector3, float> vector3H = Vector3H;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v437 @ rcx_v26 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num5;
			if (UseIndependentAxisSpeeds)
			{
				GameObject gameObject = array[num3].gameObject;
				int layer = gameObject.layer;
				ProCamera2DParallaxLayer proCamera2DParallaxLayer = dictionary.get_Item(layer);
				num5 = proCamera2DParallaxLayer.SpeedX;
			}
			else
			{
				GameObject gameObject2 = array[num3].gameObject;
				int layer2 = gameObject2.layer;
				ProCamera2DParallaxLayer proCamera2DParallaxLayer2 = dictionary.get_Item(layer2);
				num5 = proCamera2DParallaxLayer2.Speed;
			}
			float num6 = (float)enumerator3 * num5;
			Func<Vector3, float> vector3V = Vector3V;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v438 @ rcx_v29 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num7;
			if (UseIndependentAxisSpeeds)
			{
				GameObject gameObject3 = array[num3].gameObject;
				int layer3 = gameObject3.layer;
				ProCamera2DParallaxLayer proCamera2DParallaxLayer3 = dictionary.get_Item(layer3);
				num7 = proCamera2DParallaxLayer3.SpeedY;
			}
			else
			{
				GameObject gameObject4 = array[num3].gameObject;
				int layer4 = gameObject4.layer;
				ProCamera2DParallaxLayer proCamera2DParallaxLayer4 = dictionary.get_Item(layer4);
				num7 = proCamera2DParallaxLayer4.Speed;
			}
			Transform transform2 = array[num3].transform;
			Transform vectorHVD = (Transform)(object)VectorHVD;
			Func<Vector3, float> vector3D = Vector3D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rcx_v33 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
			System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v435 @ rcx_v33 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			float num8 = (float)enumerator3 * num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v388 @ rdi_v13 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
			object obj2 = (object)RootPosition + obj3;
			object obj4 = (object)enumerator3 + (object)enumerator3;
			bool flag2 = (object)transform2 == null;
			bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
			num3++;
		}
	}

	private unsafe void Move()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0844: Expected F4, but got O
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Expected O, but got Unknown
		//IL_0168: Expected O, but got I
		//IL_08af: Expected O, but got Ref
		//IL_048d: Expected O, but got I
		//IL_0355: Expected O, but got I
		//IL_04df: Expected O, but got I
		//IL_043e: Expected F4, but got I
		//IL_054d: Expected O, but got Ref
		//IL_03cc: Expected F4, but got I
		//IL_0595: Expected O, but got Ref
		//IL_05a5: Expected O, but got I
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected O, but got Unknown
		//IL_076d: Expected O, but got I
		//IL_077e: Expected O, but got I4
		//IL_07c3->IL098b: Incompatible stack heights: 9 vs 3
		//IL_02f8->IL08ea: Incompatible stack heights: 17 vs 15
		//IL_0296->IL08ea: Incompatible stack heights: 17 vs 15
		//IL_0462->IL0913: Incompatible stack heights: 18 vs 16
		//IL_03f0->IL0913: Incompatible stack heights: 18 vs 16
		//IL_0986->IL0783: Incompatible stack heights: 23 vs 8
		//IL_0783->IL0783: Incompatible stack heights: 30 vs 8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = _transform;
		bool flag = (object)_transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		List<ProCamera2DParallaxLayer> parallaxLayers = ParallaxLayers;
		bool flag3 = ParallaxLayers == null;
		Transform transform2 = null;
		float num = (float)RootPosition;
		float num3 = default(float);
		float num2 = num3;
		Transform transform3 = null;
		object obj3 = default(object);
		object obj5 = default(object);
		object obj6 = default(object);
		object obj8 = default(object);
		object obj9 = default(object);
		object obj10 = default(object);
		object obj16 = default(object);
		float value = default(float);
		object obj17 = default(object);
		object obj18 = default(object);
		while ((nint)transform3 < parallaxLayers._size)
		{
			List<ProCamera2DParallaxLayer> parallaxLayers2 = ParallaxLayers;
			bool flag4 = ParallaxLayers == null;
			bool flag5 = (nint)transform2 >= parallaxLayers2._size;
			ProCamera2DParallaxLayer[] items = parallaxLayers2._items;
			bool flag6 = parallaxLayers2._items == null;
			bool flag7 = (nint)transform2 >= items.Length;
			ProCamera2DParallaxLayer proCamera2DParallaxLayer = items[(object)transform2];
			bool flag8 = items[(object)transform2] == null;
			Camera cameraTransform = (Camera)(object)proCamera2DParallaxLayer.CameraTransform;
			if ((object)proCamera2DParallaxLayer.CameraTransform != null && ((UnityEngine.Object)cameraTransform).m_CachedPtr != (IntPtr)0)
			{
				bool flag9 = ParallaxLayers == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag10 = obj3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v40+10]");
				Camera camera = (Camera)0;
				ProCamera2D proCamera2D = base.ProCamera2D;
				bool flag11 = (object)proCamera2D == null;
				bool flag12 = (object)proCamera2D.GameCamera == null;
				Rect rect = proCamera2D.GameCamera.rect;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v40+10]");
				bool flag13 = (nint)0 == 0;
				_ = rect.m_XMin;
				bool flag14 = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				Camera.set_rect_Injected(((UnityEngine.Object)camera).m_CachedPtr, ref *(Rect*)obj4);
				bool flag15 = !ParallaxHorizontal;
				Func<Vector3, float> vector3H = Vector3H;
				if (!flag15)
				{
					bool flag16 = Vector3H == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v344 @ rcx_v39 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					if (UseIndependentAxisSpeeds)
					{
						bool flag17 = ParallaxLayers == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag18 = obj5 == null;
						float num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v76+1C]");
						float num5 = num4 * 0f;
						ret = num3;
					}
					else
					{
						bool flag19 = ParallaxLayers == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag20 = obj6 == null;
						float num6 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v75+18]");
						float num5 = num6 * 0f;
						ret = num3;
					}
				}
				else
				{
					bool flag21 = Vector3H == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v344 @ rcx_v39 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					float num5 = num3;
				}
				bool flag22 = !ParallaxVertical;
				Func<Vector3, float> vector3V = Vector3V;
				if (!flag22)
				{
					bool flag23 = Vector3V == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v41 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v346 @ rcx_v41 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					if (UseIndependentAxisSpeeds)
					{
						bool flag24 = ParallaxLayers == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag25 = obj8 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rax_v70+20]");
						float num7 = 0f;
						float num8 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rax_v70+20]");
						float num9 = num8 * 0f;
						float num10 = num3;
					}
					else
					{
						bool flag26 = ParallaxLayers == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag27 = obj9 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v69+18]");
						float num7 = 0f;
						float num11 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v69+18]");
						float num9 = num11 * 0f;
						float num10 = num3;
					}
				}
				else
				{
					bool flag28 = Vector3V == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v41 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v346 @ rcx_v41 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					float num9 = num3;
					float num7 = num3;
				}
				bool flag29 = ParallaxLayers == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag30 = obj10 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v49+28]");
				object obj11 = 0;
				Func<float, float, float, Vector3> vectorHVD = VectorHVD;
				Camera vector3D = (Camera)(object)Vector3D;
				_ = RootPosition;
				bool flag31 = (object)_transform == null;
				Vector3 position = _transform.position;
				bool flag32 = Vector3D == null;
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				_ = position.x;
				_ = position.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v276.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
				bool flag33 = VectorHVD == null;
				object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r15_v13 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v138 @ r15_v13 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
				object obj15 = 0 + obj16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-6C]");
				float num12 = 0f + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DParallax)+74]");
				float num13 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1321 @ rax_v54+8]");
				num = num13 + 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v49+28]");
				bool flag34 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r14_v13 (System.Object)+10]");
				bool flag35 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r14_v13 (System.Object)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
				bool flag36 = !ParallaxZoom;
				num2 = num3;
				if (!flag36)
				{
					bool flag37 = ParallaxLayers == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag38 = obj17 == null;
					ProCamera2D proCamera2D2 = base.ProCamera2D;
					bool flag39 = (object)proCamera2D2 == null;
					bool flag40 = (object)proCamera2D2.GameCamera == null;
					num2 = proCamera2D2.GameCamera.orthographicSize;
					float num5 = _initialOrtographicSize;
					bool flag41 = ParallaxLayers == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag42 = obj18 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v59+10]");
					bool flag43 = (nint)0 == 0;
					float num14 = num2 - _initialOrtographicSize;
					float num15 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v61+18]");
					float num16 = num15 * 0f;
					float num9 = num16 + _initialOrtographicSize;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v59+10]");
					((Camera)0).orthographicSize = num9;
					num = num9;
					obj14 = 0;
				}
			}
			parallaxLayers = ParallaxLayers;
			transform2 = (Transform)(transform2 + 1);
			bool flag44 = ParallaxLayers == null;
			transform3 = transform2;
		}
	}

	public void ToggleParallax(bool value, float duration = 2f, EaseType easeType = EaseType.EaseInOut)
	{
		if (_initialSpeeds != null)
		{
			if (_animateCoroutine != null)
			{
				StopCoroutine(_animateCoroutine);
			}
			_003CAnimate_003Ed__23 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.duration = duration;
			obj.value = value;
			obj.easeType = easeType;
			Coroutine animateCoroutine = StartCoroutine(obj);
			_animateCoroutine = animateCoroutine;
		}
	}

	private IEnumerator Animate(bool value, float duration, EaseType easeType)
	{
		_003CAnimate_003Ed__23 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.value = value;
		obj.easeType = easeType;
		return obj;
	}

	public ProCamera2DParallax()
	{
		//IL_0048: Expected I, but got O
		//IL_008a: Expected I4, but got I8
		List<ProCamera2DParallaxLayer> parallaxLayers = new List<ProCamera2DParallaxLayer>();
		ParallaxLayers = parallaxLayers;
		ParallaxHorizontal = true;
		ParallaxZoom = true;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		RootPosition = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		FrontDepthStart = 1;
		BackDepthStart = -1;
		AutomaticallyConfigureCameraClearFlags = true;
		_pmOrder = 1000;
	}
}
