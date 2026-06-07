using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Flight.UI
{
	public class MoveCrewRequest
	{
		public delegate void CrewMoveRequestEnded(string endMessage);

		private DateTime _lastAccessibleCompartmentsUpdated;

		public List<CrewCompartmentScript> AccessibleCrewCompartments { get; private set; }

		public List<EvaScript> Crew { get; }

		public CrewCompartmentScript CrewCompartment { get; }

		public double TimeSinceAccessibleCompartmentsUpdated => (DateTime.Now - _lastAccessibleCompartmentsUpdated).TotalSeconds;

		public event CrewMoveRequestEnded CrewMoveEnded;

		public MoveCrewRequest(EvaScript eva)
		{
			Crew = new List<EvaScript> { eva };
			CrewCompartment = eva.CrewCompartment;
			UpdateAccessibleCompartments();
			if (CrewCompartment != null)
			{
				CrewCompartment.PartScript.PartDestroyed += OnCompartmentDestroyed;
				CrewCompartment.PartScript.CraftScript.CraftStructureChanged += OnCraftStructureChanged;
			}
			eva.PartScript.PartDestroyed += CrewPartDestroyed;
		}

		public void AddCrew(EvaScript crew)
		{
			Crew.Add(crew);
			crew.PartScript.PartDestroyed += CrewPartDestroyed;
			if (CrewCompartment == null)
			{
				UpdateAccessibleCompartments();
			}
		}

		public void CompleteRequest(CrewCompartmentScript target)
		{
			EndCrewMove("Crew Move Complete");
		}

		public void EndCrewMove(string endMessage)
		{
			SetCompartmentsHighlighted(highlighted: false);
			if (CrewCompartment != null)
			{
				CrewCompartment.RefreshInspectorPanel(createIfClosed: false);
				CrewCompartment.PartScript.CraftScript.CraftStructureChanged -= OnCraftStructureChanged;
				CrewCompartment.PartScript.PartDestroyed -= OnCompartmentDestroyed;
			}
			if (Crew.Count > 0)
			{
				foreach (EvaScript item in Crew)
				{
					item.PartScript.PartDestroyed -= CrewPartDestroyed;
				}
			}
			this.CrewMoveEnded(endMessage);
		}

		public void RemoveCrew(EvaScript crew)
		{
			Crew.Remove(crew);
			crew.PartScript.PartDestroyed -= CrewPartDestroyed;
			if (CrewCompartment == null)
			{
				UpdateAccessibleCompartments();
			}
		}

		public void UpdateAccessibleCompartments()
		{
			if (AccessibleCrewCompartments != null && AccessibleCrewCompartments.Count > 0)
			{
				SetCompartmentsHighlighted(highlighted: false);
			}
			if (CrewCompartment != null)
			{
				AccessibleCrewCompartments = CrewCompartment.GetAccessibleCrewCompartments();
			}
			else
			{
				AccessibleCrewCompartments = new List<CrewCompartmentScript>();
				for (int i = 0; i < Crew.Count; i++)
				{
					if (Crew[i] == null)
					{
						Crew.Remove(Crew[i]);
						i--;
						if (Crew.Count == 0)
						{
							EndCrewMove("Crew Move Canceled due to Excessive Distance");
							return;
						}
					}
					foreach (CraftNode craftNode in FlightSceneScript.Instance.FlightState.CraftNodes)
					{
						if (!craftNode.IsPhysicsEnabled)
						{
							continue;
						}
						foreach (PartData part in craftNode.CraftScript.Data.Assembly.Parts)
						{
							CrewCompartmentScript modifier = part.PartScript.GetModifier<CrewCompartmentScript>();
							if (modifier != null && !modifier.IsFull && modifier.IsCloseEnoughToEnterCompartment(Crew[i]) && !AccessibleCrewCompartments.Contains(modifier))
							{
								AccessibleCrewCompartments.Add(modifier);
							}
						}
					}
				}
			}
			SetCompartmentsHighlighted(highlighted: true);
			_lastAccessibleCompartmentsUpdated = DateTime.Now;
		}

		private void CrewPartDestroyed(IPartScript partScript)
		{
			EvaScript modifier = partScript.GetModifier<EvaScript>();
			RemoveCrew(modifier);
			if (Crew.Count == 0)
			{
				EndCrewMove("Crew Move Canceled due to Sudden Astronaut Absence");
			}
		}

		private void OnCompartmentDestroyed(IPartScript partScript)
		{
			EndCrewMove("Crew Move Canceled due to Compartment Destruction");
		}

		private void OnCraftStructureChanged()
		{
			UpdateAccessibleCompartments();
		}

		private void SetCompartmentsHighlighted(bool highlighted)
		{
			foreach (CrewCompartmentScript accessibleCrewCompartment in AccessibleCrewCompartments)
			{
				if (accessibleCrewCompartment?.PartScript?.PartMaterialScript != null)
				{
					accessibleCrewCompartment.PartScript.PartMaterialScript.IsHighlighted = highlighted;
				}
			}
		}
	}
}
