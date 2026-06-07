using System;
using UnityEngine.Rendering;

[Serializable]
public class VolumeBlender : Blender<Volume, BlendableVolume>
{
	public void Enable()
	{
		BlendableVolume[] blendables = base.Blendables;
		for (int i = 0; i < blendables.Length; i++)
		{
			blendables[i].Target.gameObject.SetActive(value: true);
		}
	}

	public void Disable()
	{
		BlendableVolume[] blendables = base.Blendables;
		for (int i = 0; i < blendables.Length; i++)
		{
			blendables[i].Target.gameObject.SetActive(value: false);
		}
	}

	protected override void Blend(Volume from, Volume to, float value)
	{
		from.weight = 1f - value;
		to.weight = value;
	}
}
