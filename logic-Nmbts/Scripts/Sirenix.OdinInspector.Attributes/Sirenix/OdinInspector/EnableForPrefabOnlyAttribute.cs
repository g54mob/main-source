using System;

namespace Sirenix.OdinInspector
{
	[Obsolete("Use DisableInPrefabInstance or DisableInPrefabAsset instead.", false)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class EnableForPrefabOnlyAttribute : Attribute
	{
	}
}
