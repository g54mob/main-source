using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Polarith.AI.Criteria;
using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/System/AIM Context")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-context.html")]
	[DisallowMultipleComponent]
	public sealed class AIMContext : MonoBehaviour
	{
		[Serializable]
		private sealed class IndicatorGizmo
		{
			[Tooltip("If 'true', the indicator gizmo is visible.")]
			public bool Enabled;

			[Tooltip("If 'true', the wire-frame mode is active. This is only important if the 'ResolutionThreshold' is lesser than the sensor's receptor count.")]
			public bool Wireframe;

			[Tooltip("If 'true', the receptors of the sensor are visualized.")]
			public bool ShowReceptors;

			[Tooltip("If 'true', the constraints defined in context are visible.")]
			public bool ShowConstraints;

			[Tooltip("If 'true', the non-wire-frame version of the indicator is drawn double-sided.")]
			public bool DrawDoubleSided = true;

			[Tooltip("If the sensor receptor count is below this value, a simple visualization with lines is used. If the receptor count is greater than this value, a more complex visualization (mesh) is applied, which is also depending on 'Wire-frame' and 'DrawDoubleSided'.")]
			public int ResolutionThreshold = 32;

			[Tooltip("Determines how large each objective visualization is.")]
			public float CustomScale = 1f;

			[Tooltip("Sets the space between two objective visualizations.")]
			[OpenRangeMin(1f)]
			public float Spacing = 1f;

			[Tooltip("The color of the solution.")]
			public Color SolutionColor = Colors.Yellow;

			[Tooltip("The color of the interpolated solution.")]
			public Color InterpolatedSolutionColor = Colors.Orange;

			[Tooltip("The color of the lines representing the constraints.")]
			public Color ConstraintColor = Colors.Yellow;

			[Tooltip("The color of the lines representing the receptor's.")]
			public Color ReceptorColor = Colors.Grey;

			[Tooltip("The color of the lines representing the neighbourhood of the receptors.")]
			public Color LineColor = Colors.Grey;

			[Tooltip("The colors for each objective. If there are more objectives than colors, the colors are repeated.")]
			public Color[] ObjectiveColors = new Color[3]
			{
				Colors.Green,
				Colors.Red,
				Colors.Blue
			};

			[NonSerialized]
			public Context Context;

			[NonSerialized]
			public Mesh[] Meshes;

			[NonSerialized]
			public float[] NormalizationValues;

			[NonSerialized]
			public float[] NormalizationOffsets;

			[NonSerialized]
			public ISensor<Structure> Sensor;

			[NonSerialized]
			public Vector3 Position;

			[NonSerialized]
			public Quaternion Rotation;

			[NonSerialized]
			public Vector3 Scale = new Vector3(1f, 1f, 1f);

			[NonSerialized]
			public bool ContextEvaluated;

			[NonSerialized]
			public bool Drawn;

			private ReadOnlyCollection<float>[] contextData = new ReadOnlyCollection<float>[0];

			private Vector3 scaledDirection;

			public void Initialize(Context context, int objectiveCount)
			{
				Context = context;
				if (ObjectiveColors.Length == 0)
				{
					ObjectiveColors = new Color[3];
					ObjectiveColors[0] = Colors.Green;
					ObjectiveColors[1] = Colors.Red;
					ObjectiveColors[2] = Colors.Blue;
				}
				Meshes = new Mesh[objectiveCount * 2];
				for (int i = 0; i < Context.Problem.ObjectiveCount * 2; i++)
				{
					Meshes[i] = new Mesh();
				}
				NormalizationValues = new float[Context.Problem.ObjectiveCount];
				for (int j = 0; j < Context.Problem.ObjectiveCount; j++)
				{
					NormalizationValues[j] = 1f;
				}
				NormalizationOffsets = new float[Context.Problem.ObjectiveCount];
				for (int k = 0; k < Context.Problem.ObjectiveCount; k++)
				{
					NormalizationOffsets[k] = 0f;
				}
				Sensor = Context.Sensor;
			}

			public void ReadData()
			{
				if (contextData.Length != Context.Problem.ObjectiveCount)
				{
					contextData = new ReadOnlyCollection<float>[Context.Problem.ObjectiveCount];
				}
				if (ContextEvaluated)
				{
					for (int i = 0; i < Context.Problem.ObjectiveCount; i++)
					{
						contextData[i] = Context.Problem.GetObjective(i);
					}
				}
			}

			public void DefaultVis()
			{
				ReadData();
				if (contextData == null)
				{
					return;
				}
				for (int i = 0; i < Context.Problem.ObjectiveCount; i++)
				{
					ReadOnlyCollection<float> readOnlyCollection = contextData[i];
					if (readOnlyCollection != null && readOnlyCollection.Count == Sensor.ReceptorCount)
					{
						Gizmos.color = ObjectiveColors[i % ObjectiveColors.Length];
						for (int j = 0; j < Sensor.ReceptorCount; j++)
						{
							IReceptor<Structure> receptor = Sensor.GetReceptor(j);
							Gizmos.DrawLine(CalculatePosition(receptor.Structure, i, 0f), CalculatePosition(receptor.Structure, i, (readOnlyCollection[j] - NormalizationOffsets[i]) / NormalizationValues[i]));
						}
					}
				}
				ContextEvaluated = false;
			}

			public void SimpleVis()
			{
				ReadData();
				if (contextData == null)
				{
					return;
				}
				for (int i = 0; i < Context.Problem.ObjectiveCount; i++)
				{
					ReadOnlyCollection<float> readOnlyCollection = contextData[i];
					if (readOnlyCollection == null || readOnlyCollection.Count != Sensor.ReceptorCount)
					{
						continue;
					}
					Gizmos.color = ObjectiveColors[i % ObjectiveColors.Length];
					int num = 0;
					int num2 = -1;
					while (num < Sensor.ReceptorCount)
					{
						IReceptor<Structure> receptor = Sensor.GetReceptor(num);
						num++;
						num2 = receptor.NeighbourIDs[1];
						if (num2 < 0)
						{
							Gizmos.DrawLine(CalculatePosition(receptor.Structure, i, (readOnlyCollection[num - 1] - NormalizationOffsets[i]) / NormalizationValues[i]), CalculatePosition(receptor.Structure, i, 0f));
							continue;
						}
						if (receptor.NeighbourIDs[0] < 0)
						{
							Gizmos.DrawLine(CalculatePosition(receptor.Structure, i, (readOnlyCollection[num - 1] - NormalizationOffsets[i]) / NormalizationValues[i]), CalculatePosition(receptor.Structure, i, 0f));
						}
						IReceptor<Structure> receptor2 = Sensor.GetReceptor(num2);
						Gizmos.DrawLine(CalculatePosition(receptor.Structure, i, (readOnlyCollection[num - 1] - NormalizationOffsets[i]) / NormalizationValues[i]), CalculatePosition(receptor2.Structure, i, (readOnlyCollection[num2] - NormalizationOffsets[i]) / NormalizationValues[i]));
					}
				}
			}

			public void SimpleVisMesh(GameObject gameObject)
			{
				ReadData();
				if (contextData == null)
				{
					return;
				}
				for (int i = 0; i < Context.Problem.ObjectiveCount; i++)
				{
					ReadOnlyCollection<float> readOnlyCollection = contextData[i];
					if (readOnlyCollection != null && readOnlyCollection.Count == Sensor.ReceptorCount)
					{
						List<Vector3> list = new List<Vector3>();
						List<Vector3> list2 = new List<Vector3>();
						int[] array = new int[Context.Problem.ValueCount * 3 * 2];
						CreateMeshData(readOnlyCollection, i, list, list2, array, doubleSided: false);
						Meshes[i].vertices = list.ToArray();
						Meshes[i].normals = list2.ToArray();
						Meshes[i].triangles = array;
						Gizmos.color = ObjectiveColors[i % ObjectiveColors.Length];
						Gizmos.DrawMesh(Meshes[i], gameObject.transform.position, gameObject.transform.rotation);
						if (DrawDoubleSided)
						{
							List<Vector3> list3 = new List<Vector3>();
							List<Vector3> list4 = new List<Vector3>();
							int[] array2 = new int[Context.Problem.ValueCount * 3 * 2];
							CreateMeshData(readOnlyCollection, i, list3, list4, array2, doubleSided: true);
							Meshes[i + Context.Problem.ObjectiveCount].vertices = list3.ToArray();
							Meshes[i + Context.Problem.ObjectiveCount].normals = list4.ToArray();
							Meshes[i + Context.Problem.ObjectiveCount].triangles = array2;
							Gizmos.color = ObjectiveColors[i % ObjectiveColors.Length];
							Gizmos.DrawMesh(Meshes[i + Context.Problem.ObjectiveCount], gameObject.transform.position, gameObject.transform.rotation);
						}
					}
				}
			}

			public void CreateMeshData(ReadOnlyCollection<float> data, int objective, List<Vector3> positions, List<Vector3> normals, int[] indices, bool doubleSided)
			{
				int num = 0;
				if (doubleSided)
				{
					num = 2;
				}
				for (int i = 0; i < Sensor.ReceptorCount; i++)
				{
					IReceptor<Structure> receptor = Sensor.GetReceptor(i);
					scaledDirection = receptor.Structure.Direction;
					scaledDirection.x *= Scale.x;
					scaledDirection.y *= Scale.y;
					scaledDirection.z *= Scale.z;
					positions.Add(receptor.Structure.Position + scaledDirection * objective * Spacing + scaledDirection * Spacing);
					positions.Add(receptor.Structure.Position + scaledDirection * objective * Spacing + scaledDirection * Spacing + scaledDirection * ((data[i] - NormalizationOffsets[objective]) / NormalizationValues[objective]));
					if (receptor.NeighbourIDs[1] < 0)
					{
						indices[i * 6] = i * 2;
						indices[i * 6 + 1] = i * 2;
						indices[i * 6 + 2] = i * 2;
						indices[i * 6 + 3] = i * 2;
						indices[i * 6 + 4] = i * 2;
						indices[i * 6 + 5] = i * 2;
					}
					else
					{
						indices[i * 6] = i * 2;
						indices[i * 6 + 1] = i * 2 + (3 + num) % 4;
						indices[i * 6 + 2] = i * 2 + 1 + num;
						indices[i * 6 + 3] = i * 2 + 3;
						indices[i * 6 + 4] = i * 2 + num;
						indices[i * 6 + 5] = i * 2 + (2 + num) % 4;
					}
				}
				for (int j = 0; j < indices.Length; j++)
				{
					indices[j] %= positions.Count;
				}
				for (int k = 0; k < positions.Count; k++)
				{
					if (doubleSided)
					{
						normals.Add(new Vector3(0f, 0f, -1f));
					}
					else
					{
						normals.Add(new Vector3(0f, 0f, 1f));
					}
				}
			}

			public void DrawSolutions()
			{
				int index = Context.Decision.Index;
				if (index > Sensor.ReceptorCount)
				{
					return;
				}
				Gizmos.color = SolutionColor;
				Vector3 direction = Sensor.GetReceptor(index).Structure.Direction;
				direction.x *= Scale.x;
				direction.y *= Scale.y;
				direction.z *= Scale.z;
				Gizmos.DrawLine(Position + Rotation * Sensor.GetReceptor(index).Structure.Position, Position + Rotation * (Sensor.GetReceptor(index).Structure.Position + direction * Spacing));
				Gizmos.color = InterpolatedSolutionColor;
				direction = Context.Decision.Structure.Direction;
				direction.x *= Scale.x;
				direction.y *= Scale.y;
				direction.z *= Scale.z;
				Gizmos.DrawLine(Position + Rotation * Context.Decision.Structure.Position, Position + Rotation * (Context.Decision.Structure.Position + direction * Spacing));
				ReadData();
				if (contextData == null)
				{
					return;
				}
				for (int i = 0; i < Context.Problem.ObjectiveCount; i++)
				{
					if (contextData[i] != null)
					{
						Gizmos.color = SolutionColor;
						Gizmos.DrawLine(CalculatePosition(Sensor.GetReceptor(index).Structure, i, 0f), CalculatePosition(Sensor.GetReceptor(index).Structure, i, (contextData[i][index] - NormalizationOffsets[i]) / NormalizationValues[i]));
						if (i < Context.Decision.Values.Count)
						{
							Gizmos.color = InterpolatedSolutionColor;
							Gizmos.DrawLine(CalculatePosition(Context.Decision.Structure, i, 0f), CalculatePosition(Context.Decision.Structure, i, (Context.Decision.Values[i] - NormalizationOffsets[i]) / NormalizationValues[i]));
						}
					}
				}
			}

			public void DrawConstraints()
			{
				Gizmos.color = ConstraintColor;
				if (!(Context.Solver is ConstraintSolver constraintSolver))
				{
					return;
				}
				for (int i = 1; i < Context.Problem.ObjectiveCount; i++)
				{
					int j = 0;
					int num = 0;
					int num2 = -1;
					for (; j < Sensor.ReceptorCount; j++)
					{
						IReceptor<Structure> receptor = Sensor.GetReceptor(num);
						num2 = receptor.NeighbourIDs[1];
						if (num2 < 0)
						{
							break;
						}
						IReceptor<Structure> receptor2 = Sensor.GetReceptor(num2);
						Gizmos.DrawLine(CalculatePosition(receptor.Structure, i, constraintSolver.Epsilons[i]), CalculatePosition(receptor2.Structure, i, constraintSolver.Epsilons[i]));
						num = receptor.NeighbourIDs[1];
						if (num < 0)
						{
							break;
						}
					}
				}
			}

			public void DrawReceptors()
			{
				Gizmos.color = ReceptorColor;
				for (int i = 0; i < Sensor.ReceptorCount; i++)
				{
					scaledDirection = Sensor.GetReceptor(i).Structure.Direction;
					scaledDirection.x *= Scale.x;
					scaledDirection.y *= Scale.y;
					scaledDirection.z *= Scale.z;
					Gizmos.DrawLine(Position + Rotation * Sensor.GetReceptor(i).Structure.Position, Position + Rotation * (Sensor.GetReceptor(i).Structure.Position + scaledDirection * Spacing * Sensor.GetReceptor(i).Structure.Magnitude));
				}
			}

			public void CaluculateNormalizedValues()
			{
				ReadData();
				if (contextData == null)
				{
					return;
				}
				for (int i = 0; i < Context.Problem.ObjectiveCount; i++)
				{
					if (contextData[i] != null)
					{
						for (int j = 0; j < contextData[i].Count; j++)
						{
							NormalizationOffsets[i] = ((contextData[i][j] < NormalizationOffsets[i]) ? contextData[i][j] : NormalizationOffsets[i]);
						}
						if (NormalizationOffsets[i] >= 0f)
						{
							NormalizationOffsets[i] = 0f;
						}
						for (int k = 0; k < contextData[i].Count; k++)
						{
							NormalizationValues[i] = ((contextData[i][k] - NormalizationOffsets[i] > NormalizationValues[i]) ? (contextData[i][k] - NormalizationOffsets[i]) : NormalizationValues[i]);
						}
						if (NormalizationValues[i] < 1f)
						{
							NormalizationValues[i] = 1f;
						}
					}
				}
			}

			public Vector3 CalculatePosition(Structure struc, int idx, float dataValue)
			{
				scaledDirection = struc.Direction;
				scaledDirection.x *= Scale.x;
				scaledDirection.y *= Scale.y;
				scaledDirection.z *= Scale.z;
				return Position + Rotation * (struc.Position + scaledDirection * idx * Spacing + scaledDirection * Spacing + scaledDirection * dataValue);
			}
		}

		public readonly IList<IEvaluationPreparer> EvaluationPreparers = new List<IEvaluationPreparer>();

		public readonly IList<AIMBehaviour> Behaviours = new List<AIMBehaviour>();

		[Tooltip("Specifies how often the AI system should update this agent per second. If set to 0, the agent gets updated within Unity's update method, as against if greater than 0, it uses its own coroutine for updating.")]
		[Range(0f, 1000f)]
		public float UpdateFrequency = 20f;

		[Tooltip("Specifies if this movement AI context should be evaluated in parallel to other existing agents. This does only function if this 'AIM Context' is 'Thread Safe' and if there is an 'AIM Performance' component (Pro only) within the scene to handle the multithreading properly.")]
		public bool Threaded;

		[Tooltip("If set to 'false', this agent clones the associated 'Sensor' on start so that it can safely be manipulated at runtime without disturbing other agents having the same sensor specified in its inspector. If it is cloned, this only concerns the back-end classes.")]
		public bool SensorShared = true;

		[Tooltip("The currently used sensor asset which determines how this agent observes the world.")]
		public AIMSensor Sensor;

		[NonSerialized]
		public bool BehaviourSortRequired = true;

		[NonSerialized]
		public bool ThreadSafetyCheckRequired = true;

		[SerializeField]
		private List<string> objectiveLabels = new List<string>();

		private static readonly List<AIMContext> threadedComponents = new List<AIMContext>();

		private static readonly List<AIMContext> nonThreadedComponents = new List<AIMContext>();

		private static readonly List<Context> threadedContexts = new List<Context>();

		private readonly List<float> decidedValues = new List<float>();

		private Vector3 decidedDirection;

		private Vector3 localDecidedDirection;

		private Vector3 decidedReceptorPosition;

		private Vector3 localDecidedReceptorPosition;

		private WaitForSeconds waitForSeconds;

		private float oldUpdateFrequency = float.PositiveInfinity;

		private float decidedMagnitude;

		private float decidedReceptorSensitivity;

		private int i;

		private bool wasThreaded;

		private bool wasSensorShared;

		private bool threadSafe;

		private bool wasThreadSafe;

		private bool updateRoutineRunning;

		private bool routineAbort;

		[Tooltip("Specifies general movement AI settings.")]
		[SerializeField]
		[HideInInspector]
		private Context context = new Context();

		[Tooltip("Can be used to receive the self percept data of this agent. This should be the object having a rigidbody and maybe a perception tag etc. attached to it. The self percept data is used by every behaviour and the perception pipeline.\n\nIf no object is set, the game object of this component is considered as self object.")]
		[SerializeField]
		private GameObject selfObject;

		[Tooltip("Specifies settings for the visualization of the sampled objective data.")]
		[SerializeField]
		private IndicatorGizmo indicatorGizmo = new IndicatorGizmo();

		[SerializeField]
		[HideInInspector]
		private TabState tabState;

		[SerializeField]
		[HideInInspector]
		private bool objectiveFoldout = true;

		public static ReadOnlyCollection<AIMContext> ThreadedComponents => threadedComponents.AsReadOnly();

		public static ReadOnlyCollection<AIMContext> NonThreadedComponents => nonThreadedComponents.AsReadOnly();

		public static ReadOnlyCollection<Context> ThreadedContexts => threadedContexts.AsReadOnly();

		public Context Context => context;

		public int ObjectiveCount => context.Problem.ObjectiveCount;

		public int ValueCount => context.Problem.ValueCount;

		public IList<float> DecidedValues => decidedValues;

		public Vector3 DecidedDirection => decidedDirection;

		public Vector3 LocalDecidedDirection => localDecidedDirection;

		public float DecidedMagnitude => decidedMagnitude;

		public Vector3 DecidedReceptorPosition => decidedReceptorPosition;

		public Vector3 LocalDecidedReceptorPosition => localDecidedReceptorPosition;

		public float DecidedReceptorSensitivity => decidedReceptorSensitivity;

		public bool ThreadSafe => threadSafe;

		public GameObject SelfObject
		{
			get
			{
				if (!(selfObject == null))
				{
					return selfObject;
				}
				return base.gameObject;
			}
			set
			{
				selfObject = value;
			}
		}

		public List<string> ObjectiveLabels => objectiveLabels;

		public void BuildContext()
		{
			context.BuildContext();
			if (Sensor != null)
			{
				if (SensorShared)
				{
					context.Sensor = Sensor.Sensor;
				}
				else
				{
					context.Sensor = Sensor.Sensor.Clone;
				}
				if (context.Problem.ObjectiveCount > 0)
				{
					ResizeObjectives(Sensor.Sensor.ReceptorCount);
				}
				indicatorGizmo.Initialize(context, context.Problem.ObjectiveCount);
			}
			Collections.ResizeList(decidedValues, context.Decision.Values.Count);
		}

		public void Evaluate()
		{
			PrepareEvaluation();
			context.Evaluate();
			ObtainEvaluatedResults();
			UpdateIndicator();
		}

		public void PrepareEvaluation()
		{
			if (wasSensorShared && !SensorShared)
			{
				context.Sensor = Sensor.Sensor.Clone;
			}
			else if (SensorShared && Sensor != null)
			{
				context.Sensor = Sensor.Sensor;
			}
			else if (Sensor == null)
			{
				Debug.LogError("(" + typeof(AIMContext).Name + ") " + base.gameObject.name + ": no valid sensor set up");
			}
			wasSensorShared = SensorShared;
			context.LocalToWorldMatrix = base.transform.localToWorldMatrix;
			context.WorldToLocalMatrix = base.transform.worldToLocalMatrix;
			context.DeltaTime = Time.deltaTime;
			for (i = 0; i < EvaluationPreparers.Count; i++)
			{
				if (EvaluationPreparers[i].Enabled)
				{
					EvaluationPreparers[i].PrepareEvaluation();
				}
			}
			if (BehaviourSortRequired)
			{
				IList<AIMBehaviour> list = Behaviours.OrderBy((AIMBehaviour b) => b.Order).ToList();
				for (i = 0; i < list.Count; i++)
				{
					Behaviours[i] = list[i];
					context.Behaviours[i] = list[i].Behaviour;
				}
				BehaviourSortRequired = false;
			}
		}

		public void ObtainEvaluatedResults()
		{
			Collections.ResizeList(decidedValues, context.Decision.Values.Count);
			for (i = 0; i < decidedValues.Count; i++)
			{
				decidedValues[i] = context.Decision.Values[i];
			}
			decidedDirection = context.DecidedDirection;
			localDecidedDirection = context.Decision.Structure.Direction;
			decidedMagnitude = context.Decision.Structure.Magnitude;
			decidedReceptorPosition = context.DecidedReceptorPosition;
			localDecidedReceptorPosition = context.Decision.Structure.Position;
			decidedReceptorSensitivity = context.Decision.Structure.Sensitivity;
		}

		public ReadOnlyCollection<float> AddObjective(bool minimized, bool normalized, float constraint = 0f, bool unlimited = false)
		{
			objectiveLabels.Add("Objective # " + ObjectiveCount);
			ReadOnlyCollection<float> result = context.Problem.AddObjective(minimized);
			context.SetObjectiveNormalized(context.Problem.ObjectiveCount - 1, normalized);
			context.SetObjectiveMinimized(context.Problem.ObjectiveCount - 1, minimized);
			context.SetEpsilonConstraint(context.Problem.ObjectiveCount - 1, constraint);
			if (unlimited)
			{
				context.SetObjectiveUnlimited(context.Problem.ObjectiveCount - 1);
			}
			return result;
		}

		public void AddValues(float value)
		{
			context.Problem.AddValues(value);
		}

		public void AddValues(float[] values)
		{
			context.Problem.AddValues(values);
		}

		public ReadOnlyCollection<float> GetObjective(int index)
		{
			return context.Problem.GetObjective(index);
		}

		public float GetValue(int objectiveIndex, int valueIndex)
		{
			return context.Problem.GetValue(objectiveIndex, valueIndex);
		}

		public float GetEpsilonConstraint(int index)
		{
			return context.GetEpsilonConstraint(index);
		}

		public bool IsObjectiveMinimized(int index)
		{
			return context.Problem.IsObjectiveMinimized(index);
		}

		public bool IsObjectiveNormalized(int index)
		{
			return context.IsObjectiveNormalized(index);
		}

		public bool IsObjectiveUnlimited(int index)
		{
			return context.IsObjectiveUnlimited(index);
		}

		public void SetValue(int objectiveIndex, int valueIndex, float value)
		{
			context.Problem.SetValue(objectiveIndex, valueIndex, value);
		}

		public void SetEpsilonConstraint(int index, float value)
		{
			context.SetEpsilonConstraint(index, value);
		}

		public void SetObjectiveMinimized(int index, bool minimized)
		{
			context.SetObjectiveMinimized(index, minimized);
		}

		public void SetObjectiveNormalized(int index, bool normalized)
		{
			context.SetObjectiveNormalized(index, normalized);
		}

		public void SetObjectiveUnlimited(int index)
		{
			context.SetObjectiveUnlimited(index);
		}

		public void ResetValues()
		{
			context.Problem.ResetValues();
		}

		public void RemoveObjectiveAt(int index)
		{
			context.Problem.RemoveObjectiveAt(index);
			objectiveLabels.RemoveAt(index);
		}

		public void RemoveValuesAt(int index)
		{
			context.Problem.RemoveValuesAt(index);
		}

		public void ResizeObjectives(int valueCount)
		{
			if (context.Problem.ObjectiveCount == 0)
			{
				Debug.LogWarning("(" + typeof(AIMContext).Name + ") " + base.gameObject.name + ": cannot resize objectives (value count) because there are no objectives");
			}
			context.Problem.ResizeObjectives(valueCount);
		}

		public void ClearAgent()
		{
			AIMBehaviour[] components = GetComponents<AIMBehaviour>();
			AIMSteeringFilter[] components2 = GetComponents<AIMSteeringFilter>();
			AIMSteeringTag[] components3 = GetComponents<AIMSteeringTag>();
			AIMBehaviour[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(array[i]);
			}
			AIMSteeringFilter[] array2 = components2;
			for (int i = 0; i < array2.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(array2[i]);
			}
			AIMSteeringTag[] array3 = components3;
			for (int i = 0; i < array3.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(array3[i]);
			}
			Reset();
		}

		public void ClearObjectives()
		{
			context.ClearObjectives();
			objectiveLabels.Clear();
		}

		public void ClearValues()
		{
			context.ClearValues();
		}

		public void UpdateIndicator()
		{
			indicatorGizmo.ContextEvaluated = true;
		}

		public void Reset()
		{
			EvaluationPreparers.Clear();
			Behaviours.Clear();
			UpdateFrequency = 20f;
			Threaded = false;
			SensorShared = true;
			Sensor = null;
			BehaviourSortRequired = true;
			ThreadSafetyCheckRequired = true;
			objectiveLabels.Clear();
			decidedValues.Clear();
			decidedDirection = default(Vector3);
			localDecidedDirection = default(Vector3);
			decidedReceptorPosition = default(Vector3);
			localDecidedReceptorPosition = default(Vector3);
			decidedMagnitude = 0f;
			decidedReceptorSensitivity = 0f;
			i = 0;
			wasThreaded = false;
			wasSensorShared = false;
			threadSafe = false;
			wasThreadSafe = false;
			updateRoutineRunning = false;
			context.Reset();
			selfObject = null;
			indicatorGizmo = new IndicatorGizmo();
			BuildContext();
		}

		public void UpdateThreadSafety()
		{
			if (!ThreadSafetyCheckRequired)
			{
				return;
			}
			threadSafe = true;
			for (i = 0; i < Behaviours.Count; i++)
			{
				if (!Behaviours[i].ThreadSafe)
				{
					threadSafe = false;
					break;
				}
			}
			ThreadSafetyCheckRequired = false;
		}

		private void Awake()
		{
			BuildContext();
			indicatorGizmo.Drawn = true;
		}

		private void OnEnable()
		{
			UpdateThreadSafety();
			if (Threaded && threadSafe)
			{
				threadedComponents.Add(this);
				threadedContexts.Add(context);
			}
			else
			{
				nonThreadedComponents.Add(this);
			}
			wasThreaded = Threaded;
			wasThreadSafe = threadSafe;
			indicatorGizmo.Initialize(context, context.Problem.ObjectiveCount);
		}

		private void OnDisable()
		{
			if (wasThreaded && wasThreadSafe)
			{
				threadedComponents.Remove(this);
				threadedContexts.Remove(context);
			}
			else
			{
				nonThreadedComponents.Remove(this);
			}
			updateRoutineRunning = false;
		}

		private void OnDrawGizmos()
		{
			if (!base.enabled || !indicatorGizmo.Enabled || !indicatorGizmo.Drawn || Sensor == null || context == null || context.Problem.ObjectiveCount == 0 || context.Problem.ValueCount == 0)
			{
				return;
			}
			indicatorGizmo.Context = context;
			indicatorGizmo.Sensor = context.Sensor;
			indicatorGizmo.Scale = base.transform.lossyScale * indicatorGizmo.CustomScale;
			if (context.Problem.ObjectiveCount != indicatorGizmo.Meshes.Length * 2)
			{
				indicatorGizmo.Meshes = new Mesh[context.Problem.ObjectiveCount * 2];
				for (int i = 0; i < context.Problem.ObjectiveCount * 2; i++)
				{
					indicatorGizmo.Meshes[i] = new Mesh();
				}
				indicatorGizmo.NormalizationValues = new float[context.Problem.ObjectiveCount];
				for (int j = 0; j < context.Problem.ObjectiveCount; j++)
				{
					indicatorGizmo.NormalizationValues[j] = 1f;
				}
			}
			indicatorGizmo.Position = base.gameObject.transform.position;
			indicatorGizmo.Rotation = base.gameObject.transform.rotation;
			indicatorGizmo.CaluculateNormalizedValues();
			if (indicatorGizmo.ShowReceptors)
			{
				indicatorGizmo.DrawReceptors();
			}
			if (UseDefaultVis())
			{
				indicatorGizmo.DefaultVis();
			}
			else if (indicatorGizmo.Wireframe)
			{
				indicatorGizmo.SimpleVis();
			}
			else
			{
				indicatorGizmo.SimpleVisMesh(base.gameObject);
			}
			if (indicatorGizmo.ShowConstraints)
			{
				indicatorGizmo.DrawConstraints();
			}
			indicatorGizmo.DrawSolutions();
		}

		private void Update()
		{
			if (UpdateFrequency != oldUpdateFrequency && UpdateFrequency >= 1E-06f)
			{
				waitForSeconds = new WaitForSeconds(1f / UpdateFrequency);
			}
			oldUpdateFrequency = UpdateFrequency;
			if (Sensor == null)
			{
				Debug.LogError("(" + typeof(AIMContext).Name + ") " + base.gameObject.name + ": no valid sensor set up");
				return;
			}
			if (Sensor.Sensor.ReceptorCount == 0)
			{
				Debug.LogError("(" + typeof(AIMContext).Name + ") " + base.gameObject.name + ": the receptor count of the attached sensor is 0");
				return;
			}
			UpdateThreadSafety();
			if ((Threaded && !wasThreaded && threadSafe) || (threadSafe && !wasThreadSafe && Threaded))
			{
				threadedComponents.Add(this);
				threadedContexts.Add(context);
				nonThreadedComponents.Remove(this);
			}
			else if ((!Threaded && wasThreaded && wasThreadSafe) || (!threadSafe && wasThreadSafe && wasThreaded))
			{
				threadedComponents.Remove(this);
				threadedContexts.Remove(context);
				nonThreadedComponents.Add(this);
			}
			if (Threaded)
			{
				if (!threadSafe)
				{
					Debug.LogWarning("(AIMContext) " + base.name + ": 'Threaded' is 'true' but at least one behaviour is not thread-safe");
				}
				if (AIMContextEvaluation.InstancesCount == 0)
				{
					Debug.LogWarning("(AIMContext) " + base.name + ": 'Threaded' is 'true' but there is no 'AIM Performance'.");
				}
			}
			if (AIMContextEvaluation.InstancesCount == 0)
			{
				if (!Threaded && UpdateFrequency < 1E-06f)
				{
					Evaluate();
				}
				else if (!Threaded && !updateRoutineRunning && UpdateFrequency >= 1E-06f)
				{
					routineAbort = false;
					StartCoroutine(UpdateRoutine());
				}
			}
			else if (updateRoutineRunning && AIMContextEvaluation.InstancesCount > 0)
			{
				routineAbort = true;
			}
			wasThreaded = Threaded;
			wasThreadSafe = threadSafe;
		}

		private IEnumerator UpdateRoutine()
		{
			updateRoutineRunning = true;
			while (!Threaded && !routineAbort && base.enabled && UpdateFrequency >= 1E-06f)
			{
				Evaluate();
				yield return waitForSeconds;
			}
			updateRoutineRunning = false;
			yield return null;
		}

		private bool UseDefaultVis()
		{
			return context.Problem.ValueCount <= indicatorGizmo.ResolutionThreshold;
		}
	}
}
