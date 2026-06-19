using Aggro.Core;
using UnityEngine;

public class StationPreview : EntityBehaviourBase
{
	public Renderer[] renderers;

	public Color valid;

	public Color invalid;

	public void SetPlacement(Vector3 position, Quaternion rotation, bool isValid)
	{
		base.entity.transform.SetPositionAndRotation(position, rotation);
		Renderer[] array = renderers;
		for (int i = 0; i < array.Length; i++)
		{
			Material[] materials = array[i].materials;
			for (int j = 0; j < materials.Length; j++)
			{
				materials[j].SetColor("_blueprintColor", isValid ? valid : invalid);
			}
		}
	}
}
