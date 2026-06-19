using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrowStages", menuName = "GrowableObject/GrowStages")]
public class GrowStages : ScriptableObject
{
	public List<GameObject> stages = new List<GameObject>();
}
