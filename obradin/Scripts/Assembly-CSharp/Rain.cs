using System;
using UnityEngine;

public class Rain : MonoBehaviour
{
	[Serializable]
	public class Spec
	{
		public float separation;

		public Dust.Shade shade;

		public string sourceAssetPath;

		public bool lightning;

		public bool splashes;
	}

	public Spec spec;
}
