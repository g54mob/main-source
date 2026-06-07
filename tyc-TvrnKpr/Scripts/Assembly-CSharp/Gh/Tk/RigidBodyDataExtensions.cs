using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public static class RigidBodyDataExtensions
	{
		public static RigidBodyData ToData(this Rigidbody rigidBody)
		{
			return default(RigidBodyData);
		}

		public static void FromJson(this Rigidbody rigidBody, JsonData data)
		{
		}

		public static void ApplyToObject(this RigidBodyData data, Rigidbody rigidBody)
		{
		}
	}
}
