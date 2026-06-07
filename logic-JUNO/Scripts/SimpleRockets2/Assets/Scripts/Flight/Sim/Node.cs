using System.Reflection;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public abstract class Node : INode
	{
		public virtual float GameViewLoadDistance => 0f;

		public virtual IGameViewObject GameViewObject => null;

		public bool IsDestroyed { get; protected set; }

		public IPlanetNode Parent { get; set; }

		public abstract Vector3d Position { get; }

		public virtual Vector3d SolarPosition
		{
			get
			{
				if (Parent == null)
				{
					return Position;
				}
				return Position + Parent.SolarPosition;
			}
		}

		public event NodeDelegate Destroyed;

		public Node()
		{
		}

		public virtual void FlightEnd()
		{
		}

		public virtual void FlightLateUpdate(double elapsedTime)
		{
		}

		public virtual void FlightStart()
		{
		}

		public virtual void FlightUpdate(double elapsedTime, double currentTime)
		{
		}

		public virtual void Initialize()
		{
		}

		public virtual void SynchronizeData()
		{
		}

		protected void RaiseDestroyedEvent()
		{
			this.Destroyed?.Invoke(this);
		}
	}
}
