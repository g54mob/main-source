using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace TH20.ExtContent
{
	public class GameItemMusicPack : GameItemBase
	{
		public class GameItemMusicPackConfig : GameItemBaseConfig
		{
			public int _maxNumMusicFilesPerPack = 100;
		}

		public string cKey_NumMusicItems = "NumMusicItems";

		public string cKey_ItemFileNameBase = "ItemFileName__";

		public string cKey_ItemArtistNameBase = "ItemArtistName";

		public string cKey_ItemTrackNameBase = "ItemTrackNamee";

		public string cKey_ItemNormFactorBase = "ItemNormFactor";

		public string cKey_ItemSampleLenBase = "ItemSampleLen_";

		private List<MusicPackSourceItem> _items;

		public List<MusicPackSourceItem> Items => _items;

		public GameItemMusicPack()
		{
			_items = new List<MusicPackSourceItem>();
		}

		public void SetData(List<MusicPackSourceItem> musicPackSourceItems)
		{
			_items.Clear();
			foreach (MusicPackSourceItem musicPackSourceItem in musicPackSourceItems)
			{
				string pathSpec = ExtContentUtils.GetPathSpec(base.InstalledFolderPathSpec, Path.GetFileName(musicPackSourceItem.FileSpec));
				_items.Add(new MusicPackSourceItem(pathSpec, musicPackSourceItem.ArtistName, musicPackSourceItem.TrackName));
			}
			OnDataUpdated();
		}

		public override bool ValidateReadyForDelete(bool bSilent = false)
		{
			return true;
		}

		public override void UpdateMetaData()
		{
			base.UpdateMetaData();
			base.GameItemMetaData.Add(cKey_NumMusicItems, _items.Count.ToString());
			int i = 0;
			for (int count = _items.Count; i < count; i++)
			{
				string key = $"{cKey_ItemFileNameBase}_{i:0000}";
				string key2 = $"{cKey_ItemArtistNameBase}_{i:0000}";
				string key3 = $"{cKey_ItemTrackNameBase}_{i:0000}";
				string text = $"{cKey_ItemNormFactorBase}_{i:0000}";
				string key4 = $"{cKey_ItemSampleLenBase}_{i:0000}";
				string fileName = Path.GetFileName(_items[i].FileSpec);
				string artistName = _items[i].ArtistName;
				string trackName = _items[i].TrackName;
				string text2 = _items[i].NormalisationFactor.ToString(CultureInfo.InvariantCulture);
				string value = _items[i].SampleLengthPerChannel.ToString();
				base.GameItemMetaData.Add(key, fileName);
				base.GameItemMetaData.Add(key2, artistName);
				base.GameItemMetaData.Add(key3, trackName);
				base.GameItemMetaData.Add(text, text2);
				base.GameItemMetaData.Add(key4, value);
				ExtContentMessages.LogMessage($"GameItemMusicPack.UpdateMetaData: MusicPack '{base.Title}' wrote key '{text}' with value '{text2}'");
			}
		}

		protected override bool UpdateFromMetaData()
		{
			bool result = false;
			_items.Clear();
			if (base.UpdateFromMetaData())
			{
				int value = 0;
				base.GameItemMetaData.Get(cKey_NumMusicItems, ref value);
				if (value > 0)
				{
					for (int i = 0; i < value; i++)
					{
						string key = $"{cKey_ItemFileNameBase}_{i:0000}";
						string key2 = $"{cKey_ItemArtistNameBase}_{i:0000}";
						string key3 = $"{cKey_ItemTrackNameBase}_{i:0000}";
						string text = $"{cKey_ItemNormFactorBase}_{i:0000}";
						string key4 = $"{cKey_ItemSampleLenBase}_{i:0000}";
						string value2 = string.Empty;
						string value3 = string.Empty;
						string value4 = string.Empty;
						string value5 = string.Empty;
						string value6 = string.Empty;
						base.GameItemMetaData.Get(key, ref value2);
						base.GameItemMetaData.Get(key2, ref value3);
						base.GameItemMetaData.Get(key3, ref value4);
						base.GameItemMetaData.Get(text, ref value5);
						base.GameItemMetaData.Get(key4, ref value6);
						ExtContentMessages.LogMessage($"GameItemMusicPack.UpdateFromMetaData: MusicPack '{base.Title}' read key '{text}' with value '{value5}'");
						if (value2.IsNullOrEmpty())
						{
							continue;
						}
						MusicPackSourceItem musicPackSourceItem = new MusicPackSourceItem(ExtContentUtils.GetPathSpec(base.InstalledFolderPathSpec, value2), value3, value4);
						if (!value5.IsNullOrEmpty())
						{
							string arg = value5;
							bool flag = false;
							try
							{
								musicPackSourceItem.NormalisationFactor = Convert.ToSingle(value5);
							}
							catch (Exception ex)
							{
								flag = true;
								ExtContentMessages.LogError($"Exception converting key '{text}' value '{value5}' to string: Error: '{ex.ToString()}'");
							}
							if (flag)
							{
								char[] array = value5.ToCharArray();
								int j = 0;
								for (int num = array.Length; j < num; j++)
								{
									if (!char.IsDigit(array[j]))
									{
										array[j] = '.';
									}
								}
								value5 = new string(array);
								while (value5.Contains(".."))
								{
									value5 = value5.Replace("..", ".");
								}
								ExtContentMessages.LogMessage($"GameItemMusicPack.UpdateFromMetaData: MusicPack '{base.Title}' attempting reread key '{text}' with value '{value5}'");
								try
								{
									musicPackSourceItem.NormalisationFactor = Convert.ToSingle(value5, CultureInfo.InvariantCulture);
									ExtContentMessages.LogMessage($"GameItemMusicPack.UpdateFromMetaData: MusicPack '{base.Title}' read key '{text}' with value '{value5}' successful. Float value: {musicPackSourceItem.NormalisationFactor}");
								}
								catch (Exception ex2)
								{
									flag = true;
									ExtContentMessages.LogError($"Further exception converting key '{text}' value '{value5}' to string: Error: '{ex2.ToString()}'");
								}
							}
							musicPackSourceItem.NormalisationFactor = DynamicPlaylistManager.ResetInvalidNormalisationFactor(musicPackSourceItem.NormalisationFactor);
							ExtContentMessages.LogMessage($"GameItemMusicPack.UpdateMetaData: MusicPack '{base.Title}' set NormFactor float value {musicPackSourceItem.NormalisationFactor} using string value '{arg}'");
						}
						if (!value6.IsNullOrEmpty())
						{
							musicPackSourceItem.SampleLengthPerChannel = Convert.ToInt32(value6);
						}
						_items.Add(musicPackSourceItem);
					}
				}
				result = true;
			}
			return result;
		}
	}
}
