using System.Linq;
using TMPro;
using UnityEngine;

namespace DV.HUD
{
	public class HUDLabelTextFontAdjuster : MonoBehaviour
	{
		private void Awake()
		{
			foreach (TMP_Text item in from go in GetComponentsInChildren<Transform>()
				where go.CompareTag("HUDLabel")
				select go.GetComponent<TMP_Text>())
			{
				item.fontSize = 8.35f;
			}
		}
	}
}
