using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtSharedMaterial : MonoBehaviour
	{
		[SerializeField]
		private Material material;

		[SerializeField]
		private List<Renderer> renderers;

		public Material Material
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int RendererCount => 0;

		public void ApplyMaterial()
		{
		}

		public void RemoveMaterial()
		{
		}

		public void AddRenderer(Renderer renderer)
		{
		}

		public void RemoveRenderer(Renderer renderer)
		{
		}

		public void RemoveNullRenderers()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
