using System;
using Motorways.Constants;
using UnityEngine;

namespace Motorways.Views
{
	[ExecuteAlways]
	public class HeadlightBeam : MonoBehaviour
	{
		[Range(0f, 20f)]
		public float beamLength;

		[Range(0f, 179.99f)]
		public float beamAngle;

		public Vector2 leftCutPoint;

		public float cutAngle;

		public float cutLength;

		private Renderer _headlightBeams;

		private MaterialPropertyBlock _materialPropertyBlock;

		public Vector2 beamOrigin;

		public Vector2 RightCutPoint => leftCutPoint + new Vector2(Mathf.Cos(cutAngle * ((float)Math.PI / 180f)), Mathf.Sin(cutAngle * ((float)Math.PI / 180f))) * cutLength;

		private void UpdatePosition()
		{
			if (_materialPropertyBlock == null)
			{
				_materialPropertyBlock = new MaterialPropertyBlock();
			}
			_headlightBeams.GetPropertyBlock(_materialPropertyBlock);
			Transform transform = base.transform;
			_materialPropertyBlock.SetMatrix(ShaderConstants.ObjectToLocalMatrix, transform.parent.worldToLocalMatrix * transform.localToWorldMatrix);
			_headlightBeams.SetPropertyBlock(_materialPropertyBlock);
		}

		private void OnEnable()
		{
			_headlightBeams = GetComponent<Renderer>();
			UpdatePosition();
		}

		private void Update()
		{
			UpdatePosition();
		}
	}
}
