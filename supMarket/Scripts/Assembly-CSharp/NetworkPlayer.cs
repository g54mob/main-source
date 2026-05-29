using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;

public class NetworkPlayer : MonoBehaviour
{
	[SerializeField]
	[ReadOnly(new string[] { })]
	private bool m_IsLocalPlayer;

	private CharacterController m_CharacterController;

	private PlayerInput m_PlayerInput;

	private InputActions m_InputActions;

	private FirstPersonController m_FirstPersonController;

	public bool IsLocalPlayer
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void ChangeLocalPlayer()
	{
	}
}
