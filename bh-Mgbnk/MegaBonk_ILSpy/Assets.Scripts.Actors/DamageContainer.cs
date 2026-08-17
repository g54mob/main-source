using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Actors;

public class DamageContainer
{
	public const string unknownDamageSource = "Unkown";

	public Vector3 direction;

	public float damage;

	public bool crit;

	public bool isExecute;

	public float knockback;

	public Enemy enemy;

	public EDamageEffect damageEffect;

	public EElement element;

	public float procCoefficient;

	public string damageSource;

	public int damageBlockedByArmor;

	public DcFlags flags;

	public bool canProcJoe;

	public DamageContainer(float procCoefficient, string damageSource)
	{
		//IL_002a: Expected O, but got I4
		base._002Ector();
		this.procCoefficient = procCoefficient;
		this.damageSource = damageSource;
		direction = (Vector3)0;
		_ = 0;
		crit = false;
		knockback = 0f;
		enemy = null;
		damageEffect = EDamageEffect.None;
		damageBlockedByArmor = 0;
		isExecute = false;
		canProcJoe = false;
	}

	public void Reuse(float procCoefficient, string damageSource)
	{
		//IL_0027: Expected I, but got O
		this.procCoefficient = procCoefficient;
		this.damageSource = damageSource;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		direction = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		damage = 0f;
		crit = false;
		knockback = 0f;
		enemy = null;
		damageEffect = EDamageEffect.None;
		damageBlockedByArmor = 0;
		isExecute = false;
		canProcJoe = false;
	}

	public void Copy(DamageContainer dcOther)
	{
		direction = dcOther.direction;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dcOther @ rdx (Assets.Scripts.Actors.DamageContainer)+18]");
		_ = 0;
		damage = dcOther.damage;
		crit = dcOther.crit;
		knockback = dcOther.knockback;
		enemy = dcOther.enemy;
		damageEffect = dcOther.damageEffect;
		element = dcOther.element;
		procCoefficient = dcOther.procCoefficient;
		damageSource = dcOther.damageSource;
		damageBlockedByArmor = dcOther.damageBlockedByArmor;
		flags = dcOther.flags;
		isExecute = dcOther.isExecute;
		canProcJoe = dcOther.canProcJoe;
	}

	public unsafe Color GetColor()
	{
		//IL_0094: Expected native int or pointer, but got O
		//IL_000e: Expected native int or pointer, but got O
		//IL_001c: Expected native int or pointer, but got O
		//IL_005b: Expected native int or pointer, but got O
		//IL_0069: Expected native int or pointer, but got O
		//IL_003a: Expected native int or pointer, but got O
		//IL_0048: Expected native int or pointer, but got O
		Color color = default(Color);
		if (damageEffect == EDamageEffect.None)
		{
			((Color*)(nint)color)->r = 1f;
			((Color*)(nint)color)->a = 1f;
			if (!crit)
			{
				((Color*)(nint)color)->g = 1f;
				((Color*)(nint)color)->b = 1f;
				return color;
			}
			((Color*)(nint)color)->g = 47f / 51f;
			((Color*)(nint)color)->b = 0.015686275f;
			return color;
		}
		((Color*)(nint)color)->r = MyColorUtility.GetDamageEffectColor(damageEffect).r;
		return color;
	}
}
