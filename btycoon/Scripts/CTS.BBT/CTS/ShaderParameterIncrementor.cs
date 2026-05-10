using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class ShaderParameterIncrementor : RendererUpdater
	{
		[SerializeField]
		private string _parameterName;

		[SerializeField]
		[MinMaxSlider(0f, 10f)]
		private Vector2 _incrementRange;

		private float _value;

		[field: SerializeField]
		[field: Range(-10f, 10f)]
		public float IncrementSpeed { get; set; }

		public override void Setup()
		{
			_value = _incrementRange.x;
		}

		public override void Execute()
		{
			MaterialLoop();
		}

		protected override void ForEachMaterial(Material material)
		{
			_value += Time.deltaTime * IncrementSpeed;
			while (_value > _incrementRange.y)
			{
				_value -= _incrementRange.y;
			}
			material.SetFloat(_parameterName, _value);
		}
	}
}
