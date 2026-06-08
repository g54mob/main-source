using System.Collections.Generic;
using UnityEngine;

public class SSSpriteStatic : StonescriptObject
{
	public SSSpriteStatic()
		: base("sprite")
	{
		SSScriptableObject.Bind(this, this);
	}

	[StonescriptNativeMethod]
	public object New(List<object> parameters, InvocationContext ctx)
	{
		GameObject gameObject = new GameObject((parameters.Count > 0) ? (parameters[0] as string) : "Sprite");
		gameObject.AddComponent<MultilayerSprite>().nestedPosition = true;
		return gameObject.AddComponent<SSScriptableObject>().Target;
	}

	[StonescriptNativeMethod]
	public object NewLine(List<object> parameters, InvocationContext ctx)
	{
		GameObject gameObject = new GameObject((parameters.Count > 0) ? (parameters[0] as string) : "LineSprite");
		gameObject.AddComponent<AsciiLineSprite>();
		return gameObject.AddComponent<SSScriptableObject>().Target;
	}
}
