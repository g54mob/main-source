using System;
using UnityEngine;

namespace SimulationScripts.Rendering
{
	public class SetRotationToShader : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer sr;

		private Material mat;

		private static readonly int Rotation = Shader.PropertyToID("_rotation");

		private void Start()
		{
			if (sr == null)
			{
				sr = GetComponent<SpriteRenderer>();
			}
			mat = sr.material;
		}

		private void OnWillRenderObject()
		{
			mat.SetFloat(Rotation, -MathF.PI / 180f * base.transform.eulerAngles.z);
		}
	}
}
