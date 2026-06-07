using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class TagsUIScript : MonoBehaviour
	{
		[SerializeField]
		private GameObject _prefab;

		private List<GameObject> _tags = new List<GameObject>();

		public void Clear()
		{
			base.gameObject.SetActive(value: false);
			foreach (GameObject tag in _tags)
			{
				Object.Destroy(tag);
			}
		}

		public void CreateTag(string tagName)
		{
			base.gameObject.SetActive(value: true);
			GameObject gameObject = Object.Instantiate(_prefab);
			gameObject.transform.SetParent(_prefab.transform.parent, worldPositionStays: false);
			gameObject.SetActive(value: true);
			_tags.Add(gameObject);
			TextMeshProUGUI[] componentsInChildren = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].text = tagName;
			}
		}
	}
}
