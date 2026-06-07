using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class ProceduralTree : ImmediateModeShapeDrawer
	{
		[Header("Line Style")]
		[Range(0f, 0.1f)]
		public float lineThickness = 0.1f;

		public Color lineColor = Color.white;

		[Header("Tree shape")]
		public int seed;

		[Range(1f, 2000f)]
		public int lineCount = 100;

		[Range(0f, 4f)]
		public int branchesMin = 1;

		[Range(1f, 5f)]
		public int branchesMax = 5;

		[Range(0f, 1f)]
		public float branchLengthMin = 0.25f;

		[Range(0f, 1f)]
		public float branchLengthMax = 1f;

		[Range(0f, MathF.PI)]
		public float maxAngDeviation = MathF.PI / 3f;

		public bool use3D;

		private int currentLineCount;

		private readonly Queue<Matrix4x4> mtxQueue = new Queue<Matrix4x4>();

		public override void DrawShapes(Camera cam)
		{
			using (Draw.Command(cam))
			{
				Draw.ResetAllDrawStates();
				Draw.BlendMode = ShapesBlendMode.Additive;
				Draw.Thickness = lineThickness;
				Draw.LineGeometry = (use3D ? LineGeometry.Volumetric3D : LineGeometry.Flat2D);
				Draw.ThicknessSpace = ThicknessSpace.Meters;
				Draw.Color = lineColor;
				UnityEngine.Random.InitState(seed);
				currentLineCount = 0;
				BranchFrom(Draw.Matrix);
			}
		}

		private void BranchFrom(Matrix4x4 mtx)
		{
			if (currentLineCount++ >= lineCount)
			{
				return;
			}
			Draw.Matrix = mtx;
			float y = Mathf.Lerp(branchLengthMin, branchLengthMax, UnityEngine.Random.value);
			Vector3 vector = new Vector3(0f, y, 0f);
			Draw.Line(Vector3.zero, vector);
			Draw.Translate(vector);
			int num = UnityEngine.Random.Range(branchesMin, branchesMax + 1);
			for (int i = 0; i < num; i++)
			{
				using (Draw.MatrixScope)
				{
					float angle = Mathf.Lerp(0f - maxAngDeviation, maxAngDeviation, ShapesMath.RandomGaussian());
					if (use3D)
					{
						Draw.Rotate(angle, ShapesMath.GetRandomPerpendicularVector(Vector3.up));
					}
					else
					{
						Draw.Rotate(angle);
					}
					mtxQueue.Enqueue(Draw.Matrix);
				}
			}
			while (mtxQueue.Count > 0)
			{
				BranchFrom(mtxQueue.Dequeue());
			}
		}
	}
}
