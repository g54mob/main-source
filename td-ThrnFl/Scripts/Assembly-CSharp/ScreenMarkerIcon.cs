using UnityEngine;

public class ScreenMarkerIcon : MonoBehaviour
{
	public Sprite sprite;

	public string locaKey;

	public string UnitDescription => TextTranslator.Translate(locaKey);

	public string UnitName => TextTranslator.Translate(locaKey + " Name");
}
