using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Dreamteck.Splines;
using UnityEngine;

namespace VampireSurvivors.Tools;

public class CurveConfig : MonoBehaviour
{
	private SplineComputer _spline;

	private float Scale = 1f;

	private bool InvertPositiveNegative;

	private bool Mirror;

	private List<CurvePoint> Points;

	public void Generate()
	{
		//IL_00c8: Expected O, but got I4
		//IL_00d1: Expected O, but got I4
		//IL_0226: Expected O, but got I
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected O, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		SplineComputer spline = _spline;
		if ((object)_spline != null && ((UnityEngine.Object)spline).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.DestroyImmediate(_spline, allowDestroyingAssets: false);
		}
		GameObject gameObject = base.gameObject;
		SplineComputer spline2 = gameObject.AddComponent<SplineComputer>();
		_spline = spline2;
		List<CurvePoint> points = Points;
		SplinePoint[] points2 = new SplinePoint[points._size];
		List<CurvePoint> list = new List<CurvePoint>();
		List<CurvePoint> points3 = Points;
		object obj = 0;
		object obj2 = 0;
		float num3 = default(float);
		while (true)
		{
			if ((nint)obj < points3._size)
			{
				CurvePoint curvePoint = new CurvePoint();
				List<CurvePoint> points4 = Points;
				if ((nint)obj2 >= points4._size)
				{
					break;
				}
				CurvePoint[] items = points4._items;
				CurvePoint curvePoint2 = items[obj2];
				curvePoint.X = curvePoint2.X;
				List<CurvePoint> points5 = Points;
				if ((nint)obj2 >= points5._size)
				{
					break;
				}
				CurvePoint[] items2 = points5._items;
				CurvePoint curvePoint3 = items2[obj2];
				curvePoint.Y = curvePoint3.Y;
				int version = list._version + 1;
				list._version = version;
				CurvePoint[] items3 = list._items;
				if (list._size >= items3.Length)
				{
					((List<object>)(object)list).AddWithResize((object)curvePoint);
					CurvePoint curvePoint4 = (CurvePoint)0;
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					CurvePoint curvePoint4 = curvePoint;
				}
				float num2;
				if (InvertPositiveNegative)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v45+10]");
					float num = 0f * -1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rax_v46+14]");
					num2 = 0f * -1f;
				}
				if (Mirror)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v44+10]");
					num2 = 0f * -1f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rax_v33+10]");
				object obj3 = 0 / Scale;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v34+14]");
				object obj4 = 0 / Scale;
				Transform transform = base.transform;
				Vector3 position = transform.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Transform transform2 = base.transform;
				Vector3 position2 = transform2.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Transform transform3 = base.transform;
				Vector3 position3 = transform3.position;
				object obj5 = obj2 + 1;
				object obj6 = obj2 * 8;
				object obj7 = obj2 + obj6;
				_ = position3.z;
				points3 = Points;
				num2 = num3;
				obj = obj5;
				obj2 = obj5;
				continue;
			}
			_spline.SetPoints(points2);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Clear()
	{
		SplineComputer spline = _spline;
		if ((object)_spline != null && ((UnityEngine.Object)spline).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.DestroyImmediate(_spline, allowDestroyingAssets: false);
		}
	}

	public CurveConfig()
	{
		List<CurvePoint> points = new List<CurvePoint>();
		Points = points;
	}
}
