using GRP.Net;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/MainConfig", fileName = "MainConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class MainConfig : ScriptableObject
	{
		public BuildResult buildResult;

		public ProjectConfigEntry project;

		public GameSessionConfig gameSession;

		public NetGameConfig netGame;

		public SettingsConfig settings;

		public MainMenuConfig mainMenu;

		public SandboxConfig sandbox;

		public CampaignConfig campaign;

		public MissionConfig mission;

		public WorkshopConfig workshop;
	}
}
