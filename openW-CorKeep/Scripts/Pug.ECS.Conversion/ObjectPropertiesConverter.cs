using Pug.Conversion;
using Pug.Properties;
using UnityEngine;

public class ObjectPropertiesConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		EnsureHasComponent<ObjectPropertiesCD>();
	}
}
