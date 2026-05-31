using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class AgentSetColor : AgentVisualUpdater
	{
		[SerializeField]
		private ShaderVariable _shaderVariable;

		[SerializeField]
		private Color _color;

		protected override void Execute(AgentVisual agent)
		{
			agent.SetColor(_shaderVariable, _color);
		}
	}
}
