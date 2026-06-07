using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class EnableEmissionAtNightScript : MonoBehaviour
	{
		[ColorUsage(false, true)]
		[SerializeField]
		private Color[] _colors;

		private short _enabled = -1;

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
			short num = (short)(FlightSceneScript.Instance.Environment.IsNight ? 1 : 0);
			if (_enabled < 0 || _enabled != num)
			{
				_enabled = num;
				for (int i = 0; i < _materials.Length; i++)
				{
					_materials[i].SetColor("_EmissionColor", (num > 0) ? _colors[i] : Color.black);
				}
			}
		}
	}
}
