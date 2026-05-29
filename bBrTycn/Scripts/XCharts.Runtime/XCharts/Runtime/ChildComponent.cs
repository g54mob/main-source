using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class ChildComponent
	{
		[NonSerialized]
		protected bool m_VertsDirty;

		[NonSerialized]
		protected bool m_ComponentDirty;

		[NonSerialized]
		protected Painter m_Painter;

		public virtual int index { get; set; }

		public virtual bool vertsDirty => m_VertsDirty;

		public virtual bool componentDirty => m_ComponentDirty;

		public bool anyDirty
		{
			get
			{
				if (!vertsDirty)
				{
					return componentDirty;
				}
				return true;
			}
		}

		public Painter painter
		{
			get
			{
				return m_Painter;
			}
			set
			{
				m_Painter = value;
			}
		}

		public Action refreshComponent { get; set; }

		public GameObject gameObject { get; set; }

		public static void ClearVerticesDirty(ChildComponent component)
		{
			component?.ClearVerticesDirty();
		}

		public static void ClearComponentDirty(ChildComponent component)
		{
			component?.ClearComponentDirty();
		}

		public static bool IsVertsDirty(ChildComponent component)
		{
			return component?.vertsDirty ?? false;
		}

		public static bool IsComponentDirty(ChildComponent component)
		{
			return component?.componentDirty ?? false;
		}

		public virtual void SetVerticesDirty()
		{
			m_VertsDirty = true;
		}

		public virtual void ClearVerticesDirty()
		{
			m_VertsDirty = false;
		}

		public virtual void SetComponentDirty()
		{
			m_ComponentDirty = true;
		}

		public virtual void ClearComponentDirty()
		{
			m_ComponentDirty = false;
		}

		public virtual void ClearDirty()
		{
			ClearVerticesDirty();
			ClearComponentDirty();
		}

		public virtual void SetAllDirty()
		{
			SetVerticesDirty();
			SetComponentDirty();
		}
	}
}
