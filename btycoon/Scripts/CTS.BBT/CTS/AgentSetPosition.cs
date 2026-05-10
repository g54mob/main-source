using UnityEngine;

namespace CTS
{
	public class AgentSetPosition : AgentVisualUpdater
	{
		[SerializeField]
		private ShaderVariable _shaderVariable;

		[SerializeField]
		private Transform _target;

		[SerializeField]
		private Vector3 _offset;

		protected override void Execute(AgentVisual agent)
		{
			agent.SetVector(value: (!_target) ? _offset : (_target.position + _target.rotation * _offset), nameId: _shaderVariable);
		}
	}
}
