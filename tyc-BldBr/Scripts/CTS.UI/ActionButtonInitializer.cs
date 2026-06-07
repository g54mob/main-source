using UnityEngine;

public abstract class ActionButtonInitializer : ScriptableObject
{
	[field: SerializeField]
	public ActionButton ButtonPrefab { get; private set; }
}
