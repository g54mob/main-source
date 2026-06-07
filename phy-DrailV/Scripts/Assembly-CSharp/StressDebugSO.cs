using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Train stress debug asset")]
public class StressDebugSO : ScriptableObject
{
	public List<StressDebugSession> sessions;
}
