using Pug.Conversion;
using UnityEngine;

public class EntityMonoBehaviourData : MonoBehaviour, IEntityMonoBehaviourData, IPreferredObjectIndex
{
	public ObjectInfo objectInfo;

	public GameObject optionalPreviewPrefab;

	public GameObject GameObject => base.gameObject;

	public Transform Transform => base.transform;

	public ObjectInfo ObjectInfo => objectInfo;

	public bool TryGetPreferredObjectIndex(out int objectIndex)
	{
		objectIndex = 0;
		if (objectInfo == null || objectInfo.objectID == ObjectID.None)
		{
			return false;
		}
		objectIndex = (int)objectInfo.objectID;
		return true;
	}
}
