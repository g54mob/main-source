using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Graphics.Blitters;

[Serializable]
public class Bob : IDisposable
{
	private const int GrowAmount = 256;

	private static Stack<Bob> emptyBobs;

	private float2 _position;

	private float2 _scale;

	private Sprite _sprite;

	private static Color32 _white;

	[NonSerialized]
	internal BobVertexData[] vertexData;

	private BobData _bobData;

	private bool _disposed;

	[NonSerialized]
	public float2 halfSize;

	private Rect spriteRect;

	public float2 Position
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
		set
		{
			_position = value;
		}
	}

	public float2 Scale
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
		set
		{
			_scale = value;
		}
	}

	public Sprite Sprite => _sprite;

	public BobData BobData
	{
		get
		{
			return _bobData;
		}
		set
		{
			_bobData = value;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	internal unsafe ref BobVertexData GetVertexData(int id)
	{
		//IL_000e: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Ref, but got Unknown
		object obj = id * 2;
		object obj2 = id + obj;
		object obj3 = obj2 * 4;
		object obj4 = (object)vertexData + obj3;
		return ref *(BobVertexData*)(obj4 + 32);
	}

	private Bob()
	{
		BobVertexData[] array = new BobVertexData[4];
		vertexData = array;
		BobData bobData = new BobData();
		_bobData = bobData;
	}

	private void Reset(Vector2 position, Sprite sprite, Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
	{
		//IL_0133: Expected O, but got I
		//IL_014c: Expected O, but got I4
		//IL_00f8: Expected O, but got I
		//IL_01c9: Expected O, but got I4
		//IL_01d2: Expected O, but got I4
		//IL_011a: Expected O, but got I
		//IL_0123: Expected O, but got I4
		//IL_02b3: Expected I, but got O
		//IL_010f->IL01c0: Incompatible stack heights: 0 vs 1
		//IL_016c->IL016c: Incompatible stack heights: 2 vs 1
		bool flag2;
		if ((object)sprite != null)
		{
			bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			flag2 = flag;
		}
		else
		{
			flag2 = true;
		}
		_disposed = false;
		BobData bobData = _bobData;
		Sprite sprite2 = null;
		if (!flag2)
		{
			sprite2 = sprite;
		}
		bobData._003CTop_003Ek__BackingField = 0f;
		bobData._003CRight_003Ek__BackingField = 0f;
		bobData._003CVy_003Ek__BackingField = 0f;
		bobData._003CVx_003Ek__BackingField = 0f;
		bobData._003CID_003Ek__BackingField = 0;
		_position = position;
		bool num3;
		float num;
		float num2;
		if ((object)sprite2 == _sprite)
		{
			if ((object)sprite2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
				spriteRect = (Rect)0;
				num = 0.01f;
				num2 = 0.01f;
				goto IL_01c0;
			}
			IntPtr cachedPtr = ((UnityEngine.Object)sprite2).m_CachedPtr;
			bool flag3 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
			num3 = flag3;
			object obj = 0;
			object obj2 = 0;
		}
		else
		{
			IntPtr cachedPtr = ((UnityEngine.Object)sprite2).m_CachedPtr;
			bool flag4 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
			num3 = flag4;
			object obj = 0;
			bool flag5 = (nint)0 != 0;
			object obj2 = 0;
			if (!flag5)
			{
				bool flag6 = (nint)0 == 0;
				goto IL_02a5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v564 @ rax_v19 (should have been resolved before IL gen)");
		Rect rect = default(Rect);
		spriteRect = rect;
		float pixelsPerUnit = sprite2.pixelsPerUnit;
		float num4 = 1f / pixelsPerUnit;
		float num5 = num4 * 0.5f;
		object obj3 = default(object);
		num = num5 * (float)obj3;
		num2 = num5 * (float)obj3;
		goto IL_01c0;
		IL_01c0:
		object obj4 = 64;
		object obj5 = 60;
		_sprite = sprite2;
		goto IL_02a5;
		IL_02a5:
		nint num6 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rax_v25 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num7 = 0;
		_scale = Vector2.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rcx_v25 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876231A0");
		BobVertexData[] array = vertexData;
		BobVertexData[] array2 = vertexData;
		BobVertexData[] array3 = vertexData;
		BobVertexData[] array4 = vertexData;
	}

	private Bob(Vector2 position, Sprite sprite, Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
	{
		BobVertexData[] array = new BobVertexData[4];
		vertexData = array;
		BobData bobData = new BobData();
		_bobData = bobData;
		Color32 tint5 = default(Color32);
		Reset(position, sprite, tint1, tint2, tint3, tint5);
	}

	[MethodImpl((MethodImplOptions)256)]
	public static Bob Create(Vector2 position, Sprite sprite)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187623360");
		Bob result = default(Bob);
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static Bob Create(Vector2 position, Sprite sprite, Color32 tint)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876233E0");
		Bob result = default(Bob);
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe static Bob Create(Vector2 position, Sprite sprite, Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
	{
		//IL_0055: Expected O, but got Ref
		//IL_0070: Expected O, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		Stack<Bob> stack = emptyBobs;
		if (emptyBobs != null)
		{
			if (stack._size != 0)
			{
				goto IL_016b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Grow bobs by {0}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			object obj2 = 0;
			while (true)
			{
				Bob item = new Bob();
				if (emptyBobs == null)
				{
					break;
				}
				((Stack<object>)(object)emptyBobs).Push((object)item);
				obj2++;
				if ((nint)obj2 >= 256)
				{
					goto IL_016b;
				}
			}
		}
		goto IL_00ff;
		IL_016b:
		if (emptyBobs != null)
		{
			object obj3 = ((Stack<object>)(object)emptyBobs).Pop();
			if (obj3 != null)
			{
				Color32 tint5 = default(Color32);
				Color32 tint6 = default(Color32);
				Color32 tint7 = default(Color32);
				((Bob)obj3).Reset(position, sprite, tint1, tint5, tint6, tint7);
				return (Bob)obj3;
			}
		}
		goto IL_00ff;
		IL_00ff:
		return (Bob)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	private void LoadUVs()
	{
		Sprite sprite = _sprite;
		if ((object)_sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			Texture2D texture = _sprite.texture;
			Vector2 texelSize = texture.texelSize;
			object obj = (object)texelSize * (object)spriteRect;
			object obj3 = default(object);
			object obj4 = default(object);
			object obj2 = obj3 * obj4;
			object obj5 = obj4 + (object)spriteRect;
			object obj6 = obj4 + obj4;
			object obj7 = (object)texelSize * obj5;
			object obj8 = obj3 * obj6;
			BobVertexData[] array = vertexData;
			BobVertexData[] array2 = vertexData;
			BobVertexData[] array3 = vertexData;
			BobVertexData[] array4 = vertexData;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetAlpha(float alpha)
	{
		BobVertexData[] array = vertexData;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		BobVertexData[] array2 = vertexData;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		BobVertexData[] array3 = vertexData;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		BobVertexData[] array4 = vertexData;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetAlpha(float alpha, int vertIndex)
	{
		//IL_0018: Expected O, but got I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		BobVertexData[] array = vertexData;
		object obj = vertIndex * 2;
		object obj2 = vertIndex + obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetTint(Color32 tint)
	{
		BobVertexData[] array = vertexData;
		BobVertexData[] array2 = vertexData;
		BobVertexData[] array3 = vertexData;
		BobVertexData[] array4 = vertexData;
	}

	[MethodImpl((MethodImplOptions)256)]
	public void SetTint(Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
	{
		BobVertexData[] array = vertexData;
		BobVertexData[] array2 = vertexData;
		BobVertexData[] array3 = vertexData;
		BobVertexData[] array4 = vertexData;
	}

	public void SetTint(Color32 tint, int vertIndex)
	{
		//IL_000e: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		object obj = vertIndex * 2;
		object obj2 = vertIndex + obj;
		BobVertexData[] array = vertexData;
	}

	[MethodImpl((MethodImplOptions)256)]
	public Color32 GetTint()
	{
		//IL_0017: Expected O, but got I
		BobVertexData[] array = vertexData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BobVertexData[])+20]");
		return (Color32)0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public float GetAlpha()
	{
		//IL_0017: Expected F4, but got I
		BobVertexData[] array = vertexData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BobVertexData[])+23]");
		return 0f;
	}

	[MethodImpl((MethodImplOptions)256)]
	public Color32 GetTint(int vertIndex)
	{
		//IL_000e: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0032: Expected O, but got I
		object obj = vertIndex * 2;
		object obj2 = vertIndex + obj;
		BobVertexData[] array = vertexData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rax_v2 (BobVertexData[])+20+v3 @ rdx_v1*4]");
		return (Color32)0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			((Stack<object>)(object)emptyBobs).Push((object)this);
		}
	}

	static Bob()
	{
		//IL_0013: Expected O, but got I8
		Stack<Bob> stack = new Stack<Bob>(512);
		emptyBobs = stack;
		_white = (Color32)4294967295L;
	}
}
