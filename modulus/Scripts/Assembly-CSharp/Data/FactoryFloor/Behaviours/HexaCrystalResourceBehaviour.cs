using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/HexaCrystalResourceBehaviour", fileName = "HexaCrystalResourceBehaviour", order = 0)]
	public class HexaCrystalResourceBehaviour : ColorResourceBehaviour
	{
		[SerializeField]
		private ColorLibrarySO _colorLibrary;

		[SerializeField]
		private SerializedDictionary<Color, ResourceDataSO> _resourceDataPerColor;

		public override void SetColor(Color color)
		{
			base.SetColor(color);
			if (_resourceDataPerColor.ContainsKey(color))
			{
				SetResourceData(_resourceDataPerColor[color]);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void PopulateColorLibrary()
		{
			if (!_colorLibrary)
			{
				return;
			}
			List<ResourceDataSO> list = new List<ResourceDataSO>();
			for (int i = 0; i < _resourceDataPerColor.Count; i++)
			{
				list.Add(_resourceDataPerColor.ElementAt(i).Value);
			}
			_resourceDataPerColor.Clear();
			for (int j = 0; j < _colorLibrary.HexCodeColorDictionary.Count; j++)
			{
				if (ColorUtility.TryParseHtmlString("#" + _colorLibrary.HexCodeColorDictionary.ElementAt(j).Key, out var color))
				{
					_resourceDataPerColor.Add(color, (list.Count > j) ? list[j] : null);
				}
			}
		}
	}
}
