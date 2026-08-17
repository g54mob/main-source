using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class GraphicConnector
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<GraphicConnector> _003C_003E9__4_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CAddConnector_003Eb__4_0(GraphicConnector x, GraphicConnector y)
		{
			//IL_0074: Expected I4, but got O
			if (y != null)
			{
				int priority = y.priority;
				if (x != null)
				{
					int priority2 = x.priority;
					return priority - priority2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private static readonly List<GraphicConnector> s_Connectors;

	private static readonly Dictionary<Type, GraphicConnector> s_ConnectorMap;

	private static readonly GraphicConnector s_EmptyConnector;

	protected virtual int priority
	{
		get
		{
			//IL_000a: Expected I4, but got I8
			return -1;
		}
	}

	public virtual AdditionalCanvasShaderChannels extraChannel => AdditionalCanvasShaderChannels.TexCoord1;

	private static void Init()
	{
		GraphicConnector graphicConnector = new GraphicConnector();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 41 Invalid \"Jump target not found in method: 0x185D38180\"");
	}

	protected static void AddConnector(GraphicConnector connector)
	{
		List<object> list = (List<object>)(object)s_Connectors;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)connector);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__4_0;
		if (_003C_003Ec._003C_003E9__4_0 == null)
		{
			comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__4_0 = delegate(GraphicConnector x, GraphicConnector y)
			{
				//IL_0074: Expected I4, but got O
				if (y != null)
				{
					int num = y.priority;
					if (x != null)
					{
						int num2 = x.priority;
						return num - num2;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			});
		}
		((List<object>)(object)s_Connectors).Sort(comparison);
	}

	public unsafe static GraphicConnector FindConnector(Graphic graphic)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_008e: Expected O, but got Ref
		if ((object)graphic != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
		{
			object obj = graphic + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			if (s_ConnectorMap != null)
			{
				object key = default(object);
				if (((Dictionary<object, object>)(object)s_ConnectorMap).TryGetValue(key, out object value))
				{
					return (GraphicConnector)value;
				}
				if (s_Connectors != null)
				{
					List<GraphicConnector>.Enumerator enumerator = default(List<GraphicConnector>.Enumerator);
					if (enumerator.MoveNext())
					{
						object obj2 = null;
						List<GraphicConnector>.Enumerator enumerator2 = (List<GraphicConnector>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					goto IL_01b8;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_01b8;
		IL_01b8:
		return s_EmptyConnector;
	}

	protected virtual bool IsValid(Graphic graphic)
	{
		return true;
	}

	public virtual Shader FindShader(string shaderName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189992D3D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string name = "Hidden/" + shaderName;
		return Shader.Find(name);
	}

	public virtual void OnEnable(Graphic graphic)
	{
	}

	public virtual void OnDisable(Graphic graphic)
	{
	}

	public virtual void SetVerticesDirty(Graphic graphic)
	{
		if ((object)graphic != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
		{
			graphic.SetVerticesDirty();
		}
	}

	public virtual void SetMaterialDirty(Graphic graphic)
	{
		if ((object)graphic != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
		{
			graphic.SetMaterialDirty();
		}
	}

	public unsafe virtual void GetPositionFactor(EffectArea area, int index, Rect rect, Vector2 position, out float x, out float y)
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00cd: Invalid comparison between I4 and F4
		//IL_0118: Expected F4, but got I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_004b: Invalid comparison between I4 and F4
		//IL_018f: Expected O, but got F4
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_0096: Expected F4, but got I4
		//IL_01d2: Invalid comparison between I4 and F4
		//IL_015d: Expected O, but got F4
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0150: Expected F4, but got I4
		//IL_01c8: Expected O, but got F4
		//IL_0146: Expected O, but got F4
		object obj2 = default(object);
		object obj5 = default(object);
		float num2;
		if (area != EffectArea.Fit)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ r9 (System.Int32)+8]");
			object obj = obj2 / 0;
			float num = (float)obj + 0.5f;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ r9 (System.Int32)+C]");
			object obj4 = obj5 / 0;
			num2 = (float)obj4 + 0.5f;
		}
		else
		{
			object obj6 = obj2 - ((int*)(&rect))->m_value;
			float num3 = (float)obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ r9 (System.Int32)+8]");
			float num4 = num3 / 0f;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			object obj3 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ r9 (System.Int32)+4]");
			object obj7 = obj5 - 0;
			float num5 = (float)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ r9 (System.Int32)+C]");
			num2 = num5 / 0f;
		}
		object obj8;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				obj8 = 1f;
				return;
			}
		}
		else
		{
			num2 = 0f;
		}
		obj8 = num2;
	}

	public virtual bool IsText(Graphic graphic)
	{
		//IL_0044: Expected I, but got O
		//IL_004c: Expected I, but got O
		//IL_005c: Expected O, but got I
		//IL_0098: Expected O, but got I
		if ((object)graphic != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
		{
			nint num = (nint)typeof(Text);
			nint num2 = (nint)graphic;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v1 (Il2CppClass<UnityEngine.UI.Text>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ r8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v1 (Il2CppClass<UnityEngine.UI.Text>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ r8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v15+FFFFFFF8+v190 @ rax_v9*8]");
				if (0 == (nint)typeof(Text))
				{
					Graphic graphic2 = null;
					graphic2 = graphic;
					bool flag = (object)graphic2 == null;
					return !flag;
				}
			}
			Graphic graphic3 = null;
			bool flag2 = (object)graphic3 == null;
			return !flag2;
		}
		return false;
	}

	public virtual void SetExtraChannel(ref UIVertex vertex, Vector2 value)
	{
	}

	public virtual void GetNormalizedFactor(EffectArea area, int index, Matrix2x3 matrix, Vector2 position, out Vector2 normalizedPos)
	{
		object obj2 = default(object);
		object obj = obj2;
	}

	static GraphicConnector()
	{
		List<GraphicConnector> list = new List<GraphicConnector>();
		s_Connectors = list;
		Dictionary<Type, GraphicConnector> dictionary = new Dictionary<Type, GraphicConnector>();
		s_ConnectorMap = dictionary;
		GraphicConnector graphicConnector = new GraphicConnector();
		s_EmptyConnector = graphicConnector;
	}
}
