using System;

namespace Sirenix.OdinInspector
{
	[Obsolete("Use HideInPrefabInstance or HideInPrefabAsset instead.", false)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class ShowForPrefabOnlyAttribute : Attribute
	{
	}
}
