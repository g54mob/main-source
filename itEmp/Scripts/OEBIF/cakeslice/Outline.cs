using UnityEngine;

namespace cakeslice
{
	[RequireComponent(typeof(Renderer))]
	public class Outline : MonoBehaviour
	{
		public int color;

		public bool eraseRenderer;

		private Material[] _SharedMaterials;

		public Renderer Renderer { get; private set; }

		public SpriteRenderer SpriteRenderer { get; private set; }

		public SkinnedMeshRenderer SkinnedMeshRenderer { get; private set; }

		public MeshFilter MeshFilter { get; private set; }

		public Material[] SharedMaterials => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
