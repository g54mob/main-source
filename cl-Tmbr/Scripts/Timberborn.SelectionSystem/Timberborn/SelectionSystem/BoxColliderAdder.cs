using Timberborn.BaseComponentSystem;
using Timberborn.Common;
using UnityEngine;

namespace Timberborn.SelectionSystem
{
	internal class BoxColliderAdder : BaseComponent, IStartableComponent
	{
		public void Start()
		{
			AddCollider();
		}

		private void AddCollider()
		{
			BoxColliderAdderSpec component = GetComponent<BoxColliderAdderSpec>();
			BoxCollider boxCollider = base.GameObject.FindChild(component.TargetName).gameObject.AddComponent<BoxCollider>();
			boxCollider.center = component.Center;
			boxCollider.size = component.Size;
		}
	}
}
