using System;
using UnityEngine;

namespace JUTPS.Utilities
{
	[Serializable]
	public class GizmosSettings
	{
		[HideInInspector]
		public string ResourcesPath;

		public Color GizmosColor = new Color(0f, 0f, 0f, 0.5f);

		public Color WireGizmosColor = new Color(0.9f, 0.4f, 0.2f, 0.5f);

		public Mesh StepVisualizerMesh;
	}
}
