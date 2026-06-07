using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool DgRApMARcNKEeBbWIjoMYUtRAuFB;

		public void Awake()
		{
			DgRApMARcNKEeBbWIjoMYUtRAuFB = new upnVADhOXFcrhhTaNBqgauAtnjJdb();
			DgRApMARcNKEeBbWIjoMYUtRAuFB.Initialize(GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			DgRApMARcNKEeBbWIjoMYUtRAuFB.Start();
		}

		public void Update()
		{
			DgRApMARcNKEeBbWIjoMYUtRAuFB.Update();
		}

		public void OnDestroy()
		{
			DgRApMARcNKEeBbWIjoMYUtRAuFB.OnDestroy();
		}
	}
}
