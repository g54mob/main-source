using System.Collections.Generic;
using UnityEngine;

public class ConfigurableJointToggler : MonoBehaviour
{
	public bool moveOwningObject = true;

	public bool autoConfigureConnectedAnchor;

	private List<JointDataStruct> savedJoints = new List<JointDataStruct>();

	private void Awake()
	{
		StoreJoints();
	}

	public void ManualDisable()
	{
		OnDisable();
	}

	public void ManualEnable()
	{
		OnEnable();
	}

	private void OnEnable()
	{
		RebuildJoints();
	}

	private void OnDisable()
	{
		for (int i = 0; i < savedJoints.Count; i++)
		{
			Object.Destroy(savedJoints[i].owningObject.GetComponent<ConfigurableJoint>());
		}
	}

	private void StoreJoints()
	{
		savedJoints.Clear();
		ConfigurableJoint[] componentsInChildren = GetComponentsInChildren<ConfigurableJoint>();
		foreach (ConfigurableJoint jointRef in componentsInChildren)
		{
			savedJoints.Add(new JointDataStruct(jointRef));
		}
	}

	private void RebuildJoints()
	{
		for (int i = 0; i < savedJoints.Count; i++)
		{
			if (!(savedJoints[i].owningObject.GetComponent<ConfigurableJoint>() != null))
			{
				savedJoints[i].CreateJoint(autoConfigureConnectedAnchor, moveOwningObject);
			}
		}
	}
}
