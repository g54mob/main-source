using System;
using System.Collections.Generic;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Collect Characters")]
	[Description("Collects all Characters that within a certain radius of a position")]
	[Image(typeof(IconBust), ColorTheme.Type.Teal, typeof(OverlayListVariable))]
	[Category("Variables/Collect Characters")]
	public class InstructionVariablesCollectCharacters : TInstructionVariablesCollect
	{
		[NonSerialized]
		private List<ISpatialHash> m_Results = new List<ISpatialHash>();

		protected override string TitleTarget => "Characters";

		protected override List<GameObject> Collect(Vector3 origin, float maxRadius, float minDistance)
		{
			List<GameObject> list = new List<GameObject>();
			SpatialHashCharacters.Find(origin, maxRadius, m_Results);
			foreach (ISpatialHash result in m_Results)
			{
				if (!(Vector3.Distance(result.Position, origin) <= minDistance))
				{
					Character character = result as Character;
					if (!(character == null))
					{
						list.Add(character.gameObject);
					}
				}
			}
			return list;
		}
	}
}
