using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool HMMTPhFMOtbGLXTguOcliNqYugKi;

		public void Awake()
		{
			HMMTPhFMOtbGLXTguOcliNqYugKi = new qIuhPDwAAnDIailbndXlSAseAPrlA();
			HMMTPhFMOtbGLXTguOcliNqYugKi.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			HMMTPhFMOtbGLXTguOcliNqYugKi.Start();
		}

		public void Update()
		{
			HMMTPhFMOtbGLXTguOcliNqYugKi.Update();
		}

		public void OnDestroy()
		{
			HMMTPhFMOtbGLXTguOcliNqYugKi.OnDestroy();
		}
	}
}
