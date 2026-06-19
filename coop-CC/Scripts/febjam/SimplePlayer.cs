using Aggro.Core.Networking;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayer : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float speed = 5f;

	private Vector3 _movement;

	protected override void OnUpdatePresentation()
	{
		if (base.isLocalPlayer)
		{
			_movement = Vector2.zero;
			if (Keyboard.current.wKey.wasPressedThisFrame)
			{
				_movement.z = 1f;
			}
			if (Keyboard.current.aKey.wasPressedThisFrame)
			{
				_movement.x = -1f;
			}
			if (Keyboard.current.sKey.wasPressedThisFrame)
			{
				_movement.z = -1f;
			}
			if (Keyboard.current.dKey.wasPressedThisFrame)
			{
				_movement.x = 1f;
			}
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isLocalPlayer)
		{
			Vector3 localPosition = base.transform.localPosition;
			localPosition += _movement * (speed * Time.fixedDeltaTime);
			base.transform.localPosition = localPosition;
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
