using TMPro;
using UnityEngine;

namespace Brewery.Localization
{
	[RequireComponent(typeof(TMP_Text))]
	public class TMPLocBinder : MonoBehaviour
	{
		[Tooltip("String table collection name (e.g. UI_General, Interact)")]
		[SerializeField]
		private string table;

		[Tooltip("String table entry key (e.g. LOADING)")]
		[SerializeField]
		private string key;

		private TMP_Text _text;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Apply()
		{
		}
	}
}
