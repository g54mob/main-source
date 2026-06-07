using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama
{
	[CreateAssetMenu(fileName = "GUI Styles", menuName = "Pajama Llama/GUI Styles")]
	public class GUIStyles : ScriptableObject
	{
		private const string ASSET_PATH = "Assets/Editor/Styles/{0}.asset";

		[SerializeField]
		private GUIStyle[] _guiStyles;

		private static Dictionary<string, GUIStyles> _cache;

		public static GUIStyle GetStyle(string assetName, string styleName)
		{
			return GUIStyle.none;
		}

		private GUIStyle GetStyle(string styleName)
		{
			if (_guiStyles == null)
			{
				return GUIStyle.none;
			}
			GUIStyle[] guiStyles = _guiStyles;
			foreach (GUIStyle gUIStyle in guiStyles)
			{
				if (gUIStyle.name == styleName)
				{
					return gUIStyle;
				}
			}
			return GUIStyle.none;
		}
	}
}
