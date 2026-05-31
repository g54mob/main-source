using UnityEngine;

public class PTSMonoBehaviour : MonoBehaviour
{
	[SerializeField]
	[HideInInspector]
	protected string uniqueID;

	[HideInInspector]
	public static bool showDebug;

	private int _lastHash;

	public new static Object Instantiate(Object original)
	{
		return null;
	}

	public new static Object Instantiate(Object original, Transform parent)
	{
		return null;
	}

	public new static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
	{
		return null;
	}

	public new static Object Instantiate(Object original, Vector3 position, Quaternion rotation)
	{
		return null;
	}

	public new static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent)
	{
		return null;
	}

	public new static T Instantiate<T>(T original) where T : Object
	{
		return null;
	}

	public new static T Instantiate<T>(T original, Transform parent) where T : Object
	{
		return null;
	}

	public new static T Instantiate<T>(T original, Transform parent, bool instantiateInWorldSpace) where T : Object
	{
		return null;
	}

	public new static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object
	{
		return null;
	}

	public static T Instantiate<T>(T original, Transform parent, Vector3 position, Quaternion rotation) where T : Object
	{
		return null;
	}

	private static void AssignUniqueIDsToAllPTSComponents(Object obj)
	{
	}

	public virtual void OnSelectedInEditor()
	{
	}

	public void BaseOnSelectedInEditor()
	{
	}

	protected virtual void PTSReset()
	{
	}

	private void Reset()
	{
	}

	protected virtual void PTSOnEnable()
	{
	}

	private void OnEnable()
	{
	}

	protected virtual void PTSOnValidateFromMenu()
	{
	}

	protected virtual void PTSOnValidate()
	{
	}

	protected virtual void PTSOnValidateInspector()
	{
	}

	private void OnValidate()
	{
	}

	public static Object FindObjectByUniqueID(string uniqueID)
	{
		return null;
	}

	public string GetUniqueID()
	{
		return null;
	}

	public void SetUniqueID(string uq)
	{
	}

	[ContextMenu("Generate UniqueID")]
	public void GenerateUniqueID()
	{
	}

	[ContextMenu("Clear and Generate UniqueID")]
	public void ClearAndGenerateUniqueID()
	{
	}
}
