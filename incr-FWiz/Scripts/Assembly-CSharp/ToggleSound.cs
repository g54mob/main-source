using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
	public EventReference Sound;

	[SerializeField]
	private Toggle Toggle;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnToggle(bool value)
	{
	}
}
