using UnityEngine;

public abstract class HeroController : MonoBehaviour, IAsciiObject
{
	private Hero _hero;

	public Hero hero => _hero;

	public abstract void UpdateInput(float deltaTime);

	protected virtual void Awake()
	{
		_hero = GetComponent<Hero>();
	}

	public virtual void UpdateTic()
	{
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
	}
}
