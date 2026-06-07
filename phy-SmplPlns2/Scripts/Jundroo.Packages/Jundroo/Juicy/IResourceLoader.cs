using System;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

namespace Jundroo.Juicy
{
	public interface IResourceLoader
	{
		Type GetScriptType(string scriptTypeName);

		AudioClip LoadAudioClip(string path);

		TMP_FontAsset LoadFont(string path);

		Material LoadMaterial(string path);

		Sprite LoadSprite(string path);

		Texture LoadTexture(string path);

		GameObject LoadWidgetGameObject(string name);

		XElement LoadXml(string path);
	}
}
