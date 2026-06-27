using System.Collections.Generic;
using Restory.Data.SaveLoad.Containers;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Gameplay.Soldering
{
	public class BurntTraceGenerator : MonoBehaviour
	{
		[SerializeField]
		private float contactStepDistance = 0.002f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Probability for each segment of contact lines to become burnt. At least one burnt trace per element is always guaranteed. 0 = one guaranteed burnt trace, 0.5 = one guaranteed + ~50% of remaining segments.")]
		private float chanceToBurntTrace = 0.5f;

		[SerializeField]
		[Range(0f, 0.002f)]
		private float pointDeviationRange = 0.001f;

		[SerializeField]
		[Range(1f, 2f)]
		private float pointScalingRange = 1.5f;

		public List<BurntTraceData> GenerateBurntTraces(ContactLine[] contactLines)
		{
			List<BurntTraceData> list = new List<BurntTraceData>();
			int num = Random.Range(0, contactLines.Length);
			for (int i = 0; i < contactLines.Length; i++)
			{
				ProcessContactLine(contactLines[i], list, i == num);
			}
			return list;
		}

		private void ProcessContactLine(ContactLine contactLine, List<BurntTraceData> burntTraces, bool shouldHasBurntTrace)
		{
			int segmentCount = contactLine.SegmentCount;
			if (segmentCount < 1)
			{
				Debug.LogError("contactLine must have at least 1 segment");
			}
			else if (shouldHasBurntTrace)
			{
				int requiredIndex = Random.Range(0, segmentCount);
				MakeRandomSegmentsBurnt(contactLine, burntTraces, requiredIndex);
			}
			else
			{
				MakeRandomSegmentsBurnt(contactLine, burntTraces);
			}
		}

		private void MakeRandomSegmentsBurnt(ContactLine contactLine, List<BurntTraceData> existingTraces, int requiredIndex = -1)
		{
			List<BurntTraceData> value;
			using (CollectionPool<List<BurntTraceData>, BurntTraceData>.Get(out value))
			{
				Dictionary<int, BurntTraceData> value2;
				using (CollectionPool<Dictionary<int, BurntTraceData>, KeyValuePair<int, BurntTraceData>>.Get(out value2))
				{
					int num = contactLine.SegmentCount - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((i == requiredIndex || !(Random.value > chanceToBurntTrace)) && !value2.ContainsKey(i) && contactLine.TryGetSegmentByIndex(i, out var startPosition, out var endPosition))
						{
							if (!value2.TryGetValue(i - 1, out var value3))
							{
								value3 = new BurntTraceData();
								value.Add(value3);
							}
							AddSegmentPointsToBurntTrace(startPosition, endPosition, value3);
							value2.Add(i, value3);
						}
					}
					if (contactLine.IsLoop && value2.TryGetValue(0, out var value4) && value2.TryGetValue(num, out var value5) && value4 != value5)
					{
						value4.SolderPoints.RemoveAt(0);
						value4.SolderPoints.InsertRange(0, value5.SolderPoints);
						value5.SolderPoints.Clear();
						value.Remove(value5);
						value2.Remove(num);
					}
				}
				existingTraces.AddRange(value);
			}
		}

		private void AddSegmentPointsToBurntTrace(Vector3 startPosition, Vector3 endPosition, BurntTraceData burntTrace)
		{
			float num = contactStepDistance;
			float num2 = Vector3.Distance(startPosition, endPosition);
			Vector3 normalized = (endPosition - startPosition).normalized;
			Vector3 perpendicular = ((Mathf.Abs(normalized.x) >= Mathf.Abs(normalized.y)) ? Vector3.up : Vector3.right);
			if (burntTrace.SolderPoints.Count == 0)
			{
				AddNewSolderPointToBurntTrace(startPosition, perpendicular, burntTrace, isPivot: true);
			}
			while (num < num2)
			{
				Vector3 contactPosition = startPosition + normalized * num;
				num += contactStepDistance;
				AddNewSolderPointToBurntTrace(contactPosition, perpendicular, burntTrace);
			}
			AddNewSolderPointToBurntTrace(endPosition, perpendicular, burntTrace, isPivot: true);
		}

		private void AddNewSolderPointToBurntTrace(Vector3 contactPosition, Vector3 perpendicular, BurntTraceData burntTrace, bool isPivot = false)
		{
			SolderPointData item = new SolderPointData
			{
				State = SolderPointState.Sooty,
				Transform = new SerializableTransform(contactPosition, Quaternion.identity),
				Deviation = perpendicular * Random.Range(0f - pointDeviationRange, pointDeviationRange),
				Scaling = Random.Range(1f, pointScalingRange),
				IsPivot = isPivot
			};
			burntTrace.SolderPoints.Add(item);
		}
	}
}
