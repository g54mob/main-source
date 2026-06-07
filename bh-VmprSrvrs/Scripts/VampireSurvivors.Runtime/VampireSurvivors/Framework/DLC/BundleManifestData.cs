using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.UI;

namespace VampireSurvivors.Framework.DLC
{
	[CreateAssetMenu(fileName = "BundleManifestData", menuName = "VampireSurvivors/New BundleManifestData")]
	public class BundleManifestData : ScriptableObject
	{
		public string _Version;

		[SerializeField]
		public SwitchManifestData _Switch;

		[SerializeField]
		public PS5ManifestData _PS5;

		[SerializeField]
		public PS4ManifestData _PS4;

		[SerializeField]
		private DataManagerSettings _DataFiles;

		[SerializeField]
		private DynamicSoundGroupCreator _DynamicSoundGroup;

		[SerializeField]
		private AccessoriesFactory _AccessoriesFactory;

		[SerializeField]
		private CharacterFactory _CharacterFactory;

		[SerializeField]
		private DestructibleFactory _DestructibleFactory;

		[SerializeField]
		private EnemyFactory _EnemyFactory;

		[SerializeField]
		private ProjectileFactory _ProjectileFactory;

		[SerializeField]
		private TilesetFactory _TilesetFactory;

		[SerializeField]
		private WeaponFactory _WeaponFactory;

		[SerializeField]
		private BestiaryFactory _BestiaryFactory;

		[SerializeField]
		private MainMenuBackgroundFactory _MainMenuBackgroundFactory;

		[SerializeField]
		private PickupFactory _PickupFactory;

		[SerializeField]
		private HeroVfxFactory _HeroVfxFactory;

		[SerializeField]
		private AssetReferenceLibrary _AssetReferenceLibrary;

		public DataManagerSettings DataFiles => null;

		public DynamicSoundGroupCreator DynamicSoundGroup => null;

		public AccessoriesFactory AccessoriesFactory => null;

		public CharacterFactory CharacterFactory => null;

		public DestructibleFactory DestructibleFactory => null;

		public EnemyFactory EnemyFactory => null;

		public ProjectileFactory ProjectileFactory => null;

		public TilesetFactory TilesetFactory => null;

		public WeaponFactory WeaponFactory => null;

		public BestiaryFactory BestiaryFactory => null;

		public MainMenuBackgroundFactory MainMenuBackgroundFactory => null;

		public PickupFactory PickupFactory => null;

		public HeroVfxFactory HeroVfxFactory => null;

		public AssetReferenceLibrary AssetReferenceLibrary => null;
	}
}
