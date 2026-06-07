using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	private int _hp = 5;

	public int maxHealth = 100;

	public int ressurects;

	public int mainframe;

	public int armor;

	private bool flashing;

	public Module sentinel;

	public Dungeon dungeon => Dungeon.Instance;

	public Animator animator => GetComponent<Animator>();

	public Vector3 pos
	{
		get
		{
			return base.transform.position;
		}
		set
		{
			base.transform.position = value;
		}
	}

	public int health
	{
		get
		{
			return _hp;
		}
		set
		{
			_hp = value;
			dungeon.hpText.text = $"HP:{health}/{maxHealth}";
		}
	}

	public List<Trigger> triggers => sentinel.triggers;

	private IEnumerator Wait(int x)
	{
		return Dungeon.Wait(x);
	}

	public void Start()
	{
		health = maxHealth;
	}

	public void Heal(int x)
	{
		if (health > 0 || ressurects != 0)
		{
			x += dungeon.board.CountAuras(Aura.Type.HealBuff);
			dungeon.animationManager.CreateNumber(x, base.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), 0.1875f), Number.Type.Heal);
			health = Mathf.Min(maxHealth, health + x);
			dungeon.board.TriggerModules(global::Trigger.Type.Heal);
		}
	}

	public void Hurt(int x)
	{
		if (!dungeon.combat || health <= 0)
		{
			return;
		}
		CreateGibs();
		x -= armor;
		dungeon.audioManager.PlaySound(Utils.Rand(AudioManager.Sound.Hurt0, AudioManager.Sound.Hurt1), Random.Range(1f, 1.2f));
		StartCoroutine(Flash());
		if (!dungeon.godMode)
		{
			health -= x;
		}
		dungeon.board.TriggerModules(global::Trigger.Type.Hurt);
		if (health <= 0 && dungeon.testMode)
		{
			health = Random.Range(20, 40);
		}
		if (health <= 0)
		{
			if (ressurects > 0)
			{
				health = 0;
				Heal(maxHealth / 2);
				ressurects--;
			}
			else
			{
				CreateDeathGibs();
				dungeon.GameOver(win: false);
			}
		}
		dungeon.animationManager.Screenshake();
		dungeon.animationManager.CreateNumber(x, base.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), 0.1875f), Number.Type.Hurt);
	}

	private void CreateGibs()
	{
		int num = dungeon.currLevel;
		if (dungeon.endlessLevel > 0 && num > 30)
		{
			num %= 30;
			if (num == 0)
			{
				num = 30;
			}
		}
		if (dungeon.demo)
		{
			num = 1;
		}
		if (num >= 11)
		{
			if (num < 21)
			{
				dungeon.animationManager.CreateGibs("657392", base.transform.position, 4f, 0.5f, unmasked: false, 1.25f);
				dungeon.animationManager.CreateGibs("0098DC", base.transform.position, 1f, 0.5f, unmasked: false, 1.25f);
				dungeon.animationManager.CreateGibs("424C6E", base.transform.position, 1f, 0.5f, unmasked: false, 1.25f);
			}
			else
			{
				dungeon.animationManager.CreateGibs("0098DC", base.transform.position, 3f, 0.5f, unmasked: false, 1.25f);
				dungeon.animationManager.CreateGibs("5AC54F", base.transform.position, 3f, 0.5f, unmasked: false, 1.25f);
			}
		}
		else
		{
			dungeon.animationManager.CreateGibs("5D5D5C", base.transform.position, 4f, 0.5f, unmasked: false, 1.25f);
			dungeon.animationManager.CreateGibs("894836", base.transform.position, 1f, 0.5f, unmasked: false, 1.25f);
		}
	}

	private void CreateDeathGibs()
	{
		dungeon.audioManager.PlaySound(AudioManager.Sound.Player_Death);
		spriteRenderer.enabled = false;
		int num = dungeon.currLevel;
		if (dungeon.endlessLevel > 0 && num > 30)
		{
			num %= 30;
			if (num == 0)
			{
				num = 30;
			}
		}
		if (dungeon.demo)
		{
			num = 1;
		}
		if (num >= 11)
		{
			if (num < 21)
			{
				dungeon.animationManager.CreatePermaGibs("657392", base.transform.position, 8f, 0.5f);
				dungeon.animationManager.CreatePermaGibs("0098DC", base.transform.position, 2f, 0.5f);
				dungeon.animationManager.CreatePermaGibs("424C6E", base.transform.position, 2f, 0.5f);
			}
			else
			{
				dungeon.animationManager.CreatePermaGibs("0098DC", base.transform.position, 6f, 0.5f);
				dungeon.animationManager.CreatePermaGibs("5AC54F", base.transform.position, 6f, 0.5f);
			}
		}
		else
		{
			dungeon.animationManager.CreatePermaGibs("5D5D5C", base.transform.position, 8f, 0.5f);
			dungeon.animationManager.CreatePermaGibs("894836", base.transform.position, 2f, 0.5f);
		}
	}

	private IEnumerator Flash()
	{
		if (!flashing)
		{
			flashing = true;
			Material def = spriteRenderer.material;
			spriteRenderer.material = dungeon.shadowMat;
			yield return Wait(10);
			spriteRenderer.material = def;
			flashing = false;
		}
	}

	internal void EndRound()
	{
		health = maxHealth;
		dungeon.board.TriggerModules(global::Trigger.Type.Heal);
	}

	public void Trigger(Trigger.Type t, Module source = null)
	{
		sentinel.Trigger(t, source);
	}

	public void AddTrigger(Trigger t, int timer = -1)
	{
		sentinel.AddTrigger(t, timer);
	}

	public void AddTrigger(Trigger.Ability ability, Aura source = null, float proc = 100f, int val = 0, int dmg = 1)
	{
		sentinel.AddTrigger(ability, source, proc, val, dmg);
	}

	public void AddAura(Aura a, int timer = -1)
	{
		sentinel.AddAura(a, timer);
	}

	public void AddAura(Aura.Type a, int timer = -1)
	{
		sentinel.AddAura(a, timer);
	}
}
