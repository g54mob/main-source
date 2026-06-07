using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public abstract class TWeapon : ScriptableObject, IWeapon
	{
		[SerializeField]
		private UniqueID m_Id = new UniqueID();

		[SerializeField]
		private PropertyGetString m_Title = GetStringString.Create;

		[SerializeField]
		private PropertyGetString m_Description = GetStringTextArea.Create();

		[SerializeField]
		private PropertyGetSprite m_Icon = GetSpriteNone.Create;

		[SerializeField]
		private PropertyGetColor m_Color = GetColorColorsWhite.Create;

		[SerializeField]
		private Reaction m_HitReaction;

		[SerializeField]
		private Reaction m_ParriedReaction;

		[SerializeField]
		private RunInstructionsList m_OnEquip = new RunInstructionsList();

		[SerializeField]
		private RunInstructionsList m_OnUnequip = new RunInstructionsList();

		[SerializeField]
		private RunInstructionsList m_OnDodge = new RunInstructionsList();

		public IdString Id => m_Id.Get;

		public abstract Texture EditorIcon { get; }

		public abstract IShield Shield { get; }

		public IReaction HitReaction => m_HitReaction;

		public IReaction ParriedReaction => m_ParriedReaction;

		public string GetName(Args args)
		{
			return m_Title.Get(args);
		}

		public string GetDescription(Args args)
		{
			return m_Description.Get(args);
		}

		public Sprite GetSprite(Args args)
		{
			return m_Icon.Get(args);
		}

		public Color GetColor(Args args)
		{
			return m_Color.Get(args);
		}

		public virtual async Task RunOnEquip(Character character, Args args)
		{
			await m_OnEquip.Run(args);
		}

		public virtual async Task RunOnUnequip(Character character, Args args)
		{
			await m_OnUnequip.Run(args);
		}

		public virtual async Task RunOnDodge(Character character, Args args)
		{
			await m_OnDodge.Run(args);
		}

		public abstract TMunitionValue CreateMunition();

		public override string ToString()
		{
			return TextUtils.Humanize(base.name);
		}
	}
}
