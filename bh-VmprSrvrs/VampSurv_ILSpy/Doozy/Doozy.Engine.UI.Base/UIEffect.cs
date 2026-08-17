using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.UI.Base;

[Serializable]
public class UIEffect
{
	public const DynamicSorting DEFAULT_AUTO_SORT = DynamicSorting.InFront;

	public const UIEffectBehavior DEFAULT_BEHAVIOR = UIEffectBehavior.Play;

	public const int DEFAULT_SORTING_ORDER = 0;

	public const int DEFAULT_SORTING_STEPS = 1;

	public const ParticleSystemStopBehavior DEFAULT_STOP_BEHAVIOR = ParticleSystemStopBehavior.StopEmitting;

	public const string DEFAULT_SORTING_LAYER = "Default";

	public DynamicSorting AutoSort;

	public UIEffectBehavior Behavior;

	public int CustomSortingOrder;

	public int SortingSteps;

	public ParticleSystem ParticleSystem;

	public ParticleSystemStopBehavior StopBehavior;

	public string CustomSortingLayer;

	private Renderer[] m_renderers;

	public ParticleSystem.MainModule MainModule
	{
		get
		{
			if ((object)ParticleSystem == null)
			{
				return (ParticleSystem.MainModule)new NullReferenceException();
			}
			return (ParticleSystem.MainModule)ParticleSystem;
		}
	}

	public Renderer[] Renderers
	{
		get
		{
			if (m_renderers == null)
			{
				if ((object)ParticleSystem == null)
				{
					return (Renderer[])(object)new NullReferenceException();
				}
				Renderer[] componentsInChildren = ParticleSystem.GetComponentsInChildren<Renderer>();
				m_renderers = componentsInChildren;
			}
			return m_renderers;
		}
	}

	public string SortingLayerName
	{
		get
		{
			Renderer[] renderers = Renderers;
			if (renderers.Length > 0)
			{
				return renderers[0].sortingLayerName;
			}
			return (string)(object)new IndexOutOfRangeException();
		}
	}

	public int SortingOrder
	{
		get
		{
			Renderer[] renderers = Renderers;
			if (renderers != null)
			{
				if (renderers.Length <= 0)
				{
					throw new IndexOutOfRangeException();
				}
				Renderer renderer = renderers[0];
				if ((object)renderers[0] != null)
				{
					bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 70 ConditionalJump @-1, v101 @ ZF_v9 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
			}
			throw new NullReferenceException();
		}
	}

	public UIEffect()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899808AD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AutoSort = DynamicSorting.InFront;
		SortingSteps = 1;
		StopBehavior = ParticleSystemStopBehavior.StopEmitting;
		CustomSortingLayer = "Default";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899808B3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AutoSort = DynamicSorting.InFront;
		StopBehavior = ParticleSystemStopBehavior.StopEmitting;
		SortingSteps = 1;
		CustomSortingLayer = "Default";
		CustomSortingOrder = 0;
	}

	public void Clear()
	{
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			ParticleSystem.Clear(withChildren: true);
		}
	}

	public void Emit(int count)
	{
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			ParticleSystem.Emit(count);
		}
	}

	public void Execute()
	{
		if (Behavior == UIEffectBehavior.Play)
		{
			Play();
		}
		else if (Behavior == UIEffectBehavior.Stop)
		{
			Stop(StopBehavior);
		}
	}

	public void Execute(string sortingLayer, int sortingOrder)
	{
		if (Behavior == UIEffectBehavior.Play)
		{
			Play(sortingLayer, sortingOrder);
		}
		else if (Behavior == UIEffectBehavior.Stop)
		{
			Stop(StopBehavior);
		}
	}

	public void OverrideSortingAndPlay(string overrideSortingLayer, int overrideSortingOrder)
	{
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			bool flag = SetSortingLayer(overrideSortingLayer);
			SetSortingOrder(overrideSortingOrder);
			Play();
		}
	}

	public void Play(string sortingLayer, int sortingOrder)
	{
		//IL_007c: Expected O, but got I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ParticleSystem particleSystem2 = ParticleSystem;
		if ((object)ParticleSystem != null)
		{
			bool flag = ((UnityEngine.Object)particleSystem2).m_CachedPtr == (IntPtr)0;
			if (!flag)
			{
				object obj = AutoSort - 1;
				int sortingOrder2;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							goto IL_0131;
						}
						bool flag2 = SetSortingLayer(CustomSortingLayer);
						sortingOrder2 = CustomSortingOrder;
					}
					else
					{
						bool flag3 = SetSortingLayer(sortingLayer);
						int num = sortingOrder - SortingSteps;
						sortingOrder2 = num;
					}
				}
				else
				{
					bool flag4 = SetSortingLayer(sortingLayer);
					sortingOrder2 = SortingSteps + sortingOrder;
				}
				SetSortingOrder(sortingOrder2);
			}
		}
		goto IL_0131;
		IL_0131:
		Play();
	}

	public void Play()
	{
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			ParticleSystem.Play(withChildren: true);
		}
	}

	public void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899808B3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AutoSort = DynamicSorting.InFront;
		StopBehavior = ParticleSystemStopBehavior.StopEmitting;
		SortingSteps = 1;
		CustomSortingLayer = "Default";
		CustomSortingOrder = 0;
	}

	public bool SetSortingLayer(string sortingLayerName)
	{
		//IL_0058: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0113: Expected I4, but got O
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			Renderer[] renderers = Renderers;
			bool flag = renderers == null;
			object obj = 0;
			object obj2 = 0;
			if (!flag)
			{
				while (true)
				{
					if ((nint)obj2 < renderers.Length)
					{
						if ((object)renderers[obj] == null)
						{
							break;
						}
						renderers[obj].sortingLayerName = sortingLayerName;
						obj++;
						obj2 = obj;
						continue;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public void SetSortingOrder(int sortingOrder)
	{
		//IL_0049: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0117->IL0057: Incompatible stack heights: 1 vs 0
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			Renderer[] renderers = Renderers;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < renderers.Length)
			{
				Renderer renderer = renderers[obj];
				bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)renderer).m_CachedPtr, sortingOrder);
				obj++;
				obj2 = obj;
			}
		}
	}

	public void Stop()
	{
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			Stop(StopBehavior);
		}
	}

	public void Stop(ParticleSystemStopBehavior stopBehavior)
	{
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			ParticleSystem.Stop(withChildren: true, stopBehavior);
		}
	}

	public void UpdateSorting(string sortingLayer, int sortingOrder)
	{
		//IL_0046: Expected O, but got I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		ParticleSystem particleSystem = ParticleSystem;
		if ((object)ParticleSystem == null)
		{
			return;
		}
		bool flag = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
		if (flag)
		{
			return;
		}
		object obj = AutoSort - 1;
		int sortingOrder2;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					return;
				}
				bool flag2 = SetSortingLayer(CustomSortingLayer);
				sortingOrder2 = CustomSortingOrder;
			}
			else
			{
				bool flag3 = SetSortingLayer(sortingLayer);
				int num = sortingOrder - SortingSteps;
				sortingOrder2 = num;
			}
		}
		else
		{
			bool flag4 = SetSortingLayer(sortingLayer);
			sortingOrder2 = SortingSteps + sortingOrder;
		}
		SetSortingOrder(sortingOrder2);
	}
}
