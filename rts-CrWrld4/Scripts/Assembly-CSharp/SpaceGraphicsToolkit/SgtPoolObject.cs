using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtPoolObject : SgtLinkedBehaviour<SgtPoolObject>
	{
		public string TypeName;

		public List<Object> Elements;

		protected virtual void OnDestroy()
		{
		}
	}
}
