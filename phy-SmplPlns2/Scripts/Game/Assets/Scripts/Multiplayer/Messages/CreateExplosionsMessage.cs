using System.Collections.Generic;
using Assets.Scripts.Flight;

namespace Assets.Scripts.Multiplayer.Messages
{
	public class CreateExplosionsMessage
	{
		public List<CreateExplosionInfo> Explosions { get; set; } = new List<CreateExplosionInfo>();
	}
}
