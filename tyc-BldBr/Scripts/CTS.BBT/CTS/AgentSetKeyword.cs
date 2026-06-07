using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace CTS
{
	[Serializable]
	public class AgentSetKeyword : AgentVisualUpdater
	{
		[SerializeField]
		private string _name = "";

		[SerializeField]
		private bool _keywordValue;

		private LocalKeyword? _localKeyword;

		protected override void Execute(AgentVisual agent)
		{
			LocalKeyword valueOrDefault = _localKeyword.GetValueOrDefault();
			if (!_localKeyword.HasValue)
			{
				valueOrDefault = new LocalKeyword(AgentVisual.ToonShader, _name);
				_localKeyword = valueOrDefault;
			}
			agent.SetKeyword(_localKeyword.Value, _keywordValue);
		}
	}
}
