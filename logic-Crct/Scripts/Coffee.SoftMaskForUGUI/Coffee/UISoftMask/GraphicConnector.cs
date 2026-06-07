using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	public class GraphicConnector
	{
		private static readonly List<GraphicConnector> s_Connectors;

		private static readonly Dictionary<Type, GraphicConnector> s_ConnectorMap;

		private static readonly GraphicConnector s_EmptyConnector;

		protected virtual int priority => 0;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
		}

		protected static void AddConnector(GraphicConnector connector)
		{
		}

		public static GraphicConnector FindConnector(Graphic graphic)
		{
			return null;
		}

		protected virtual bool IsValid(Graphic graphic)
		{
			return false;
		}

		public virtual void SetVerticesDirty(Graphic graphic)
		{
		}

		public virtual void SetMaterialDirty(Graphic graphic)
		{
		}
	}
}
