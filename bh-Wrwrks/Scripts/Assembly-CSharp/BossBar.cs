using System.Collections;
using TMPro;
using UnityEngine;

public class BossBar : MonoBehaviour
{
	public new TMP_Text name;

	public SpriteRenderer redBar;

	private Monster currMonster;

	private Dungeon dungeon => Dungeon.Instance;

	private AnimationManager animationManager => Dungeon.Instance.animationManager;

	public void StartBoss(Monster m)
	{
		base.transform.localScale = new Vector3(1f, 0f);
		string text = m.type.ToString();
		currMonster = m;
		switch (m.type)
		{
		case Monster.Type.BOSS_Saint:
			text = dungeon.GetText(LocalizationManager.Text.Saint);
			break;
		case Monster.Type.BOSS_Squid:
			text = dungeon.GetText(LocalizationManager.Text.Squid);
			break;
		case Monster.Type.BOSS_Mothership:
			text = dungeon.GetText(LocalizationManager.Text.Mothership);
			break;
		default:
			Debug.LogWarning("BOSS");
			break;
		}
		name.text = text;
		name.color = new Color(1f, 1f, 1f, 0f);
		StartCoroutine(opener());
		StartCoroutine(barControl());
	}

	private IEnumerator barControl()
	{
		if (currMonster == null)
		{
			yield break;
		}
		while (currMonster.health > 0 && !(currMonster == null))
		{
			redBar.transform.localScale = new Vector3((float)currMonster.health / (float)currMonster.maxHealth, 1f);
			yield return Dungeon.Wait(1);
			if (currMonster == null)
			{
				break;
			}
		}
		redBar.transform.localScale = new Vector3(0f, 1f);
		yield return Dungeon.Wait(30);
		for (int i = 0; i < 5; i++)
		{
			name.color += new Color(0f, 0f, 0f, -0.2f);
			yield return Dungeon.Wait(1);
		}
		EndBoss();
	}

	private IEnumerator opener()
	{
		yield return Dungeon.Wait(30);
		yield return animationManager.LerpZoom(base.gameObject, Vector3.one, 5f, 0.1f);
		for (int i = 0; i < 5; i++)
		{
			name.color += new Color(0f, 0f, 0f, 0.2f);
			yield return Dungeon.Wait(1);
		}
	}

	private void EndBoss()
	{
		currMonster = null;
		animationManager.LerpZoom(base.gameObject, new Vector3(1f, 0f), 5f);
	}
}
