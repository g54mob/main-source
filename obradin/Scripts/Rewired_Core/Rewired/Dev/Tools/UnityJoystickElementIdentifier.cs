using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool JuXlVpBNvqGhNlCHbkodwVeYqoI;

		public void Awake()
		{
			JuXlVpBNvqGhNlCHbkodwVeYqoI = new kpDhpqDOpflhbpqcXmUaqQLlTBq();
			JuXlVpBNvqGhNlCHbkodwVeYqoI.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			JuXlVpBNvqGhNlCHbkodwVeYqoI.Start();
		}

		public void Update()
		{
			JuXlVpBNvqGhNlCHbkodwVeYqoI.Update();
		}

		public void OnDestroy()
		{
			JuXlVpBNvqGhNlCHbkodwVeYqoI.OnDestroy();
		}
	}
}
