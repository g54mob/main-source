using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class InteractionArea : Graphic, ICanvasRaycastFilter, IResolutionDependency
	{
		public enum Shape
		{
			Rectangle = 0,
			RoundedRectangle = 1,
			Ellipse = 2
		}

		public Shape ClickableShape;

		[SerializeField]
		private FloatSizeModifier cornerRadiusFallback;

		[SerializeField]
		private FloatSizeConfigCollection cornerRadiusConfigs;

		public float CurrentCornerRadius => 0f;

		public override void SetMaterialDirty()
		{
		}

		public override void SetVerticesDirty()
		{
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
		}

		protected override void OnEnable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		public void UpdateCornerRadius()
		{
		}

		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void DrawGizmos()
		{
		}

		private Vector3 Transpose(Vector2 relativePosition, Vector3 zeroPoint, Vector3 upperPoint, Vector3 rightPoint)
		{
			return default(Vector3);
		}
	}
}
