using System;
using UnityEngine;
using VampireSurvivors.Builds;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class BaseGameData : ScriptableObject
	{
		public static readonly string ARTIFACT_TYPE;

		public readonly string _Title;

		[SerializeField]
		private BuildMeta _BuildMeta;

		[SerializeField]
		public SteamBaseGameData _Steam;

		[SerializeField]
		public EpicGamesStoreGameData _EpicGamesStore;

		[SerializeField]
		public XboxBaseGameData _Xbox;

		[SerializeField]
		public SwitchBaseGameData _Switch;

		[SerializeField]
		public PS4BaseGameData _PS4;

		[SerializeField]
		public PS5BaseGameData _PS5;

		[SerializeField]
		public IOS _IOS;

		[SerializeField]
		public AppleArcade _AppleArcade;

		public BuildMeta BuildMeta
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
