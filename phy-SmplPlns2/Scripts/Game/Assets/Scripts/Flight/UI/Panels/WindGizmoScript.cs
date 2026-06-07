using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class WindGizmoScript : MonoBehaviour
	{
		private const int MaxCones = 9;

		private int _activeCones;

		private List<GameObject> _cones = new List<GameObject>();

		private Vector3 _direction;

		private float _frequencyTimer;

		[SerializeField]
		private float _indexScale = 0.4f;

		[SerializeField]
		private float _maxFrequency = 3f;

		[SerializeField]
		private float _minFrequency = 0.25f;

		[SerializeField]
		private float _spacing = 0.04f;

		private Vector3 _targetDirection;

		[SerializeField]
		private GameObject _windGizmoConePrefab;

		private Vector3 _windGizmoConeScale = Vector3.one;

		private float _windSpeed;

		public void SetWindDirection(Vector3 direction)
		{
			_targetDirection = direction;
		}

		public void SetWindSpeed(float windSpeed)
		{
			_windSpeed = windSpeed;
			Vector3 localPosition = new Vector3(0f, 0f, (float)(-(_activeCones - 1)) / 2f * _spacing);
			for (int i = 0; i < _activeCones; i++)
			{
				_cones[i].SetActive(value: true);
				_cones[i].transform.localPosition = localPosition;
				localPosition.z += _spacing;
			}
		}

		protected virtual void Start()
		{
			_activeCones = 9;
			for (int i = 0; i < 9; i++)
			{
				GameObject gameObject = Object.Instantiate(_windGizmoConePrefab);
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				_windGizmoConeScale = gameObject.transform.localScale * 0.7f;
				_cones.Add(gameObject);
			}
		}

		protected virtual void Update()
		{
			for (int i = 0; i < _activeCones; i++)
			{
				float num = Mathf.Lerp(_minFrequency, _maxFrequency, _windSpeed / 90f);
				_frequencyTimer += Time.deltaTime * num;
				float num2 = Mathf.Sin(0f - _frequencyTimer + (float)i * _indexScale * num);
				float num3 = 1f + num2 * 0.4f * Mathf.Lerp(0f, 1f, _windSpeed / 90f);
				_cones[i].transform.localScale = _windGizmoConeScale * num3;
			}
			float num4 = Vector3.Distance(_direction, _targetDirection);
			_direction = Vector3.MoveTowards(_direction, _targetDirection, Time.unscaledDeltaTime * num4 * 5f);
			base.transform.rotation = Quaternion.LookRotation(_direction);
		}
	}
}
