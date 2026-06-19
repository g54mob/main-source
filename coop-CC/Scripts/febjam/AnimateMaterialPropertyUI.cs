using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class AnimateMaterialPropertyUI : EntityBehaviourBase
{
	public string propertyName = "";

	public float value;

	public Image image;

	private Material material;

	protected override void OnEntityCreated()
	{
		material = new Material(image.material);
		image.material = material;
	}

	protected override void OnEntityDestroyed()
	{
		Object.Destroy(material);
	}

	protected override void OnUpdatePresentation()
	{
		material.SetFloat(propertyName, value);
	}
}
