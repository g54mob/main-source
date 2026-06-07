using DV.CabControls.Spec;
using DV.Items;
using UnityEngine;

public class EOTLantern : Lantern
{
	[SerializeField]
	[Header("Snappable on coupler")]
	private Transform transformToRotateOnSnapToCoupler;

	[SerializeField]
	private float couplerSnapRotation = -85f;

	[SerializeField]
	private float couplerUnsnapRotation;

	[SerializeField]
	private AudioClip couplerSnapSound;

	[SerializeField]
	private AudioClip couplerUnsnapSound;

	private SnappableItem snappableItem;

	protected override void Initialize()
	{
		snappableItem = GetComponent<SnappableItem>();
		base.Initialize();
	}

	protected override void SetupListeners(bool on)
	{
		base.SetupListeners(on);
		if (!(snappableItem == null))
		{
			if (on)
			{
				snappableItem.ItemSnappingChanged += OnItemSnappingChanged;
			}
			else
			{
				snappableItem.ItemSnappingChanged -= OnItemSnappingChanged;
			}
		}
	}

	private void OnItemSnappingChanged(SnappableItem item, bool snapped, SnapPointTypes snapPointType)
	{
		if (snapPointType == SnapPointTypes.Coupler)
		{
			RotateTransform(snapped);
			AudioClip audioClip = (snapped ? couplerSnapSound : couplerUnsnapSound);
			if (!snapped && !base.gameObject.activeInHierarchy)
			{
				base.gameObject.SetActive(value: true);
			}
			if (audioClip != null)
			{
				audioClip.Play(transformToRotateOnSnapToCoupler.position);
			}
		}
	}

	private void RotateTransform(bool snap)
	{
		float x = (snap ? couplerSnapRotation : couplerUnsnapRotation);
		transformToRotateOnSnapToCoupler.localRotation = Quaternion.Euler(x, 0f, 0f);
	}
}
