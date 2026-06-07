using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool YsGTIVFWVtOVYCvVsHJEYzEuABNO;

		public void Awake()
		{
			YsGTIVFWVtOVYCvVsHJEYzEuABNO = new ldCOHIVPwsuScSoDQlVVIxYZwLne();
			YsGTIVFWVtOVYCvVsHJEYzEuABNO.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			YsGTIVFWVtOVYCvVsHJEYzEuABNO.Start();
		}

		public void Update()
		{
			YsGTIVFWVtOVYCvVsHJEYzEuABNO.Update();
		}

		public void OnDestroy()
		{
			YsGTIVFWVtOVYCvVsHJEYzEuABNO.OnDestroy();
		}
	}
}
