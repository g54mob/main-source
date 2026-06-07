using UnityEngine;

namespace RLD
{
	public class RTPrefabLibDbUI : MonoBehaviour
	{
		private RTActiveLibDropDown _activeLibDropDown;

		private RTPrefabScrollView _prefabScrollView;

		private RTHoveredPrefabNameLabel _hoveredPrefabNameLabel;

		public RTActiveLibDropDown ActiveLibDropDown => _activeLibDropDown;

		public RTPrefabScrollView PrefabScrollView => _prefabScrollView;

		public RTHoveredPrefabNameLabel HoveredPrefabNameLabel => _hoveredPrefabNameLabel;

		private void Awake()
		{
			_activeLibDropDown = base.gameObject.GetComponentInChildren<RTActiveLibDropDown>();
			_prefabScrollView = base.gameObject.GetComponentInChildren<RTPrefabScrollView>();
			_hoveredPrefabNameLabel = base.gameObject.GetComponentInChildren<RTHoveredPrefabNameLabel>();
			_prefabScrollView.PrefabPreviewHoverEnter += OnPrefabPreviewHoverEnter;
			_prefabScrollView.PrefabPreviewHoverExit += OnPrefabPreviewHoverExit;
		}

		private void OnPrefabPreviewHoverEnter(RTPrefab prefab)
		{
			HoveredPrefabNameLabel.PrefabName = ((prefab.UnityPrefab != null) ? prefab.UnityPrefab.name : string.Empty);
		}

		private void OnPrefabPreviewHoverExit(RTPrefab prefab)
		{
			HoveredPrefabNameLabel.PrefabName = string.Empty;
		}
	}
}
