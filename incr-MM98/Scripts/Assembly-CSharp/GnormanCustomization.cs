using UnityEngine;

public class GnormanCustomization : MonoBehaviour, ICustomization
{
	[SerializeField]
	private SkinnedMeshRenderer previewMesh;

	[SerializeField]
	private Transform entryParent;

	[SerializeField]
	private GnormanEntry entryPrefab;

	private GnormanSkin _selectedSkin;

	public void Initialize()
	{
		foreach (GnormanSkin value in EnumUtility.GetValues<GnormanSkin>())
		{
			if (value != GnormanSkin.Gold || SteamManager.User.DlcInstalled(4510400u))
			{
				GnormanEntry gnormanEntry = Object.Instantiate(entryPrefab, entryParent);
				gnormanEntry.Setup(value);
				gnormanEntry.Selected += OnSkinSelected;
			}
		}
	}

	public void Show()
	{
		_selectedSkin = Database.State.Customization.Gnorman.Value;
		OnSkinSelected(_selectedSkin);
		base.gameObject.SetActive(value: true);
	}

	public void Apply()
	{
		Database.State.Customization.Gnorman.Value = _selectedSkin;
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnSkinSelected(GnormanSkin skin)
	{
		_selectedSkin = skin;
		previewMesh.material.mainTexture = skin.Value().texture;
	}
}
