using UnityEngine;

public class DecorationElement : Element
{
	[SerializeField]
	private SettingsRouter settingsRouter;

	private BiomeObjectConfiguration latestConfiguration;

	private bool _003CShouldUpdateBiome_003Ek__BackingField = true;

	private bool listeningToSettingsRouter;

	public bool HasBiomeConfiguration => latestConfiguration != null;

	public bool ShouldUpdateBiome
	{
		get
		{
			return _003CShouldUpdateBiome_003Ek__BackingField;
		}
		private set
		{
			_003CShouldUpdateBiome_003Ek__BackingField = value;
		}
	}

	public override bool IsDecoration
	{
		get
		{
			if (!ignoreDisplayProbability)
			{
				return settingsRouter;
			}
			return false;
		}
	}

	public override void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		if ((bool)settingsRouter && !listeningToSettingsRouter)
		{
			StartListeningToSettingsRouter();
		}
		if (!this && listeningToSettingsRouter)
		{
			Debug.Log("decoration element wants to apply biome but is null");
			return;
		}
		base.ApplyBiomeConfiguration(biomeConfiguration);
		latestConfiguration = new BiomeObjectConfiguration(biomeConfiguration);
	}

	private void StartListeningToSettingsRouter()
	{
	}

	protected void OnEnable()
	{
		if ((bool)settingsRouter && !listeningToSettingsRouter)
		{
			StartListeningToSettingsRouter();
		}
	}

	private void UpdateDecorationEnabled(bool newEnabled)
	{
		ShouldUpdateBiome = newEnabled;
		if (latestConfiguration != null)
		{
			ApplyBiomeConfiguration(latestConfiguration);
		}
	}
}
