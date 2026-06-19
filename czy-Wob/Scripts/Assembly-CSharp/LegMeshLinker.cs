using System.Collections.Generic;
using UnityEngine;

public class LegMeshLinker : MonoBehaviour
{
	public GameObject legRoot;

	public GameObject legBaseObject;

	public SkinnedMeshRenderer legMesh;

	public List<JointRemapMap> jointRemapping = new List<JointRemapMap>();

	public Dictionary<int, Vector3> positionMapping = new Dictionary<int, Vector3>();

	private void Awake()
	{
		StoreJointPositions();
	}

	public void StoreJointPositions()
	{
		for (int i = 0; i < jointRemapping.Count; i++)
		{
			ConfigurableJoint component = jointRemapping[i].refObject.GetComponent<ConfigurableJoint>().connectedBody.GetComponent<ConfigurableJoint>();
			Vector3 vector = component.connectedBody.transform.TransformPoint(component.connectedAnchor);
			jointRemapping[i].positionalOffset = vector - jointRemapping[i].refObject.transform.position;
		}
		int num = 0;
		GameObject gameObject = legRoot;
		while (gameObject != null)
		{
			positionMapping[num] = gameObject.transform.localPosition;
			if (gameObject.transform.childCount > 0)
			{
				num++;
				gameObject = gameObject.transform.GetChild(0).gameObject;
				continue;
			}
			break;
		}
	}

	public void RepositionObject(GameObject obj, int index)
	{
		if (positionMapping.ContainsKey(index))
		{
			obj.transform.localPosition = positionMapping[index];
		}
	}

	public int GetNumberOfJoints()
	{
		return jointRemapping.Count;
	}

	public void RemapJointIndexStart(int i, ref Vector3 attachedJointAnchor, ref JointDataStruct jointInfo)
	{
		if (i < jointRemapping.Count)
		{
			RemapJointStart(jointRemapping[i], ref attachedJointAnchor, ref jointInfo);
		}
	}

	public void RemapJointIndexEnd(int i, Vector3 attachedJointAnchor, JointDataStruct jointInfo)
	{
		if (i < jointRemapping.Count)
		{
			RemapJointEnd(jointRemapping[i], attachedJointAnchor, jointInfo);
		}
	}

	private void RemapJointStart(JointRemapMap mapRef, ref Vector3 attachedJointAnchor, ref JointDataStruct jointInfo)
	{
		GameObject refObject = mapRef.refObject;
		Rigidbody component = refObject.GetComponent<Rigidbody>();
		ConfigurableJoint component2 = refObject.GetComponent<ConfigurableJoint>();
		Rigidbody rigidbody = mapRef.remapTarget.AddComponent<Rigidbody>();
		rigidbody.mass = component.mass;
		rigidbody.drag = component.drag;
		rigidbody.angularDrag = component.angularDrag;
		rigidbody.useGravity = component.useGravity;
		rigidbody.isKinematic = component.isKinematic;
		rigidbody.interpolation = component.interpolation;
		rigidbody.collisionDetectionMode = component.collisionDetectionMode;
		rigidbody.constraints = component.constraints;
		ConfigurableJoint component3 = component2.connectedBody.transform.GetComponent<ConfigurableJoint>();
		attachedJointAnchor = component3.connectedBody.transform.TransformPoint(component3.connectedAnchor);
		jointInfo = new JointDataStruct(component2);
		Object.Destroy(component2);
		Object.Destroy(component);
	}

	private void RemapJointEnd(JointRemapMap mapRef, Vector3 attachedJointAnchor, JointDataStruct jointInfo)
	{
		mapRef.refObject.transform.position = attachedJointAnchor - mapRef.positionalOffset;
		ConfigurableJoint jointRef = mapRef.remapTarget.AddComponent<ConfigurableJoint>();
		jointInfo.ApplyPropertiesToJoint(jointRef, mapRef.autoConfigureConnectedAnchor, moveOwningObject: false);
	}

	public void RepositionJoints()
	{
		int num = 0;
		GameObject gameObject = legRoot;
		while (gameObject != null)
		{
			if (num == 1)
			{
				ConfigurableJoint component = gameObject.GetComponent<ConfigurableJoint>();
				if (component == null)
				{
					num++;
					continue;
				}
				gameObject.transform.localPosition = positionMapping[num];
				component.autoConfigureConnectedAnchor = true;
				gameObject.SetActive(value: false);
				gameObject.SetActive(value: true);
			}
			if (gameObject.transform.childCount > 0)
			{
				num++;
				gameObject = gameObject.transform.GetChild(0).gameObject;
				continue;
			}
			break;
		}
	}
}
