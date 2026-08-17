using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DRepeater : BasePC2D, IPostMover
{
	public static string ExtensionName = "Repeater";

	public Transform ObjectToRepeat;

	public Vector2 ObjectSize;

	public Vector2 ObjectBottomLeft;

	public bool ObjectOnStage;

	public bool _repeatHorizontal;

	public bool _repeatVertical;

	public Camera CameraToUse;

	private Transform _cameraToUseTransform;

	private Vector3 _objStartPosition;

	private List<RepeatedObject> _allRepeatedObjects;

	private Queue<RepeatedObject> _inactiveRepeatedObjects;

	private IntPoint _prevStartIndex;

	private IntPoint _prevEndIndex;

	private Dictionary<IntPoint, bool> _occupiedIndices;

	private int _pmOrder;

	public bool RepeatHorizontal
	{
		get
		{
			return _repeatHorizontal;
		}
		set
		{
			_repeatHorizontal = value;
			Refresh();
		}
	}

	public bool RepeatVertical
	{
		get
		{
			return _repeatVertical;
		}
		set
		{
			_repeatVertical = value;
			Refresh();
		}
	}

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
		base.Awake();
		SetRepeatingObject(ObjectToRepeat, ObjectOnStage);
		Transform cameraToUseTransform = CameraToUse.transform;
		_cameraToUseTransform = cameraToUseTransform;
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPostMover(this);
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
		//IL_034c: Expected O, but got I4
		//IL_00d4: Expected I, but got O
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0051->IL0331: Incompatible stack heights: 1 vs 0
		//IL_00a8->IL0331: Incompatible stack heights: 1 vs 0
		//IL_00ee->IL0331: Incompatible stack heights: 1 vs 0
		//IL_03c3->IL0331: Incompatible stack heights: 2 vs 0
		//IL_012b->IL0331: Incompatible stack heights: 2 vs 0
		//IL_0331->IL03e2: Incompatible stack heights: 2 vs 1
		IntPoint intPoint;
		IntPoint intPoint2 = default(IntPoint);
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			Func<Vector3, float> vector3D = Vector3D;
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				Vector3 localPosition = proCamera2D.LocalPosition;
				float num2 = default(float);
				float num = num2 - num2;
				float num3 = localPosition.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRepeater)+98]");
				float num4 = num3 - 0f;
				if (Vector3D != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v139 @ rbx_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Vector2 screenSizeInWorldCoords = Utils.GetScreenSizeInWorldCoords(CameraToUse, num2);
					nint num5 = (nint)_cameraToUseTransform;
					if ((object)_cameraToUseTransform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.IntPtr)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.IntPtr)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						Func<Vector3, float> vector3H = Vector3H;
						if (Vector3H != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v155 @ rcx_v24 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							Func<Vector3, float> vector3V = Vector3V;
							if (Vector3V != null)
							{
								float num6 = (float)screenSizeInWorldCoords * 0.5f;
								float num7 = num2 - num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v154 @ rcx_v26 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								float num8 = num7 - (float)_objStartPosition;
								object obj2 = default(object);
								float num9 = (float)obj2 * 0.5f;
								float num10 = num8 - (float)ObjectBottomLeft;
								float num11 = num2 - num9;
								float num12 = num10 / (float)ObjectSize;
								float num13 = num11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRepeater)+94]");
								float num14 = num13 - 0f;
								float num15 = num14;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRepeater)+74]");
								float num16 = num15 - 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
								float num17 = num16;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRepeater)+6C]");
								float num18 = num17 / 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
								object obj3 = (object)screenSizeInWorldCoords / (object)ObjectSize;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRepeater)+6C]");
								object obj4 = obj2 / 0;
								object obj5 = default(object);
								intPoint = (IntPoint)((object)intPoint2 + obj5);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
								object obj7 = default(object);
								object obj8 = default(object);
								object obj6 = obj7 + obj8;
								if ((object)_prevStartIndex == (object)intPoint2)
								{
									object obj9 = (object)_prevStartIndex >> 32;
									if (obj9 == obj8 && (object)_prevEndIndex == (object)intPoint && obj6 == obj6)
									{
										goto IL_0318;
									}
								}
								FreeOutOfRangeObjects(intPoint2, intPoint);
								FillGrid(intPoint2, intPoint);
								goto IL_0318;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0318:
		_prevStartIndex = intPoint2;
		_prevEndIndex = intPoint;
	}

	public unsafe void SetRepeatingObject(Transform objectToRepeat, bool isExistingObject)
	{
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected I, but got Unknown
		//IL_01a2: Expected O, but got F4
		//IL_03e3: Expected O, but got I4
		//IL_03ee: Expected O, but got I4
		//IL_02cc: Expected O, but got I
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_0352->IL05e3: Incompatible stack heights: 17 vs 9
		ObjectToRepeat = objectToRepeat;
		Transform objectToRepeat2 = ObjectToRepeat;
		if ((object)ObjectToRepeat != null && ((UnityEngine.Object)objectToRepeat2).m_CachedPtr != (IntPtr)0)
		{
			Transform objectToRepeat3 = ObjectToRepeat;
			Func<Vector3, float> vector3H = Vector3H;
			bool flag = (object)ObjectToRepeat == null;
			_ = 0;
			_ = 0;
			bool flag2 = ((UnityEngine.Object)objectToRepeat3).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 64;
			Transform.get_position_Injected(((UnityEngine.Object)objectToRepeat3).m_CachedPtr, out *(Vector3*)obj);
			bool flag3 = Vector3H == null;
			object obj3 = obj2 - 48;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v273 @ rsi_v1 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			object objectToRepeat4 = ObjectToRepeat;
			Func<Vector3, float> vector3V = Vector3V;
			bool flag4 = (object)ObjectToRepeat == null;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v15 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			object obj4 = obj2 - 64;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v15 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
			bool flag6 = Vector3V == null;
			object obj5 = obj2 - 48;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v338 @ rsi_v12 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Transform objectToRepeat5 = ObjectToRepeat;
			Func<Vector3, float> vector3D = Vector3D;
			bool flag7 = (object)ObjectToRepeat == null;
			_ = 0;
			_ = 0;
			bool flag8 = ((UnityEngine.Object)objectToRepeat5).m_CachedPtr == (IntPtr)0;
			object obj6 = obj2 - 64;
			Transform.get_position_Injected(((UnityEngine.Object)objectToRepeat5).m_CachedPtr, out *(Vector3*)obj6);
			bool flag9 = Vector3D == null;
			nint num = (nint)(obj2 - 48);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v316 @ r14_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			bool flag10 = _allRepeatedObjects == null;
			float num2 = default(float);
			_objStartPosition = (Vector3)num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
			_ = 0;
			if (!flag10)
			{
				List<RepeatedObject> allRepeatedObjects = _allRepeatedObjects;
				if (allRepeatedObjects._size > 0)
				{
					Transform transform = null;
					Transform transform2 = null;
					while ((nint)transform < allRepeatedObjects._size)
					{
						List<RepeatedObject> allRepeatedObjects2 = _allRepeatedObjects;
						bool flag11 = _allRepeatedObjects == null;
						bool flag12 = (nint)transform2 >= allRepeatedObjects2._size;
						RepeatedObject[] items = allRepeatedObjects2._items;
						bool flag13 = allRepeatedObjects2._items == null;
						bool flag14 = (nint)transform2 >= items.Length;
						Func<Vector3, float> func = (Func<Vector3, float>)(object)items[(object)transform2];
						bool flag15 = items[(object)transform2] == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rsi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
						Func<Vector3, float> func2 = (Func<Vector3, float>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rsi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
						bool flag16 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rsi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
						bool flag17 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rsi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject obj7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						UnityEngine.Object.Destroy(obj7, 0f);
						allRepeatedObjects = _allRepeatedObjects;
						transform2 = (Transform)(transform2 + 1);
						bool flag18 = _allRepeatedObjects == null;
						num = 0;
						transform = transform2;
					}
				}
			}
			List<RepeatedObject> allRepeatedObjects3 = new List<RepeatedObject>();
			_allRepeatedObjects = allRepeatedObjects3;
			Queue<RepeatedObject> inactiveRepeatedObjects = new Queue<RepeatedObject>();
			_inactiveRepeatedObjects = inactiveRepeatedObjects;
			Dictionary<IntPoint, bool> occupiedIndices = null;
			EqualityComparer<IntPoint> equalityComparer = EqualityComparer<IntPoint>.Default;
			if (equalityComparer != null)
			{
				_ = 0;
			}
			_occupiedIndices = occupiedIndices;
			_prevStartIndex = (IntPoint)0;
			_prevEndIndex = (IntPoint)0;
			bool flag19 = default(bool);
			if (flag19)
			{
				InitCopy(ObjectToRepeat);
			}
		}
		else
		{
			Debug.LogWarning("ProCamera2D Repeater extension - No ObjectToRepeat defined!");
		}
	}

	private void FreeOutOfRangeObjects(IntPoint startIndex, IntPoint endIndex)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_016b: Expected O, but got I
		List<RepeatedObject> allRepeatedObjects = _allRepeatedObjects;
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		object obj5 = default(object);
		while (true)
		{
			if ((nint)obj2 >= allRepeatedObjects._size)
			{
				return;
			}
			List<RepeatedObject> allRepeatedObjects2 = _allRepeatedObjects;
			if ((nint)obj >= allRepeatedObjects2._size)
			{
				break;
			}
			RepeatedObject[] items = allRepeatedObjects2._items;
			object obj3 = items[obj];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v7 (System.Object)+10]");
			if ((nint)0 == 2147483647)
			{
				goto IL_00e4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v7 (System.Object)+10]");
			if (0 >= (nint)startIndex)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v7 (System.Object)+10]");
				if (0 <= (nint)endIndex)
				{
					goto IL_00e4;
				}
			}
			goto IL_0154;
			IL_0188:
			allRepeatedObjects = _allRepeatedObjects;
			obj++;
			obj2 = obj;
			continue;
			IL_00e4:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v7 (System.Object)+14]");
			if ((nint)0 == 2147483647)
			{
				goto IL_0188;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v7 (System.Object)+14]");
			if (0 >= (nint)obj4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v7 (System.Object)+14]");
				if (0 <= (nint)obj5)
				{
					goto IL_0188;
				}
			}
			goto IL_0154;
			IL_0154:
			Dictionary<IntPoint, bool> occupiedIndices = _occupiedIndices;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rsi_v7 (System.Object)+10]");
			bool flag = occupiedIndices.Remove((IntPoint)0);
			((Queue<object>)(object)_inactiveRepeatedObjects).Enqueue(obj3);
			PositionObject((RepeatedObject)obj3, IntPoint.MaxValue);
			goto IL_0188;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void FillGrid(IntPoint startIndex, IntPoint endIndex)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_0151: Expected O, but got I
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		IntPoint intPoint;
		IntPoint intPoint2;
		if (!_repeatHorizontal)
		{
			intPoint = (IntPoint)0;
			intPoint2 = (IntPoint)0;
		}
		else
		{
			IntPoint intPoint3 = default(IntPoint);
			intPoint = intPoint3;
			IntPoint intPoint4 = default(IntPoint);
			intPoint2 = intPoint4;
		}
		IntPoint intPoint5;
		IntPoint intPoint6;
		if (!_repeatVertical)
		{
			intPoint5 = (IntPoint)0;
			intPoint6 = (IntPoint)0;
		}
		else
		{
			IntPoint intPoint7 = default(IntPoint);
			intPoint5 = intPoint7;
			IntPoint intPoint8 = default(IntPoint);
			intPoint6 = intPoint8;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint2) > System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint))
		{
			return;
		}
		do
		{
			if (System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint5) <= System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint6))
			{
				IntPoint intPoint9;
				do
				{
					int num = _occupiedIndices.FindEntry(intPoint2);
					if (num < 0)
					{
						Queue<RepeatedObject> inactiveRepeatedObjects = _inactiveRepeatedObjects;
						if (inactiveRepeatedObjects._size == 0)
						{
							Transform newCopy = UnityEngine.Object.Instantiate(ObjectToRepeat);
							InitCopy(newCopy, positionOffscreen: false);
						}
						bool flag = _occupiedIndices.TryInsert(intPoint2, true, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
						object obj = ((Queue<object>)(object)_inactiveRepeatedObjects).Dequeue();
						PositionObject((RepeatedObject)obj, intPoint2);
					}
					else
					{
						IntPoint intPoint3 = (IntPoint)0;
					}
					intPoint9 = (IntPoint)(intPoint5 + 1);
				}
				while (System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint9) <= System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint6));
			}
			intPoint2 = (IntPoint)(intPoint2 + 1);
		}
		while (System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint2) <= System.Runtime.CompilerServices.Unsafe.As<IntPoint, UIntPtr>(ref intPoint));
	}

	private void InitCopy(Transform newCopy, bool positionOffscreen = true)
	{
		RepeatedObject repeatedObject = new RepeatedObject();
		repeatedObject.Transform = newCopy;
		Transform parent = ObjectToRepeat.parent;
		repeatedObject.Transform.SetParent(parent, worldPositionStays: true);
		List<object> allRepeatedObjects = (List<object>)(object)_allRepeatedObjects;
		int version = allRepeatedObjects._version + 1;
		allRepeatedObjects._version = version;
		object[] items = allRepeatedObjects._items;
		if (allRepeatedObjects._size >= items.Length)
		{
			allRepeatedObjects.AddWithResize((object)repeatedObject);
		}
		else
		{
			int size = allRepeatedObjects._size + 1;
			allRepeatedObjects._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		((Queue<object>)(object)_inactiveRepeatedObjects).Enqueue((object)repeatedObject);
		if (positionOffscreen)
		{
			PositionObject(repeatedObject, IntPoint.MaxValue);
		}
	}

	private void PositionObject(RepeatedObject obj, IntPoint index)
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		if (obj != null)
		{
			Transform transform = obj.Transform;
			obj.GridPos = index;
			Func<float, float, float, Vector3> vectorHVD = VectorHVD;
			if (VectorHVD != null)
			{
				object obj2 = (object)index >> 32;
				object obj3 = (object)index * (object)ObjectSize;
				object obj4 = obj3 + (object)_objStartPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRepeater)+6C]");
				object obj5 = obj2 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRepeater)+94]");
				object obj6 = obj5 + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v15 @ rdx_v7 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void Refresh()
	{
		FreeOutOfRangeObjects(IntPoint.MaxValue, IntPoint.MaxValue);
		FillGrid(_prevStartIndex, _prevEndIndex);
	}

	public ProCamera2DRepeater()
	{
		//IL_000b: Expected O, but got I4
		//IL_0026: Expected I, but got O
		//IL_0082: Expected I, but got O
		ObjectSize = (Vector2)1073741824;
		_ = 1073741824;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		ObjectBottomLeft = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		ObjectOnStage = true;
		_repeatVertical = true;
		_pmOrder = 2000;
		nint num3 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
