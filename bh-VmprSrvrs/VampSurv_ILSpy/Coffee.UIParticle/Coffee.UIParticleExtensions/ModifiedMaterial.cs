using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleExtensions;

internal class ModifiedMaterial
{
	private class MatEntry
	{
		public Material baseMat;

		public Material customMat;

		public int count;

		public Texture texture;

		public int id;
	}

	private static readonly List<MatEntry> s_Entries;

	public static Material Add(Material baseMat, Texture texture, int id)
	{
		//IL_03f4: Expected O, but got I4
		//IL_0438: Expected O, but got I4
		//IL_0452: Expected O, but got I4
		//IL_04ae: Expected O, but got I4
		//IL_04c8: Expected O, but got I4
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		object obj = 0;
		while (true)
		{
			List<MatEntry> list = s_Entries;
			if ((nint)obj < list._size)
			{
				List<MatEntry> list2 = s_Entries;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				MatEntry[] items = list2._items;
				MatEntry matEntry = items[obj];
				Material baseMat2 = matEntry.baseMat;
				bool flag = (object)matEntry.baseMat == null;
				bool flag2 = (object)baseMat == null;
				object obj2 = flag2 & flag;
				bool flag3 = obj2 == null;
				object obj3 = !flag3;
				if (obj3 == null)
				{
					bool flag4;
					if ((object)baseMat != null)
					{
						if ((object)matEntry.baseMat != null)
						{
							object obj4 = (object)matEntry.baseMat - (object)baseMat;
							flag4 = obj4 == null;
						}
						else
						{
							flag4 = ((UnityEngine.Object)baseMat).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag4 = ((UnityEngine.Object)baseMat2).m_CachedPtr == (IntPtr)0;
					}
					if (!flag4)
					{
						goto IL_0231;
					}
				}
				Texture texture2 = matEntry.texture;
				bool flag5 = (object)matEntry.texture == null;
				bool flag6 = (object)texture == null;
				object obj5 = flag6 & flag5;
				bool flag7 = obj5 == null;
				object obj6 = !flag7;
				if (obj6 == null)
				{
					bool flag8;
					if ((object)texture != null)
					{
						if ((object)matEntry.texture != null)
						{
							object obj7 = (object)matEntry.texture - (object)texture;
							flag8 = obj7 == null;
						}
						else
						{
							flag8 = ((UnityEngine.Object)texture).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag8 = ((UnityEngine.Object)texture2).m_CachedPtr == (IntPtr)0;
					}
					if (!flag8)
					{
						goto IL_0231;
					}
				}
				if (matEntry.id != id)
				{
					goto IL_0231;
				}
				int count = matEntry.count + 1;
				matEntry.count = count;
				return matEntry.customMat;
			}
			MatEntry matEntry2 = new MatEntry();
			matEntry2.count = 1;
			matEntry2.baseMat = baseMat;
			matEntry2.texture = texture;
			matEntry2.id = id;
			Material customMat = new Material(baseMat);
			matEntry2.customMat = customMat;
			matEntry2.customMat.hideFlags = HideFlags.HideAndDontSave;
			if ((object)texture != null && ((UnityEngine.Object)texture).m_CachedPtr != (IntPtr)0)
			{
				matEntry2.customMat.mainTexture = texture;
			}
			List<object> list3 = (List<object>)(object)s_Entries;
			int version = list3._version + 1;
			list3._version = version;
			object[] items2 = list3._items;
			if (list3._size >= items2.Length)
			{
				list3.AddWithResize((object)matEntry2);
				return matEntry2.customMat;
			}
			int size = list3._size + 1;
			list3._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return matEntry2.customMat;
			IL_0231:
			obj++;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Material result = default(Material);
		return result;
	}

	public static void Remove(Material customMat)
	{
		if ((object)customMat == null || ((UnityEngine.Object)customMat).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			List<MatEntry> list = s_Entries;
			if (num >= list._size)
			{
				return;
			}
			List<MatEntry> list2 = s_Entries;
			if (num >= list2._size)
			{
				break;
			}
			MatEntry[] items = list2._items;
			MatEntry matEntry = items[num];
			bool flag;
			if ((object)matEntry.customMat != null)
			{
				object obj = (object)matEntry.customMat - (object)customMat;
				flag = obj == null;
			}
			else
			{
				flag = ((UnityEngine.Object)customMat).m_CachedPtr == (IntPtr)0;
			}
			if (!flag)
			{
				num++;
				continue;
			}
			int count = matEntry.count - 1;
			matEntry.count = count;
			if (!flag)
			{
				DestroyImmediate(matEntry.customMat);
				matEntry.baseMat = null;
				matEntry.texture = null;
				s_Entries.RemoveAt(num);
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private static void DestroyImmediate(UnityEngine.Object obj)
	{
		if ((object)obj != null && obj.m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.Destroy(obj, 0f);
		}
	}

	static ModifiedMaterial()
	{
		List<MatEntry> list = new List<MatEntry>();
		s_Entries = list;
	}
}
