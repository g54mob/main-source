using System.Collections.Generic;
using UnityEngine;

public class RoomEffectBase : MonoBehaviour
{
	public bool runEffectOnUpdate = true;

	public bool runEffectOnFixedUpdate;

	protected RoomBase roomRef;

	protected List<GameObject> objList = new List<GameObject>();

	protected BoundingBoxComponent bbc;

	protected ObjectRegistration regRef;

	private void Awake()
	{
		AwakeBehavior();
	}

	protected virtual void AwakeBehavior()
	{
		roomRef = GetComponent<RoomBase>();
		regRef = ObjectRegistration.GetRegistrationScript();
	}

	private void Update()
	{
		UpdateBehavior();
	}

	private void FixedUpdate()
	{
		FixedUpdateBehavior();
	}

	protected virtual void UpdateBehavior()
	{
		if (runEffectOnUpdate)
		{
			FindObjectsAndApplyRoomEffect();
		}
	}

	protected virtual void FixedUpdateBehavior()
	{
		if (runEffectOnFixedUpdate)
		{
			FindObjectsAndApplyRoomEffect();
		}
	}

	private void FindObjectsAndApplyRoomEffect()
	{
		if (bbc == null)
		{
			bbc = GetComponent<BoundingBoxComponent>();
			if (bbc == null)
			{
				bbc = base.gameObject.AddComponent<BoundingBoxComponent>();
			}
		}
		objList.Clear();
		objList = regRef.GetAllObjectsForTag(TagsEnum.ALL);
		for (int i = 0; i < objList.Count; i++)
		{
			if (objList[i].GetComponent<BoundingBoxComponent>().CheckBoxContained(bbc))
			{
				ApplyRoomEffect(objList[i]);
			}
		}
	}

	protected virtual void ApplyRoomEffect(GameObject obj)
	{
	}
}
