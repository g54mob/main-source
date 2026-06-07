using UnityEngine;

public class InputDependentGroup : MonoBehaviour
{
	[NamedArray(typeof(InputType))]
	public GameObject[] Wrappers;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInputTypeChanged()
	{
	}
}
