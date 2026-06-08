using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool NhVPPvZKOcTaxmGjUWBgRnEXHaeD;

		public void Awake()
		{
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD = new spBBieTDEjAXVoJIoAvlDgncYNW();
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Start();
		}

		public void Update()
		{
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Update();
		}

		public void OnDestroy()
		{
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD.OnDestroy();
		}
	}
}
