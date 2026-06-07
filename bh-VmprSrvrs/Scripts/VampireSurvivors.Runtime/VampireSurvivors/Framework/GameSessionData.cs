using System;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class GameSessionData : IInitializable, IDisposable
	{
		private CharacterController _activeCharacter;

		public CharacterController ActiveCharacter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}
	}
}
