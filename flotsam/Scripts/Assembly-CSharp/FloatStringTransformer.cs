using UnityEngine;

public abstract class FloatStringTransformer : ScriptableObject
{
	[Header("Debug")]
	[SerializeField]
	private float _debug;

	public abstract string ReturnString(float input);

	[ContextMenu("Print Debug")]
	public void PrintDebug()
	{
		Debug.Log(ReturnString(_debug));
	}
}
