using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public abstract class GadgetComponent : MonoBehaviour
	{
		public GadgetBase ThisGadget { get; private set; }

		public virtual GadgetBase.GadgetRemovalMethod GetValidRemovalMethodsMask()
		{
			return GadgetBase.GadgetRemovalMethod.Any;
		}

		protected virtual void Awake()
		{
			ThisGadget = GetComponent<GadgetBase>();
		}

		protected internal virtual void GeneratePlacementData(Collider placedOnto)
		{
		}

		protected internal virtual void OnGlassBroken()
		{
		}

		protected internal virtual void SaveDataRequested(JObject dst)
		{
		}

		protected internal virtual void SaveDataLoaded(JObject src)
		{
		}

		protected internal virtual void AfterSaveDataLoaded(JObject src)
		{
		}
	}
}
