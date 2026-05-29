using System;
using UnityEngine;
using UnityEngine.Search;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	[Serializable]
	public class TextureSet
	{
		[Tooltip("先頭はStopモーション扱い。2コマアニメなら3つ必要。「stop」という単独spriteは特殊扱い")]
		[Header("先頭はStopモーション扱い。2コマアニメなら3つ必要。「stop」という単独spriteは特殊扱い")]
		public Texture2D[] textures;

		[SearchContext("ext:json")]
		public TextAsset texturePartsMap;
	}
}
