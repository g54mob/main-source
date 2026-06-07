using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool nhujvekTWLfTVOztukLkjNhnRWD;

		public void Awake()
		{
			nhujvekTWLfTVOztukLkjNhnRWD = new GoulwhsaGIMkbOYWWKWtbgAYarv();
			nhujvekTWLfTVOztukLkjNhnRWD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			nhujvekTWLfTVOztukLkjNhnRWD.Start();
		}

		public void Update()
		{
			nhujvekTWLfTVOztukLkjNhnRWD.Update();
		}

		public void OnDestroy()
		{
			nhujvekTWLfTVOztukLkjNhnRWD.OnDestroy();
		}
	}
}
