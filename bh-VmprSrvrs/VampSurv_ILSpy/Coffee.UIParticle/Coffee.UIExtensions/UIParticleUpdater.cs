using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions;

internal static class UIParticleUpdater
{
	private static readonly List<UIParticle> s_ActiveParticles;

	private static readonly List<UIParticleAttractor> s_ActiveAttractors;

	private static readonly HashSet<int> s_UpdatedGroupIds;

	private static int frameCount;

	public static int uiParticleCount
	{
		get
		{
			//IL_001d: Expected I4, but got O
			List<UIParticle> list = s_ActiveParticles;
			if (s_ActiveParticles != null)
			{
				return list._size;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public static void Register(UIParticle particle)
	{
		if ((object)particle != null && ((UnityEngine.Object)particle).m_CachedPtr != (IntPtr)0)
		{
			List<object> list = (List<object>)(object)s_ActiveParticles;
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)particle);
				return;
			}
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
	}

	public static void Unregister(UIParticle particle)
	{
		if ((object)particle != null && ((UnityEngine.Object)particle).m_CachedPtr != (IntPtr)0)
		{
			bool flag = ((List<object>)(object)s_ActiveParticles).Remove((object)particle);
		}
	}

	public static void Register(UIParticleAttractor attractor)
	{
		if ((object)attractor != null && ((UnityEngine.Object)attractor).m_CachedPtr != (IntPtr)0)
		{
			List<object> list = (List<object>)(object)s_ActiveAttractors;
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)attractor);
				return;
			}
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
	}

	public static void Unregister(UIParticleAttractor attractor)
	{
		if ((object)attractor != null && ((UnityEngine.Object)attractor).m_CachedPtr != (IntPtr)0)
		{
			bool flag = ((List<object>)(object)s_ActiveAttractors).Remove((object)attractor);
		}
	}

	private static void InitializeOnLoad()
	{
		//IL_004f: Expected I, but got O
		//IL_0065: Expected O, but got I
		Canvas.WillRenderCanvases value = Refresh;
		Delegate obj = Canvas.willRenderCanvases;
		while (true)
		{
			Delegate obj2 = Delegate.Remove(obj, value);
			bool flag = (object)obj2 == null;
			Delegate obj3 = null;
			if (!flag)
			{
				bool flag2 = (object)obj2.GetType() != typeof(Canvas.WillRenderCanvases);
				obj3 = null;
				if (!flag2)
				{
					obj3 = obj2;
				}
				if ((object)obj3 == null)
				{
					break;
				}
			}
			nint num = (nint)typeof(Canvas);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v8 (Il2CppClass<UnityEngine.Canvas>)+B8]");
			object obj4 = (nint)0 + (nint)8;
			bool flag3 = obj == obj4;
			Delegate obj5;
			if (obj == obj4)
			{
				obj4 = obj3;
				obj5 = obj;
			}
			else
			{
				obj5 = (Delegate)obj4;
			}
			Delegate obj6 = obj;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj;
			obj = obj6;
			if (!flag4)
			{
				Canvas.WillRenderCanvases value2 = Refresh;
				Canvas.willRenderCanvases += value2;
				return;
			}
		}
		throw new InvalidCastException();
	}

	private static void Refresh()
	{
		//IL_0626: Expected O, but got I4
		//IL_0402: Expected O, but got I
		//IL_0412: Expected O, but got I
		//IL_0439: Expected O, but got I
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Expected O, but got Unknown
		//IL_01e5->IL067c: Incompatible stack heights: 1 vs 0
		//IL_03a5->IL06ac: Incompatible stack heights: 1 vs 0
		//IL_04ef->IL06d3: Incompatible stack heights: 1 vs 0
		//IL_0618->IL06ce: Incompatible stack heights: 1 vs 0
		object obj = Time.frameCount;
		if (frameCount == (nint)obj)
		{
			return;
		}
		int num = Time.frameCount;
		frameCount = num;
		Canvas canvas = null;
		while (true)
		{
			List<UIParticle> list = s_ActiveParticles;
			if ((nint)canvas >= list._size)
			{
				break;
			}
			List<UIParticle> list2 = s_ActiveParticles;
			bool flag = (nint)canvas >= list2._size;
			UIParticle[] items = list2._items;
			Graphic graphic = items[(object)canvas];
			if ((object)items[(object)canvas] != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
			{
				Canvas canvas2 = items[(object)canvas].canvas;
				if ((bool)canvas2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v20 (UnityEngine.UI.Graphic)+100]");
					if ((nint)0 != 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v20 (UnityEngine.UI.Graphic)+100]");
						if ((nint)0 != 3)
						{
							goto IL_01d2;
						}
					}
					HashSet<int> hashSet = s_UpdatedGroupIds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v20 (UnityEngine.UI.Graphic)+128]");
					if (!hashSet.Contains(0))
					{
						HashSet<int> hashSet2 = s_UpdatedGroupIds;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v20 (UnityEngine.UI.Graphic)+128]");
						bool flag2 = hashSet2.AddIfNotPresent(0);
						items[(object)canvas].UpdateTransformScale();
						items[(object)canvas].UpdateRenderers();
					}
				}
			}
			goto IL_01d2;
			IL_01d2:
			canvas = (Canvas)(canvas + 1);
		}
		Canvas canvas3 = null;
		while (true)
		{
			List<UIParticle> list3 = s_ActiveParticles;
			if ((nint)canvas3 >= list3._size)
			{
				break;
			}
			List<UIParticle> list4 = s_ActiveParticles;
			bool flag3 = (nint)canvas3 >= list4._size;
			UIParticle[] items2 = list4._items;
			Graphic graphic2 = items2[(object)canvas3];
			if ((object)items2[(object)canvas3] != null && ((UnityEngine.Object)graphic2).m_CachedPtr != (IntPtr)0)
			{
				Canvas canvas4 = items2[(object)canvas3].canvas;
				if ((bool)canvas4)
				{
					items2[(object)canvas3].UpdateTransformScale();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rbx_v18 (UnityEngine.UI.Graphic)+100]");
					if ((nint)0 > (nint)0)
					{
						HashSet<int> hashSet3 = s_UpdatedGroupIds;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rbx_v18 (UnityEngine.UI.Graphic)+128]");
						if (hashSet3.Contains(0))
						{
							goto IL_0392;
						}
						HashSet<int> hashSet4 = s_UpdatedGroupIds;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rbx_v18 (UnityEngine.UI.Graphic)+128]");
						bool flag4 = hashSet4.AddIfNotPresent(0);
					}
					items2[(object)canvas3].UpdateRenderers();
				}
			}
			goto IL_0392;
			IL_0392:
			canvas3 = (Canvas)(canvas3 + 1);
		}
		HashSet<int> hashSet5 = s_UpdatedGroupIds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v10 (System.Collections.Generic.HashSet`1<System.Int32>)+24]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v10 (System.Collections.Generic.HashSet`1<System.Int32>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v10 (System.Collections.Generic.HashSet`1<System.Int32>)+24]");
			Array.Clear((Array)num2, 0, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v10 (System.Collections.Generic.HashSet`1<System.Int32>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v10 (System.Collections.Generic.HashSet`1<System.Int32>)+10]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ r8_v9+18]");
			Array.Clear((Array)num3, 0, 0);
			_ = 0;
			_ = 4294967295L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v10 (System.Collections.Generic.HashSet`1<System.Int32>)+38]");
		_ = (nint)0 + (nint)1;
		Canvas canvas5 = null;
		Canvas canvas6;
		while (true)
		{
			List<UIParticleAttractor> list5 = s_ActiveAttractors;
			bool flag5 = (nint)canvas5 >= list5._size;
			canvas6 = null;
			if (!flag5)
			{
				List<UIParticleAttractor> list6 = s_ActiveAttractors;
				bool flag6 = (nint)canvas5 >= list6._size;
				UIParticleAttractor[] items3 = list6._items;
				items3[(object)canvas5].Attract();
				canvas5 = (Canvas)(canvas5 + 1);
				continue;
			}
			break;
		}
		while (true)
		{
			List<UIParticle> list7 = s_ActiveParticles;
			if ((nint)canvas6 >= list7._size)
			{
				break;
			}
			List<UIParticle> list8 = s_ActiveParticles;
			bool flag7 = (nint)canvas6 >= list8._size;
			UIParticle[] items4 = list8._items;
			Graphic graphic3 = items4[(object)canvas6];
			if ((object)items4[(object)canvas6] != null && ((UnityEngine.Object)graphic3).m_CachedPtr != (IntPtr)0)
			{
				Canvas canvas7 = items4[(object)canvas6].canvas;
				if ((bool)canvas7)
				{
					items4[(object)canvas6].UpdateParticleCount();
				}
			}
			canvas6 = (Canvas)(canvas6 + 1);
		}
	}

	public static void GetGroupedRenderers(int groupId, int index, List<UIParticleRenderer> results)
	{
		int version = results._version + 1;
		results._version = version;
		results._size = 0;
		if (results._size > 0)
		{
			Array.Clear(results._items, 0, results._size);
		}
		int num = 0;
		while (true)
		{
			List<UIParticle> list = s_ActiveParticles;
			if (num >= list._size)
			{
				return;
			}
			List<UIParticle> list2 = s_ActiveParticles;
			if (num >= list2._size)
			{
				break;
			}
			UIParticle[] items = list2._items;
			UIParticle uIParticle = items[num];
			if (uIParticle.m_MeshSharing > UIParticle.MeshSharing.None && uIParticle._groupId == groupId)
			{
				UIParticleRenderer renderer = uIParticle.GetRenderer(index);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800049E0");
			}
			num++;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	internal static UIParticle GetPrimary(int groupId)
	{
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		UIParticle uIParticle = null;
		UIParticle uIParticle2 = null;
		while (true)
		{
			List<UIParticle> list = s_ActiveParticles;
			if ((nint)uIParticle < list._size)
			{
				List<UIParticle> list2 = s_ActiveParticles;
				if ((nint)uIParticle >= list2._size)
				{
					break;
				}
				UIParticle[] items = list2._items;
				UIParticle uIParticle3 = items[(object)uIParticle];
				if (uIParticle3.m_MeshSharing > UIParticle.MeshSharing.None && uIParticle3._groupId == groupId)
				{
					if (uIParticle3.m_MeshSharing == UIParticle.MeshSharing.Primary || uIParticle3.m_MeshSharing == UIParticle.MeshSharing.PrimarySimulator)
					{
						return uIParticle3;
					}
					if (((object)uIParticle2 == null || ((UnityEngine.Object)uIParticle2).m_CachedPtr == (IntPtr)0) && (uIParticle3.m_MeshSharing == UIParticle.MeshSharing.None || uIParticle3.m_MeshSharing == UIParticle.MeshSharing.Auto || uIParticle3.m_MeshSharing == UIParticle.MeshSharing.Primary || uIParticle3.m_MeshSharing == UIParticle.MeshSharing.PrimarySimulator))
					{
						uIParticle2 = uIParticle3;
					}
				}
				uIParticle = (UIParticle)(uIParticle + 1);
				continue;
			}
			return uIParticle2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		UIParticle result = default(UIParticle);
		return result;
	}

	static UIParticleUpdater()
	{
		List<UIParticle> list = new List<UIParticle>();
		s_ActiveParticles = list;
		List<UIParticleAttractor> list2 = new List<UIParticleAttractor>();
		s_ActiveAttractors = list2;
		HashSet<int> hashSet = new HashSet<int>();
		s_UpdatedGroupIds = hashSet;
		frameCount = 0;
	}
}
