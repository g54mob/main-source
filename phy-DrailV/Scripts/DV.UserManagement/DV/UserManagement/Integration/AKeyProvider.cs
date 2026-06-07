using UnityEngine;

namespace DV.UserManagement.Integration
{
	public abstract class AKeyProvider : ScriptableObject
	{
		public abstract byte[] GetKeyFor(int uid, string name, string signature);
	}
}
