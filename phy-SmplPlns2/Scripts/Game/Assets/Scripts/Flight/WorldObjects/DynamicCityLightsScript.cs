using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class DynamicCityLightsScript : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve _dayMasking;

		[SerializeField]
		private AnimationCurve[] _distributions;

		private Material[] _materialOriginalCopies;

		[SerializeField]
		private Material[] _materials;

		protected virtual void Awake()
		{
			_materialOriginalCopies = new Material[_materials.Length];
			for (int i = 0; i < _materialOriginalCopies.Length; i++)
			{
				_materialOriginalCopies[i] = Object.Instantiate(_materials[i]);
			}
		}

		protected virtual void OnDestroy()
		{
			for (int i = 0; i < _materialOriginalCopies.Length; i++)
			{
				if (_materialOriginalCopies[i] != null)
				{
					if (_materials[i] != null)
					{
						_materials[i].CopyPropertiesFromMaterial(_materialOriginalCopies[i]);
					}
					Object.Destroy(_materialOriginalCopies[i]);
				}
			}
		}

		protected virtual void Update()
		{
			float timeOfDay = FlightSceneScript.Instance.Environment.TimeOfDay;
			for (int i = 0; i < _materials.Length; i++)
			{
				_materials[i].SetFloat("_EmissiveThreshold", _distributions[i].Evaluate(timeOfDay));
				_materials[i].SetFloat("_DayMasking", _dayMasking.Evaluate(timeOfDay));
			}
		}
	}
}
