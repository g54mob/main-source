using UnityEngine;

public class SavableAttribute : PropertyAttribute
{
	public string id { get; private set; }

	public bool autoLoad { get; private set; }

	public bool saveTransform { get; private set; }

	public SavableAttribute(string id, bool autoLoad = true, bool saveTransform = false)
	{
		this.id = id;
		this.autoLoad = autoLoad;
		this.saveTransform = saveTransform;
	}
}
