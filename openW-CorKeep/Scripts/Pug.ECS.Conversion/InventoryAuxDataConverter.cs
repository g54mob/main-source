using System.Text;
using Pug.Conversion;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class InventoryAuxDataConverter : SingleAuthoringComponentConverter<InventoryAuxDataPrefabsAuthoring>
{
	protected override void Convert(InventoryAuxDataPrefabsAuthoring authoring)
	{
		EnsureHasBuffer<InventoryAuxDataPrefabBuffer>();
		foreach (InventoryAuxDataPrefabsAuthoring.Prefab prefab in authoring.prefabs)
		{
			Entity prefabDependency = GetPrefabDependency(prefab.gameObject);
			if (string.IsNullOrEmpty(prefab.name))
			{
				Debug.LogError("name for aux inventory data prefab " + prefab.gameObject.name + " not set");
				continue;
			}
			uint hashFromName = GetHashFromName(prefab.name);
			AddToBuffer(new InventoryAuxDataPrefabBuffer
			{
				Entity = prefabDependency,
				TypeHash = hashFromName
			});
			AddComponentData(prefabDependency, new InventoryAuxDataPrefabCD
			{
				TypeHash = hashFromName
			});
			EnsureHasComponent<InventoryAuxDataCD>(prefabDependency);
			EnsureHasComponent<InventoryAuxDataNeedsInitializationCD>(prefabDependency);
		}
	}

	private unsafe uint GetHashFromName(string name)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(name);
		fixed (byte* pBuffer = bytes)
		{
			return math.hash(pBuffer, bytes.Length, 3135629039u);
		}
	}
}
