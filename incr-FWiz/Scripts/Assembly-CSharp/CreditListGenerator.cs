using TMPro;
using UnityEngine;

public class CreditListGenerator : MonoBehaviour
{
	public TextMeshProUGUI CreditTextPrefab;

	public Transform Parent;

	[Header("Text file with one name per line")]
	public TextAsset NamesTxt;

	private void Awake()
	{
	}
}
