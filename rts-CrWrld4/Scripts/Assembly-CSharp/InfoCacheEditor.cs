using UnityEngine;

public class InfoCacheEditor : UnitEditor
{
	private InspectorChoice messageKey;

	private InspectorChoice messageType;

	private InspectorString messageButton0Text;

	private InspectorString messageButton1Text;

	private InspectorString messageChannel;

	private InspectorBool pauseGame;

	private InspectorFloat yPos;

	private InfoCache unit;

	public void ShowEditor(Transform inspector, UnitManager unit)
	{
	}

	public void Apply()
	{
	}
}
