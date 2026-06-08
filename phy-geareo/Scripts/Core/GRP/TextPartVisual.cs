using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class TextPartVisual : MonoBehaviour
	{
		public LettersConfig config;

		public MeshFilter meshFilter;

		public MeshRenderer rend;

		public Transform cursor;

		public GameObject colliderObj;

		private MaterialPropertyBlock materialBlock;

		public BoxCollider[] cols;

		private Dictionary<char, Mesh> lettersSource;

		private Dictionary<char, Mesh> newSource;

		private TextPartVisualOptions options;

		public void Setup()
		{
		}

		public void Build(TextPartVisualOptions op)
		{
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}
	}
}
