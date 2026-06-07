using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DV.CabControls;
using DV.Interaction;
using DV.Items;
using DV.Localization;
using DV.Radio;
using PlaylistsNET.Models;
using UnityEngine;

public class Cassette : MagazineAmmo, IInventoryItemLocalizer
{
	private enum CassetteType
	{
		Album = 0,
		Single = 1,
		ExtendedPlay = 2,
		Soundtrack = 3,
		Mix = 4,
		Playlist = 5
	}

	private const string ALBUM_SUFFIX_LOCALIZATION_KEY = "item/cassette_album_suffix";

	private const string SINGLE_SUFFIX_LOCALIZATION_KEY = "item/cassette_single_suffix";

	private const string EXTENDED_PLAY_SUFFIX_LOCALIZATION_KEY = "item/cassette_ep_suffix";

	private const string MIX_SUFFIX_LOCALIZATION_KEY = "item/cassette_mix_suffix";

	private const string PLAYLIST_DESCRIPTION_LOCALIZATION_KEY = "item/cassette_playlist_desc";

	[SerializeField]
	private string customName;

	[SerializeField]
	private string cassetteNumber;

	[SerializeField]
	private CassetteType cassetteType;

	public string playlistPath;

	public Renderer[] cassetteRenderers;

	[NonSerialized]
	public int lastPlayedPlaylistEntry;

	[NonSerialized]
	public long lastPlayedSeekPosition;

	private Material[][] cassetteSharedMaterials;

	private Mesh[] cassetteSharedMeshes;

	private bool materialsAndMeshesReferenced;

	public override ItemBase Item { get; protected set; }

	public override ItemUseTarget AmmoUseTarget { get; protected set; }

	public string BoomboxErrorName
	{
		get
		{
			if (cassetteType != CassetteType.Playlist)
			{
				return "Cassette A" + cassetteNumber;
			}
			return "Cassette P" + cassetteNumber;
		}
	}

	private void Awake()
	{
		if (VRManager.IsVREnabled())
		{
			base.gameObject.AddComponent<CassetteUseVR>();
		}
		else
		{
			base.gameObject.AddComponent<CassetteUseNonVR>();
		}
		ReferenceSharedMaterialsAndMeshes();
	}

	private void Start()
	{
		Item = GetComponent<ItemBase>();
		AmmoUseTarget = GetComponentInChildren<ItemUseTarget>();
	}

	private void ReferenceSharedMaterialsAndMeshes()
	{
		cassetteSharedMaterials = new Material[cassetteRenderers.Length][];
		cassetteSharedMeshes = new Mesh[cassetteRenderers.Length];
		for (int i = 0; i < cassetteRenderers.Length; i++)
		{
			Renderer renderer = cassetteRenderers[i];
			cassetteSharedMaterials[i] = renderer.sharedMaterials;
			cassetteSharedMeshes[i] = renderer.GetComponent<MeshFilter>().sharedMesh;
		}
		materialsAndMeshesReferenced = true;
	}

	public (Mesh[] sharedMeshes, Material[][] sharedMaterials) RequestSharedMeshesAndMaterials()
	{
		if (!materialsAndMeshesReferenced)
		{
			ReferenceSharedMaterialsAndMeshes();
		}
		return (sharedMeshes: cassetteSharedMeshes, sharedMaterials: cassetteSharedMaterials);
	}

	private bool IsAllowedExtension(string filePath)
	{
		string extension = Path.GetExtension(filePath.ToLower());
		if (!(extension == ".mp3") && !(extension == ".ogg"))
		{
			return extension == ".wav";
		}
		return true;
	}

	public IBasePlaylist GetPlaylist()
	{
		string text = GetFullPath(playlistPath);
		if (PlaylistPlayer.TryGetPlaylist(text, out var playlist))
		{
			return playlist;
		}
		if (text.EndsWith("\\") || text.EndsWith("/"))
		{
			text = text.Substring(0, text.Length - 1);
		}
		if (Directory.Exists(text))
		{
			List<M3uPlaylistEntry> playlistEntries = (from p in Directory.GetFiles(text).Where(IsAllowedExtension)
				select new M3uPlaylistEntry
				{
					Path = p
				}).ToList();
			M3uPlaylist m3uPlaylist = new M3uPlaylist();
			m3uPlaylist.Path = text + "/DOES_NOT_EXIST.m3u";
			m3uPlaylist.PlaylistEntries = playlistEntries;
			Debug.Log($"Built a playlist for cassette '{base.name}' from dir '{text}' with {m3uPlaylist.PlaylistEntries.Count} entries", this);
			return m3uPlaylist;
		}
		if (PlaylistPlayer.TryGetPlaylist(text + ".pls", out var playlist2))
		{
			return playlist2;
		}
		if (PlaylistPlayer.TryGetPlaylist(text + ".m3u", out var playlist3))
		{
			return playlist3;
		}
		Debug.LogWarning("Cassette '" + base.name + "' couldn't create playlist from path '" + text + "'", this);
		return null;
	}

	private static string GetFullPath(string relativePath)
	{
		if (string.IsNullOrWhiteSpace(relativePath))
		{
			return "";
		}
		relativePath = relativePath.Replace("/", "\\");
		return Application.streamingAssetsPath.Replace('/', '\\') + "\\" + relativePath;
	}

	public string GetNameParam()
	{
		return cassetteNumber;
	}

	public string GetCustomDescription()
	{
		switch (cassetteType)
		{
		case CassetteType.Album:
			return customName + " " + LocalizationAPI.L("item/cassette_album_suffix") + ".";
		case CassetteType.Single:
			return customName + " " + LocalizationAPI.L("item/cassette_single_suffix") + ".";
		case CassetteType.ExtendedPlay:
			return customName + " " + LocalizationAPI.L("item/cassette_ep_suffix") + ".";
		case CassetteType.Mix:
			return customName + " " + LocalizationAPI.L("item/cassette_mix_suffix") + ".";
		case CassetteType.Playlist:
			return LocalizationAPI.L("item/cassette_playlist_desc");
		default:
			return null;
		}
	}
}
