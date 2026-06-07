using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class PartConnectionFailure
	{
		public string LogMessage { get; }

		public PartData PartA { get; }

		public PartData PartB { get; }

		public PartConnectionFailureReason Reason { get; }

		public PartConnectionFailure(PartData partA, PartData partB, PartConnectionFailureReason reason, string logMessage)
		{
			PartA = partA;
			PartB = partB;
			Reason = reason;
			LogMessage = logMessage;
		}

		public static void LogWarnings(IEnumerable<PartConnectionFailure> failures)
		{
			foreach (PartConnectionFailure failure in failures)
			{
				if (failure != null && failure.PartA != null && failure.PartB != null)
				{
					if (!string.IsNullOrEmpty(failure.LogMessage))
					{
						Debug.LogWarning(failure.LogMessage);
					}
					else
					{
						Debug.LogWarning($"Part connection failure between {PartString(failure.PartA)} and {PartString(failure.PartB)}: {failure.Reason}");
					}
				}
			}
			static string PartString(PartData partData)
			{
				return $"'{partData?.Name} (Id: {partData?.Id})'";
			}
		}
	}
}
