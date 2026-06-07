using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods;
using UnityEngine;

namespace Assets.Scripts.Flight.Maps
{
	public class ModMap : MapBase
	{
		private readonly string _mapId;

		public override string MapId => _mapId;

		public MapInfo MapInfo { get; private set; }

		public override string Name => MapInfo.Name;

		public ModMap(MapInfo mapInfo)
		{
			MapInfo = mapInfo;
			string text = mapInfo.Mod.Name + "__" + mapInfo.Name;
			char[] underscoreCharacters = new char[2] { ' ', ':' };
			char[] emtpyCharacters = new char[29]
			{
				'`', '~', '!', '@', '#', '$', '%', '^', '&', '*',
				'(', ')', '+', '=', '[', ']', '{', '}', '\\', '|',
				';', '\'', '"', ',', '.', '<', '>', '/', '?'
			};
			_mapId = new string((from c in text.ToCharArray()
				select (!underscoreCharacters.Contains(c)) ? c : '_' into c
				select (!emtpyCharacters.Contains(c)) ? c : '#' into c
				where c != '#'
				select c).ToArray());
		}

		public override MapLoadResult LoadMap(LevelInfo level)
		{
			GameObject gameObject = ModManager.Instance.LoadMap(MapInfo);
			Terrain[] componentsInChildren = gameObject.GetComponentsInChildren<Terrain>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.layer |= 20;
			}
			LevelBase levelBase = null;
			if (level.IsSandbox)
			{
				levelBase = gameObject.AddComponent<LevelSandboxScript>();
				levelBase.AllowAutopilot = true;
				levelBase.AutoPilotDisablesSomeAchievements = false;
			}
			return new MapLoadResult(new List<GameObject> { gameObject }, levelBase, null);
		}
	}
}
