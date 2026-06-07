using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtPoolComponent : SgtLinkedBehaviour<SgtPoolComponent>
	{
		public string TypeName;

		public List<Component> Elements;

		protected virtual void OnDestroy()
		{
		}
	}
}
