using UnityEngine;

public class ElementSubType : ScriptableObject
{
	public GroupTypeId groupTypeId;

	public bool hasOverrideInstancingMinMaxScale;

	public Vector3 overrideMinScale = Vector3.one;

	public Vector3 overrideMaxScale = Vector3.one;
}
