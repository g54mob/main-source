using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors.Tools;

public static class LayerHelper
{
	public static bool IsLayerInLayerMask(int layer, LayerMask layerMask)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected I4, but got Unknown
		int num = layer & 0x1F;
		int num2 = 1 << num;
		int num3 = layerMask & num2;
		bool flag = num3 == 0;
		return !flag;
	}

	public static void SetLayerRecursively(Transform parent, int layer)
	{
		//IL_005f: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_00b9: Expected I4, but got O
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00fd->IL0102: Incompatible stack heights: 2 vs 1
		//IL_0102->IL002e: Incompatible stack heights: 2 vs 1
		GameObject gameObject = parent.gameObject;
		gameObject.layer = layer;
		bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
		object obj = Transform.get_childCount_Injected(((UnityEngine.Object)parent).m_CachedPtr);
		bool flag2 = (nint)obj <= 0;
		object obj2 = 0;
		if (!flag2)
		{
			do
			{
				bool flag3 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
				IntPtr child_Injected = Transform.GetChild_Injected(((UnityEngine.Object)parent).m_CachedPtr, (int)obj2);
				Transform parent2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
				SetLayerRecursively(parent2, layer);
				obj2++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
		}
	}
}
