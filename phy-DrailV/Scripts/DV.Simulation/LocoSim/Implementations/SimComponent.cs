using System.Collections.Generic;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;

namespace LocoSim.Implementations
{
	public abstract class SimComponent
	{
		private readonly List<Fuse> allFuses = new List<Fuse>();

		private readonly List<FuseReference> allFuseReferences = new List<FuseReference>();

		private readonly List<Port> allPorts = new List<Port>();

		private readonly List<PortReference> allPortReferences = new List<PortReference>();

		public readonly string id;

		protected SimGameParams gameParams;

		public virtual bool HasSaveData => false;

		protected SimComponent(string id)
		{
			this.id = id;
		}

		public void SetGameParams(SimGameParams gameParams)
		{
			this.gameParams = gameParams;
		}

		protected Fuse AddFuse(FuseDefinition fDef)
		{
			Fuse fuse = new Fuse(id, fDef);
			allFuses.Add(fuse);
			return fuse;
		}

		protected FuseReference AddFuseReference(string fuseId)
		{
			FuseReference fuseReference = new FuseReference(fuseId);
			allFuseReferences.Add(fuseReference);
			return fuseReference;
		}

		protected Port AddPort(PortDefinition pDef, float defaultValue = 0f)
		{
			Port port = new Port(id, pDef, defaultValue);
			allPorts.Add(port);
			return port;
		}

		protected PortReference AddPortReference(PortReferenceDefinition prDef, float defaultValue = 0f)
		{
			PortReference portReference = new PortReference(id, prDef, defaultValue);
			allPortReferences.Add(portReference);
			return portReference;
		}

		public virtual void InitializationAfterConnecting()
		{
		}

		public abstract void Tick(float delta);

		public List<Fuse> GetAllFuses()
		{
			return allFuses;
		}

		public List<FuseReference> GetAllFuseReferences()
		{
			return allFuseReferences;
		}

		public List<Port> GetAllPorts()
		{
			return allPorts;
		}

		public List<PortReference> GetAllPortReferences()
		{
			return allPortReferences;
		}

		public virtual JObject GetSaveStateData()
		{
			return null;
		}

		public virtual void SetSaveStateData(JObject savedData)
		{
		}
	}
}
