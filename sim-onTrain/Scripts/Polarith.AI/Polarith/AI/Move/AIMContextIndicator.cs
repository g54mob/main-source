using System;
using System.Collections.ObjectModel;
using Polarith.AI.Criteria;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[RequireComponent(typeof(AIMContext))]
	public sealed class AIMContextIndicator : MonoBehaviour
	{
		[Tooltip("Specifies the objective that is displayed. The objective corresponds to the AIMContext instance that is attached to the same GameObject.")]
		[SerializeField]
		[TargetObjective(false)]
		private int targetObjective;

		[Tooltip("If true, the decision of the current AI update is displayed. Both, the decided receptor and the (possibly) interpolated DecidedDirection, are shown. The colors DecisionColor and InterpolatedDecisionColor affect the result. Otherwise, the decision information is ignored for the visualization.")]
		[SerializeField]
		private bool displayDecision = true;

		[Tooltip("If true, all directions that violate the constraint in at least one objective are not displayed. Otherwise, the constraints are ignored for the visualization.")]
		[SerializeField]
		private bool filterConstraint;

		[Tooltip("If true, the ShapeScale is calculated automatically based on the Scale and the sensor of the attached AIMContext. Otherwise, the ShapeScale parameter is used.")]
		[SerializeField]
		private bool autoShapeScale = true;

		[Tooltip("Determines the size of the primitive used for displaying an objective value. For IndicatorType.Bar this value can be interpreted as thickness and as the area of the IndicatorType.Splat triangle.")]
		[SerializeField]
		private float shapeScale = 0.25f;

		[Tooltip("The size of the overall visualization for the TargetObjective. Different scales can be used when having more than one instance attached. This way multiple objectives can be displayed at once.")]
		[SerializeField]
		[OpenRangeMin(0f)]
		private float scale = 1f;

		[Tooltip("If true, the current objective value is passed to the alpha channel. Can be used to avoid occluding relevant details. Is especially useful when multiple indicator instances are active at once.")]
		[SerializeField]
		private bool transparent;

		[Tooltip("Defines the style of the visualization. The receptor values corresponding to the TargetObjective are either displayed as a classical bar chart or as 2D circles. Depending on the chosen type further parameters are available for customization: the SplatShape and BarLength. Depending on how you want to analyze the data, both types have their advantages. While the bar chart-like visualization is more reliable for 2D scenarios, the point Splat rendering is more appropriate for 3D sensors, especially if more than one objective is shown.")]
		[SerializeField]
		private IndicatorType indicatorShape;

		[Tooltip("Defines the shape of the splats when IndicatorType is set to IndicatorType.Splat.")]
		[SerializeField]
		private SplatType splatShape;

		[Tooltip("The length of a bar if the objective value is 1. Only applies to IndicatorType.Bar.")]
		[SerializeField]
		private float barLength = 1f;

		[Tooltip("Is assigned to the receptor with the best possible solution for the current AI update. Only used if DisplayDecision is set to true.")]
		[SerializeField]
		private Color decisionColor = Colors.Yellow;

		[Tooltip("The color of the extra shape that is rendered for the AIMContext.DecidedDirection.")]
		[SerializeField]
		private Color interpolatedDecisionColor = Colors.Orange;

		[Tooltip("The colors that are applied to the different objective value representations. If the TargetObjective index exceeds the AIMContext.ObjectiveCount, the colors start to repeat using the modulo operator.")]
		[SerializeField]
		private Color[] objectiveColors = new Color[3]
		{
			Colors.Green,
			Colors.Red,
			Colors.Blue
		};

		private AIMContext context;

		private Sensor sensor;

		private Mesh objectiveMesh;

		private Material objectiveMaterial;

		private Sensor oldSensorReference;

		private int decisionOffset;

		public int TargetObjective
		{
			get
			{
				return targetObjective;
			}
			set
			{
				targetObjective = value;
			}
		}

		public bool DisplayDecision
		{
			get
			{
				return displayDecision;
			}
			set
			{
				decisionOffset = (value ? 1 : 0);
				if (displayDecision != value)
				{
					displayDecision = value;
					BuildMesh();
				}
				displayDecision = value;
			}
		}

		public bool FilterConstraint
		{
			get
			{
				return filterConstraint;
			}
			set
			{
				filterConstraint = value;
			}
		}

		public bool AutoShapeScale
		{
			get
			{
				return autoShapeScale;
			}
			set
			{
				autoShapeScale = value;
			}
		}

		public float ShapeScale
		{
			get
			{
				return shapeScale;
			}
			set
			{
				shapeScale = value;
			}
		}

		public float Scale
		{
			get
			{
				return scale;
			}
			set
			{
				scale = value;
				BuildMesh();
			}
		}

		public bool Transparent
		{
			get
			{
				return transparent;
			}
			set
			{
				transparent = value;
				if (!(objectiveMaterial == null))
				{
					objectiveMaterial.SetInt("_Transparent", (!transparent) ? 1 : 0);
				}
			}
		}

		public IndicatorType IndicatorType
		{
			get
			{
				return indicatorShape;
			}
			set
			{
				if (indicatorShape != value)
				{
					ApplyShader(value);
				}
				indicatorShape = value;
				UpdateSplatParameters();
			}
		}

		public SplatType SplatShape
		{
			get
			{
				return splatShape;
			}
			set
			{
				splatShape = value;
				if (!(objectiveMaterial == null))
				{
					switch (splatShape)
					{
					case SplatType.Circle:
						objectiveMaterial.SetTexture("_MainTex", Textures.Circle16x16);
						break;
					case SplatType.Pentagon:
						objectiveMaterial.SetTexture("_MainTex", Textures.Pentagon16x16);
						break;
					case SplatType.Ring:
						objectiveMaterial.SetTexture("_MainTex", Textures.Ring16x16);
						break;
					}
				}
			}
		}

		public float BarLength
		{
			get
			{
				return barLength;
			}
			set
			{
				barLength = value;
				if (!(objectiveMaterial == null) && IndicatorType == IndicatorType.Bar)
				{
					objectiveMaterial.SetFloat("_Length", BarLength);
				}
			}
		}

		public Color DecisionColor
		{
			get
			{
				return decisionColor;
			}
			set
			{
				decisionColor = value;
			}
		}

		public Color InterpolatedDecisionColor
		{
			get
			{
				return interpolatedDecisionColor;
			}
			set
			{
				interpolatedDecisionColor = value;
			}
		}

		public Color[] ObjectiveColors
		{
			get
			{
				return objectiveColors;
			}
			set
			{
				objectiveColors = value;
			}
		}

		public void BuildMesh()
		{
			if (sensor != null)
			{
				Vector3[] array = new Vector3[sensor.ReceptorCount + decisionOffset];
				Vector3[] array2 = new Vector3[sensor.ReceptorCount + decisionOffset];
				Color[] array3 = new Color[sensor.ReceptorCount + decisionOffset];
				int[] array4 = new int[sensor.ReceptorCount + decisionOffset];
				for (int i = 0; i < sensor.ReceptorCount; i++)
				{
					Structure structure = sensor.GetReceptor(i).Structure;
					array[i] = structure.Position + structure.Direction * scale;
					array2[i] = structure.Direction.normalized;
					array3[i] = FromObjectiveColors();
					array4[i] = i;
				}
				if (displayDecision)
				{
					Structure structure = context.Context.Decision.Structure;
					array[^1] = structure.Position + structure.Direction * scale;
					array2[^1] = structure.Direction.normalized;
					array3[^1] = interpolatedDecisionColor;
					array4[^1] = array4.Length - 1;
				}
				objectiveMesh.Clear();
				objectiveMesh.vertices = array;
				objectiveMesh.normals = array2;
				objectiveMesh.colors = array3;
				objectiveMesh.SetIndices(array4, MeshTopology.Points, 0);
			}
		}

		private void Start()
		{
			context = GetComponent<AIMContext>();
			sensor = context.Sensor.Sensor;
			objectiveMesh = new Mesh();
			if (ApplyShader(indicatorShape))
			{
				decisionOffset = (displayDecision ? 1 : 0);
				objectiveMaterial.SetFloat("_Size", shapeScale);
				BuildMesh();
				ComputeShapeScale();
				UpdateSplatParameters();
				oldSensorReference = sensor;
			}
		}

		private void Update()
		{
			sensor = context.Sensor.Sensor;
			if (HasSensorChanged())
			{
				oldSensorReference = sensor;
				BuildMesh();
				UpdateSplatParameters();
			}
			ComputeShapeScale();
			objectiveMaterial.SetFloat("_Size", shapeScale);
			UpdateMesh();
		}

		private void LateUpdate()
		{
			Graphics.DrawMesh(objectiveMesh, base.transform.localToWorldMatrix, objectiveMaterial, 0);
		}

		private void UpdateMesh()
		{
			Color[] colors = objectiveMesh.colors;
			Color color = FromObjectiveColors();
			ReadOnlyCollection<float> objective = context.Context.Problem.GetObjective(TargetObjective);
			if (colors.Length != sensor.ReceptorCount + decisionOffset || objective.Count != colors.Length - decisionOffset)
			{
				return;
			}
			for (int i = 0; i < sensor.ReceptorCount; i++)
			{
				colors[i] = color * (0.3f + objective[i] * 0.7f);
				colors[i].a = color.a * objective[i];
				colors[i] = CheckConstraints(colors[i], i);
			}
			if (DisplayDecision)
			{
				float num = 1f;
				Structure structure = context.Context.Decision.Structure;
				if (context.Context.Decision.Index < sensor.ReceptorCount)
				{
					colors[context.Context.Decision.Index] = new Color(DecisionColor.r, DecisionColor.g, DecisionColor.b, colors[context.Context.Decision.Index].a);
					if (Vector3.Dot(structure.Direction, sensor.GetReceptor(context.Context.Decision.Index).Structure.Direction.normalized) > 0.99f)
					{
						num = 0f;
					}
				}
				colors[^1] = interpolatedDecisionColor * num;
				Vector3[] vertices = objectiveMesh.vertices;
				Vector3[] normals = objectiveMesh.normals;
				vertices[^1] = structure.Position + structure.Direction * scale;
				normals[^1] = structure.Direction.normalized;
				objectiveMesh.vertices = vertices;
				objectiveMesh.normals = normals;
			}
			objectiveMesh.colors = colors;
		}

		private bool ApplyShader(IndicatorType type)
		{
			Shader shader = Shader.Find((type == IndicatorType.Splat) ? "Polarith/Unlit/Splat" : "Polarith/Unlit/Extrude");
			if (shader == null)
			{
				LogMissingShader();
				base.enabled = false;
				return false;
			}
			objectiveMaterial = new Material(shader);
			if (type == IndicatorType.Splat)
			{
				SplatShape = splatShape;
			}
			if (type == IndicatorType.Bar)
			{
				BarLength = barLength;
			}
			Scale = scale;
			Transparent = transparent;
			return true;
		}

		private void ComputeShapeScale()
		{
			if (AutoShapeScale && sensor != null)
			{
				float num = scale * Mathv.MinElement(base.transform.lossyScale);
				if (sensor is PlanarSensor)
				{
					float num2 = (float)Math.PI * 2f * num;
					float num3 = ((indicatorShape == IndicatorType.Splat) ? 1.25f : 0.3f);
					shapeScale = num2 / (float)sensor.ReceptorCount * num3;
				}
				else
				{
					float num4 = (float)Math.PI * 4f * num * num;
					float num5 = ((indicatorShape == IndicatorType.Splat) ? 1.5f : 0.5f);
					shapeScale = Mathf.Sqrt(num4 / (float)sensor.ReceptorCount) * num5;
				}
			}
		}

		private void UpdateSplatParameters()
		{
			if (indicatorShape != IndicatorType.Bar && sensor != null && !(objectiveMaterial == null))
			{
				objectiveMaterial.SetInt("_Billboard", (sensor is PlanarSensor) ? 1 : 0);
			}
		}

		private bool HasSensorChanged()
		{
			if (!sensor.Equals(oldSensorReference) || sensor.ReceptorCount + decisionOffset != objectiveMesh.vertexCount)
			{
				return true;
			}
			return false;
		}

		private Color FromObjectiveColors()
		{
			return ObjectiveColors[TargetObjective % ObjectiveColors.Length];
		}

		private Color CheckConstraints(Color color, int valueIndex)
		{
			if (filterConstraint)
			{
				IProblem<float> problem = context.Context.Problem;
				for (int i = 1; i < problem.ObjectiveCount; i++)
				{
					if (context.Context.IsObjectiveMinimized(i))
					{
						if (problem.GetValue(i, valueIndex) >= context.GetEpsilonConstraint(i))
						{
							return new Color(0f, 0f, 0f, 0f);
						}
					}
					else if (problem.GetValue(i, valueIndex) <= context.GetEpsilonConstraint(i))
					{
						return new Color(0f, 0f, 0f, 0f);
					}
				}
			}
			return color;
		}

		private void LogMissingShader()
		{
			Debug.LogError("(" + typeof(AIMContextIndicator).Name + ") " + base.gameObject.name + ": At least one of the two necessary Shader files, Extrude.shader or Splat.shader are missing. Try to re-import the Polarith AI Package including the shader files.");
		}
	}
}
