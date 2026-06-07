using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool ZvYlVBVSYMwejhfetDIOHxzZDWJOA;

		public void Awake()
		{
			ZvYlVBVSYMwejhfetDIOHxzZDWJOA = new ooqJkpsBSWIDQBazgNVCPOfbzfkO();
			ZvYlVBVSYMwejhfetDIOHxzZDWJOA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			ZvYlVBVSYMwejhfetDIOHxzZDWJOA.Start();
		}

		public void Update()
		{
			ZvYlVBVSYMwejhfetDIOHxzZDWJOA.Update();
		}

		public void OnDestroy()
		{
			ZvYlVBVSYMwejhfetDIOHxzZDWJOA.OnDestroy();
		}
	}
}
