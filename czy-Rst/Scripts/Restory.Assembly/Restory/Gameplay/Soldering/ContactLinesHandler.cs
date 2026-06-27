using System.Collections.Generic;
using System.Linq;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Soldering
{
	public class ContactLinesHandler : MonoBehaviour
	{
		[SerializeField]
		private ElementBase element;

		[SerializeField]
		private Transform contactsLinesContainer;

		private readonly List<SolderPoint> allPoints = new List<SolderPoint>();

		private readonly Dictionary<int, List<SolderPoint>> pointsByIndex = new Dictionary<int, List<SolderPoint>>();

		private readonly Dictionary<int, SolderTrace> tracesByIndex = new Dictionary<int, SolderTrace>();

		private DisassembleStateMachine disassembleStateMachine;

		private SolderPointFactory solderPointFactory;

		private SolderTraceFactory solderTraceFactory;

		private bool isDisassembleModeActivated;

		private int initialPointsCount;

		public IReadOnlyList<SolderPoint> AllPoints => allPoints;

		public int InitialPointsCount => initialPointsCount;

		[Inject]
		public void Construct(DisassembleStateMachine disassembleStateMachine, SolderPointFactory solderPointFactory, SolderTraceFactory solderTraceFactory)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.solderPointFactory = solderPointFactory;
			this.solderTraceFactory = solderTraceFactory;
		}

		private void OnEnable()
		{
			element.OnActivated.AddListener(ResolveElementActivated);
			element.OnDeactivated.AddListener(ResolveElementDeactivated);
			if (!(disassembleStateMachine.ActiveState is DisabledDisassembleState) && element.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty)
			{
				ResolveElementActivated();
			}
		}

		private void OnDisable()
		{
			element.OnActivated.RemoveListener(ResolveElementActivated);
			element.OnDeactivated.RemoveListener(ResolveElementDeactivated);
			isDisassembleModeActivated = false;
			Clear();
		}

		public ContactLine[] GetContactLines()
		{
			return contactsLinesContainer.GetComponentsInChildren<ContactLine>();
		}

		private void ResolveElementActivated()
		{
			if (!isDisassembleModeActivated)
			{
				isDisassembleModeActivated = true;
				if (element.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty scorchedCircuitProperty)
				{
					initialPointsCount = scorchedCircuitProperty.InitialBurntPointsCount;
					RestoreSolderPoints(scorchedCircuitProperty);
				}
			}
		}

		private void ResolveElementDeactivated()
		{
			if (isDisassembleModeActivated && disassembleStateMachine.ActiveState is DisabledDisassembleState)
			{
				isDisassembleModeActivated = false;
				Clear();
			}
		}

		private void RestoreSolderPoints(ScorchedCircuitProperty scorchedCircuitProperty)
		{
			if (allPoints.Count > 0)
			{
				Debug.LogError(string.Format("{0} contains {1} unexpected points", "allPoints", allPoints.Count));
				Clear();
			}
			for (int i = 0; i < scorchedCircuitProperty.BurntTraces.Count; i++)
			{
				BurntTraceData burntTraceData = scorchedCircuitProperty.BurntTraces[i];
				if (burntTraceData.SolderPoints.Count < 2)
				{
					Debug.LogError("burntTrace should contain at least two solder points");
					continue;
				}
				List<SolderPoint> list = new List<SolderPoint>();
				for (int j = 0; j < burntTraceData.SolderPoints.Count; j++)
				{
					SolderPointData solderPointData = burntTraceData.SolderPoints[j];
					SolderPointState state = solderPointData.State;
					if (state == SolderPointState.None || state == SolderPointState.Resoldered || state == SolderPointState.Disappearing)
					{
						Debug.LogError($"{element.Info.ID} try restore unexpected {solderPointData.State} point");
						continue;
					}
					float pointPositionRatioInTrace = (float)j / (float)(burntTraceData.SolderPoints.Count - 1);
					SolderPoint solderPoint = solderPointFactory.Create(solderPointData, contactsLinesContainer);
					solderPoint.Init(i, pointPositionRatioInTrace, solderPointData);
					list.Add(solderPoint);
				}
				allPoints.AddRange(list);
				pointsByIndex.Add(i, list);
			}
		}

		public void CaptureSolderPoints()
		{
			if (!(element.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty scorchedCircuitProperty))
			{
				Debug.LogError("Failed to capture solder points, AdditionalProperty is not ScorchedCircuitProperty");
				return;
			}
			Dictionary<int, BurntTraceData> value;
			using (CollectionPool<Dictionary<int, BurntTraceData>, KeyValuePair<int, BurntTraceData>>.Get(out value))
			{
				foreach (SolderPoint allPoint in allPoints)
				{
					SolderPointState state = allPoint.State;
					if (state != SolderPointState.None && state != SolderPointState.Disappearing)
					{
						if (allPoint.State == SolderPointState.Resoldered)
						{
							allPoint.SetState(SolderPointState.Burnt);
						}
						if (!value.TryGetValue(allPoint.TraceIndex, out var value2))
						{
							value2 = new BurntTraceData();
							value.Add(allPoint.TraceIndex, value2);
						}
						value2.SolderPoints.Add(allPoint.Data);
					}
				}
				if (value.Count == 0)
				{
					element.ConditionHandler.ElementData.AdditionalProperty = null;
				}
				else
				{
					scorchedCircuitProperty.BurntTraces = value.Values.ToList();
				}
			}
		}

		private void GenerateSolderTraces()
		{
			if (pointsByIndex.Count == 0)
			{
				return;
			}
			foreach (KeyValuePair<int, List<SolderPoint>> item in pointsByIndex)
			{
				if (item.Value.Count != 0)
				{
					SolderTrace solderTrace = solderTraceFactory.Create(item.Key, item.Value, contactsLinesContainer);
					if ((bool)solderTrace)
					{
						tracesByIndex.Add(item.Key, solderTrace);
					}
				}
			}
		}

		private void Clear()
		{
			ClearSolderPoints();
		}

		private void ClearSolderPoints()
		{
			foreach (SolderPoint allPoint in allPoints)
			{
				solderPointFactory.Destroy(allPoint);
			}
			allPoints.Clear();
			pointsByIndex.Clear();
		}

		private void ClearSolderTraces()
		{
			foreach (SolderTrace value in tracesByIndex.Values)
			{
				solderTraceFactory.Destroy(value);
			}
			tracesByIndex.Clear();
		}
	}
}
