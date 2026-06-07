using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	public class GraphicProxy
	{
		private static readonly List<GraphicProxy> s_Proxies;

		private static readonly Func<UIVertex, UIVertex, UIVertex, float, UIVertex> s_OnLerpVertex;

		private static readonly Func<UIVertex, float, UIVertex> s_OnMarkAsShadow;

		private static readonly Func<UIVertex, Rect, UIVertex> s_OnModifyVertex;

		public static void Register(GraphicProxy proxy)
		{
		}

		public static GraphicProxy Find(Graphic graphic)
		{
			return null;
		}

		protected virtual bool IsValid(Graphic graphic)
		{
			return false;
		}

		public virtual bool IsText(Graphic graphic)
		{
			return false;
		}

		public virtual void OnPreModifyMesh(Graphic graphic, Canvas canvas)
		{
		}

		public virtual void SetVerticesDirty(Graphic graphic, bool enabled)
		{
		}

		public virtual Vector4 ModifyExpandSize(Graphic graphic, Vector4 expandSize)
		{
			return default(Vector4);
		}
	}
}
