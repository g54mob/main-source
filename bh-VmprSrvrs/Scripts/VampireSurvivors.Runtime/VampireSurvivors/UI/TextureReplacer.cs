using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class TextureReplacer : MonoBehaviour
	{
		[SerializeField]
		private List<Sprite> _Sprites;

		private List<string> _spriteNames;

		private Dictionary<string, Sprite> _spriteDic;

		private void Replace()
		{
		}
	}
}
