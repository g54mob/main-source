using System;
using System.Collections.Generic;
using UnityEngine;

namespace HighlightPlus
{
	[ExecuteInEditMode]
	public class HighlightSeeThroughOccluder : MonoBehaviour
	{
		public OccluderMode mode;

		public DetectionMethod detectionMethod;

		[NonSerialized]
		public MeshData[] meshData;

		private List<Renderer> rr;

		private void OnEnable()
		{
		}

		private void Init()
		{
		}

		private void OnDisable()
		{
		}
	}
}
