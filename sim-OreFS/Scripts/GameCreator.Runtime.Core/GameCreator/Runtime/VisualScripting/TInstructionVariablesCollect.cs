using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Origin", "The position where the rest of the game objects are collected")]
	[Parameter("Max Radius", "How far from the Origin the game objects are collected")]
	[Parameter("Min Radius", "How far from the Origin game objects start to be collected")]
	[Parameter("Store In", "List where the collected game objects are saved")]
	[Parameter("Filter", "Checks a set of Conditions with each collected game object")]
	[Example("Note that in most cases it is not desirable to set the Min Radius to 0. Doing so will also collect game objects at a distance of 0 from the Origin. For example, if we want to collect all enemies around the Player and we set a Min Radius of 0, the Player will also be collected because it's a Character at a distance 0 from himself")]
	[Keywords(new string[] { "Gather", "Get", "Set", "Array", "List", "Variables" })]
	public abstract class TInstructionVariablesCollect : Instruction
	{
		[SerializeField]
		private PropertyGetPosition m_Origin = GetPositionCharacter.Create;

		[SerializeField]
		private PropertyGetDecimal m_MaxRadius = GetDecimalDecimal.Create(5f);

		[SerializeField]
		private PropertyGetDecimal m_MinRadius = GetDecimalDecimal.Create(0.01f);

		[SerializeField]
		private CollectorListVariable m_StoreIn = new CollectorListVariable();

		public override string Title => $"Collect {TitleTarget} within {m_Origin} {m_MaxRadius} units";

		protected abstract string TitleTarget { get; }

		protected override Task Run(Args args)
		{
			Vector3 origin = m_Origin.Get(args);
			float maxRadius = (float)m_MaxRadius.Get(args);
			float minRadius = (float)m_MinRadius.Get(args);
			List<GameObject> list = Collect(origin, maxRadius, minRadius);
			m_StoreIn.Fill(list.ToArray(), args);
			return Instruction.DefaultResult;
		}

		protected abstract List<GameObject> Collect(Vector3 origin, float maxRadius, float minRadius);
	}
}
