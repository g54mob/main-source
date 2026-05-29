using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using Unity.AI.Navigation;
using UnityEngine;

namespace CTS
{
	[Constructor("Construct")]
	public class NavMeshRebuilder : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private NavMeshSurface _surface;

		[SerializeField]
		private NavMeshSurface[] _children;

		[SerializeField]
		[NavArea(false)]
		private int _defaultArea;

		private int _currentArea;

		private static readonly HashSet<NavMeshRebuilder> _rebuilding = new HashSet<NavMeshRebuilder>();

		public static bool IsRebuilding => _rebuilding.Count > 0;

		public NavigationArea Area
		{
			get
			{
				return _surface.defaultArea;
			}
			set
			{
				RebuildNavMesh(value);
			}
		}

		public static event Action<NavMeshRebuildInfo> NavMeshRebuilt;

		public event Action AreaChanged;

		private void Construct()
		{
			_currentArea = _defaultArea;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_rebuilding.Remove(this);
		}

		[Button(null, EButtonEnableMode.Playmode)]
		public void ResetNavMesh()
		{
			RebuildNavMesh(_defaultArea);
		}

		public void RebuildNavMesh(int? specificArea = null)
		{
			if (!base.isActiveAndEnabled)
			{
				Debug.LogException(new Exception("Cannot rebuild navmesh on disabled object"));
			}
			else
			{
				if (_surface == null)
				{
					return;
				}
				_currentArea = specificArea ?? _currentArea;
				_surface.defaultArea = _currentArea;
				NavMeshSurface[] children = _children;
				for (int i = 0; i < children.Length; i++)
				{
					children[i].defaultArea = _currentArea;
				}
				this.AreaChanged?.Invoke();
				_rebuilding.Add(this);
				children = _children;
				foreach (NavMeshSurface navMeshSurface in children)
				{
					if ((bool)navMeshSurface.navMeshData)
					{
						navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
					}
					else
					{
						navMeshSurface.BuildNavMesh();
					}
				}
				if ((bool)_surface.navMeshData)
				{
					StopAllCoroutines();
					StartCoroutine(Updating());
				}
				else
				{
					int defaultArea = _surface.defaultArea;
					_surface.BuildNavMesh();
					EndUpdate(defaultArea);
				}
			}
		}

		private IEnumerator Updating()
		{
			int previousArea = _surface.defaultArea;
			yield return _surface.UpdateNavMesh(_surface.navMeshData);
			EndUpdate(previousArea);
		}

		private void EndUpdate(int previousArea)
		{
			NavMeshRebuildInfo obj = new NavMeshRebuildInfo
			{
				PreviousArea = previousArea,
				NavArea = _surface.defaultArea
			};
			_rebuilding.Remove(this);
			NavMeshRebuilder.NavMeshRebuilt?.Invoke(obj);
		}
	}
}
