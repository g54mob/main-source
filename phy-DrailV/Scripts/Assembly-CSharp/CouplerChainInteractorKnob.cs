using DV.CabControls;
using DV.CabControls.Spec;
using UnityEngine;

public class CouplerChainInteractorKnob : MonoBehaviour
{
	private Vector3 initialLocalPosition;

	private Quaternion initialLocalRotation;

	private void Awake()
	{
		initialLocalPosition = base.transform.localPosition;
		initialLocalRotation = base.transform.localRotation;
	}

	public void ResetKnob(Renderer highlightTarget)
	{
		ItemBase component = GetComponent<ItemBase>();
		Item specItem = component.SpecItem;
		Rigidbody component2 = GetComponent<Rigidbody>();
		HighlightTag component3 = GetComponent<HighlightTag>();
		if ((bool)component)
		{
			Object.Destroy(component);
		}
		if ((bool)specItem)
		{
			Object.Destroy(specItem);
		}
		if ((bool)component2)
		{
			Object.Destroy(component2);
		}
		if ((bool)component3)
		{
			Object.Destroy(component3);
		}
		base.transform.localPosition = initialLocalPosition;
		base.transform.localRotation = initialLocalRotation;
		component3 = base.gameObject.AddComponent<HighlightTag>();
		component3.renderers.Add(highlightTarget);
		component2 = base.gameObject.AddComponent<Rigidbody>();
		component2.mass = 10f;
		specItem = base.gameObject.AddComponent<Item>();
	}
}
