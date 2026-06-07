using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(LineRenderer))]
	public class RegionBorder : MonoBehaviour
	{
		public List<Transform> borderNodes;
	}
}
