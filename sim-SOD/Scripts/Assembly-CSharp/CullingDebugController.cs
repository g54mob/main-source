using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CullingDebugController : MonoBehaviour
{
	public enum CullDebugType
	{
		none = 0,
		succeededNew = 1,
		succeededOvr = 2,
		adjacent = 3,
		atriumTop = 4
	}

	public MeshRenderer rend;

	public NewRoom room;

	public NewNode.NodeAccess parentEntrance;

	public NewNode.NodeAccess otherEntrance;

	public List<NewDoor> dependentDoors;

	public NewRoom atriumTopOf;

	public GameObject parentObjectMarker;

	public CullDebugType cullType;

	[Header("Config")]
	public Material red;

	public Material white;

	public Material yellow;

	public Material green;

	public Material blue;

	public void Setup(NewRoom newRoom, NewNode.NodeAccess newPEntrance, List<NewDoor> newDoors, CullDebugType newCullType, NewRoom newAtriumTopOf = null, NewNode.NodeAccess newOEntrance = null)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ToggleParentsEntrance()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RunDataRaycast()
	{
	}
}
