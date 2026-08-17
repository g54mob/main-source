using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public abstract class BaseMaterialEffect : BaseMeshEffect, IParameterTexture, IMaterialModifier
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<object, bool> _003C_003E9__15_0;

		public static Func<object, string> _003C_003E9__15_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CSetShaderVariants_003Eb__15_0(object x)
		{
			//IL_0010: Expected O, but got I
			//IL_001d: Expected I, but got O
			//IL_00f4: Expected I4, but got O
			//IL_0069: Expected O, but got I
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
			object obj = 0;
			nint num = (nint)x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v3 (Il2CppClass<System.Object>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+40]");
			if (num2 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				object obj2 = num3 ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				object obj3 = 0 & obj2;
				bool flag = (nint)obj3 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				bool flag2 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
		}

		internal string _003CSetShaderVariants_003Eb__15_1(object x)
		{
			if (x != null)
			{
				string text = x.ToString();
				if (text != null)
				{
					return text.ToUpper();
				}
			}
			return (string)(object)new NullReferenceException();
		}
	}

	protected static readonly Hash128 k_InvalidHash;

	protected static readonly List<UIVertex> s_TempVerts;

	private static readonly StringBuilder s_StringBuilder;

	private Hash128 _effectMaterialHash;

	private int _003CparameterIndex_003Ek__BackingField;

	public int parameterIndex
	{
		get
		{
			return _003CparameterIndex_003Ek__BackingField;
		}
		set
		{
			_003CparameterIndex_003Ek__BackingField = value;
		}
	}

	public virtual ParameterTexture paramTex => null;

	public void SetMaterialDirty()
	{
		GraphicConnector graphicConnector = base.connector;
		Graphic materialDirty = base.graphic;
		graphicConnector.SetMaterialDirty(materialDirty);
		List<UISyncEffect>.Enumerator enumerator = default(List<UISyncEffect>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe virtual Hash128 GetMaterialHash(Material baseMaterial)
	{
		//IL_0018: Expected I8, but got O
		//IL_0013: Expected native int or pointer, but got O
		Hash128 hash = default(Hash128);
		((Hash128*)(nint)hash)->u64_0 = (ulong)(long)k_InvalidHash;
		return hash;
	}

	public Material GetModifiedMaterial(Material baseMaterial)
	{
		//IL_000f: Expected I, but got O
		//IL_001f: Expected O, but got I
		//IL_002f: Expected O, but got I
		Graphic graphic = base.graphic;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ r9_v1 (Il2CppClass<Coffee.UIEffects.BaseMaterialEffect>)+318]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ r9_v1 (Il2CppClass<Coffee.UIEffects.BaseMaterialEffect>)+320]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v14 @ r10_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public unsafe virtual Material GetModifiedMaterial(Material baseMaterial, Graphic graphic)
	{
		//IL_0117: Expected O, but got I4
		//IL_0042: Expected O, but got I8
		//IL_00af: Expected I, but got O
		//IL_00cf: Expected O, but got Ref
		//IL_00e9: Expected O, but got Ref
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Material result;
		if (obj != null)
		{
			_effectMaterialHash = (Hash128)GetMaterialHash(baseMaterial).u64_0;
			if ((object)_effectMaterialHash == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIEffects.BaseMaterialEffect)+48]");
				bool flag2 = (nint)0 <= (nint)0;
				result = baseMaterial;
				if (flag2)
				{
					goto IL_00e0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r8_v4 (Il2CppClass<Coffee.UIEffects.BaseMaterialEffect>)+330]");
			Action<Material, Graphic> onModifyMaterial = new Action<Material, Graphic>(this, (IntPtr)0);
			nint num = (nint)this;
			ulong num2 = default(ulong);
			Material material = MaterialCache.Register(baseMaterial, (Hash128)(&num2), onModifyMaterial, graphic);
			result = material;
			goto IL_00e0;
		}
		return baseMaterial;
		IL_00e0:
		Hash128 hash = default(Hash128);
		MaterialCache.Unregister((Hash128)(&hash));
		return result;
	}

	public virtual void ModifyMaterial(Material newMaterial, Graphic graphic)
	{
		//IL_007d: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			ParameterTexture parameterTexture = paramTex;
			if (parameterTexture != null)
			{
				ParameterTexture parameterTexture2 = paramTex;
				parameterTexture2.RegisterMaterial(newMaterial);
			}
		}
	}

	protected void SetShaderVariants(Material newMaterial, object[] variants)
	{
		//IL_0118: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		Func<object, bool> predicate = _003C_003Ec._003C_003E9__15_0;
		if (_003C_003Ec._003C_003E9__15_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__15_0 = delegate(object x)
			{
				//IL_0010: Expected O, but got I
				//IL_001d: Expected I, but got O
				//IL_00f4: Expected I4, but got O
				//IL_0069: Expected O, but got I
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				//IL_007e: Expected O, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
				object obj3 = 0;
				nint num = (nint)x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v3 (Il2CppClass<System.Object>)+40]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+40]");
				if (num2 != 0)
				{
					InvalidCastException ex2 = new InvalidCastException();
					return (byte)(int)ex2 != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				object obj4 = num3 ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				object obj5 = 0 & obj4;
				bool flag = (nint)obj5 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				bool flag2 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			});
		}
		IEnumerable<object> source = Enumerable.Where(variants, predicate);
		Func<object, string> selector = _003C_003Ec._003C_003E9__15_1;
		if (_003C_003Ec._003C_003E9__15_1 == null)
		{
			selector = (_003C_003Ec._003C_003E9__15_1 = delegate(object x)
			{
				if (x != null)
				{
					string text2 = x.ToString();
					if (text2 != null)
					{
						return text2.ToUpper();
					}
				}
				return (string)(object)new NullReferenceException();
			});
		}
		IEnumerable<string> first = Enumerable.Select(source, selector);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186423890");
		IEnumerable<string> second = default(IEnumerable<string>);
		IEnumerable<string> source2 = Enumerable.Concat(first, second);
		IEnumerable<string> enumerable = Enumerable.Distinct(source2);
		if (enumerable != null)
		{
			System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)enumerable);
			System.Linq.Buffer<string> buffer2 = default(System.Linq.Buffer<string>);
			string[] array = buffer2.ToArray();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186423950");
			s_StringBuilder.Length = 0;
			Shader shader = newMaterial.shader;
			string path = ((UnityEngine.Object)shader).GetName();
			string fileName = Path.GetFileName(path);
			StringBuilder stringBuilder = s_StringBuilder.Append(fileName);
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				StringBuilder stringBuilder2 = s_StringBuilder.Append("-");
				StringBuilder stringBuilder3 = s_StringBuilder.Append(array[obj]);
				obj++;
				obj2 = obj;
			}
			string text = s_StringBuilder.ToString();
			((UnityEngine.Object)newMaterial).SetName(text);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	protected override void OnEnable()
	{
		GraphicConnector graphicConnector = base.connector;
		Graphic graphic = base.graphic;
		graphicConnector.OnEnable(graphic);
		base.SetVerticesDirty();
		ParameterTexture parameterTexture = paramTex;
		if (parameterTexture != null)
		{
			ParameterTexture parameterTexture2 = paramTex;
			parameterTexture2.Register(this);
		}
		SetMaterialDirty();
		base.SetEffectParamsDirty();
	}

	protected unsafe override void OnDisable()
	{
		//IL_0072: Expected O, but got Ref
		GraphicConnector graphicConnector = base.connector;
		Graphic graphic = base.graphic;
		graphicConnector.OnDisable(graphic);
		base.SetVerticesDirty();
		SetMaterialDirty();
		ParameterTexture parameterTexture = paramTex;
		if (parameterTexture != null)
		{
			ParameterTexture parameterTexture2 = paramTex;
			parameterTexture2.Unregister(this);
		}
		Hash128 hash = default(Hash128);
		MaterialCache.Unregister((Hash128)(&hash));
		_effectMaterialHash = k_InvalidHash;
	}

	static BaseMaterialEffect()
	{
		//IL_002d: Expected O, but got I4
		k_InvalidHash = (Hash128)0;
		List<UIVertex> list = new List<UIVertex>();
		s_TempVerts = list;
		StringBuilder stringBuilder = new StringBuilder();
		s_StringBuilder = stringBuilder;
	}
}
