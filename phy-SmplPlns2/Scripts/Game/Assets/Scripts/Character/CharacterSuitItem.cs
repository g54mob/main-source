using System;
using Assets.Scripts.Character.Suit;
using UnityEngine;

namespace Assets.Scripts.Character
{
	[Serializable]
	public class CharacterSuitItem
	{
		[Serializable]
		public class SuitItemColor
		{
			[SerializeField]
			private string _name;

			[SerializeField]
			[Tooltip("The index of the color in the material. Use -1 to match with element index.")]
			private int _index = -1;

			public int Index => _index;

			public string Name => _name;
		}

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _antidependent;

		[SerializeField]
		private SuitItemColor[] _colors;

		[SerializeField]
		private bool _enabledSelf = true;

		[SerializeField]
		private bool _optional;

		[SerializeField]
		private string _parent;

		[SerializeField]
		private Renderer[] _renderers;

		[SerializeField]
		private string _sharedColorsWith;

		public string AntiDependentName => _antidependent;

		public SuitItemColor[] Colors => _colors;

		public bool EnabledSelf
		{
			get
			{
				return _enabledSelf;
			}
			set
			{
				_enabledSelf = value;
			}
		}

		public string Name => _name;

		public bool Optional => _optional;

		public string ParentName => _parent;

		public string SharedColorsWith => _sharedColorsWith;

		public void ApplyData(CharacterSuitData.CharacterSuitItemData itemData, CharacterSuitData.CharacterSuitItemData parentItemData, CharacterSuitData.CharacterSuitItemData antiDependentItem, CharacterSuitData.CharacterSuitItemData sharedColorsItem)
		{
			EnabledSelf = itemData.Enabled;
			Renderer[] renderers = _renderers;
			foreach (Renderer renderer in renderers)
			{
				bool flag = itemData.Enabled && (parentItemData == null || parentItemData.Enabled) && !(antiDependentItem?.Enabled ?? false);
				renderer.gameObject.SetActive(flag);
				foreach (CharacterSuitData.SuitItemDataColor color in itemData.Colors)
				{
					if (sharedColorsItem != null)
					{
						foreach (CharacterSuitData.SuitItemDataColor color2 in sharedColorsItem.Colors)
						{
							if (color.Index == color2.Index)
							{
								if (flag)
								{
									color2.Color = color.Color;
								}
								else
								{
									color.Color = color2.Color;
								}
							}
						}
					}
					renderer.sharedMaterial.SetColor($"_Color{color.Index}", color.Color);
				}
			}
		}

		public CharacterSuitData.CharacterSuitItemData GetData()
		{
			CharacterSuitData.CharacterSuitItemData characterSuitItemData = new CharacterSuitData.CharacterSuitItemData();
			Renderer renderer = _renderers[0];
			characterSuitItemData.Name = _name;
			characterSuitItemData.Enabled = EnabledSelf;
			for (int i = 0; i < _colors.Length; i++)
			{
				int num = ((_colors[i].Index < 0) ? (i + 1) : _colors[i].Index);
				CharacterSuitData.SuitItemDataColor suitItemDataColor = new CharacterSuitData.SuitItemDataColor();
				suitItemDataColor.Color = renderer.sharedMaterial.GetColor($"_Color{num}");
				suitItemDataColor.Index = num;
				characterSuitItemData.Colors.Add(suitItemDataColor);
			}
			return characterSuitItemData;
		}
	}
}
