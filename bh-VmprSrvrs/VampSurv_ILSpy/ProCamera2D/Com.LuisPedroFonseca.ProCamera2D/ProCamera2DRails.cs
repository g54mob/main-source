using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DRails : BasePC2D, IPreMover
{
	public static string ExtensionName = "Rails";

	public List<Vector3> RailNodes;

	public FollowMode FollowMode;

	public List<CameraTarget> CameraTargets;

	private Dictionary<CameraTarget, Transform> _cameraTargetsOnRails;

	private List<CameraTarget> _tempCameraTargets;

	private KDTree _kdTree;

	private int _prmOrder;

	public int PrMOrder
	{
		get
		{
			return _prmOrder;
		}
		set
		{
			_prmOrder = value;
		}
	}

	protected override void Awake()
	{
		//IL_0049: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_0068: Expected I4, but got O
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0323: Expected F4, but got O
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_044a: Expected I4, but got O
		//IL_017c->IL04f3: Incompatible stack heights: 1 vs 0
		//IL_01b3->IL04f3: Incompatible stack heights: 1 vs 0
		//IL_01d5->IL04f3: Incompatible stack heights: 1 vs 0
		//IL_0236->IL04f3: Incompatible stack heights: 1 vs 0
		//IL_0591->IL04f3: Incompatible stack heights: 2 vs 0
		//IL_028f->IL04f3: Incompatible stack heights: 3 vs 0
		//IL_02ae->IL04f3: Incompatible stack heights: 3 vs 0
		//IL_02ff->IL04f3: Incompatible stack heights: 3 vs 0
		//IL_034b->IL04f3: Incompatible stack heights: 3 vs 0
		//IL_039a->IL04f3: Incompatible stack heights: 4 vs 0
		//IL_03d1->IL04f3: Incompatible stack heights: 4 vs 0
		//IL_03ee->IL04f3: Incompatible stack heights: 4 vs 0
		//IL_043c->IL04f3: Incompatible stack heights: 4 vs 0
		//IL_045f->IL0596: Incompatible stack heights: 4 vs 0
		base.Awake();
		if (RailNodes != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049EA70");
			Vector3[] array = default(Vector3[]);
			if (array != null)
			{
				int[] array2 = new int[array.Length];
				if (array.Length > 0)
				{
					bool flag = array2 == null;
					object obj = 0;
					if (flag)
					{
						goto IL_04f3;
					}
					do
					{
						array2[obj] = (int)obj;
						obj++;
					}
					while ((nint)obj < array.Length);
				}
				int enIndex = array.Length - 1;
				int[] array3 = default(int[]);
				KDTree kdTree = KDTree.MakeFromPointsInner(0, 0, enIndex, array, array3);
				_kdTree = kdTree;
				List<CameraTarget> cameraTargets = CameraTargets;
				if (CameraTargets != null)
				{
					object obj2 = 0;
					object obj3 = 0;
					Vector2 targetOffset = default(Vector2);
					ProCamera2DRails proCamera2DRails = default(ProCamera2DRails);
					while (true)
					{
						List<CameraTarget> cameraTargets2 = CameraTargets;
						if ((nint)obj2 < cameraTargets._size)
						{
							if (CameraTargets == null)
							{
								break;
							}
							bool flag2 = (nint)obj3 >= cameraTargets2._size;
							CameraTarget[] items = cameraTargets2._items;
							if (cameraTargets2._items == null)
							{
								break;
							}
							CameraTarget cameraTarget = items[obj3];
							if (items[obj3] == null || (object)cameraTarget.TargetTransform == null)
							{
								break;
							}
							string text = ((UnityEngine.Object)cameraTarget.TargetTransform).GetName();
							string text2 = text + "_OnRails";
							GameObject gameObject = new GameObject();
							GameObject.Internal_CreateGameObject(gameObject, text2);
							if ((object)gameObject == null)
							{
								break;
							}
							bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							List<CameraTarget> cameraTargets3 = CameraTargets;
							if (CameraTargets == null)
							{
								break;
							}
							bool flag4 = (nint)obj3 >= cameraTargets3._size;
							CameraTarget[] items2 = cameraTargets3._items;
							if (cameraTargets3._items == null || _cameraTargetsOnRails == null)
							{
								break;
							}
							bool flag5 = ((Dictionary<object, object>)(object)_cameraTargetsOnRails).TryInsert((object)items2[obj3], (object)transform, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							ProCamera2D proCamera2D = base.ProCamera2D;
							if ((object)proCamera2D == null)
							{
								break;
							}
							CameraTarget cameraTarget2 = proCamera2D.AddCameraTarget(transform, 1f, 1f, (float)array3, targetOffset);
							List<CameraTarget> cameraTargets4 = CameraTargets;
							if (CameraTargets == null)
							{
								break;
							}
							bool flag6 = (nint)obj3 >= cameraTargets4._size;
							CameraTarget[] items3 = cameraTargets4._items;
							if (cameraTargets4._items == null)
							{
								break;
							}
							CameraTarget cameraTarget3 = items3[obj3];
							if (items3[obj3] == null || cameraTarget2 == null)
							{
								break;
							}
							obj3++;
							_ = cameraTarget3.TargetOffset;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v33 (Com.LuisPedroFonseca.ProCamera2D.CameraTarget)+24]");
							_ = 0;
							cameraTargets = CameraTargets;
							if (CameraTargets == null)
							{
								break;
							}
							enIndex = (int)cameraTarget2;
							obj2 = obj3;
							array3 = array3;
							continue;
						}
						if (CameraTargets == null)
						{
							break;
						}
						ProCamera2DRails obj4;
						if (cameraTargets2._size == 0)
						{
							bool flag7 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
							obj4 = this;
							if (flag7)
							{
								goto IL_0624;
							}
							Behaviour.set_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr, false);
						}
						ProCamera2D proCamera2D2 = base.ProCamera2D;
						if ((object)proCamera2D2 == null)
						{
							break;
						}
						proCamera2D2.AddPreMover(this);
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 717 Invalid \"Jump target not found in method: 0x1851BE7A0\"");
						obj4 = proCamera2DRails;
						goto IL_0624;
						IL_0624:
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(obj4);
						break;
					}
				}
			}
		}
		goto IL_04f3;
		IL_04f3:
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._preMovers).Remove((object)this);
		}
	}

	public void PreMove(float deltaTime)
	{
		//IL_0040: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			Step();
		}
	}

	private unsafe void Step()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0861: Expected I, but got O
		//IL_0894: Expected O, but got I
		//IL_0016: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_06ef: Expected O, but got Ref
		//IL_07e6: Expected O, but got Ref
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		//IL_073b: Expected O, but got I4
		//IL_018d: Expected O, but got I
		//IL_05ad: Expected O, but got Ref
		//IL_05bd: Expected O, but got I
		//IL_03b9: Expected O, but got I
		//IL_043a: Expected O, but got Ref
		//IL_0785: Expected O, but got I
		//IL_07a7: Expected O, but got I
		//IL_0226: Expected O, but got Ref
		//IL_066a: Expected O, but got Ref
		//IL_082a->IL0749: Incompatible stack heights: 1 vs 0
		//IL_0748->IL082f: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		List<CameraTarget> cameraTargets = CameraTargets;
		Vector3 zeroVector = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = 0;
		if (CameraTargets != null)
		{
			object obj4 = 0;
			object obj5 = 0;
			CameraTarget cameraTarget = default(CameraTarget);
			object obj8 = default(object);
			CameraTarget cameraTarget2 = default(CameraTarget);
			object obj10 = default(object);
			CameraTarget cameraTarget3 = default(CameraTarget);
			object obj11 = default(object);
			CameraTarget cameraTarget4 = default(CameraTarget);
			object obj13 = default(object);
			CameraTarget key = default(CameraTarget);
			object obj15 = default(object);
			while (true)
			{
				if ((nint)obj5 >= cameraTargets._size)
				{
					return;
				}
				bool flag = FollowMode == FollowMode.BothAxis;
				float num6;
				float x2;
				float x;
				object obj7;
				if (!flag)
				{
					object obj6 = FollowMode - 1;
					Transform vectorHVD;
					float num5;
					float x4;
					object obj9;
					if (!flag)
					{
						if ((nint)obj6 != 1)
						{
							goto IL_0755;
						}
						vectorHVD = (Transform)(object)VectorHVD;
						Func<Vector3, float> vector3H = Vector3H;
						ProCamera2D proCamera2D = base.ProCamera2D;
						if ((object)proCamera2D == null)
						{
							break;
						}
						Vector3 localPosition = proCamera2D.LocalPosition;
						if (Vector3H == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v214 @ rsi_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						Func<Vector3, float> vector3V = Vector3V;
						if (CameraTargets == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if (cameraTarget == null)
						{
							break;
						}
						Vector3 targetPosition = cameraTarget.TargetPosition;
						if (Vector3V == null)
						{
							break;
						}
						x = targetPosition.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rsi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
						obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v215 @ rsi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
						if (CameraTargets == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if (obj8 == null || VectorHVD == null)
						{
							break;
						}
						float num3 = targetPosition.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v58+1C]");
						float num4 = num3 * 0f;
						obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
						num5 = num4;
						x2 = localPosition.x;
						float x3 = targetPosition.x;
						x4 = localPosition.x;
						float x5 = localPosition.x;
						goto IL_0774;
					}
					vectorHVD = (Transform)(object)VectorHVD;
					Func<Vector3, float> vector3H2 = Vector3H;
					if (CameraTargets == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (cameraTarget2 == null)
					{
						break;
					}
					Vector3 targetPosition2 = cameraTarget2.TargetPosition;
					if (Vector3H == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v216 @ rsi_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					if (CameraTargets == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (obj10 == null)
					{
						break;
					}
					Func<Vector3, float> vector3V2 = Vector3V;
					ProCamera2D proCamera2D2 = base.ProCamera2D;
					if ((object)proCamera2D2 == null)
					{
						break;
					}
					Vector3 localPosition2 = proCamera2D2.LocalPosition;
					if (Vector3V == null)
					{
						break;
					}
					x = localPosition2.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rsi_v15 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
					obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v217 @ rsi_v15 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					if (VectorHVD == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rax_v45+18]");
					num6 = 0f * targetPosition2.x;
					float x6 = localPosition2.x;
					float x7 = targetPosition2.x;
					num5 = localPosition2.x;
					x4 = targetPosition2.x;
					obj9 = (object)(&obj2);
				}
				else
				{
					Transform vectorHVD = (Transform)(object)VectorHVD;
					Func<Vector3, float> vector3H3 = Vector3H;
					if (CameraTargets == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (cameraTarget3 == null)
					{
						break;
					}
					Vector3 targetPosition3 = cameraTarget3.TargetPosition;
					if (Vector3H == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v218 @ rsi_v12 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					if (CameraTargets == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (obj11 == null)
					{
						break;
					}
					Func<Vector3, float> vector3V3 = Vector3V;
					if (CameraTargets == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (cameraTarget4 == null)
					{
						break;
					}
					Vector3 targetPosition4 = cameraTarget4.TargetPosition;
					if (Vector3V == null)
					{
						break;
					}
					x = targetPosition4.x;
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rsi_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
					obj7 = 0;
					_ = targetPosition4.x;
					_ = targetPosition4.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ rsi_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					if (CameraTargets == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (obj13 == null || VectorHVD == null)
					{
						break;
					}
					float num7 = targetPosition4.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v40+1C]");
					float x4 = num7 * 0f;
					object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v35+18]");
					num6 = 0f * targetPosition3.x;
					float x8 = targetPosition3.x;
					float num5 = x4;
				}
				x2 = num6;
				goto IL_0774;
				IL_0755:
				if (CameraTargets == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if (_cameraTargetsOnRails == null)
				{
					break;
				}
				Transform transform = _cameraTargetsOnRails.get_Item(key);
				Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				Vector3 positionOnRail = GetPositionOnRail(pos);
				x = positionOnRail.x;
				_ = positionOnRail.x;
				_ = positionOnRail.z;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj14);
				cameraTargets = CameraTargets;
				obj4++;
				if (CameraTargets == null)
				{
					break;
				}
				obj7 = 0;
				obj5 = obj4;
				continue;
				IL_0774:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ r14_v8 (UnityEngine.Transform)+18]");
				pos = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v842 @ r14_v8 (UnityEngine.Transform)+18] (should have been resolved before IL gen)");
				zeroVector = (Vector3)obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v18+8]");
				obj3 = 0;
				goto IL_0755;
			}
		}
		throw new NullReferenceException();
	}

	public void AddRailsTarget(Transform targetTransform, float targetInfluenceH = 1f, float targetInfluenceV = 1f, Vector2 targetOffset = default(Vector2), float duration = 0f)
	{
		CameraTarget railsTarget = GetRailsTarget(targetTransform);
		if (railsTarget == null)
		{
			CameraTarget cameraTarget = new CameraTarget();
			cameraTarget.TargetInfluenceH = 1f;
			cameraTarget.TargetInfluenceV = 1f;
			cameraTarget.TargetTransform = targetTransform;
			Vector2 targetOffset2 = default(Vector2);
			cameraTarget.TargetOffset = targetOffset2;
			cameraTarget.TargetInfluenceH = targetInfluenceH;
			cameraTarget.TargetInfluenceV = targetInfluenceV;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B76D0");
			string text = ((UnityEngine.Object)targetTransform).GetName();
			string text2 = text + "_OnRails";
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, text2);
			Transform transform = gameObject.transform;
			bool flag = ((Dictionary<object, object>)(object)_cameraTargetsOnRails).TryInsert((object)cameraTarget, (object)transform, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			ProCamera2D proCamera2D = base.ProCamera2D;
			float duration2 = default(float);
			Vector2 targetOffset3 = default(Vector2);
			CameraTarget cameraTarget2 = proCamera2D.AddCameraTarget(transform, targetInfluenceH, targetInfluenceV, duration2, targetOffset3);
			base.enabled = true;
		}
	}

	public void RemoveRailsTarget(Transform targetTransform)
	{
		CameraTarget railsTarget = GetRailsTarget(targetTransform);
		if (railsTarget != null)
		{
			bool flag = ((List<object>)(object)CameraTargets).Remove((object)railsTarget);
			ProCamera2D proCamera2D = base.ProCamera2D;
			Transform targetTransform2 = _cameraTargetsOnRails.get_Item(railsTarget);
			proCamera2D.RemoveCameraTarget(targetTransform2);
			Transform transform = _cameraTargetsOnRails.get_Item(railsTarget);
			GameObject obj = transform.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		}
	}

	public CameraTarget GetRailsTarget(Transform targetTransform)
	{
		//IL_00fb: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		List<CameraTarget> cameraTargets = CameraTargets;
		object obj = 0;
		object obj2 = 0;
		CameraTarget result = default(CameraTarget);
		while (true)
		{
			if ((nint)obj2 < cameraTargets._size)
			{
				List<CameraTarget> cameraTargets2 = CameraTargets;
				if ((nint)obj >= cameraTargets2._size)
				{
					break;
				}
				CameraTarget[] items = cameraTargets2._items;
				CameraTarget cameraTarget = items[obj];
				int instanceID = cameraTarget.TargetTransform.GetInstanceID();
				int instanceID2 = targetTransform.GetInstanceID();
				cameraTargets = CameraTargets;
				if (instanceID != instanceID2)
				{
					obj++;
					obj2 = obj;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				return result;
			}
			return null;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		CameraTarget result2 = default(CameraTarget);
		return result2;
	}

	public void DisableTargets(float transitionDuration = 0f)
	{
		//IL_003d: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		List<CameraTarget> tempCameraTargets = _tempCameraTargets;
		if (tempCameraTargets._size != 0)
		{
			return;
		}
		Dictionary<CameraTarget, Transform> cameraTargetsOnRails = _cameraTargetsOnRails;
		object obj = 0;
		object obj2 = 0;
		float duration = default(float);
		Vector2 targetOffset = default(Vector2);
		while (true)
		{
			object obj3 = cameraTargetsOnRails._count - cameraTargetsOnRails._freeCount;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				ProCamera2D proCamera2D = base.ProCamera2D;
				List<CameraTarget> cameraTargets = CameraTargets;
				if ((nint)obj2 >= cameraTargets._size)
				{
					break;
				}
				CameraTarget[] items = cameraTargets._items;
				Transform targetTransform = _cameraTargetsOnRails.get_Item(items[obj2]);
				proCamera2D.RemoveCameraTarget(targetTransform, transitionDuration);
				List<object> tempCameraTargets2 = (List<object>)(object)_tempCameraTargets;
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				List<CameraTarget> cameraTargets2 = CameraTargets;
				if ((nint)obj2 >= cameraTargets2._size)
				{
					break;
				}
				CameraTarget[] items2 = cameraTargets2._items;
				CameraTarget cameraTarget = items2[obj2];
				List<CameraTarget> cameraTargets3 = CameraTargets;
				CameraTarget[] items3 = cameraTargets3._items;
				CameraTarget cameraTarget2 = items3[obj2];
				List<CameraTarget> cameraTargets4 = CameraTargets;
				CameraTarget[] items4 = cameraTargets4._items;
				CameraTarget cameraTarget3 = items4[obj2];
				List<CameraTarget> cameraTargets5 = CameraTargets;
				CameraTarget[] items5 = cameraTargets5._items;
				CameraTarget cameraTarget4 = items5[obj2];
				CameraTarget item = proCamera2D2.AddCameraTarget(cameraTarget.TargetTransform, cameraTarget2.TargetInfluenceH, cameraTarget3.TargetInfluenceV, duration, targetOffset);
				int version = tempCameraTargets2._version + 1;
				tempCameraTargets2._version = version;
				object[] items6 = tempCameraTargets2._items;
				if (tempCameraTargets2._size >= items6.Length)
				{
					tempCameraTargets2.AddWithResize((object)item);
				}
				else
				{
					int size = tempCameraTargets2._size + 1;
					tempCameraTargets2._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				cameraTargetsOnRails = _cameraTargetsOnRails;
				obj2++;
				obj = obj2;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void EnableTargets(float transitionDuration = 0f)
	{
		List<CameraTarget> tempCameraTargets = _tempCameraTargets;
		int num = 0;
		int num2 = 0;
		float duration = default(float);
		Vector2 targetOffset = default(Vector2);
		while (true)
		{
			if (num2 < tempCameraTargets._size)
			{
				ProCamera2D proCamera2D = base.ProCamera2D;
				List<CameraTarget> tempCameraTargets2 = _tempCameraTargets;
				if (num >= tempCameraTargets2._size)
				{
					break;
				}
				CameraTarget[] items = tempCameraTargets2._items;
				CameraTarget cameraTarget = items[num];
				proCamera2D.RemoveCameraTarget(cameraTarget.TargetTransform, transitionDuration);
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				List<CameraTarget> cameraTargets = CameraTargets;
				if (num >= cameraTargets._size)
				{
					break;
				}
				CameraTarget[] items2 = cameraTargets._items;
				Transform targetTransform = _cameraTargetsOnRails.get_Item(items2[num]);
				CameraTarget cameraTarget2 = proCamera2D2.AddCameraTarget(targetTransform, 1f, 1f, duration, targetOffset);
				tempCameraTargets = _tempCameraTargets;
				num++;
				num2 = num;
				continue;
			}
			List<CameraTarget> tempCameraTargets3 = _tempCameraTargets;
			int version = tempCameraTargets3._version + 1;
			tempCameraTargets3._version = version;
			tempCameraTargets3._size = 0;
			if (tempCameraTargets3._size > 0)
			{
				Array.Clear(tempCameraTargets3._items, 0, tempCameraTargets3._size);
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe Vector3 GetPositionOnRail(Vector3 pos)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0041: Expected O, but got Ref
		//IL_00b7: Expected O, but got I
		//IL_06c0: Expected O, but got I
		//IL_0547: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_057e: Expected O, but got I
		//IL_071e: Expected O, but got I
		//IL_073b: Expected O, but got I
		//IL_05a3: Expected O, but got I
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_05ce: Expected O, but got I
		//IL_0132: Expected O, but got I
		//IL_078b: Expected O, but got Ref
		//IL_0799: Expected O, but got Ref
		//IL_0157: Expected O, but got I
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_074d: Expected native int or pointer, but got O
		//IL_075f: Expected native int or pointer, but got O
		//IL_0605: Expected O, but got I
		//IL_062a: Expected O, but got I
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Expected O, but got Unknown
		//IL_0666: Expected O, but got I
		//IL_0683: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_01be: Expected O, but got Ref
		//IL_01de: Expected O, but got I
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_0232: Expected O, but got Ref
		//IL_0284: Expected O, but got I
		//IL_02bb: Expected O, but got I
		//IL_02d6: Expected O, but got I
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_0328: Expected O, but got Ref
		//IL_0348: Expected O, but got I
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected O, but got Unknown
		//IL_039c: Expected O, but got Ref
		//IL_0515: Expected native int or pointer, but got O
		//IL_0527: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ref int bestIndex = ref System.Runtime.CompilerServices.Unsafe.As<object, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		ref float bestSqSoFar = ref System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		_ = pos.x;
		Vector3 pt = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = 1315859240;
		_ = 4294967295L;
		_ = pos.z;
		_kdTree.Search(pt, ref bestSqSoFar, ref bestIndex);
		List<Vector3> railNodes = RailNodes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
		Vector3 pos2 = default(Vector3);
		Vector3 positionOnRailSegment2;
		Vector3 vector = default(Vector3);
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj3 = -1;
			List<Vector3> railNodes2 = RailNodes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
			if (0 != (nint)obj3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
				object obj4 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				if ((nint)obj4 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj5 = 0;
					List<Vector3> railNodes3 = RailNodes;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
					object obj6 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
					object obj7 = 0 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					if (num < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						object obj8 = 0;
						Vector3 node = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = pos.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
						object obj9 = (nint)0 * (nint)2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
						object obj10 = 0 + obj9;
						_ = pos.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v14+28+v586 @ rax_v35*4]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v13+1C+v90 @ r8_v11*4]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v14+20+v586 @ rax_v35*4]");
						_ = 0;
						Vector3 node2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v13+14+v90 @ r8_v11*4]");
						_ = 0;
						Vector3 positionOnRailSegment = GetPositionOnRailSegment(node2, node, pos2);
						List<Vector3> railNodes4 = RailNodes;
						_ = positionOnRailSegment.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
						object obj11 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						if ((nint)obj11 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
							object obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
							object obj13 = (nint)0 * (nint)2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
							object obj14 = 0 + obj13;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							if (num2 < 0)
							{
								Vector3 node3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								_ = pos.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
								object obj15 = (nint)0 * (nint)2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
								object obj16 = 0 + obj15;
								_ = pos.x;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v15+28+v697 @ rax_v43*4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v15+34+v92 @ r8_v13*4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v15+20+v697 @ rax_v43*4]");
								_ = 0;
								Vector3 node4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v15+2C+v92 @ r8_v13*4]");
								_ = 0;
								positionOnRailSegment2 = GetPositionOnRailSegment(node4, node3, pos2);
								float num3 = pos.x;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
								float num4 = num3 - 0f;
								float num5 = pos.y;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B]");
								float num6 = num5 - 0f;
								float num7 = pos.z - positionOnRailSegment.z;
								float num8 = num7 * num7;
								float num9 = num6 * num6;
								float num10 = num4 * num4;
								float num11 = num10 + num9;
								float num12 = num11 + num8;
								float num13 = pos.x - positionOnRailSegment2.x;
								float num14 = pos.z - positionOnRailSegment2.z;
								object obj17 = default(object);
								float num15 = pos.y - (float)obj17;
								float num16 = num15 * num15;
								float num17 = num13 * num13;
								float num18 = num14 * num14;
								float num19 = num16 + num17;
								float num20 = num19 + num18;
								if (num20 < num12)
								{
									goto IL_0740;
								}
								((Vector3*)(nint)vector)->x = positionOnRailSegment.x;
								((Vector3*)(nint)vector)->z = positionOnRailSegment.z;
								goto IL_0773;
							}
						}
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj18 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				if ((nint)obj18 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj19 = 0;
					List<Vector3> railNodes5 = RailNodes;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj20 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj21 = 0 + obj20;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v25 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj22 = -2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v25 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					if ((nint)obj22 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v25 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						object obj23 = 0;
						_ = pos.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v25 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj24 = (nint)0 * (nint)2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v25 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj25 = 0 + obj24;
						_ = pos.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v10+8+v596 @ rax_v29*4]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v12+14+v272 @ r9_v9*4]");
						object obj26 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v10+10+v596 @ rax_v29*4]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v12+1C+v272 @ r9_v9*4]");
						object obj27 = 0;
						goto IL_0778;
					}
				}
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				if ((nint)0 > (nint)1)
				{
					_ = pos.x;
					_ = pos.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v9+2C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v9+20]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v9+34]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v9+28]");
					object obj27 = 0;
					goto IL_0778;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Vector3 result = default(Vector3);
		return result;
		IL_0740:
		((Vector3*)(nint)vector)->x = positionOnRailSegment2.x;
		((Vector3*)(nint)vector)->z = positionOnRailSegment2.z;
		goto IL_0773;
		IL_0778:
		Vector3 node5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Vector3 node6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		positionOnRailSegment2 = GetPositionOnRailSegment(node6, node5, pos2);
		goto IL_0740;
		IL_0773:
		return vector;
	}

	private unsafe Vector3 GetPositionOnRailSegment(Vector3 node1, Vector3 node2, Vector3 pos)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_00c1: Expected O, but got F4
		//IL_02be: Invalid comparison between I4 and F4
		//IL_0218: Expected I, but got O
		//IL_0238: Expected F4, but got I
		//IL_0253: Expected native int or pointer, but got O
		//IL_0260: Expected native int or pointer, but got O
		//IL_01b5: Expected native int or pointer, but got O
		//IL_01c2: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ stack_28+8]");
		object obj = 0 - node1.z;
		object obj2 = default(object);
		float num = (float)obj2 - node1.x;
		float num3 = default(float);
		float num2 = num3 - num3;
		float num4 = node2.z - node1.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
		Vector3 vector;
		float num6;
		if (num3 > 1E-05f)
		{
			float num5 = num4 / num3;
			vector = (Vector3)num3;
			num6 = num5;
		}
		else
		{
			nint num7 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			num6 = 0f;
			vector = Vector3.zeroVector;
		}
		float num9 = (float)vector * num;
		object obj3 = default(object);
		float num10 = (float)obj3 * num2;
		float num11 = num9 + num10;
		float num12 = num6 * (float)obj;
		float num13 = num11 + num12;
		Vector3 vector2 = default(Vector3);
		float x;
		float z2;
		if (!(0f > num13))
		{
			float num14 = node2.x - node1.x;
			float num15 = node2.z - node1.z;
			float num16 = node2.y - num3;
			float num17 = num16 * num16;
			float num18 = num14 * num14;
			float num19 = num15 * num15;
			float num20 = num17 + num18;
			float num21 = num13 * num13;
			float num22 = num20 + num19;
			if (!(num21 > num22))
			{
				float num23 = num6 * num13;
				float z = num23 + node1.z;
				((Vector3*)(nint)vector2)->x = num3;
				((Vector3*)(nint)vector2)->z = z;
				goto IL_0246;
			}
			x = node2.x;
			z2 = node2.z;
		}
		else
		{
			x = node1.x;
			z2 = node1.z;
		}
		((Vector3*)(nint)vector2)->x = x;
		((Vector3*)(nint)vector2)->z = z2;
		goto IL_0246;
		IL_0246:
		return vector2;
	}

	public ProCamera2DRails()
	{
		List<Vector3> railNodes = new List<Vector3>();
		RailNodes = railNodes;
		List<CameraTarget> cameraTargets = new List<CameraTarget>();
		CameraTargets = cameraTargets;
		Dictionary<CameraTarget, Transform> cameraTargetsOnRails = new Dictionary<CameraTarget, Transform>();
		_cameraTargetsOnRails = cameraTargetsOnRails;
		List<CameraTarget> tempCameraTargets = new List<CameraTarget>();
		_tempCameraTargets = tempCameraTargets;
		_prmOrder = 1000;
	}
}
