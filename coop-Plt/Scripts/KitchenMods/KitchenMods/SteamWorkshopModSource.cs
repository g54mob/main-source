using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Platforms;
using Platforms.Steam;
using Steamworks;
using Steamworks.Data;
using Steamworks.Ugc;
using UnityEngine;

namespace KitchenMods
{
	public class SteamWorkshopModSource : ModSource
	{
		private const string PublicKeyData = "<RSAKeyValue><Modulus>3NF84AQANXqd2EWq1zxAhc5avCMCeC2/uU1aVuoLQGYJyumqcfg5uNLorMmcZPu4Wm3cphWIh5emV1zlo4Kfc38Jwn6sVQR92IRlGKzS2yTVbaAPAMvTXIHMiQfwOEpWJ4VyYeDa7lZwH94Z4KtFGWi3OWVWc9Lw2Jp1nVFDLex/KMC43TBHXtBjrZRpUUCHlqAWYRIY5Ej+RTqvo5DNtgnal03NBvn5N0So+NzFXsXRjfIEY3LeFDYHWEFBeaXpD2mUdI+uTRGpr0ZThzoFB4IegOMTInDavhcVQ1rTeirfsiCltgYVpa5yuTu2iB5MtXYa4wLC7uDtxydCEELedeMQNAVKzjqjtpK3BNI/r88YXkj1jlxOng4NJeajIS64FNG2xvKPZfSsv4LLPoSVoiwxxYlKi/q31WiuuOPp7U5VGFP+3L2el/P+XNO+JeM/WnHCaHo2MNO8D977FpnQflRW2U/HgSQGlERaHq+d9e+7XmheDi/Q4epDkQPclMUh</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

		private static readonly RSA PublicKey = LoadRSAKey("<RSAKeyValue><Modulus>3NF84AQANXqd2EWq1zxAhc5avCMCeC2/uU1aVuoLQGYJyumqcfg5uNLorMmcZPu4Wm3cphWIh5emV1zlo4Kfc38Jwn6sVQR92IRlGKzS2yTVbaAPAMvTXIHMiQfwOEpWJ4VyYeDa7lZwH94Z4KtFGWi3OWVWc9Lw2Jp1nVFDLex/KMC43TBHXtBjrZRpUUCHlqAWYRIY5Ej+RTqvo5DNtgnal03NBvn5N0So+NzFXsXRjfIEY3LeFDYHWEFBeaXpD2mUdI+uTRGpr0ZThzoFB4IegOMTInDavhcVQ1rTeirfsiCltgYVpa5yuTu2iB5MtXYa4wLC7uDtxydCEELedeMQNAVKzjqjtpK3BNI/r88YXkj1jlxOng4NJeajIS64FNG2xvKPZfSsv4LLPoSVoiwxxYlKi/q31WiuuOPp7U5VGFP+3L2el/P+XNO+JeM/WnHCaHo2MNO8D977FpnQflRW2U/HgSQGlERaHq+d9e+7XmheDi/Q4epDkQPclMUh</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");

		private const string SignatureFileName = "signature.txt";

		private static readonly HashSet<string> CheckExtensions = new HashSet<string> { ".dll", ".assets" };

		private static readonly HashSet<string> RevokedSignatures = new HashSet<string>();

		private static readonly HashSet<ulong> PinnedMods = new HashSet<ulong> { 2898069883uL, 2898033283uL };

