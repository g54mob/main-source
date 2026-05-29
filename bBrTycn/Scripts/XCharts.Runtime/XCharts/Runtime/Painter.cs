using System;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[RequireComponent(typeof(CanvasRenderer))]
	public class Painter : MaskableGraphic
	{
		public enum Type
		{
			Base = 0,
			Serie = 1,
			Top = 2
		}

		protected int m_Index = -1;

		protected Type m_Type;

		protected bool m_Refresh;

		protected Action<VertexHelper, Painter> m_OnPopulateMesh;

		public Action<VertexHelper, Painter> onPopulateMesh
		{
			set
			{
				m_OnPopulateMesh = value;
			}
		}

		public int index
		{
			get
			{
				return m_Index;
			}
			set
			{
				m_Index = value;
			}
		}

		public Type type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
			}
		}

		public void Refresh()
		{
			if (!(null == this) && !(base.gameObject == null) && base.gameObject.activeSelf)
			{
				m_Refresh = true;
			}
		}

		public void Init()
		{
			raycastTarget = false;
		}

		public void SetActive(bool flag, bool isDebugMode = false)
		{
			if (base.gameObject.activeInHierarchy != flag)
			{
				base.gameObject.SetActive(flag);
			}
			HideFlags hideFlags = ((!(flag && isDebugMode)) ? HideFlags.HideInHierarchy : HideFlags.None);
			if (base.gameObject.hideFlags != hideFlags)
			{
				base.gameObject.hideFlags = hideFlags;
			}
		}

		protected override void Awake()
		{
			Init();
		}

		public void CheckRefresh()
		{
			if (m_Refresh && base.gameObject.activeSelf)
			{
				m_Refresh = false;
				SetVerticesDirty();
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			if (m_OnPopulateMesh != null)
			{
				m_OnPopulateMesh(vh, this);
			}
		}
	}
}
