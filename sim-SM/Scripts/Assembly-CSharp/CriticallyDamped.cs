using UnityEngine;

public class CriticallyDamped
{
	public class Float3 : Spring<Vector3>
	{
		private Vector3 m_CurrentVelocity;

		public override Vector3 Update()
		{
			return default(Vector3);
		}
	}
}
