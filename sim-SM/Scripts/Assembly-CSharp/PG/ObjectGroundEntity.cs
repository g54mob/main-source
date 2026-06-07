using UnityEngine;

namespace PG
{
	public class ObjectGroundEntity : IGroundEntity
	{
		[SerializeField]
		private GroundType GroundType;

		public override GroundConfig GetGroundConfig(Vector3 position)
		{
			return null;
		}
	}
}
