using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	internal sealed class TmpProxy : GraphicProxy
	{
		private static readonly Func<UIVertex, UIVertex, UIVertex, float, UIVertex> s_OnLerpVertex;

		private static readonly Func<UIVertex, float, UIVertex> s_OnMarkAsShadow;

		private static readonly Func<UIVertex, Rect, UIVertex> s_OnModifyVertex;

		private static Mesh s_Mesh;

		private static readonly VertexHelper s_VertexHelper;

		private static readonly HashSet<TextMeshProUGUI> s_ChangedInstances;

		private static readonly HashSet<TextMeshProUGUI> s_RegisteredInstances;

		private static readonly Dictionary<int, float> s_SdfScaleCache;

		protected override bool IsValid(Graphic graphic)
		{
			return false;
		}

		public override bool IsText(Graphic graphic)
		{
			return false;
		}

		public override void OnPreModifyMesh(Graphic graphic, Canvas canvas)
		{
		}

		public override void SetVerticesDirty(Graphic graphic, bool enabled)
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RuntimeInitializeOnLoadMethod()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
		}

		private static void ModifyMesh(TextMeshProUGUI textMeshProUGUI)
		{
		}

		private static TMP_SubMeshUI GetSubMeshUI(List<TMP_SubMeshUI> subMeshes, Material material, int start)
		{
			return null;
		}
	}
}
