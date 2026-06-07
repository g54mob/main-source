using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class MenuSunScript : MonoBehaviour
	{
		private float _eclipse;

		private Material _material;

		[SerializeField]
		private Material _materialHigh;

		[SerializeField]
		private Material _materialLow;

		public float Eclipse
		{
			get
			{
				return _eclipse;
			}
			set
			{
				_eclipse = Mathf.Clamp01(value);
				_material.SetFloat("_DetailOpacity", 1f - _eclipse);
			}
		}

		protected virtual void OnDestroy()
		{
			if (_material != null)
			{
				Object.Destroy(_material);
			}
		}

		protected virtual void Start()
		{
			if (Game.Instance.QualitySettings.VisualEffects.MainMenuSun.Value == VisualEffectsQualitySettings.MenuSunQuality.High)
			{
				_material = Object.Instantiate(_materialHigh);
			}
			else
			{
				_material = Object.Instantiate(_materialLow);
			}
			GetComponent<MeshRenderer>().material = _material;
			Eclipse = 1f;
		}
	}
}
