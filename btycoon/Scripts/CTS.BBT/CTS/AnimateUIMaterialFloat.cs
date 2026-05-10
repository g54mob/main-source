using UnityEngine;

namespace CTS
{
	public class AnimateUIMaterialFloat : AnimateUIMaterial
	{
		[SerializeField]
		private ShaderVariable _shaderVariable;

		[SerializeField]
		private float _floatValue;

		[SerializeField]
		private bool _resetToDefaultWhenInactive;

		private float _defaultValue;

		protected override void OnAwake()
		{
			base.OnAwake();
			_defaultValue = base.Material.GetFloat(_shaderVariable);
		}

		private void Update()
		{
			base.Material.SetFloat(_shaderVariable, _floatValue);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (_resetToDefaultWhenInactive)
			{
				base.Material.SetFloat(_shaderVariable, _defaultValue);
			}
		}
	}
}
