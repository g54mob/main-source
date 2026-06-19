using System;
using System.Collections.Generic;
using ClipperLib;
using UnityEngine;

namespace SimplySVG
{
	[Serializable]
	public abstract class GraphicalElement : SVGElement, SVGStylable, SVGTransformable
	{
		private delegate void PolyTreeRecurse(PolyNode node);

		[Serializable]
		public class ContourPath
		{
			public bool closed;

			public List<Vector2> path;

			public List<IntPoint> clipperPath;

			public ContourPath(bool closed = false, List<Vector2> path = null)
			{
				this.closed = closed;
				if (path == null)
				{
					this.path = new List<Vector2>();
				}
				else
				{
					this.path = path;
				}
			}

			public void PopulateClipperPath()
			{
				clipperPath = new List<IntPoint>(path.Count);
				for (int i = 0; i < path.Count; i++)
				{
					clipperPath.Add(ImportUtilities.ConvertToScaledClipperPoint(path[i]));
				}
			}
		}

		public static readonly double clipperCoordinateScale = 8192.0;

		protected GraphicalAttributes localGraphicalAttributes;

		protected TransformAttributes localTransformAttributes;

		private List<ContourPath> contourPaths;

		public PolyTree stencilTree;

		public PolyTree fillTree;

		public PolyTree openStrokeTree;

		public PolyTree closedStrokeTree;

		public GraphicalElement()
		{
			localGraphicalAttributes = new GraphicalAttributes();
			localTransformAttributes = new TransformAttributes();
		}

		public override bool AddAttribute(string attributeName, string attributeValue)
		{
			if (!base.AddAttribute(attributeName, attributeValue) && !AddShapeAttribute(attributeName, attributeValue) && !AddStyleAttribute(attributeName, attributeValue))
			{
				return AddTransformAttribute(attributeName, attributeValue);
			}
			return true;
		}

		public bool AddStyleAttribute(string attributeName, string attributeValue)
		{
			return localGraphicalAttributes.AddAttribute(attributeName, attributeValue);
		}

		public bool AddTransformAttribute(string attributeName, string attributeValue)
		{
			return localTransformAttributes.AddAttribute(attributeName, attributeValue);
		}

		public abstract bool AddShapeAttribute(string attributeName, string attributeValue);

		protected abstract List<ContourPath> BuildShape(ImportSettings options);

		protected bool BuildCountour(ImportSettings options)
		{
			contourPaths = BuildShape(options);
			if (contourPaths == null)
			{
				return false;
			}
			for (int i = 0; i < contourPaths.Count; i++)
			{
				contourPaths[i].PopulateClipperPath();
			}
			return true;
		}

		public bool BuildStencil(CascadeContext cascadeContext, ImportSettings options)
		{
			if (!BuildCountour(options))
			{
				return false;
			}
			if (!TriangulationUtility.ClipFill(contourPaths, cascadeContext.graphicalAttributes.clipRule.Value, out stencilTree))
			{
				return false;
			}
			ApplyTransformation(stencilTree, cascadeContext.transformAttributes.combinedTransform);
			return true;
		}

		public bool ClipShape(CascadeContext cascadeContext, ImportSettings options)
		{
			if (!BuildCountour(options))
			{
				return false;
			}
			if (cascadeContext.graphicalAttributes.useFill.HasValue && cascadeContext.graphicalAttributes.useFill.Value && !TriangulationUtility.ClipFill(contourPaths, cascadeContext.graphicalAttributes.fillRule.Value, out fillTree))
			{
				return false;
			}
			if (cascadeContext.graphicalAttributes.useStroke.HasValue && cascadeContext.graphicalAttributes.useStroke.Value && !TriangulationUtility.ClipStroke(contourPaths, cascadeContext.graphicalAttributes.fillRule.Value, cascadeContext.graphicalAttributes.strokeWidth.Value, cascadeContext.graphicalAttributes.strokeMiterLimit.Value, out openStrokeTree, out closedStrokeTree))
			{
				return false;
			}
			ApplyTransformation(fillTree, cascadeContext.transformAttributes.combinedTransform);
			ApplyTransformation(closedStrokeTree, cascadeContext.transformAttributes.combinedTransform);
			ApplyTransformation(openStrokeTree, cascadeContext.transformAttributes.combinedTransform);
			return true;
		}

