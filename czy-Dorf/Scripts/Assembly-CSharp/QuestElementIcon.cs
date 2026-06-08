using System;
using TMPro;
using UnityEngine;

public class QuestElementIcon : MonoBehaviour
{
	private TextMeshPro countLabel;

	[SerializeField]
	private MeshRenderer elementRenderer;

	[SerializeField]
	private SpriteRenderer fulfilledSprite;

	[SerializeField]
	private SpriteRenderer unfulfillableSprite;

	private string labelText;

	public Material SharedMaterial => elementRenderer.sharedMaterial;

	public Material Material => elementRenderer.material;

	private void Awake()
	{
		countLabel = GetComponentInChildren<TextMeshPro>();
	}

	public void Setup(QuestCondition condition)
	{
		labelText = condition.GetLabelText();
	}

	public void UpdateLabelText(int currentValue)
	{
		string text = labelText;
		text = text.Replace("[currentValue]", currentValue.ToString());
		countLabel.text = text;
	}

	public void UpdateLabelText(string overwriteString)
	{
		countLabel.text = overwriteString;
	}

	public void SetFulfillmentState(FulfillmentStatus fulfillmentStatus)
	{
		try
		{
			fulfilledSprite.gameObject.SetActive(fulfillmentStatus == FulfillmentStatus.Fulfilled);
			unfulfillableSprite.gameObject.SetActive(fulfillmentStatus == FulfillmentStatus.Unfulfillable);
			countLabel.gameObject.SetActive(fulfillmentStatus == FulfillmentStatus.Changed || fulfillmentStatus == FulfillmentStatus.Unchanged);
		}
		catch (Exception arg)
		{
			Debug.Log($"Error: {arg}");
		}
	}

	public void SetMaterial(QuestElementIcon referenceElementIcon)
	{
		Debug.Log($"{elementRenderer.name} set material to {referenceElementIcon} material");
		elementRenderer.sharedMaterial = referenceElementIcon.SharedMaterial;
	}

	public void SetTextColor(Color newColor)
	{
		countLabel.color = newColor;
	}

	public void SetRendererLayer(int targetLayer)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = targetLayer;
		}
	}
}
