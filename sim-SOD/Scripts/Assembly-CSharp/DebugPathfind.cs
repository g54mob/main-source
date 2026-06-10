using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class DebugPathfind : MonoBehaviour
{
	[Serializable]
	public class DebugLocationLink
	{
		public string name;

		public NewNode.NodeAccess access;

		public DebugLocationLink(NewNode.NodeAccess acc, string reason)
		{
		}
	}

	private NewNode.NodeAccess access;

	[Tooltip("Parent to this room")]
	public NewRoom room;

	[Tooltip("Parent to this gamelocation")]
	public NewGameLocation gameLocation;

	[ReadOnly]
	public Vector3 fromNodePos;

	[ReadOnly]
	public Vector3 toNodePos;

	[Header("Access Details")]
	[ReadOnly]
	public bool walkingAccess;

	[ReadOnly]
	public bool employeeDoor;

	[ReadOnly]
	public bool noPassThroughOnFromNode;

	[ReadOnly]
	public bool noPassThroughOnToNode;

	[ReadOnly]
	public bool noAccessOnFromNode;

	[ReadOnly]
	public bool noAccessOnToNode;

	[Tooltip("Links to other gamelocations")]
	[Space(7f)]
	public List<DebugLocationLink> locationLinkAttempts;

	public void Setup(NewNode.NodeAccess newAccess, NewRoom newRoom, List<DebugLocationLink> linkList)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TeleportPlayer()
	{
	}
}
