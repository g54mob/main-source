using UnityEngine;

public class bqv : MonoBehaviour
{
	public struct State
	{
		public Vector3 move;

		public Vector3 lookPos;

		public bool crouch;

		public bool jump;

		public int actionIndex;
	}

	public bool walkByDefault;

	public bool canCrouch;

	public bool canJump;

	public State state;

	protected Transform unu;

	protected virtual void Start()
	{
	}

	protected virtual void Update()
	{
	}
}
