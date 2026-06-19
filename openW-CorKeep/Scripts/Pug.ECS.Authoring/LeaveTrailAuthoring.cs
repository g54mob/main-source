using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class LeaveTrailAuthoring : MonoBehaviour
{
	public bool leaveTrail;

	[ShowIf("leaveTrail")]
	public int trails;

	[ShowIf("leaveTrail")]
	public ObjectID trailObjectID;
}
