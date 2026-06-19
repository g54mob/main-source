using UnityEngine;

public class SaddleBind : MonoBehaviour
{
	[SerializeField]
	private GameObject saddle;

	private Transform chestBone;

	private Transform saddleBone;

	private void Awake()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.name == "Chest_Pull")
			{
				chestBone = transform;
			}
			if (transform.name == "Saddle_MCH_Back_end")
			{
				saddleBone = transform;
			}
		}
	}

	private void LateUpdate()
	{
		saddle.transform.position = chestBone.position;
		saddle.transform.LookAt(saddleBone.position);
	}
}
