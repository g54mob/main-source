using System.Collections.Generic;
using UnityEngine;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	internal sealed class PrefabSpawner : MonoBehaviour
	{
		private enum Mode
		{
			OnStart = 0,
			OnDemand = 1
		}

		[SerializeField]
		private GameObject _Prefab;

		[SerializeField]
		private Mode _Mode;

		[SerializeField]
		private bool _DestroyInstances = true;

		[SerializeField]
		private bool _SpawnAsChild = true;

		[SerializeField]
		private bool _RandomizePosition;

		[SerializeField]
		private float _RandomizePositionSphericalSize = 1f;

		private readonly List<GameObject> _Instances = new List<GameObject>();

		private void Start()
		{
			if (_Mode != Mode.OnDemand)
			{
				Execute();
			}
		}

		private void OnDestroy()
		{
			if (!_DestroyInstances)
			{
				return;
			}
			foreach (GameObject instance in _Instances)
			{
				Object.Destroy(instance);
			}
		}

		public void Execute()
		{
			GameObject gameObject = Object.Instantiate(_Prefab);
			gameObject.transform.SetPositionAndRotation(base.transform.position + (_RandomizePosition ? (Random.insideUnitSphere * _RandomizePositionSphericalSize) : Vector3.zero), base.transform.rotation);
			gameObject.transform.localScale = base.transform.localScale;
			if (_SpawnAsChild)
			{
				gameObject.transform.SetParent(base.transform, worldPositionStays: true);
			}
			_Instances.Add(gameObject);
		}
	}
}
