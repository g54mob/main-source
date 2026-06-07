using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Move To")]
	[Description("Instructs the Character to move to a new location")]
	[Category("Characters/Navigation/Move To")]
	[Parameter("Location", "The position and rotation of the destination")]
	[Parameter("Stop Distance", "Distance to the destination that the Character considers it has reached the target")]
	[Parameter("Cancel on Fail", "Stops executing the rest of Instructions if the path has been obstructed")]
	[Parameter("On Fail", "A list of Instructions executed when it can't reach the destination")]
	[Example("The Stop Distance field is useful if you want [Character A] to approach another [Character B]. With a Stop Distance of 0, [Character A] tries to occupy the same space as the other one, bumping into it. Having a Stop Distance value of 2 allows [Character A] to stop 2 units away from [Character B]'s position")]
	[Keywords(new string[] { "Walk", "Run", "Position", "Location", "Destination" })]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Blue)]
	public class InstructionCharacterNavigationMoveTo : TInstructionCharacterNavigation
	{
		[Serializable]
		public class NavigationOptions
		{
			[SerializeField]
			private bool m_WaitToArrive = true;

			[SerializeField]
			private bool m_CancelOnFail = true;

			[SerializeField]
			private InstructionList m_OnFail = new InstructionList();

			public bool WaitToArrive => m_WaitToArrive;

			public bool CancelOnFail => m_CancelOnFail;

			public InstructionList OnFail => m_OnFail;
		}

		private class NavigationResult
		{
			[NonSerialized]
			private bool m_Complete;

			[NonSerialized]
			private bool m_Success = true;

			public void OnFinish(Character character, bool success)
			{
				m_Complete = true;
				m_Success = success;
			}

			public async Task<bool> Await(NavigationOptions options)
			{
				if (options.WaitToArrive)
				{
					while (!m_Complete)
					{
						await Task.Yield();
					}
				}
				return m_Success;
			}
		}

		[SerializeField]
		private PropertyGetLocation m_Location = GetLocationNavigationMarker.Create;

		[SerializeField]
		private PropertyGetDecimal m_StopDistance = GetDecimalConstantZero.Create;

		[SerializeField]
		private NavigationOptions m_Options = new NavigationOptions();

		[NonSerialized]
		private NavigationResult m_Result;

		public override string Title => $"Move {m_Character} to {m_Location}";

		protected override async Task Run(Args args)
		{
			m_Result = new NavigationResult();
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return;
			}
			Location location = m_Location.Get(args);
			character.Motion.MoveToLocation(location, (float)m_StopDistance.Get(args), m_Result.OnFinish);
			if (!(await m_Result.Await(m_Options)))
			{
				await m_Options.OnFail.Run(args);
				if (m_Options.CancelOnFail)
				{
					base.NextInstruction = int.MaxValue;
				}
			}
		}
	}
}
