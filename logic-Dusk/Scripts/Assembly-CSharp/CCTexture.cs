using System;
using UnityEngine;

[Serializable]
public class CCTexture
{
	public Texture texture;

	[Compact]
	public Vector4 scaleTranslate = new Vector4(1f, 1f, 0f, 0f);

	[Compact]
	public Vector4 scaleTranslatePerSecond = Vector4.zero;

	private void OnInspectorGUI()
	{
		Debug.Log("2237049");
	}

	public void Update()
	{
		scaleTranslate += scaleTranslatePerSecond * Time.deltaTime;
	}
}
