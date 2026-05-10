using System;
using UnityEngine;

[DefaultExecutionOrder(-20)]
public class LODSetup : MonoBehaviour
{
	[Serializable]
	private struct LODSetupDefinition
	{
		public int ID;

		public int Capacity;

		public float[] Distances;
	}

	[SerializeField]
	private LODSetupDefinition[] m_Definitions;

	[SerializeField]
	private Camera m_Camera;

	private void Awake()
	{
	}
}
