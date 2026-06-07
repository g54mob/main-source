using Rewired;
using UnityEngine;

public class Func_HideWhenUsingController : MonoBehaviour
{
	[SerializeField]
	private GameObject objectToHide;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}
}
