using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public abstract class BaseSerie
	{
		[NonSerialized]
		protected bool m_VertsDirty;

		[NonSerialized]
		protected bool m_ComponentDirty;

		[NonSerialized]
		protected Painter m_Painter;

		[NonSerialized]
		public SerieContext context = new SerieContext();

		[NonSerialized]
		public InteractData interact = new InteractData();

		public virtual bool vertsDirty => m_VertsDirty;

		public virtual bool componentDirty => m_ComponentDirty;

		public virtual SerieColorBy defaultColorBy => SerieColorBy.Serie;

		public virtual bool titleJustForSerie => false;

		public virtual bool useSortData => false;

		public virtual bool multiDimensionLabel => false;

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

		public SerieHandler handler { get; set; }

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

		public virtual void OnRemove()
		{
			if (handler != null)
			{
				handler.RemoveComponent();
			}
		}

		public virtual void OnDataUpdate()
		{
		}

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
			OnDataUpdate();
		}

		public void RefreshLabel()
		{
			if (handler != null)
			{
				handler.RefreshLabelNextFrame();
			}
		}
	}
}
