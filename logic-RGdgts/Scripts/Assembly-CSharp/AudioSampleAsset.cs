using System;
using System.Collections;
using System.Collections.Generic;
using ATL;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSampleAsset : Asset
{
	[Serializable]
	public class Serialized : SerializedAsset
	{
		public int samplesCount;

		public int channels;

		public int frequency;

		public byte[] compressedData;

		public Metadata metadata;

		public Serialized()
		{
		}

		public Serialized(AudioSampleAsset audioSample)
		{
		}

		public override Asset Instantiate(SerializedAssetMetadata metadata)
		{
			return null;
		}
	}

	[Serializable]
	public struct Metadata
	{
		[LuaTable.HideIfNull]
		public string LongDescription;

		public DateTime? Date;

		[LuaTable.HideIfNull]
		public int? Year;

		[LuaTable.HideIfNull]
		public int? TrackNumber;

		[LuaTable.HideIfNull]
		public int? TrackTotal;

		[LuaTable.HideIfNull]
		public int? DiscNumber;

		[LuaTable.HideIfNull]
		public int? DiscTotal;

		[LuaTable.HideIfNull]
		public float? Popularity;

		[LuaTable.HideIfNull]
		public string SeriesPart;

		public int Bitrate;

		public int? BitDepth;

		public double SampleRate;

		public bool IsVariableBitRate;

		public int Duration;

		[LuaTable.AddDictionaryIntoParent]
		public Dictionary<string, string> AdditionalFields;

		[LuaTable.HideIfNull]
		public string SeriesTitle;

		[LuaTable.HideIfNull]
		public string SortTitle;

		[LuaTable.HideIfNull]
		public string Title;

		[LuaTable.HideIfNull]
		public string Artist;

		[LuaTable.HideIfNull]
		public string Composer;

		[LuaTable.HideIfNull]
		public string Comment;

		[LuaTable.HideIfNull]
		public string Genre;

		[LuaTable.HideIfNull]
		public string Album;

		[LuaTable.HideIfNull]
		public string Group;

		[LuaTable.HideIfNull]
		public string OriginalArtist;

		[LuaTable.HideIfNull]
		public string Copyright;

		[LuaTable.HideIfNull]
		public string OriginalAlbum;

		[LuaTable.HideIfNull]
		public string Publisher;

		public DateTime? PublishingDate;

		[LuaTable.HideIfNull]
		public string AlbumArtist;

		[LuaTable.HideIfNull]
		public string Conductor;

		[LuaTable.HideIfNull]
		public string ProductId;

		[LuaTable.HideIfNull]
		public string SortAlbum;

		[LuaTable.HideIfNull]
		public string SortAlbumArtist;

		[LuaTable.HideIfNull]
		public string SortArtist;

		[LuaTable.HideIfNull]
		public string Description;

		public Metadata(Track track)
		{
			LongDescription = null;
			Date = null;
			Year = null;
			TrackNumber = null;
			TrackTotal = null;
			DiscNumber = null;
			DiscTotal = null;
			Popularity = null;
			SeriesPart = null;
			Bitrate = 0;
			BitDepth = null;
			SampleRate = 0.0;
			IsVariableBitRate = false;
			Duration = 0;
			AdditionalFields = null;
			SeriesTitle = null;
			SortTitle = null;
			Title = null;
			Artist = null;
			Composer = null;
			Comment = null;
			Genre = null;
			Album = null;
			Group = null;
			OriginalArtist = null;
			Copyright = null;
			OriginalAlbum = null;
			Publisher = null;
			PublishingDate = null;
			AlbumArtist = null;
			Conductor = null;
			ProductId = null;
			SortAlbum = null;
			SortAlbumArtist = null;
			SortArtist = null;
			Description = null;
		}
	}

	public AudioClip audioClip;

	public bool isStreamingAudioClip;

	public Metadata metadata;

	public int Script_SamplesCount => 0;

	public int Script_Channels => 0;

	public int Script_Frequency => 0;

	public float Script_Length => 0f;

	public LuaTable Script_Metadata => null;

	public AudioSampleAsset()
	{
	}

	public AudioSampleAsset(string name)
	{
	}

	public static byte[] CompressData(float[] data)
	{
		return null;
	}

	public static float[] DecompressData(byte[] compressedData)
	{
		return null;
	}

	public override AssetType GetAssetType()
	{
		return default(AssetType);
	}

	public override void Dispose()
	{
	}

	public override SerializedAsset ToSerializedAsset()
	{
		return null;
	}

	public override void InitDefaultEditorAsset()
	{
	}

	private void SetData(float[] data, int samplesCount, int channels, int frequency)
	{
	}

	public bool LoadFromAudioClip(AudioClip audioClip, bool skipCopyData)
	{
		return false;
	}

	public override bool LoadFromFile(string path, Asset[] additionalInitAssets)
	{
		return false;
	}

	public IEnumerator LoadFromFileAsync(string path, bool allowStreaming, Action<bool> onComplete)
	{
		return null;
	}

	private UnityWebRequest LoadAudioClipFromFile(string soundFile, bool allowStreaming = false)
	{
		return null;
	}

	private AudioClip GetAudioClipFromRequest(UnityWebRequest request, bool allowStreaming = false)
	{
		return null;
	}
}