		public override bool Triangulate(CascadeContext parentCascadeContext, ImportSettings options, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			CascadeContext cascadeContext = parentCascadeContext.GatherElement(this);
			if (!ClipShape(cascadeContext, options))
			{
				if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
				{
					Debug.LogError("Shape (" + (string.IsNullOrEmpty(id) ? "no ID set" : ("ID: " + id)) + ") contour building failed");
				}
				return false;
			}
			if (cascadeContext.clipStencil != null)
			{
				if (fillTree != null)
				{
					TriangulationUtility.ClipStencil(fillTree, cascadeContext.clipStencil, out fillTree);
				}
				if (closedStrokeTree != null)
				{
					TriangulationUtility.ClipStencil(closedStrokeTree, cascadeContext.clipStencil, out closedStrokeTree);
				}
				if (openStrokeTree != null)
				{
					TriangulationUtility.ClipStencil(openStrokeTree, cascadeContext.clipStencil, out openStrokeTree);
				}
			}
			Color value = cascadeContext.graphicalAttributes.fillColor.Value;
			value.a = cascadeContext.graphicalAttributes.fillOpacity.Value * cascadeContext.graphicalAttributes.opacity.Value;
			Color value2 = cascadeContext.graphicalAttributes.strokeColor.Value;
			value2.a = cascadeContext.graphicalAttributes.strokeOpacity.Value * cascadeContext.graphicalAttributes.opacity.Value;
			if (fillTree != null && fillTree.Total > 0 && !TriangulationUtility.TriangulatePolyTree(fillTree, value, ref meshVertices, ref meshTriangles, ref meshVertexColors))
			{
				if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
				{
					Debug.LogError("Triangulating shape (" + (string.IsNullOrEmpty(id) ? "no ID set" : ("ID: " + id)) + ") fill failed");
				}
				return false;
			}
			if (closedStrokeTree != null && closedStrokeTree.Total > 0 && !TriangulationUtility.TriangulatePolyTree(closedStrokeTree, value2, ref meshVertices, ref meshTriangles, ref meshVertexColors))
			{
				if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
				{
					Debug.LogError("Triangulating shape (" + (string.IsNullOrEmpty(id) ? "no ID set" : ("ID: " + id)) + ") closed stroke failed");
				}
				return false;
			}
			if (openStrokeTree != null && openStrokeTree.Total > 0 && !TriangulationUtility.TriangulatePolyTree(openStrokeTree, value2, ref meshVertices, ref meshTriangles, ref meshVertexColors))
			{
				if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
				{
					Debug.LogError("Triangulating shape (" + (string.IsNullOrEmpty(id) ? "no ID set" : ("ID: " + id)) + ") open stroke failed");
				}
				return false;
			}
			return true;
		}

		public GraphicalAttributes GetLocalAttributes()
		{
			return localGraphicalAttributes;
		}

		public TransformAttributes GetLocalTransformation()
		{
			return localTransformAttributes;
		}

		private void ApplyTransformation(PolyTree shapes, Matrix transformation)
		{
			if (shapes == null || shapes.Total == 0 || shapes.ChildCount == 0)
			{
				return;
			}
			PolyTreeRecurse recurse = null;
			recurse = delegate(PolyNode node)
			{
				List<IntPoint> contour = node.Contour;
				for (int i = 0; i < contour.Count; i++)
				{
					contour[i] = MatrixUtils.MultiplyScaledClipperPoint(transformation, contour[i]);
				}
				List<PolyNode> childs = node.Childs;
				for (int j = 0; j < childs.Count; j++)
				{
					recurse(childs[j]);
				}
			};
			recurse(shapes);
		}
	}
}