		public override List<Mod> LoadMods()
		{
			if (!(Platform.Current is SteamPlatform steamPlatform) || !steamPlatform.Initialized)
			{
				return new List<Mod>();
			}
			SteamUGC.SubscribedItem[] subscribedItems = SteamUGC.GetSubscribedItems();
			Debug.Log($"Found {subscribedItems.Length} workshop mods");
			List<Mod> list = new List<Mod>();
			SteamUGC.SubscribedItem[] array = subscribedItems;
			for (int i = 0; i < array.Length; i++)
			{
				SteamUGC.SubscribedItem subscribedItem = array[i];
				Debug.Log($"... id: {subscribedItem.Id}, dir: {subscribedItem.Directory}");
				if (string.IsNullOrEmpty(subscribedItem.Directory) || !Directory.Exists(subscribedItem.Directory))
				{
					continue;
				}
				PublishedFileId id = subscribedItem.Id;
				string name = id.ToString();
				if (PinnedMods.Contains(subscribedItem.Id) && !SignatureValid(subscribedItem.Directory))
				{
					Debug.LogError($"refusing to load pinned mod {subscribedItem.Id}");
					Mod mod = new Mod(subscribedItem.Id, name);
					mod.State = ModState.FailedDuringLoad;
					mod.Source = this;
					list.Add(mod);
				}
				else
				{
					Mod mod = LoadModFromFolder(subscribedItem.Directory, name, subscribedItem.Id);
					if (mod != null)
					{
						mod.Source = this;
						list.Add(mod);
					}
				}
			}
			return list;
		}

		private static RSA LoadRSAKey(string xml)
		{
			RSA rSA = RSA.Create();
			rSA.FromXmlString(xml);
			return rSA;
		}

		private bool SignatureValid(string directory)
		{
			try
			{
				string text = File.ReadLines(Path.Combine(directory, "signature.txt")).First();
				if (RevokedSignatures.Contains(text))
				{
					return false;
				}
				byte[] signature = Convert.FromBase64String(text);
				List<string> list = (from x in ListModFilePaths(directory)
					where CheckExtensions.Contains(Path.GetExtension(x))
					select x).ToList();
				list.Sort(StringComparer.Ordinal);
				string prefix = directory + Path.DirectorySeparatorChar;
				using IncrementalHash incrementalHash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
				using (SHA256 sHA = SHA256.Create())
				{
					foreach (string item in list)
					{
						using FileStream inputStream = File.OpenRead(item);
						string s = Hex(sHA.ComputeHash(inputStream));
						incrementalHash.AppendData(Encoding.UTF8.GetBytes(s));
						incrementalHash.AppendData(Encoding.UTF8.GetBytes("  "));
						string s2 = TrimPrefix(item, prefix);
						incrementalHash.AppendData(Encoding.UTF8.GetBytes(s2));
						incrementalHash.AppendData(Encoding.UTF8.GetBytes("\n"));
					}
				}
				return PublicKey.VerifyHash(incrementalHash.GetHashAndReset(), signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"error verifying signature: {arg}");
				return false;
			}
		}

		private string TrimPrefix(string s, string prefix)
		{
			if (s.StartsWith(prefix))
			{
				return s.Substring(prefix.Length);
			}
			return s;
		}

		private string Hex(byte[] data)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in data)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		public override async Task<List<Mod>> PopulateModNames(List<Mod> mods)
		{
			new List<Item>();
			int page_number = 1;
			int result_count = 0;
			PublishedFileId[] ids = mods.Where((Mod x) => x.ID != 0L && x.Source == this).Select((Func<Mod, PublishedFileId>)((Mod x) => x.ID)).ToArray();
			Dictionary<ulong, int> id_to_index = mods.Select((Mod x, int i) => (ID: x.ID, i: i)).ToDictionary(((ulong ID, int i) x) => x.ID, ((ulong ID, int i) x) => x.i);
			while (true)
			{
				using ResultPage? resultPage = await Query.Items.WithFileId(ids).GetPageAsync(page_number);
				if (!resultPage.HasValue)
				{
					break;
				}
				ResultPage value = resultPage.Value;
				foreach (Item entry in value.Entries)
				{
					if (id_to_index.TryGetValue(entry.Id, out var value2))
					{
						mods[value2].Name = entry.Title;
					}
				}
				result_count += value.ResultCount;
				page_number++;
				if (value.ResultCount == 0 || result_count >= value.TotalCount)
				{
					break;
				}
				continue;
			}
			return mods;
		}
	}
}
