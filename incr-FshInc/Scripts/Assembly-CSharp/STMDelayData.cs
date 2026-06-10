using UnityEngine;

[CreateAssetMenu(fileName = "New Delay Data", menuName = "Super Text Mesh/Delay Data", order = 1)]
public class STMDelayData : ScriptableObject
{
	[Tooltip("Amount of additional delays to be applied. eg. If text delay is normally 0.1 and this value is 3, it will cause a delay of 0.4 seconds in total. (0.1 + (3 * 0.1))")]
	public int count;
}
