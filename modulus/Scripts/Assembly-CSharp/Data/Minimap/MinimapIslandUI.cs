using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Events.Islands;
using UnityEngine;
using UnityEngine.UI;

namespace Data.Minimap
{
	public class MinimapIslandUI : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private int _borderSize = 2;

		[SerializeField]
		private RectTransform _resizeParent;

		[SerializeField]
		private RawImage _image;

		[SerializeField]
		private RectTransform _lockedView;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private UnlockedIslandEventSO _unlockedIslandEvent;

		private IslandObject _islandObject;

		public void SetIslandTexture(RenderTexture renderTexture, IslandObject islandObject, MinimapData minimapData)
		{
			_image.texture = renderTexture;
			_resizeParent.sizeDelta = new Vector2(islandObject.Size.x, islandObject.Size.y);
			_rectTransform.anchoredPosition = new Vector2(islandObject.Position.x, islandObject.Position.z) - minimapData.Center;
			_lockedView.gameObject.SetActive(!_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject));
			_islandObject = islandObject;
			_unlockedIslandEvent.Register(OnIslandUnlocked);
			if (islandObject.IslandConfig.IsGNNGateIsland && !_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject))
			{
				_resizeParent.gameObject.SetActive(value: false);
			}
		}

		private void OnDestroy()
		{
			_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
		}

		private void OnIslandUnlocked(IslandObject islandObject)
		{
			if (islandObject == _islandObject)
			{
				_lockedView.gameObject.SetActive(value: false);
				_resizeParent.gameObject.SetActive(value: true);
			}
		}
	}
}
