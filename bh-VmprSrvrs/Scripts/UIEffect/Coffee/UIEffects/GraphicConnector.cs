using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	public class GraphicConnector
	{
		private static readonly List<GraphicConnector> s_Connectors;

		private static readonly Dictionary<Type, GraphicConnector> s_ConnectorMap;

		private static readonly GraphicConnector s_EmptyConnector;

		protected virtual int priority => 0;

		public virtual AdditionalCanvasShaderChannels extraChannel => default(AdditionalCanvasShaderChannels);

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

		public virtual Shader FindShader(string shaderName)
		{
			return null;
		}

		public virtual void OnEnable(Graphic graphic)
		{
		}

		public virtual void OnDisable(Graphic graphic)
		{
		}

		public virtual void SetVerticesDirty(Graphic graphic)
		{
		}

		public virtual void SetMaterialDirty(Graphic graphic)
		{
		}

		public virtual void GetPositionFactor(EffectArea area, int index, Rect rect, Vector2 position, out float x, out float y)
		{
			x = default(float);
			y = default(float);
		}

		public virtual bool IsText(Graphic graphic)
		{
			return false;
		}

		public virtual void SetExtraChannel(ref UIVertex vertex, Vector2 value)
		{
		}

		public virtual void GetNormalizedFactor(EffectArea area, int index, Matrix2x3 matrix, Vector2 position, out Vector2 normalizedPos)
		{
			normalizedPos = default(Vector2);
		}
	}
}
