using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class MainComponent : IComparable
	{
		protected bool m_VertsDirty;

		protected bool m_ComponentDirty;

		protected Painter m_Painter;

		public int instanceId => index;

		public int index { get; internal set; }

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

		internal MainComponentHandler handler { get; set; }

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

		public virtual void Reset()
		{
		}

		public virtual void ClearData()
		{
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

		public virtual void SetDefaultValue()
		{
		}

		public virtual void OnRemove()
		{
			if (handler != null)
			{
				handler.RemoveComponent();
			}
		}

		public int CompareTo(object obj)
		{
			int num = GetType().Name.CompareTo(obj.GetType().Name);
			if (num == 0)
			{
				return index.CompareTo((obj as MainComponent).index);
			}
			return num;
		}
	}
}
