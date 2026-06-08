using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class LocalisationSpecific : MonoBehaviour
	{
		public List<Locale> ShowIfAny = new List<Locale>();

		public bool Inverted;

		private void Awake()
		{
			base.gameObject.SetActive(Inverted != ShowIfAny.Contains(Localisation.CurrentLocale));
		}
	}
}
