using System.Collections.Generic;
using DV.Interaction;
using UnityEngine;

namespace DV.Items
{
	public class PaintSprayerEffects : MonoBehaviour
	{
		public AudioClip soundOnInsert;

		public AudioClip soundOnExtract;

		public AudioClip soundOnReplaced;

		[SerializeField]
		private List<ItemRendererDynamic> dynamicParts = new List<ItemRendererDynamic>();

		[SerializeField]
		private GameObject dummyCan;

		private void Start()
		{
			if (dynamicParts.Count <= 0)
			{
				Debug.LogError("PaintSprayerEffects: Missing ItemRendererDynamic references. Transparency will not be handled.", this);
			}
			foreach (ItemRendererDynamic dynamicPart in dynamicParts)
			{
				if (dynamicPart == null)
				{
					Debug.LogError("PaintSprayerEffects: Null entry in dynamicParts. This should not happen.", this);
				}
				else
				{
					dynamicPart.Initialize();
				}
			}
		}

		public void OnInserted(PaintCan insertedCan, bool playSound)
		{
			if (dynamicParts.Count > 0)
			{
				foreach (ItemRendererDynamic dynamicPart in dynamicParts)
				{
					if (!(dynamicPart == null))
					{
						dynamicPart.UpdateDynamicMaterialsCache(insertedCan.OriginalMaterials);
					}
				}
			}
			if (dummyCan != null)
			{
				dummyCan.SetActive(value: true);
			}
			if (playSound && !(soundOnInsert == null))
			{
				if (base.gameObject.activeInHierarchy)
				{
					soundOnInsert.Play(base.transform.position);
				}
				else
				{
					soundOnInsert.Play2D();
				}
			}
		}

		public void OnExtracted()
		{
			if (dummyCan != null)
			{
				dummyCan.SetActive(value: false);
			}
			if (!(soundOnExtract == null))
			{
				if (base.gameObject.activeInHierarchy)
				{
					soundOnExtract.Play(base.transform.position);
				}
				else
				{
					soundOnExtract.Play2D();
				}
			}
		}

		public void OnSpent()
		{
			if (!(soundOnReplaced == null))
			{
				if (base.gameObject.activeInHierarchy)
				{
					soundOnReplaced.Play(base.transform.position);
				}
				else
				{
					soundOnReplaced.Play2D();
				}
			}
		}
	}
}
