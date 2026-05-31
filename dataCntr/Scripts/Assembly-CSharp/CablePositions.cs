using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CablePositions : MonoBehaviour
{
	public class CableEntityInfo
	{
		public Entity Entity;

		public int Version;
	}

	public static CablePositions instance;

	public Dictionary<int, List<Vector3>> cables;

	private Dictionary<int, List<Vector3>> rawCablePoints;

	public Dictionary<int, CableEntityInfo> cableEntities;

	private Dictionary<int, GameObject> cableGameObjects;

	private Dictionary<int, Material> cableMaterials;

	public int nextCableId;

	public float packetSpeed;

	public float spawnRateDivider;

	public string startSwitchID;

	public string endSwitchID;

	public int startCustomerID;

	public int endCustomerID;

	private Dictionary<int, bool> cableStartPoints;

	private Dictionary<int, bool> cableEndPoints;

	private Dictionary<int, List<Transform>> rawLinkTransforms;

	[SerializeField]
	private float cableWidth;

	public Material cableMaterial;

	[SerializeField]
	private float bendRadius;

	[SerializeField]
	private int bendSegments;

	[SerializeField]
	private float holderSegmentLength;

	private Vector3 lastPosAfterBendToPass;

	public int lastCompletedCableId;

	public CableLink.TypeOfLink startCableLinkType;

	public CableLink.TypeOfLink endtCableLinkType;

	public string startServerID;

	public string endServerID;

	public float currentCableLength;

	private void Awake()
	{
	}

	public void ClearAllCables()
	{
	}

	public void LoadCable(CableSaveData cableData)
	{
	}

	public int CreateNewCable()
	{
		return 0;
	}

	public int CreateNewReverseCable()
	{
		return 0;
	}

	public void AssignNewPosition(int cableId, Transform linkTransform, bool isStartPoint = false, bool isEndPoint = false, CableLink.TypeOfLink typeOfLink = CableLink.TypeOfLink.None, string serverID = null)
	{
	}

	private void GenerateFinalPath(int cableId)
	{
	}

	private IEnumerable<Vector3> GenerateCornerBend(Vector3 p_prev, Vector3 p_curr, Vector3 p_next, Transform t_curr)
	{
		return null;
	}

	private IEnumerable<Vector3> GenerateBentSegment(Vector3 connectionPoint, Vector3 nextPoint, Transform linkTransform, bool isStart)
	{
		return null;
	}

	private void RedrawCable(int cableId)
	{
	}

	private Mesh CreateTubeMesh(List<Vector3> path)
	{
		return null;
	}

	public void RemovePosition(int cableId)
	{
	}

	public Transform RemoveLastPosition(int cableId)
	{
		return null;
	}

	public List<Vector3> GetCablePositions(int cableId)
	{
		return null;
	}

	public List<Vector3> GetRawCablePositions(int cableId)
	{
		return null;
	}

	public List<Transform> GetRawLinkTransforms(int cableId)
	{
		return null;
	}

	public void AssignEntity(int cableId, Entity entity)
	{
	}

	public bool IsCableComplete(int cableId)
	{
		return false;
	}

	public Material GetCableMaterial(int cableId)
	{
		return null;
	}
}
