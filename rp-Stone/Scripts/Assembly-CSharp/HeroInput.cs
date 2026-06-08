using UnityEngine;

[RequireComponent(typeof(Hero))]
public class HeroInput : HeroController
{
	public override void UpdateInput(float deltaTime)
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			base.hero.PositionX--;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			base.hero.PositionX++;
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			base.hero.PositionZ--;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			base.hero.PositionZ++;
		}
	}

	private void Start()
	{
	}
}
