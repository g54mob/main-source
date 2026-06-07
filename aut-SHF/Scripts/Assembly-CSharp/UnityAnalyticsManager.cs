using System.Diagnostics;
using UnityEngine;

public class UnityAnalyticsManager : MonoBehaviour
{
	[Conditional("INHOUSE_WITH_ANALYZE_SECRETLY")]
	public static void RecordEvent(SDEventBase sdEvent)
	{
	}
}
