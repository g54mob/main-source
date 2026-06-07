using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_Stylesinfluences : MonoBehaviour
	{
		[SerializeField]
		private UI_StyleInflenceValue _prefab;

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private BarStyleParameters _allTheme;

		private List<UI_StyleInflenceValue> _stylesList = new List<UI_StyleInflenceValue>();

		private void Start()
		{
			for (int i = 0; i < 5; i++)
			{
				UI_StyleInflenceValue item = Object.Instantiate(_prefab, _container);
				_stylesList.Add(item);
			}
		}

		private void OnEnable()
		{
			BarStyleInfluence.OnMainStylesInfluenceChanged += OnMainStylesInfluenceChanged;
		}

		private void OnDisable()
		{
			BarStyleInfluence.OnMainStylesInfluenceChanged -= OnMainStylesInfluenceChanged;
		}

		private void OnMainStylesInfluenceChanged(List<BarStyleValues> mainStyle)
		{
			foreach (UI_StyleInflenceValue styles in _stylesList)
			{
				styles.gameObject.SetActive(value: false);
			}
			float num = 0f;
			foreach (BarStyleValues item in mainStyle)
			{
				num += item._value;
			}
			float num2 = 0f;
			for (int i = 0; i < mainStyle.Count; i++)
			{
				if (i < 4)
				{
					BarStyleParameters themeFromStyle = MonoSingleton<ThemeManager>.Instance.GetThemeFromStyle(mainStyle[i]._style);
					if (!(themeFromStyle == null))
					{
						_stylesList[i].SetTheme(themeFromStyle);
						_stylesList[i].gameObject.SetActive(value: true);
						_stylesList[i].SetValue(mainStyle[i]._value / num);
						num2 += mainStyle[i]._value / num;
					}
				}
				else
				{
					_stylesList[i].SetTheme(_allTheme);
					_stylesList[i].gameObject.SetActive(value: true);
					_stylesList[i].SetValue(1f - num2);
				}
			}
		}
	}
}
