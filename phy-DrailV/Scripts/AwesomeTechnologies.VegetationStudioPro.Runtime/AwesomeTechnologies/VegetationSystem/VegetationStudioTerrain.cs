using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationStudioTerrain
	{
		public static IVegetationStudioTerrain GetIVegetationStudioTerrain(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			MonoBehaviour[] components = go.GetComponents<MonoBehaviour>();
			foreach (MonoBehaviour monoBehaviour in components)
			{
				if (monoBehaviour is IVegetationStudioTerrain)
				{
					return monoBehaviour as IVegetationStudioTerrain;
				}
			}
			return null;
		}
	}
}
