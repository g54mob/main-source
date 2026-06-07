using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("Crest/Sample/Crest Sample Displacement Demo")]
	internal sealed class SampleDisplacementDemo : ManagedBehaviour<WaterRenderer>
	{
		[Tooltip("Which water collision layer to target.")]
		[SerializeField]
		private CollisionLayer _Layer;

		[SerializeField]
		private bool _TrackCamera = true;

		[RangeAttribute(0f, 32f)]
		[SerializeField]
		private float _MinimumGridSize;

		private readonly GameObject[] _MarkerObjects = new GameObject[3];

		private readonly Vector3[] _MarkerPosition = new Vector3[3];

		private readonly Vector3[] _ResultDisplacement = new Vector3[3];

		private readonly Vector3[] _ResultNormal = new Vector3[3];

		private readonly Vector3[] _ResultVelocity = new Vector3[3];

		private readonly float _SamplesRadius = 5f;

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private void OnUpdate(WaterRenderer water)
		{
			if (_TrackCamera)
			{
				float num = Mathf.Abs(Camera.main.transform.position.y - water.SeaLevel);
				float num2 = Mathf.Max(Mathf.Abs(Camera.main.transform.forward.y), 0.001f);
				float num3 = num / num2;
				_MarkerPosition[0] = Camera.main.transform.position + Camera.main.transform.forward * num3;
				_MarkerPosition[1] = Camera.main.transform.position + Camera.main.transform.forward * num3 + _SamplesRadius * Vector3.right;
				_MarkerPosition[2] = Camera.main.transform.position + Camera.main.transform.forward * num3 + _SamplesRadius * Vector3.forward;
			}
			ICollisionProvider provider = water.AnimatedWavesLod.Provider;
			int status = provider.Query(GetHashCode(), _MinimumGridSize, _MarkerPosition, _ResultDisplacement, _ResultNormal, _ResultVelocity, _Layer);
			if (!provider.RetrieveSucceeded(status))
			{
				return;
			}
			for (int i = 0; i < _ResultDisplacement.Length; i++)
			{
				if (_MarkerObjects[i] == null)
				{
					_MarkerObjects[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
					Helpers.Destroy(_MarkerObjects[i].GetComponent<Collider>());
					_MarkerObjects[i].transform.localScale = Vector3.one * 0.5f;
				}
				Vector3 vector = _MarkerPosition[i];
				vector.y = water.SeaLevel;
				Vector3 vector2 = _ResultDisplacement[i];
				Vector3 vector3 = vector;
				vector3.y = vector2.y;
				Debug.DrawLine(vector3, vector3 - vector2);
				_MarkerObjects[i].transform.SetPositionAndRotation(vector3, Quaternion.FromToRotation(Vector3.up, _ResultNormal[i]));
			}
			for (int j = 0; j < _ResultNormal.Length; j++)
			{
				Debug.DrawLine(_MarkerObjects[j].transform.position, _MarkerObjects[j].transform.position + _ResultNormal[j], Color.blue);
			}
			for (int k = 0; k < _ResultVelocity.Length; k++)
			{
				Debug.DrawLine(_MarkerObjects[k].transform.position, _MarkerObjects[k].transform.position + _ResultVelocity[k], Color.green);
			}
		}
	}
}
