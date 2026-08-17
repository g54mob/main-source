using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DGeometryBoundaries : BasePC2D, IPositionDeltaChanger
{
	public static string ExtensionName = "Geometry Boundaries";

	public LayerMask BoundariesLayerMask;

	public MoveInColliderBoundaries MoveInColliderBoundaries;

	private int _pdcOrder;

	public int PDCOrder
	{
		get
		{
			return _pdcOrder;
		}
		set
		{
			_pdcOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		MoveInColliderBoundaries moveInColliderBoundaries = new MoveInColliderBoundaries(proCamera2D);
		moveInColliderBoundaries._002Ector(proCamera2D);
		MoveInColliderBoundaries = moveInColliderBoundaries;
		MoveInColliderBoundaries moveInColliderBoundaries2 = MoveInColliderBoundaries;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		Transform cameraTransform = proCamera2D2.transform;
		moveInColliderBoundaries2.CameraTransform = cameraTransform;
		MoveInColliderBoundaries moveInColliderBoundaries3 = MoveInColliderBoundaries;
		moveInColliderBoundaries3.CameraCollisionMask = BoundariesLayerMask;
		ProCamera2D proCamera2D3 = base.ProCamera2D;
		proCamera2D3.AddPositionDeltaChanger(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionDeltaChangers).Remove((object)this);
		}
	}

	public unsafe Vector3 AdjustDelta(float deltaTime, Vector3 originalDelta)
	{
		//IL_00cc: Expected O, but got I4
		//IL_00b3: Expected native int or pointer, but got O
		//IL_00f1: Expected native int or pointer, but got O
		//IL_0071: Expected O, but got Ref
		//IL_008f: Expected native int or pointer, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		float z;
		Vector3 vector2 = default(Vector3);
		if (obj != null)
		{
			MoveInColliderBoundaries moveInColliderBoundaries = MoveInColliderBoundaries;
			ProCamera2D proCamera2D = base.ProCamera2D;
			moveInColliderBoundaries.CameraSize = proCamera2D._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v15 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			_ = 0;
			object obj2 = default(object);
			Vector3 vector = MoveInColliderBoundaries.Move((Vector3)(&obj2));
			z = vector.z;
			((Vector3*)(nint)vector2)->x = vector.x;
		}
		else
		{
			z = originalDelta.z;
			((Vector3*)(nint)vector2)->x = originalDelta.x;
		}
		((Vector3*)(nint)vector2)->z = z;
		return vector2;
	}

	public ProCamera2DGeometryBoundaries()
	{
		//IL_0020: Expected I, but got O
		_pdcOrder = 3000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
