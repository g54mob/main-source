using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public class GPUIDetailDensityModifier : MonoBehaviour
	{
		public GPUIDetailManager detailManager;

		public List<Collider> selectedColliders;

		public bool useBounds;

		public Vector3 boundsSize;

		public bool applyEveryUpdate;

		public float offset;

		public List<int> selectedPrototypeIndexes;

		[Range(0f, 255f)]
		public float densityValue;

		private Bounds _bounds;

		private bool _isExecuted;

		private void OnEnable()
		{
			SetDetailManager();
			ModifyDetailDensity();
			_bounds = new Bounds(base.transform.position, boundsSize);
		}

		private void Update()
		{
			if (applyEveryUpdate)
			{
				ModifyDetailDensity();
			}
			else if (_isExecuted)
			{
				base.enabled = false;
			}
			else
			{
				ModifyDetailDensity();
			}
		}

		private void SetDetailManager()
		{
			if (detailManager == null)
			{
				detailManager = Object.FindAnyObjectByType<GPUIDetailManager>();
			}
		}

		private void ModifyDetailDensity()
		{
			if (!(detailManager != null) || !detailManager.IsInitialized)
			{
				return;
			}
			if (useBounds)
			{
				_bounds.center = base.transform.position;
				GPUITerrainUtility.SetDetailDensityInsideBounds(detailManager, densityValue, _bounds, offset, selectedPrototypeIndexes);
			}
			else if (selectedColliders != null)
			{
				foreach (Collider selectedCollider in selectedColliders)
				{
					if (selectedCollider != null)
					{
						GPUITerrainUtility.SetDetailDensityInsideCollider(detailManager, selectedCollider, densityValue, offset, selectedPrototypeIndexes);
					}
				}
			}
			_isExecuted = true;
		}
	}
}
