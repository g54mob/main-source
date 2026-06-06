using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RecipeAnimationVisual : RecipeVisual
{
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private AnimationClip _clip;

	public override void StartRecipe(float startProgress)
	{
		_animator.speed = _clip.length / _recipeProperties.ProductionTime;
		_animator.Play(_clip.name);
	}

	public override void FinishRecipe()
	{
		_animator.speed = 0f;
	}
}
