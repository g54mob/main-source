using System;
using UnityEngine;

[ExecuteInEditMode]
public class BlendTransform : MonoBehaviour
{
	[Serializable]
	public class BlendNode
	{
		public Transform Object;

		public string Name;

		public float Weight = 1f;

		public float NormalizedWeight = 1f;

		public void Init()
		{
			if (Object == null)
			{
				GameObject gameObject = GameObject.Find(Name);
				if (gameObject != null)
				{
					Object = gameObject.transform;
				}
			}
		}
	}

	public BlendNode[] Nodes;

	public GameObject[] Followers;

	private void Start()
	{
		BlendNode[] nodes = Nodes;
		for (int i = 0; i < nodes.Length; i++)
		{
			nodes[i].Init();
		}
	}

	private void Update()
	{
		float num = 0f;
		BlendNode[] nodes = Nodes;
		foreach (BlendNode blendNode in nodes)
		{
			if (blendNode != null)
			{
				num += blendNode.Weight;
			}
		}
		if (num == 0f)
		{
			num = 1f;
		}
		Vector3 zero = Vector3.zero;
		nodes = Nodes;
		foreach (BlendNode blendNode2 in nodes)
		{
			if (blendNode2 != null && blendNode2.Object != null)
			{
				blendNode2.NormalizedWeight = blendNode2.Weight / num;
				zero += blendNode2.Object.position * blendNode2.NormalizedWeight;
			}
		}
		GameObject[] followers = Followers;
		foreach (GameObject gameObject in followers)
		{
			if (gameObject != null)
			{
				gameObject.transform.position = zero;
			}
		}
	}
}
