using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class FoeArmorPerSecondAoe : MonoBehaviour, IPostAsciiRendererEffect
{
	public int aoeRange = 10;

	public float armorGainPerTic = 10f;

	public float armorGainPerLevel = 1f;

	public float minTargetArmor = 10f;

	public AsciiSprite targetShieldSprite;

	private Enemy myEnemy;

	private List<Enemy> affectedCharacters = new List<Enemy>();

	private void UpdateArmor(Character c)
	{
		if (!myEnemy.Alive)
		{
			return;
		}
		List<Enemy> enemies = GameStates.Singleton.level.Enemies;
		float num = armorGainPerTic + armorGainPerLevel * (float)myEnemy.level;
		affectedCharacters.Clear();
		for (int i = 0; i < enemies.Count; i++)
		{
			Enemy enemy = enemies[i];
			if (!enemy.Alive || enemy == myEnemy || enemy.id == myEnemy.id)
			{
				continue;
			}
			float maxArmor = enemy.MaxArmor;
			if (maxArmor <= 0f)
			{
				maxArmor = minTargetArmor;
			}
			if (Mathf.Abs(enemy.PositionX - myEnemy.PositionX) <= aoeRange)
			{
				if (enemy.Armor < maxArmor)
				{
					enemy.Armor = Mathf.Min(maxArmor, enemy.Armor + num);
				}
				affectedCharacters.Add(enemy);
			}
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (GameStates.Singleton.CurrentState == GameStates.State.Playing || GameStates.Singleton.CurrentState == GameStates.State.PlayPaused)
		{
			for (int i = 0; i < affectedCharacters.Count; i++)
			{
				Enemy enemy = affectedCharacters[i];
				targetShieldSprite.Draw(r, enemy.lastDrawX, enemy.lastDrawY);
			}
		}
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage damage)
	{
		if (c == myEnemy)
		{
			GameStates.Singleton.asciiRenderer.RemovePostEffect(this);
		}
	}

	private void Awake()
	{
		myEnemy = GetComponent<Enemy>();
		myEnemy.OnUpdateTic += UpdateArmor;
		GameStates.Singleton.asciiRenderer.AddPostEffect(this);
		Character.OnCharacterDied += HandleCharacterDied;
	}

	private void OnDestroy()
	{
		myEnemy.OnUpdateTic -= UpdateArmor;
		GameStates.Singleton.asciiRenderer.RemovePostEffect(this);
		Character.OnCharacterDied -= HandleCharacterDied;
		myEnemy = null;
	}
}
