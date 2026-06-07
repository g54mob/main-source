using System;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub
{
	public class FreighterAnimationEvents : MonoBehaviour
	{
		public event Action<int> OnUpdateCrateResource = delegate
		{
		};

		public void ChangeCrateResource(int index)
		{
			this.OnUpdateCrateResource(index);
		}
	}
}
