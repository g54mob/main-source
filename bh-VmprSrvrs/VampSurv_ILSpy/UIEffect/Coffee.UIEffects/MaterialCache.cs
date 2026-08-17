using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public class MaterialCache
{
	private class MaterialEntry
	{
		public Material material;

		public int referenceCount;

		public void Release()
		{
			Material material = this.material;
			if ((object)this.material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
			{
				UnityEngine.Object.DestroyImmediate(this.material, allowDestroyingAssets: false);
			}
			this.material = null;
		}
	}

	private static Dictionary<Hash128, MaterialEntry> materialMap;

	public unsafe static Material Register(Material baseMaterial, Hash128 hash, Action<Material, Graphic> onModifyMaterial, Graphic graphic)
	{
		//IL_003c: Expected O, but got Ref
		//IL_006d: Expected O, but got I
		//IL_00ce: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_01c5: Expected O, but got Ref
		//IL_00fa: Expected O, but got I
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0290: Expected O, but got I4
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		if (hash.u64_0 == 0 && (long)hash.u64_1 <= 0L)
		{
			return null;
		}
		Dictionary<Hash128, MaterialEntry> dictionary = materialMap;
		ulong num2 = default(ulong);
		int num = materialMap.FindEntry((Hash128)(&num2));
		MaterialEntry materialEntry;
		MaterialEntry materialEntry2;
		if (num >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rbx_v1 (System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIEffects.MaterialCache+MaterialEntry>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v23+18]");
			if ((nint)num >= (nint)0)
			{
				return (Material)(object)new IndexOutOfRangeException();
			}
			int num3 = num << 5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v36 (System.Int32)+38+v243 @ rcx_v23]");
			materialEntry = (MaterialEntry)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v36 (System.Int32)+38+v243 @ rcx_v23]");
			materialEntry2 = (MaterialEntry)0;
			if (flag)
			{
				goto IL_01e3;
			}
			object obj2 = (nint)(&materialEntry2) >> 12;
			object obj3 = obj2 & 0x1FFFFF;
			object obj4 = obj3 >> 6;
			object obj5 = obj3 & 0x3F;
			object obj6 = obj4 * 8;
			object obj7 = 6603577472L + obj6;
			nint num5;
			do
			{
				object obj8 = 1 << (int)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v14+462E0]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v14+462E0]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v14+462E0]");
				if (num4 == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v14+462E0]");
				num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v14+462E0]");
			}
			while (num5 != 0);
		}
		else
		{
			MaterialEntry materialEntry3 = new MaterialEntry();
			Material material = new Material(baseMaterial);
			material.hideFlags = HideFlags.HideAndDontSave;
			materialEntry3.material = material;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onModifyMaterial @ r8 (System.Action`2<UnityEngine.Material, UnityEngine.UI.Graphic>)+18] (should have been resolved before IL gen)");
			bool flag2 = ((Dictionary<Hash128, object>)(object)materialMap).TryInsert((Hash128)(&num2), (object)materialEntry3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			materialEntry2 = materialEntry3;
		}
		materialEntry = materialEntry2;
		goto IL_01e3;
		IL_01e3:
		int referenceCount = materialEntry.referenceCount + 1;
		materialEntry.referenceCount = referenceCount;
		return materialEntry2.material;
	}

	public unsafe static void Unregister(Hash128 hash)
	{
		//IL_003e: Expected O, but got Ref
		//IL_006f: Expected O, but got I
		//IL_0092: Expected O, but got I
		//IL_00ad: Expected O, but got I
		//IL_0193: Expected O, but got I
		//IL_0146: Expected O, but got Ref
		//IL_0123: Expected O, but got I
		if (hash.u64_0 == 0 && (long)hash.u64_1 <= 0L)
		{
			return;
		}
		Dictionary<Hash128, MaterialEntry> dictionary = materialMap;
		ulong num2 = default(ulong);
		int num = materialMap.FindEntry((Hash128)(&num2));
		if (num < 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rbx_v2 (System.Collections.Generic.Dictionary`2<UnityEngine.Hash128, Coffee.UIEffects.MaterialCache+MaterialEntry>)+18]");
		object obj = 0;
		int num3 = num << 5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v14 (System.Int32)+38+v241 @ rcx_v9]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v11+18]");
		object obj3 = -1;
		if ((nint)obj3 > 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v11+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v11+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rdi_v5+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v11+10]");
				UnityEngine.Object.DestroyImmediate((UnityEngine.Object)0, allowDestroyingAssets: false);
			}
		}
		_ = 0;
		bool flag = ((Dictionary<Hash128, object>)(object)materialMap).Remove((Hash128)(&num2));
	}

	static MaterialCache()
	{
		Dictionary<Hash128, MaterialEntry> dictionary = null;
		EqualityComparer<Hash128> equalityComparer = EqualityComparer<Hash128>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		materialMap = dictionary;
	}
}
