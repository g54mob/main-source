using System;
using UnityEngine;

[Serializable]
public class NavigationMethod
{
	[Tooltip("The navigator is bound to the node it's navigating, else it will be bound to the (moving) world.")]
	public bool LockedToNode;

	[Tooltip("The navigator moves only in a horizontal movement and not in all directions (including vertically).")]
	public bool HorizontalMovement;

	[Tooltip("The navigator is bound to the world physics and uses forces to move around.")]
	public bool PhysicsBound;
}
