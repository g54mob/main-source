using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	[Serializable]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	public class TransformationType
	{
		private float rotationField;

		private PointType pivotField;

		private PointType xAxisField;

		private PointType yAxisField;

		private PointType translationField;

		private string transformMatrixField;

		private RectangleType boundsField;

		public float Rotation
		{
			get
			{
				return rotationField;
			}
			set
			{
				rotationField = value;
			}
		}

		public PointType Pivot
		{
			get
			{
				return pivotField;
			}
			set
			{
				pivotField = value;
			}
		}

		public PointType XAxis
		{
			get
			{
				return xAxisField;
			}
			set
			{
				xAxisField = value;
			}
		}

		public PointType YAxis
		{
			get
			{
				return yAxisField;
			}
			set
			{
				yAxisField = value;
			}
		}

		public PointType Translation
		{
			get
			{
				return translationField;
			}
			set
			{
				translationField = value;
			}
		}

		public string TransformMatrix
		{
			get
			{
				return transformMatrixField;
			}
			set
			{
				transformMatrixField = value;
			}
		}

		public RectangleType Bounds
		{
			get
			{
				return boundsField;
			}
			set
			{
				boundsField = value;
			}
		}
	}
}
