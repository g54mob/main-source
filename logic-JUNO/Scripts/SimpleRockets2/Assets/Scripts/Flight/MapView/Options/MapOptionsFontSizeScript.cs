using ModApi.Flight.MapView;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Options
{
	public class MapOptionsFontSizeScript : MonoBehaviour
	{
		public IMapOptions Options { get; private set; }

		public TextMeshProUGUI Text { get; private set; }

		public static MapOptionsFontSizeScript Create(TextMeshProUGUI text, IMapOptions options)
		{
			MapOptionsFontSizeScript mapOptionsFontSizeScript = text.gameObject.AddComponent<MapOptionsFontSizeScript>();
			mapOptionsFontSizeScript.Text = text;
			mapOptionsFontSizeScript.Options = options;
			return mapOptionsFontSizeScript;
		}

		protected virtual void LateUpdate()
		{
			if (Text.fontSize != Options.FontSizeValue)
			{
				Text.fontSize = Options.FontSizeValue;
			}
		}
	}
}
