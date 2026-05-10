using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "New Song", menuName = "Audio/Song")]
	public class Song : ScriptableObject
	{
		[SerializeField]
		private MusicStyle[] _stylesArray;

		public Dictionary<EBarStyle, MusicStyle> styles;

		public void Initialize()
		{
			if (styles != null)
			{
				return;
			}
			styles = new Dictionary<EBarStyle, MusicStyle>();
			MusicStyle[] stylesArray = _stylesArray;
			foreach (MusicStyle musicStyle in stylesArray)
			{
				if (!styles.TryAdd(musicStyle.style, musicStyle))
				{
					Debug.LogWarning($"[Song] Style {musicStyle.style} already present for song {base.name}, skipping {musicStyle.name}.");
				}
			}
		}
	}
}
