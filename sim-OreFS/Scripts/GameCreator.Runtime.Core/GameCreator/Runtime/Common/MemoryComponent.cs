using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconComponent), ColorTheme.Type.Green)]
	[Title("Component Enabled")]
	[Category("Game Object/Component Enabled")]
	[Description("Remembers if the specified component of the object is enabled")]
	public class MemoryComponent : Memory
	{
		[SerializeField]
		private TypeReferenceBehaviour m_Component = new TypeReferenceBehaviour();

		public override string Title => $"Is {m_Component} Enabled";

		public override Token GetToken(GameObject target)
		{
			return new TokenComponent(GetBehaviour(target));
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenComponent tokenComponent)
			{
				Behaviour behaviour = GetBehaviour(target);
				if (behaviour != null)
				{
					behaviour.enabled = tokenComponent.Enabled;
				}
			}
		}

		private Behaviour GetBehaviour(GameObject target)
		{
			if (!(target.Get(m_Component.Type) is Behaviour result))
			{
				return null;
			}
			return result;
		}
	}
}
