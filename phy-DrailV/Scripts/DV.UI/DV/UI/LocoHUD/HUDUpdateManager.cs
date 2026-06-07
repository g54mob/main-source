using System.Collections.Generic;
using DV.Utils;

namespace DV.UI.LocoHUD
{
	public class HUDUpdateManager : SingletonBehaviour<HUDUpdateManager>
	{
		public interface IUpdateSlave
		{
			void DoUpdate();
		}

		private HashSet<IUpdateSlave> slaves = new HashSet<IUpdateSlave>();

		private List<IUpdateSlave> copyList = new List<IUpdateSlave>();

		public new static string AllowAutoCreate()
		{
			return "[HUDUpdateManager]";
		}

		private void Update()
		{
			foreach (IUpdateSlave slafe in slaves)
			{
				copyList.Add(slafe);
			}
			foreach (IUpdateSlave copy in copyList)
			{
				copy.DoUpdate();
			}
			copyList.Clear();
		}

		public void AddSlave(IUpdateSlave slave)
		{
			slaves.Add(slave);
		}

		public void RemoveSlave(IUpdateSlave slave)
		{
			slaves.Remove(slave);
		}
	}
}
