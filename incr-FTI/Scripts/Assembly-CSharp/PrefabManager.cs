using TMPro;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
	private static PrefabManager _instance;

	public GameObject userInputPrefab;

	public GameObject menuPrefab;

	public GameObject iconManagerPrefab;

	public GameObject soundManagerPrefab;

	public GameObject colorManagerPrefab;

	public GameObject musicPlayerPrefab;

	public GameObject miningMapPrefab;

	public TMP_FontAsset primaryFont;

	public TMP_FontAsset japaneseFont;

	public TMP_FontAsset chineseFont;

	public static PrefabManager Instance => _instance;

	private void Awake()
	{
		_instance = this;
	}
}
