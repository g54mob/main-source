using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story
{
	public abstract class BaseTargetFilterConfig : ScriptableObjectX
	{
		[HideInInspector]
		public string id;

		protected virtual void OnValidateInternal()
		{
		}

		public BaseTargetFilterConfig()
		{
		}
	}
	public abstract class BaseTargetFilterConfig<T> : BaseTargetFilterConfig
	{
		public abstract List<T> GetAllMatches();
	}
}
