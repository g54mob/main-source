using System.Collections.Generic;
using System.Linq;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Character.Suit
{
	public class CharacterSuitScript : MonoBehaviour
	{
		public static class ShaderPropertyIds
		{
			public static readonly int Color1 = Shader.PropertyToID("_Color1");

			public static readonly int Color2 = Shader.PropertyToID("_Color2");

			public static readonly int Color3 = Shader.PropertyToID("_Color3");

			public static readonly int Color4 = Shader.PropertyToID("_Color4");
		}

		private bool _initialized;

		[SerializeField]
		private List<CharacterSuitItem> _suitItems = new List<CharacterSuitItem>();

		public List<CharacterSuitItem> SuitItems => _suitItems;

		public void ApplyData(CharacterSuitData data)
		{
			if (!_initialized)
			{
				Initialize();
			}
			foreach (CharacterSuitData.CharacterSuitItemData itemData in data.Items)
			{
				CharacterSuitItem item = SuitItems.First((CharacterSuitItem x) => x.Name == itemData.Name);
				CharacterSuitData.CharacterSuitItemData characterSuitItemData = ((item.ParentName != null) ? data.Items.FirstOrDefault((CharacterSuitData.CharacterSuitItemData x) => x.Name == item.ParentName) : null);
				CharacterSuitData.CharacterSuitItemData characterSuitItemData2 = ((item.AntiDependentName != null) ? data.Items.FirstOrDefault((CharacterSuitData.CharacterSuitItemData x) => x.Name == item.AntiDependentName) : null);
				CharacterSuitData.CharacterSuitItemData sharedColorsItem = ((item.SharedColorsWith != null) ? data.Items.FirstOrDefault((CharacterSuitData.CharacterSuitItemData x) => x.Name == item.SharedColorsWith) : null);
				if (!item.Optional)
				{
					bool enabledSelf = (characterSuitItemData == null || characterSuitItemData.Enabled) && !(characterSuitItemData2?.Enabled ?? false);
					itemData.Enabled = enabledSelf;
					item.EnabledSelf = enabledSelf;
				}
				item.ApplyData(itemData, characterSuitItemData, characterSuitItemData2, sharedColorsItem);
			}
		}

		public CharacterSuitData GetData()
		{
			CharacterSuitData characterSuitData = new CharacterSuitData();
			foreach (CharacterSuitItem suitItem in _suitItems)
			{
				CharacterSuitData.CharacterSuitItemData data = suitItem.GetData();
				characterSuitData.Items.Add(data);
			}
			return characterSuitData;
		}

		private void Initialize()
		{
			_initialized = true;
			List<Material> value;
			using (CollectionPool<List<Material>, Material>.Get(out value))
			{
				foreach (IGrouping<Material, Renderer> item in from x in GetComponentsInChildren<Renderer>(includeInactive: true)
					group x by x.sharedMaterial)
				{
					if (item.Key == null)
					{
						Debug.LogWarning("Character's renderer '" + item.FirstOrDefault()?.name + "' does not have a shared material", item.FirstOrDefault());
						continue;
					}
					Material material = Object.Instantiate(item.Key);
					Color black = Color.black;
					material.SetColor(ShaderPropertyIds.Color1, black);
					material.SetColor(ShaderPropertyIds.Color2, black);
					material.SetColor(ShaderPropertyIds.Color3, black);
					material.SetColor(ShaderPropertyIds.Color4, black);
					foreach (Renderer item2 in item)
					{
						value.Clear();
						item2.GetSharedMaterials(value);
						if (value.Count > 1)
						{
							for (int num = 0; num < value.Count; num++)
							{
								value[num] = material;
							}
							item2.SetSharedMaterials(value);
						}
						else
						{
							item2.sharedMaterial = material;
						}
					}
				}
			}
		}

		[ContextMenu("Log Current Config XML")]
		private void LogCurrentXml()
		{
			Debug.Log(GetData().GenerateXml("Current"));
		}
	}
}
