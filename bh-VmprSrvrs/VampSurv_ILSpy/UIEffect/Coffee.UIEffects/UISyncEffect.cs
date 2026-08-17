using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class UISyncEffect : BaseMaterialEffect
{
	private BaseMeshEffect m_TargetEffect;

	public BaseMeshEffect targetEffect
	{
		get
		{
			//IL_00a6: Expected O, but got I4
			//IL_00c0: Expected O, but got I4
			bool flag = (object)m_TargetEffect == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)m_TargetEffect != null)
				{
					object obj3 = (object)m_TargetEffect - (object)this;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					return m_TargetEffect;
				}
			}
			return null;
		}
		set
		{
			//IL_0111: Expected O, but got I4
			//IL_012b: Expected O, but got I4
			BaseMeshEffect baseMeshEffect = m_TargetEffect;
			bool flag = (object)m_TargetEffect == null;
			bool flag2 = (object)value == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 != null)
			{
				return;
			}
			bool flag4;
			if ((object)value != null)
			{
				if ((object)m_TargetEffect != null)
				{
					object obj3 = (object)m_TargetEffect - (object)value;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)value).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)baseMeshEffect).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				m_TargetEffect = value;
				base.SetVerticesDirty();
				SetMaterialDirty();
				base.SetEffectParamsDirty();
			}
		}
	}

	protected override void OnEnable()
	{
		BaseMeshEffect baseMeshEffect = targetEffect;
		if ((object)baseMeshEffect != null && ((UnityEngine.Object)baseMeshEffect).m_CachedPtr != (IntPtr)0)
		{
			BaseMeshEffect baseMeshEffect2 = targetEffect;
			List<object> list = (List<object>)(object)baseMeshEffect2.syncEffects;
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)this);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		base.OnEnable();
	}

	protected override void OnDisable()
	{
		BaseMeshEffect baseMeshEffect = targetEffect;
		if ((object)baseMeshEffect != null && ((UnityEngine.Object)baseMeshEffect).m_CachedPtr != (IntPtr)0)
		{
			BaseMeshEffect baseMeshEffect2 = targetEffect;
			bool flag = ((List<object>)(object)baseMeshEffect2.syncEffects).Remove((object)this);
		}
		base.OnDisable();
	}

	public unsafe override Hash128 GetMaterialHash(Material baseMaterial)
	{
		//IL_01ab: Expected O, but got I4
		//IL_0231: Expected I8, but got O
		//IL_0061: Expected I, but got O
		//IL_006f: Expected I, but got O
		//IL_007f: Expected O, but got I
		//IL_0219: Expected native int or pointer, but got O
		//IL_00ff: Expected O, but got I4
		//IL_00bb: Expected O, but got I
		//IL_00f1: Expected O, but got I4
		//IL_018d: Expected I8, but got O
		//IL_0170: Expected I, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		BaseMeshEffect baseMeshEffect;
		BaseMeshEffect baseMeshEffect2;
		object obj4;
		if (obj != null)
		{
			baseMeshEffect = targetEffect;
			if ((object)baseMeshEffect == null)
			{
				baseMeshEffect2 = null;
				goto IL_01f4;
			}
			nint num = (nint)baseMeshEffect;
			nint num2 = (nint)typeof(BaseMaterialEffect);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v11 (Il2CppClass<Coffee.UIEffects.BaseMaterialEffect>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r9_v6 (Il2CppClass<Coffee.UIEffects.BaseMeshEffect>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v11 (Il2CppClass<Coffee.UIEffects.BaseMaterialEffect>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r9_v6 (Il2CppClass<Coffee.UIEffects.BaseMeshEffect>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v43+FFFFFFF8+v248 @ rax_v39*8]");
				if (0 == (nint)typeof(BaseMaterialEffect))
				{
					obj4 = 1;
					goto IL_01cd;
				}
			}
			obj4 = 0;
			goto IL_01cd;
		}
		goto IL_0228;
		IL_0211:
		Hash128 hash = default(Hash128);
		ulong u64_;
		((Hash128*)(nint)hash)->u64_0 = u64_;
		return hash;
		IL_0228:
		u64_ = (ulong)(long)BaseMaterialEffect.k_InvalidHash;
		goto IL_0211;
		IL_01f4:
		if ((object)baseMeshEffect2 != null && ((UnityEngine.Object)baseMeshEffect2).m_CachedPtr != (IntPtr)0 && baseMeshEffect2.IsActive())
		{
			nint num4 = (nint)baseMeshEffect2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v496 @ r9_v4 (Il2CppClass<Coffee.UIEffects.BaseMeshEffect>)+308] (should have been resolved before IL gen)");
			goto IL_0228;
		}
		u64_ = (ulong)(long)BaseMaterialEffect.k_InvalidHash;
		goto IL_0211;
		IL_01cd:
		bool flag2 = obj4 == null;
		baseMeshEffect2 = null;
		if (!flag2)
		{
			baseMeshEffect2 = baseMeshEffect;
		}
		goto IL_01f4;
	}

	public override void ModifyMaterial(Material newMaterial, Graphic graphic)
	{
		//IL_0193: Expected O, but got I4
		//IL_0061: Expected I, but got O
		//IL_006f: Expected I, but got O
		//IL_007f: Expected O, but got I
		//IL_00ff: Expected O, but got I4
		//IL_00bb: Expected O, but got I
		//IL_00f1: Expected O, but got I4
		//IL_0170: Expected I, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj == null)
		{
			return;
		}
		BaseMeshEffect baseMeshEffect = targetEffect;
		BaseMeshEffect baseMeshEffect2;
		if ((object)baseMeshEffect == null)
		{
			baseMeshEffect2 = null;
			goto IL_01dc;
		}
		nint num = (nint)baseMeshEffect;
		nint num2 = (nint)typeof(BaseMaterialEffect);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rdx_v9 (Il2CppClass<Coffee.UIEffects.BaseMaterialEffect>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r9_v4 (Il2CppClass<Coffee.UIEffects.BaseMeshEffect>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rdx_v9 (Il2CppClass<Coffee.UIEffects.BaseMaterialEffect>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r9_v4 (Il2CppClass<Coffee.UIEffects.BaseMeshEffect>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v32+FFFFFFF8+v278 @ rax_v28*8]");
			if (0 == (nint)typeof(BaseMaterialEffect))
			{
				obj4 = 1;
				goto IL_01b5;
			}
		}
		obj4 = 0;
		goto IL_01b5;
		IL_01dc:
		if ((object)baseMeshEffect2 != null && ((UnityEngine.Object)baseMeshEffect2).m_CachedPtr != (IntPtr)0 && baseMeshEffect2.IsActive())
		{
			nint num4 = (nint)baseMeshEffect2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v426 @ rax_v21 (Il2CppClass<Coffee.UIEffects.BaseMeshEffect>)+328] (should have been resolved before IL gen)");
		}
		return;
		IL_01b5:
		bool flag2 = obj4 == null;
		baseMeshEffect2 = null;
		if (!flag2)
		{
			baseMeshEffect2 = baseMeshEffect;
		}
		goto IL_01dc;
	}

	public override void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
		//IL_00d3: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj == null)
		{
			return;
		}
		BaseMeshEffect baseMeshEffect = targetEffect;
		if ((object)baseMeshEffect != null && ((UnityEngine.Object)baseMeshEffect).m_CachedPtr != (IntPtr)0)
		{
			BaseMeshEffect baseMeshEffect2 = targetEffect;
			if (baseMeshEffect2.IsActive())
			{
				BaseMeshEffect baseMeshEffect3 = targetEffect;
				baseMeshEffect3.ModifyMesh(vh, graphic);
			}
		}
	}
}
