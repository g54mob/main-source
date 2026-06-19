using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool FAOYNIruyIMaZYDGgeJzjcpoeVLNA;

		public void Awake()
		{
			FAOYNIruyIMaZYDGgeJzjcpoeVLNA = new kOgVqfOcjKNquuTyxQzAGtlWqeGB();
			FAOYNIruyIMaZYDGgeJzjcpoeVLNA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			FAOYNIruyIMaZYDGgeJzjcpoeVLNA.Start();
		}

		public void Update()
		{
			FAOYNIruyIMaZYDGgeJzjcpoeVLNA.Update();
		}

		public void OnDestroy()
		{
			FAOYNIruyIMaZYDGgeJzjcpoeVLNA.OnDestroy();
		}
	}
}
