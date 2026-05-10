using System.Collections.Generic;
using UnityEngine;

namespace RadiantGI.Universal
{
	[ExecuteInEditMode]
	public class RadiantVirtualEmitter : MonoBehaviour
	{
		[Header("GI Color")]
		[ColorUsage(false, true)]
		public Color color;

		[Tooltip("Enable this option to add the emission color of the material used by this object to the global illumination.")]
		public bool addMaterialEmission;

		[Tooltip("The renderer from which synchronize the emission color")]
		public Renderer targetRenderer;

		[Tooltip("Optionally specify the material for the emission color")]
		public Material material;

		public string emissionPropertyName;

		[Tooltip("Useful in case the gameobject uses more than one material")]
		public int materialIndex;

		public float intensity;

		public float range;

		[Header("Area Of Influence")]
		public Vector3 boxCenter;

		public Vector3 boxSize;

		public bool boundsInLocalSpace;

		private int emissionNameId;

		private Renderer thisRenderer;

		private static List<Material> sharedMaterials;

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public Color GetGIColor()
		{
			return default(Color);
		}

		public Vector4 GetGIColorAndRange()
		{
			return default(Vector4);
		}

		public Bounds GetBounds()
		{
			return default(Bounds);
		}

		public void SetBounds(Bounds bounds)
		{
		}
	}
}
