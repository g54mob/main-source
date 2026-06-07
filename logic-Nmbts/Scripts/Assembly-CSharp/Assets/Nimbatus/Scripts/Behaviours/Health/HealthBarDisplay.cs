using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public class HealthBarDisplay : MonoBehaviour
	{
		private HealthPool _hp;

		private SpriteRenderer _renderer;

		public void Awake()
		{
			_renderer = GetComponent<SpriteRenderer>();
		}

		public void Init(HealthPool hp)
		{
			_hp = hp;
		}

		public void Update()
		{
			if (_hp != null && _hp.ActiveMaxHealth > 0f)
			{
				float value = Mathf.Clamp01(_hp.CurrentHealth / _hp.ActiveMaxHealth);
				_renderer.material.SetFloat("_Percentage", value);
			}
		}
	}
}
