using UnityEngine;

namespace Enviro
{
	public class EnviroConfigurationCreation
	{
		public static EnviroConfiguration CreateMyAsset()
		{
			return ScriptableObject.CreateInstance<EnviroConfiguration>();
		}
	}
}
