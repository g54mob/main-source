using System;
using UnityEngine;

namespace VRTK
{
	[Obsolete("`InteractControllerAppearanceEventArgs` will be removed in a future version of VRTK.")]
	public struct InteractControllerAppearanceEventArgs
	{
		public GameObject interactingObject;

		public GameObject ignoredObject;
	}
}
