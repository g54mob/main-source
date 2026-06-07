using System;
using Jundroo.Common.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class AuthorUIScript : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _date;

		[SerializeField]
		private TextMeshProUGUI _name;

		[SerializeField]
		private GameObject _points;

		[SerializeField]
		private Image _pointsBackground;

		public void SetAuthor(int points, string name, DateTime createdDateTime)
		{
			_name.text = name;
			_date.text = createdDateTime.RelativeDate();
			Color color = Color.white;
			Color white = Color.white;
			if (points > 25000)
			{
				white = new Color32(51, 51, 51, byte.MaxValue);
			}
			else if (points > 5000)
			{
				white = new Color32(228, 184, 75, byte.MaxValue);
			}
			else if (points > 1000)
			{
				white = new Color32(121, 121, 121, byte.MaxValue);
			}
			else if (points > 100)
			{
				white = new Color32(120, 97, 19, byte.MaxValue);
			}
			else
			{
				white = Color.white;
				color = Color.black;
			}
			_pointsBackground.color = white;
			TextMeshProUGUI[] componentsInChildren = _points.GetComponentsInChildren<TextMeshProUGUI>();
			string text = Utilities.FriendlyLargeNumber(points);
			TextMeshProUGUI[] array = componentsInChildren;
			foreach (TextMeshProUGUI obj in array)
			{
				obj.text = text;
				obj.color = color;
			}
		}

		public void Show(bool show)
		{
			base.gameObject.SetActive(show);
		}
	}
}
