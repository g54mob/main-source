using System;
using UnityEngine;

namespace Gh.Tk.Story
{
	[Serializable]
	[CreateAssetMenu(fileName = "RandomEventNarrationConfigAsset", menuName = "Greenheart Custom/Story/Config/RandomEventNarrationConfigAsset")]
	public class RandomEventNarrationConfigAsset : ScriptableObjectX
	{
		public EventNarrationConfig[] narrations;
	}
}
