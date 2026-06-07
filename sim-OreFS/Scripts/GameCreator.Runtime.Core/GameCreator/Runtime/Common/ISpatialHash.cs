using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public interface ISpatialHash
	{
		Vector3 Position => ((Component)this).transform.position;

		int UniqueCode => ((Component)this).transform.GetInstanceID();
	}
}
