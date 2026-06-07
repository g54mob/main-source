using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool eZcrulBsDSInsGfzJtutfMUhBOOGA;

		public void Awake()
		{
			eZcrulBsDSInsGfzJtutfMUhBOOGA = new JyIBiZiVRImIXkZoMnljBdMNCzzDA();
			eZcrulBsDSInsGfzJtutfMUhBOOGA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			eZcrulBsDSInsGfzJtutfMUhBOOGA.Start();
		}

		public void Update()
		{
			eZcrulBsDSInsGfzJtutfMUhBOOGA.Update();
		}

		public void OnDestroy()
		{
			eZcrulBsDSInsGfzJtutfMUhBOOGA.OnDestroy();
		}
	}
}
