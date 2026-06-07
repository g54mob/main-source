using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Pick Random")]
	[Category("Pick Random")]
	[Description("Selects a random index between the first and last elements of the list")]
	[Image(typeof(IconDice), ColorTheme.Type.Red)]
	public class GetPickRandom : TListGetPick
	{
		public override int GetIndex(int count, Args args)
		{
			return UnityEngine.Random.Range(0, count);
		}

		public override string ToString()
		{
			return "Random";
		}
	}
}
