using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace FishNet.Serializing.Helping
{
	internal class SceneComparer : IEqualityComparer<Scene>
	{
		public bool Equals(Scene a, Scene b)
		{
			return false;
		}

		public int GetHashCode(Scene obj)
		{
			return 0;
		}
	}
}
