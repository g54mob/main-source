using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
	[TextArea]
	[Tooltip("Dont remove Notes variable.")]
	public string Notes = "With the WireBuilder object selected use right click to select position. Have active Gizmos.";

	[TextArea]
	[Tooltip("Dont remove Notes2 variable.")]
	public string Notes2 = "Wire render settings in TubeRender.cs on WireRender object.";

	[Header("SETTINGS")]
	[Tooltip("Disabling it removes the wire physics, for use as a prop (Only change after clearing).")]
	public bool usePhysics = true;

	[Tooltip("Distance between segments and position selected with the mouse. Lowering it allows more precision. Increase it when you want to set the end anchor point. Dont go below than 0.01")]
	public float maxDistanceWithSelectedPos = 0.2f;

	[Tooltip("Separation between segments, lower it instance less segments. Dont go below than 0.01")]
	public float segmentsSeparation = 0.2f;

	[Tooltip("Prevents infinite segments from being instantiated in case of an error in the code.")]
	public int limitMax = 200;

	private int limit;

	[Tooltip("A higher value improves the stability of the physics.")]
	public float segmentsRadius = 1.5f;

	public float currentDistanceToStartAnchor;

	[Tooltip("Sets the maximum distance from the start anchor point to the end anchor point, based on the number of segments and the separation between them.")]
	public float maxDistanceToStarAnchor;

	[Header("RUNTIME SETTINGS")]
	[Tooltip("Enable endless rope mode - adds segments dynamically at runtime")]
	public bool endlessRopeMode = true;

	[Tooltip("Distance threshold before adding new segments (as percentage of max distance, e.g., 0.9 = 90%)")]
	[Range(0.7f, 0.99f)]
	public float extensionThreshold = 0.9f;

	[Tooltip("Number of segments to add each time the rope extends")]
	public int segmentsToAddPerExtension = 5;

	[Tooltip("Maximum total segments for endless rope (safety limit)")]
	public int maxTotalSegments = 500;

	[Header("SPAWNED SEGMENTS")]
	public List<Transform> segments;

	[HideInInspector]
	[Tooltip("You can delete these references when you are no longer modifying the wire.")]
	public List<int> undoSegments;

	private int undoCount;

	[Header("REFERENCES")]
	public TubeRenderer ropeMesh;

	public Transform starAnchorTemp;

	public Transform firstSegment;

	public Transform endAnchorTemp;

	public Transform plugTemp;

	[Header("PREFABS")]
	public Transform startAnchorPoint;

	public Transform segment;

	public Transform segmentNoPhysics;

	public Transform endAnchorPoint;

	public Transform plugObjt;

	[Header("MOUSE POSS")]
	public Vector3 selectPosition;

	public Transform mousePossHelper;

	private void Start()
	{
		mousePossHelper.gameObject.SetActive(value: false);
	}

	private void OnValidate()
	{
		ChangeRadius();
	}

	public void GetSegmentsDistance()
	{
		int index = segments.Count - 1;
		if (Vector3.Distance(segments[index].position, selectPosition) >= maxDistanceWithSelectedPos + segmentsSeparation && limit <= limitMax)
		{
			limit++;
			if (usePhysics)
			{
				Transform transform = Object.Instantiate(segment, segments[index].position + segments[index].forward * segmentsSeparation, segments[index].rotation, base.transform);
				transform.GetComponent<ConfigurableJoint>().connectedBody = segments[index].GetComponent<Rigidbody>();
				segments.Add(transform);
			}
			else
			{
				Transform item = Object.Instantiate(segmentNoPhysics, segments[index].position + segments[index].forward * segmentsSeparation, segments[index].rotation, base.transform);
				segments.Add(item);
			}
			undoCount++;
			GetSegmentsDistance();
		}
		else
		{
			SetMaxDistance();
		}
	}

	public void AddStar()
	{
		if (starAnchorTemp == null)
		{
			starAnchorTemp = Object.Instantiate(startAnchorPoint, selectPosition, Quaternion.identity, base.transform);
		}
		if (!usePhysics)
		{
			Object.DestroyImmediate(starAnchorTemp.GetComponent<ConfigurableJoint>());
			Object.DestroyImmediate(starAnchorTemp.GetComponent<Collider>());
			Object.DestroyImmediate(starAnchorTemp.GetComponent<Rigidbody>());
		}
	}

	public void AddSegment()
	{
		undoCount = 0;
		if (firstSegment == null)
		{
			if (usePhysics)
			{
				firstSegment = Object.Instantiate(segment, starAnchorTemp.position, starAnchorTemp.rotation, base.transform);
				firstSegment.GetComponent<ConfigurableJoint>().connectedBody = starAnchorTemp.GetComponent<Rigidbody>();
			}
			else
			{
				firstSegment = Object.Instantiate(segmentNoPhysics, starAnchorTemp.position, starAnchorTemp.rotation, base.transform);
			}
			segments.Add(firstSegment);
			undoCount++;
		}
		int index = segments.Count - 1;
		segments[index].LookAt(selectPosition);
		GetSegmentsDistance();
		RenderWireMesh();
		undoSegments.Add(undoCount);
	}

	public void AddEnd()
	{
		int index = segments.Count - 1;
		endAnchorTemp = Object.Instantiate(endAnchorPoint, segments[index].position + segments[index].forward * 0.0005f, segments[index].rotation, base.transform);
		endAnchorTemp.GetComponent<ConfigurableJoint>().connectedBody = segments[index].GetComponent<Rigidbody>();
		if (usePhysics)
		{
			segments[index].gameObject.AddComponent<ConfigurableJoint>().connectedBody = endAnchorTemp.GetComponent<Rigidbody>();
			return;
		}
		Object.DestroyImmediate(endAnchorTemp.GetComponent<ConfigurableJoint>());
		Object.DestroyImmediate(endAnchorTemp.GetComponent<Collider>());
		Object.DestroyImmediate(endAnchorTemp.GetComponent<Rigidbody>());
	}

	public void AddPlug()
	{
		plugTemp = Object.Instantiate(plugObjt, selectPosition, plugObjt.transform.rotation, base.transform);
		PlugController component = plugTemp.GetComponent<PlugController>();
		component.endAnchor = endAnchorTemp;
		component.endAnchorRB = endAnchorTemp.GetComponent<Rigidbody>();
		component.wireController = this;
	}

	public void SetMaxDistance()
	{
		maxDistanceToStarAnchor = (float)segments.Count * segmentsSeparation;
	}

	public void ChangeRadius()
	{
		if (!usePhysics)
		{
			return;
		}
		foreach (Transform segment in segments)
		{
			segment.GetComponent<SphereCollider>().radius = segmentsRadius;
		}
	}

	public void Clear()
	{
		for (int i = 1; i < segments.Count; i++)
		{
			Object.DestroyImmediate(segments[i].gameObject);
		}
		if (firstSegment != null)
		{
			Object.DestroyImmediate(firstSegment.gameObject);
		}
		if (starAnchorTemp != null)
		{
			Object.DestroyImmediate(starAnchorTemp.gameObject);
		}
		if (endAnchorTemp != null)
		{
			Object.DestroyImmediate(endAnchorTemp.gameObject);
		}
		if (plugTemp != null)
		{
			Object.DestroyImmediate(plugTemp.gameObject);
		}
		segments.Clear();
		undoSegments.Clear();
		undoCount = 0;
		RenderWireMesh();
		ClearWireMesh();
		limit = 0;
	}

	public void Undo()
	{
		if (endAnchorTemp != null)
		{
			Object.DestroyImmediate(endAnchorTemp.gameObject);
		}
		for (int i = 1; i <= undoSegments[undoSegments.Count - 1]; i++)
		{
			Object.DestroyImmediate(segments[segments.Count - 1].gameObject);
			segments.Remove(segments[segments.Count - 1]);
		}
		undoSegments.RemoveAt(undoSegments.Count - 1);
		if (undoSegments.Count == 0)
		{
			ClearWireMesh();
		}
		RenderWireMesh();
	}

	public void ClearWireMesh()
	{
		Vector3[] positions = new Vector3[2]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f)
		};
		ropeMesh.SetPositions(positions);
	}

	public void FinishNoPhysicsWire()
	{
		if (!usePhysics)
		{
			foreach (Transform segment in segments)
			{
				Object.DestroyImmediate(segment.gameObject);
			}
			segments.Clear();
			undoSegments.Clear();
		}
		else
		{
			Debug.LogWarning("only use in no-physics wires and when you don't want to modify them anymore.");
		}
	}

	public void SetPosition(Vector3 position)
	{
		selectPosition = position;
		AddClickPosHelper();
	}

	public void AddClickPosHelper()
	{
		mousePossHelper.transform.position = selectPosition;
	}

	private void LateUpdate()
	{
		if (usePhysics)
		{
			RenderWireMesh();
			DistanceBetweenStartAndEnd();
			if (endlessRopeMode && endAnchorTemp != null)
			{
				CheckAndExtendRope();
			}
		}
	}

	public void DistanceBetweenStartAndEnd()
	{
		if (endAnchorTemp != null && starAnchorTemp != null)
		{
			currentDistanceToStartAnchor = Vector3.Distance(endAnchorTemp.position, starAnchorTemp.position);
			if (!endlessRopeMode)
			{
				_ = currentDistanceToStartAnchor;
				_ = maxDistanceToStarAnchor;
			}
		}
	}

	private void CheckAndExtendRope()
	{
		if (segments.Count >= maxTotalSegments)
		{
			Debug.LogWarning("Reached maximum total segments limit!");
		}
		else if (currentDistanceToStartAnchor / maxDistanceToStarAnchor >= extensionThreshold)
		{
			ExtendRope();
		}
	}

	private void ExtendRope()
	{
		if (!usePhysics || endAnchorTemp == null || segments.Count == 0)
		{
			return;
		}
		int index = segments.Count - 1;
		Transform obj = segments[index];
		_ = endAnchorTemp.localPosition;
		_ = endAnchorTemp.localRotation;
		ConfigurableJoint component = endAnchorTemp.GetComponent<ConfigurableJoint>();
		ConfigurableJoint[] components = obj.GetComponents<ConfigurableJoint>();
		foreach (ConfigurableJoint configurableJoint in components)
		{
			if (configurableJoint.connectedBody == endAnchorTemp.GetComponent<Rigidbody>())
			{
				Object.Destroy(configurableJoint);
				break;
			}
		}
		int num = 0;
		for (int j = 0; j < segmentsToAddPerExtension; j++)
		{
			if (segments.Count >= maxTotalSegments)
			{
				break;
			}
			Transform transform = segments[segments.Count - 1];
			Transform transform2 = Object.Instantiate(segment, transform.position + transform.forward * segmentsSeparation, transform.rotation, base.transform);
			ConfigurableJoint component2 = transform2.GetComponent<ConfigurableJoint>();
			if (component2 != null)
			{
				component2.connectedBody = transform.GetComponent<Rigidbody>();
			}
			SphereCollider component3 = transform2.GetComponent<SphereCollider>();
			if (component3 != null)
			{
				component3.radius = segmentsRadius;
			}
			segments.Add(transform2);
			num++;
		}
		if (num > 0)
		{
			Transform transform3 = segments[segments.Count - 1];
			endAnchorTemp.position = transform3.position + transform3.forward * 0.0005f;
			endAnchorTemp.rotation = transform3.rotation;
			if (component != null)
			{
				component.connectedBody = transform3.GetComponent<Rigidbody>();
			}
			ConfigurableJoint component4 = segment.GetComponent<ConfigurableJoint>();
			ConfigurableJoint configurableJoint2 = transform3.gameObject.AddComponent<ConfigurableJoint>();
			CopyJointSettings(component4, configurableJoint2);
			configurableJoint2.connectedBody = endAnchorTemp.GetComponent<Rigidbody>();
			SetMaxDistance();
			Debug.Log($"Extended rope by {num} segments. Total segments: {segments.Count}");
		}
	}

	private void CopyJointSettings(ConfigurableJoint source, ConfigurableJoint target)
	{
		target.xMotion = source.xMotion;
		target.yMotion = source.yMotion;
		target.zMotion = source.zMotion;
		target.angularXMotion = source.angularXMotion;
		target.angularYMotion = source.angularYMotion;
		target.angularZMotion = source.angularZMotion;
		target.linearLimit = source.linearLimit;
		target.angularXLimitSpring = source.angularXLimitSpring;
		target.angularYLimit = source.angularYLimit;
		target.angularZLimit = source.angularZLimit;
		target.xDrive = source.xDrive;
		target.yDrive = source.yDrive;
		target.zDrive = source.zDrive;
		target.angularXDrive = source.angularXDrive;
		target.angularYZDrive = source.angularYZDrive;
		target.breakForce = source.breakForce;
		target.breakTorque = source.breakTorque;
	}

	public void RenderWireMesh()
	{
		List<Vector3> list = new List<Vector3>();
		foreach (Transform segment in segments)
		{
			if (segment != null)
			{
				list.Add(segment.localPosition);
			}
		}
		if (list.Count > 0)
		{
			ropeMesh.SetPositions(list.ToArray());
		}
	}
}
