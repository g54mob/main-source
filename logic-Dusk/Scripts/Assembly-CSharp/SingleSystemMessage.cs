using UnityEngine;

public class SingleSystemMessage
{
	public Texture MessageTexture;

	public float ShowTimer { get; set; }

	public string MessageText { get; set; }

	public ConsoleMessageType SystemMessageType { get; set; }

	public SystemMessageImageType ImageType { get; set; }
}
