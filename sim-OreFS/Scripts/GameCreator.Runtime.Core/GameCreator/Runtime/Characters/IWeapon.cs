using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public interface IWeapon
	{
		IdString Id { get; }

		Texture EditorIcon { get; }

		IReaction HitReaction { get; }

		IReaction ParriedReaction { get; }

		IShield Shield { get; }

		string GetName(Args args);

		string GetDescription(Args args);

		Sprite GetSprite(Args args);

		Color GetColor(Args args);

		Task RunOnEquip(Character character, Args args);

		Task RunOnUnequip(Character character, Args args);

		Task RunOnDodge(Character character, Args args);

		TMunitionValue CreateMunition();
	}
}
