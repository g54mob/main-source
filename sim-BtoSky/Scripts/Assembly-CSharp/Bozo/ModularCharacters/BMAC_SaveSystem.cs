using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Bozo.ModularCharacters
{
	public static class BMAC_SaveSystem
	{
		public static string filePath = Application.persistentDataPath + "/BoZo_StylizedModularCharacters/CustomCharacters";

		public static string iconFilePath = Application.persistentDataPath + "/BoZo_StylizedModularCharacters/CustomCharacters/Icons";

		public static string assetPath = "/BoZo_StylizedModularCharacters/CustomCharacters/Resources/";

		public static string iconAssetPath = "/BoZo_StylizedModularCharacters/CustomCharacters/Icons/";

		public static void SaveCharacter(OutfitSystem outfitSystem, string saveName, Texture2D icon = null)
		{
			CharacterData characterData = GetCharacterData(outfitSystem);
			characterData.characterName = saveName;
			string contents = JsonUtility.ToJson(characterData);
			File.WriteAllText(filePath + "/" + saveName + ".json", contents);
			Debug.Log("Character Saved:" + filePath + "/" + saveName + ".json");
		}

		public static CharacterData GetCharacterData(OutfitSystem outfitSystem)
		{
			if (outfitSystem.mergedMode)
			{
				return outfitSystem.data;
			}
			CharacterData characterData = new CharacterData();
			Dictionary<string, float> bodyShapeValues = outfitSystem.GetBodyShapeValues();
			characterData.bodyIDs = bodyShapeValues.Keys.ToList();
			characterData.bodyShapes = bodyShapeValues.Values.ToList();
			Dictionary<string, float> faceShapeValues = outfitSystem.GetFaceShapeValues();
			characterData.faceIDs = faceShapeValues.Keys.ToList();
			characterData.faceShapes = faceShapeValues.Values.ToList();
			List<BodyModData> list = new List<BodyModData>();
			List<string> list2 = outfitSystem.bodyModifiers.Keys.ToList();
			for (int i = 0; i < list2.Count; i++)
			{
				BodyModData data = outfitSystem.bodyModifiers[list2[i]].GetData();
				list.Add(data);
			}
			characterData.bodyMods = list;
			characterData.bodyModsKeys = list2;
			List<Outfit> outfits = outfitSystem.GetOutfits();
			List<OutfitData> list3 = new List<OutfitData>();
			for (int j = 0; j < outfits.Count; j++)
			{
				if (!(outfits[j] == null))
				{
					list3.Add(outfits[j].GetOutfitData());
				}
			}
			characterData.stance = outfitSystem.stance;
			characterData.outfitDatas = list3;
			return characterData;
		}

		public static async Task LoadCharacter(OutfitSystem outfitSystem, CharacterData characterObject = null, bool manualShapeApply = false, bool async = false)
		{
			List<Outfit> list = new List<Outfit>();
			if (async)
			{
				list = await LoadOutfits(characterObject.outfitDatas);
			}
			else
			{
				foreach (OutfitData outfitData2 in characterObject.outfitDatas)
				{
					list.Add(Resources.Load<Outfit>(outfitData2.outfit));
				}
			}
			outfitSystem.RemoveAllOutfits();
			for (int i = 0; i < characterObject.outfitDatas.Count; i++)
			{
				OutfitData outfitData = characterObject.outfitDatas[i];
				Outfit outfit = list[i];
				if (outfit == null)
				{
					Debug.LogWarning("Outfit Path: " + outfitData.outfit + " returns null make sure Prefab is named correctly");
					continue;
				}
				Outfit outfit2 = outfitSystem.InstantiateOutfit(outfit);
				if (outfit2.customShader)
				{
					outfit2.SetSwatch(outfitData.swatch);
					outfit2.SetColor(outfitData.color);
				}
				else
				{
					for (int j = 0; j < 9; j++)
					{
						if (outfitData.colors.Count > j)
						{
							outfit2.SetColor(outfitData.colors[j], j + 1);
						}
						if (j + 1 <= 3 && outfitData.decal != "")
						{
							outfit2.SetDecalColor(outfitData.decalColors[j], j + 1);
						}
						if (j + 1 <= 3 && outfitData.pattern != "")
						{
							outfit2.SetPatternColor(outfitData.patternColors[j], j + 1);
						}
					}
					Texture decal = Resources.Load<Texture>(outfitData.decal);
					outfit2.SetDecal(decal);
					outfit2.SetDecalSize(outfitData.decalScale);
					Texture pattern = Resources.Load<Texture>(outfitData.pattern);
					outfit2.SetPattern(pattern);
					outfit2.SetPatternSize(outfitData.patternScale);
				}
				try
				{
					for (int k = 0; k < outfit.optionalPieces.Length; k++)
					{
						if (!(outfit2.optionalPieces[k] == null))
						{
							outfit2.optionalPieces[k].SetActive(characterObject.outfitDatas[i].partVisibility[k]);
						}
					}
				}
				catch
				{
					Debug.LogError("Something Went Wrong");
				}
			}
			for (int l = 0; l < characterObject.bodyIDs.Count; l++)
			{
				outfitSystem.SetShape(characterObject.bodyIDs[l], characterObject.bodyShapes[l]);
			}
			for (int m = 0; m < characterObject.faceIDs.Count; m++)
			{
				outfitSystem.SetShape(characterObject.faceIDs[m], characterObject.faceShapes[m]);
			}
			if (!manualShapeApply)
			{
				LoadBodyMods(outfitSystem, characterObject);
			}
			outfitSystem.animator.Rebind();
			outfitSystem.SetStance(characterObject.stance);
		}

		public static void LoadBodyMods(OutfitSystem outfitSystem, CharacterData loadData)
		{
			for (int i = 0; i < loadData.bodyModsKeys.Count; i++)
			{
				outfitSystem.bodyModifiers[loadData.bodyModsKeys[i]].SetData(loadData.bodyMods[i]);
			}
		}

		public static CharacterData GetDataFromID(string saveName)
		{
			Debug.Log("Attempted Load at: " + filePath + "/" + saveName + ".json");
			if (!File.Exists(filePath + "/" + saveName + ".json"))
			{
				Debug.LogWarning("Save ID: " + saveName + " does not exist. Make sure input matches an existing Save");
				return null;
			}
			return JsonUtility.FromJson<CharacterData>(File.ReadAllText(filePath + "/" + saveName + ".json"));
		}

		public static async Task<List<Outfit>> LoadOutfits(List<OutfitData> outfitDatas)
		{
			return (await Task.WhenAll(outfitDatas.Select((OutfitData data) => LoadResourceAsync<Outfit>(data.outfit)))).ToList();
		}

		public static async Task<T> LoadResourceAsync<T>(string path) where T : Object
		{
			ResourceRequest request = Resources.LoadAsync<T>(path);
			TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
			request.completed += delegate
			{
				if (request.asset == null)
				{
					tcs.SetResult(null);
				}
				else if (!(request.asset is T result))
				{
					tcs.SetResult(null);
				}
				else
				{
					tcs.SetResult(result);
				}
			};
			return await tcs.Task;
		}

		public static void DeleteCharacter(string characterName)
		{
			File.Delete(filePath + "/" + characterName + ".json");
			File.Delete(iconFilePath + "/" + characterName + ".png");
			File.Delete("Assets/" + assetPath + "/" + characterName + ".asset");
			File.Delete("Assets/" + assetPath + "/" + characterName + ".meta");
			File.Delete("Assets/" + iconAssetPath + characterName + ".png");
			File.Delete("Assets/" + iconAssetPath + characterName + ".meta");
		}
	}
}
