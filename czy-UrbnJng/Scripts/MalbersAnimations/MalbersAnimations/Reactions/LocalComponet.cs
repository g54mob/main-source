using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	public struct LocalComponet
	{
		public bool useLocal;

		[RequiredField]
		public Component component;
	}
}
