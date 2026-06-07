using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool ljOVHAbUhpcgmnejRcvuZgjrYVHt;

		public void Awake()
		{
			ljOVHAbUhpcgmnejRcvuZgjrYVHt = new SZQINXtHteyLWtnGxgZphVQOpmrib();
			ljOVHAbUhpcgmnejRcvuZgjrYVHt.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			ljOVHAbUhpcgmnejRcvuZgjrYVHt.Start();
		}

		public void Update()
		{
			ljOVHAbUhpcgmnejRcvuZgjrYVHt.Update();
		}

		public void OnDestroy()
		{
			ljOVHAbUhpcgmnejRcvuZgjrYVHt.OnDestroy();
		}
	}
}
