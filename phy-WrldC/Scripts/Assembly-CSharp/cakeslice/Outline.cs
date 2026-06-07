using UnityEngine;

namespace cakeslice
{
	[RequireComponent(typeof(Renderer))]
	public class Outline : MonoBehaviour
	{
		public int color;

		public bool eraseRenderer;

		[HideInInspector]
		public int objectLayerMask = int.MaxValue;

		private Material[] _SharedMaterials;

		public Renderer Renderer { get; private set; }

		public SkinnedMeshRenderer SkinnedMeshRenderer { get; private set; }

		public MeshFilter MeshFilter { get; private set; }

		public Material[] SharedMaterials
		{
			get
			{
				if (_SharedMaterials == null)
				{
					_SharedMaterials = Renderer.sharedMaterials;
				}
				return _SharedMaterials;
			}
		}

		private void Awake()
		{
			Renderer = GetComponent<Renderer>();
			SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
			MeshFilter = GetComponent<MeshFilter>();
			if (objectLayerMask == int.MaxValue)
			{
				objectLayerMask = 1 << base.gameObject.layer;
			}
		}

		private void OnEnable()
		{
			foreach (OutlineEffect instance in OutlineEffect.Instances)
			{
				instance.AddOutline(this);
			}
		}

		private void OnDisable()
		{
			foreach (OutlineEffect instance in OutlineEffect.Instances)
			{
				instance.RemoveOutline(this);
			}
		}
	}
}
