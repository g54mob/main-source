using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("By Index")]
	[Category("By Index")]
	[Description("Selects the list element at a specific position")]
	[Image(typeof(IconListIndex), ColorTheme.Type.Yellow)]
	public class GetPickIndex : TListGetPick
	{
		[SerializeField]
		private PropertyGetInteger m_Index = GetDecimalInteger.Create(0);

		public override int GetIndex(int count, Args args)
		{
			return (int)m_Index.Get(args);
		}

		public override string ToString()
		{
			return m_Index.ToString();
		}
	}
}
