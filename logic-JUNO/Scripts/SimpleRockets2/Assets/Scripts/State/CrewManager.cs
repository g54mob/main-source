using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Scripts.State;

namespace Assets.Scripts.State
{
	public class CrewManager
	{
		private GameState _gameState;

		private List<CrewMember> _members = new List<CrewMember>();

		private int _nextCrewMemberId = 1;

		public IEnumerable<CrewMember> Members => _members;

		public CrewManager(XElement xml, GameState gameState)
		{
			_gameState = gameState;
			if (xml == null)
			{
				return;
			}
			_nextCrewMemberId = xml.GetIntAttribute("nextId");
			IEnumerable<XElement> enumerable = xml.Elements("CrewMember");
			if (enumerable == null)
			{
				return;
			}
			List<int> list = gameState.LoadFlightStateData().CraftNodes.Select((ICraftNodeData x) => x.NodeId).ToList();
			foreach (XElement item in enumerable)
			{
				CrewMember crewMember = new CrewMember(item);
				if (crewMember.State == CrewMemberState.InFlight && crewMember.NodeId >= 0 && !list.Contains(crewMember.NodeId))
				{
					crewMember.NodeId = -1;
					crewMember.State = CrewMemberState.Available;
				}
				_members.Add(crewMember);
			}
		}

		public CrewMember CreateCrewMember()
		{
			CrewMember crewMember = new CrewMember(_nextCrewMemberId++, Utilities.NameGenerator.FullName(null));
			crewMember.Location = string.Empty;
			crewMember.State = CrewMemberState.Available;
			_members.Add(crewMember);
			_gameState.Save();
			return crewMember;
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("CrewMembers");
			xElement.SetAttributeValue("nextId", _nextCrewMemberId);
			foreach (CrewMember member in Members)
			{
				xElement.Add(member.GenerateXml());
			}
			return xElement;
		}

		public List<CrewMember> GetAvailableCrew(Assembly assembly)
		{
			List<EvaData> modifiers = assembly.GetModifiers<EvaData>();
			List<CrewMember> list = Members.Where((CrewMember x) => x.State == CrewMemberState.Available).ToList();
			List<CrewMember> list2 = new List<CrewMember>();
			foreach (CrewMember member in list)
			{
				if (!modifiers.Any((EvaData x) => x.CrewId == member.Id))
				{
					list2.Add(member);
				}
			}
			return list2;
		}

		public CrewMember GetCrewMember(int crewId)
		{
			return Members.Where((CrewMember x) => x.Id == crewId).FirstOrDefault();
		}
	}
}
