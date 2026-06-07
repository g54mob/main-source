using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.MapEditor
{
	public class MapEditorToolbarUI : MonoBehaviour
	{
		[SerializeField]
		private Button _addIslandButton;

		[SerializeField]
		private Transform _parent;

		[SerializeField]
		private IslandMapEditorButton _buttonPrefab;

		[SerializeField]
		private IslandDatabase _islandsDatabase;

		private void Start()
		{
			_addIslandButton.onClick.AddListener(AddIsland);
			_islandsDatabase.NewIslandLoaded += NewIslandLoaded;
		}

		private void OnDestroy()
		{
			_islandsDatabase.NewIslandLoaded -= NewIslandLoaded;
			_addIslandButton.onClick.RemoveListener(AddIsland);
		}

		private void NewIslandLoaded(IslandData obj)
		{
			IslandMapEditorButton islandMapEditorButton = Object.Instantiate(_buttonPrefab, _parent);
			Texture2D texture2D = new Texture2D(obj.Texture2D.width, obj.Texture2D.height);
			Color32[] pixels = obj.Texture2D.GetPixels32();
			Color32[] array = new Color32[pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
			{
				if (pixels[i].r > 0)
				{
					array[i] = Color.gray;
				}
				if (pixels[i].g > 0)
				{
					array[i] = Color.green;
				}
				if (pixels[i].b > 0)
				{
					array[i] = Color.cyan;
				}
			}
			texture2D.SetPixels32(array);
			texture2D.Apply();
			Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, obj.Texture2D.width, obj.Texture2D.height), new Vector2(0.5f, 0.5f), 100f);
			islandMapEditorButton.SetIsland(sprite, obj.Name, obj.Id);
		}

		private void AddIsland()
		{
			_islandsDatabase.TryLoadNewIslandFromFileSystem();
		}
	}
}
