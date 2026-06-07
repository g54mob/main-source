using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MalbersAnimations
{
	public abstract class IDs : ScriptableObject
	{
		[Tooltip("Display name on the ID Selection Context Button")]
		public string DisplayName;

		[Tooltip("Integer value to Identify IDs")]
		public int ID;

		public static implicit operator int(IDs reference)
		{
			if (!(reference != null))
			{
				return 0;
			}
			return reference.ID;
		}

		protected virtual void OnValidate()
		{
			if (string.IsNullOrEmpty(DisplayName))
			{
				DisplayName = base.name;
			}
		}

		protected void FindID<T>() where T : IDs
		{
			int newID = 0;
			List<T> allInstances = MTools.GetAllInstances<T>();
			bool flag = true;
			while (flag)
			{
				newID++;
				flag = allInstances.Exists((T x) => x.ID == newID && x != this);
			}
			ID = newID;
			DisplayName = base.name;
			MTools.SetDirty(this);
		}

		public bool Included<T>(List<T> list, bool include) where T : IDs
		{
			bool flag = list.Contains(this);
			if (!include)
			{
				return !flag;
			}
			return flag;
		}

		public bool Included(List<IDs> list)
		{
			return Included(list, include: true);
		}

		public bool Excluded(List<IDs> list)
		{
			return Included(list, include: false);
		}
	}
}
