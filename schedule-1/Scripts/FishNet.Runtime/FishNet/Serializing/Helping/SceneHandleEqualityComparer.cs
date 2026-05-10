using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace FishNet.Serializing.Helping
{
	internal sealed class SceneHandleEqualityComparer : EqualityComparer<Scene>
	{
		public override bool Equals(Scene a, Scene b)
		{
			return false;
		}

		public override int GetHashCode(Scene obj)
		{
			return 0;
		}
	}
}
