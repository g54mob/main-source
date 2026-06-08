using System;

namespace MLAPI.NetworkedVar
{
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class SyncedVarAttribute : Attribute
	{
		public string Channel = "MLAPI_DEFAULT_MESSAGE";

		public float SendTickrate;
	}
}
