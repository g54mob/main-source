using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[AddComponentMenu("")]
	internal class AnimimAnimatorProxy : MonoBehaviour
	{
		[field: NonSerialized]
		public TUnitAnimim Animim { private get; set; }

		private void OnAnimatorIK(int layerIndex)
		{
			Animim?.OnAnimatorIK(layerIndex);
		}

		private void OnAnimatorMove()
		{
			Animim?.OnAnimatorMove();
		}
	}
}
