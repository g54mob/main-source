using UnityEngine;

namespace ModApi.Common.ResourceUtils
{
	public class ResourceDataScript : MonoBehaviour
	{
		public ResourceData Data { get; set; }

		public static ResourceDataScript Add(GameObject obj, ResourceData data)
		{
			ResourceDataScript resourceDataScript = obj.AddComponent<ResourceDataScript>();
			resourceDataScript.Data = data;
			return resourceDataScript;
		}
	}
}
