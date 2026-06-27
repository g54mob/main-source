using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool INxdNMKXRQPSEJhqSCnEjYscsukHA;

		public void Awake()
		{
			INxdNMKXRQPSEJhqSCnEjYscsukHA = new dQFRRkpuRSelxbLxNdmOgUoImHJV();
			INxdNMKXRQPSEJhqSCnEjYscsukHA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			INxdNMKXRQPSEJhqSCnEjYscsukHA.Start();
		}

		public void Update()
		{
			INxdNMKXRQPSEJhqSCnEjYscsukHA.Update();
		}

		public void OnDestroy()
		{
			INxdNMKXRQPSEJhqSCnEjYscsukHA.OnDestroy();
		}
	}
}
