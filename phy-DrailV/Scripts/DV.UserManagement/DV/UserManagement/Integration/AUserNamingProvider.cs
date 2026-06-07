using UnityEngine;

namespace DV.UserManagement.Integration
{
	public abstract class AUserNamingProvider : ScriptableObject
	{
		public abstract string DefaultName { get; }
	}
}
