using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;

namespace ModApi.Craft.Program
{
	public class ProgramEventHandler
	{
		private Process _process;

		public ProgramEventHandler(Process process)
		{
			_process = process;
		}

		public void OnChangeSoi(string name)
		{
			List<EventInstruction> events = GetEvents(ProgramEventType.ChangeSoi);
			if (events.Count <= 0)
			{
				return;
			}
			foreach (EventInstruction item in events)
			{
				ThreadContext threadContext = CreateThread(item);
				if (threadContext != null)
				{
					threadContext.CreateLocalVariable("planet").Value.TextValue = name;
				}
			}
		}

		public void OnCraftDocked(string craftNameA, string craftNameB)
		{
			List<EventInstruction> events = GetEvents(ProgramEventType.Docked);
			if (events.Count <= 0)
			{
				return;
			}
			foreach (EventInstruction item in events)
			{
				ThreadContext threadContext = CreateThread(item);
				if (threadContext != null)
				{
					threadContext.CreateLocalVariable("craftA").Value.TextValue = craftNameA;
					threadContext.CreateLocalVariable("craftB").Value.TextValue = craftNameB;
				}
			}
		}

		public void OnFlightStart()
		{
			foreach (EventInstruction @event in GetEvents(ProgramEventType.FlightStart))
			{
				CreateThread(@event);
			}
		}

		public void OnPartCollision(IPartFlightCollision partCollision)
		{
			List<EventInstruction> events = GetEvents(ProgramEventType.PartCollision);
			if (events.Count <= 0)
			{
				return;
			}
			string textValue = (partCollision.IsGroundCollision ? "Ground" : ((partCollision.OtherPartScript == null) ? partCollision.Contact.otherCollider.gameObject.name : partCollision.OtherPartScript.Data.Name));
			foreach (EventInstruction item in events)
			{
				ThreadContext threadContext = CreateThread(item);
				if (threadContext != null)
				{
					threadContext.CreateLocalVariable("part").Value.TextValue = partCollision.PartScript.Data.Name;
					threadContext.CreateLocalVariable("other").Value.TextValue = textValue;
					threadContext.CreateLocalVariable("velocity").Value.VectorValue = partCollision.RelativeVelocity;
					threadContext.CreateLocalVariable("impulse").Value.NumberValue = partCollision.Impulse;
				}
			}
		}

		public void OnPartExploded(PartData part)
		{
			List<EventInstruction> events = GetEvents(ProgramEventType.PartExplode);
			if (events.Count <= 0)
			{
				return;
			}
			foreach (EventInstruction item in events)
			{
				ThreadContext threadContext = CreateThread(item);
				if (threadContext != null)
				{
					threadContext.CreateLocalVariable("part").Value.TextValue = part.Name;
				}
			}
		}

		public void OnReceiveMessage(string messageName, ExpressionResult data)
		{
			foreach (EventInstruction @event in GetEvents(ProgramEventType.ReceiveMessage))
			{
				if (@event.Expressions.Count > 0 && GetEventMessageName(@event) == messageName)
				{
					ThreadContext threadContext = CreateThread(@event);
					if (threadContext != null && data != null)
					{
						threadContext.CreateLocalVariable("data").Value.Set(data);
					}
				}
			}
		}

		private static string GetEventMessageName(EventInstruction e)
		{
			return (e.GetExpression(0) as ConstantExpression)?.ExpressionResult.TextValue;
		}

		private ThreadContext CreateThread(EventInstruction e)
		{
			ThreadContext threadContext = _process.CreateThread(e);
			if (threadContext == null)
			{
				string arg = e.EventType.ToString();
				if (e.EventType == ProgramEventType.ReceiveMessage)
				{
					arg = "Receive Message: " + GetEventMessageName(e);
				}
				_process.LogService.LogError($"Could not start thread from event '{arg}' because thread queue is full. Max size = {_process.MaxThreads}");
			}
			return threadContext;
		}

		private List<EventInstruction> GetEvents(ProgramEventType eventType)
		{
			List<EventInstruction> list = new List<EventInstruction>();
			foreach (ProgramInstruction rootInstruction in _process.Program.RootInstructions)
			{
				if (rootInstruction is EventInstruction eventInstruction && eventInstruction.EventType == eventType)
				{
					list.Add(eventInstruction);
				}
			}
			return list;
		}
	}
}
