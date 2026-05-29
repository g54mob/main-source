using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class MapEntry : MonoBehaviour
{
	public RawImage mapIcon;

	public GameObject locked;

	public GameObject notificationIcon;

	public SelectionGroupToggleSingleButton buttonScript;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_name;

	public MapData mapData { get; private set; }

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnLocaleChanged(Locale obj)
	{
	}

	private void OnMapSelected(SelectionGroupToggleSingleButton arg1, MapData arg2)
	{
	}

	public void Set(MapData mapData)
	{
	}
}
