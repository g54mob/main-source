using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class AgentSetFloat : AgentVisualUpdater
	{
		[SerializeField]
		private ShaderVariable _shaderVariable;

		[SerializeField]
		private float _value;

		[SerializeField]
		private bool _incrementOverTime;

		[SerializeField]
		[ShowIf("_incrementOverTime")]
		[AllowNesting]
		private float _incrementWeight = 1f;

		[SerializeField]
		[ShowIf("_incrementOverTime")]
		[AllowNesting]
		private bool _incrementScaledTime = true;

		private float _time;

		private float _actualValue;

		public override void OnEnable()
		{
			_time = 0f;
			_actualValue = _value;
		}

		protected override void Execute(AgentVisual agent)
		{
			if (_incrementOverTime)
			{
				_actualValue += (_incrementScaledTime ? Time.deltaTime : Time.unscaledDeltaTime) * _incrementWeight;
			}
			agent.SetFloat(_shaderVariable, _actualValue);
		}
	}
}
