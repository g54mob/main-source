using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Layers
{
	public abstract class HideLayerBase : MonoBehaviour
	{
		protected bool ShadowsAvailable = true;

		[SerializeField]
		private List<Collider> colliders = new List<Collider>();

		[SerializeField]
		private float offset;

		private float elevationLevel;

		public float Offset => offset;

		public List<Collider> Colliders => colliders;

		public float GetElevation()
		{
			return elevationLevel;
		}

		public virtual void HideMapObject(float realWorldLevel)
		{
			Collider[] array = colliders.ToArray();
			foreach (Collider collider in array)
			{
				if (collider == null)
				{
					colliders.Remove(collider);
				}
				else
				{
					collider.enabled = false;
				}
			}
		}

		public virtual void ShowMapObject(float realWorldLevel)
		{
			Collider[] array = colliders.ToArray();
			foreach (Collider collider in array)
			{
				if (collider == null)
				{
					colliders.Remove(collider);
				}
				else
				{
					collider.enabled = true;
				}
			}
		}

		protected void SetElevation(float elevationLevel)
		{
			this.elevationLevel = elevationLevel;
		}

		protected virtual void ShowMesh(MeshRenderer[] meshes)
		{
			foreach (MeshRenderer meshRenderer in meshes)
			{
				if (!(meshRenderer == null))
				{
					if (ShadowsAvailable)
					{
						meshRenderer.shadowCastingMode = ShadowCastingMode.On;
					}
					else
					{
						meshRenderer.enabled = true;
					}
				}
			}
		}

		protected virtual void HideMesh(MeshRenderer[] meshes)
		{
			foreach (MeshRenderer meshRenderer in meshes)
			{
				if (!(meshRenderer == null))
				{
					if (ShadowsAvailable)
					{
						meshRenderer.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
					}
					else
					{
						meshRenderer.enabled = false;
					}
				}
			}
		}

		protected static bool Equal(float a, float b)
		{
			return Math.Abs(a - b) < 0.1f;
		}
	}
}
