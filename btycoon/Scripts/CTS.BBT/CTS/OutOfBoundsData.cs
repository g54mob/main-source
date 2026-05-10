using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class OutOfBoundsData : CTSBehaviour
	{
		[SerializeField]
		private Vector3[] _positions;

		[SerializeField]
		private float _noiseStrength = 0.5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _distanceInfluence = 0.1f;

		[SerializeField]
		[Range(0f, 3f)]
		private float _distanceMultiply = 0.1f;

		private readonly Vector4[] _arrayToSend = new Vector4[10];

		private static readonly int _OOBCenters = Shader.PropertyToID("OutOfBoundsCenters");

		private static readonly int _OOBenterCount = Shader.PropertyToID("OutOfBoundsCenterCount");

		private static readonly int _OOBNoise = Shader.PropertyToID("OutOfBoundsNoise");

		private static readonly int _OOBInfluence = Shader.PropertyToID("OutOfBoundsDistanceInfluence");

		private static readonly int _OOBDistanceMultiply = Shader.PropertyToID("OutOfBoundsDistanceMultiply");

		protected override void OnAwake()
		{
			UpdateShader();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateShader()
		{
			if (_positions != null)
			{
				if (_positions.Length > 10)
				{
					throw new IndexOutOfRangeException("Cannot set more than 10 positions in the Out of Bounds Data");
				}
				for (int i = 0; i < _positions.Length; i++)
				{
					_arrayToSend[i] = _positions[i];
				}
				Shader.SetGlobalVectorArray(_OOBCenters, _arrayToSend);
				Shader.SetGlobalInteger(_OOBenterCount, _positions.Length);
				Shader.SetGlobalFloat(_OOBNoise, _noiseStrength);
				Shader.SetGlobalFloat(_OOBInfluence, _distanceInfluence);
				Shader.SetGlobalFloat(_OOBDistanceMultiply, _distanceMultiply);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (_positions != null)
			{
				Gizmos.color = Color.red;
				Vector3[] positions = _positions;
				for (int i = 0; i < positions.Length; i++)
				{
					Gizmos.DrawWireSphere((Vector4)positions[i], 1f);
				}
			}
		}

		private void OnValidate()
		{
			UpdateShader();
		}
	}
}
