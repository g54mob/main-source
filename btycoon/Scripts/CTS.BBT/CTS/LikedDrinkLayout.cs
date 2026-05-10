using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class LikedDrinkLayout : MonoBehaviour
	{
		[SerializeField]
		private LikedDrinkIcon _prefab;

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private bool _likedLayout;

		[Header("Color")]
		[SerializeField]
		private Image _background;

		[SerializeField]
		private PaletteData _workerColor;

		[SerializeField]
		private PaletteData _humanColor;

		[SerializeField]
		private PaletteData _vampireColor;

		[SerializeField]
		private PaletteData _backgroundWorkerColor;

		[SerializeField]
		private PaletteData _backgroundHumanColor;

		[SerializeField]
		private PaletteData _backgroundVampireColor;

		private List<LikedDrinkIcon> _drinkIcons = new List<LikedDrinkIcon>();

		[SerializeField]
		private LikedDrinkIcon _nothing;

		public void SetDrinks(DrinkSO[] drinks, Agent agent)
		{
			while (drinks.Length > _drinkIcons.Count)
			{
				_drinkIcons.Add(Object.Instantiate(_prefab, _container));
			}
			if (drinks.Length == 0)
			{
				_nothing.gameObject.SetActive(value: true);
			}
			else
			{
				_nothing.gameObject.SetActive(value: false);
			}
			Color color = (agent.IsHuman ? _backgroundHumanColor : _backgroundVampireColor);
			_nothing.SetupColor(color);
			for (int i = 0; i < _drinkIcons.Count; i++)
			{
				if (i < drinks.Length)
				{
					_drinkIcons[i].Setup(drinks[i], _likedLayout, color);
					_drinkIcons[i].gameObject.SetActive(value: true);
				}
				else
				{
					_drinkIcons[i].gameObject.SetActive(value: false);
				}
			}
			_background.color = ((agent is Worker) ? _workerColor : (agent.IsHuman ? _humanColor : _vampireColor));
		}
	}
}
