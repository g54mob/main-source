using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Debug/Crest Collision Area Visualizer")]
	public sealed class CollisionAreaVisualizer : ManagedBehaviour<WaterRenderer>
	{
		[Tooltip("Which water collision layer to target.")]
		[SerializeField]
		internal CollisionLayer _Layer;

		[SerializeField]
		private float _ObjectWidth;

		[SerializeField]
		private float _StepSize = 5f;

		[SerializeField]
		private int _Steps = 10;

		[SerializeField]
		private bool _UseDisplacements;

		[SerializeField]
		private bool _UseNormals;

		private float[] _ResultHeights;

		private Vector3[] _ResultDisplacements;

		private Vector3[] _ResultNormals;

		private Vector3[] _SamplePositions;

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private void OnUpdate(WaterRenderer water)
		{
			if (water.AnimatedWavesLod.Provider == null)
			{
				return;
			}
			if (_ResultHeights == null || _ResultHeights.Length != _Steps * _Steps)
			{
				_ResultHeights = new float[_Steps * _Steps];
			}
			if (_ResultDisplacements == null || _ResultDisplacements.Length != _Steps * _Steps)
			{
				_ResultDisplacements = new Vector3[_Steps * _Steps];
			}
			if (_ResultNormals == null || _ResultNormals.Length != _Steps * _Steps)
			{
				_ResultNormals = new Vector3[_Steps * _Steps];
				for (int i = 0; i < _ResultNormals.Length; i++)
				{
					_ResultNormals[i] = Vector3.up;
				}
			}
			if (_SamplePositions == null || _SamplePositions.Length != _Steps * _Steps)
			{
				_SamplePositions = new Vector3[_Steps * _Steps];
			}
			ICollisionProvider provider = water.AnimatedWavesLod.Provider;
			for (int j = 0; j < _Steps; j++)
			{
				for (int k = 0; k < _Steps; k++)
				{
					_SamplePositions[k * _Steps + j] = new Vector3(((float)j + 0.5f - (float)_Steps / 2f) * _StepSize, 0f, ((float)k + 0.5f - (float)_Steps / 2f) * _StepSize);
					_SamplePositions[k * _Steps + j].x += base.transform.position.x;
					_SamplePositions[k * _Steps + j].z += base.transform.position.z;
				}
			}
			if (_UseDisplacements ? provider.RetrieveSucceeded(provider.Query(GetHashCode(), _ObjectWidth, _SamplePositions, _ResultDisplacements, _UseNormals ? _ResultNormals : null, null, _Layer)) : provider.RetrieveSucceeded(provider.Query(GetHashCode(), _ObjectWidth, _SamplePositions, _ResultHeights, _UseNormals ? _ResultNormals : null, null, _Layer)))
			{
				Render(water, Debug.DrawLine);
			}
		}

		internal void Render(WaterRenderer water, DebugUtility.DrawLine draw)
		{
			if (_SamplePositions == null)
			{
				return;
			}
			for (int i = 0; i < _Steps; i++)
			{
				for (int j = 0; j < _Steps; j++)
				{
					Vector3 position = _SamplePositions[j * _Steps + i];
					if (_UseDisplacements)
					{
						position.y = water.SeaLevel;
						position += _ResultDisplacements[j * _Steps + i];
					}
					else
					{
						position.y = _ResultHeights[j * _Steps + i];
					}
					Vector3 up = (_UseNormals ? _ResultNormals[j * _Steps + i] : Vector3.up);
					DebugUtility.DrawCross(draw, position, up, Mathf.Min(_StepSize / 4f, 1f), Color.green);
				}
			}
		}
	}
}
