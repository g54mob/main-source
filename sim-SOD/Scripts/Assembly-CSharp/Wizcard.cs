using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class Wizcard : MonoBehaviour
{
	[Flags]
	public enum Labels
	{
		None = 0,
		Monster = 1,
		Animal = 2,
		Building = 4,
		Metallic = 8,
		Wooden = 0x10,
		Human = 0x20,
		Mage = 0x40,
		Fabric = 0x80
	}

	[CompilerGenerated]
	private sealed class _003CBuffCO_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Wizcard _003C_003E4__this;

		private SpecialInteraction[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private SpecialInteraction _003CspecialInteraction_003E5__4;

		private List<Wizcard>.Enumerator _003C_003E7__wrap4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CBuffCO_003Ed__32(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAttackCO_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Wizcard _003C_003E4__this;

		private List<Wizcard>.Enumerator _003C_003E7__wrap1;

		private Wizcard _003Cwizcard_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAttackCO_003Ed__36(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public string cardName;

	[InfoBox("Cole: I've moved this description to the computer.csv file for localisation reasons; it now uses the above card name for a key to get this description text.", EInfoBoxType.Normal)]
	[TextArea(3, 10)]
	public string cardDescription;

	public int attack;

	public int health;

	public int startHealth;

	public int mana;

	public int manaPerTurn;

	public Sprite[] boardSprites;

	public CardSpace cardSpace;

	public bool occupySpace;

	public bool enemy;

	public SpecialInteraction[] specialInteractions;

	[SerializeField]
	public Labels labels;

	public bool[] moveSpaces;

	public bool[] spawnSpaces;

	public bool[] attackSpaces;

	public bool[] buffSpaces;

	private WizcardsApp app;

	public int myBoardSpace;

	public bool isHovered;

	private ComputerController comp;

	private ComputerOSUIComponent hoverComponent;

	private RectTransform rectTransform;

	private void Update()
	{
	}

	private void Start()
	{
	}

	public void FindApp()
	{
	}

	public void UpdateStatVisuals()
	{
	}

	private bool IsCursorOverCard()
	{
		return false;
	}

	public void PickUp()
	{
	}

	public void ChangeVisibility(bool visible)
	{
	}

	public void Buff()
	{
	}

	[IteratorStateMachine(typeof(_003CBuffCO_003Ed__32))]
	public IEnumerator BuffCO()
	{
		return null;
	}

	public void Move()
	{
	}

	public void Summon()
	{
	}

	public void Attack()
	{
	}

	[IteratorStateMachine(typeof(_003CAttackCO_003Ed__36))]
	public IEnumerator AttackCO()
	{
		return null;
	}

	public void Die()
	{
	}
}
