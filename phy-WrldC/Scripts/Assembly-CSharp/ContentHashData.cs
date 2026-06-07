using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Content Hash Data")]
public class ContentHashData : ScriptableObject
{
	[TextArea(20, 20)]
	[SerializeField]
	private string schematicHashes;

	[TextArea(20, 20)]
	[SerializeField]
	private string levelHashes;

	[TextArea(5, 5)]
	[SerializeField]
	private string schematicPropertiesHash;

	[TextArea(5, 5)]
	[SerializeField]
	private string materialPropertiesHash;

	public Properties GetSchematicHashes()
	{
		return GetPropertiesHashesMap(schematicHashes);
	}

	public Properties GetLevelHashes()
	{
		return GetPropertiesHashesMap(levelHashes);
	}

	public string GetSchematicPropertiesHash()
	{
		return schematicPropertiesHash;
	}

	public string GetMaterialPropertiesHash()
	{
		return materialPropertiesHash;
	}

	private Properties GetPropertiesHashesMap(string hashesText)
	{
		Properties properties = new Properties();
		string[] array = hashesText.Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Replace("\r", "");
			if (!string.IsNullOrEmpty(array[i]) && !string.IsNullOrWhiteSpace(array[i]))
			{
				string[] array2 = array[i].Split('=');
				if (array2.Length == 2)
				{
					properties.AddProperty(array2[0], array2[1]);
				}
			}
		}
		return properties;
	}
}
