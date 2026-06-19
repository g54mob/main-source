using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool NuSUCGZLzYJQRRtHbKwdvZMVsDb;

		public void Awake()
		{
			NuSUCGZLzYJQRRtHbKwdvZMVsDb = new mQlGRRnbLWhhTtcJnIqlEtsWmB();
			NuSUCGZLzYJQRRtHbKwdvZMVsDb.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			NuSUCGZLzYJQRRtHbKwdvZMVsDb.Start();
		}

		public void Update()
		{
			NuSUCGZLzYJQRRtHbKwdvZMVsDb.Update();
		}

		public void OnDestroy()
		{
			NuSUCGZLzYJQRRtHbKwdvZMVsDb.OnDestroy();
		}
	}
}
