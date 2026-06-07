using UnityEngine;

public abstract class InputMode : MonoBehaviour
{
	[HideInInspector]
	public PlayerController playerController;

	protected EInputMode inputModeType;

	public EInputMode InputModeType => inputModeType;
}
