using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Dreamteck.Splines;
using UnityEngine;

namespace VampireSurvivors;

public class SplineManager
{
	public static SplineComputer Create(Vector3 position, List<Vector2> points, Transform parent, float scale = 1f, bool flipX = false, bool flipY = false)
	{
		//IL_00be: Expected O, but got I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0154: Expected O, but got I
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		Transform transform = gameObject.transform;
		transform.parent = parent;
		SplineComputer splineComputer = gameObject.AddComponent<SplineComputer>();
		if (!splineComputer._is2D)
		{
			splineComputer._is2D = true;
			SplinePoint[] points2 = splineComputer.GetPoints();
			splineComputer.SetPoints(points2);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		SplinePoint[] array = new SplinePoint[0];
		object obj = 0;
		object obj8 = default(object);
		object obj9 = default(object);
		while (true)
		{
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj2 < 0)
			{
				if ((nint)obj >= array.Length)
				{
					break;
				}
				object obj3 = obj * 8;
				object obj4 = obj + obj3;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				object obj5 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj5 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
					object obj6 = 0;
					object obj7 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v18+18]");
					if ((nint)obj7 >= 0)
					{
						break;
					}
					if (obj8 == null)
					{
						if (obj9 != null)
						{
							continue;
						}
						if ((nint)obj >= array.Length)
						{
							break;
						}
					}
					object obj10 = obj + 1;
					object obj11 = obj * 8;
					object obj12 = obj + obj11;
					_ = position.z;
					obj = obj10;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
			}
			splineComputer.SetPoints(array);
			return splineComputer;
		}
		return (SplineComputer)(object)new IndexOutOfRangeException();
	}
}
