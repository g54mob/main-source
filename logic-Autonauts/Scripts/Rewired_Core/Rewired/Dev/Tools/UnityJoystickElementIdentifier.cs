using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool wiTBqirJxgunqDtGTgkxTCeSabZG;

		public void Awake()
		{
			wiTBqirJxgunqDtGTgkxTCeSabZG = new ZoBmmpfqvlKEIRhdhNYsNLNprUb();
			wiTBqirJxgunqDtGTgkxTCeSabZG.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			wiTBqirJxgunqDtGTgkxTCeSabZG.Start();
		}

		public void Update()
		{
			wiTBqirJxgunqDtGTgkxTCeSabZG.Update();
		}

		public void OnDestroy()
		{
			wiTBqirJxgunqDtGTgkxTCeSabZG.OnDestroy();
		}
	}
}
