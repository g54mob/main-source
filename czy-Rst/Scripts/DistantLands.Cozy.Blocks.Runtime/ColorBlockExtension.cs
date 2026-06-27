using UnityEngine;

public abstract class ColorBlockExtension : ScriptableObject
{
	public abstract void BlendAndApply(ColorBlockExtension other, float weight);

	public virtual void PullFromWorld()
	{
	}

	public void SingleBlock()
	{
		BlendAndApply(this, 0f);
	}

	public void TwoBlock(ColorBlockExtension other, float weight)
	{
		BlendAndApply(other, weight);
	}
}
