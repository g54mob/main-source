using System;
using Unity.Mathematics;
using UnityEngine;

namespace DV.Customization
{
	public class GadgetColliderHolder : MonoBehaviour
	{
		private const float PLAYER_DIST_SQR = 400f;

		[NonSerialized]
		public bool interiorProcessed;

		public GameObject holder { get; private set; }

		public Transform holderTransform { get; private set; }

		private void Awake()
		{
			holder = new GameObject("Holder");
			holder.SetActive(value: false);
			holderTransform = holder.transform;
			holderTransform.SetParent(base.transform, worldPositionStays: false);
			base.gameObject.AddComponent<GadgetColliderHolderEnabler>().mainClass = this;
			base.enabled = CustomizationPlacementMeshes.ShouldBePlacing;
		}

		private void OnEnable()
		{
			RefreshDist();
		}

		private void Update()
		{
			if (!CustomizationPlacementMeshes.ShouldBePlacing)
			{
				base.enabled = false;
				holder.SetActive(value: false);
			}
			else
			{
				RefreshDist();
			}
		}

		private void RefreshDist()
		{
			if (!(PlayerManager.PlayerTransform == null))
			{
				bool flag = math.lengthsq(((float3)(PlayerManager.PlayerTransform.position - base.transform.position)).xz) < 400f;
				if (holder.activeSelf != flag)
				{
					holder.SetActive(flag);
				}
			}
		}
	}
}
