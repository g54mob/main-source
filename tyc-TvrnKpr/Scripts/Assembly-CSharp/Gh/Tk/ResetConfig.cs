using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(GameObjectX))]
	public class ResetConfig : MonoBehaviour
	{
		public List<Transform> transformsToEnable;

		public List<Transform> transformsToDisable;

		public void Reset()
		{
		}
	}
}
