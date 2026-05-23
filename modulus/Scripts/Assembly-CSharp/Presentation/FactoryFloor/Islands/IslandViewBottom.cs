using System.Collections.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandViewBottom : MonoBehaviour
	{
		[SerializeField]
		private GameObject _lockedContainer;

		[SerializeField]
		private List<MeshRenderer> _lockedContainerRends = new List<MeshRenderer>();

		private MeshRenderer[] _cachedMeshRenderers;

		private IslandView _islandView;

		public GameObject LockedContainer => _lockedContainer;

		public List<MeshRenderer> LockedContainerRends => _lockedContainerRends;

		public MeshRenderer[] CachedMeshRenderers => _cachedMeshRenderers;

		public List<MeshRenderer> CachedLockedMeshRenderers => _lockedContainerRends;

		public void Initalize(IslandView islandView)
		{
			_islandView = islandView;
			_islandView.OnViewShow += OnViewShow;
			_islandView.OnViewHide -= OnViewHide;
			_cachedMeshRenderers = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		}

		private void OnDestroy()
		{
			if (_islandView != null)
			{
				_islandView.OnViewShow -= OnViewShow;
				_islandView.OnViewHide -= OnViewHide;
			}
			_islandView = null;
		}

		private void OnViewShow()
		{
			MeshRenderer[] cachedMeshRenderers = _cachedMeshRenderers;
			for (int i = 0; i < cachedMeshRenderers.Length; i++)
			{
				cachedMeshRenderers[i].forceRenderingOff = false;
			}
		}

		private void OnViewHide()
		{
			MeshRenderer[] cachedMeshRenderers = _cachedMeshRenderers;
			for (int i = 0; i < cachedMeshRenderers.Length; i++)
			{
				cachedMeshRenderers[i].forceRenderingOff = true;
			}
		}
	}
}
