using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct VisualBody
	{
		[field: SerializeField]
		public EGender Gender { get; private set; }

		[field: SerializeField]
		public ReferenceDispatcher Body { get; private set; }
	}
}
