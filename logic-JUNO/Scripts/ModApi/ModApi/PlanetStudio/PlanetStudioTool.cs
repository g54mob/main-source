using UnityEngine.EventSystems;

namespace ModApi.PlanetStudio
{
	public class PlanetStudioTool
	{
		public bool Active { get; private set; }

		public ICelestialBodyDesigner Designer { get; private set; }

		public string Name { get; private set; }

		public PlanetStudioTool(ICelestialBodyDesigner designer)
		{
			Designer = designer;
			Name = GetType().Name;
		}

		public virtual void Activate()
		{
			Active = true;
		}

		public virtual void Deactivate()
		{
			Active = false;
		}

		public virtual bool OnDrag(PointerEventData eventData)
		{
			return false;
		}

		public virtual bool OnPointerDown(PointerEventData eventData)
		{
			return false;
		}

		public virtual bool OnPointerUp(PointerEventData eventData)
		{
			return false;
		}

		public virtual void Update(float deltaTime)
		{
		}
	}
}
