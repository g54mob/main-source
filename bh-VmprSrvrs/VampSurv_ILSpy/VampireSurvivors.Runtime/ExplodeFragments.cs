using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

public class ExplodeFragments : MonoBehaviour
{
	private struct OriginalTransformData
	{
		public Vector3 scale;

		public Vector3 position;

		public Quaternion rotation;
	}

	private sealed class _003CExplodeCoroutine_003Ed__28(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ExplodeFragments _003C_003E4__this;

		private Vector3 _003CeffectiveGravity_003E5__2;

		private float _003Celapsed_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0048: Expected I4, but got I8
			//IL_06a3: Expected I4, but got I8
			//IL_0084: Expected O, but got I
			//IL_00a1: Expected O, but got I
			//IL_00be: Expected O, but got I
			//IL_00e3: Invalid comparison between F4 and I4
			//IL_06df: Expected F4, but got I4
			//IL_10af: Invalid comparison between I and F4
			//IL_010a: Expected O, but got I
			//IL_011a: Expected O, but got I
			//IL_0caf: Expected O, but got I
			//IL_0e44: Expected O, but got F4
			//IL_0cd3: Expected O, but got I4
			//IL_0f9e: Expected O, but got I
			//IL_0702: Expected F4, but got I4
			//IL_0712: Expected O, but got I
			//IL_0d62: Expected O, but got I
			//IL_01de: Expected O, but got I
			//IL_0172: Expected O, but got I
			//IL_0d4d: Expected O, but got I
			//IL_0d12: Expected O, but got I
			//IL_01a2: Expected O, but got I
			//IL_0be4: Expected O, but got I
			//IL_02ba: Expected F4, but got I4
			//IL_02ca: Expected O, but got I
			//IL_0e27: Expected F4, but got I4
			//IL_027d: Expected O, but got I
			//IL_0282: Expected I, but got O
			//IL_020e->IL020e: Incompatible stack heights: 2 vs 1
			//IL_0be9->IL0fcd: Incompatible stack heights: 0 vs 1
			//IL_1069->IL0e2d: Incompatible stack heights: 1 vs 0
			//IL_02a7->IL0c5d: Incompatible stack heights: 1 vs 0
			//IL_0262->IL0c5d: Incompatible stack heights: 1 vs 0
			//IL_0e2d->IL109f: Incompatible stack heights: 1 vs 0
			//IL_0c4e->IL0c5d: Incompatible stack heights: 1 vs 0
			//IL_109f->IL105e: Incompatible stack heights: 2 vs 1
			Component component = _003C_003E4__this;
			float num6;
			Component component2;
			float num7;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+4C]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+4C]");
					object obj = num * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+48]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+48]");
					object obj2 = num2 * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+44]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+44]");
					object obj3 = num3 * 0;
					object obj4 = obj2 + obj3;
					float num4 = (float)obj + (float)obj4;
					Vector3 vector;
					if (num4 > 0f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+44]");
						vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+4C]");
						object obj5 = 0;
					}
					else
					{
						Physics.get_gravity_Injected(out Vector3 ret);
						vector = ret;
						object obj5 = 0;
					}
					_003CeffectiveGravity_003E5__2 = vector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+80]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+80]");
					bool num5;
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rdi_v39+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+80]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+80]");
							if ((nint)0 == 0)
							{
								goto IL_0c5d;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdi_v45 (System.Object)+10]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdi_v45 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							num5 = flag;
							object obj9 = 0;
							goto IL_0d33;
						}
					}
					Transform transform = _003C_003E4__this.transform;
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v222 (UnityEngine.Transform)+10]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v222 (UnityEngine.Transform)+10]");
						bool flag2 = (nint)0 == 0;
						num5 = flag2;
						object obj9 = 0;
						if ((nint)0 != 0)
						{
							goto IL_0d33;
						}
						bool flag3 = (nint)0 == 0;
						goto IL_0d88;
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0e2d;
				}
				_003C_003E1__state = -1;
				num6 = _003Celapsed_003E5__3;
				if ((object)_003C_003E4__this != null)
				{
					component2 = _003C_003E4__this;
					num7 = 0f;
					goto IL_109f;
				}
			}
			goto IL_0c5d;
			IL_0d33:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2383 @ rax_v165 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+60]");
			object obj10 = 0;
			goto IL_0d88;
			IL_0c5d:
			throw new NullReferenceException();
			IL_0e2d:
			return false;
			IL_109f:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+20]");
			Component component4;
			if (0f > num6)
			{
				float num8 = _003Celapsed_003E5__3;
				object obj11 = Time.deltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+20]");
				float num9 = 0f + _003Celapsed_003E5__3;
				_003Celapsed_003E5__3 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+A0]");
				if ((nint)0 != 0)
				{
					float num10 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+A0]");
					List<Transform>.Enumerator enumerator = (List<Transform>.Enumerator)0;
					List<Transform>.Enumerator enumerator2 = default(List<Transform>.Enumerator);
					while (enumerator2.MoveNext())
					{
						Transform transform2 = null;
					}
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+A0]");
				if ((nint)0 != 0)
				{
					List<Transform>.Enumerator enumerator3 = default(List<Transform>.Enumerator);
					while (enumerator3.MoveNext())
					{
						Component component3 = null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+78]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+78]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1912 @ rdi_v5+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+78]");
							component4 = (Component)0;
							goto IL_0fcd;
						}
					}
					bool flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
					Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					component4 = transform3;
					goto IL_0fcd;
				}
			}
			goto IL_0c5d;
			IL_0d88:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+60]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdi_v41 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+60]");
					if ((nint)0 == 0)
					{
						goto IL_0c5d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+60]");
					((ParticleSystem)0).Play(withChildren: true);
					nint num11 = unchecked((nint)null);
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+A0]");
			if ((nint)0 == 0)
			{
				goto IL_0c5d;
			}
			float num12 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+A0]");
			List<Transform>.Enumerator enumerator4 = (List<Transform>.Enumerator)0;
			List<Transform>.Enumerator enumerator5 = default(List<Transform>.Enumerator);
			while (enumerator5.MoveNext())
			{
				Transform transform4 = null;
			}
			_003Celapsed_003E5__3 = 0f;
			num6 = _003Celapsed_003E5__3;
			component2 = _003C_003E4__this;
			float num13 = 1000f;
			num7 = 0f;
			goto IL_109f;
			IL_0fcd:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v1 (UnityEngine.Component)+89]");
			if ((nint)0 != 0 && (object)component4 != null && ((UnityEngine.Object)component4).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = component4.gameObject;
				if ((object)gameObject == null)
				{
					goto IL_0c5d;
				}
				bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
			}
			_ = 0;
			goto IL_0e2d;
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

	private float lifetime;

	private AnimationCurve scaleOverLifetime;

	private float radialSpeed;

	private float radialSpeedJitter;

	private float directionJitterDegrees;

	private Vector2 spinSpeedRangeDeg;

	private Vector3 gravity;

	private int seed;

	private Vector3 extraVelocityJitter;

	private ParticleSystem explodeParticles;

	private float mass;

	private float drag;

	private float angularDrag;

	private bool useGravity;

	private Transform fragmentRoot;

	private Transform explosionTransform;

	private bool enableRootOnExplode;

	private bool disableRootOnStop;

	private Dictionary<Transform, OriginalTransformData> originalTransforms;

	private Dictionary<Transform, FakeRigidBodyMover> fragmentMovers;

	private List<Transform> fragments;

	private bool isExploding;

	private void Awake()
	{
		CollectFragments();
		Transform transform = fragmentRoot;
		if ((object)fragmentRoot != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = fragmentRoot.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private unsafe void CollectFragments()
	{
		//IL_00c9: Expected O, but got I
		//IL_00f0: Expected O, but got I
		//IL_0128: Expected O, but got I
		//IL_0582: Expected O, but got Ref
		//IL_059e: Expected O, but got Ref
		//IL_02a4: Expected O, but got I4
		//IL_065a: Expected I, but got O
		//IL_0249: Expected O, but got I
		//IL_030c: Expected I, but got O
		//IL_031c: Expected O, but got I
		//IL_0618: Expected O, but got I4
		//IL_0354: Expected O, but got I
		//IL_02c0: Expected O, but got I4
		//IL_02d6: Expected O, but got I
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_0462: Expected O, but got Ref
		//IL_02b3->IL0385: Incompatible stack heights: 2 vs 4
		//IL_057a->IL070b: Incompatible stack heights: 7 vs 0
		List<Transform> list = fragments;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
			System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
		}
		Dictionary<Transform, OriginalTransformData> dictionary = originalTransforms;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v2 (System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ExplodeFragments+OriginalTransformData>)+20]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v2 (System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ExplodeFragments+OriginalTransformData>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v2 (System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ExplodeFragments+OriginalTransformData>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r8_v33+18]");
			Array.Clear((Array)num, 0, 0);
			_ = 0;
			_ = 4294967295L;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v2 (System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ExplodeFragments+OriginalTransformData>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v2 (System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ExplodeFragments+OriginalTransformData>)+20]");
			Array.Clear((Array)num2, 0, 0);
			System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v2 (System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ExplodeFragments+OriginalTransformData>)+2C]");
		_ = (nint)0 + (nint)1;
		fragmentMovers.Clear();
		Transform transform = fragmentRoot;
		Transform transform2 = (((object)fragmentRoot == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0) ? base.transform : fragmentRoot);
		IEnumerator enumerator = transform2.GetEnumerator();
		object obj2 = default(object);
		object obj3 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		object obj17 = default(object);
		while (true)
		{
			bool flag = obj2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			if (obj3 == null)
			{
				break;
			}
			bool flag2 = obj2 == null;
			object obj4 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ r10_v5+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0289;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ r10_v5+B0]");
			object obj5 = 0;
			int num3 = 0;
			while (true)
			{
				object obj6 = num3 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ r8_v9+v719 @ rax_v118*8]");
				if (0 == (nint)typeof(IEnumerator))
				{
					break;
				}
				num3++;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ r10_v5+12E]");
				if ((nint)num4 < (nint)0)
				{
					continue;
				}
				goto IL_0289;
			}
			object obj7 = num3 + num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ r8_v9+8+v780 @ rcx_v84*8]");
			object obj8 = (nint)0 + (nint)1;
			object obj9 = obj8 << 4;
			object obj10 = obj9 + 312;
			object obj11 = obj10 + obj4;
			goto IL_0642;
			IL_04e5:
			FakeRigidBodyMover fakeRigidBodyMover;
			fakeRigidBodyMover.mass = mass;
			fakeRigidBodyMover.drag = drag;
			fakeRigidBodyMover.angularDrag = angularDrag;
			fakeRigidBodyMover.useGravity = useGravity;
			fakeRigidBodyMover.customGravity = gravity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ExplodeFragments)+4C]");
			_ = 0;
			fakeRigidBodyMover.isKinematic = true;
			object obj12;
			bool flag3 = ((Dictionary<object, object>)(object)fragmentMovers).TryInsert(obj12, (object)fakeRigidBodyMover, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			continue;
			IL_0289:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj11 = obj13;
			obj5 = 1;
			goto IL_0642;
			IL_0642:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v787 @ rdx_v15] (should have been resolved before IL gen)");
			nint num5 = (nint)typeof(Transform);
			if (obj14 == null)
			{
				obj12 = null;
			}
			else
			{
				nint num6 = (nint)obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rdx_v17 (Il2CppClass<UnityEngine.Transform>)+130]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ r8_v29 (Il2CppClass<System.Object>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rdx_v17 (Il2CppClass<UnityEngine.Transform>)+130]");
				bool flag4 = num7 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ r8_v29 (Il2CppClass<System.Object>)+C8]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v113+FFFFFFF8+v821 @ rax_v112*8]");
				bool flag5 = 0 != (nint)typeof(Transform);
				obj12 = obj14;
			}
			List<object> list2 = (List<object>)(object)fragments;
			int version2 = list2._version + 1;
			list2._version = version2;
			object[] items = list2._items;
			if (list2._size >= items.Length)
			{
				list2.AddWithResize(obj12);
			}
			else
			{
				int size = list2._size + 1;
				list2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rbx_v11 (System.Object)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rbx_v11 (System.Object)+10]");
			Transform.get_localScale_Injected((IntPtr)0, out Vector3 _);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rbx_v11 (System.Object)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rbx_v11 (System.Object)+10]");
			Transform.get_localPosition_Injected((IntPtr)0, out Vector3 _);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rbx_v11 (System.Object)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rbx_v11 (System.Object)+10]");
			Transform.get_localRotation_Injected((IntPtr)0, out Quaternion _);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
			bool flag9 = ((Dictionary<object, OriginalTransformData>)(object)originalTransforms).TryInsert(obj12, (OriginalTransformData)(&obj17), System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			FakeRigidBodyMover component = ((Component)obj12).GetComponent<FakeRigidBodyMover>();
			if ((object)component != null)
			{
				bool flag10 = ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0;
				fakeRigidBodyMover = component;
				if (flag10)
				{
					goto IL_04e5;
				}
			}
			GameObject gameObject = ((Component)obj12).gameObject;
			FakeRigidBodyMover fakeRigidBodyMover2 = gameObject.AddComponent<FakeRigidBodyMover>();
			fakeRigidBodyMover = fakeRigidBodyMover2;
			goto IL_04e5;
		}
		object obj18 = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		object obj19 = (object)(&obj2);
		object obj20 = default(object);
		obj19 = obj20;
		if (obj20 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
	}

	private unsafe void SetupFragments()
	{
		//IL_0321: Expected O, but got Ref
		//IL_033d: Expected O, but got Ref
		//IL_0142: Expected O, but got I4
		//IL_042c: Expected I, but got O
		//IL_00ef: Expected O, but got I
		//IL_00f8: Expected O, but got I4
		//IL_01ad: Expected I, but got O
		//IL_01bd: Expected O, but got I
		//IL_0177: Expected O, but got I
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_01f9: Expected O, but got I
		Transform transform = fragmentRoot;
		Transform transform2 = (((object)fragmentRoot == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0) ? base.transform : fragmentRoot);
		IEnumerator enumerator = transform2.GetEnumerator();
		object obj = default(object);
		object obj2 = default(object);
		object obj15 = default(object);
		Transform transform4 = default(Transform);
		object obj18 = default(object);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj4;
			object obj12;
			if (obj2 != null)
			{
				bool flag = obj == null;
				Transform transform3 = null;
				if (!flag)
				{
					object obj3 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r10_v5+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_012f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r10_v5+B0]");
					obj4 = 0;
					object obj5 = 0;
					while (true)
					{
						object obj6 = obj5 + obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v7+v452 @ rax_v57*8]");
						if (0 == (nint)typeof(IEnumerator))
						{
							break;
						}
						obj5++;
						object obj7 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r10_v5+12E]");
						if ((nint)obj7 < 0)
						{
							continue;
						}
						goto IL_012f;
					}
					object obj8 = obj5 + obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v7+8+v511 @ rcx_v40*8]");
					object obj9 = (nint)0 + (nint)1;
					object obj10 = obj9 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj3;
					goto IL_0414;
				}
				throw new NullReferenceException();
			}
			object obj13 = (object)(&obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			object obj14 = (object)(&obj);
			obj14 = obj15;
			if (obj15 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_02ae:
			FakeRigidBodyMover fakeRigidBodyMover;
			fakeRigidBodyMover.mass = mass;
			fakeRigidBodyMover.drag = drag;
			fakeRigidBodyMover.angularDrag = angularDrag;
			fakeRigidBodyMover.useGravity = useGravity;
			fakeRigidBodyMover.customGravity = gravity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ExplodeFragments)+4C]");
			_ = 0;
			fakeRigidBodyMover.isKinematic = true;
			continue;
			IL_0414:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v519 @ rdx_v12] (should have been resolved before IL gen)");
			nint num = (nint)typeof(Transform);
			nint num2 = (nint)transform4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v14 (Il2CppClass<UnityEngine.Transform>)+130]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ r8_v11 (Il2CppClass<UnityEngine.Transform>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v14 (Il2CppClass<UnityEngine.Transform>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ r8_v11 (Il2CppClass<UnityEngine.Transform>)+C8]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v35+FFFFFFF8+v549 @ rax_v34*8]");
				if (0 == (nint)typeof(Transform))
				{
					FakeRigidBodyMover component = transform4.GetComponent<FakeRigidBodyMover>();
					if ((object)component != null)
					{
						bool flag2 = ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0;
						fakeRigidBodyMover = component;
						Transform transform3 = (Transform)(object)typeof(UnityEngine.Object);
						if (flag2)
						{
							goto IL_02ae;
						}
					}
					GameObject gameObject = transform4.gameObject;
					FakeRigidBodyMover fakeRigidBodyMover2 = gameObject.AddComponent<FakeRigidBodyMover>();
					fakeRigidBodyMover = fakeRigidBodyMover2;
					goto IL_02ae;
				}
			}
			throw new InvalidCastException();
			IL_012f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj4 = 1;
			obj12 = obj18;
			goto IL_0414;
		}
		throw new NullReferenceException();
	}

	public void Explode()
	{
		if (!isExploding)
		{
			Transform transform = fragmentRoot;
			isExploding = true;
			Transform transform2;
			if ((object)fragmentRoot != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
			{
				transform2 = fragmentRoot;
			}
			else
			{
				Transform transform3 = base.transform;
				transform2 = transform3;
			}
			if (enableRootOnExplode && (object)transform2 != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = transform2.gameObject;
				gameObject.SetActive(value: true);
			}
			_003CExplodeCoroutine_003Ed__28 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	public void ResetFragments()
	{
		//IL_026e->IL0232: Incompatible stack heights: 1 vs 0
		//IL_0223->IL0232: Incompatible stack heights: 1 vs 0
		//IL_03eb->IL03ae: Incompatible stack heights: 2 vs 1
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			MonoBehaviour.StopAllCoroutines_Injected(((UnityEngine.Object)this).m_CachedPtr);
			isExploding = false;
			if (fragments != null)
			{
				List<Transform>.Enumerator enumerator = (List<Transform>.Enumerator)fragments;
				List<Transform>.Enumerator enumerator2 = default(List<Transform>.Enumerator);
				while (enumerator2.MoveNext())
				{
					object obj = null;
				}
				Transform transform = fragmentRoot;
				Transform transform2;
				if ((object)fragmentRoot != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
				{
					transform2 = fragmentRoot;
				}
				else
				{
					Transform transform3 = base.transform;
					transform2 = transform3;
				}
				if (!disableRootOnStop || (object)transform2 == null || ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				GameObject gameObject = transform2.gameObject;
				if ((object)gameObject != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v62 (UnityEngine.GameObject)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v62 (UnityEngine.GameObject)+10]");
					GameObject.SetActive_Injected((IntPtr)0, false);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator ExplodeCoroutine()
	{
		_003CExplodeCoroutine_003Ed__28 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe static Vector3 RandomOnUnitSphere(System.Random rng)
	{
		//IL_00fc: Expected I, but got O
		//IL_0154: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_0179: Invalid comparison between O and F4
		//IL_0031: Invalid comparison between F4 and O
		//IL_0061: Invalid comparison between I4 and F4
		//IL_01c0: Invalid comparison between O and F4
		//IL_021d: Expected F4, but got O
		//IL_0218: Expected native int or pointer, but got O
		//IL_0225: Expected native int or pointer, but got O
		//IL_01e2: Expected I, but got O
		//IL_020b: Expected F4, but got I
		Vector3 vector = default(Vector3);
		Vector3 vector3 = default(Vector3);
		while (rng != null)
		{
			while (true)
			{
				double num = rng.NextDouble();
				nint num2 = (nint)rng;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm11\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm8,xmm0\"");
				double num3 = rng.NextDouble();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,xmm11\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm9,xmm0\"");
				object obj = 0 * 0;
				object obj2 = 0 * 0;
				object obj3 = obj2 + obj;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
				{
					break;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-06f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					float num4 = 1f - (float)obj3;
					if (!(0f > num4))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
					}
					object obj4 = obj3 + obj3;
					float num5 = 1f - (float)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
					Vector3 vector2;
					float z;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
					{
						float num6 = num5 / (float)vector;
						vector2 = vector;
						z = num6;
					}
					else
					{
						nint num7 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num8 = 0;
						vector2 = Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						z = 0f;
					}
					((Vector3*)(nint)vector3)->x = (float)vector2;
					((Vector3*)(nint)vector3)->z = z;
					return vector3;
				}
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public ExplodeFragments()
	{
		//IL_0031: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		//IL_011d: Expected I, but got O
		lifetime = 2f;
		AnimationCurve animationCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);
		scaleOverLifetime = animationCurve;
		radialSpeed = 6f;
		radialSpeedJitter = 2f;
		directionJitterDegrees = 10f;
		spinSpeedRangeDeg = (Vector2)1119092736;
		_ = 1141309440;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		gravity = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		extraVelocityJitter = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		mass = 1f;
		drag = 1f;
		angularDrag = 1f;
		useGravity = true;
		enableRootOnExplode = true;
		Dictionary<Transform, OriginalTransformData> dictionary = null;
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		originalTransforms = dictionary;
		Dictionary<Transform, FakeRigidBodyMover> dictionary2 = new Dictionary<Transform, FakeRigidBodyMover>();
		fragmentMovers = dictionary2;
		List<Transform> list = new List<Transform>();
		fragments = list;
	}
}
