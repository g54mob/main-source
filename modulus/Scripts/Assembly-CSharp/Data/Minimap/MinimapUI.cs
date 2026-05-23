using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Events.Minimap;
using Presentation.UI.Menus.HudPanelTabGroups;
using Presentation.UI.Menus.MenuEvents;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Data.Minimap
{
	public class MinimapUI : TabGroupPanel
	{
		[SerializeField]
		private Transform _islandsParent;

		[SerializeField]
		private MinimapIslandUI _islandUIPrefab;

		[SerializeField]
		private MinimapDataCreatedEvent _minimapDataCreatedEvent;

		[SerializeField]
		private RectTransform _minimapBackground;

		[SerializeField]
		private RawImage _fullMapOverlay;

		[SerializeField]
		private MinimapScrollViewControls _minimapScrollViewControls;

		[SerializeField]
		private InputActionReference _minimapToggleInputAction;

		[SerializeField]
		private ShowHudPanelEvent _showHudPanelEvent;

		[SerializeField]
		protected TabGroupPanelSO _tabGroupPanelSo;

		private MinimapData _minimapData;

		private List<MinimapIslandUI> _minimapIslandUIs = new List<MinimapIslandUI>();

		private bool _tryingToShow;

		public MinimapData MinimapData => _minimapData;

		private void Awake()
		{
			_minimapDataCreatedEvent.Register(OnMinimapDataCreated);
		}

		private void OnDestroy()
		{
			_minimapDataCreatedEvent.UnRegister(OnMinimapDataCreated);
		}

		public override void ShowPanel()
		{
			if (_minimapData == null)
			{
				_tryingToShow = true;
			}
			else
			{
				base.gameObject.SetActive(value: true);
			}
		}

		public override void HidePanel()
		{
			_tryingToShow = false;
			_minimapScrollViewControls.SetMinimapHidden();
			base.gameObject.SetActive(value: false);
		}

		private void OnMinimapDataCreated(MinimapData minimapData)
		{
			DestroyIslandImages();
			_minimapData = minimapData;
			for (int i = 0; i < minimapData.MinimapTextures.Length; i++)
			{
				CreateIslandImage(minimapData.MinimapTextures[i], minimapData.IslandObjects[i]);
			}
			_fullMapOverlay.texture = minimapData.FullMapOverlayTexture;
			_minimapBackground.sizeDelta = new Vector2(minimapData.MapBounds.size.x, minimapData.MapBounds.size.z);
			if (_tryingToShow && !base.gameObject.activeSelf)
			{
				ShowPanel();
			}
		}

		private void CreateIslandImage(RenderTexture minimapTexture, IslandObject islandObject)
		{
			MinimapIslandUI minimapIslandUI = Object.Instantiate(_islandUIPrefab, _islandsParent);
			minimapIslandUI.SetIslandTexture(minimapTexture, islandObject, _minimapData);
			_minimapIslandUIs.Add(minimapIslandUI);
		}

		private void DestroyIslandImages()
		{
			for (int num = _minimapIslandUIs.Count - 1; num >= 0; num--)
			{
				Object.Destroy(_minimapIslandUIs[num].gameObject);
			}
			_minimapIslandUIs.Clear();
		}

		public void FocusMinimapOnWorldPosition(Vector3 worldPosition)
		{
			_minimapScrollViewControls.FocusOnPosition(_minimapData.WorldPosToLocalPos(worldPosition), _minimapData);
		}
	}
}
