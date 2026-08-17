using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.UI;

namespace VampireSurvivors.Framework.DLC;

public class BundleManifestData : ScriptableObject
{
	public string _Version;

	public SwitchManifestData _Switch;

	public PS5ManifestData _PS5;

	public PS4ManifestData _PS4;

	private DataManagerSettings _DataFiles;

	private DynamicSoundGroupCreator _DynamicSoundGroup;

	private AccessoriesFactory _AccessoriesFactory;

	private CharacterFactory _CharacterFactory;

	private DestructibleFactory _DestructibleFactory;

	private EnemyFactory _EnemyFactory;

	private ProjectileFactory _ProjectileFactory;

	private TilesetFactory _TilesetFactory;

	private WeaponFactory _WeaponFactory;

	private BestiaryFactory _BestiaryFactory;

	private MainMenuBackgroundFactory _MainMenuBackgroundFactory;

	private PickupFactory _PickupFactory;

	private HeroVfxFactory _HeroVfxFactory;

	private AssetReferenceLibrary _AssetReferenceLibrary;

	public DataManagerSettings DataFiles => _DataFiles;

	public DynamicSoundGroupCreator DynamicSoundGroup => _DynamicSoundGroup;

	public AccessoriesFactory AccessoriesFactory => _AccessoriesFactory;

	public CharacterFactory CharacterFactory => _CharacterFactory;

	public DestructibleFactory DestructibleFactory => _DestructibleFactory;

	public EnemyFactory EnemyFactory => _EnemyFactory;

	public ProjectileFactory ProjectileFactory => _ProjectileFactory;

	public TilesetFactory TilesetFactory => _TilesetFactory;

	public WeaponFactory WeaponFactory => _WeaponFactory;

	public BestiaryFactory BestiaryFactory => _BestiaryFactory;

	public MainMenuBackgroundFactory MainMenuBackgroundFactory => _MainMenuBackgroundFactory;

	public PickupFactory PickupFactory => _PickupFactory;

	public HeroVfxFactory HeroVfxFactory => _HeroVfxFactory;

	public AssetReferenceLibrary AssetReferenceLibrary => _AssetReferenceLibrary;

	public BundleManifestData()
	{
		SwitchManifestData switchManifestData = new SwitchManifestData();
		_Switch = switchManifestData;
		PS5ManifestData pS5ManifestData = new PS5ManifestData();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AD7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		pS5ManifestData._MasterVersion = "01.00";
		_PS5 = pS5ManifestData;
		PS4ManifestData pS4ManifestData = new PS4ManifestData();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AD8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		pS4ManifestData._MasterVersion = "01.00";
		_PS4 = pS4ManifestData;
		base._002Ector();
	}
}
